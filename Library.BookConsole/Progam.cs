using Library.BookConsole;
using Library.Models;
using Newtonsoft.Json;

namespace Library.Books
{
    public class Progam
    {
        static async Task Main(string[] args)
        {
            await BooksApiClient.GetBooks();
            SaveFiles.SaveAsXML();
            SaveFiles.SaveAsCSV();
            SaveFiles.SaveAsJSON();
        }
    }
}