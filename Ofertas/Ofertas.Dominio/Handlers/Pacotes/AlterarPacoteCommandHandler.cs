using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Repositorios;
using CodeTur.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominios.Handlers.Pacotes
{
    public class AlterarPacoteCommandHandler
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public AlterarPacoteCommandHandler(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }

        public ICommandResult Handle(AlterarPacoteCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            //var pacoteexiste = _pacoteRepositorio.BuscarPorId(command.Id);
            //if (pacoteexiste != null)
                //return new GenericCommandResult(false, "Este Pacote não existe!", null);

            var pacote = new Entidades.Ofertas(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            _pacoteRepositorio.Alterar(pacote);

            return new GenericCommandResult(true, "Pacote Alterado!", pacote);
        }
    }
}
