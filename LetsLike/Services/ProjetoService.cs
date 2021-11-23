using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly LetsLikeContext _context;
        private readonly IUsuarioLikeProjetoService _usaurioProjetoService;
        public ProjetoService(LetsLikeContext contexto, IUsuarioLikeProjetoService usaurioProjetoService)
        {
            _context = contexto;
            _usaurioProjetoService = usaurioProjetoService;
        }

        public int LikeProjeto(UsuarioLikeProjeto model)
        {
            try
            {
                var projeto = _context.Projetos.Where(x => x.Id.Equals(model.IdProjetoLike)).FirstOrDefault();
                var usuario = _context.Usuarios.Where(x => x.Id.Equals(model.IdUsuarioLike)).FirstOrDefault();

                if (projeto == null)
                {
                    throw new FileNotFoundException(message: "Não foi encontrado projeto com o valor inserido");
                }
                else if (usuario == null)
                {
                    throw new FileNotFoundException(message: "Não foi encontrado usuário com o valor inserido");
                }
                else
                {
                    _usaurioProjetoService.SaveOrUpdate(model);
                    projeto.LikeContador = projeto.LikeContador + 1;
                    SaveOrUpdate(projeto);
                    return projeto.LikeContador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Projeto SaveOrUpdate(Projeto projeto)
        {
            try
            {
                if (_context.Usuarios.Any(e => e.Id == projeto.IdUsuarioCadastro))
                {
                    var state = projeto.Id == 0 ? EntityState.Added : EntityState.Modified;
                    _context.Entry(projeto).State = state;
                    _context.SaveChanges();
                    return projeto;
                }
                else
                {
                    throw new FileNotFoundException(message: "Não foi encontrado usuário com o valor inserido");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
