using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    //Can't you just give the WishList a Description and a deathline;  Wishlist.Title = event.Name   
    public class Event
    {
        //Variable declaration with getters and setters
        public int EventId { get; set; }               //Id of event
        public string Name { get; set; }               //name of event
        public string Description { get; set; }        //text description of evente
        public DateTime Deadline { get; set; }         //deadline of event, when it takes place, maybe allow for days before so everything is in order before the deadline

        //Constructors
        public Event(string name, string description, DateTime deadline)
        {
            Name = name;
            Description = description;
            Deadline = deadline;
        }


    }
}
