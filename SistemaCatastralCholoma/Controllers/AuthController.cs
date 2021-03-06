﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using System.Data.SqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class AuthController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[empleado]";

        // POST: api/Auth
        [HttpPost]
        public HttpResponseMessage login(Empleado empleado)
        {
            try {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"select * from {DatabaseReference} where nombre = @nombre and password = @pass";

                query.Prepare();
                query.Parameters.AddWithValue("@nombre", empleado.nombre);
                query.Parameters.AddWithValue("@pass", empleado.password);

                SqlDataReader reader = query.ExecuteReader();

                
                if (reader.HasRows) {
                    reader.Read();
                    Empleado fetchedEmpleado = new Empleado((string)reader["nombre"], (string)reader["password"], (Int32)reader["tipo"], (string)reader["UserType"]);
                    if (reader.GetString(0).Equals(empleado.nombre) && reader.GetString(1).Equals(empleado.password))
                        return Request.CreateResponse(HttpStatusCode.OK, fetchedEmpleado);
                }
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.NotFound, "No se encontro empleado con esa combinacion de usuario y contraseña");
            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
}

    }
}
