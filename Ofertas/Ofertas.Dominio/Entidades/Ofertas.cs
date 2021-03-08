﻿using Flunt.Validations;
using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Dominios.Entidades
{
    public class Ofertas : Entidade
    {
        public Ofertas(string nomeProduto, string descricao, string imagem, bool ativo, Guid idUsuario, Usuario usuario, string preco, string precoAntigo, DateTime dataValidade, bool disponivelDoacao, int estoqueTotal, EnCategoria categoria)
        {
            NomeProduto = nomeProduto;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
            IdUsuario = idUsuario;
            Usuario = usuario;
            Preco = preco;
            PrecoAntigo = precoAntigo;
            DataValidade = dataValidade;
            DisponivelDoacao = disponivelDoacao;
            EstoqueTotal = estoqueTotal;
            Categoria = categoria;
        }

        public string NomeProduto { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdUsuario { get; private set; }//emoresa
        public virtual Usuario Usuario { get; private set; }
        public string Preco { get; private set; }// em R$ e p/unidade
        public string PrecoAntigo { get; private set; }// em R$ e p/unidade
        public DateTime DataValidade { get; private set; }
        public bool DisponivelDoacao { get; private set; }
        public int EstoqueTotal { get; private set; }
        public EnCategoria Categoria { get; private set; }
    }
}
