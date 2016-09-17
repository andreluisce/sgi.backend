using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface ILocalizacaoService : IDisposable
    {
        List<Pais> ObterPaises();
        List<Estado> ObterEstados(long paisId);
        List<Cidade> ObterCidades(long estadoId);  
    }
}
