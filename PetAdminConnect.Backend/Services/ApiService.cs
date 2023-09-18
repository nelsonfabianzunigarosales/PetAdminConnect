﻿using PetAdminConnect.Shared.Responses;
using System.Text.Json;

namespace PetAdminConnect.Backend.Services
{
    public class ApiService : IApiService
    {
        private readonly string _urlBase;
        private readonly string _tokenName;
        private readonly string _tokenValue;
        public ApiService(IConfiguration configuration)
        {

            _urlBase = configuration["CountriesAPI:urlBase"]!;
            _tokenName = configuration["CountriesAPI:tokenName"]!;
            _tokenValue = configuration["CountriesAPI:tokenValue"]!;

        }

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

       
        public async Task<Response<T>> GetAsync<T>(string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(_urlBase),
                };

                client.DefaultRequestHeaders.Add(_tokenName, _tokenValue);
                var url = $"{servicePrefix}{controller}";
                var responseHttp = await client.GetAsync(url);
                var response = await responseHttp.Content.ReadAsStringAsync();
                if (!responseHttp.IsSuccessStatusCode)
                {
                    return new Response<T>
                    {
                        WasSuccess = false,
                        Message = response
                    };
                }

                return new Response<T>
                {
                    WasSuccess = true,
                    Result = JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!
                };
            }
            catch (Exception ex)
            {
                return new Response<T>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

