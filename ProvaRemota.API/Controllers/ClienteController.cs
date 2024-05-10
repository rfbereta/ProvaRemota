using Microsoft.AspNetCore.Mvc;
using ProvaRemota.Services;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaRemota.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;


        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }



        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var clientesViewModel = await _clienteService.GetAllCliente();
                if (clientesViewModel?.Count == 0) return this.NoContent();

                return Ok(clientesViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }

        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var clienteViewModel = await _clienteService.GetClienteById(id);
                if (clienteViewModel == null) return this.NoContent();

                return Ok(clienteViewModel);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }


        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel clienteViewModel)
        {

            try
            {
                await _clienteService.Add(clienteViewModel);

                return Ok("Cliente adicionado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar cliente. Erro: {ex.Message}");
            }


        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteViewModel clienteViewModel)
        {

            try
            {
                var existeCliente = await _clienteService.GetClienteById(id);
                if (existeCliente == null) return this.NoContent();


                await _clienteService.Update(id, clienteViewModel);
                return Ok("Cliente atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar cliente. Erro: {ex.Message}");
            }


        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existeCliente = await _clienteService.GetClienteById(id);
                if (existeCliente == null) return this.NoContent();

                await _clienteService.Delete(id);

                return Ok("Cliente excluído com sucesso!");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }



        }
    }
}
