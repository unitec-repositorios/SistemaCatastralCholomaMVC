using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SistemaCatastralCholoma.Models;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class ServiciosPublicosController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/
        [HttpGet]
        public HttpResponseMessage listServiciosPublicos()
        {
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from serviciospublicos", conn);
                reader = cmd.ExecuteReader();
                List<ServiciosPublicos> sp = new List<ServiciosPublicos>();
                while (reader.Read())
                {
                    sp.Add(new ServiciosPublicos((int)reader["idserviciospublicos"], (string)reader["Agua"],
                        (string)reader["Telefono"], (String)reader["Drenaje"], (String)reader["Calle"],
                        (String)reader["Electricidad"], (String)reader["Acera"], (String)reader["Alumbrado"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, sp);
                return response;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        [HttpGet]
        public HttpResponseMessage getServiciosPublicos(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from serviciospublicos where idserviciospublicos = " + id;

                MySqlDataReader reader = query.ExecuteReader();


                ServiciosPublicos sp = new ServiciosPublicos();
                while (reader.Read())
                {
                    sp = new ServiciosPublicos((int)reader["idserviciospublicos"], (String)reader["Agua"], (string)reader["Telefono"],
                        (String)reader["Drenaje"], (string)reader["Calle"], (string)reader["Electricidad"], (String)reader["Acera"], (string)reader["Alumbrado"]);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, sp);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage createServiciosPublicos(ServiciosPublicos sp)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO serviciospublicos VALUES (@idserviciospublicos,@Agua,@Telefono,@Drenaje,@Calle,@Electricidad,@Acera,@Alumbrado);";

                query.Prepare();
                query.Parameters.AddWithValue("@idserviciospublicos", sp.idserviciospublicos);
                query.Parameters.AddWithValue("@Agua", sp.Agua);
                query.Parameters.AddWithValue("@Telefono", sp.Telefono);
                query.Parameters.AddWithValue("@Drenaje", sp.Drenaje);
                query.Parameters.AddWithValue("@Calle", sp.Calle);
                query.Parameters.AddWithValue("@Electricidad", sp.Electricidad);
                query.Parameters.AddWithValue("@Acera", sp.Acera);
                query.Parameters.AddWithValue("@Alumbrado", sp.Alumbrado);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, sp);
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
        public HttpResponseMessage modifyServicioPublico(int id, ServiciosPublicos sp)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE serviciospublicos SET Agua=@Agua," +
                                                            "Telefono = @Telefono," +
                                                            "Drenaje = @Drenaje," +
                                                            "Calle = @Calle," +
                                                            "Electricidad = @Electricidad," +
                                                            "Acera = @Acera," +
                                                            "Alumbrado = @Alumbrado " +
                                                            "where idserviciospublicos = @idserviciospublicos";

                query.Prepare();
                query.Parameters.AddWithValue("@idserviciospublicos", id);
                query.Parameters.AddWithValue("@Agua", sp.Agua);
                query.Parameters.AddWithValue("@Telefono", sp.Telefono);
                query.Parameters.AddWithValue("@Drenaje", sp.Drenaje);
                query.Parameters.AddWithValue("@Calle", sp.Calle);
                query.Parameters.AddWithValue("@Electricidad", sp.Electricidad);
                query.Parameters.AddWithValue("@Acera", sp.Acera);
                query.Parameters.AddWithValue("@Alumbrado", sp.Alumbrado);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, sp);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage deletePiso(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from serviciospublicos where idserviciospublicos = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}