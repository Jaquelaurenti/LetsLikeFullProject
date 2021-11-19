using AutoMapper;
using LetsLike.Data;
using LetsLike.DTO;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly LetsLikeContext _context;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, LetsLikeContext context)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuario = _usuarioService.FindAllUsuarios();
            if (usuario != null)
            {

                return Ok(usuario.Select(x => _mapper.Map<Usuario>(x)).ToList());
            }
            else
                return NotFound();
        }


        // POST api/usuario
        /// <summary>
        /// Cria usuário na Base
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/usuario
        ///     { 
        ///        "nome": "Jaque Laurenti",
        ///        "email": "jaquelaurenti@gmail.com",
        ///        "senha": "odeiomeuchefe",
        ///        "senha": "odeiomeuchefe"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Usuário inserido na base</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioDto> Post([FromQuery] UsuarioDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = value.Nome,
                Email = value.Email,
                Senha = value.Senha
            };

            var registryUser = _usuarioService.SaveOrUpdate(usuario);
            if (registryUser != null)
            {
                return Ok(registryUser);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao cadastrar Usuário!";
                return NotFound(notfound);
            }

        }
    }
}
