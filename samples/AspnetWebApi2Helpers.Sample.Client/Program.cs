using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using AspnetWebApi2Helpers.Sample.Entities;
using AspnetWebApi2Helpers.Serialization;

namespace AspnetWebApi2Helpers.Sample.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Retrieve entities with cyclical references.");
            Console.WriteLine("Use Fiddler? {Y/N}");
            bool useFiddler = Console.ReadLine().ToUpper() == "Y";

            string fiddlerSuffix = useFiddler ? ".fiddler" : string.Empty;
            string address = string.Format("http://localhost{0}:2266/api/", fiddlerSuffix);

            MediaTypeFormatter formatter;
            string acceptHeader;

            while (GetFormatter(out formatter, out acceptHeader))
            {
                var client = new HttpClient { BaseAddress = new Uri(address) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));
                GetCategories(client, formatter);
                GetProducts(client, formatter);
            }
        }

        private static bool GetFormatter(out MediaTypeFormatter formatter, out string acceptHeader)
        {
            Console.WriteLine("\nSelect a formatter: Json {J}, Xml {X}, Protobuf {P}, or exit {Enter}");
            string selection = Console.ReadLine().ToUpper();

            if (selection == "J")
            {
                var jsonFormatter = new JsonMediaTypeFormatter();
                jsonFormatter.JsonPreserveReferences();
                formatter = jsonFormatter;
                acceptHeader = MediaTypes.Json;
            }
            else if (selection == "X")
            {
                var xmlFormatter = new XmlMediaTypeFormatter();
                xmlFormatter.XmlPreserveReferences(typeof(Category).Assembly.GetTypes());
                formatter = xmlFormatter;
                acceptHeader = MediaTypes.Xml;
            }
            //else if (selection == "P")
            //{
            //    var protoFormatter = new ProtoBufFormatter();
            //    protoFormatter.ProtobufPreserveReferences(typeof(Category).Assembly);
            //    formatter = protoFormatter;
            //    acceptHeader = MediaTypes.Protobuf;
            //}
            else
            {
                formatter = null;
                acceptHeader = null;
                return false;
            }
            return true;
        }

        private static void GetProducts(HttpClient client, MediaTypeFormatter formatter)
        {
            // Get products
            var productsResponse = client.GetAsync("products").Result;
            productsResponse.EnsureSuccessStatusCode();

            // Read categories
            var products = productsResponse.Content.ReadAsAsync<List<Product>>(new[] { formatter }).Result;
            foreach (var p in products)
            {
                Console.WriteLine("{0} {1}, Category {2}: {3}",
                    p.ProductId,
                    p.ProductName,
                    p.CategoryId,
                    p.Category.CategoryName);
            }
        }

        private static void GetCategories(HttpClient client, MediaTypeFormatter formatter)
        {
            // Get categories
            var categoriesResponse = client.GetAsync("categories").Result;
            categoriesResponse.EnsureSuccessStatusCode();

            // Read categories
            var categories = categoriesResponse.Content.ReadAsAsync<List<Category>>(new[] { formatter }).Result;
            foreach (var c in categories)
            {
                Console.WriteLine("{0} {1}, {2} Products",
                    c.CategoryId,
                    c.CategoryName,
                    c.Products.Count);
            }
            Console.WriteLine();
        }
    }
}
