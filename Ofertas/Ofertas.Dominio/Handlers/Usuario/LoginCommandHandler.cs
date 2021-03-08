using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominios.Commands.Usuario;
using CodeTur.Dominios.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominios.Handlers.Usuarios
{
    public class LoginCommandHandler : IHandlerCommand<LoginCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "E-mail inválido", null);

            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
