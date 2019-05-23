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
    public class PredioController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listPredios()
        {
            List<Predio> predios = new List<Predio>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predio";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    predios.Add(new Predio((string)reader["idpropietario"], (string)reader["barrio"], (string)reader["caserio"], (string)reader["uso"], (string)reader["subUso"], (string)reader["sitio"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, predios);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getPredio(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predio where idpropietario = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Predio predio = new Predio();
                while (reader.Read())
                {
                    predio = new Predio((string)reader["idpropietario"], (string)reader["barrio"], (string)reader["caserio"], (string)reader["uso"], (string)reader["subUso"], (string)reader["sitio"]);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, predio);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage crearPredio(Predio p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO predio VALUES (@idpropietario,@barrio,@caserio,@uso,@subUso,@sitio);";

                query.Prepare();
                query.Parameters.AddWithValue("@idpropietario", p.idpropietario);
                query.Parameters.AddWithValue("@barrio", p.barrio);
                query.Parameters.AddWithValue("@caserio", p.caserio);
                query.Parameters.AddWithValue("@uso",p.uso);
                query.Parameters.AddWithValue("@subUso", p.subUso);
                query.Parameters.AddWithValue("@sitio", p.sitio);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, p);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modificarPredio(string id, Predio p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE predio SET barrio = @barrio, caserio = @caserio, uso = @uso, subUso = @subUso, sitio = @sitio where idpropietario = @idpropietario";

                p.idpropietario = id;

                query.Prepare();
                query.Parameters.AddWithValue("@idpropietario", p.idpropietario);
                query.Parameters.AddWithValue("@barrio", p.barrio);
                query.Parameters.AddWithValue("@caserio", p.caserio);
                query.Parameters.AddWithValue("@uso", p.uso);
                query.Parameters.AddWithValue("@subUso", p.subUso);
                query.Parameters.AddWithValue("@sitio", p.sitio);
                query.ExecuteNonQuery();

                conn.Close();
         
                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage eliminarPredio(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from predio where idpropietario = @idpropietario";

                query.Prepare();
                query.Parameters.AddWithValue("@idpropietario", id);
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