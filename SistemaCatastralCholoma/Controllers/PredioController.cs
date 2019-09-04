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
    public class PredioController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listPredios()
        {
            List<Predio> predios = new List<Predio>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.predios";

                SqlDataReader reader = query.ExecuteReader();
                Predio predio;
                while (reader.Read())
                {
                    /*predio = new Predio();
                    predio.idPredio = (int)reader["idPredio"];
                    predio.mapa = (string)reader["mapa"];
                    predio.bloque = (string)reader["bloque"];
                    predio.numeroPredio = (string)reader["numeroPredio"];
                    predio.barrio = (string)reader["barrio"];
                    predio.caserio = (string)reader["caserio"];
                    predio.uso = (USO)reader["uso"];
                    predio.subUso = (SUBUSO)reader["subUso"];
                    predio.ubicacion = (string)reader["ubicacion"];
                    predio.sitio = (string)reader["sitio"];
                    predio.construccion = (string)reader["construccion"];
                    predio.estatusTributario = (ESTATUS_TRIBUTARIO)reader["estatusTributario"];
                    predio.codigoPropietario = (string)reader["codigoPropietario"];
                    predio.codigoHabitacional = (string)reader["codigoHabitacional"];
                    predio.porcentajeExencion = (double)reader["porcentajeExtencion"];
                    predio.tasaImpositiva = (double)reader["tasaImpositiva"];
                    predio.futurasRevisiones = (string)reader["futurasRevisiones"];
                    predio.porcentajeConcertacion = (double)reader["porcentajeConcertacion"];*/

                    predio = new Predio();
                    predio.idPredio = reader.GetString(0);
                    predio.mapa = reader.GetString(1);
                    predio.bloque = reader.GetString(2);
                    predio.numeroPredio = reader.GetString(3);
                    predio.barrio = reader.GetString(4);
                    predio.caserio = reader.GetString(5);
                    predio.sitio = reader.GetString(6);
                    predio.uso = reader.GetInt32(7);
                    predio.subUso = reader.GetInt32(8);
                    predio.ubicacion = reader.GetString(9);
                    predio.construccion = reader.GetString(10);
                    predio.estatusTributario = reader.GetInt32(11);
                    predio.codigoPropietario = reader.GetString(12);
                    predio.codigoHabitacional = reader.GetString(13);
                    predio.porcentajeExencion = reader.GetDouble(14);
                    predio.tasaImpositiva = reader.GetDouble(15);
                    predio.futurasRevisiones = reader.GetString(16);
                    predio.porcentajeConcertacion = reader.GetDouble(17);
                    predio.observacion = reader.GetString(18);

                    predios.Add(predio);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, predios);
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

        [HttpGet]
        public HttpResponseMessage getPredio(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.predios where idPredio = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                Predio predio = new Predio();
                while (reader.Read())
                {
                    /*predio = new Predio();
                   predio.idPredio = (int)reader["idPredio"];
                   predio.mapa = (string)reader["mapa"];
                   predio.bloque = (string)reader["bloque"];
                   predio.numeroPredio = (string)reader["numeroPredio"];
                   predio.barrio = (string)reader["barrio"];
                   predio.caserio = (string)reader["caserio"];
                   predio.uso = (USO)reader["uso"];
                   predio.subUso = (SUBUSO)reader["subUso"];
                   predio.ubicacion = (string)reader["ubicacion"];
                   predio.sitio = (string)reader["sitio"];
                   predio.construccion = (string)reader["construccion"];
                   predio.estatusTributario = (ESTATUS_TRIBUTARIO)reader["estatusTributario"];
                   predio.codigoPropietario = (string)reader["codigoPropietario"];
                   predio.codigoHabitacional = (string)reader["codigoHabitacional"];
                   predio.porcentajeExencion = (double)reader["porcentajeExtencion"];
                   predio.tasaImpositiva = (double)reader["tasaImpositiva"];
                   predio.futurasRevisiones = (string)reader["futurasRevisiones"];
                   predio.porcentajeConcertacion = (double)reader["porcentajeConcertacion"];*/

                    predio = new Predio();
                    predio.idPredio = reader.GetString(0);
                    predio.mapa = reader.GetString(1);
                    predio.bloque = reader.GetString(2);
                    predio.numeroPredio = reader.GetString(3);
                    predio.barrio = reader.GetString(4);
                    predio.caserio = reader.GetString(5);
                    predio.sitio = reader.GetString(6);
                    predio.uso = reader.GetInt32(7);
                    predio.subUso = reader.GetInt32(8);
                    predio.ubicacion = reader.GetString(9);
                    predio.construccion = reader.GetString(10);
                    predio.estatusTributario = reader.GetInt32(11);
                    predio.codigoPropietario = reader.GetString(12);
                    predio.codigoHabitacional = reader.GetString(13);
                    predio.porcentajeExencion = reader.GetDouble(14);
                    predio.tasaImpositiva = reader.GetDouble(15);
                    predio.futurasRevisiones = reader.GetString(16);
                    predio.porcentajeConcertacion = reader.GetDouble(17);
                    predio.observacion = reader.GetString(18);
                }
                conn.Close();
                if (string.IsNullOrEmpty(predio.idPredio))
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, predio);
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

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage createPredio(Predio p)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.predios where mapa = '" + p.mapa + "' and bloque = " + p.bloque + " order by numeroPredio desc limit 1";
                SqlDataReader reader = query.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    //int ultimoPredio = Int32.Parse((string)reader["numeroPredio"]);
                    int ultimoPredio = Int32.Parse(reader.GetString(0));
                    ultimoPredio++;
                    string nuevoNumeroPredio = ultimoPredio.ToString();
                    while (nuevoNumeroPredio.Length < 4)
                    {
                        nuevoNumeroPredio = "0" + nuevoNumeroPredio;
                    }
                    p.numeroPredio = nuevoNumeroPredio;
                }
                else
                {
                    p.numeroPredio = "0001";
                }

                reader.Close();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.predios VALUES (@id," +
                                                                "@mapa," +
                                                                "@bloque," +
                                                                "@numeroPredio," +
                                                                "@barrio," +
                                                                "@caserio," +
                                                                "@sitio," +
                                                                "@uso," +
                                                                "@subUso," +
                                                                "@ubicacion,"+
                                                                "@construccion," +
                                                                "@estatusTributario," +
                                                                "@codigoPropietario," +
                                                                "@codigoHabitacional," +
                                                                "@porcentajeExencion," +
                                                                "@tasaImpositiva," +
                                                                "@futurasRevisiones," +
                                                                "@porcentajeConcertacion" +
                                                                "@observacion);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", null);
                query.Parameters.AddWithValue("@mapa", p.mapa);
                query.Parameters.AddWithValue("@bloque", p.bloque);
                query.Parameters.AddWithValue("@numeroPredio", p.numeroPredio);
                query.Parameters.AddWithValue("@barrio", p.barrio);
                query.Parameters.AddWithValue("@caserio", p.caserio);
                query.Parameters.AddWithValue("@uso", p.uso);
                query.Parameters.AddWithValue("@subUso", p.subUso);
                query.Parameters.AddWithValue("@ubicacion", p.ubicacion);
                query.Parameters.AddWithValue("@sitio", p.sitio);
                query.Parameters.AddWithValue("@construccion",p.construccion);
                query.Parameters.AddWithValue("@estatusTributario",p.estatusTributario);
                query.Parameters.AddWithValue("@codigoPropietario",p.codigoPropietario);
                query.Parameters.AddWithValue("@codigoHabitacional",p.codigoHabitacional);
                query.Parameters.AddWithValue("@porcentajeExencion",p.porcentajeExencion);
                query.Parameters.AddWithValue("@tasaImpositiva",p.tasaImpositiva);
                query.Parameters.AddWithValue("@futurasRevisiones",p.futurasRevisiones);
                query.Parameters.AddWithValue("@porcentajeConcertacion",p.porcentajeConcertacion);
                query.Parameters.AddWithValue("@observacion", p.observacion);

                query.ExecuteNonQuery();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.predios where mapa = '" + p.mapa + "' and bloque = " + p.bloque + " and numeroPredio = '" + p.numeroPredio + "'";
                reader = query.ExecuteReader();
                reader.Read();
                p.idPredio = reader.GetString(0);

                reader.Close();
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modifyPredio(string id, Predio p)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.predios SET numeroPredio = @numeroPredio, " +
                                                        "mapa = @mapa, " +
                                                        "bloque = @bloque, " +
                                                        "barrio = @barrio,"
                                                    +   "caserio = @caserio, " +
                                                        "uso = @uso, " +
                                                        "subUso = @subUso, " +
                                                        "ubicacion = @ubicacion,"
                                                    +   "sitio = @sitio, " +
                                                        "construccion = @construccion,"
                                                    +   "estatusTributario = @estatusTributario, " +
                                                        "codigoPropietario = @codigoPropietario,"
                                                    +   "codigoHabitacional = @codigoHabitacional, " +
                                                        "porcentajeExtencion = @porcentajeExencion,"
                                                    +   "tasaImpositivo = @tasaImpositiva, " +
                                                        "futuraRevisiones = @futuraRevisiones,"
                                                    +   "porcentajeConcertacion = @porcentajeConcertacion " +
                                                        "observacion = @observacion where idPredio = @id";

                p.idPredio = id;

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@mapa", p.mapa);
                query.Parameters.AddWithValue("@bloque", p.bloque);
                query.Parameters.AddWithValue("@numeroPredio", p.numeroPredio);
                query.Parameters.AddWithValue("@barrio", p.barrio);
                query.Parameters.AddWithValue("@caserio", p.caserio);
                query.Parameters.AddWithValue("@uso", p.uso);
                query.Parameters.AddWithValue("@subUso", p.subUso);
                query.Parameters.AddWithValue("@ubicacion", p.ubicacion);
                query.Parameters.AddWithValue("@sitio", p.sitio);
                query.Parameters.AddWithValue("@construccion",p.construccion);
                query.Parameters.AddWithValue("@estatusTributario",p.estatusTributario);
                query.Parameters.AddWithValue("@codigoPropietario",p.codigoPropietario);
                query.Parameters.AddWithValue("@codigoHabitacional",p.codigoHabitacional);
                query.Parameters.AddWithValue("@porcentajeExencion",p.porcentajeExencion);
                query.Parameters.AddWithValue("@tasaImpositiva",p.tasaImpositiva);
                query.Parameters.AddWithValue("@futurasRevisiones",p.futurasRevisiones);
                query.Parameters.AddWithValue("@porcentajeConcertacion",p.porcentajeConcertacion);
                query.Parameters.AddWithValue("@observacion", p.observacion);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage deletePredio(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.predios where idPredio = @id";

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