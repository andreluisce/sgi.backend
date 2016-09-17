using sgi.common.Resources;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class InstituicaoService:IInstituicaoService
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoService(IInstituicaoRepository instituicaoRepository)
        {
            this._instituicaoRepository = instituicaoRepository;
            
        }

        public List<Denominacao> ObterDenominacoes()
        {
            return _instituicaoRepository.ObterDenominacoes(); 
        }

        public List<Regiao> ObterRegioes(long DenominacaoId)
        {
            return _instituicaoRepository.ObterRegioes(DenominacaoId);
        }

        public List<Estado> ObterEstados(long RegiaoId)
        {
            return _instituicaoRepository.ObterEstados(RegiaoId); 
        }

        public List<Cidade> ObterCidades(long DistritoId)
        {
            return _instituicaoRepository.ObterCidades(DistritoId);
        }


        public List<Distrito> ObterDistritos(long EstadoId)
        {
            return _instituicaoRepository.ObterDistritos(EstadoId); 
        }

        public List<Igreja> ObterIgrejas(long DistritoId)
        {
            return _instituicaoRepository.ObterIgrejas(DistritoId); 
        }

        public void Dispose()
        {
            _instituicaoRepository.Dispose(); 
        }


        public void CadastrarIgreja(Igreja igreja)
        {
            _instituicaoRepository.CadastrarIgreja(igreja);
        }
    }
}
