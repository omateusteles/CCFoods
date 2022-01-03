using Modulo1.Android;
using Modulo1.Infraestructure;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Modulo1.Android
{
	public class DatabaseConnection_Android : IDatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CCFoodsDb.db");
			return new SQLiteConnection(path);
		}
	}
}