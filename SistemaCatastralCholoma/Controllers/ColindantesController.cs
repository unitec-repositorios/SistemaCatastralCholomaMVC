using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using System.Data.SqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class ColindantesController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listcolindante()
        {
            List<Colindantes> colindantes = new List<Colindantes>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.colindantes";

                SqlDataReader reader = query.ExecuteReader();
                Colindantes colindante;
                while (reader.Read())
                {
                    colindante = new Colindantes();
<<<<<<< HEAD
                    colindante.idcolindantes = reader.GetInt32(0);
                    colindante.Norte = reader.GetString(1);
                    colindante.Sur = reader.GetString(2);
                    colindante.Este= reader.GetString(3);
                    colindante.Oeste = reader.GetString(4);
                    colindante.idDatosComplementarios = reader.GetString(5);
=======
                    colindante.idcolindantes = (int)reader["idcolindantes"];
                    colindante.Norte = (string)reader["Norte"];
                    colindante.Sur = (string)reader["Sur"];
                    colindante.Este= (string)reader["Este"];
                    colindante.Oeste = (string)reader["Oeste"];
                    colindante.idDatosComplementarios = (string)reader["idDatosComplementarios"];
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

                    colindantes.Add(colindante);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
                return response;

            }
            catch (SqlException e)
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
                SqlCommand query = conn.CreateCommand();

<<<<<<< HEAD
                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.colindantes where id = '" + id + "'";
=======
                query.CommandText = "Select * from colindantes where idcolindantes = '" + id + "'";
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

                SqlDataReader reader = query.ExecuteReader();


                Colindantes colindantes = new Colindantes();
                while (reader.Read())
                {
<<<<<<< HEAD
                    colindantes.idcolindantes = reader.GetInt32(0);
                    colindantes.Norte = reader.GetString(1);
                    colindantes.Sur = reader.GetString(2);
                    colindantes.Este = reader.GetString(3);
                    colindantes.Oeste = reader.GetString(4);
                    colindantes.idDatosComplementarios = reader.GetString(5);
=======
                    colindantes.idcolindantes = (int)reader["idcolindantes"];
                    colindantes.Norte = (string)reader["Norte"];
                    colindantes.Sur = (string)reader["Sur"];
                    colindantes.Este = (string)reader["Este"];
                    colindantes.Oeste = (string)reader["Oeste"];
                    colindantes.idDatosComplementarios = (string)reader["idDatosComplementarios"];
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f


                }
                conn.Close();
                if (colindantes.idcolindantes == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
                return response;

            }
            catch (SqlException e)
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

                SqlCommand query = conn.CreateCommand();

<<<<<<< HEAD
                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.colindantes VALUES (@idcolindante,@Norte,@Sur,@Este,@Oeste,@idDatosComplementarios);";
=======
                query.CommandText = "INSERT INTO colindantes VALUES (@idcolindantes,@Norte,@Sur,@Este,@Oeste,@idDatosComplementarios);";
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

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
            catch (SqlException e)
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

                SqlCommand query = conn.CreateCommand();

<<<<<<< HEAD
                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.caracteristicaspropiedad SET id = @id, Norte = @Norte,"
=======
                query.CommandText = "UPDATE colindantes SET idcolindantes = @idcolindantes, Norte = @Norte,"
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f
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
            catch (SqlException e)
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
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.colindante where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@idcolindantes", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}


