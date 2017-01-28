using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models.Base;
using VideoClubAPI.Models.EF;

namespace VideoClubAPI.Models
{
    public class ActoresPeliculasViewModel : IViewModel<Actores_Peliculas>
    {
        //PROPIEDADES DEL ENTETY FRAMEWORK
        public int idActor_Pelicula { get; set; }
        public int idPelicula { get; set; }
        public int idActor { get; set; }
        public Nullable<int> Sueldo { get; set; }

        //EXTERNAS AL MODELO
        public PeliculasViewModel PeliActores { get; set; }
        public ActoresViewModel ActoresPeli { get; set; }


        public void FromModel(Actores_Peliculas model)
        {
            idActor = model.idActor;
            idPelicula = model.idPelicula;
            idActor_Pelicula = model.idActor_Pelicula;
            Sueldo = model.Sueldo;
        }

        public int[] GetPK()
        {
            return new[] { idActor_Pelicula };
        }

        public Actores_Peliculas ToModel()
        {
            return new Actores_Peliculas
            {
                idActor = idActor,
                idPelicula = idPelicula,
                idActor_Pelicula = idActor_Pelicula,
                Sueldo = Sueldo
            };
        }

        public void UpdateModel(Actores_Peliculas model)
        {
            model.idActor = idActor;
            model.Sueldo = Sueldo;
            model.idActor_Pelicula = idActor_Pelicula;
            model.idPelicula = idPelicula;
        }
    }
}