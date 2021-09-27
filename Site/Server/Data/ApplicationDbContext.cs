using Microsoft.EntityFrameworkCore;
using Site.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Site.Server.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions options)
            : base(options){
        }
        public DbSet<Tarefa> Tarefas { get; set; }        
    }
}