using sgi.common.Resources;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class ModuloService : IModuloService
    {
        private IModuloRepository _moduloRepository;
        private IRegraRepository _regraRepository;
        public ModuloService(IModuloRepository moduloRepository, IRegraRepository regraRepository)
        {
            this._moduloRepository = moduloRepository;
            this._regraRepository = regraRepository;
        }

        public void Registrar(Modulo modulo)
        {
            var hasModulo = _moduloRepository.Obter(modulo.Nome);
            if (hasModulo != null)
                throw new Exception(Errors.DuplicateModule);

            modulo.Validar();

            _moduloRepository.Criar(modulo);
        }

        public void MudarNome(Modulo modulo, string novoNome)
        {
            var mod = ObterPorNome(modulo.Nome);

            mod.MudarNome(novoNome);
            modulo.Validar();

            _moduloRepository.Atualizar(modulo);
        }


        public void Dispose()
        {
            this._moduloRepository.Dispose();
        }

        public Modulo ObterPorNome(string name)
        {
            return this._moduloRepository.Obter(name);
        }

        public Modulo ObterPorId(Int64 id)
        {
            var hasModulo = _moduloRepository.Obter(id);
            if (hasModulo == null)
                throw new Exception(Errors.NonexistentModule);

            return hasModulo;
        }

        public List<Modulo> GetByRange(int skip, int take)
        {
            return this._moduloRepository.Obter(skip, take);
        }

        public List<Modulo> ObterTodos()
        {
            return this._moduloRepository.Obter();
        }
    }
}
