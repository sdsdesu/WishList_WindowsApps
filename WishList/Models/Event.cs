using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    class Event
    {
        //Variable declaration with getters and setters
        private int EventId { get; set; }               //Id of event
        private string Name { get; set; }               //name of event
        private string Description { get; set; }        //text description of evente
        private DateTime Deadline { get; set; }         //deadline of event, when it takes place, maybe allow for days before so everything is in order before the deadline

        //Constructors
        public Event(string name, string description, DateTime deadline)
        {
            Name = name;
            Description = description;
            Deadline = deadline;
        }


    }
}
