using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FoundIt.Models;
using Org.Apache.Http.Protocol;

namespace FoundIt.Services
{
    public class FoundItService
    {
        readonly HttpClient _httpClient;
        readonly JsonSerializerOptions _serializerOptions;
        static string URL = DeviceInfo.Platform == DevicePlatform.Android ? @"http://10.0.2.2:5062/FoundItController" : @"http://localhost:5062";
        static string IMAGE_URL = DeviceInfo.Platform == DevicePlatform.Android ? @"http://10.0.2.2.5062":@"http://localhost:5062";
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
        public async Task<List<PostStatus>> GetPostStatus()
        {
            //TODO use httpget

            //Dummy - To be deleted when added httpclient method
            await Task.Delay(1000);
            List<PostStatus> postStatuses = new List<PostStatus>();
            postStatuses.Add(new PostStatus() { Id = 1, PostStatusName = "Waiting For approval" }); 
            postStatuses.Add(new PostStatus() { Id = 2, PostStatusName = "Not Found Yet" });

            postStatuses.Add(new PostStatus() { Id = 3, PostStatusName = "Verification" });

            postStatuses.Add(new PostStatus() { Id = 4, PostStatusName = "Found" });
           return postStatuses;
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

       
             public async Task<bool> CreateNewPostAsync(Post post)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(post, _serializerOptions);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{URL}Register", content);

                switch (response.StatusCode)
                {
                    case (HttpStatusCode.OK):
                        {
                            jsonContent = await response.Content.ReadAsStringAsync();
                           Post p = JsonSerializer.Deserialize<Post>(jsonContent, _serializerOptions);
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


        public async Task<string> GetImage() { return $"{IMAGE_URL}images/"; }


        public async Task<bool> UploadFile(FileResult file)
        {

            try
            {
                //קובץ הוא לא מחלקה...
                //נדרש להמיר אותו למערך של בייטים על מנת שיוכל לעבור ברשת
                byte[] bytes;

                #region המרה של הקובץ
                using (MemoryStream ms = new MemoryStream())
                {
                    //קריאה את אוסף הנתונים בקובץ
                    var stream = await file.OpenReadAsync();
                    //העתקת רצף הבייטים למקום זמני בזיכרון
                    stream.CopyTo(ms);
                    //המרה למערך
                    bytes = ms.ToArray();
                }
                #endregion

                //אובייקט המאפשר לשמור אוסף של קבצים שנוכל לצרף אותו לבקשה לשרת
                var multipartFormDataContent = new MultipartFormDataContent();

                //תוכן של בקשה המבוסס על מערך בתים
                //פרמטר הראשון הוא התוכן
                //פרמטר השני - זהה לשם הפרמטר של הפרמטר כפי שמופיע בחתימת הפעולה בשרת
                //הפרמטר השלישי הוא שם הקובץ עצמו
                var content = new ByteArrayContent(bytes);
                multipartFormDataContent.Add(content, "file", "robot.jpg");
                //ניתן לחזור על הפעולה אם נרצה קובץ נוסף או במקרה הזה
                //אובייקט
               /*TODO*/ var userContent = JsonSerializer.Serialize(new User() { Id = 1, Email = "kuku@kuku.com", FirstName = "kuku", LastName = "kiki", Pasword = "1234" }, _serializerOptions);
                //הפרמטר הראשון הוא התוכן
                //הפרמטר השני זה שם הפרמטר כפי שמופיע בחתימת הפעולה בשרת
                multipartFormDataContent.Add(new StringContent(userContent, Encoding.UTF8, "application/json"), "user");

                // Send POST request
                var response = await _httpClient.PostAsync($@"{URL}UploadFile", multipartFormDataContent);
                if (response.IsSuccessStatusCode) { return true; }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }

}
    

