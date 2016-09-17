using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface IAcaoService : IDisposable
    {
        Acao ObterPorNome(string name);
        Acao ObterPorId(Int64 id);
        void Registrar(Acao acao);
        void MudarNome(Acao acao, string newName);
        List<Acao> GetByRange(int skip, int take);
        List<Acao> ObterTodos();
    }
}
