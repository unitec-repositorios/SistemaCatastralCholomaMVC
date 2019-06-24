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
    public class DatosComplementariosController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/DatosComplementarios
        [HttpGet]
        public HttpResponseMessage listDatosComplementarios()
        {
            List<DatosComplementarios> datosComplementariosList = new List<DatosComplementarios>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datoscomplementarios";

                MySqlDataReader reader = query.ExecuteReader();
                DatosComplementarios datosComplementarios;
                while (reader.Read())
                {
                    datosComplementarios = new DatosComplementarios();
                    datosComplementarios.idClaveCatastral = (string)reader["idClaveCatastral"];
                    datosComplementarios.adquicicion= reader.GetMySqlDateTime(5).GetDateTime();
                    datosComplementarios.montoTransaccion = (Double)reader["montoTransaccion"];
                    datosComplementarios.claseTransaccion = (string)reader["montoTransaccion"];
                    datosComplementarios.maquinaria = (string)reader["maquinaria"];
                    datosComplementarios.delineador = (string)reader["delineador"];
                    datosComplementarios.fecha = reader.GetMySqlDateTime(5).GetDateTime();
                    datosComplementarios.observacions = (string)reader["observacions"];
                    datosComplementarios.ocupante = (string)reader["ocupante"];
                    datosComplementarios.uso = (string)reader["uso"];
                    datosComplementarios.clase = (string)reader["clase"];
                    datosComplementarios.bueno = (Double)reader["bueno"];
                    datosComplementarios.observacion = (string)reader["observacion"];
                    datosComplementarios.rentaMensual = (Double)reader["rentaMensual"];
                    datosComplementarios.idServiciosPublicos = (int)reader["idServiciosPublicos"];
                    datosComplementarios.valorDatosComplementarios = (Double)reader["valorDatosComplementarios"];
                    
                    datosComplementariosList.Add(datosComplementarios);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementariosList);
                return response;

            }
            catch (MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datoscomplementarios where idClaveCatastral = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();

                DatosComplementarios datosComplementarios = new DatosComplementarios();
                while (reader.Read())
                {
                    datosComplementarios.idClaveCatastral = (string)reader["idClaveCatastral"];
                    datosComplementarios.adquicicion = reader.GetMySqlDateTime(5).GetDateTime();
                    datosComplementarios.montoTransaccion = (Double)reader["montoTransaccion"];
                    datosComplementarios.claseTransaccion = (string)reader["montoTransaccion"];
                    datosComplementarios.maquinaria = (string)reader["maquinaria"];
                    datosComplementarios.delineador = (string)reader["delineador"];
                    datosComplementarios.fecha = reader.GetMySqlDateTime(5).GetDateTime();
                    datosComplementarios.observacions = (string)reader["observacions"];
                    datosComplementarios.ocupante = (string)reader["ocupante"];
                    datosComplementarios.uso = (string)reader["uso"];
                    datosComplementarios.clase = (string)reader["clase"];
                    datosComplementarios.bueno = (Double)reader["bueno"];
                    datosComplementarios.observacion = (string)reader["observacion"];
                    datosComplementarios.rentaMensual = (Double)reader["rentaMensual"];
                    datosComplementarios.idServiciosPublicos = (int)reader["idServiciosPublicos"];
                    datosComplementarios.valorDatosComplementarios = (Double)reader["valorDatosComplementarios"];

                }
                conn.Close();
                if (datosComplementarios.idClaveCatastral == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, datosComplementarios);
                return response;

            }
            catch (MySqlException e)
            {
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO datoscomplementarios VALUES                                        (@idClaveCatastral,"
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
                query.Parameters.AddWithValue("@adquisicion", datosComplementarios.adquicicion);
                query.Parameters.AddWithValue("@montoTransaccion", datosComplementarios.montoTransaccion);
                query.Parameters.AddWithValue("@claseTransaccion", datosComplementarios.claseTransaccion);
                query.Parameters.AddWithValue("@maquinaria", datosComplementarios.maquinaria);
                query.Parameters.AddWithValue("@delineador", datosComplementarios.delineador);
                query.Parameters.AddWithValue("@fecha", datosComplementarios.fecha);
                query.Parameters.AddWithValue("@observacions", datosComplementarios.observacions);
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE datoscomplementarios SET adquisicion = @adquisicion," +
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
                query.Parameters.AddWithValue("@adquisicion", datosComplementarios.adquicicion);
                query.Parameters.AddWithValue("@montoTransaccion", datosComplementarios.montoTransaccion);
                query.Parameters.AddWithValue("@claseTransaccion", datosComplementarios.claseTransaccion);
                query.Parameters.AddWithValue("@maquinaria", datosComplementarios.maquinaria);
                query.Parameters.AddWithValue("@delineador", datosComplementarios.delineador);
                query.Parameters.AddWithValue("@fecha", datosComplementarios.fecha);
                query.Parameters.AddWithValue("@observacions", datosComplementarios.observacions);
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
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
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
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from datoscomplementarios where idClaveCatastral = @id";

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
