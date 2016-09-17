using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sgi.infra.Data.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private AppDataContext _context;

        public ModuloRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Modulo Obter(Int64 id)
        {
            return _context.Modulos.Where(x => x.Id == id).FirstOrDefault();
        }
        public Modulo Obter(string name)
        {
            return _context.Modulos.Where(x => x.Nome.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public List<Modulo> Obter()
        {
            return _context.Modulos.Include("Acoes").ToList();

            
        }
        public List<Modulo> Obter(int skip, int take)
        {
            return _context.Modulos.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }
        public void Criar(Modulo modulo)
        {
            _context.Modulos.Add(modulo);
            _context.SaveChanges();
        }
        public void Atualizar(Modulo modulo)
        {
            _context.Entry<Modulo>(modulo).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Deletar(Modulo modulo)
        {
            _context.Modulos.Remove(modulo);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
