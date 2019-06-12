using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{
    public class CaracteristicasVecindadController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/CaracteristicasVecindad
        [HttpGet]
        public HttpResponseMessage listCaracteristicasVecindad()
        {
            List<CaracteristicasVecindad> caraven = new List<CaracteristicasVecindad>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from caracteristicasvecindad";

                MySqlDataReader reader = query.ExecuteReader();
                CaracteristicasVecindad carv;
                while (reader.Read())
                {
                    carv = new CaracteristicasVecindad();
                    carv.idcaracteristicasvecindad = (string)reader["idcaracteristicasvecindad"];
                    carv.Iglesia = (string)reader["Iglesia"];
                    carv.Escuela = (string)reader["Escuela"];
                    carv.sitioEmbarque = (Double)reader["sitioEmbarque"];
                    carv.mercadoCercano = (Double)reader["mercadoCercano"];

                    carv.Add(carv);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, caraven);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/CaracteristicasVecindad/5
        [HttpGet]
        public HttpResponseMessage getCaracteristicasVecindad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from caracteristicasvecindad where idcaracteristicasvecindad = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();
                CaracteristicasVecindad car = new CaracteristicasVecindad();

                while (reader.Read())
                {
                    car.idcaracteristicasvecindad = (string)reader["idcaracteristicasvecindad"];
                    car.Iglesia = (string)reader["Iglesia"];
                    car.Escuela = (string)reader["Escuela"];
                    car.sitioEmbarque = (Double)reader["sitioEmbarque"];
                    car.mercadoCercano = (Double)reader["mercadoCercano"];
                }

                conn.Close();
                if (car.idcaracteristicasvecindad == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new KeyNotFoundException("No se encontro CaracterísticaVecindad con codigo " + id));

                var response = Request.CreateResponse(HttpStatusCode.OK, car);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }
        // POST: api/CaracteristicasVecindad
        [HttpPost]
        public HttpResponseMessage createCaracteristicasVecindad(CaracteristicasVecindad carv)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO caracteristicasvecindad VALUES (@idcaracteristicasvecindad," +
                                                               "@Iglesia," +
                                                               "@Escuela," +
                                                               "@sitioEmbarque," +
                                                               "@mercadoCercano);";

                query.Prepare();
                query.Parameters.AddWithValue("@idavaluoedificaciones", carv.idavaluoedificaciones);
                query.Parameters.AddWithValue("@Iglesia", carv.Iglesia);
                query.Parameters.AddWithValue("@Escuela", carv.Escuela);
                query.Parameters.AddWithValue("@sitioEmbarque", carv.sitioEmbarque);
                query.Parameters.AddWithValue("@mercadoCercano", carv.mercadoCercano);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, carv);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/CaracteristicasVecindad/5
        [HttpPut]
        public HttpResponseMessage modifyCaracteristicasVecindad(string id, CaracteristicasVecindad carva)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE caracteristicasvecindad SET Iglesia = @Iglesia," +
                                                      "Escuela = @Escuela " +
                                                      "sitioEmbarque = @sitioEmbarque " +
                                                      "mercadoCercano = @mercadoCercano " +
                                                      "where idcaracteristicasvecindad = @idcaracteristicasvecindad";

                query.Prepare();
                query.Parameters.AddWithValue("@idcaracteristicasvecindad", id);
                query.Parameters.AddWithValue("@Iglesia", carva.Iglesia);
                query.Parameters.AddWithValue("@Escuela", carva.Escuela);
                query.Parameters.AddWithValue("@sitioEmbarque", carva.Escuela);
                query.Parameters.AddWithValue("@mercadoCercano", carva.Escuela);
                query.ExecuteNonQuery();
                avaluo.idcaracteristicasvecindad = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, carva);
                return response;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // DELETE: api/CaracteristicasVecindad/5
        [HttpDelete]
        public HttpResponseMessage deleteCaracteristicasVecindad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from caracteristicasvecindad where idcaracteristicasvecindad = @id";

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