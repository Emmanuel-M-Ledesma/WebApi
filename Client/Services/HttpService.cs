using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApi.Client.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient httpClient;

        public HttpService(HttpClient http)
        {
            this.httpClient = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var RespGet = await httpClient.GetAsync(url);
            if (RespGet.IsSuccessStatusCode)
            {
                var resp = await DeserializarRespuesta<T>(RespGet);
                return new HttpRespuesta<T>(resp, false, RespGet);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, RespGet);
            }
        }

        public async Task<HttpRespuesta<object>> Post<T>(string url, T send)
        {
            try
            {
                var SendJson = JsonSerializer.Serialize(send);
                var SendContent = new StringContent(SendJson, Encoding.UTF8, "application/json");
                var RespPost = await httpClient.PostAsync(url, SendContent);

                return new HttpRespuesta<object>(null, !RespPost.IsSuccessStatusCode, RespPost);
            }
            catch (Exception )
            {

                throw  ;
            }
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T send)
        {
            try
            {
                var SendJson = JsonSerializer.Serialize(send);
                var SendContent = new StringContent(SendJson, Encoding.UTF8, "application/json");
                var RespPut = await httpClient.PutAsync(url, SendContent);

                return new HttpRespuesta<object>(null, !RespPut.IsSuccessStatusCode, RespPut);
            }
            catch (Exception )
            {

                throw;
            }
        }
        
        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var RespDel = await httpClient.DeleteAsync(url);
            return new HttpRespuesta<object>(null, !RespDel.IsSuccessStatusCode, RespDel);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpRespuesta)
        {
            var RepuestaString = await httpRespuesta.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(RepuestaString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
