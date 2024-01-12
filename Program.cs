using CRUD.ConsoleApplication;
using CRUD.ConsoleApplication.Models;

public class Program
{
    private static HttpClient client;
    public static void Main(string[] args)
    {
        client = new HttpClient()
        {
            BaseAddress = new Uri($"https://jsonplaceholder.typicode.com/")
        };
        ApiServise apiService = new ApiServise();

        #region Ger Response
        var res = apiService.GetReposAsync(client, "coments").Result;
        if (res == "Error ex")
        {
            Console.WriteLine(res);
        }
        else
        {
            Console.WriteLine(res);
        }

        #endregion

        Address address = new Address();
        apiService.PutAsync(client).Wait();


    }
}