using sgi.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgi.api.Models.ViewModels
{
    public class SubModuloViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CssClass { get; set; }
        //public Int64? SupermoduloId { get; set; }
        //public virtual ICollection<ModuloViewModel> Submodulos { get; set; }        
        public virtual ICollection<AcaoViewModel> Acoes { get; set; }        
    }
}