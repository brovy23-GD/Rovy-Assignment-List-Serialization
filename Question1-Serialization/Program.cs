using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;            // JSON serializer
using System.Xml.Serialization;    // XML serializerConsole.WriteLine("Hello, World!");

namespace Rovy_Assignment_List_Serialization__Json___XML_
{
    internal class Program // Main class of the program
    {

        static void Main(string[] args) // Main method to execute the program
        {

            Directory.CreateDirectory(@"C:\Files");// Create a directory to store the files if it doesn't exist


            var Players = new List<Player> // Build hardcode list of players

            {
                new Player { Name = "Jalen Brunson", Team = "New York Knicks", PointsPerGame = 25.6f },
                new Player { Name = "Victor Wembanyama", Team = "San Antonio Spurs", PointsPerGame = 22.3f },
                new Player { Name = "Michael Jordan", Team = "Chicago Bulls", PointsPerGame = 33.4f }

            };

            //JSON Serialization

            Console.WriteLine("\n--- JSON Serialization ---\n");

            var jsonPath = @"C:\Files\Players.json"; // Define the path for the JSON file
            if (File.Exists(jsonPath)) File.Delete(jsonPath); // Start with clean file

            // Create a FileStream to write the JSON data to the file
            var jsonFs = new FileStream(jsonPath, FileMode.CreateNew, FileAccess.ReadWrite);


            // Serialize the Whole list to JSON format and write it to the file
            JsonSerializer.Serialize(jsonFs, Players); // Serialize the list of players to JSON format and write it to the file

            // Inform the user that the list has been serialized to JSON and is being reading it back
            Console.WriteLine("list serialzied to JSON. Reading it back...");

            // Reset to start of the file to read the data back
            jsonFs.Position = 0;

            // Deserialize the JSON data from the file back into a list of Player objects
            var jsonResult = JsonSerializer.Deserialize<List<Player>>(jsonFs);
            jsonFs.Close();

            //Print easch player to prove round trip was successful
            foreach (var p in jsonResult)
            {
                Console.WriteLine($"{p.Name} - {p.Team} - {p.PointsPerGame} ");
            }

            //XML Serialization
            Console.WriteLine("\n--- XML Serialization ---\n");

            var xmlPath = @"C:\Files\Players.xml"; // Define the path for the XML file
            if (File.Exists(xmlPath)) File.Delete(xmlPath); // Start with clean file)

            // Declare the serialzier before you use it to read and write the XML data
            var xmlSerializer = new XmlSerializer(typeof(List<Player>));

            //Write the XML data to the file
            using (var xmlWrite = new FileStream(xmlPath, FileMode.CreateNew, FileAccess.Write))
            {
                // Serialize the list of players to XML format and write it to the file
                xmlSerializer.Serialize(xmlWrite, Players);
            }
            // Inform the user that the list has been serialized to XML and is being read back
            Console.WriteLine("List serialized to XML. Reading it back...");

            //Read XML 
            using (var xmlRead = new FileStream(xmlPath, FileMode.Open, FileAccess.Read))
            {
                // Deserialize the XML data from the file back into a list of Player objects
                var xmlResult = (List<Player>)xmlSerializer.Deserialize(xmlRead);


                //Print each player to prove round trip was successful
                foreach (var p in xmlResult)
                {
                    Console.WriteLine($"{p.Name} - {p.Team} - {p.PointsPerGame} ");
                }
            }
            // Read the raw XML content as text and print it to the console
            string xmlText = File.ReadAllText(xmlPath);
            Console.WriteLine("\n--- Raw XML content ---\n");
            Console.WriteLine(xmlText);


            //Wait for user input before closing the console
            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();



        }



    }

}














    

























