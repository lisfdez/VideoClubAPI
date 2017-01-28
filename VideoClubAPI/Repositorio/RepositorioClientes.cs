using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClubAPI.Models;
using VideoClubAPI.Models.EF;
using VideoClubAPI.Repositorio.Base;

namespace VideoClubAPI.Repositorio
{
    public class RepositorioClientes : Repositorio<ClientesViewModel, Clientes>
    {
        public RepositorioClientes(VideoClubEntities context) : base(context)
        {
        }
    }
}