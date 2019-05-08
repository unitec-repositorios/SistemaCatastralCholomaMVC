using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static MySqlConnection conn()
        {
            string conn_string = "server=bkmilcp6nvs1hgkadyz6-mysql.services.clever-cloud.com;port=3306;database=bkmilcp6nvs1hgkadyz6;Uid=uedhxkzl6doratlh;Pwd=xDdW8Ro6Rg01GUnJsjLW ";


            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }
    }
}
