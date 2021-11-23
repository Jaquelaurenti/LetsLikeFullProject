using LetsLike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Interfaces
{
    public interface IUsuarioLikeProjetoService
    {
        UsuarioLikeProjeto SaveOrUpdate(UsuarioLikeProjeto model);
    }
}
