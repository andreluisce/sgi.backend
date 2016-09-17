using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace sgi.infra.Data.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private AppDataContext _context;

        public InstituicaoRepository(AppDataContext context)
        {
            this._context = context;
        }
        
        public List<Denominacao> ObterDenominacoes()
        {
           return _context.Denominacoes.OrderBy(x => x.Nome).ToList(); 
        }

        public List<Regiao> ObterRegioes(long DenominacaoId)
        {
            var lista = _context.Regioes.Where(x => x.DenominacaoId == DenominacaoId).ToList();
            return lista;
        }

        public List<Estado> ObterEstados(long RegiaoId)
        {
            return _context.Estados.Where(e => e.Regioes.Any(r => r.Id == RegiaoId)).ToList<Estado>(); 

           // return new List<Estado>();
        }

        public List<Distrito> ObterDistritos(long EstadoId)
        {
            return _context.Distritos.Where(x => x.EstadoId == EstadoId).ToList(); 
        }

        public List<Cidade> ObterCidades(long DistritoId)
        {
            return _context.Cidades.Where(x => x.DistritoId == DistritoId).ToList();
        }

        public List<Igreja> ObterIgrejas(long DistritoId)
        {
            return _context.Igrejas.Include("PerfilIgreja.Endereco.Cidade").Where(x => x.DistritoId == DistritoId).ToList(); 
        }

        public void CadastrarIgreja(Igreja igreja)
        {
            _context.Igrejas.Add(igreja);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        
    }
}
