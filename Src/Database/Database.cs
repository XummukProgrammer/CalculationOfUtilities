using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

namespace CalculationOfUtilities.Database
{
    public class Database
    {
        public int UserId { private set; get; }

        private SqliteConnection _connection;

        public void Connect()
        {
            _connection = new SqliteConnection("Data Source=DataBase.db");
            _connection.Open();
        }

        public void Disconnect()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }

        public void Initialization()
        {
            if (_connection != null)
            {
                SqliteCommand command = _connection.CreateCommand();
                CreateTables(command);
                CreateTestUser(command);
            }
        }

        public int CreateMount(Core.Context context)
        {
            if (_connection != null)
            {
                SqliteCommand sqlCommand = _connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO mounths (user_id, residents) VALUES(@user_id, @residents); SELECT last_insert_rowid();";
                sqlCommand.Parameters.Add(new SqliteParameter("@user_id", UserId));
                sqlCommand.Parameters.Add(new SqliteParameter("@residents", context.Residents));
                return (int)(long)sqlCommand.ExecuteScalar();
            }
            return -1;
        }

        public int CreateService(Core.Context context, int mountId, string name, float price)
        {
            if (_connection != null)
            {
                SqliteCommand sqlCommand = _connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO services (mounth_id, name, price) VALUES(@mounth_id, @name, @price); SELECT last_insert_rowid();";
                sqlCommand.Parameters.Add(new SqliteParameter("@mounth_id", mountId));
                sqlCommand.Parameters.Add(new SqliteParameter("@name", name));
                sqlCommand.Parameters.Add(new SqliteParameter("@price", price));
                return (int)(long)sqlCommand.ExecuteScalar();
            }
            return -1;
        }

        public int CreateElectricityMeteringDevice(int serviceId, Counter.MeteringDeviceSpan daySpan, Counter.MeteringDeviceSpan nightSpan)
        {
            if (_connection != null)
            {
                SqliteCommand sqlCommand = _connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO electricity_metering_devices " +
                        "(service_id, current_indications_day, prev_indications_day, current_indications_night, prev_indications_night) " +
                        "VALUES(@service_id, @current_indications_day, @prev_indications_day, @current_indications_night, @prev_indications_night);" +
                        "SELECT last_insert_rowid();";
                sqlCommand.Parameters.Add(new SqliteParameter("@service_id", serviceId));
                sqlCommand.Parameters.Add(new SqliteParameter("@current_indications_day", daySpan.CurrentIndications));
                sqlCommand.Parameters.Add(new SqliteParameter("@prev_indications_day", daySpan.PrevIndications));
                sqlCommand.Parameters.Add(new SqliteParameter("@current_indications_night", nightSpan.CurrentIndications));
                sqlCommand.Parameters.Add(new SqliteParameter("@prev_indications_night", nightSpan.PrevIndications));
                return (int)(long)sqlCommand.ExecuteScalar();
            }
            return -1;
        }

        public int CreateMeteringDevice(int serviceId, Counter.MeteringDeviceSpan span)
        {
            if (_connection != null)
            {
                SqliteCommand sqlCommand = _connection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO metering_devices " +
                        "(service_id, current_indications, prev_indications) " +
                        "VALUES(@service_id, @current_indications, @prev_indications); SELECT last_insert_rowid();";
                sqlCommand.Parameters.Add(new SqliteParameter("@service_id", serviceId));
                sqlCommand.Parameters.Add(new SqliteParameter("@current_indications", span.CurrentIndications));
                sqlCommand.Parameters.Add(new SqliteParameter("@prev_indications", span.PrevIndications));
                return (int)(long)sqlCommand.ExecuteScalar();
            }
            return -1;
        }

        private void CreateTables(SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS users(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "login TEXT NOT NULL," +
                    "password TEXT NOT NULL" +
                ")";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS mounths(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "user_id INTEGER NOT NULL," +
                    "residents INTEGER NOT NULL," +
                    "FOREIGN KEY (user_id) REFERENCES users (id)" +
                ")";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS services(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "mounth_id INTEGER NOT NULL," +
                    "name TEXT NOT NULL," +
                    "price FLOAT NOT NULL," +
                    "FOREIGN KEY (mounth_id) REFERENCES mounths (id)" +
                ")";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS electricity_metering_devices(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "service_id INTEGER NOT NULL," +
                    "current_indications_day FLOAT NOT NULL," +
                    "prev_indications_day FLOAT NOT NULL," +
                    "current_indications_night FLOAT NOT NULL," +
                    "prev_indications_night FLOAT NOT NULL," +
                    "FOREIGN KEY (service_id) REFERENCES services (id)" +
                ")";
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = "CREATE TABLE IF NOT EXISTS metering_devices(" +
                    "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE," +
                    "service_id INTEGER NOT NULL," +
                    "current_indications FLOAT NOT NULL," +
                    "prev_indications FLOAT NOT NULL," +
                    "FOREIGN KEY (service_id) REFERENCES services (id)" +
                ")";
            sqlCommand.ExecuteNonQuery();
        }

        private void CreateTestUser(SqliteCommand sqlCommand)
        {
            UserId = GetTestUserID(sqlCommand);
            if (UserId != -1)
            {
                return;
            }

            sqlCommand.CommandText = "INSERT INTO users (login, password) VALUES(@login, @password); SELECT last_insert_rowid();";
            sqlCommand.Parameters.Add(new SqliteParameter("@login", "root"));
            sqlCommand.Parameters.Add(new SqliteParameter("@password", "root"));
            UserId = (int)(long)sqlCommand.ExecuteScalar();
            sqlCommand.Parameters.Clear();

        }

        private int GetTestUserID(SqliteCommand sqlCommand)
        {
            sqlCommand.CommandText = "SELECT id, login FROM users WHERE login = @login";
            sqlCommand.Parameters.Add(new SqliteParameter("@login", "root"));

            using (var reader = sqlCommand.ExecuteReader())
            {
                sqlCommand.Parameters.Clear();
                
                if (reader.HasRows && reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }

            return -1;
        }
    }
}
