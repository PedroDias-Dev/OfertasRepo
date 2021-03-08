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
    public class CriarComentarioCommand : Notifiable, ICommand
    {
        public CriarComentarioCommand()
        {
        }
        public CriarComentarioCommand(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Guid idPacote)
        {

            Texto = texto;
            Sentimento = sentimento;
            Status = status;
            IdUsuario = idUsuario;
            IdPacote = idPacote;

        }
        public string Texto { get; set; }
        public string Sentimento { get; set; }
        public EnStatusComentario Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPacote { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto do comentário!")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário!")
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote!")
            );
        }
    }
}
