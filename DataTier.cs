namespace Final2;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
class DataTier{
    public string connStr = "server=20.172.0.16;user=cjgomez2;database=cjgomez2;port=8080;password=cjgomez2";

    
    public bool LoginCheck(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {  
            conn.Open();
            string procedure = "LoginCount";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@inputUserID", user.userID);
            cmd.Parameters.AddWithValue("@inputUserPassword", user.userPassword);
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction =  ParameterDirection.Output;
            MySqlDataReader rdr = cmd.ExecuteReader();
           
            int returnCount = (int) cmd.Parameters["@userCount"].Value;
            rdr.Close();
            conn.Close();

            if (returnCount ==1){
                return true;
            }
            else{
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return false;
        }
       
    }
    public DataTable CheckRecord(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Check Record");
        string semester = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "CheckRecord";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputResidentID", user.userID);
            cmd.Parameters["@inputResidentID"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@input", semester);
            cmd.Parameters["@inputSemester"].Direction = ParameterDirection.Input;

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableDelivery = new DataTable();
            tableDelivery.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableDelivery;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

     public DataTable AddPackage(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("AddPackage");
        string semester = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "AddPackage";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputpackage_id", Package.Package_id);
            cmd.Parameters["@inputpackage_id"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@input", package_unit);
            cmd.Parameters["@inputpackage_unit"].Direction = ParameterDirection.Input;

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableDelivery = new DataTable();
            tableDelivery.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableDelivery;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public DataTable RemovePackage(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("RemovePackage");
        string semester = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "RemovePackage";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputpackage_id", Package.Package_id);
            cmd.Parameters["@inputpackage_id"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@input", package_unit);
            cmd.Parameters["@inputpackage_unit"].Direction = ParameterDirection.Input;

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableDelivery = new DataTable();
            tableDelivery.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableDelivery;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }
   

}


