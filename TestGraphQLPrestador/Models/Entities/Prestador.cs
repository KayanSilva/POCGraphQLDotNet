using System;
using System.Collections.Generic;

namespace TestGraphQLPrestador.Models.Entities
{
    public class Prestador
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}