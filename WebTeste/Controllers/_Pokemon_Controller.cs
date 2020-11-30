using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;
using WebTeste.Validator;

namespace WebTeste.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class _Pokemon_Controller : Controller
    {
        protected readonly I_Pokemon_Repository _repository;
        protected readonly IValidator<_Pokemon_> _validator;

        public _Pokemon_Controller(I_Pokemon_Repository pokemonRepository, IValidator<_Pokemon_> pokemonValidator)
        {
            _repository = pokemonRepository;
            _validator = pokemonValidator;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var list = await _repository.BuscarTodos();
                return new OkObjectResult(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Incluir([FromBody] _Pokemon_ dado)
        {
            try
            {

                List<string> response = new List<string>();

                var validationResult = _validator.Validate(dado);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.Add(error.ToString());
                    }

                    return new OkObjectResult(response);
                }

                return new OkObjectResult(await _repository.Incluir(dado));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
