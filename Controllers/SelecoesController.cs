using CopaApi.Models;
using CopaHAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class SelecoesController : ControllerBase
{
    private readonly DataContext _context;

    public SelecoesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Selecao selecao = await _context.TB_SELECOES
                .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

            return Ok(selecao);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message + " - " + ex.InnerException);
        }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Selecao> lista = await _context.TB_SELECOES.ToListAsync();
            return Ok(lista);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message + " - " + ex.InnerException);
        }
    }

    // Próximos métodos aqui
}