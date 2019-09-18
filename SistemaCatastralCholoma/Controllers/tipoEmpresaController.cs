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
    public class tipoEmpresaController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        [HttpGet]
        public HttpResponseMessage listManPropietarios()
        {
            List<tipoEmpresa> mp = new List<tipoEmpresa>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "select * from bkmilcp6nvs1hgkadyz6.tipoEmpresa";
                SqlDataReader reader = query.ExecuteReader();
                tipoEmpresa tmp = new tipoEmpresa();
                while (reader.Read())
                {
                    tmp.empresa = reader.GetString(0);

                    mp.Add(tmp);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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

        [HttpGet]
        public HttpResponseMessage getMpId(string empresa)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "selec * from bkmilcp6nvs1hgkadyz6.tipoEmpresa where empresa = " + empresa;

                SqlDataReader reader = query.ExecuteReader();

                string tmp = reader.GetString(0);

                reader.Close();
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, tmp);
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

        [HttpPost]
        public HttpResponseMessage crearMP(tipoEmpresa mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "insert into bkmilcp6nvs1hgkadyz6.tipoEmpresa values (@empresa)";

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", mp.empresa);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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

        [HttpPut]
        public HttpResponseMessage modificarMP(string old, tipoEmpresa mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "update bkmilcp6nvs1hgkadyz6.tipoEmpresa set empresa = @empresa where empresa = " + old;

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", mp.empresa);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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

        [HttpDelete]
        public HttpResponseMessage deleteMP(string old)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "delete from bkmilcp6nvs1hgkadyz6.tipoEmpresa where empresa = @empresa";

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", old);
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
