using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUD.ConsoleApplication
{
    public class ApiServise
    {
        public ApiServise()
        {

        }
        public async Task<string> GetReposAsync(HttpClient client, string endpoint)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return result;

            }
            catch (HttpRequestException ex)
            {
                return $"Error {nameof(ex)}";
            }

        }

        public async Task PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 77,
                    id = 1,
                    title = "write code sample",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "todos",
                jsonContent);

            var r = response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{r}\n");
        }


        public async Task PutAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 1,
                    id = 1,
                    title = "foo bar",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PutAsync(
                "todos/3",
                jsonContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }


        public async Task MyPutAsync(HttpClient client)
        {
            var content = new StringContent
                (
                    JsonSerializer.Serialize(new
                    {
                        userId = 1,
                        id = 1,
                        title = "foo bar",
                        completed = false
                    }),
                    Encoding.UTF8,
                    "application/json"
                );
            var responce = client.PutAsync("todos/2", content).Result;

            Console.WriteLine(responce.EnsureSuccessStatusCode());

        }


        public static async Task<string> MyPatchAsync(HttpClient client)
        {
            using StringContent jsonContent = new
            (
                JsonSerializer.Serialize(new
                {
                    title = "Patch example run",
                }),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PatchAsync("todos/1", jsonContent);

            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }


        public static async ValueTask<string> MyClientDeleteAsync(HttpClient client)
        {
            HttpResponseMessage response = await client.DeleteAsync("todos/1");

            string jsonResult = await response.Content.ReadAsStringAsync();

            return jsonResult;
        }
    }
}



