using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWebChat.MVC.Models
{
    public class ChatBotModel
    {
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool Continental { get; set; }
        public bool Wintery { get; set; }
        public bool Mediterranean { get; set; }
        public bool Tropical { get; set; }

    }

}
