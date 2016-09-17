using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface IRegraService : IDisposable
    {
        Regra ObterPorNome(string name);
        Regra ObterPorId(Int64 id);
        void Registrar(Regra regra);
        void MudarNome(Regra regra, string newName);
        List<Regra> GetByRange(int skip, int take);
        List<Regra> ObterTodos();
        void AssociarRegraModulo(Regra regra, Modulo modulo);
       // void AssociarRegraAcao(Regra regra, Acao acao);        
    }
}
