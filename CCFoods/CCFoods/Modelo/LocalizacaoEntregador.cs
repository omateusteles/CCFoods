using Modulo1.Modelo.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace Modulo1.Modelo
{
    public class LocalizacaoEntregador
    {
        [PrimaryKey, AutoIncrement]
        public long? LocalizacaoId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long? EntityId { get; set; }
        public OperacaoSincronismo OperacaoSincronismo { get; set; }

        /*
               [ForeignKey(typeof(Entregador))]
               public long? EntregadorId { get; set; }

               [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
               public Entregador Entregador { get; set; }

               [ForeignKey(typeof(Pedido))]
               public long? PedidoId { get; set; }

               [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
               public Pedido Pedido { get; set; }
        */

        public override bool Equals(object obj)
        {
            var localizacao = obj as LocalizacaoEntregador;
            return this.LocalizacaoId.Equals(localizacao.LocalizacaoId);
        }
    }
}
