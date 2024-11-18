using Lab5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab5.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
}