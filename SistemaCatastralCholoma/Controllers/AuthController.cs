using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SistemaCatastralCholoma.Models;


namespace SistemaCatastralCholoma.Controllers
{
    public class AuthController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();

        // POST: api/Auth
        [HttpPost]
        public HttpResponseMessage login(Empleado empleado)
        {
            try {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "select * from empleado where nombre = @nombre and password = @pass";

                query.Prepare();
                query.Parameters.AddWithValue("@nombre", empleado.nombre);
                query.Parameters.AddWithValue("@pass", empleado.password);

                MySqlDataReader reader = query.ExecuteReader();

                
                if (reader.HasRows) {
                    reader.Read();
                    Empleado fetchedEmpleado = new Empleado(reader.GetString("nombre"), reader.GetString("password"), (TIPO_EMPLEADO)reader.GetInt32("tipo"));
                    if (reader.GetString(0).Equals(empleado.nombre) && reader.GetString(1).Equals(empleado.password))
                        return Request.CreateResponse(HttpStatusCode.OK, fetchedEmpleado);
                }
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.NotFound, "No se encontro empleado con esa combinacion de usuario y contraseña");
            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
}

    }
}
