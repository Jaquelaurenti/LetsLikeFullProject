﻿using LetsLike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Interfaces
{
    public interface IProjetoService
    {
        Projeto SaveOrUpdate(Projeto projeto);
        int LikeProjeto(UsuarioLikeProjeto model);
        IList<Projeto> GetByUsuario(int idUsuario);
        IList<Projeto> GetAll();
    }
}
