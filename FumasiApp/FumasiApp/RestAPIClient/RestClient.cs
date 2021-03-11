using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FumasiApp.RestAPIClient
{
    public class RestClient<T>
    {
        private const string LoginWebServiceUrl = "https://localhost:44363/api/Account/";

        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);

            return response.IsSuccessStatusCode;
        }
    }
}
