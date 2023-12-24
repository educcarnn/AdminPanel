using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MensagensController : ControllerBase
{
    private readonly MeuDbContext _context;

    public MensagensController(MeuDbContext context)
    {
        _context = context;
    }

    // Listar todas as mensagens
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var mensagens = await _context.Mensagens.ToListAsync();
        return Ok(mensagens);
    }

    // Criar uma nova mensagem
    [HttpPost]
  
    public async Task<IActionResult> Create([FromBody] Mensagem mensagem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(mensagem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = mensagem.Id }, mensagem);
        }
        return BadRequest(ModelState);
    }

    // Editar uma mensagem existente
    [HttpPut("{id}")]

    public async Task<IActionResult> Edit(int id, [FromBody] Mensagem mensagem)
    {
        if (id != mensagem.Id)
        {
            return BadRequest();
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
            return Ok(mensagem);
        }
        return BadRequest(ModelState);
    }

    // Excluir uma mensagem
    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        var mensagem = await _context.Mensagens.FindAsync(id);
        if (mensagem == null)
        {
            return NotFound();
        }

        _context.Mensagens.Remove(mensagem);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool MensagemExists(int id)
    {
        return _context.Mensagens.Any(e => e.Id == id);
    }
}