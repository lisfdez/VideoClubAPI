using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models;
using VideoClubAPI.Models.EF;
using VideoClubAPI.Repositorio.Base;

namespace VideoClubAPI.Repositorio
{
    public class RepositorioActoresPeliculas : Repositorio<ActoresPeliculasViewModel, Actores_Peliculas>
    {
        public RepositorioActoresPeliculas(VideoClubEntities context) : base(context)
        {
        }
    }
}