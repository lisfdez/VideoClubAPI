using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoClubAPI.Models;
using VideoClubAPI.Repositorio;

namespace VideoClubAPI.Controllers
{
    public class PeliculasController : ApiController
    {
        //AÑADIR LAS DEPENDENCY
        [Dependency]
        public RepositorioPeliculas _repoPelis { get; set; }

        [Dependency]
        public RepositorioActores _repoActores { get; set; }


        // GET: api/Peliculas
        public IEnumerable<PeliculasViewModel> Get()
        {
            return _repoPelis.Get();
        }

        // GET: api/Peliculas/5
        public PeliculasViewModel Get(int id)
        {
            var pelicula = _repoPelis.Get(id);
            pelicula.ActoresPelicula = _repoActores.ObtenerActoresPorPelicula(pelicula.idPelicula);

            return pelicula;
        }

        // POST: api/Peliculas
        public void Post([FromBody]PeliculasViewModel mivalue)
        {
            _repoPelis.Add(mivalue);
        }

        // PUT: api/Peliculas/5
        public void Put(int id, [FromBody]PeliculasViewModel value)
        {
            _repoPelis.Update(value);
        }

        // DELETE: api/Peliculas/5
        public void Delete(int id)
        {
            _repoPelis.Delete(id);
        }

        // METODO AÑADIDO PARA EL BUSCADOR
        [HttpGet]
        public List<PeliculasViewModel> BuscarPeliculas(String busqueda)
        {
            return _repoPelis.Find(bd => bd.Nombre.ToLower().Contains(busqueda.ToLower()));
        }
    }
}
