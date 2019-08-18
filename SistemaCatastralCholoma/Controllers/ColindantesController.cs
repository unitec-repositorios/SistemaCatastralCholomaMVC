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

                query.CommandText = "Select * from colindantes";

                SqlDataReader reader = query.ExecuteReader();
                Colindantes colindante;
                while (reader.Read())
                {
                    colindante = new Colindantes();
                    colindante.idcolindantes = (int)reader["id"];
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

                query.CommandText = "Select * from colindantes where id = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                Colindantes colindantes = new Colindantes();
                while (reader.Read())
                {
                    colindantes.idcolindantes = (int)reader["id"];
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

                query.CommandText = "INSERT INTO colindantes VALUES (@idcolindante,@Norte,@Sur,@Este,@Oeste,@idDatosComplementarios);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", p.idcolindantes);
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

                query.CommandText = "UPDATE caracteristicaspropiedad SET id = @id, Norte = @Norte,"
                                                    + "Sur = @Sur, Este = @Este, Oeste = @Oeste,"
                                                    + "idDatosComplementarios = @idDatosComplementarios";

                p.idcolindantes = id;

                query.Prepare();
                query.Parameters.AddWithValue("@id", p.idcolindantes);
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
                query.CommandText = "Delete from colindante where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
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