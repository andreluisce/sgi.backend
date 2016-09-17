using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.domain.Contracts.Services
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Autenticar(string email, string password);
        Usuario Obter(string email);
        Usuario Obter(int id);
        Usuario ObterPorEmailComRegras(string email);        
        void Registrar(Usuario usuario);
        void MudarInformacao(string email, string name);
        void Atualizar(Usuario user);
        void MudarSenha(string email, string password, string newPassword, string confirmNewPassword);
        string ResetarSenha(string email);       
        List<Usuario> GetByRange(int skip, int take);        
        void AssociarUsuarioRegra(Usuario user, Regra regra);
        Usuario MontarMenu(string email);
    }
}
