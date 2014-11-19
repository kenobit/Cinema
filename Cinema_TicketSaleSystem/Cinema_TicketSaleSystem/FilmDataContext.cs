using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_TicketSaleSystem
{
    class FilmDataContext:DbContext
    {
        public FilmDataContext() : base("DBCinema") { }
        public DbSet<Film> Films { get; set; }
    }
}
