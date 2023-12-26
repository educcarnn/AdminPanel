using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Models;

namespace AdminPanel.Data
{
    public class AdminPanelContext : DbContext
    {
        public AdminPanelContext (DbContextOptions<AdminPanelContext> options)
            : base(options)
        {
        }

        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Message> Message { get; set; }
    
        
    }
}
