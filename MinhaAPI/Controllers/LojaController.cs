using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaAPI.Infraestrutura;
using MinhaAPI.Model;
using MinhaAPI.ViewModel;
using System.Net;

namespace MinhaAPI.Controllers
{

        [ApiController]
        [Route("api/v1/loja")]
        public class LojaController : ControllerBase
        {
            private readonly ILoja _LojaRepositorio;

            public LojaController(ILoja lojaRepositorio)
            {
                _LojaRepositorio = lojaRepositorio ?? throw new ArgumentNullException(nameof(LojaRepositorio));
            }

            [HttpPost]
            public IActionResult Add(LojaViewModel lojaView)
            {

                Loja loja = new Loja(lojaView.Numero_CNPJ,
                                    lojaView.Razao_Social,
                                    lojaView.Nome_Fantasia,
                                    DateTime.ParseExact(lojaView.DataAbertura, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                                    DateTime.ParseExact(lojaView.DataEncerrada, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                                    lojaView.Status,
                                    lojaView.Endereco,
                                    lojaView.Telefone,
                                    lojaView.Proprietario);

                _LojaRepositorio.Add(loja);

                return Created();
            }

            [HttpGet]

            public IActionResult Get()
            {
                var lojas = _LojaRepositorio.Get();

                return Ok(lojas);
            }


        [HttpPut("{Numero_CNPJ}")]
        public async Task<IActionResult> Put(string Numero_CNPJ, LojaViewModel lojaView)
        {
            Loja lojaToUpdate = _LojaRepositorio.getEmpresaByCNPJ(Numero_CNPJ);
            if (lojaToUpdate == null || lojaToUpdate.numero_CNPJ == null) return NotFound();

            lojaToUpdate.numero_CNPJ = lojaView.Numero_CNPJ;
            lojaToUpdate.razao_Social = lojaView.Razao_Social;
            lojaToUpdate.nome_Fantasia = lojaView.Nome_Fantasia;
            lojaToUpdate.status = lojaView.Status;
            lojaToUpdate.endereco = lojaView.Endereco;
            lojaToUpdate.telefone = lojaView.Telefone;
            lojaToUpdate.proprietario = lojaView.Proprietario;

            _LojaRepositorio.Update(lojaToUpdate);

            return Accepted();

        }

        [HttpDelete("{Numero_CNPJ}")]
        public async Task<IActionResult> Delete(string Numero_CNPJ)
        {
            HttpStatusCode responseStatus = _LojaRepositorio.Delete(Numero_CNPJ);
            ObjectResult result = new ObjectResult(null);
            result.StatusCode = ((int)responseStatus);
            return result;
        }
    }

    }

