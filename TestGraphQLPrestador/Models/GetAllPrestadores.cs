using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using TestGraphQLPrestador.Models.Entities;
using TestGraphQLPrestador.Repositories;

namespace TestGraphQLPrestador.Models
{
    public class GetAllPrestadores : ObjectGraphType
    {
        public GetAllPrestadores(IPrestadorRepository prestadorRepository, ITelefoneRepository telefoneRepository)
        {
            Field<ListGraphType<PrestadorType>>("prestadores",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    }
                }),
                resolve: context =>
                {
                    var query = new List<Prestador>();
                    var prestadorId = context.GetArgument<int?>("id");
                    if (prestadorId.HasValue)
                        query.Add(prestadorRepository.Obter(prestadorId.Value));
                    else
                         query = prestadorRepository.GetAll().ToList();

                   if(context.SubFields.Keys.Any(x => x == "telefones"))
                        query.ToList().ForEach(prestador => prestador.Telefones = telefoneRepository.Obter(prestador.Id));

                    return query.ToList();
                }
            );

        }
    }
}