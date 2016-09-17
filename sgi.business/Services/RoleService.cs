using sgi.common.Resources;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class RoleService:IRegraService
    {
        private IRegraRepository _regraRepository;
        private IModuloRepository _moduloRepository;
        private IAcaoRepository _acaoRepository;
        public RoleService(IRegraRepository regraRepository, IModuloRepository moduloRepository, IAcaoRepository acaoRepository)
        {
            this._regraRepository = regraRepository;
            this._moduloRepository = moduloRepository;
            this._acaoRepository = acaoRepository; 
        }
                       
        public void Registrar(Regra regra)
        {
            var hasRole = _regraRepository.Obter(regra.Nome);
            if (hasRole != null)
                throw new Exception(Errors.DuplicateRole);
                        
            regra.Validar();

            _regraRepository.Criar(regra);
        }

        public void MudarNome(Regra regra, string novoNome)
        {
            regra = ObterPorNome(regra.Nome);

            regra.MudarNome(novoNome);
            regra.Validar();

            _regraRepository.Atualizar(regra);
        }

        
        public void Dispose()
        {
            this._regraRepository.Dispose();
        }
        
        public Regra ObterPorNome(string name)
        {
            return this._regraRepository.Obter(name);
        }

        public Regra ObterPorId(Int64 id)
        {
            return this._regraRepository.Obter(id);
        }

        public List<Regra> GetByRange(int skip, int take)
        {
            return this._regraRepository.Obter(skip, take);
        }

        public List<Regra> ObterTodos()
        {
            return this._regraRepository.Obter();            
        }

        public void AssociarRegraModulo(Regra regra, Modulo modulo)
        {
            regra = _regraRepository.Obter(regra.Id);
            modulo = _moduloRepository.Obter(modulo.Id);

            if (regra == null)
                throw new Exception(Errors.NonexistentRole);

            if (modulo == null)
                throw new Exception(Errors.NonexistentModule);

            regra.Modulos.Add(modulo);
            this._regraRepository.Atualizar(regra);
        }
        /*public void AssociarRegraAcao(Regra regra, Acao acao)
        {
            regra = this._regraRepository.Obter(regra.Id);
            acao = this._acaoRepository.Obter(acao.Id);

            if (regra == null)
                throw new Exception(Errors.NonexistentRole);

            if (acao == null)
                throw new Exception(Errors.NonexistentAction);

            regra.Acoes.Add(acao);

            this._regraRepository.Atualizar(regra);
        }*/
    }
}
