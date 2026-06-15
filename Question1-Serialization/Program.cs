using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Question1_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Make sure the output folder exists.
            //    For this assignment, all files are stored in C:\Files.
            string folderPath = @"C:\Files";

            // If C:\Files does not exist yet, create it.
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Created directory: {folderPath}");
            }

            // 2. Create a list of Player objects with sample data.
            //    This is our in-memory data that we want to serialize.
            var players = new List<Player>
            {
                new Player { Name = "Jalen Brunson",      Team = "New York Knicks",    PointsPerGame = 25.6f },
                new Player { Name = "Victor Wembanyama", Team = "San Antonio Spurs",  PointsPerGame = 22.3f },
                new Player { Name = "Michael Jordan",    Team = "Chicago Bulls",      PointsPerGame = 33.4f }
            };

            // Build full file paths for the JSON and XML files.
            string jsonPath = Path.Combine(folderPath, "Players.json");
            string xmlPath  = Path.Combine(folderPath, "Players.xml");

            //
            // --- JSON SERIALIZATION + DESERIALIZATION ---
            //

            Console.WriteLine("--- JSON Serialization ---\n");

            // 3. Serialize the list of players to JSON and write it to Players.json.
            //    File.WriteAllText is a quick way to write a full string to a file.
            string jsonString = JsonSerializer.Serialize(players, new JsonSerializerOptions
            {
                WriteIndented = true // makes the JSON easier to read
            });
            File.WriteAllText(jsonPath, jsonString);

            Console.WriteLine("List serialized to JSON. Reading it back...\n");

            // 4. Read the JSON back from the file and deserialize into a new List<Player>.
            string jsonFromFile = File.ReadAllText(jsonPath);

            // Deserialize can return null if something goes wrong,
            // so we use the null-coalescing operator ?? to fall back to an empty list.
            List<Player>? playersFromJson = JsonSerializer.Deserialize<List<Player>>(jsonFromFile)
                                            ?? new List<Player>();

            // 5. Print the players that came from the JSON file.
            foreach (var p in playersFromJson)
            {
                Console.WriteLine($"{p.Name} - {p.Team} - {p.PointsPerGame}");
            }

            Console.WriteLine();

            //
            // --- XML SERIALIZATION + DESERIALIZATION ---
            //

            Console.WriteLine("--- XML Serialization ---\n");

            // 6. Create an XmlSerializer that knows how to handle List<Player>.
            var xmlSerializer = new XmlSerializer(typeof(List<Player>));

            // 7. Serialize the list of players to XML and write it to Players.xml.
            using (var xmlStream = new FileStream(xmlPath, FileMode.Create))
            {
                xmlSerializer.Serialize(xmlStream, players);
            }

            Console.WriteLine("List serialized to XML. Reading it back...\n");

            // 8. Read the XML file back in and deserialize into another List<Player>.
            List<Player> playersFromXml;
            using (var xmlStream = new FileStream(xmlPath, FileMode.Open))
            {
                // XmlSerializer.Deserialize returns object, so we cast it back to List<Player>.
                playersFromXml = (List<Player>)xmlSerializer.Deserialize(xmlStream);
            }

            // 9. Print the players that came from the XML file.
            foreach (var p in playersFromXml)
            {
                Console.WriteLine($"{p.Name} - {p.Team} - {p.PointsPerGame}");
            }

            //
            // --- SHOW RAW XML CONTENT ---
            //

            Console.WriteLine("\n--- Raw XML content ---");

            // 10. Read the raw XML text just to show what the file looks like.
            string xmlText = File.ReadAllText(xmlPath);
            Console.WriteLine(xmlText);

            //
            // --- FINISH ---
            //

            // 11. Pause the console so the user can see the output
            //     before the window closes.
            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }
    }

    // Player class is defined in a separate file (Player.cs) in the project:
    //
    // public class Player
    // {
    //     public string Name { get; set; }
    //     public string Team { get; set; }
    //     public float PointsPerGame { get; set; }
    // }
}