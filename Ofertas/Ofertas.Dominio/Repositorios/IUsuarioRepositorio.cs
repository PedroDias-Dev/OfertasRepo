using CodeTur.Dominios.Entidades;
using System;
using System.Collections.Generic;

namespace CodeTur.Dominios.Repositorios
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        ICollection<Usuario> Listar();
    }
}
