using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sgi.infra.Data.Repositories
{
    public class AcaoRepository : IAcaoRepository
    {
        private AppDataContext _context;

        public AcaoRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Acao Obter(Int64 id)
        {
            return _context.Acoes.Where(x => x.Id == id).FirstOrDefault();
        }
        public Acao Obter(string name)
        {
            return _context.Acoes.Where(x => x.Nome.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public List<Acao> Obter()
        {
            return _context.Acoes.Include("Acoes").ToList();

            
        }
        public List<Acao> Obter(int skip, int take)
        {
            return _context.Acoes.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }
        public void Criar(Acao modulo)
        {
            _context.Acoes.Add(modulo);
            _context.SaveChanges();
        }
        public void Atualizar(Acao modulo)
        {
            _context.Entry<Acao>(modulo).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Deletar(Acao modulo)
        {
            _context.Acoes.Remove(modulo);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
