using sgi.domain.Contracts;
using System;

namespace sgi.domain.Models
{
    public class Departamento :IDepartamento
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }
}
