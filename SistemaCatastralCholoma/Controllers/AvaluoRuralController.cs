﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class AvaluoRuralController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/AvaluoRural
        [HttpGet]
        public HttpResponseMessage listAvaluosRurales()
        {
            List<AvaluoRural> avaluosRurales = new List<AvaluoRural>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from avaluorural";

                MySqlDataReader reader = query.ExecuteReader();
                AvaluoRural avaluoRural;
                while (reader.Read())
                {
                    avaluoRural = new AvaluoRural();
                    avaluoRural.idavaluorural = (string)reader["idavaluorural"];
                    avaluoRural.valorTerrenoRural = (Double)reader["valorTerrenoRural"];

                    avaluosRurales.Add(avaluoRural);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, avaluosRurales);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from avaluorural where idavaluorural = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                AvaluoRural avaluo = new AvaluoRural();
                while (reader.Read())
                {
                    avaluo.idavaluorural = (string)reader["idavaluorural"];
                    avaluo.valorTerrenoRural = (Double)reader["valorTerrenoRural"];

                }
                conn.Close();
                if (avaluo.idavaluorural == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo " + id));

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluo);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO avaluorural VALUES (@idavaluorural," +
                                                               "@valorTerrenoRural";

                query.Prepare();
                query.Parameters.AddWithValue("@idavaluoedificaciones", avaluoRural.idavaluorural);
                query.Parameters.AddWithValue("@valorTerrenoRural", avaluoRural.valorTerrenoRural);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoRural);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/AvaluoRural/5
        [HttpPut]
        public HttpResponseMessage modifyAvaluoRural(string id, AvaluoRural avaluoRural)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE avaluorural SET valorTerrenoRural = @valorTerrenoRural," +
                                                      "where idavaluorural = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@edificaciones", avaluoRural.valorTerrenoRural);
                query.ExecuteNonQuery();
                avaluoRural.idavaluorural = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, avaluoRural);
                return response;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
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
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from avaluorural where idavaluorural = @id";

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
