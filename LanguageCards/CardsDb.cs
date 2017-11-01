using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCards
{
    public class CardsDb : DbContext
    {
        public DbSet<Card> Cards { get; set; }
    }
}
