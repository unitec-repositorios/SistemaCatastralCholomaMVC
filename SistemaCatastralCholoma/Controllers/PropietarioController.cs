using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace SistemaCatastralCholoma.Controllers
{
    public class PropietarioController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();

        // GET: api/Propietario
        [HttpGet]
        public HttpResponseMessage listPropietarios()
        {
            List<Propietario> propietarios = new List<Propietario>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propietarios";

                SqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    propietarios.Add(new Propietario((int)reader["id"], (string)reader["nombres"], (string)reader["apellidos"], (string)reader["identidad"],
                        (string)reader["telefono"],(string)reader["rtn"],reader.GetChar("sexo"),(string)reader["nacionalidad"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propietarios);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.NoContent, e.Message);
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
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propietarios where id = '"+id+"'";

                SqlDataReader reader = query.ExecuteReader(); 
                

                Propietario propietario = new Propietario();
                while (reader.Read())
                {
                    propietario = new Propietario((int)reader["id"], (string)reader["nombres"], (string)reader["apellidos"],(string)reader["identidad"],
                        (string)reader["telefono"], (string)reader["rtn"], reader.GetChar("sexo"), (string)reader["nacionalidad"]);
                }
                conn.Close();
                if (propietario.id == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;


            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
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

                if (propietario.nombres.Equals("") || propietario.apellidos.Equals("") || propietario.identidad.Equals(""))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"El formulario esta incompleto");
                }

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO propietarios VALUES (@id,@nombres,@apellidos,@identidad,@rtn,@telefono,@sexo,@nacionalidad);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", null);
                query.Parameters.AddWithValue("@nombres", propietario.nombres);
                query.Parameters.AddWithValue("@apellidos", propietario.apellidos);
                query.Parameters.AddWithValue("@identidad", propietario.identidad);
                query.Parameters.AddWithValue("@telefono", propietario.telefono);
                query.Parameters.AddWithValue("@rtn", propietario.rtn);
                query.Parameters.AddWithValue("@sexo", propietario.sexo);
                query.Parameters.AddWithValue("@nacionalidad", propietario.nacionalidad);
                query.ExecuteNonQuery();

               

                query.CommandText = "Select * from propietarios where identidad = '" + propietario.identidad + "'";
                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                propietario.id = reader.GetInt32("id");

                conn.Close();
                var response =  Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,"Ocurrio un error al enviar el formulario");
                return response;
            }
        }

        // PUT: api/Propietario/5
        [HttpPut]
        public HttpResponseMessage modificarPropietario(int id, Propietario propietario)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE propietarios SET nombres=@nombres," +
                                                            "apellidos = @apellidos," +
                                                            "telefono = @telefono," +
                                                            "identidad = @identidad,"+
                                                            "rtn = @rtn," +
                                                            "sexo = @sexo," +
                                                            "nacionalidad = @nacionalidad where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@nombres", propietario.nombres);
                query.Parameters.AddWithValue("@apellidos", propietario.apellidos);
                query.Parameters.AddWithValue("@identidad", propietario.identidad);
                query.Parameters.AddWithValue("@telefono", propietario.telefono);
                query.Parameters.AddWithValue("@rtn", propietario.rtn);
                query.Parameters.AddWithValue("@sexo", propietario.sexo);
                query.Parameters.AddWithValue("@nacionalidad", propietario.nacionalidad);
                query.ExecuteNonQuery();

                conn.Close();
                propietario.id = id;
                var response = Request.CreateResponse(HttpStatusCode.OK, propietario);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE: api/Propietario/5
        [HttpDelete]
        public HttpResponseMessage deletePropietario(int id)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from propietarios where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, "No se encontro propietario con identidad "+id);
                return response;
            }
        }
    }
}
