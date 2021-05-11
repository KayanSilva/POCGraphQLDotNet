using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using TestGraphQLPrestador.Models.Entities;

namespace TestGraphQLPrestador.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly SqlConnection _sqlConnection;

        public PrestadorRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("SqlAzure"));
        }

        public IEnumerable<Prestador> GetAll()
        {
            var selectPrestador = @"SELECT
                    PRS_ID AS Id,
                    PRS_NOME AS RazaoSocial,
                    PRS_CNPJ_CPF AS CpfCnpj,
                    PRS_ATIVO AS Ativo,
                    PRS_NOME_FANTASIA AS NomeFantasia,
                    PRS_ENDERECO AS Endereco,
                    PRS_COMPLEMENTO AS Complemento,
                    PRS_NUMERO AS NumeroEndereco,
                    PRS_BAIRRO AS Bairro,
                    PRS_MUNCIPIO AS Municipio,
                    PRS_UF_SIGLA AS UF,
                    PRS_PAIS_SIGLA AS Pais,
                    PRS_OBSERVACAO AS Observacao,
                    PRS_MATRICULA AS Matricula,
                    PRS_RECEPCAO_FISCAL_AUTOMATICA AS RecepcaoFiscalAutomatica,
                    PRS_PERMITE_ENVIO_QUESTIONARIO AS PermiteEnvioQuestionario,
                    PRS_LIMITE_KM_MOTOR AS LimiteKmMotor,
                    PRS_QTDE_MAX_ACN_MOTOR AS QuantidadeMaximaAcionamentoMotor,
                    PRS_NAO_CALCULAR_PEDAGIO AS NaoCalcularPedagio,
                    PRS_NAO_CALCULAR_KM_EXCEDENTE AS NaoCalcularKmExcedente,
                    PRS_USU_APROVACAO_MATRICULA AS UsuarioAprovacaoMatricula
                FROM
                    dbo.PRESTADOR";

            return _sqlConnection.Query<Prestador>(selectPrestador);
        }

        public Prestador Obter(int id)
        {
            var selectPrestador = @"SELECT
                    PRS_ID AS Id,
                    PRS_NOME AS RazaoSocial,
                    PRS_CNPJ_CPF AS CpfCnpj,
                    PRS_ATIVO AS Ativo,
                    PRS_NOME_FANTASIA AS NomeFantasia,
                    PRS_ENDERECO AS Endereco,
                    PRS_COMPLEMENTO AS Complemento,
                    PRS_NUMERO AS NumeroEndereco,
                    PRS_BAIRRO AS Bairro,
                    PRS_MUNCIPIO AS Municipio,
                    PRS_UF_SIGLA AS UF,
                    PRS_PAIS_SIGLA AS Pais,
                    PRS_OBSERVACAO AS Observacao,
                    PRS_MATRICULA AS Matricula,
                    PRS_RECEPCAO_FISCAL_AUTOMATICA AS RecepcaoFiscalAutomatica,
                    PRS_PERMITE_ENVIO_QUESTIONARIO AS PermiteEnvioQuestionario,
                    PRS_LIMITE_KM_MOTOR AS LimiteKmMotor,
                    PRS_QTDE_MAX_ACN_MOTOR AS QuantidadeMaximaAcionamentoMotor,
                    PRS_NAO_CALCULAR_PEDAGIO AS NaoCalcularPedagio,
                    PRS_NAO_CALCULAR_KM_EXCEDENTE AS NaoCalcularKmExcedente,
                    PRS_USU_APROVACAO_MATRICULA AS UsuarioAprovacaoMatricula
                FROM
                    dbo.PRESTADOR
                WHERE PRS_ID = @id";

            return _sqlConnection.QueryFirstOrDefault<Prestador>(selectPrestador, new { id });
        }
    }

    public interface IPrestadorRepository
    {
        IEnumerable<Prestador> GetAll();
        Prestador Obter(int id);
    }
}
