using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SistemaCatastralCholoma.Models;

namespace SistemaCatastralCholoma.Controllers
{
    public class DetallesAdicionalesController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        [HttpGet]
        public HttpResponseMessage listDetallesAdicionales()
        {
            List<DetallesAdicionales> detallesAdicionales = new List<DetallesAdicionales>();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from bkmilcp6nvs1hgkadyz6.detallesadicionales";
                SqlDataReader reader = cmd.ExecuteReader();
                DetallesAdicionales detalle = new DetallesAdicionales();
                while (reader.Read())
                {
                    detalle = new DetallesAdicionales();
                    detalle.idDetallesAdicionales = reader.GetInt32(0);
                    detalle.codigo = reader.GetString(1);
                    detalle.codEdificacion = reader.GetInt32(2);
                    detalle.area = reader.GetDouble(3);
                    detalle.porcentaje = reader.GetDouble(4);
                    detalle.costoUnitario = reader.GetDouble(5);
                    detalle.comentario = reader.GetString(6);
                    detalle.valorDetallesAdicionales = reader.GetDouble(7);
                    detalle.idClaveCatastral = reader.GetString(8);

                    detallesAdicionales.Add(detalle);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, detallesAdicionales);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getDetalleAdicional(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "select * from bkmilcp6nvs1hgkadyz6.detallesadicionales where idDetallesAdicionales = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();
                DetallesAdicionales detalle = new DetallesAdicionales();
                while (reader.Read())
                {
                    detalle.idDetallesAdicionales = reader.GetInt32(0);
                    detalle.codigo = reader.GetString(1);
                    detalle.codEdificacion = reader.GetInt32(2);
                    detalle.area = reader.GetDouble(3);
                    detalle.porcentaje = reader.GetDouble(4);
                    detalle.costoUnitario = reader.GetDouble(5);
                    detalle.comentario = reader.GetString(6);
                    detalle.valorDetallesAdicionales = reader.GetDouble(7);
                    detalle.idClaveCatastral = reader.GetString(8);

                }
                conn.Close();

                if (detalle == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, detalle);
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
        public HttpResponseMessage createDetallesAdicionales(DetallesAdicionales detalle)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.detallesadicionales VALUES (@idDetallesAdicionales, @codigo," +
                                                               "@codEdificacion," +
                                                               "@area," +
                                                               "@porcentaje," +
                                                               "@costoUnitario," +
                                                               "@comentario," +
                                                               "@valorDetallesAdicionales," +
                                                               "@idClaveCatasral);";

                query.Prepare();
                query.Parameters.AddWithValue("@idDetallesAdicionales", detalle.idDetallesAdicionales);
                query.Parameters.AddWithValue("@codigo", detalle.codigo);
                query.Parameters.AddWithValue("@codEdificacion", detalle.codEdificacion);
                query.Parameters.AddWithValue("@area", detalle.area);
                query.Parameters.AddWithValue("@porcentaje", detalle.porcentaje);
                query.Parameters.AddWithValue("@costoUnitario", detalle.costoUnitario);
                query.Parameters.AddWithValue("@comentario", detalle.comentario);
                query.Parameters.AddWithValue("@valorDetallesAdicionales", detalle.valorDetallesAdicionales);
                query.Parameters.AddWithValue("@idClaveCatasral", detalle.idClaveCatastral);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, detalle);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage modifyDetallesAdicionales(int id, DetallesAdicionales detalle)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.detallesadicionales SET codigo = @codigo," +
                                                      "codEdificacion = @codEdificacion," +
                                                      "area = @area," +
                                                      "porcentaje = @porcentaje," +
                                                      "costoUnitario = @costoUnitario," +
                                                      "comentario = @comentario," +
                                                      "valorDetallesAdicionales = @valorDetallesAdicionales, " +
                                                      "idClaveCatastral = @idClaveCatastral " +
                                                      "where idDetallesAdicionales = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@codigo", detalle.codigo);
                query.Parameters.AddWithValue("@codEdificacion", detalle.codEdificacion);
                query.Parameters.AddWithValue("@area", detalle.area);
                query.Parameters.AddWithValue("@porcentaje", detalle.porcentaje);
                query.Parameters.AddWithValue("@costoUnitario", detalle.costoUnitario);
                query.Parameters.AddWithValue("@comentario", detalle.comentario);
                query.Parameters.AddWithValue("@valorDetallesAdicionales", detalle.valorDetallesAdicionales);
                query.Parameters.AddWithValue("@idClaveCatastral", detalle.idClaveCatastral);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, detalle);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteDetalleAdicionales(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "delete from bkmilcp6nvs1hgkadyz6.detallesadicionales where idDetallesAdicionales = @id";

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
