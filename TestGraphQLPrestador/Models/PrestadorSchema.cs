using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestGraphQLPrestador.Models
{
    public class PrestadorSchema : Schema
    {
        public PrestadorSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = resolver.GetRequiredService<GetAllPrestadores>();
        }
    }
}
