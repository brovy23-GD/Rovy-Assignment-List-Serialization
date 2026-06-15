\# Assignment 10.1 - Player Serialization



> A C# console application that demonstrates how to create a user-defined class and serialize/deserialize objects using \*\*JSON\*\* and \*\*XML\*\*.



\---



\## Overview



This project was created for \*\*Assignment 10.1\*\*.  

The goal was to build a user-defined class with 3 properties and show how its data can be serialized and deserialized in different formats.



In this project, I created a `Player` class and used a list of basketball players to demonstrate:

\- JSON serialization/deserialization

\- XML serialization/deserialization

\- File creation and reading in C#

\- Round-trip validation by printing the data back to the console



\---



\## Why this project matters



This assignment helped reinforce several important C# concepts:



\- Creating custom classes

\- Working with object collections

\- Using built-in serializers

\- Reading from and writing to files

\- Verifying that serialized data can be restored correctly



It also helped practice writing cleaner project documentation and presenting code in a more professional GitHub format.



\---



\## Tech Stack



\- \*\*Language:\*\* C#

\- \*\*Framework:\*\* .NET Console App

\- \*\*Serialization:\*\*

&#x20; - `System.Text.Json`

&#x20; - `System.Xml.Serialization`

\- \*\*IDE:\*\* Visual Studio

\- \*\*Version Control:\*\* Git / GitHub



\---



\## Project Structure



```text

Rovy Assignment List Serialization (Json \& XML)/

├── README.md

├── Program.cs

├── Player.cs

├── Rovy Assignment List Serialization (Json \& XML).csproj

└── Properties/

```



\---



\## Player Class



This project uses a custom `Player` class with 3 properties:



| Property | Type | Description |

|---|---|---|

| `Name` | `string` | Player's name |

| `Team` | `string` | Team the player belongs to |

| `PointsPerGame` | `float` | Average points scored per game |



Example:



```csharp

public class Player

{

&#x20;   public string Name { get; set; }

&#x20;   public string Team { get; set; }

&#x20;   public float PointsPerGame { get; set; }

}

```



\---



\## Program Workflow



```mermaid

flowchart TD

&#x20;   A\[Start Program] --> B\[Create C:\\\\Files directory]

&#x20;   B --> C\[Create List of Player objects]

&#x20;   C --> D\[Serialize list to JSON]

&#x20;   D --> E\[Deserialize JSON back into List<Player>]

&#x20;   E --> F\[Serialize list to XML]

&#x20;   F --> G\[Deserialize XML back into List<Player>]

&#x20;   G --> H\[Print player data to console]

&#x20;   H --> I\[Print raw XML content]

&#x20;   I --> J\[Wait for key press and exit]

```



\---



\## Serialization Flow



```mermaid

sequenceDiagram

&#x20;   participant Program

&#x20;   participant PlayerList as List<Player>

&#x20;   participant JSONFile as Players.json

&#x20;   participant XMLFile as Players.xml



&#x20;   Program->>PlayerList: Create hardcoded player objects

&#x20;   Program->>JSONFile: Serialize player list to JSON

&#x20;   JSONFile-->>Program: Read JSON file back

&#x20;   Program->>PlayerList: Deserialize JSON to objects

&#x20;   Program->>XMLFile: Serialize player list to XML

&#x20;   XMLFile-->>Program: Read XML file back

&#x20;   Program->>PlayerList: Deserialize XML to objects

&#x20;   Program->>Program: Print final results

```



\---



\## Whiteboard Explanation



If I had to explain this on a whiteboard, I would break it down like this:



\### Step 1: Create the data

First, I make a custom `Player` class with 3 properties:

\- Name

\- Team

\- PointsPerGame



Then I create a list of `Player` objects with sample data.



\### Step 2: Serialize the list

Serialization means taking objects in memory and converting them into a storable format.



In this program:

\- JSON serialization writes the player list into a `.json` file

\- XML serialization writes the player list into a `.xml` file



\### Step 3: Deserialize the list

Deserialization means reading the stored file and turning it back into C# objects.



So the program:

\- Reads the JSON file back into a `List<Player>`

\- Reads the XML file back into a `List<Player>`



\### Step 4: Verify the round trip

To prove everything worked:

\- The deserialized players are printed to the console

\- The raw XML content is also displayed



\### Simple whiteboard idea

Think of it like this:



```mermaid

flowchart LR

&#x20;   A\[Player Objects in Memory] --> B\[Convert to JSON/XML]

&#x20;   B --> C\[Save to File]

&#x20;   C --> D\[Read File Back]

&#x20;   D --> E\[Convert Back to Player Objects]

&#x20;   E --> F\[Print Results]

```



That is the full “round trip”:

\*\*object → file → object again\*\*



\---



\## How the JSON part works



The JSON section does this:



1\. Create the file path

2\. Open a file stream

3\. Serialize the `List<Player>` into the file

4\. Reset the stream position to the beginning

5\. Deserialize the file back into a `List<Player>`

6\. Print each player



\---



\## How the XML part works



The XML section does this:



1\. Create the file path

2\. Create an `XmlSerializer` for `List<Player>`

3\. Write the player list into the XML file

4\. Open the XML file again for reading

5\. Deserialize the XML back into a `List<Player>`

6\. Print each player

7\. Read the raw XML text and print it



\---



\## Example Console Output



```text

\--- JSON Serialization ---



List serialized to JSON. Reading it back...

Jalen Brunson - New York Knicks - 25.6

Victor Wembanyama - San Antonio Spurs - 22.3

Michael Jordan - Chicago Bulls - 33.4



\--- XML Serialization ---



List serialized to XML. Reading it back...

Jalen Brunson - New York Knicks - 25.6

Victor Wembanyama - San Antonio Spurs - 22.3

Michael Jordan - Chicago Bulls - 33.4



\--- Raw XML content ---

<?xml version="1.0"?>

<ArrayOfPlayer>

&#x20; ...

</ArrayOfPlayer>

```



\---



\## How to Run



1\. Open the project in \*\*Visual Studio\*\*

2\. Build the solution

3\. Run the program

4\. View console output

5\. Check the generated files in:



```text

C:\\Files

```



You should see:

\- `Players.json`

\- `Players.xml`



\---



\## Git Workflow



```mermaid

gitGraph

&#x20;  commit id: "Create console project"

&#x20;  commit id: "Add Player class"

&#x20;  commit id: "Add JSON serialization"

&#x20;  commit id: "Add XML serialization"

&#x20;  commit id: "Add README documentation"

```



\---



\## What I Learned



This project helped me get more comfortable with:



\- Creating user-defined classes

\- Working with lists of objects

\- Writing data to files

\- Reading data back into objects

\- Understanding the difference between JSON and XML

\- Explaining program flow step by step



\---



\## Future Improvements



Possible upgrades for this project:



\- Add user input instead of hardcoded players

\- Add error handling with `try/catch`

\- Store files in a relative folder instead of `C:\\Files`

\- Add menu options for choosing JSON or XML

\- Add more player statistics

\- Add unit tests



\---



\## Author



\*\*Bobby Rovy\*\*  

Army veteran transitioning into tech with a focus on backend development, cloud, security, and building strong C# fundamentals.



\---



