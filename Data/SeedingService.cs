using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Models;
using AdminPanel.Models.Enums;

namespace AdminPanel.Data
{
    public class SeedingService
    {
        private AdminPanelContext _context;

        public SeedingService(AdminPanelContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Tipo.Any() || _context.Message.Any())
            {
                return;
            }

            Tipo d1 = new Tipo(1, "Mensagem");
            Tipo d2 = new Tipo(2, "Lembrete");
            Tipo d3 = new Tipo(3, "Aviso");
            Tipo d4 = new Tipo(4, "Citação");





            _context.Tipo.AddRange(d1, d2, d3, d4);


            _context.SaveChanges();
        }
    }
}
