using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Dominios.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominios.Commands.Comentario
{
    public class AlterarComentarioCommand : Notifiable, ICommand
    {
        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }
        public Guid IdUsuario { get; private set; }
        //public virtual Usuario Usuario { get; private set; }
        public Guid IdPacote { get; private set; }
        //public virtual Pacote Pacote { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto desse comentário!")
            );
        }
    }
}
