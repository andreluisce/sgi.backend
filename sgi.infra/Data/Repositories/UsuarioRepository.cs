using sgi.domain.Contracts.Repositories;
using sgi.domain.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace sgi.infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AppDataContext _context;

        public UsuarioRepository(AppDataContext context)
        {
            this._context = context;
        }
        public Usuario Obter(Int64 id)
        {
            return _context.Usuarios.Include("PerfilPessoal.Endereco.Cidade.Estado.Pais").Include("PerfilPessoal.Igreja.PerfilIgreja.Endereco").Include("PerfilPessoal.Igreja.Denominacao").Include("PerfilPessoal.Igreja.Distrito").Include("Regra.Modulos.Submodulos").Include("Regra.Modulos.Submodulos.Acoes").Where(x => x.Id == id).FirstOrDefault();
        }
        public Usuario Obter(string email)
        {
            return _context.Usuarios.Include("PerfilPessoal.Endereco.Cidade.Estado.Pais").Include("PerfilPessoal.Igreja.PerfilIgreja.Endereco").Include("PerfilPessoal.Igreja.Denominacao").Include("PerfilPessoal.Igreja.Distrito").Include("Regra.Modulos.Submodulos").Include("Regra.Modulos.Submodulos.Acoes").Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public Usuario ObterComRegras(string email)
        {
            return _context.Usuarios.Include("Regra").Include("PerfilPessoal.Endereco.Cidade.Estado.Pais").Include("PerfilPessoal.Igreja.PerfilIgreja.Endereco").Include("PerfilPessoal.Igreja.Denominacao").Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public List<Usuario> Obter(int skip, int take)
        {
            return _context.Usuarios.Include("PerfilPessoal.Endereco").OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();            
        }
        public Regra GetRole(string roleName)
        {
            return _context.Regras.Where(x => x.Nome.ToLower() == roleName.ToLower()).FirstOrDefault();
        }
        public void Criar(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges(); 
        }
        public void Atualizar(Usuario user)
        {
            var userOriginal = Obter(user.Id);
            //_context.Usuarios.Attach(user);
            //_context.Entry<Usuario>(user).State = System.Data.Entity.EntityState.Modified;

            foreach (PropertyInfo propertyInfo in userOriginal.GetType().GetProperties())
            {               

                if (propertyInfo.GetValue(user, null) == null)
                    propertyInfo.SetValue(user, propertyInfo.GetValue(userOriginal, null), null);
            }

            user.RegraId = userOriginal.RegraId;

            _context.Entry<Usuario>(userOriginal).CurrentValues.SetValues(user);
            _context.Entry<PerfilPessoal>(userOriginal.PerfilPessoal).CurrentValues.SetValues(user.PerfilPessoal);
            _context.Entry<Endereco>(userOriginal.PerfilPessoal.Endereco).CurrentValues.SetValues(user.PerfilPessoal.Endereco);            
                        
            _context.SaveChanges(); 
        }
        public void Deletar(Usuario user)
        {
            _context.Usuarios.Remove(user);
            _context.SaveChanges(); 
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public Usuario ObterComModulosEAcoes(string email)
        {            

            var user = _context.Usuarios.Include("Regra.Modulos.Submodulos").Include("Regra.Modulos.Submodulos.Acoes").Where(x => x.Email.ToLower() == email.ToLower()).OrderBy(x=> x.Nome).FirstOrDefault();

            for (int i = 0; i < user.Regra.Modulos.Count; i++)            
            {
                if (user.Regra.Modulos[i].SupermoduloId != null)
                {
                    user.Regra.Modulos.RemoveAt(i);
                    continue;
                }
                var id = user.Regra.Modulos[i].Id; 
                user.Regra.Modulos[i].Acoes = _context.Acoes.Where(x => x.ModuloId == id).OrderBy(x=> x.Nome).ToList<Acao>(); 
            }
            
            return user;
        }
    }
}
