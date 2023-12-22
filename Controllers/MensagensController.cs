using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class MensagensController : Controller
{
    private readonly MeuDbContext _context;

    public MensagensController(MeuDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var mensagens = await _context.Mensagens.ToListAsync();
        return View(mensagens);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Conteudo")] Mensagem mensagem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(mensagem);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mensagem = await _context.Mensagens.FindAsync(id);
        if (mensagem == null)
        {
            return NotFound();
        }
        return View(mensagem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Conteudo")] Mensagem mensagem)
    {
        if (id != mensagem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(mensagem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensagemExists(mensagem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(mensagem);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mensagem = await _context.Mensagens
            .FirstOrDefaultAsync(m => m.Id == id);
        if (mensagem == null)
        {
            return NotFound();
        }

        return View(mensagem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var mensagem = await _context.Mensagens.FindAsync(id);
        _context.Mensagens.Remove(mensagem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MensagemExists(int id)
    {
        return _context.Mensagens.Any(e => e.Id == id);
    }
}