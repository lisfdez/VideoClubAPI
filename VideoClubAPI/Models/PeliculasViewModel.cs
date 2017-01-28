using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models.Base;
using VideoClubAPI.Models.EF;

namespace VideoClubAPI.Models
{
    public class PeliculasViewModel : IViewModel<Peliculas>
    {
        //PROPIEDADES DEL ENTETY FRAMEWORK
        public int idPelicula { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public string Pais { get; set; }
        public string Genero { get; set; }
        public string Descripcion { get; set; }
        public int? idCliente { get; set; }

        //Externas al modelo
        public List<ActoresViewModel> ActoresPelicula { get; set; }


        public void FromModel(Peliculas model)
        {
            Año = model.Año;
            Descripcion = model.Descripcion;
            Genero = model.Genero;
            Nombre = model.Nombre;
            Pais = model.Pais;
            idCliente = model.idCliente;
            idPelicula = model.idPelicula;
        }

        public int[] GetPK()
        {
            return new[] { idPelicula };
        }

        public Peliculas ToModel()
        {
            return new Peliculas
            {
                Nombre = Nombre,
                Pais = Pais,
                idCliente = idCliente,
                idPelicula = idPelicula,
                Año = Año,
                Genero = Genero,
                Descripcion = Descripcion
            };
        }

        public void UpdateModel(Peliculas model)
        {
            model.Nombre = Nombre;
            model.Año = Año;
            model.Descripcion = Descripcion;
            model.Genero = Genero;
            model.Pais = Pais;
            model.idCliente = idCliente;
            model.idPelicula = idPelicula;
        }
    }
}