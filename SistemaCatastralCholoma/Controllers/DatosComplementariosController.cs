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
    public class DatosComplementariosController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/DatosComplementarios
        [HttpGet]
        public HttpResponseMessage listDatosComplementarios()
        {
            List<DatosComplementarios> datosComplementariosList = new List<DatosComplementarios>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.datoscomplementarios";

                SqlDataReader reader = query.ExecuteReader();
                DatosComplementarios datosComplementarios;
                while (reader.Read())
                {
                    datosComplementarios = new DatosComplementarios();
                    datosComplementarios.idClaveCatastral = reader.GetString(0);
                    datosComplementarios.adquisicion= reader.GetDateTime(1);
                    datosComplementarios.montoTransaccion = reader.GetDouble(2);
                    datosComplementarios.claseTransaccion = reader.GetString(3);
                    datosComplementarios.maquinaria = reader.GetString(4);
                    datosComplementarios.delineador = reader.GetString(5);
                    datosComplementarios.fecha = reader.GetDateTime(6);
                    datosComplementarios.observaciones = reader.GetString(7);
                    datosComplementarios.ocupante = reader.GetString(8);
                    datosComplementarios.uso = reader.GetString(9);
                    datosComplementarios.clase = reader.GetString(10);
                    datosComplementarios.bueno = reader.GetDouble(11);
                    datosComplementarios.observacion = reader.GetString(12);
                    datosComplementarios.rentaMensual = reader.GetDouble(13);
                    datosComplementarios.idServiciosPublicos = reader.GetInt32(14);
                    datosComplementarios.valorDatosComplementarios = reader.GetDouble(15);
                    
                    datosComplementariosList.Add(datosComplementarios);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementariosList);
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

        // GET: api/DatosComplementarios/5
        [HttpGet]
        public HttpResponseMessage getDatosComplementarios(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.datoscomplementarios where idClaveCatastral = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();

                DatosComplementarios datosComplementarios = new DatosComplementarios();
                while (reader.Read())
                {
                    datosComplementarios.idClaveCatastral = reader.GetString(0);
                    datosComplementarios.adquisicion = reader.GetDateTime(1);
                    datosComplementarios.montoTransaccion = reader.GetDouble(2);
                    datosComplementarios.claseTransaccion = reader.GetString(3);
                    datosComplementarios.maquinaria = reader.GetString(4);
                    datosComplementarios.delineador = reader.GetString(5);
                    datosComplementarios.fecha = reader.GetDateTime(6);
                    datosComplementarios.observaciones = reader.GetString(7);
                    datosComplementarios.ocupante = reader.GetString(8);
                    datosComplementarios.uso = reader.GetString(9);
                    datosComplementarios.clase = reader.GetString(10);
                    datosComplementarios.bueno = reader.GetDouble(11);
                    datosComplementarios.observacion = reader.GetString(12);
                    datosComplementarios.rentaMensual = reader.GetDouble(13);
                    datosComplementarios.idServiciosPublicos = reader.GetInt32(14);
                    datosComplementarios.valorDatosComplementarios = reader.GetDouble(15);

                }
                conn.Close();
                if (datosComplementarios.idClaveCatastral == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementarios);
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

        // POST: api/DatosComplementarios
        [HttpPost]
        public HttpResponseMessage createDatosComplementarios(DatosComplementarios datosComplementarios)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.datoscomplementarios VALUES                                        (@idClaveCatastral,"
                                     + "@adquisicion," 
                                     + "@montoTransaccion,"
                                     + "@claseTransaccion,"
                                     + "@maquinaria,"
                                     + "@delineador,"
                                     + "@fecha,"
                                     + "@observacions,"
                                     + "@ocupante,"
                                     + "@uso,"
                                     + "@clase,"
                                     + "@bueno,"
                                     + "@observacion,"
                                     + "@rentaMensual,"
                                     + "@idServiciosPublicos,"
                                     + "@valorDatosComplementarios);";

                query.Prepare();
                query.Parameters.AddWithValue("@idClaveCatastral", datosComplementarios.idClaveCatastral);
                query.Parameters.AddWithValue("@adquisicion", datosComplementarios.adquisicion);
                query.Parameters.AddWithValue("@montoTransaccion", datosComplementarios.montoTransaccion);
                query.Parameters.AddWithValue("@claseTransaccion", datosComplementarios.claseTransaccion);
                query.Parameters.AddWithValue("@maquinaria", datosComplementarios.maquinaria);
                query.Parameters.AddWithValue("@delineador", datosComplementarios.delineador);
                query.Parameters.AddWithValue("@fecha", datosComplementarios.fecha);
                query.Parameters.AddWithValue("@observacions", datosComplementarios.observaciones);
                query.Parameters.AddWithValue("@ocupante", datosComplementarios.ocupante);
                query.Parameters.AddWithValue("@uso", datosComplementarios.uso);
                query.Parameters.AddWithValue("@clase", datosComplementarios.clase);
                query.Parameters.AddWithValue("@bueno", datosComplementarios.bueno);
                query.Parameters.AddWithValue("@observacion", datosComplementarios.observacion);
                query.Parameters.AddWithValue("@rentaMensual", datosComplementarios.rentaMensual);
                query.Parameters.AddWithValue("@idServiciosPublicos", datosComplementarios.idServiciosPublicos);
                query.Parameters.AddWithValue("@valorDatosComplementarios", datosComplementarios.valorDatosComplementarios);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementarios);
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

        // PUT: api/DatosComplementarios/5
        [HttpPut]
        public HttpResponseMessage modifyDatosComplementarios(string id, DatosComplementarios datosComplementarios)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.datoscomplementarios SET adquisicion = @adquisicion," +
                                                            "montoTransaccion = @montoTransaccion," +
                                                            "claseTransaccion = @claseTransaccion," +
                                                            "maquinaria = @maquinaria," +
                                                            "delineador = @delineador," +
                                                            "fecha = @fecha," +
                                                            "observacions = @observacions," +
                                                            "ocupante = @ocupante," +
                                                            "uso = @uso," +
                                                            "clase = @clase," +
                                                            "bueno = @bueno," +
                                                            "observacion = @observacion," +
                                                            "rentaMensual = @rentaMensual," +
                                                            "idServiciosPublicos = @idServiciosPublicos, " +
                                                            "valorDatosComplementarios = @valorDatosComplementarios " +
                                                            "where idClaveCatastral = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@idClaveCatastral", datosComplementarios.idClaveCatastral);
                query.Parameters.AddWithValue("@adquisicion", datosComplementarios.adquisicion);
                query.Parameters.AddWithValue("@montoTransaccion", datosComplementarios.montoTransaccion);
                query.Parameters.AddWithValue("@claseTransaccion", datosComplementarios.claseTransaccion);
                query.Parameters.AddWithValue("@maquinaria", datosComplementarios.maquinaria);
                query.Parameters.AddWithValue("@delineador", datosComplementarios.delineador);
                query.Parameters.AddWithValue("@fecha", datosComplementarios.fecha);
                query.Parameters.AddWithValue("@observacions", datosComplementarios.observaciones);
                query.Parameters.AddWithValue("@ocupante", datosComplementarios.ocupante);
                query.Parameters.AddWithValue("@uso", datosComplementarios.uso);
                query.Parameters.AddWithValue("@clase", datosComplementarios.clase);
                query.Parameters.AddWithValue("@bueno", datosComplementarios.bueno);
                query.Parameters.AddWithValue("@observacion", datosComplementarios.observacion);
                query.Parameters.AddWithValue("@rentaMensual", datosComplementarios.rentaMensual);
                query.Parameters.AddWithValue("@idServiciosPublicos", datosComplementarios.idServiciosPublicos);
                query.Parameters.AddWithValue("@valorDatosComplementarios", datosComplementarios.valorDatosComplementarios);
                datosComplementarios.idClaveCatastral = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementarios);
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

        // DELETE: api/DatosComplementarios/5
        [HttpDelete]
        public HttpResponseMessage deleteDatosComplementarios(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.datoscomplementarios where idClaveCatastral = @id";

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
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}
