using Modulo1.Infraestructure;
using Modulo1.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Modulo1.DAL
{
    public class LocalizacaoEntregadorDAL
    {
        private SQLiteConnection sqlConnection;

        public LocalizacaoEntregadorDAL ()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<LocalizacaoEntregador>();
        }

        public void Update(LocalizacaoEntregador localizacao)
        {
            this.sqlConnection.Update(localizacao);
        }
        private long GetMaxId()
        {
            var id = sqlConnection.Table<LocalizacaoEntregador>().Max(g => g.EntityId);
            return Convert.ToInt32(id) + 1;
        }
        public void Add(LocalizacaoEntregador localizacao)
        {
            localizacao.EntityId = GetMaxId();
            localizacao.OperacaoSincronismo = Modelo.Enums.OperacaoSincronismo.InseridoDispositivo;
            sqlConnection.Insert(localizacao);
        }

        public IEnumerable<LocalizacaoEntregador> GetAll()
        {
            return (from t in sqlConnection.Table<LocalizacaoEntregador>() select t).OrderBy(i => i.LocalizacaoId).ToList();
        }

        public IEnumerable<LocalizacaoEntregador> GetAllInseridoDispositivo()
        {
            return (from t in sqlConnection.Table<LocalizacaoEntregador>()
                    where t.OperacaoSincronismo == Modelo.Enums.OperacaoSincronismo.InseridoDispositivo
                    select t).OrderBy(i => i.LocalizacaoId).ToList();
        }
    }
}
