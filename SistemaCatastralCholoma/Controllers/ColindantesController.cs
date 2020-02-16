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
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[colindantes]";
        String DataDiferentTableRef = WebApiConfig.DatabaseName();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listcolindante()
        {
            List<Colindantes> colindantes = new List<Colindantes>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference}";

                SqlDataReader reader = query.ExecuteReader();
                Colindantes colindante;
                while (reader.Read())
                {
                    colindante = new Colindantes();
                    colindante.idcolindantes = reader.GetInt32(0);
                    colindante.Norte = reader.GetString(1);
                    colindante.Sur = reader.GetString(2);
                    colindante.Este = reader.GetString(3);
                    colindante.Oeste = reader.GetString(4);
                    colindante.idDatosComplementarios = reader.GetString(5);

                    colindantes.Add(colindante);
                }

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
                return response;


            }
            catch(SqlException e){
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.OK, e.Message.ToString());
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

                query.CommandText = $"Select * from {DatabaseReference} where id = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                Colindantes colindantes = new Colindantes();
                while (reader.Read())
                {
                    colindantes.idcolindantes = reader.GetInt32(0);
                    colindantes.Norte = reader.GetString(1);
                    colindantes.Sur = reader.GetString(2);
                    colindantes.Este = reader.GetString(3);
                    colindantes.Oeste = reader.GetString(4);
                    colindantes.idDatosComplementarios = reader.GetString(5);


                }
                conn.Close();
                if (colindantes.idcolindantes == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, colindantes);
                return response;

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

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage crearcolindante(Colindantes p)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"INSERT INTO {DatabaseReference} VALUES (@idcolindante,@Norte,@Sur,@Este,@Oeste,@idDatosComplementarios);";

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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, e.Message.ToString());
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

                query.CommandText = $"UPDATE {DataDiferentTableRef}.[caracteristicaspropiedad] SET id = @id, Norte = @Norte,"
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
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
                query.CommandText = $"Delete from {DataDiferentTableRef}.[colindante] where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@idcolindantes", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

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


