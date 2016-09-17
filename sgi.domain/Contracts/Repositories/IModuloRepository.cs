using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Repositories
{
    public interface IModuloRepository : IDisposable
    {
        Modulo Obter(Int64 id);
        Modulo Obter(string name);
        List<Modulo> Obter(int skip, int take);
        List<Modulo> Obter();
        void Criar(Modulo role);
        void Atualizar(Modulo role);
        void Deletar(Modulo role);
    }
}
