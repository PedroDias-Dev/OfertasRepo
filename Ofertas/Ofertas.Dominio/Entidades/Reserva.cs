using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using System;
using Flunt.Validations;
namespace CodeTur.Dominios.Entidades
{
    public class Reserva : Entidade
    {
        public Reserva(Guid idReserva, Guid idUsuario, Usuario usuario, Guid idOferta, Ofertas oferta, int quantidadeReserva)
        {
            IdReserva = idReserva;
            IdUsuario = idUsuario;
            Usuario = usuario;
            IdOferta = idOferta;
            Oferta = oferta;
            QuantidadeReserva = quantidadeReserva;
        }

        public Guid IdReserva { get; private set; }
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdOferta { get; private set; }
        public virtual Ofertas Oferta { get; private set; }
        public int QuantidadeReserva { get; private set; }
    }
}
