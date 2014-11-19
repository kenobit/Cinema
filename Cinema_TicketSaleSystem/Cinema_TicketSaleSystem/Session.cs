using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_TicketSaleSystem
{
    class Session
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_Film { get; set; }
        public int ID_Hall { get; set; }
        public string Time { get; set; }
    }
}