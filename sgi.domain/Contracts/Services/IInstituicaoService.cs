using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface IInstituicaoService : IDisposable
    {
        List<Denominacao> ObterDenominacoes();
        List<Regiao> ObterRegioes(long DenominacaoId);
        List<Estado> ObterEstados(long RegiaoId);
        List<Distrito> ObterDistritos(long EstadoId);
        List<Cidade> ObterCidades(long CidadeId);
        List<Igreja> ObterIgrejas(long DistritoId);
        void CadastrarIgreja(Igreja igreja);
    }
}
