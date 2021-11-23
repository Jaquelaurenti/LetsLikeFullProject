
using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services
{
    public class UsuarioLikeProjetoService : IUsuarioLikeProjetoService
    {
        public readonly LetsLikeContext _context;
        public UsuarioLikeProjetoService(LetsLikeContext contexto)
        {
            _context = contexto;
        }
        public UsuarioLikeProjeto SaveOrUpdate(UsuarioLikeProjeto model)
        {
            try
            {
                var state = model.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.Entry(model).State = state;
                _context.SaveChanges();

                return model;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
    }
}
