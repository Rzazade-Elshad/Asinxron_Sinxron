using System.Diagnostics;

namespace asinxron_sinxron;

public class Program
{
    static void Main(string[] args)
    {
        List<string> urls = new List<string>
        {
            "https://www.translate.com",
            "https://www.chatgpt.com",
            "https://www.github.com",
            "https://www.stackoverflow.com",
            "https://www.Barcelona.com"
        };
        GetData(urls).Wait();
    }
        static async Task GetData(List<string> urls)
        {
            using HttpClient client = new HttpClient(); 

            Stopwatch stopwatch = new Stopwatch(); 
            stopwatch.Start(); 

            foreach (string url in urls)
            {
                    HttpResponseMessage response = await client.GetAsync(url); 

                    if (response.IsSuccessStatusCode) 
                    {
                        Console.WriteLine($"Request sent  {url}");
                    }
                    else
                    {
                        Console.WriteLine($"Request failedd {url} - {response.StatusCode}");
                    }
            }

            stopwatch.Stop(); 
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }
    }