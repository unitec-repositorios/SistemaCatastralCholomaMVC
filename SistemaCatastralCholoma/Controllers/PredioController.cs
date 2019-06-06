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

                query.CommandText = "Select * from predio";

                MySqlDataReader reader = query.ExecuteReader();
                Predio predio;
                while (reader.Read())
                {
                    predio = new Predio();
                    predio.id = (string)reader["id"];
                    predio.numeroPredio = (string)reader["numeroPredio"];
                    predio.barrio = (string)reader["barrio"];
                    predio.caserio = (string)reader["caserio"];
                    predio.uso = (USO)reader["uso"];
                    predio.subUso = (SUBUSO)reader["subUso"];
                    predio.sitio = (string)reader["sitio"];
                    predio.construccion = (string)reader["construccion"];
                    predio.estatusTributario = (ESTATUS_TRIBUTARIO)reader["estatusTributario"];
                    predio.codigoPropietario = (string)reader["codigoPropietario"];
                    predio.codigoHabitacional = (string)reader["codigoHabitacional"];
                    predio.porcentajeExencion = (double)reader["porcentajeExencion"];
                    predio.tasaImpositiva = (double)reader["tasaImpositiva"];
                    predio.futurasRevisiones = (int)reader["futurasRevisiones"];
                    predio.porcentajeConcertacion = (double)reader["procentajeConcertacion"];


                    predios.Add(predio);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, predios);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getPredio(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from predio where id = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Predio predio = new Predio();
                while (reader.Read())
                {
                    predio = new Predio();
                    predio.id = (string)reader["id"];
                    predio.numeroPredio = (string)reader["numeroPredio"];
                    predio.barrio = (string)reader["barrio"];
                    predio.caserio = (string)reader["caserio"];
                    predio.uso = (USO)reader["uso"];
                    predio.subUso = (SUBUSO)reader["subUso"];
                    predio.sitio = (string)reader["sitio"];
                    predio.construccion = (string)reader["construccion"];
                    predio.estatusTributario = (ESTATUS_TRIBUTARIO)reader["estatusTributario"];
                    predio.codigoPropietario = (string)reader["codigoPropietario"];
                    predio.codigoHabitacional = (string)reader["codigoHabitacional"];
                    predio.porcentajeExencion = (double)reader["porcentajeExencion"];
                    predio.tasaImpositiva = (double)reader["tasaImpositiva"];
                    predio.futurasRevisiones = (int)reader["futurasRevisiones"];
                    predio.porcentajeConcertacion = (double)reader["procentajeConcertacion"];

                }
                conn.Close();
                if (predio.id == null)
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
        public HttpResponseMessage crearPredio(Predio p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO predio VALUES (@id,@numeroPredio,@barrio,@caserio,@uso,@subUso,@sitio,@construccion,@estatusTributario,@codigoPropietario,@codigoHabitacional,@porcentajeExencion,@tasaImpositiva,@futurasRevisiones,@porcentajeConcertacion);";

                query.Prepare();
                query.Parameters.AddWithValue("@id", p.id);
                query.Parameters.AddWithValue("@numeroPredio", p.numeroPredio);
                query.Parameters.AddWithValue("@barrio", p.barrio);
                query.Parameters.AddWithValue("@caserio", p.caserio);
                query.Parameters.AddWithValue("@uso", p.uso);
                query.Parameters.AddWithValue("@subUso", p.subUso);
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
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, p);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
public HttpResponseMessage modificarPredio(string id, Predio p)
{
    try
    {
        conn.Open();

        MySqlCommand query = conn.CreateCommand();

        query.CommandText = "UPDATE predio SET numeroPredio = @numeroPredio, barrio = @barrio,"
                                            +  "caserio = @caserio, uso = @uso, subUso = @subUso,"
                                            +  "sitio = @sitio, construccion = @construccion,"
                                            +  "estatusTributario = @estatusTributario, codigoPropietario = @codigoPropietario,"
                                            +  "codigoHabitacional = @codigoHabitacional, porcentajeExencion = @porcentajeExencion,"
                                            +  "tasaImpositivo = @tasaImpositiva, futuraRevisiones = @futuraRevisiones,"
                                            +  "porcentajeConcertacion = @porcentajeConcertacion where id = @id";

        p.id = id;

        query.Prepare();
        query.Parameters.AddWithValue("@id", p.id);
        query.Parameters.AddWithValue("@numeroPredio", p.numeroPredio);
        query.Parameters.AddWithValue("@barrio", p.barrio);
        query.Parameters.AddWithValue("@caserio", p.caserio);
        query.Parameters.AddWithValue("@uso", p.uso);
        query.Parameters.AddWithValue("@subUso", p.subUso);
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
        var response = Request.CreateResponse(HttpStatusCode.BadRequest);
        return response;
    }
}

// DELETE api/<controller>/5
[HttpDelete]
public HttpResponseMessage eliminarPredio(string id)
{
    try
    {
        conn.Open();
        MySqlCommand query = conn.CreateCommand();
        query.CommandText = "Delete from predio where id = @id";

        query.Prepare();
        query.Parameters.AddWithValue("@id", id);
        query.ExecuteNonQuery();

        conn.Close();

        var response = Request.CreateResponse(HttpStatusCode.NoContent);
        return response;

    }
    catch (MySql.Data.MySqlClient.MySqlException e)
    {
        var response = Request.CreateResponse(HttpStatusCode.BadRequest);
        return response;
    }
}
    }
}