using sgi.domain.Models;
using System;

namespace sgi.api.Models.ViewModels
{
    public class UsuarioCreateMenuModel
    {
        public Int64 Id { get; set; }
        //public string Nome { get; set; }
        //public string Email { get; set; }
        public RegraViewModel Regra { get; set; }

    }

}