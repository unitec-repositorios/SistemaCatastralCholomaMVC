using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaCatastralCholoma.Controllers
{
    public class ClasificacionSueloController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<ClasificacionSuelo>
        [HttpGet]
        public HttpResponseMessage listClasificacionSuelo()
        {
            List<ClasificacionSuelo> clasificacionSuelo = new List<ClasificacionSuelo>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from clasificacionsuelo";

                MySqlDataReader reader = query.ExecuteReader();
                ClasificacionSuelo clasificacionS;
                while (reader.Read())
                {
                    clasificacionS = new ClasificacionSuelo();
                    clasificacionS.idclasificacionsuelo = (string)reader["idclasificacionsuelo"];
                    clasificacionS.fRiego = (Double)reader["fRiego"];
                    clasificacionS.codigo = (int)reader["codigo"];
                    clasificacionS.area = (Double)reader["area"];
                    clasificacionS.idClaveCatastral = (string)reader["idClaveCatastral"];

                    clasificacionSuelo.Add(clasificacionS);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, clasificacionSuelo);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/ClasificacionSuelo/5
        [HttpGet]
        public HttpResponseMessage getClasificacionSuelo(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from clasificacionsuelo where idclasificacionsuelo = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                ClasificacionSuelo clasif = new ClasificacionSuelo();
                while (reader.Read())
                {
                    clasificacionS.fRiego = (Double)reader["fRiego"];
                    clasificacionS.codigo = (int)reader["codigo"];
                    clasificacionS.area = (Double)reader["area"];
                    clasificacionS.idClaveCatastral = (string)reader["idClaveCatastral"];

                }
                conn.Close();
                if (clasif.idclasificacionsuelo == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, clasif);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/ClasificacionSuelo
        [HttpPost]
        public HttpResponseMessage createClasificacionSuelo(ClasificacionSuelo clasif)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO clasificacionsuelo VALUES (@idclasificacionsuelo," +
                                                               "@fRiego," +
                                                               "@codigo," +
                                                               "@area," +
                                                               "@idClaveCatastral);";

                query.Prepare();
                query.Parameters.AddWithValue("@idclasificacionsuelo", clasif.idclasificacionsuelo);
                query.Parameters.AddWithValue("@fRiego", clasif.fRiego);
                query.Parameters.AddWithValue("@codigo", clasif.codigo);
                query.Parameters.AddWithValue("@area", clasif.area);
                query.Parameters.AddWithValue("@idClaveCatastral", clasif.idClaveCatastral);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, clasif);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/ClasificacionSuelo/5
        [HttpPut]
        public HttpResponseMessage modifyClasificacionSuelo(string id, ClasificacionSuelo clasif)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE clasificacionsuelo SET fRiego = @fRiego," +
                                                      "codigo = @codigo " +
                                                      "area = @area " +
                                                      "idClaveCatastral = @idClaveCatastral " +
                                                      "where idclasificacionsuelo = @idclasificacionsuelo";

                query.Prepare();
                query.Parameters.AddWithValue("@idclasificacionsuelo", id);
                query.Parameters.AddWithValue("@fRiego", clasif.fRiego);
                query.Parameters.AddWithValue("@area", clasif.area);
                query.Parameters.AddWithValue("@idClaveCatastral", clasif.idClaveCatastral);
                query.ExecuteNonQuery();
                avaluo.idavaluoedificaciones = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, clasif);
                return response;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // DELETE: api/ClasificacionSuelo/5
        [HttpDelete]
        public HttpResponseMessage deleteClasificacionSuelo(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from clasificacionsuelo where idclasificacionsuelo = @id";

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