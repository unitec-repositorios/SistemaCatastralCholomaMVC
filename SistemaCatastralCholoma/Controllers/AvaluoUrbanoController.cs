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
    public class AvaluoUrbanoController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();

        // GET: api/AvaluoUrbano
        [HttpGet]
        public HttpResponseMessage listAvaluosUrbanos()
        {
            List<AvaluoUrbano> avaluosUrbanos = new List<AvaluoUrbano>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.avaluourbano";

                SqlDataReader reader = query.ExecuteReader();
                AvaluoUrbano avaluo;
                while (reader.Read())
                {
                    avaluo = new AvaluoUrbano();
                    avaluo.idavaluourbano = reader.GetString(0);
                    avaluo.Esquina = reader.GetDouble(1);
                    avaluo.Topografia = reader.GetDouble(2);

                    avaluosUrbanos.Add(avaluo);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluosUrbanos);
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

        // GET: api/AvaluoUrbano/5
        [HttpGet]
        public HttpResponseMessage getAvaluoUrbano(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.avaluourbano where idavaluourbano = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                AvaluoUrbano avaluo = new AvaluoUrbano();
                while (reader.Read())
                {
                    avaluo.idavaluourbano = reader.GetString(0);
                    avaluo.Esquina = reader.GetDouble(1);
                    avaluo.Topografia = reader.GetDouble(2);

                }

                if (avaluo.idavaluourbano == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo "+id));

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
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

        // POST: api/AvaluoUrbano
        [HttpPost]
        public HttpResponseMessage createAvaluoUrbano(AvaluoUrbano avaluo)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.avaluourbano VALUES (@id," +
                                                               "@esquina," +
                                                               "@topografia);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", avaluo.idavaluourbano);
                query.Parameters.AddWithValue("@esquina", avaluo.Esquina);
                query.Parameters.AddWithValue("@topografia", avaluo.Topografia);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
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

        // PUT: api/AvaluoUrbano/5
        [HttpPut]
        public HttpResponseMessage modifyAvaluoUrbano(string id, AvaluoUrbano avaluo)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.avaluourbano SET Esquina = @esquina," +
                                                      "Topografia = @topografia " +
                                                      "where idavaluourbano = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@esquina", avaluo.Esquina);
                query.Parameters.AddWithValue("@topografia", avaluo.Topografia);
                query.ExecuteNonQuery();
                avaluo.idavaluourbano = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
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

        // DELETE: api/AvaluoUrbano/5
        [HttpDelete]
        public HttpResponseMessage deleteAvaluoUrbano(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.avaluourbano where idavaluourbano = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
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
