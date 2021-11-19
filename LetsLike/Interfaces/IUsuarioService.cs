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
        Usuario FindByIdLevel(int usuarioId);
        Usuario FindByLevelName(string nome);
        Usuario SaveOrUpdate(Usuario usuario);
    }
}
