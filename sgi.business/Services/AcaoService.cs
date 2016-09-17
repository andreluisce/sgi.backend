using sgi.common.Resources;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class AcaoService:IAcaoService
    {
        private IAcaoRepository _acaoRepository;
        private IModuloRepository _moduloRepository;
        public AcaoService(IAcaoRepository acaoRepository, IModuloRepository moduloRepository)
        {
            this._acaoRepository = acaoRepository;
            this._moduloRepository = moduloRepository; 
        }
                       
        public void Registrar(Acao acao)
        {            
           /*var modulo = _moduloRepository.Obter(acao.ModuloId);
            if (modulo != null)
                throw new Exception(Errors.DuplicateModule);

            acao.Modulo = modulo; 
           acao.Validar();*/

            _acaoRepository.Criar(acao);
        }

        public void MudarNome(Acao acao, string novoNome)
        {
            acao = ObterPorNome(acao.Nome);

           acao.MudarNome(novoNome);
           acao.Validar();

           _acaoRepository.Atualizar(acao);
        }

        
        public void Dispose()
        {
            this._acaoRepository.Dispose();
        }
        
        public Acao ObterPorNome(string name)
        {
            return this._acaoRepository.Obter(name);
        }

        public Acao ObterPorId(Int64 id)
        {
            return this._acaoRepository.Obter(id);
        }

        public List<Acao> GetByRange(int skip, int take)
        {
            return this._acaoRepository.Obter(skip, take);
        }

        public List<Acao> ObterTodos()
        {
            return this._acaoRepository.Obter();            
        }
    }
}
