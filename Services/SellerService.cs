using Microsoft.EntityFrameworkCore;
using AdminPanel.Data;
using AdminPanel.Models;
using AdminPanel.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Services
{
    public class MessageService
    {
        private readonly AdminPanelContext _context;

        public MessageService(AdminPanelContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> FindAllAsync()
        {
            return await _context.Message.ToListAsync();
        }

        public async Task InsertAsync(Message obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Message> FindByIdAsync(int id)
        {
            return await _context.Message.Include(obj => obj.Tipo).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Message.FindAsync(id);
                _context.Message.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete message because he/she has sales");
            }
        }

        public async Task UpdateAsync(Message obj)
        {
            bool hasAny = await _context.Message.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
