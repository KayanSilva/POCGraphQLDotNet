using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGraphQLPrestador.Models.Entities;

namespace TestGraphQLPrestador.Models
{
    public class PrestadorType : ObjectGraphType<Prestador>
    {
        public PrestadorType()
        {
            Field(x => x.Id);
            Field(x => x.RazaoSocial);
            Field(x => x.CpfCnpj);
            Field<ListGraphType<TelefoneType>>(nameof(Prestador.Telefones));
        }
    }

    public class TelefoneType : ObjectGraphType<Telefone>
    {
        public TelefoneType()
        {
            Field(x => x.Numero);
            Field(x => x.Descricao);
        }
    }
}