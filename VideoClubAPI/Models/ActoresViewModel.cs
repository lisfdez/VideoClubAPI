using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models.Base;
using VideoClubAPI.Models.EF;

namespace VideoClubAPI.Models
{
    public class ActoresViewModel : IViewModel<Actores>
    {
        //PROPIEDADES DEL ENTETY FRAMEWORK
        public int idActor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public PeliculasViewModel PeliculasActores { get; set; }

        //EXTERNA AL MODELO
        public int SueldoActorEnPelicula { get; set; }

        //NECESARIA PARA EL USO DE MVC
        public int idPelicula { get; set; }


        public void FromModel(Actores model)
        {
            idActor = model.idActor;
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;
        }

        public int[] GetPK()
        {
            return new[] { idActor };
        }

        public Actores ToModel()
        {
            return new Actores
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                idActor = idActor
            };
        }

        public void UpdateModel(Actores model)
        {
            model.Nombre = Nombre;
            model.Apellidos = Apellidos;
            model.idActor = idActor;
        }
    }
}