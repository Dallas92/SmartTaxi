using System;
using Mono.Data.Sqlite;
using System.IO;

namespace SmartTaxi.iOS
{
	public class SQLiteHelper
	{
		public SQLiteHelper ()
		{
		}

		private void CreateSQLiteDatabase (string databaseFile)
		{
			try
			{
				if (!File.Exists (databaseFile))
				{
					SqliteConnection.CreateFile (databaseFile);
					using (SqliteConnection sqlCon = new SqliteConnection
						(String.Format ("Data Source = {0};",
							databaseFile)))
					{
						sqlCon.Open ();
						using (SqliteCommand sqlCom = new SqliteCommand
							(sqlCon))
						{
							sqlCom.CommandText = "CREATE TABLE Customers (ID " +
								"INTEGER PRIMARY KEY, FirstName VARCHAR(20), " +
							"LastName VARCHAR(20))";
							sqlCom.ExecuteNonQuery ();
						}
						sqlCon.Close ();
					}
					//this.lblStatus.Text = "Database created!";
				} else {
					//this.lblStatus.Text = "Database already exists!";
				}
			} catch (Exception ex) {
				//this.lblStatus.Text = String.Format ("Sqlite error: {0}", ex.Message);
			}
		}
	}
}

