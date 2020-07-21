using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace help.DbFolder
{
    public class Help
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }
        public string Title { get; set; }

        public string UserName { get; set; }

        public string Info { get; set; }

        public string PhoneNumber { get; set; }

        public bool WhatsApp { get; set; } = false;

        public bool Telegram { get; set; } = false;


        public int CityId { get; set; }
        public City City { get; set; }
    }
}
