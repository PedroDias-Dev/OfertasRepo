using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CodeTur.Dominios.Commands.Pacote
{
    public class AlterarStatusCommand : Notifiable, ICommand
    {
        public Guid IdPacote { get; set; }
        public bool Ativo { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe um Id de Pacote válido!")
            );
        }
    }
}
