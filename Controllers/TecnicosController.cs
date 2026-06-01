using CopaApi.Models;
using CopaHAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TecnicosController : ControllerBase
    {
        private readonly DataContext _context;

        public TecnicosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Tecnico tecnico = await _context.TB_TECNICOS
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(tecnico);
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
                List<Tecnico> lista = await _context.TB_TECNICOS
                    .Include(t => t.SelecaoIdNavegacao)
                    .ToListAsync();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        //Próximos métodos aqui.
    }
}