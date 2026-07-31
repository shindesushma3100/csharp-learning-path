using System .Net.Http;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting API Call...");
        Console.WriteLine("Meanwhile , this  line prints immediately,without waiting.");

        string result =await FetchDataAsync();

        Console.WriteLine("\n API call finished. First 200 characters of response:");
        Console.WriteLine(result.Substring(0, Math.Min(200,result.Length)));
    }
    static async Task<string> FetchDataAsync()
    {
        using HttpClient client =new  HttpClient();
        string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
        return response;
    }
}