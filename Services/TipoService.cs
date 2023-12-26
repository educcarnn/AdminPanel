using AdminPanel.Data;
using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Services
{
    public class TipoService
    {
        private readonly AdminPanelContext _context;

        public TipoService(AdminPanelContext context)
        {
            _context = context;
        }

        public async Task<List<Tipo>> FindAllAsync()
        {
            return await _context.Tipo.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
