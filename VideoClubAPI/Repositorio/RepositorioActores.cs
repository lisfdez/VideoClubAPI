using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models;
using VideoClubAPI.Models.EF;
using VideoClubAPI.Repositorio.Base;

namespace VideoClubAPI.Repositorio
{
    public class RepositorioActores : Repositorio<ActoresViewModel, Actores>
    {
        public RepositorioActores(VideoClubEntities context) : base(context)
        {
        }

        public List<ActoresViewModel> ObtenerActoresPorPelicula(int idPelicula)
        {
            var listaIdActoresPorPelicula = new RepositorioActoresPeliculas(new VideoClubEntities()).Find(bd => bd.idPelicula == idPelicula);

            var listaActores = new List<ActoresViewModel>();

            foreach (var idActoresPorPelicula in listaIdActoresPorPelicula)
            {
                var actor = Get(idActoresPorPelicula.idActor);
                listaActores.Add(actor);
            }

            return listaActores;
        }
    }
}