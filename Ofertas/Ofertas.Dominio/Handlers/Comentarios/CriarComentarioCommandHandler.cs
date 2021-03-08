using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.ServicosCognitivos;
using CodeTur.Dominio.Repositorios;
using CodeTur.Dominios.Commands.Comentario;
using CodeTur.Dominios.Entidades;
using CodeTur.Dominios.Repositorios;
using Flunt.Notifications;
using System;
using System.Linq;

namespace CodeTur.Dominios.Handlers.Comentarios
{
    public class CriarComentarioCommandHandler : Notifiable, IHandlerCommand<CriarComentarioCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;
        private readonly IComentarioRepositorio _comentarioRepositorio;
        public CriarComentarioCommandHandler(IPacoteRepositorio pacoteRepositorio, IComentarioRepositorio comentarioRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
            _comentarioRepositorio = comentarioRepositorio;
        }
        public ICommandResult Handle(CriarComentarioCommand command)
        {
            command.Validar();
            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var pacoteExiste = _pacoteRepositorio.BuscarPorId(command.IdPacote);
            if (pacoteExiste == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            var resultado = new ModeradorConteudo().Moderar(command.Texto);
            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                ).ToArray();
                return new GenericCommandResult(false, "Este comentário fere nossas politicas", palavras);
            }

            Reserva comentario = new Comentario(command.Texto, "Feliz", command.IdUsuario, command.IdPacote, EnStatusComentario.Publicado);
            if (comentario.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", comentario.Notifications);
            _comentarioRepositorio.Adicionar(comentario);

            return new GenericCommandResult(true, "Comentário Adicionado", null);
        }
    }
}
