using System;
using System.IO;

//using System.Text.Json;
//using System.Text.Json.Serialization;

using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace ResponseJsonToOpenApi
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                using (StreamReader sr = new StreamReader("/Users/tamurar/Projects/ResponseJsonToOpenApi/ResponseJsonToOpenApi/TestFile.json"))
                {
                    string allLine = sr.ReadToEnd();
                    using dynamic document = System.Text.Json.JsonDocument.Parse(allLine);


                    Console.WriteLine(document.RootElement.ValueKind);
                    Console.WriteLine(JsonValueKind.Object);

                    foreach(JsonProperty prop in document.RootElement.EnumerateObject())
                    {
                        Console.Write($"{prop.Name}");
                        string propName = prop.Name;
                        var property = document.RootElement.GetProperty(propName);
                        Console.Write(property);
                        if (property.ValueKind == JsonValueKind.Object)
                        {
                            Console.Write("it's object !!!");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
