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
    public class ClientesController : ApiController
    {
        //AÑADIR LAS DEPENDENCY
        [Dependency]
        public RepositorioClientes _repoClientes { get; set; }

        [Dependency]
        public RepositorioPeliculas _repoPeliculas { get; set; }


        // GET: api/Clientes
        public IEnumerable<ClientesViewModel> Get()
        {
            return _repoClientes.Get();
        }

        // GET: api/Clientes/5
        public ClientesViewModel Get(int id)
        {
            return _repoClientes.Get(id);
        }

        // POST: api/Clientes
        public void Post([FromBody]ClientesViewModel mivalue)
        {
            _repoClientes.Add(mivalue);
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]ClientesViewModel value)
        {
            _repoClientes.Update(value);
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
            _repoClientes.Delete(id);
        }
    }
}
