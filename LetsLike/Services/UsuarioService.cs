using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Services
{
    public class UsuarioService : IUsuarioService
    {
        public LetsLikeContext _context;
        public UsuarioService(LetsLikeContext contexto)
        {
            _context = contexto;
        }
        public IList<Usuario> FindAllUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindByIdLevel(int usuarioId)
        {
            return _context.Usuarios.Find(usuarioId);
        }

        public Usuario FindByLevelName(string nome)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Usuario SaveOrUpdate(Usuario usuario)
        {
            var existe = _context.Usuarios
                    .Where(x => x.Id == usuario.Id)
                    .FirstOrDefault();

            if (existe == null)
                _context.Usuarios.Add(usuario);
            else
            {
                existe.Email = usuario.Email;
                existe.Nome = usuario.Nome;
                existe.Senha = usuario.Senha;
            }
            _context.SaveChanges();

            return usuario;
        }
    }
}
