using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models.Base;
using VideoClubAPI.Models.EF;

namespace VideoClubAPI.Models
{
    public class ClientesViewModel : IViewModel<Clientes>
    {
        //PROPIEDADES DEL ENTETY FRAMEWORK
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        //Externas al Modelo
        public List<PeliculasViewModel> PeliculasCliente { get; set; }


        public void FromModel(Clientes model)
        {
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;
            idCliente = model.idCliente;

            try
            {
                var temp = new List<PeliculasViewModel>();
                foreach (var pelicula in model.Peliculas)
                {
                    var temp1 = new PeliculasViewModel();
                    temp1.FromModel(pelicula);
                    temp.Add(temp1);
                }
                PeliculasCliente = temp;
            }
            catch (Exception)
            {
                PeliculasCliente = null;
            }
        }

        public int[] GetPK()
        {
            return new[] { idCliente };
        }

        public Clientes ToModel()
        {
            return new Clientes
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                idCliente = idCliente
            };
        }

        public void UpdateModel(Clientes model)
        {
            model.Nombre = Nombre;
            model.Apellidos = Apellidos;
            model.idCliente = idCliente;
        }
    }
}