using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Repositorios;
using CodeTur.Dominios.Commands.Pacote;
using CodeTur.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominios.Handlers.Pacotes
{
    public class AlterarStatusCommandHandler : IHandlerCommand<AlterarStatusCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public AlterarStatusCommandHandler(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(AlterarStatusCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            var pacoteexiste = _pacoteRepositorio.BuscarPorId(command.IdPacote);

            var pacote = new Entidades.Ofertas(pacoteexiste.Titulo, pacoteexiste.Descricao, pacoteexiste.Imagem, command.Ativo);

            _pacoteRepositorio.Alterar(pacote);

            return new GenericCommandResult(true, "Status Alterado!", pacote);
        }
    }
}
