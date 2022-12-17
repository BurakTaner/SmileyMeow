using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmileyMeow.Data;
public class SmileyMeowDbContext : DbContext
{
    public SmileyMeowDbContext(DbContextOptions<SmileyMeowDbContext> options) : base(options)
    { }

}
