using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Queries.Pacote;
using CodeTur.Dominio.Repositorios;
using CodeTur.Dominios.Queries.Comentario;
using CodeTur.Dominios.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Dominios.Handlers.Comentarios
{
    public class ListarComentarioQueryHandler : IHandlerQuery<ListarComentariosQuery>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public ListarComentarioQueryHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public IQueryResult Handle(ListarComentariosQuery query)
        {
            var comentarios = _comentarioRepositorio.Listar();

            var retornoComentarios = comentarios.Select(
                x =>
                {
                    return new ListarComentariosQueryResult()
                    {
                        Texto = x.Texto,
                        Sentimento = x.Sentimento,
                        Status = x.Status,
                        IdUsuario = x.IdUsuario,
                        IdPacote = x.IdPacote
                    };
                }
            );

            return new GenericQueryResult(true, "Comentarios", retornoComentarios);
        }
    }
}
