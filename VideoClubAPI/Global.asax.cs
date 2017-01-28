using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace VideoClubAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //LINEA COPIADA AL INSTALAR LOS NUGET DE UNITY.WEBAPI
            UnityConfig.RegisterComponents();
        }
    }
}
