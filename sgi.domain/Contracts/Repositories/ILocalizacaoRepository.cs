using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Repositories
{
    public interface ILocalizacaoRepository : IDisposable
    {        
        List<Pais> ObterPaises();
        List<Estado> ObterEstados(long paisId);
        List<Cidade> ObterCidades(long estadoId);        
    }
}
