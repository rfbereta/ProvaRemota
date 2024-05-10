using Microsoft.AspNetCore.Mvc;
using ProvaRemota.Services;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaRemota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoClienteController : ControllerBase
    {
        private readonly ISituacaoClienteService _situacaoClienteService;


        public SituacaoClienteController(ISituacaoClienteService situacaoClienteService)
        {
            _situacaoClienteService = situacaoClienteService;
        }

        // GET: api/<SituacaoClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var situacaoClientesViewModel = await _situacaoClienteService.GetAllSituacaoCliente();
                if (situacaoClientesViewModel?.Count == 0 || situacaoClientesViewModel == null) return this.NoContent();

                return Ok(situacaoClientesViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar SituacaoCliente. Erro: {ex.Message}");
            }

        }

        // GET api/<SituacaoClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var situacaoClienteViewModel = await _situacaoClienteService.GetSituacaoClienteById(id);
                if (situacaoClienteViewModel == null) return this.NoContent();

                return Ok(situacaoClienteViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar SituacaoCliente. Erro: {ex.Message}");
            }


        }

        // POST api/<SituacaoClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SituacaoClienteViewModel situacaoClienteViewModel)
        {

            try
            {
                await _situacaoClienteService.Add(situacaoClienteViewModel);

                return Ok("SituacaoCliente adicionado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar SituacaoCliente. Erro: {ex.Message}");
            }
        }

        // PUT api/<SituacaoClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SituacaoClienteViewModel situacaoClienteViewModel)
        {
            try
            {
                var existeSituacaoCliente = await _situacaoClienteService.GetSituacaoClienteById(id);
                if (existeSituacaoCliente == null) return this.NoContent();

                await _situacaoClienteService.Update(id, situacaoClienteViewModel);
                return Ok("SituacaoCliente atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar SituacaoCliente. Erro: {ex.Message}");
            }
        }

        // DELETE api/<SituacaoClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existeSituacaoCliente = await _situacaoClienteService.GetSituacaoClienteById(id);
                if (existeSituacaoCliente == null) return this.NoContent();

                await _situacaoClienteService.Delete(id);

                return Ok("SituacaoCliente excluído com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar SituacaoCliente. Erro: {ex.Message}");
            }
        }
    }
}
