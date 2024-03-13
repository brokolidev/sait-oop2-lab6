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


        }
    }
}
