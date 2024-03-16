using System.IO;
using System.Text;
using System.Text.Json;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating new event object
            Event newEvent = new Event()
            {
                EventNumber = 1,
                Location = "Calgary",
            };

            // figuring out root directory
            string rootPath = Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // set the file name with full path
            string txtPath = $"{rootPath}/event.txt";

            // serialize newEvent object
            string serializedEvent = JsonSerializer.Serialize(newEvent);
            // write it to a file
            File.WriteAllText(txtPath, serializedEvent);


            // deserialize json object from the file
            string serializedEventFromFile = File.ReadAllText(txtPath);
            Event deserializedEvent = JsonSerializer.Deserialize<Event>(serializedEventFromFile);

            // print out information of deserialized event object
            Console.WriteLine(deserializedEvent);


            // create a list that contains 4 event objects
            List<Event> events = [new Event()
            {
                EventNumber = 1,
                Location = "Calgary",
            },
            new Event()
            {
                EventNumber = 2,
                Location = "Vancouver",
            },
            new Event()
            {
                EventNumber = 3,
                Location = "Toronto",
            },
            new Event()
            {
                EventNumber = 4,
                Location = "Edmonton",
            }];


            // serialize events list itself
            string serializedEventsList = JsonSerializer.Serialize(events);

            // set the json file path
            string jsonPath = $"{rootPath}/events.json";
            File.WriteAllText(jsonPath, serializedEventsList);

            // get text from the event.json
            string jsonObject = File.ReadAllText(jsonPath);
            List<Event> eventsFromJson = JsonSerializer.Deserialize<List<Event>>(jsonObject);

            // print out parsed events list
            Console.WriteLine("Tech Competition");
            foreach (var item in eventsFromJson)
            {
                Console.WriteLine($"{item.EventNumber} {item.Location}");
            }

            // set a path to save file
            string filePath = $"{rootPath}/hackaton.txt";

            // call ReadFromFile function
            ReadFromFile(filePath);
        }

        public static void ReadFromFile(string filePath)
        {
            string targetWord = "Hackathon";
            // use stream writer to write text into a file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(targetWord);
            }

            // use file stream to get contents from saved file
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine($"In Word: {targetWord}");
                
                // Read from the beginning
                Console.Write($"The First Character is: {(char)fs.ReadByte()}\n");

                // change position to middle
                fs.Seek((fs.Length / 2) - 1, SeekOrigin.Begin);
                Console.Write($"The Middle Character is: {(char)fs.ReadByte()}\n");

                // change position to the last
                fs.Seek(-3, SeekOrigin.End);
                Console.Write($"The Last Character is: {(char)fs.ReadByte()}");
            }


        }
    }
}
