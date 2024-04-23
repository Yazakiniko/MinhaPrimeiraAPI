using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Infraestrutura;
using MinhaAPI.Model;
using MinhaAPI.ViewModel;
using System.Net;

namespace MinhaAPI.Controllers
{

    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _UsuarioRepositorio;

        public UsuarioController(IUsuario usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio ?? throw new ArgumentNullException(nameof(UsuarioRepositorio));
        }

        [HttpPost]
        public IActionResult Add(UsuarioViewModel usuarioView)
        {

            Usuario usuario = new Usuario(usuarioView.Numero_CPF,
                                      usuarioView.Nome_Completo,
                                      usuarioView.Email,
                                      usuarioView.Celular,
                                      usuarioView.Cargo,
                                      usuarioView.Data_Cadastro,
                                      usuarioView.Status);

            _UsuarioRepositorio.Add(usuario);

            return Created();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _UsuarioRepositorio.Get();

            return Ok(usuarios);
        }

        [HttpPut("{Numero_CPF}")]
        public async Task<IActionResult> Put(string Numero_CPF, UsuarioViewModel usuarioView)
        {
            Usuario usuarioToUpdate = _UsuarioRepositorio.getUsuarioByCPF(Numero_CPF);
            if (usuarioToUpdate == null || usuarioToUpdate.numero_CPF == null) return NotFound();

            usuarioToUpdate.nome_Completo = usuarioView.Nome_Completo;
            usuarioToUpdate.email = usuarioView.Email;
            usuarioToUpdate.celular = usuarioView.Celular;
            usuarioToUpdate.cargo = usuarioView.Cargo;
            usuarioToUpdate.status = usuarioView.Status;

            _UsuarioRepositorio.Update(usuarioToUpdate);

            return Accepted();

        }

        [HttpDelete("{Numero_CPF}")]
        public async Task<IActionResult> Delete(string Numero_CPF)
        {
            HttpStatusCode responseStatus = _UsuarioRepositorio.Delete(Numero_CPF);
            ObjectResult result = new ObjectResult(null);
            result.StatusCode = ((int)responseStatus);
            return result;
        }

    }

}
