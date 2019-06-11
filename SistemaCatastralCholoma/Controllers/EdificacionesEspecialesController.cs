using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{
    public class EdificacionesEspecialesController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();


        // GET: api/EdificacionesEspeciales
        [HttpGet]
        public HttpResponseMessage listEdificacionesEspeciales()
        {
            List<EdificacionesEspeciales> edificaciones = new List<EdificacionesEspeciales>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from edificacionesespeciales";

                MySqlDataReader reader = query.ExecuteReader();
                EdificacionesEspeciales edificacion;
                while (reader.Read())
                {
                    edificacion = new EdificacionesEspeciales();
                    edificacion.idedificacionesespeciales = (int)reader["idedificacionesespeciales"];
                    edificacion.Nivel = (string)reader["Nivel"];
                    edificacion.Area = (Double)reader["Area"];
                    edificacion.Area = (Double)reader["Costo"];
                    edificacion.idDatosComplementarios = (int)reader["idDatosComplementarios"];

                    edificaciones.Add(edificacion);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, edificaciones);
                return response;

            }
            catch (MySqlException e)
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from edificacionesespeciales where idDatosComplementarios = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                EdificacionesEspeciales edificacion = new EdificacionesEspeciales();
                while (reader.Read())
                {
                    edificacion.idedificacionesespeciales = (int)reader["idEdificacionesEspeciales"];
                    edificacion.Nivel = (string)reader["Nivel"];
                    edificacion.Area = (Double)reader["Area"];
                    edificacion.Area = (Double)reader["Costo"];
                    edificacion.idDatosComplementarios = (int)reader["idDatosComplementarios"];

                }

                if (edificacion == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo " + id));

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, edificacion);
                return response;

            }
            catch (MySqlException e)
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO edificacionesespeciales VALUES (@id," +
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/EdificacionesEspeciales/5
        [HttpPut]
        public HttpResponseMessage modifyEdificacionesEspeciales(int id, EdificacionesEspeciales edificaciones)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE edificacionesespeciales SET Nivel = @nivel," +
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // DELETE: api/EdificacionesEspeciales/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from edificacionesespeciales where idedificacionesespeciales = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}
