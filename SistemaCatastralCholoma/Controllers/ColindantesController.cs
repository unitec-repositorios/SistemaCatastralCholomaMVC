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
    public class ColindantesController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listcolindante()
        {
            List<Colindantes> colindantes = new List<Colindantes>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from colindantes";

                MySqlDataReader reader = query.ExecuteReader();
                Colindantes colindante;
                while (reader.Read())
                {
                    colindante = new Colindantes();
                    colindante.idcolindantes = (int)reader["idcolindantes"];
                    colindante.Norte = (string)reader["Norte"];
                    colindante.Sur = (string)reader["Sur"];
                    colindante.Este= (string)reader["Este"];
                    colindante.Oeste = (string)reader["Oeste"];
                    colindante.idDatosComplementarios = (string)reader["idDatosComplementarios"];

                    colindantes.Add(colindante);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getcolindante(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from colindantes where idcolindantes = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Colindantes colindantes = new Colindantes();
                while (reader.Read())
                {
                    colindantes.idcolindantes = (int)reader["idcolindantes"];
                    colindantes.Norte = (string)reader["Norte"];
                    colindantes.Sur = (string)reader["Sur"];
                    colindantes.Este = (string)reader["Este"];
                    colindantes.Oeste = (string)reader["Oeste"];
                    colindantes.idDatosComplementarios = (string)reader["idDatosComplementarios"];


                }
                conn.Close();
                if (colindantes.idcolindantes == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
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
        public HttpResponseMessage crearcolindante(Colindantes p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO colindantes VALUES (@idcolindantes,@Norte,@Sur,@Este,@Oeste,@idDatosComplementarios);";

                query.Prepare();
                query.Parameters.AddWithValue("@idcolindantes", p.idcolindantes);
                query.Parameters.AddWithValue("@Norte", p.Norte);
                query.Parameters.AddWithValue("@Sur", p.Sur);
                query.Parameters.AddWithValue("@Este", p.Este);
                query.Parameters.AddWithValue("@Oeste", p.Oeste);
                query.Parameters.AddWithValue("@idDatosComplementarios", p.idDatosComplementarios);
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
        public HttpResponseMessage modificarcolindante(int id, Colindantes p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE colindantes SET idcolindantes = @idcolindantes, Norte = @Norte,"
                                                    + "Sur = @Sur, Este = @Este, Oeste = @Oeste,"
                                                    + "idDatosComplementarios = @idDatosComplementarios " +
                                                      "where idcolindantes = @idcolindantes";

                p.idcolindantes = id;

                query.Prepare();
                query.Parameters.AddWithValue("@idcolindantes", p.idcolindantes);
                query.Parameters.AddWithValue("@Norte", p.Norte);
                query.Parameters.AddWithValue("@Sur", p.Sur);
                query.Parameters.AddWithValue("@Este", p.Este);
                query.Parameters.AddWithValue("@Oeste", p.Oeste);
                query.Parameters.AddWithValue("@idDatosComplementarios", p.idDatosComplementarios);
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
        public HttpResponseMessage eliminarcolindante(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from colindantes where idcolindantes = @idcolindantes";

                query.Prepare();
                query.Parameters.AddWithValue("@idcolindantes", id);
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

