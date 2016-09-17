using sgi.common.Resources;
using sgi.common.Validation;
using sgi.domain.Contracts.Repositories;
using sgi.domain.Contracts.Services;
using sgi.domain.Models;
using System;
using System.Collections.Generic;

namespace sgi.business.Services
{
    public class UserService : IUsuarioService
    {
        private IUsuarioRepository _userRepository;
        private IRegraRepository _regraRepository;
        public UserService(IUsuarioRepository userRepository, IRegraRepository regraRepository)
        {
            this._userRepository = userRepository;
            this._regraRepository = regraRepository;
        }
        public Usuario Autenticar(string email, string senha)
        {
            var user = ObterPorEmailComRegras(email);
            if (user.Senha != PasswordAssertionConcern.Encrypt(senha))
            {
                throw new Exception(Errors.InvalidPassword);
            }

            return user;
        }
        public Usuario Obter(string email)
        {
            Usuario user = _userRepository.Obter(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }
        public Usuario Obter(int id)
        {
            Usuario user = _userRepository.Obter(id);
            if (user == null)
                throw new Exception(Errors.UserNotFound);
            return user;
        }
        public Usuario ObterPorEmailComRegras(string email)
        {
            Usuario user = _userRepository.ObterComRegras(email);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }
        public void Registrar(Usuario usuario)
        {
            var hasUser = _userRepository.Obter(usuario.Email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            usuario.Validar();
            usuario.SetarSenha(usuario.Senha, usuario.ConfirmarSenha);
            usuario.PerfilPessoal.Validar();
            //usuario.Regra = _regraRepository.Obter(usuario.RegraId);
            _userRepository.Criar(usuario);
        }
        public void MudarInformacao(string email, string nome)
        {
            var user = Obter(email);
            if (user.Nome == nome)
            {

            }

            user.MudarSenha(nome);
            user.Validar();

            _userRepository.Atualizar(user);
        }
        public void MudarSenha(string email, string senha, string novaSenha, string confirmarNovaSenha)
        {
            var user = Autenticar(email, senha);

            user.SetarSenha(novaSenha, confirmarNovaSenha);
            user.Validar();

            _userRepository.Atualizar(user);
        }
        public string ResetarSenha(string email)
        {
            var user = Obter(email);
            var password = user.ResetarSenha();
            user.Validar();

            _userRepository.Atualizar(user);
            return password;
        }
        public List<Usuario> GetByRange(int skip, int take)
        {
            return _userRepository.Obter(skip, take);
        }
        public void Dispose()
        {
            this._userRepository.Dispose();
        }
        public void AssociarUsuarioRegra(Usuario usuario, Regra regra)
        {
            usuario = Obter(usuario.Email);

            regra = _regraRepository.Obter(regra.Id);


            if (usuario == null)
                throw new Exception(Errors.InvalidUserName);

            if (regra == null)
                throw new Exception(Errors.InvalidRoleName);

            usuario.Regra = regra;

            this._userRepository.Atualizar(usuario);
        }
        public Usuario MontarMenu(string email)
        {
            var user = this._userRepository.ObterComModulosEAcoes(email);

            return user;
        }


        public void Atualizar(Usuario user)
        {
            if (user == null)
                throw new Exception(Errors.InvalidUserName);

            _userRepository.Atualizar(user); 
        }
    }
}
