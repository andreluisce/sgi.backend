using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Repositories
{
    public interface IRegraRepository : IDisposable
    {
        Regra Obter(Int64 id);
        Regra Obter(string name);
        List<Regra> Obter(int skip, int take);
        List<Regra> Obter();
        void Criar(Regra role);
        void Atualizar(Regra role);
        void Deletar(Regra role);
    }
}
