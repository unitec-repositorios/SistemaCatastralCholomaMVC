using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using MySql.Data.MySqlClient;
using System.Net.Http.Headers;

namespace SistemaCatastralCholoma.Controllers
{
    public class PropietarioController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();

        // GET: api/Propietario
        [HttpGet]
        public HttpResponseMessage listPropietarios()
        {
            List<Propietario> propietarios = new List<Propietario>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propietario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    propietarios.Add(new Propietario((string)reader["id"], (string)reader["nombres"], (string)reader["apellidos"],
                        (string)reader["telefono"],(string)reader["rtn"],reader.GetChar("sexo"),(string)reader["nacionalidad"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propietarios);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            }
        }

        // GET: api/Propietario/5
        [HttpGet]
        public HttpResponseMessage getPropietario(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propietario where id = '"+id+"'";

                MySqlDataReader reader = query.ExecuteReader(); 
                

                Propietario propietario = new Propietario();
                while (reader.Read())
                {
                    propietario = new Propietario((string)reader["id"], (string)reader["nombres"], (string)reader["apellidos"],
                        (string)reader["telefono"], (string)reader["rtn"], reader.GetChar("sexo"), (string)reader["nacionalidad"]);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // POST: api/Propietario
        [HttpPost]
        public HttpResponseMessage crearPropietario(Propietario propietario)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO propietario VALUES (@id,@nombres,@apellidos,@telefono,@rtn,@sexo,@nacionalidad);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", propietario.id);
                query.Parameters.AddWithValue("@nombres", propietario.nombres);
                query.Parameters.AddWithValue("@apellidos", propietario.apellidos);
                query.Parameters.AddWithValue("@telefono", propietario.telefono);
                query.Parameters.AddWithValue("@rtn", propietario.rtn);
                query.Parameters.AddWithValue("@sexo", propietario.sexo);
                query.Parameters.AddWithValue("@nacionalidad", propietario.nacionalidad);
                query.ExecuteNonQuery();

                conn.Close();

                var response =  Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // PUT: api/Propietario/5
        [HttpPut]
        public HttpResponseMessage modificarPropietario(string id, Propietario propietario)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE propietario SET nombres=@nombres," +
                                                            "apellidos = @apellidos," +
                                                            "telefono = @telefono," +
                                                            "rtn = @rtn," +
                                                            "sexo = @sexo," +
                                                            "nacionalidad = @nacionalidad where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@nombres", propietario.nombres);
                query.Parameters.AddWithValue("@apellidos", propietario.apellidos);
                query.Parameters.AddWithValue("@telefono", propietario.telefono);
                query.Parameters.AddWithValue("@rtn", propietario.rtn);
                query.Parameters.AddWithValue("@sexo", propietario.sexo);
                query.Parameters.AddWithValue("@nacionalidad", propietario.nacionalidad);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE: api/Propietario/5
        [HttpDelete]
        public HttpResponseMessage deletePropietario(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from propietario where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}
