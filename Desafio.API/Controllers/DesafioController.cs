using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain;
using Desafio.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio.API.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class DesafioController : ControllerBase {
        private readonly IDesafioRepository _repo;
        private readonly IFileManager _fileManager;

        public DesafioController (IDesafioRepository repo, IFileManager fileManager) {
            _repo = repo;
            _fileManager = fileManager;
        }

        [HttpGet ("getValores")]
        public async Task<IActionResult> GetValores () {
            try {

                _fileManager.ManageFile ("TestLog");
                var valores = _fileManager.GetValores ();

                return Ok (valores);
            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }

        [HttpGet ("getValores/{dataLog}")]
        public async Task<IActionResult> GetValoresByDataLog (DateTime dataLog) {
            try {

                _fileManager.ManageFile ("TestLog");
                var valores = _fileManager.GetValoresByDatalog (dataLog);

                return Ok (valores);
            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }

        [HttpPost ("postValores")]
        public async Task<ActionResult> PostValores (Valores valores) {

            try {

                _fileManager.ManageFile ("TestLog");

                Valores val = _repo.CalcularResultado (valores);

                string data = val.Valor1.ToString () + ";" +
                    val.Valor2.ToString () + ";" +
                    val.Resultado.ToString () + ";" +
                    val.Operacao;

                await _fileManager.WriteData (data);

                return Created($"/desafio/getValores/{valores.DataLog}",valores);

            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }

        [HttpGet ("getRegistros")]
        public async Task<IActionResult> GetRegistros () {

            try {

                _fileManager.ManageFile ("TestRegis");
                var registros = _fileManager.GetDados ();

                return Ok (registros);
            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }

        [HttpGet ("getRegistros/{Identificacao}")]
        public async Task<IActionResult> GetRegistrosByIdentificacao (string Identificacao) {

            try {

                _fileManager.ManageFile ("TestRegis");
                
                var registros = _fileManager.GetDadosById (Identificacao);

                return Ok (registros);
            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }

        [HttpPost ("postRegistros")]
        public async Task<ActionResult> PostRegistro (Registros registro) {

            try {

                string data = registro.Nome + ";" +
                    registro.Endereco + ";" +
                    registro.DataNascimento.ToString () + ";" +
                    registro.Telefone + ";" +
                    _repo.FormataIdentificacao(registro.Identificacao);

                _fileManager.ManageFile ("TestRegis");

                if (await _fileManager.WriteData (data)) {
                    return Created ($"desafio/getRegistro/{registro.Identificacao}", registro);
                }

                return Conflict ("Usuário existente");
            } catch (Exception ex) {
                return this.StatusCode (StatusCodes.Status500InternalServerError,
                    "Banco de Dados falhou!\n" +
                    $"Detalhes do erro: {ex.Message}");
            }

        }
    }
}