﻿using MySql.Data.MySqlClient;
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

        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/AvaluoEdificaciones
        [HttpGet]
        public HttpResponseMessage listAvaluoEdificaciones()
        {
            List<AvaluoEdificaciones> avaluoEdificaciones = new List<AvaluoEdificaciones>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from avaluoedificaciones";

                MySqlDataReader reader = query.ExecuteReader();
                AvaluoEdificaciones avaluoEdificacion;
                while (reader.Read())
                {
                    avaluoEdificacion = new AvaluoEdificaciones();
                    avaluoEdificacion.idavaluoedificaciones = (string)reader["idavaluoedificaciones"];
                    avaluoEdificacion.totalEdificaciones = (Double)reader["totalEdificaciones"];
                    avaluoEdificacion.edificaciones = (Double)reader["edificaciones"];

                    avaluoEdificaciones.Add(avaluoEdificacion);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoEdificaciones);
                return response;

            }
            catch (MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from avaluoedificaciones where idavaluoedificaciones = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                AvaluoEdificaciones avaluo = new AvaluoEdificaciones();
                while (reader.Read())
                {
                    avaluo.idavaluoedificaciones = (string)reader["idavaluoedificaciones"];
                    avaluo.totalEdificaciones = (Double)reader["totalEdificaciones"];
                    avaluo.edificaciones = (Double)reader["edificaciones"];

                }
                conn.Close();
                if (avaluo.idavaluoedificaciones == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
                return response;

            }
            catch (MySqlException e)
            {
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO avaluoedificaciones VALUES (@idavaluoedificaciones," +
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE avaluoedificaciones SET totalEdificaciones = @totalEdificaciones," +
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from avaluoedificaciones where idavaluoedificaciones = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }
    }
}