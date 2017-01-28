using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models;
using VideoClubAPI.Models.EF;
using VideoClubAPI.Repositorio.Base;

namespace VideoClubAPI.Repositorio
{
    public class RepositorioPeliculas : Repositorio<PeliculasViewModel, Peliculas>
    {
        public RepositorioPeliculas(VideoClubEntities context) : base(context)
        {
        }

        public List<PeliculasViewModel> ObtenerPeliculasPorActor(int idActores)
        {
            var listaIdPeliculasPorActor = new RepositorioActoresPeliculas(new VideoClubEntities()).Find(bd => bd.idActor == idActores);
            var listaPeliculas = new List<PeliculasViewModel>();

            foreach (var idPeliculaPorActor in listaIdPeliculasPorActor)
            {
                var pelicula = Get(idPeliculaPorActor.idActor);
                listaPeliculas.Add(pelicula);
            }

            return listaPeliculas;
        }
    }
}