using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sgi.infra.Data.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private AppDataContext _context;

        public LocalizacaoRepository(AppDataContext context)
        {
            this._context = context;
        }

        public List<Pais> ObterPaises()
        {
            return _context.Paises.OrderBy(x => x.Nome).ToList();
        }

        public List<Estado> ObterEstados(long paisId)
        {
            return _context.Estados.Where(x => x.PaisId == paisId).OrderBy(x=> x.Nome).ToList();
        }

        public List<Cidade> ObterCidades(long estadoId)
        {
            return _context.Cidades.Where(x => x.EstadoId == estadoId).OrderBy(x => x.Nome).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
