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
    public class AvaluoRuralController : ApiController
    {
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[avaluorural]";
        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/AvaluoRural
        [HttpGet]
        public HttpResponseMessage listAvaluosRurales()
        {
            List<AvaluoRural> avaluosRurales = new List<AvaluoRural>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference}";

                SqlDataReader reader = query.ExecuteReader();
                AvaluoRural avaluoRural;
                while (reader.Read())
                {
                    avaluoRural = new AvaluoRural();
                    avaluoRural.idavaluorural = reader.GetString(0);
                    avaluoRural.valorTerrenoRural = reader.GetDouble(1);

                    avaluosRurales.Add(avaluoRural);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluosRurales);
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

        // GET: api/AvaluoRural/5
        [HttpGet]
        public HttpResponseMessage getAvaluoRural(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference} where idavaluorural = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                AvaluoRural avaluo = new AvaluoRural();
                while (reader.Read())
                {
                    avaluo.idavaluorural = reader.GetString(0);
                    avaluo.valorTerrenoRural = reader.GetDouble(1);

                }
                conn.Close();
                if (avaluo.idavaluorural == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

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

        // POST: api/AvaluoRural
        [HttpPost]
        public HttpResponseMessage createAvaluoRural(AvaluoRural avaluoRural)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"INSERT INTO {DatabaseReference} VALUES (@idavaluorural," +
                                                               "@valorTerrenoRural)";

                query.Prepare();

                //Arreglar
                query.Parameters.AddWithValue("@idavaluorural", avaluoRural.idavaluorural);
                query.Parameters.AddWithValue("@valorTerrenoRural", avaluoRural.valorTerrenoRural);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoRural);
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

        // PUT: api/AvaluoRural/5
        [HttpPut]
        public HttpResponseMessage modifyAvaluoRural(string id, AvaluoRural avaluoRural)//put esta malo
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"UPDATE {DatabaseReference} SET valorTerrenoRural = @valorTerrenoRural," +
                                                      "where idavaluorural = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@valorTerrenoRural", avaluoRural.valorTerrenoRural);
                query.ExecuteNonQuery();
                avaluoRural.idavaluorural = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoRural);
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

        // DELETE: api/AvaluoRural/5
        [HttpDelete]
        public HttpResponseMessage deleteAvaluoRural(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"Delete from {DatabaseReference} where idavaluorural = @id";

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
