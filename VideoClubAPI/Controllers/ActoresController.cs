using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using VideoClubAPI.Repositorio;
using VideoClubAPI.Models;

namespace VideoClubAPI.Controllers
{
    public class ActoresController : ApiController
    {
        //AÑADIR LAS DEPENDENCY
        [Dependency]
        public RepositorioPeliculas _repoPelis { get; set; }

        [Dependency]
        public RepositorioActores _repoActores { get; set; }


        // GET: api/Actores
        public IEnumerable<ActoresViewModel> Get()
        {
            return _repoActores.Get();
        }

        // GET: api/Actores/5
        public ActoresViewModel Get(int id)
        {
            return _repoActores.Get(id);
        }

        // POST: api/Actores
        public void Post([FromBody]ActoresViewModel mivalue)
        {
            _repoActores.Add(mivalue);
        }

        // PUT: api/Actores/5
        public void Put(int id, [FromBody]ActoresViewModel value)
        {
            _repoActores.Update(value);
        }

        // DELETE: api/Actores/5
        public void Delete(int id)
        {
            _repoActores.Delete(id);
        }

        // METODO AÑADIDO PARA EL BUSCADOR
        [HttpGet]
        public List<ActoresViewModel> BuscarActores(String busqueda)
        {
            return _repoActores.Find(bd => bd.Nombre.ToLower().Contains(busqueda.ToLower()) || bd.Apellidos.ToLower().Contains(busqueda.ToLower()));
        }
    }
}
