using CodeTur.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominios.Repositorios
{
    public interface IComentarioRepositorio
    {
        void Adicionar(Reserva comentario);
        void Alterar(Reserva comentario);
        IEnumerable<Reserva> Listar();

    }
}
