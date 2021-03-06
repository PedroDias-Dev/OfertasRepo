using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominios.Commands.Usuario
{
    public class CriarContaCommand : Notifiable, ICommand
    {
        public CriarContaCommand()
        {

        }

        public CriarContaCommand(string nome, string email, string senha, string telefone, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres!")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres!")
                .IsEmail(Email, "Email", "Informe um e-mail válido!")
                .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres!")
                .HasMaxLen(Senha, 12, "Senha", "A senha deve ter no máximo 12 caracteres!")
            );
        }
    }
}
