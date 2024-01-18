using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FoundIt.Models;

namespace FoundIt.Services
{
    public class FoundItService
    {
        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _serializerOptions;
        const string URL = @"https://h8pwv439-7102.euw.devtunnels.ms/api/FoundIt/";

        public FoundItService()
        {
            _httpClient = new HttpClient();

            //הגדרות הסיריליזאציה
            //האם להעלם מאותיות גדולות/קטנות
            //האם לייצר json עם רווחים
            //כיצד לטפל במקרה של הפניות מעגליות
            _serializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

        }

        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{URL}Register", content);

                switch (response.StatusCode)
                {
                    case (HttpStatusCode.OK):
                        {
                            jsonContent = await response.Content.ReadAsStringAsync();
                            User u = JsonSerializer.Deserialize<User>(jsonContent, _serializerOptions);
                            await Task.Delay(2000);
                            return true;
                        }
                    case (HttpStatusCode.Conflict):
                        {
                            return false;
                        }
                    case (HttpStatusCode.BadRequest):
                        {
                            return false;
                        }
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return false;
            
        }

        public async Task<User> LogInAsync(string username, string password)
        {
            try
            {
                LoginDto user = new LoginDto(username, password);
                var jsonContent = JsonSerializer.Serialize(user, _serializerOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{URL}LogIn", content);

                switch (response.StatusCode)
                {
                    case (HttpStatusCode.OK):
                        {
                            jsonContent = await response.Content.ReadAsStringAsync();
                            User u = JsonSerializer.Deserialize<User>(jsonContent, _serializerOptions);
                            await Task.Delay(2000);
                            return u;
                                
                        }
                    case (HttpStatusCode.Conflict):
                        {
                            return null;
                        }
                    case (HttpStatusCode.BadRequest):
                        {
                            return null;
                        }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }


    }
}
