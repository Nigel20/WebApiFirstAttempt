using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApiFirstAttempt.Models
{
    public class ShoppingListModel
    {
        public string ItemName { get; set; }
        public int ItemQnty { get; set; }
        public string ItemDesc { get; set; }

        public enum DBOperation
        {
            Select = 1,
            SelectAll = 2,
            Insert = 3,
            Update = 4,
            Delete = 5
        }

        public int DBItems(DBOperation DBOp)
        {
            MySqlConnection Con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString);
            MySqlCommand Cmd = new MySqlCommand();
            try
            {

                Cmd.Connection = Con;
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                MySqlParameter MSP = new MySqlParameter();

                MSP.ParameterName = "ItemName";
                MSP.MySqlDbType = MySqlDbType.VarChar;
                MSP.Value = ItemName;
                Cmd.Parameters.Add(MSP);

                MSP = new MySqlParameter();
                MSP.ParameterName = "ItemQnty";
                MSP.MySqlDbType = MySqlDbType.Int32;
                MSP.Value = ItemQnty;
                Cmd.Parameters.Add(MSP);

                MSP = new MySqlParameter();
                MSP.ParameterName = "ItemDesc";
                MSP.MySqlDbType = MySqlDbType.VarChar;
                MSP.Value = ItemDesc;
                Cmd.Parameters.Add(MSP);

                switch (DBOp)
                {
                    case DBOperation.Select:
                        Cmd.CommandText = "SelectShoppingList";
                        break;
                    case DBOperation.SelectAll:
                        Cmd.CommandText = "SelectAShoppingList";
                        break;
                    case DBOperation.Insert:
                        Cmd.CommandText = "InsertShoppingList";
                        break;
                    case DBOperation.Update:
                        Cmd.CommandText = "UpdateShoppingList";
                        break;
                    case DBOperation.Delete:
                        Cmd.CommandText = "DeleteShoppingList";
                        break;
                    default:
                        break;
                }              

                Con.Open();
                return Cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                if (Con.State != System.Data.ConnectionState.Closed)
                {
                    Con.Close();
                }
                return 0;
            }
            finally
            {
                Con = null;
                Cmd = null;
            }
        }

    }
}