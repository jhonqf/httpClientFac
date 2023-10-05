using Microsoft.Net.Http.Headers;
using System.Net.Http;

namespace PHttpClienteFactory.Interface
{
    public interface IHttpCallService
    {
        Task<T> GetData<T>();
       

    }
}
