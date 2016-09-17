using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario Obter(string email);
        Usuario ObterComRegras(string email);
        Usuario ObterComModulosEAcoes(string email);
        Usuario Obter(Int64 id);
        List<Usuario> Obter(int skip, int take);
        //Regra GetRole(string roleName);
        void Criar(Usuario user);
        void Atualizar(Usuario user);
        void Deletar(Usuario user); 
    }
}
