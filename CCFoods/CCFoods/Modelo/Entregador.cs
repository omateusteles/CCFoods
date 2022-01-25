using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo1.Modelo
{
    public class Entregador
    {
        [PrimaryKey, AutoIncrement]
        public long? EntregadorId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
