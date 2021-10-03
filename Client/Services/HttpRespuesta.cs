using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Client.Services
{
    public class HttpRespuesta<T>
    {
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpresponsemessage { get; }

        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpresponsemessage = httpResponseMessage;
        }

        public async Task<string> GetBody()
        {
            var resp = await httpresponsemessage.Content.ReadAsStringAsync();
            return resp;
        }
    }
}
