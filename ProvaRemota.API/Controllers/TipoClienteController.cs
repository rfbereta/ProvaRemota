using Microsoft.AspNetCore.Mvc;
using ProvaRemota.Services;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaRemota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoClienteController : ControllerBase
    {
        private readonly ITipoClienteService _tipoClienteService;


        public TipoClienteController(ITipoClienteService tipoClienteService)
        {
            _tipoClienteService = tipoClienteService;
        }

        // GET: api/<TipoClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var tipoClientesViewModel = await _tipoClienteService.GetAllTipoCliente();
                if (tipoClientesViewModel?.Count == 0) return this.NoContent();

                return Ok(tipoClientesViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar TipoCliente. Erro: {ex.Message}");
            }

        }

        // GET api/<TipoClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tipoClienteViewModel = await _tipoClienteService.GetTipoClienteById(id);
                if (tipoClienteViewModel == null) return this.NoContent();

                return Ok(tipoClienteViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar TipoCliente. Erro: {ex.Message}");
            }


        }

        // POST api/<TipoClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoClienteViewModel tipoClienteViewModel)
        {

            try
            {
                await _tipoClienteService.Add(tipoClienteViewModel);

                return Ok("TipoCliente adicionado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar TipoCliente. Erro: {ex.Message}");
            }
        }

        // PUT api/<TipoClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoClienteViewModel tipoClienteViewModel)
        {
            try
            {
                var existeTipoCliente = await _tipoClienteService.GetTipoClienteById(id);
                if (existeTipoCliente == null) return this.NoContent();

                await _tipoClienteService.Update(id, tipoClienteViewModel);
                return Ok("TipoCliente atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar TipoCliente. Erro: {ex.Message}");
            }
        }

        // DELETE api/<TipoClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existeTipoCliente = await _tipoClienteService.GetTipoClienteById(id);
                if (existeTipoCliente == null) return this.NoContent();

                await _tipoClienteService.Delete(id);

                return Ok("TipoCliente excluído com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar TipoCliente. Erro: {ex.Message}");
            }
        }
    }
}
