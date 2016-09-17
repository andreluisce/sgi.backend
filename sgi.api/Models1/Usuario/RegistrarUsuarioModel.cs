
namespace sgi.api.Models.Usuario
{
    public class RegistrarUsuarioModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        //Perfil
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        //Endereço
        public int EnderecoNumero { get; set; }
        public string EnderecoNome { get; set; }
        public int TipoEndereco { get; set; }

    }
}