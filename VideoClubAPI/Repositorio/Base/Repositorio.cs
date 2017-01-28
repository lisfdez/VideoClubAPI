using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using VideoClubAPI.Models.Base;
using VideoClubAPI.Models.EF;

namespace VideoClubAPI.Repositorio.Base
{
    public class Repositorio<TView, TEntry> : IRepositorio<TView, TEntry> where TView : class, IViewModel<TEntry>, new() where TEntry : class
    {
        // CODIGO AÑADIDO
        private VideoClubEntities Context;

        public Repositorio(VideoClubEntities context)
        {
            Context = context;
        }

        protected DbSet<TEntry> DbSet
        {
            get { return Context.Set<TEntry>(); }
        }
        // FIN CODIGO AÑADIDO


        public virtual TView Add(TView model)
        {
            var data = model.ToModel();

            DbSet.Add(data);

            try
            {
                Context.SaveChanges();
                model.FromModel(data);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                return null;
            }
            return model;
        }

        public virtual int Delete(int pk)
        {
            var obj = DbSet.Find(pk);
            DbSet.Remove(obj);

            int n = 0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;
        }

        public virtual int Delete(Expression<Func<TEntry, bool>> busqueda)
        {
            var data = DbSet.Where(busqueda);

            foreach (var view in data)
            {
                DbSet.Remove(view);
            }

            try
            {
                return Context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public virtual List<TView> Find(Expression<Func<TEntry, bool>> busqueda)
        {
            var data = DbSet.Where(busqueda);

            var lista = new List<TView>();

            foreach (var obj in data)
            {
                var view = new TView();

                view.FromModel(obj);

                lista.Add(view);
            }

            return lista;
        }

        public virtual List<TView> Get()
        {
            var lista = new List<TView>();
            var data = DbSet;

            foreach (var obj in data)
            {
                var v = new TView();
                v.FromModel(obj);
                lista.Add(v);
            }

            return lista;
        }

        public virtual TView Get(int pk)
        {
            var model = DbSet.Find(pk);
            var view = new TView();

            view.FromModel(model);

            return view;
        }

        public virtual TEntry GetModelbyPk(TView model)
        {
            int[] pks = model.GetPK();
            TEntry data = null;

            if (pks.Length == 1)
            {
                data = DbSet.Find(pks[0]);
            }
            else if (pks.Length == 2)
            {
                data = DbSet.Find(pks[0], pks[1]);
            }
            else if (pks.Length == 3)
            {
                data = DbSet.Find(pks[0], pks[1], pks[2]);
            }

            return data;
        }

        public virtual TView Update(TView model)
        {
            var data = GetModelbyPk(model);

            model.UpdateModel(data);

            try
            {
                int r = Context.SaveChanges();
                model.FromModel(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return model;
        }
    }
}