using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace BubliotecaMVC.Service
{
    public class BibliotecaService
    {
        private const string url = "https://itunes.apple.com/";

        public Response BuscaLivros(string textoPesquisa)
        {
            Response retorno= null;
            string parametros = $"search?term={textoPesquisa}&entity=ibook";
            var newUrl = $"{url}{parametros}";

            HttpClient clientApi = new()
            {
                BaseAddress = new Uri(url)

            };

            var resultado = clientApi.GetAsync(newUrl).Result;
            if (resultado.IsSuccessStatusCode) //retorna o status code
            {
                //var texto = resultado.Content.ReadAsStringAsync().Result;
                retorno = resultado.Content.ReadFromJsonAsync<Response>().Result;
                //Console.WriteLine(texto); 
            }

            clientApi.Dispose();
            return retorno;
        }

        public Response BuscaLivroPeloId (int id)
        {
            Response retorno = null;
            string parametros = $"lookup?id={id}";
            var newUrl = $"{url}{parametros}";

            HttpClient clientApi = new()
            {
                BaseAddress = new Uri(url)

            };

            var resultado = clientApi.GetAsync(newUrl).Result;
            if (resultado.IsSuccessStatusCode)
            {
                retorno = resultado.Content.ReadFromJsonAsync<Response>().Result;
            }

            clientApi.Dispose();
            return retorno;
        }
    }
}
