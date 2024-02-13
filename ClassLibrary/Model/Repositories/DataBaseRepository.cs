using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Work
{
    class DataBaseRepository : IRepository
    {
        const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=""./Repositories/Bicycles.accdb""";
        string queryString = "Select * From Bicycles, BicycleFrame";
        public RepositoryType TypeOfRepository => RepositoryType.SQL;
        bool isClear;
        public bool IsClear
        {
            get
            {
                return isClear;
            }
            private set
            {
                isClear = value;
            }
        }

        public DataBaseRepository()
        {

        }

        public void CreateRepository()
        {

        }

        public void ReadRepository(ObservableCollection<Bicycle> s)
        {
            //using (OleDbConnection connection = new OleDbConnection(connectionString))
            //{
            //    OleDbCommand command = new OleDbCommand(queryString, connection);

            //    connection.Open();
            //    OleDbDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {

            //    }
            //    reader.Close();
            //}
        }

        public void UpdateRepository(ObservableCollection<Bicycle> s)
        {
            MessageBox.Show(connectionString);

            //string insertSQL = "INSERT INTO BicycleFrame VALUES (@id_from_bicycle,@material,@size)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                foreach (Bicycle b in s)
                {
                    string insertSQL = string.Format("INSERT INTO BicycleFrame VALUES ('{0}', '{1}', '{2}')", b.ID, b.Frame.Material, b.Frame.Size);
                    //command.Parameters.AddWithValue("@id_from_bicycle", b.ID);
                    //command.Parameters.Add("@material", OleDbType.Char).Value = b.Frame.Material.ToCharArray();
                    //command.Parameters.Add("@size", OleDbType.Integer).Value = b.Frame.Size;

                    using (OleDbCommand command = new OleDbCommand(insertSQL, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public void DeleteDataRepository(ObservableCollection<Bicycle> s)
        {

        }
    }
}
