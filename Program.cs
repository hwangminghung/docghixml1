using System;
using System.IO;
using System.Xml.Serialization;

public class Book
{
    public string Title { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Ghi đối tượng Book vào file XML
        Book bookToWrite = new Book { Title = "Harry Potter", Price = 19.99m };
        string filePath = "book.xml";
        WriteBookToXml(bookToWrite, filePath);
        Console.WriteLine("Đã ghi đối tượng Book vào file XML.");

        // Đọc đối tượng Book từ file XML
        Book bookToRead = ReadBookFromXml(filePath);
        Console.WriteLine($"Đã đọc đối tượng Book từ file XML: Title = {bookToRead.Title}, Price = {bookToRead.Price}");
    }

    public static void WriteBookToXml(Book book, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Book));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, book);
        }
    }

    public static Book ReadBookFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Book));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (Book)serializer.Deserialize(reader);
        }
    }
}