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
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoService projetoService, IMapper mapper)
        {
            _projetoService = projetoService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjetoDto> Post([FromBody] ProjetoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Projeto
            {
                Nome = value.Nome,
                URL = value.URL,
                Imagem = value.Imagem,
                IdUsuarioCadastro = value.IdUsuarioCadastro,
                LikeContador = 0,

            };

            var registryUser = _projetoService.SaveOrUpdate(usuario);
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

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Projeto> Patch([FromBody] UsuarioLikeProjetoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioLikeProjeto = new UsuarioLikeProjeto
            {
                IdProjetoLike = value.IdProjetoLike,
                IdUsuarioLike = value.IdUsuarioLike,

            };

            var registryUser = _projetoService.LikeProjeto(usuarioLikeProjeto);

            if (registryUser > 0)
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
