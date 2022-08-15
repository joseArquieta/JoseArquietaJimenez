using JoseArquietaJimenez.Models;
using JoseArquietaJimenez.Models.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JoseArquietaJimenez.ApiConf
{
    public class ConexionApi
    {
        public static string UrlApi = ConfigurationManager.AppSettings["conexionApi"];

        public static async Task<ResultData> ActualizaProductosApi(object api)
        {
            var result = new ResultData();
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(UrlApi);

                var request = await _client.PostAsJsonAsync("_AcualizaCanciones", api);
                if (request.IsSuccessStatusCode)
                {
                    result = await request.Content.ReadAsAsync<ResultData>();
                }
            }
            return result;
        }

        public static async Task<ResultData> InsertarProductosApi(DatosCanciones api)
        {
            var result = new ResultData();
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(UrlApi);
              
                var request = await _client.PostAsJsonAsync("_CrearProducto", api);
                if (request.IsSuccessStatusCode)
                {
                    result = await request.Content.ReadAsAsync<ResultData>();
                }
            }
            return result;
        }
    }
}