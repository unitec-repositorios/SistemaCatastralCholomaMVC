﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SistemaCatastralCholoma.Models;
using SistemaCatastralCholoma.Models.RequestModels;

namespace SistemaCatastralCholoma.Controllers
{
   
    public class DatosLegalesController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[datoslegales]";
        // GET: api/DatosLegales
        [HttpGet]
        public HttpResponseMessage listDatosLegales()
        {
            List<DatosLegales> datosLegales = new List<DatosLegales>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference}";

                SqlDataReader reader = query.ExecuteReader();
                DatosLegales datos;
                while (reader.Read())
                {                    

                    datos = new DatosLegales();
                    datos.idclaveCatastral = reader.GetString(0);
                    datos.propiedad = reader.GetString(1);
                    datos.tomo = reader.GetString(2);
                    datos.folio = reader.GetString(3);
                    datos.asiento = reader.GetString(4);
                    datos.inscripcion = reader.GetDateTime(5);
                    datos.matricula = reader.GetString(6);
                    datos.linea = reader.GetString(7);
                    datos.foto = reader.GetString(8);
                    datos.predio = reader.GetString(9);
                    datos.naturalezaJuridica = reader.GetString(10);
                    datos.tipoDocumento = reader.GetString(11);
                    datos.area = reader.GetDouble(12);
                    datos.unidadArea = reader.GetString(13);
                    datos.tipoMedida = reader.GetString(14);
                    datos.claseDominio = reader.GetString(15);

                    datosLegales.Add(datos);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, datosLegales);
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

        // GET: api/DatosLegales/5
        [HttpGet]
        public HttpResponseMessage getDatosLegales(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference} where idclaveCatastral = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                DatosLegales datos = new DatosLegales();
                while (reader.Read())
                {
                    datos = new DatosLegales();
                    datos.idclaveCatastral = reader.GetString(0);
                    datos.propiedad = reader.GetString(1);
                    datos.tomo = reader.GetString(2);
                    datos.folio = reader.GetString(3);
                    datos.asiento = reader.GetString(4);
                    datos.inscripcion = reader.GetDateTime(5);
                    datos.matricula = reader.GetString(6);
                    datos.linea = reader.GetString(7);
                    datos.foto = reader.GetString(8);
                    datos.predio = reader.GetString(9);
                    datos.naturalezaJuridica = reader.GetString(10);
                    datos.tipoDocumento = reader.GetString(11);
                    datos.area = reader.GetDouble(12);
                    datos.unidadArea = reader.GetString(13);
                    datos.tipoMedida = reader.GetString(14);
                    datos.claseDominio = reader.GetString(15);

                }
                conn.Close();
                if (datos.idclaveCatastral == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro avaluoUrbano con codigo " + id));

                var response = Request.CreateResponse(HttpStatusCode.OK, datos);
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

        // POST: api/DatosLegales
        [HttpPost]
        public HttpResponseMessage createDatosLegales(DatosLegales datos)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"INSERT INTO {DatabaseReference} VALUES (@idclaveCatastral," +
                                                                    "@propiedad," +
                                                                    "@tomo," +
                                                                    "@folio," +
                                                                    "@asiento," +
                                                                    "@inscripcion," +
                                                                    "@matricula," +
                                                                    "@linea," +
                                                                    "@foto," +
                                                                    "@predio," +
                                                                    "@naturalezaJuridica," +
                                                                    "@tipoDocumento," +
                                                                    "@area," +
                                                                    "@unidadArea," +
                                                                    "@tipoMedida,"+
                                                                    "@claseDominio);";

                query.Prepare();
                query.Parameters.AddWithValue("@idclaveCatastral", datos.idclaveCatastral);
                query.Parameters.AddWithValue("@propiedad", datos.propiedad);
                query.Parameters.AddWithValue("@tomo", datos.tomo);
                query.Parameters.AddWithValue("@folio", datos.folio);
                query.Parameters.AddWithValue("@asiento", datos.asiento);
                query.Parameters.AddWithValue("@inscripcion", datos.inscripcion);
                query.Parameters.AddWithValue("@matricula", datos.matricula);
                query.Parameters.AddWithValue("@linea", datos.linea);
                query.Parameters.AddWithValue("@foto", datos.foto);
                query.Parameters.AddWithValue("@predio", datos.predio);
                query.Parameters.AddWithValue("@naturalezaJuridica", datos.naturalezaJuridica);
                query.Parameters.AddWithValue("@tipoDocumento", datos.tipoDocumento);
                query.Parameters.AddWithValue("@area", datos.area);
                query.Parameters.AddWithValue("@unidadArea", datos.unidadArea);
                query.Parameters.AddWithValue("@tipoMedida", datos.tipoMedida);
                query.Parameters.AddWithValue("@claseDominio", datos.claseDominio);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datos);
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

        // PUT: api/DatosLegales/5
        [HttpPut]
        public HttpResponseMessage modifyDatosLegales(string id, DatosLegales datos)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"UPDATE {DatabaseReference} SET propiedad = @propiedad," +
                                                            "tomo = @tomo," +
                                                            "folio = @folio," +
                                                            "asiento = @asiento," +
                                                            "inscripcion = @inscripcion," +
                                                            "matricula = @matricula," +
                                                            "linea = @linea," +
                                                            "foto = @foto," +
                                                            "predio = @predio," +
                                                            "naturalezaJuridica = @naturalezaJuridica," +
                                                            "tipoDocumento = @tipoDocumento," +
                                                            "area = @area," +
                                                            "unidadArea = @unidadArea," +
                                                            "tipoMedida = @tipoMedida "+
                                                            "claseDominio = @claseDominio"+
                                                            "where idclaveCatastral = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@propiedad", datos.propiedad);
                query.Parameters.AddWithValue("@tomo", datos.tomo);
                query.Parameters.AddWithValue("@folio", datos.folio);
                query.Parameters.AddWithValue("@asiento", datos.asiento);
                query.Parameters.AddWithValue("@inscripcion", datos.inscripcion);
                query.Parameters.AddWithValue("@matricula", datos.matricula);
                query.Parameters.AddWithValue("@linea", datos.linea);
                query.Parameters.AddWithValue("@foto", datos.foto);
                query.Parameters.AddWithValue("@predio", datos.predio);
                query.Parameters.AddWithValue("@naturalezaJuridica", datos.naturalezaJuridica);
                query.Parameters.AddWithValue("@tipoDocumento", datos.tipoDocumento);
                query.Parameters.AddWithValue("@area", datos.area);
                query.Parameters.AddWithValue("@unidadArea", datos.unidadArea);
                query.Parameters.AddWithValue("@tipoMedida", datos.tipoMedida);
                query.Parameters.AddWithValue("@claseDominio", datos.claseDominio);
                query.ExecuteNonQuery();
                datos.idclaveCatastral = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datos);
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

        // DELETE: api/DatosLegales/5
        [HttpDelete]
        public HttpResponseMessage deleteDatosLegales(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"Delete from {DatabaseReference} where idclaveCatastral = @id";

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
