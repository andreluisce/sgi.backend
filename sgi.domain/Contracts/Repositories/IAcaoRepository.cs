using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Repositories
{
    public interface IAcaoRepository : IDisposable
    {
        Acao Obter(Int64 id);
        Acao Obter(string acao);
        List<Acao> Obter(int skip, int take);
        List<Acao> Obter();
        void Criar(Acao role);
        void Atualizar(Acao role);
        void Deletar(Acao role);
    }
}
