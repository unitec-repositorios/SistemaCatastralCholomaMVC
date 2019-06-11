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
    public class FraccionController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/
        [HttpGet]
        public HttpResponseMessage listFraccion()
        {
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from fraccion", conn);
                reader = cmd.ExecuteReader();
                List<Fraccion> f = new List<Fraccion>();
                while (reader.Read())
                {
                    f.Add(new Fraccion((int)reader["idfraccion"], (double)reader["Valor"], (double)reader["Area"],
                        (double)reader["parecelaTipica"], (double)reader["factorModificado"], (double)reader["Frente"],
                        (int)reader["idAvaluoUrbano"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, f);
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
        public HttpResponseMessage getFraccion(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from fraccion where idfraccion = " + id;

                MySqlDataReader reader = query.ExecuteReader();


                Fraccion f = new Fraccion();
                while (reader.Read())
                {
                    f = new Fraccion((int)reader["idfraccion"], (double)reader["Valor"], (double)reader["Area"],
                        (double)reader["parecelaTipica"], (double)reader["factorModificado"], (double)reader["Frente"], (int)reader["idAvaluoUrbano"]);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, f);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage createFraccion(Fraccion f)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO fraccion VALUES (@idfraccion,@Valor,@Area,@parecelaTipica,@factorModificado,@Frente,@idAvaluoUrbano);";

                query.Prepare();
                query.Parameters.AddWithValue("@idfraccion", f.idfraccion );
                query.Parameters.AddWithValue("@Valor", f.Valor);
                query.Parameters.AddWithValue("@Area", f.Area);
                query.Parameters.AddWithValue("@parecelaTipica", f.parecelaTipica);
                query.Parameters.AddWithValue("@factorModificado", f.factorModificado);
                query.Parameters.AddWithValue("@Frente", f.Frente);
                query.Parameters.AddWithValue("@idAvaluoUrbano", f.idAvaluoUrbano);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, f);
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
        public HttpResponseMessage modifyFraccion(int id,Fraccion f)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE fraccion SET Valor=@Valor," +
                                                            "Area = @Area," +
                                                            "parecelaTipica = @parecelaTipica," +
                                                            "factorModificado = @factorModificado," +
                                                            "Frente = @Frente," +
                                                            "idAvaluoUrbano = @idAvaluoUrbano " +
                                                            "where idfraccion = @idfraccion";

                query.Prepare();
                query.Parameters.AddWithValue("@idfraccion", id);
                query.Parameters.AddWithValue("@Valor", f.Valor);
                query.Parameters.AddWithValue("@Area", f.Area);
                query.Parameters.AddWithValue("@parecelaTipica", f.parecelaTipica);
                query.Parameters.AddWithValue("@factorModificado", f.factorModificado);
                query.Parameters.AddWithValue("@Frente", f.Frente);
                query.Parameters.AddWithValue("@idAvaluoUrbano", f.idAvaluoUrbano);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, f);
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
        public HttpResponseMessage deleteFraccion(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from fraccion where idfraccion = @id";

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