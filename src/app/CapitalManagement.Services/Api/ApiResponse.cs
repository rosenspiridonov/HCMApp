using System.Net;

namespace CapitalManagement.Services.Api
{
    public class ApiResponse
    {
        public ApiResponse(HttpResponseMessage response)
        {
            StatusCode = response.StatusCode;
            Success = response.IsSuccessStatusCode;
            Data = response.Content.ReadAsStringAsync().Result;
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public string Data { get; set; }
    }
}
