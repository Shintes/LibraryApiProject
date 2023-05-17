using Library.Models;
using Newtonsoft.Json;

namespace Library.Books
{
    public class SaveFiles
    {
        public static List<Book> books = new List<Book>();

        public static void SaveAsXML()
        {
            const string xmlFilename = "Books.xml";
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
            using var file = new StreamWriter(xmlFilename);
            writer.Serialize(file, books);
        }
        public static void SaveAsJSON()
        {
            const string jsonFilename = "Books.json";
            string jsonRepresentation = JsonConvert.SerializeObject(books);
            File.WriteAllText(jsonFilename, jsonRepresentation);
        }
        public static void SaveAsCSV()
        {
            const string csvFilename = "Books.csv";
            var csvFile = new List<string>();
            foreach (Book book in books)
            {
                csvFile.Add(string.Format("{0},{1},{2},{3},{4}",
                    book.Name, book.Category, book.Cover,
                    book.DatePublication, book.AuthorId));
            }
            File.WriteAllLines(csvFilename, csvFile);
        }
    }
}
