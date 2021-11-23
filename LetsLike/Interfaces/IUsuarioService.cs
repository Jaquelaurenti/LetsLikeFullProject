using LetsLike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Interfaces
{
    public interface IUsuarioService
    {
        IList<Usuario> FindAllUsuarios();
        Usuario SaveOrUpdate(Usuario usuario);
        Usuario FindByUsername(string username);
        bool VerifyPassword(string password, int userId);
    }
}
