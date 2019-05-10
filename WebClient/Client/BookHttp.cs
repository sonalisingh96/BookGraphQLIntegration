using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebClient.Client
{
    public class BookHttp
    {
        private readonly HttpClient _httpClient;
        public BookHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Response<BooksContainer>> GetBooks()
        {
            var response = await _httpClient.GetAsync(@"?query= 
            { book
                { title author isbn } 
            }");
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<BooksContainer>>(stringResult);
        }
    }
}
