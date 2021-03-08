using CodeTur.Dominios.Entidades;
using System;
using System.Collections.Generic;

namespace CodeTur.Dominio.Repositorios
{
    public interface IPacoteRepositorio
    {
        void Adicionar(Dominios.Entidades.Ofertas pacote);
        void Alterar(Dominios.Entidades.Ofertas pacote);
        IEnumerable<Dominios.Entidades.Ofertas> Listar(bool? ativo = null);
        Dominios.Entidades.Ofertas BuscarPorTitulo(string titulo);
        Dominios.Entidades.Ofertas BuscarPorId(Guid id);
    }
}
