using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sgi.infra.Data.Repositories
{
    public class RegraRepository : IRegraRepository
    {
        private AppDataContext _context;

        public RegraRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Regra Obter(Int64 id)
        {
            return _context.Regras.Include("Acoes").Include("Modulos").Where(x => x.Id == id).FirstOrDefault();
        }
        public Regra Obter(string name)
        {
            return _context.Regras.Where(x => x.Nome.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public List<Regra> Obter()
        {
            return _context.Regras.Include("Permissions").ToList();

            
        }
        public List<Regra> Obter(int skip, int take)
        {
            return _context.Regras.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }
        public void Criar(Regra role)
        {
            _context.Regras.Add(role);
            _context.SaveChanges();
        }
        public void Atualizar(Regra role)
        {
            _context.Entry<Regra>(role).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Deletar(Regra role)
        {
            _context.Regras.Remove(role);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
