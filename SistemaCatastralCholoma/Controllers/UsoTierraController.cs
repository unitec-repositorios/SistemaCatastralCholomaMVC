using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{
    public class UsoTierraController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[usotierra]";
        [HttpGet]
        public HttpResponseMessage listUsoTierra()
        {
            List<UsoTierra> usoTierra = new List<UsoTierra>();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = $"select * from {DatabaseReference}";
                SqlDataReader reader = cmd.ExecuteReader();
                UsoTierra ut;
                while (reader.Read())
                {
                    /*ut = new UsoTierra();
                    ut.idusotierra = Convert.ToInt32(reader["idusotierra"]);
                    ut.uso = (string)reader["uso"];
                    ut.codigo = (string)reader["codigo"];
                    ut.idCaracRural = Convert.ToInt32(reader["idCaracRural"]);*/

                    ut = new UsoTierra();
                    ut.idusotierra = reader.GetInt32(0);
                    ut.uso = reader.GetString(1);
                    ut.codigo = reader.GetString(2);
                    ut.idCaracRural = reader.GetInt32(3);

                    usoTierra.Add(ut);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, usoTierra);
                return response;
            }
            catch(SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getUsoTierra(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"select * from {DatabaseReference} where idusotierra = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();
                UsoTierra ut = null;
                while (reader.Read())
                {
                    /*ut = new UsoTierra();
                     ut.idusotierra = Convert.ToInt32(reader["idusotierra"]);
                     ut.uso = (string)reader["uso"];
                     ut.codigo = (string)reader["codigo"];
                     ut.idCaracRural = Convert.ToInt32(reader["idCaracRural"]);*/

                    ut = new UsoTierra();
                    ut.idusotierra = reader.GetInt32(0);
                    ut.uso = reader.GetString(1);
                    ut.codigo = reader.GetString(2);
                    ut.idCaracRural = reader.GetInt32(3);

                }
                conn.Close();
                if (ut == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, ut);
                return response;
            }
            catch(SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/UsoTierra
        [HttpPost]
        public HttpResponseMessage createUsoTierra(UsoTierra usoTierra)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"INSERT INTO {DatabaseReference} VALUES (@idusotierra," +
                                                               "@uso," +
                                                               "@codigo," +
                                                               "idCaracRural);";

                query.Prepare();
                query.Parameters.AddWithValue("@idusotierra", usoTierra.idusotierra);
                query.Parameters.AddWithValue("@uso", usoTierra.uso);
                query.Parameters.AddWithValue("@codigo", usoTierra.codigo);
                query.Parameters.AddWithValue("@idCaracRural", usoTierra.idCaracRural);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, usoTierra);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage modifyUsoTierra(int id, UsoTierra usoTierra)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"UPDATE {DatabaseReference} SET uso = @uso," +
                                                      "codigo = @codigo," +
                                                      "idCaracRural = @idCaracRural " +
                                                      "where idusotierra = @idusotierra";

                query.Prepare();
                query.Parameters.AddWithValue("@idusotierra", id);
                query.Parameters.AddWithValue("@uso", usoTierra.uso);
                query.Parameters.AddWithValue("@codigo", usoTierra.codigo);
                query.Parameters.AddWithValue("@idCaracRural", usoTierra.idCaracRural);
                query.ExecuteNonQuery();
                usoTierra.idusotierra = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, usoTierra);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteUsoTierra(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"delete from {DatabaseReference} where idusotierra = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}
