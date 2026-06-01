using CopaApi.Models;
using CopaHAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoSelecoesController : ControllerBase
    {
        private readonly DataContext _context;

        public JogoSelecoesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{jogoId}/{selecaoId}")]
        public async Task<IActionResult> GetSingle(int jogoId, int selecaoId)
        {
            try
            {
                JogoSelecao jogoSelecao = await _context.TB_JOGOS_SELECOES
                    .FirstOrDefaultAsync(eBusca =>
                        eBusca.JogoId == jogoId &&
                        eBusca.SelecaoId == selecaoId);

                return Ok(jogoSelecao);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        //Próximos métodos aqui.
    }
}