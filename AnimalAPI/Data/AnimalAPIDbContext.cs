using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Data;

public class AnimalAPIDbContext : DbContext
{
    public AnimalAPIDbContext(DbContextOptions<AnimalAPIDbContext> options) : base(options)
    {
    }
}
