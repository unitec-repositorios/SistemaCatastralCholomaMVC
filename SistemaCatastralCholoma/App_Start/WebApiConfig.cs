using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using WebApiContrib.Core.Formatter.Jsonp;
using System.Net.Http.Headers;


namespace SistemaCatastralCholoma
{
    public static class WebApiConfig
    {
        public static String DatabaseName()
        {
            //[DatabaseName].[dboofDatabaseUseradminName]  retrurnedhere
            return "[cholomatest].[dbo]";
            //if there is no need for server name use the next line. 
            //return "";
        }
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

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

        }

        public static SqlConnection conn()
        {
            string conn_string = "Server=DESKTOP-BNO2SU0;Database=cholomatest;Integrated Security=true";//server=bkmilcp6nvs1hgkadyz6-Sql.services.clever-cloud.com;port=3306;database=bkmilcp6nvs1hgkadyz6;Uid=uedhxkzl6doratlh;Pwd=xDdW8Ro6Rg01GUnJsjLW;
            //Server=WIN-RJQFJ758DS1;Database=cholomatest;User Id=DBA;Password=Hello123; servidor
            //"Server=DESKTOP-BNO2SU0;Database=cholomatest;Integrated Security=true;" local

            SqlConnection conn = new SqlConnection(conn_string);

            return conn;
        }
    }
}
