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
    public class PropiedadController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET: api/Propietario
        [HttpGet]
        public HttpResponseMessage listPropiedades()
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propiedad";

                MySqlDataReader reader = query.ExecuteReader();

                Propiedad propiedad;
                while (reader.Read())
                {
                    string claveCatastral = (string)reader["claveCatastral"];

                    MySqlCommand queryPropietarios = conn.CreateCommand();

                    query.CommandText = "Select propietario from propietarios_propiedad where claveCatastral = '" + claveCatastral + "'";

                    MySqlDataReader readerPropietarios = query.ExecuteReader();

                    List<string> codigoPropitarios = new List<string>();
                    while (readerPropietarios.Read())
                    {
                        codigoPropitarios.Add((string)readerPropietarios["propietario"]);
                    }

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = (string)reader["mapa"];
                    propiedad.bloque = (string)reader["bloque"];
                    propiedad.predio = (string)reader["predio"];
                    propiedad.propietarioPrincipal = (string)reader["propietarioPrincipal"];
                    propiedad.propietarios = codigoPropitarios;
                    propiedad.informacionLegalPredio = (bool)reader["inforamcionLegalPredio"];
                    propiedad.caracteristicasPredio = (bool)reader["caracteristicasPredio"];
                    propiedad.datosComplementarios = (bool)reader["datosComplementarios"];
                    propiedad.terreno = (double)reader["terreno"];
                    propiedad.terrenoId = (string)reader["terrenoId"];
                    propiedad.edificaciones = (double)reader["edificaciones"];
                    propiedad.edificacionesId = (string)reader["edificacionesId"];
                    propiedad.detallesAdicionales = (double)reader["detallesAdicionales"];
                    propiedad.cultivosPermanentes = (double)reader["cultivosPermanentes"];
                    propiedad.valorDeclarado = (double)reader["valorDeclarado"];
                    propiedad.avaluoTotal = (double)reader["avaluoTotal"];
                    propiedad.exencion = (double)reader["exencion"];
                    propiedad.valorGrabable = (double)reader["valorGrabable"];
                    propiedad.impuesto = (double)reader["impuesto"];
                    propiedad.estadoPredio = (ESTADO_PREDIO)reader["estadoPredio"];
                    propiedades.Add(propiedad);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedades);
                return response;

            }
            catch (MySqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/Propietario/5
        [HttpGet]
        public HttpResponseMessage getPropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propiedad where claveCatastral = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Propiedad propiedad = new Propiedad();
                while (reader.Read())
                {
                    string claveCatastral = (string)reader["claveCatastral"];

                    MySqlCommand queryPropietarios = conn.CreateCommand();

                    query.CommandText = "Select propietario from propiedades_propietarios where claveCatastral = '" + claveCatastral + "'";

                    MySqlDataReader readerPropietarios = query.ExecuteReader();

                    List<string> codigoPropitarios = new List<string>();
                    while (readerPropietarios.Read())
                    {
                        codigoPropitarios.Add((string)readerPropietarios["propietario"]);
                    }

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = (string)reader["mapa"];
                    propiedad.bloque = (string)reader["bloque"];
                    propiedad.predio = (string)reader["predio"];
                    propiedad.propietarioPrincipal = (string)reader["propietarioPrincipal"];
                    propiedad.propietarios = codigoPropitarios;
                    propiedad.informacionLegalPredio = (bool)reader["inforamcionLegalPredio"];
                    propiedad.caracteristicasPredio = (bool)reader["caracteristicasPredio"];
                    propiedad.datosComplementarios = (bool)reader["datosComplementarios"];
                    propiedad.terreno = (double)reader["terreno"];
                    propiedad.terrenoId = (string)reader["terrenoId"];
                    propiedad.edificaciones = (double)reader["edificaciones"];
                    propiedad.edificacionesId = (string)reader["edificacionesId"];
                    propiedad.detallesAdicionales = (double)reader["detallesAdicionales"];
                    propiedad.cultivosPermanentes = (double)reader["cultivosPermanentes"];
                    propiedad.valorDeclarado = (double)reader["valorDeclarado"];
                    propiedad.avaluoTotal = (double)reader["avaluoTotal"];
                    propiedad.exencion = (double)reader["exencion"];
                    propiedad.valorGrabable = (double)reader["valorGrabable"];
                    propiedad.impuesto = (double)reader["impuesto"];
                    propiedad.estadoPredio = (ESTADO_PREDIO)reader["estadoPredio"];
                }
                if (propiedad.claveCatastral == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/Propietario
        [HttpPost]
        public HttpResponseMessage crearPropiedad(Propiedad propiedad)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "SELECT numeroPredio FROM predio WHERE mapa = '"+propiedad.mapa+"' AND bloque = '"+propiedad.bloque+"' ORDER BY numeroPredio DESC LIMIT 1;";
                MySqlDataReader readPredio = query.ExecuteReader();

                int numeroPredio = (int)readPredio["numeroPredio"] + 1;
                
                string claveCatastral = propiedad.mapa+propiedad.bloque+numeroPredio;

                query.CommandText = "INSERT INTO propiedades_propietarios VALUES (@clavecatastral, @propietario);";
                foreach (string codigo in propiedad.propietarios)
                {
                    query.Prepare();
                    query.Parameters.AddWithValue("@claveCatastral",claveCatastral);
                    query.Parameters.AddWithValue("@propietario",codigo);
                    query.ExecuteNonQuery();
                }

                query.CommandText = "INSERT INTO propiedad VALUES (@claveCatastral,"
                                                                + "@mapa,"
                                                                + "@bloque,"
                                                                + "@predio,"
                                                                + "@propietarioPrincipal,"
                                                                + "@propietarios,"
                                                                + "@informacionLegalPredio,"
                                                                + "@caracteristicasPredio,"
                                                                + "@datosComplementarios,"
                                                                + "@terreno,"
                                                                + "@terrenoId,"
                                                                + "@edificaciones,"
                                                                + "@edificacionesId,"
                                                                + "@detallesAdicionales,"
                                                                + "@cultivosPermanentes,"
                                                                + "@valorDeclarado,"
                                                                + "@avaluoTotal,"
                                                                + "@exencion,"
                                                                + "@valorGrabable,"
                                                                + "@impuesto,"
                                                                + "@estadoPredio);";
                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", claveCatastral);
                query.Parameters.AddWithValue("@mapa", propiedad.mapa);
                query.Parameters.AddWithValue("@bloque", propiedad.bloque);
                query.Parameters.AddWithValue("@predio", numeroPredio);
                query.Parameters.AddWithValue("@propietarioPrincipal", propiedad.propietarioPrincipal);
                query.Parameters.AddWithValue("@propietarios", null);
                query.Parameters.AddWithValue("@informacionLegalPredio", propiedad.informacionLegalPredio);
                query.Parameters.AddWithValue("@caracteristicasPredio", propiedad.caracteristicasPredio);
                query.Parameters.AddWithValue("@datosComplementarios", propiedad.datosComplementarios);
                query.Parameters.AddWithValue("@terreno", propiedad.terreno);
                query.Parameters.AddWithValue("@terrenoId", propiedad.terrenoId);
                query.Parameters.AddWithValue("@edificaciones", propiedad.edificaciones);
                query.Parameters.AddWithValue("@edificacionesId", propiedad.edificacionesId);
                query.Parameters.AddWithValue("@detallesAdicionales", propiedad.detallesAdicionales);
                query.Parameters.AddWithValue("@cultivosPermanentes", propiedad.cultivosPermanentes);
                query.Parameters.AddWithValue("@valorDeclarado", propiedad.valorDeclarado);
                query.Parameters.AddWithValue("@avaluoTotal", propiedad.avaluoTotal);
                query.Parameters.AddWithValue("@exencion", propiedad.exencion);
                query.Parameters.AddWithValue("@valorGrabable", propiedad.valorGrabable);
                query.Parameters.AddWithValue("@impuesto", propiedad.impuesto);
                query.Parameters.AddWithValue("@estadoPredio", propiedad.estadoPredio);
                query.ExecuteNonQuery();
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        // PUT: api/Propietario/5
        [HttpPut]
        public HttpResponseMessage modificarPropiedad(string id, Propiedad propiedad)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE propiedad SET propietarioPrincipal = @propietarioPrincipal,"
                                                        + "propietarios = @propietarios,"
                                                        + "informacionLegalPredio = @informacionLegalPredio,"
                                                        + "caracteristicasPredio = @caracteristicasPredio,"
                                                        + "datosComplementarios = @datosComplementarios,"
                                                        + "terreno = @terreno,"
                                                        + "terrenoId = @terrenoId,"
                                                        + "edificaciones = @edificaciones,"
                                                        + "edificacionesId = @edificacionesId,"
                                                        + "detallesAdicionales = @detallesAdicionales,"
                                                        + "cultivosPermanentes = @cultivosPermanentes,"
                                                        + "valorDeclarado = @valorDeclarado,"
                                                        + "avaluoTotal = @avaluoTotal,"
                                                        + "exencion = @exencion,"
                                                        + "valorGrabable = @valorGrabable,"
                                                        + "impuesto = @impuesto,"
                                                        + "estadoPredio = @estadoPredio"
                                                        +"WHERE claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.Parameters.AddWithValue("@propietarioPrincipal", propiedad.propietarioPrincipal);
                query.Parameters.AddWithValue("@propietarios", null);
                query.Parameters.AddWithValue("@informacionLegalPredio", propiedad.informacionLegalPredio);
                query.Parameters.AddWithValue("@caracteristicasPredio", propiedad.caracteristicasPredio);
                query.Parameters.AddWithValue("@datosComplementarios", propiedad.datosComplementarios);
                query.Parameters.AddWithValue("@terreno", propiedad.terreno);
                query.Parameters.AddWithValue("@terrenoId", propiedad.terrenoId);
                query.Parameters.AddWithValue("@edificaciones", propiedad.edificaciones);
                query.Parameters.AddWithValue("@edificacionesId", propiedad.edificacionesId);
                query.Parameters.AddWithValue("@detallesAdicionales", propiedad.detallesAdicionales);
                query.Parameters.AddWithValue("@cultivosPermanentes", propiedad.cultivosPermanentes);
                query.Parameters.AddWithValue("@valorDeclarado", propiedad.valorDeclarado);
                query.Parameters.AddWithValue("@avaluoTotal", propiedad.avaluoTotal);
                query.Parameters.AddWithValue("@exencion", propiedad.exencion);
                query.Parameters.AddWithValue("@valorGrabable", propiedad.valorGrabable);
                query.Parameters.AddWithValue("@impuesto", propiedad.impuesto);
                query.Parameters.AddWithValue("@estadoPredio", propiedad.estadoPredio);
                query.ExecuteNonQuery();

                query.CommandText = "DELETE FROM propiedades_propietarios WHERE claveCatastral = @clavecatastral;";
                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral",id);
                query.ExecuteNonQuery();

                query.CommandText = "INSERT INTO propiedades_propietarios VALUES (@clavecatastral, @propietario);";
                foreach (string codigo in propiedad.propietarios)
                {
                    query.Prepare();
                    query.Parameters.AddWithValue("@claveCatastral",id);
                    query.Parameters.AddWithValue("@propietario",codigo);
                    query.ExecuteNonQuery();
                }
                conn.Close();
                propiedad.claveCatastral = id;
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        // DELETE: api/Propietario/5
        [HttpDelete]
        public HttpResponseMessage eliminarPropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from propiedad where claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }

        }
    }
}
