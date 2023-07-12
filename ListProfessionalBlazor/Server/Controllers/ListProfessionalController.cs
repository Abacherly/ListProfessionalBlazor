using ListProfessionalBlazor.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListProfessionalBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListProfessionalController : ControllerBase
{
    private readonly DataContext _context;

    public ListProfessionalController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ListProfessional>>> GetListProfessionals()
    {
        var professionals = await _context.ListProfessionals.Include(sh => sh.Work).ToListAsync();
        return Ok(professionals);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ListProfessional>> GetSingleProfessional(int id)
    {
        var professional = await _context.ListProfessionals
            .Include(h => h.Work)
            .FirstOrDefaultAsync(h => h.Id == id);
        if (professional == null)
        {
            return NotFound("Sem profissionais por aqui. :/");
        }
        return Ok(professional);
    }

    [HttpGet("works")]
    public async Task<ActionResult<Work>> GetWorks()
    {
        var works = await _context.Works.ToListAsync();
        return Ok(works);
    }

    [HttpPost]
    public async Task<ActionResult<ListProfessional>> CreateProfessional(ListProfessional professional)
    {
        professional.Work = null;
        _context.ListProfessionals.Add(professional);
        await _context.SaveChangesAsync();
        return Ok(await GetDbProfessionals());

    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ListProfessional>> UpdateProfessional(ListProfessional professional, int id)
    {
        var dbProfessional = await _context.ListProfessionals
          .Include(sh => sh.Work)
          .FirstOrDefaultAsync(sh => sh.Id == id);
        if (dbProfessional == null)
            return NotFound("Desculpe, profissional não encontrado.");
        dbProfessional.Name = professional.Name;
        dbProfessional.Position = professional.Position;
        dbProfessional.Years = professional.Years;
        dbProfessional.WorkId = professional.WorkId;
       
          await _context.SaveChangesAsync();
        return Ok(await GetDbProfessionals());
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ListProfessional>> DeleteProfessional(int id)
    {
        var dbProfessional = await _context.ListProfessionals
          .Include(sh => sh.Work)
          .FirstOrDefaultAsync(sh => sh.Id == id);

        if (dbProfessional == null)
            return NotFound("Desculpe, profissional não encontrado.");

        _context.ListProfessionals.Remove(dbProfessional);
        await _context.SaveChangesAsync();
        return Ok(await GetDbProfessionals());
    }

    private async Task<List<ListProfessional>> GetDbProfessionals()
    {
        return await _context.ListProfessionals.Include(sh => sh.Work).ToListAsync();
    }
} 
