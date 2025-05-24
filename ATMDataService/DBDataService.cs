using ATMCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;

namespace ATMDataService
{
    class DBDataService : IBankDataService
    {
        //connectionString
        static string connectionString
        = "Data Source =INDALEEN\\SQLEXPRESS; Initial Catalog = ATM; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public void CreateAccount(BankAccount bankAccount)
        {
            var insertStatement = "INSERT INTO BankDetails VALUES (@AccountNumber, @AccountName, @Bank, @PIN, @Balance)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@AccountNumber", bankAccount.Number);
            insertCommand.Parameters.AddWithValue("@AccountName", bankAccount.Name);
            insertCommand.Parameters.AddWithValue("@Bank", bankAccount.Bank);
            insertCommand.Parameters.AddWithValue("@PIN", bankAccount.PIN);
            insertCommand.Parameters.AddWithValue("@Balance", bankAccount.Balance);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

        }

        public List<BankAccount> GetAccounts()
        {
            string selectStatement = "SELECT AccountNumber, AccountName, Bank, PIN, Balance FROM BankDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var bankAccounts = new List<BankAccount>();

            while (reader.Read())
            {
                //deserialize

                BankAccount bankAccount = new BankAccount();
                bankAccount.Name = reader["AccountName"].ToString();
                bankAccount.Number = reader["AccountNumber"].ToString();
                bankAccount.PIN = reader["PIN"].ToString();
                bankAccount.Balance = Convert.ToDouble(reader["Balance"].ToString());
                bankAccount.Bank = reader["Bank"].ToString();

                bankAccounts.Add(bankAccount);
            }

            sqlConnection.Close();
            return bankAccounts;

        }

        public void RemoveAccount(BankAccount bankAccount)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM BankDetails WHERE AccountNumber = @AccountNumber";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@AccountNumber", bankAccount.Number);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateAccount(BankAccount bankAccount)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE BankDetails SET AccountName = @AccountName, Balance = @Balance, Bank = @Bank WHERE AccountNumber = @AccountNumber";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@AccountName", bankAccount.Name);
            updateCommand.Parameters.AddWithValue("@Balance", bankAccount.Balance);
            updateCommand.Parameters.AddWithValue("@Bank", bankAccount.Bank);
            updateCommand.Parameters.AddWithValue("@AccountNumber", bankAccount.Number);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
