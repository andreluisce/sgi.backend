using sgi.common.Resources;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class LocalizacaoService:ILocalizacaoService
    {
        private ILocalizacaoRepository _localizacaoRepository;
        
        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository)
        {
            this._localizacaoRepository = localizacaoRepository;
            
        }
        public List<Pais> ObterPaises()
        {
          return this._localizacaoRepository.ObterPaises();    
        }

        public List<Estado> ObterEstados(long paisId)
        {
            return this._localizacaoRepository.ObterEstados(paisId); 
        }

        public List<Cidade> ObterCidades(long estadoId)
        {
            return this._localizacaoRepository.ObterCidades(estadoId);
        }

        public void Dispose()
        {
            this._localizacaoRepository.Dispose(); 
        }
    }
}
