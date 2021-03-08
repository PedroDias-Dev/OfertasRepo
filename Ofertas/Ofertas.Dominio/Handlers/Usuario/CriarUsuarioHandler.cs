using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Util;
using CodeTur.Dominios.Entidades;
using CodeTur.Dominios.Repositorios;
using CodeTur.Dominios.Commands.Usuario;
using Flunt.Notifications;

namespace CodeTur.Dominios.Handlers.Usuarios
{
    public class CriarUsuarioHandler : Notifiable, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(CriarContaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Informe corretamente os dados do usuário!", command.Notifications);

            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usuarioExiste != null)
                return new GenericCommandResult(false, "E-mail já cadastrado no sistema, informe outro e-mail!", null);

            command.Senha = Senha.Criptografar(command.Senha);

            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AlterarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados de usuário inválidos!", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            //EMAIL DE BOAS VINDAS ---- SENDGRID

            return new GenericCommandResult(true, "Usuário Criado com sucesso!", usuario);
        }
    }
}
