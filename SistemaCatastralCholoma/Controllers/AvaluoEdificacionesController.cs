using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{

    public class AvaluoEdificacionesController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/AvaluoEdificaciones
        [HttpGet]
        public HttpResponseMessage listAvaluoEdificaciones()
        {
            List<AvaluoEdificaciones> avaluoEdificaciones = new List<AvaluoEdificaciones>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.avaluoedificaciones";

                SqlDataReader reader = query.ExecuteReader();
                AvaluoEdificaciones avaluoEdificacion;
                while (reader.Read())
                {
                    avaluoEdificacion = new AvaluoEdificaciones();
                    avaluoEdificacion.idavaluoedificaciones = reader.GetString(0);
                    avaluoEdificacion.totalEdificaciones = reader.GetDouble(1);
                    avaluoEdificacion.edificaciones = reader.GetDouble(2);

                    avaluoEdificaciones.Add(avaluoEdificacion);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoEdificaciones);
                return response;

            }
            catch (SqlException e)
            {
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/AvaluoEdificaciones/5
        [HttpGet]
        public HttpResponseMessage getAvaluoEdificaciones(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.avaluoedificaciones where idavaluoedificaciones = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                AvaluoEdificaciones avaluo = new AvaluoEdificaciones();
                while (reader.Read())
                {
                    avaluo.idavaluoedificaciones = reader.GetString(0);
                    avaluo.totalEdificaciones = reader.GetDouble(1);
                    avaluo.edificaciones = reader.GetDouble(2);

                }


                conn.Close();
                if (avaluo.idavaluoedificaciones == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo " + id));

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/AvaluoEdificaciones
        [HttpPost]
        public HttpResponseMessage createAvaluoEdificaciones(AvaluoEdificaciones avaluoEdificaciones)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.avaluoedificaciones VALUES (@idavaluoedificaciones," +
                                                               "@totalEdificaciones," +
                                                               "@edificaciones);";

                query.Prepare();
                query.Parameters.AddWithValue("@idavaluoedificaciones", avaluoEdificaciones.idavaluoedificaciones);
                query.Parameters.AddWithValue("@totalEdificaciones", avaluoEdificaciones.totalEdificaciones);
                query.Parameters.AddWithValue("@edificaciones", avaluoEdificaciones.edificaciones);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoEdificaciones);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/AvaluoEdificaciones/5
        [HttpPut]
        public HttpResponseMessage modifyAvaluoEdificaciones(string id, AvaluoEdificaciones avaluo)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.avaluoedificaciones SET totalEdificaciones = @totalEdificaciones," +
                                                      "edificaciones = @edificaciones " +
                                                      "where idavaluoedificaciones = @idavaluoedificaciones";

                query.Prepare();
                query.Parameters.AddWithValue("@idavaluoedificaciones", id);
                query.Parameters.AddWithValue("@totalEdificaciones", avaluo.totalEdificaciones);
                query.Parameters.AddWithValue("@edificaciones", avaluo.edificaciones);
                query.ExecuteNonQuery();
                avaluo.idavaluoedificaciones = id;
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
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        // DELETE: api/AvaluoEdificaciones/5
        [HttpDelete]
        public HttpResponseMessage deleteAvaluoEdificaciones(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.avaluoedificaciones where idavaluoedificaciones = @id";

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
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }
    }
}
