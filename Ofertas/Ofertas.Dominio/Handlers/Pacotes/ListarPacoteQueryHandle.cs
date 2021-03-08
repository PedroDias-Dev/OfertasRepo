using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Queries.Pacote;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Dominios.Handlers.Pacotes
{
    public class ListarPacoteQueryHandle : IHandlerQuery<ListarPacotesQuery>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public ListarPacoteQueryHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public IQueryResult Handle(ListarPacotesQuery query)
        {
            var pacotes = _pacoteRepositorio.Listar(query.Ativo);

            var retornoPacotes = pacotes.Select(
                x =>
                {
                    return new ListarPacotesQueryResult()
                    {
                        Id = x.Id,
                        Titulo = x.Titulo,
                        Descricao = x.Descricao,
                        Ativo = x.Ativo,
                        Imagem = x.Imagem,
                        DataCriacao = x.DataCriacao,
                        QuantidadeComentarios = x.Comentarios.Count
                    };
                }
            );

            return new GenericQueryResult(true, "Pacotes", retornoPacotes);
        }
    }
}
