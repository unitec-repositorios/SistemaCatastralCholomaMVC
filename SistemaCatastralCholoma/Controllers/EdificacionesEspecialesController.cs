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
    public class EdificacionesEspecialesController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();


        // GET: api/EdificacionesEspeciales
        [HttpGet]
        public HttpResponseMessage listEdificacionesEspeciales()
        {
            List<EdificacionesEspeciales> edificaciones = new List<EdificacionesEspeciales>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.edificacionesespeciales";

                SqlDataReader reader = query.ExecuteReader();
                EdificacionesEspeciales edificacion;
                while (reader.Read())
                {
                    edificacion = new EdificacionesEspeciales();
                    edificacion.idedificacionesespeciales = reader.GetInt32(0);
                    edificacion.Nivel = reader.GetString(1);
                    edificacion.Area = reader.GetDouble(2);
                    edificacion.Area = reader.GetDouble(3);
                    edificacion.idDatosComplementarios = reader.GetInt32(4);

                    edificaciones.Add(edificacion);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, edificaciones);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/EdificacionesEspeciales/5
        [HttpGet]
        public HttpResponseMessage getEdificacionesEspeciales(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.edificacionesespeciales where idedificacionesespeciales = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                EdificacionesEspeciales edificacion = new EdificacionesEspeciales();
                while (reader.Read())
                {
                    edificacion.idedificacionesespeciales = reader.GetInt32(0);
                    edificacion.Nivel = reader.GetString(1);
                    edificacion.Area = reader.GetDouble(2);
                    edificacion.Area = reader.GetDouble(3);
                    edificacion.idDatosComplementarios = reader.GetInt32(4);

                }

                if (edificacion == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo " + id));

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, edificacion);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/EdificacionesEspeciales
        [HttpPost]
        public HttpResponseMessage createEdificacionesEspeciales(EdificacionesEspeciales edificaciones)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.edificacionesespeciales VALUES (@id," +
                                                               "@nivel," +
                                                               "@area," +
                                                               "@costo," +
                                                               "@idDatos);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", edificaciones.idedificacionesespeciales);
                query.Parameters.AddWithValue("@nivel", edificaciones.Nivel);
                query.Parameters.AddWithValue("@area", edificaciones.Area);
                query.Parameters.AddWithValue("@costo", edificaciones.Costo);
                query.Parameters.AddWithValue("@idDatos", edificaciones.idDatosComplementarios);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, edificaciones);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/EdificacionesEspeciales/5
        [HttpPut]
        public HttpResponseMessage modifyEdificacionesEspeciales(string id, EdificacionesEspeciales edificaciones)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.edificacionesespeciales SET Nivel = @nivel," +
                                                             "Area = @area," +
                                                             "Costo = @costo," +
                                                             "idDatosComplementarios = @idDatos "+
                                                             "where idedificacionesespeciales = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@Nivel", edificaciones.Nivel);
                query.Parameters.AddWithValue("@Area", edificaciones.Area);
                query.Parameters.AddWithValue("@Costo", edificaciones.Costo);
                query.Parameters.AddWithValue("@idDatosComplementarios", edificaciones.idDatosComplementarios);
                query.ExecuteNonQuery();
                edificaciones.idedificacionesespeciales = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, edificaciones);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // DELETE: api/EdificacionesEspeciales/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.edificacionesespeciales where idedificacionesespeciales = @id";

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
