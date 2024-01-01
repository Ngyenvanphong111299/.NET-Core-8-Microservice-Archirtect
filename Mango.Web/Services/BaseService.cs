using Mango.Web.Models;
using Mango.Web.Services.IServices;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto ResponseDto { get ; set ; }
        public IHttpClientFactory HttpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseDto = new ResponseDto();
            HttpClient = httpClient;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SenAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonSerializer.Serialize(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }

                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonSerializer.Deserialize<T>(apiContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return apiResponseDto;
            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonSerializer.Serialize(dto);
                var apiResponseDto = JsonSerializer.Deserialize<T>(res, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return apiResponseDto;
            }
        }
    }
}
