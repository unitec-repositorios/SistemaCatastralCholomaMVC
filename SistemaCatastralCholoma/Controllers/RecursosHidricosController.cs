﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{
    public class RecursosHidricosController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        [HttpGet]
        public HttpResponseMessage listRecursosHidricos()
        {
            List<RecursosHidricos> recursosHidricos = new List<RecursosHidricos>();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from usotierra";
                SqlDataReader reader = cmd.ExecuteReader();
                RecursosHidricos rh;
                while (reader.Read())
                {
                    rh = new RecursosHidricos();
                    rh.idrecursoshidricos = Convert.ToInt32(reader["idrecursoshidricos"]);
                    rh.fuente = (string)reader["fuente"];
                    rh.riego = (string)reader["codigo"];
                    rh.sistemaIrrigacion = (string)reader["sistemaIrrigacion"];
                    rh.distancia = (double)reader["distancia"];
                    rh.area = (double)reader["area"];
                    rh.idCaracRural = Convert.ToInt32(reader["idCaracRural"]);
                    recursosHidricos.Add(rh);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, recursosHidricos);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getRecursoHidrico(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "select * from recursoshidricos where idrecursoshidricos = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();
                RecursosHidricos rh = null;
                while (reader.Read())
                {
                    rh = new RecursosHidricos();
                    rh.idrecursoshidricos = Convert.ToInt32(reader["idrecursoshidricos"]);
                    rh.fuente = (string)reader["fuente"];
                    rh.riego = (string)reader["riego"];
                    rh.sistemaIrrigacion = (string)reader["sistemaIrrigacion"];
                    rh.distancia = (double)reader["distancia"];
                    rh.area = (double)reader["area"];
                    rh.idCaracRural = Convert.ToInt32(reader["idCaracRural"]);

                }
                conn.Close();
                if (rh == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, rh);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/UsoTierra
        [HttpPost]
        public HttpResponseMessage createRecursoHidrico(RecursosHidricos rh)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO recursoshidricos VALUES (@idrecursoshidricos," +
                                                               "@fuente," +
                                                               "@riego," +
                                                               "@sistemaIrrigacion," +
                                                               "@distancia," +
                                                               "@area," +
                                                               "idCaracRural);";

                query.Prepare();
                query.Parameters.AddWithValue("@idrecursoshidricos", rh.idrecursoshidricos);
                query.Parameters.AddWithValue("@fuente", rh.fuente);
                query.Parameters.AddWithValue("@riego", rh.riego);
                query.Parameters.AddWithValue("@sistemaIrrigacion", rh.sistemaIrrigacion);
                query.Parameters.AddWithValue("@distancia", rh.distancia);
                query.Parameters.AddWithValue("@area", rh.area);
                query.Parameters.AddWithValue("@idCaracRural", rh.idCaracRural);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, rh);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage modifyRecursoHidrico(int id, RecursosHidricos rh)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE recursoshidricos SET fuente = @fuente," +
                                                      "riego = @riego," +
                                                      "sistemaIrrigacion = @sistemaIrrigacion," +
                                                      "distancia = @distancia," +
                                                      "area = @area," +
                                                      "idCaracRural = @idCaracRural " +
                                                      "where idrecursoshidricos = @idrecursoshidricos";

                query.Prepare();
                query.Parameters.AddWithValue("@idrecursoshidricos", rh.idrecursoshidricos);
                query.Parameters.AddWithValue("@fuente", rh.fuente);
                query.Parameters.AddWithValue("@riego", rh.riego);
                query.Parameters.AddWithValue("@sistemaIrrigacion", rh.sistemaIrrigacion);
                query.Parameters.AddWithValue("@distancia", rh.distancia);
                query.Parameters.AddWithValue("@area", rh.area);
                query.Parameters.AddWithValue("@idCaracRural", rh.idCaracRural);
                query.ExecuteNonQuery();
                rh.idrecursoshidricos = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, rh);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteRecursoHidrico(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "delete from recursoshidricos where idusotierra = @id";

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
