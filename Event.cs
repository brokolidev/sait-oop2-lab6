using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Event
    {
        // set properties of the Event class
        public int EventNumber { get; set; }
        public string Location { get; set; }

        // Default constructor
        public Event()
        {
            
        }

        // Overriding ToString method to print out instance information of this class
        public override string ToString()
        {
            return $"{EventNumber}\n" +
                $"{Location}";
        }
    }
}
