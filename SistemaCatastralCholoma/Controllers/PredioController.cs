using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SistemaCatastralCholoma.Models;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class PredioController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listPredios()
        {
            List<Predio> predios = new List<Predio>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predios";

                MySqlDataReader reader = query.ExecuteReader();
                Predio predio;
                while (reader.Read())
                {
                    predio = new Predio();
                    predio.idPredio = (int)reader["idPredio"];
                    predio.mapa = reader.GetString("mapa");
                    predio.bloque = reader.GetString("bloque");
                    predio.numeroPredio = (string)reader["numeroPredio"];
                    predio.barrio = (string)reader["barrio"];
                    predio.caserio = (string)reader["caserio"];
                    predio.uso = (USO)reader.GetInt32("uso");
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
                    predio.porcentajeConcertacion = (double)reader["porcentajeConcertacion"];


                    predios.Add(predio);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, predios);
                return response;

            }
            catch (MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predios where idPredio = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Predio predio = new Predio();
                while (reader.Read())
                {
                    predio.idPredio = (int)reader["idPredio"];
                    predio.mapa = reader.GetString("mapa");
                    predio.bloque = reader.GetString("bloque");
                    predio.numeroPredio = (string)reader["numeroPredio"];
                    predio.barrio = (string)reader["barrio"];
                    predio.caserio = (string)reader["caserio"];
                    predio.uso = (USO)reader.GetInt32("uso");
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
                    predio.porcentajeConcertacion = (double)reader["porcentajeConcertacion"];
                }
                conn.Close();
                if (predio.idPredio == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, predio);
                return response;

            }
            catch (MySqlException e)
            {
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predios where mapa = '" + p.mapa + "' and bloque = " + p.bloque + " order by numeroPredio desc limit 1";
                MySqlDataReader reader = query.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int ultimoPredio = Int32.Parse(reader.GetString("numeroPredio"));
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

                query.CommandText = "INSERT INTO predios VALUES (@id," +
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
                                                                "@porcentajeConcertacion);";

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

                query.ExecuteNonQuery();

                query.CommandText = "Select * from predios where mapa = '" + p.mapa + "' and bloque = " + p.bloque + " and numeroPredio = '" + p.numeroPredio + "'";
                reader = query.ExecuteReader();
                reader.Read();
                p.idPredio = reader.GetInt32("idPredio");

                reader.Close();
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modifyPredio(int id, Predio p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE predios SET numeroPredio = @numeroPredio, " +
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
                                                    +   "porcentajeConcertacion = @porcentajeConcertacion where idPredio = @id";

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
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from predios where idPredio = @id";

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