using Microsoft.AspNetCore.Cors;
using Microsoft.Net.Http.Headers;
using PHttpClienteFactory.Interface;
using System.Diagnostics;
using System.Net.Http;

namespace PHttpClienteFactory.Service
{
    public class HttpCallService: IHttpCallService
    {
        private readonly IHttpClientFactory _httpClientFactory;

         public HttpCallService(IHttpClientFactory httpClientFactory)=>
            _httpClientFactory = httpClientFactory;
        
        public async Task<T> GetData<T>()
        {
            T data = default(T);
            var httpResquestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.publicapis.org/entries")
            {
                Headers ={
                    {HeaderNames.Accept,"application/json"},
                    {HeaderNames.UserAgent,"HttpRequestsSample" }
                    
                }
            };
            var httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response =await httpClient.SendAsync(httpResquestMessage);
            if (response.IsSuccessStatusCode) {
                data=await  response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }
            else
            {

                data= default(T);
            }
            return data;

        }
    }
}
