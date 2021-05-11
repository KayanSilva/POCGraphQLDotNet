using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestGraphQLPrestador.Models.Entities;

namespace TestGraphQLPrestador.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly SqlConnection _sqlConnection;

        public TelefoneRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("SqlAzure"));
        }

        public IEnumerable<Telefone> Obter(int id)
        {
            try
            {
                _sqlConnection.Open();
                var sql = @"
                SELECT
                    TEL_ID,
                    TEL_PRS_ID AS PrestadorId,
                    TEL_NUMERO AS Numero,
                    TEL_DESCRICAO AS Descricao
                FROM TELEFONE
                WHERE TEL_PRS_ID = @PrestadorId
            ";

                var parametros = new
                {
                    PrestadorId = id
                };

                return _sqlConnection.Query<Telefone>(sql, parametros);
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
            
        }
    }

    public interface ITelefoneRepository
    {
        IEnumerable<Telefone> Obter(int id);
    }
}