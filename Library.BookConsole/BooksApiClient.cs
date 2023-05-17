using Library.Books;
using Library.Models;
using Newtonsoft.Json;


namespace Library.BookConsole
{
    public class BooksApiClient
    {
       static readonly HttpClient client = new HttpClient();
       public static async Task GetBooks()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7119/api/Books");
                response.EnsureSuccessStatusCode();
                using HttpContent content = response.Content;
                string responseBody = await response.Content.ReadAsStringAsync();
                var bookss = JsonConvert.DeserializeObject<List<Book>>(responseBody);
                foreach (var emp in bookss)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", emp.Id, emp.Name, emp.Category, emp.Cover, emp.DatePublication, emp.AuthorId);
                }
                SaveFiles.books = JsonConvert.DeserializeObject<List<Book>>(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message : {0}", e.Message);
            }
        }
    }
}

