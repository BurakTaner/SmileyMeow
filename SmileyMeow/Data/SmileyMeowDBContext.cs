using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmileyMeow.DBContext
{
    public class SmileyMeowDBContext : DbContext
    {
        public SmileyMeowDBContext(DbContextOptions<SmileyMeowDBContext> options) : base(options)
        {}

    }
}