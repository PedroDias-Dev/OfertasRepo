using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Repositorios;
using CodeTur.Dominios.Entidades;
using System;

namespace CodeTur.Dominios.Handlers.Pacotes
{
    public class CriarPacoteCommandHandle : IHandlerCommand<CriarPacoteCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public CriarPacoteCommandHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(CriarPacoteCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            var pacoteexiste = _pacoteRepositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteexiste != null)
                return new GenericCommandResult(true, "Titulo do pacote já cadastrado!", null);

            var pacote = new Entidades.Ofertas(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if (pacote.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", pacote.Notifications);

            _pacoteRepositorio.Adicionar(pacote);

            return new GenericCommandResult(true, "Pacote criado!", pacote);

        }
    }
}
