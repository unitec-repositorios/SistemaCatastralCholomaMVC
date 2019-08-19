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
    public class NegociosController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listnegocios()
        {
            List<Negocios> negocios = new List<Negocios>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.negocios";

                SqlDataReader reader = query.ExecuteReader();
                Negocios negocio;
                while (reader.Read())
                {
                     negocio = new Negocios();
                    /*negocio.idnegocios = (int)reader["id"];
                    negocio.nombre = (string)reader["nombre"];
                    negocio.direccion = (string)reader["direccion"];
                    negocio.tipo = (string)reader["tipo"]; 
                    negocio.deuda = (double)reader["deuda"];
                    negocio.cofundadores = (string)reader["cofundadores"];
                    negocio.fechaFundacion = (string)reader["fechaFundacion"];
                    negocio.idclavecatastral_n = (string)reader["idclavecatastral_n"];*/

                    negocio.idnegocios = reader.GetInt32(0);
                    negocio.nombre = reader.GetString(1);
                    negocio.direccion = reader.GetString(2);
                    negocio.tipo = reader.GetString(3);
                    negocio.deuda = reader.GetDouble(4);
                    negocio.cofundadores = reader.GetString(5);
                    negocio.fechaFundacion = reader.GetString(6);
                    negocio.idclavecatastral_n = reader.GetString(7);

                    negocios.Add(negocio);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, negocios);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getnegocios(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.negocios where id = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                Negocios negocio = new Negocios();
                while (reader.Read())
                {
                    /*negocio.idnegocios = (int)reader["id"];
                    negocio.nombre = (string)reader["nombre"];
                    negocio.direccion = (string)reader["direccion"];
                    negocio.tipo = (string)reader["tipo"]; 
                    negocio.deuda = (double)reader["deuda"];
                    negocio.cofundadores = (string)reader["cofundadores"];
                    negocio.fechaFundacion = (string)reader["fechaFundacion"];
                    negocio.idclavecatastral_n = (string)reader["idclavecatastral_n"];*/

                    negocio.idnegocios = reader.GetInt32(0);
                    negocio.nombre = reader.GetString(1);
                    negocio.direccion = reader.GetString(2);
                    negocio.tipo = reader.GetString(3);
                    negocio.deuda = reader.GetDouble(4);
                    negocio.cofundadores = reader.GetString(5);
                    negocio.fechaFundacion = reader.GetString(6);
                    negocio.idclavecatastral_n = reader.GetString(7);


                }
                conn.Close();
                if (negocio.idnegocios == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, negocio);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage crearnegocios(Negocios p)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.negocios VALUES (@idnegocios,@nombre,@direccion,@tipo,@deuda,@cofundadores,@fechaFundacion,@idclavecatastral_n);";

                query.Prepare();
                query.Parameters.AddWithValue("@idnegocios", p.idnegocios);
                query.Parameters.AddWithValue("@nombre", p.nombre);
                query.Parameters.AddWithValue("@direccion", p.direccion);
                query.Parameters.AddWithValue("@tipo", p.tipo);
                query.Parameters.AddWithValue("@deuda", p.deuda);
                query.Parameters.AddWithValue("@cofundadores", p.cofundadores);
                query.Parameters.AddWithValue("@fechaFundacion", p.fechaFundacion);
                query.Parameters.AddWithValue("@idclavecatastral_n", p.idclavecatastral_n);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, p);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modificarnegocios(int id, Negocios p)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.negocios SET idnegocios = @idnegocios, nombre = @nombre,"
                                                    + "direccion = @direccion, tipo = @tipo, deuda = @deuda,"
                                                    + "cofundadores = @cofundadores, fechaFundacion = @fechaFundacion,"
                                                    + "ididclavecatastral_n = @idclavecatastral_n";

                p.idnegocios = id;

                query.Prepare();
                query.Parameters.AddWithValue("@idnegocios", p.idnegocios);
                query.Parameters.AddWithValue("@nombre", p.nombre);
                query.Parameters.AddWithValue("@direccion", p.direccion);
                query.Parameters.AddWithValue("@tipo", p.tipo);
                query.Parameters.AddWithValue("@deuda", p.deuda);
                query.Parameters.AddWithValue("@cofundadores", p.cofundadores);
                query.Parameters.AddWithValue("@fechaFundacion", p.fechaFundacion);
                query.Parameters.AddWithValue("@idclavecatastral_n", p.idclavecatastral_n);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage eliminarnegocio(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.negocio where idnegocios = @idnegocios";

                query.Prepare();
                query.Parameters.AddWithValue("@idnegocios", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}