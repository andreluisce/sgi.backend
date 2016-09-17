using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface IModuloService : IDisposable
    {
        Modulo ObterPorNome(string name);
        Modulo ObterPorId(Int64 id);
        void Registrar(Modulo modulo);
        void MudarNome(Modulo modulo, string newName);
        List<Modulo> GetByRange(int skip, int take);
        List<Modulo> ObterTodos();
    }
}
