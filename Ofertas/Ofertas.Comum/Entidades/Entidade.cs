﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Ofertas.Comum.Entidades
{
    public class Entidade : Notifiable
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
