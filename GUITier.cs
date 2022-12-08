namespace Final2;
using System.Data;
using MySql.Data.MySqlClient;
class GuiTier{
    User user = new User();
    DataTier database = new DataTier();

    
    public User Login(){
        Console.WriteLine("------Package Mangament System------");
        Console.WriteLine("Please input user ID: ");
        user.userID = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Please input password: ");
        user.userPassword = Console.ReadLine();
        return user;
    }
    
    public int Dashboard(User user){
        DateTime localDate = DateTime.Now;
        Console.WriteLine("---------------Dashboard-------------------");
        Console.WriteLine($"Hello: {user.userID}; Date/Time: {localDate.ToString()}");
        Console.WriteLine("Please select an option to continue:");
        Console.WriteLine("1. Check Records");
        Console.WriteLine("2. Add A Package");
        Console.WriteLine("3. Drop A Package");
        Console.WriteLine("4. Send Email");
        Console.WriteLine("5. Log Out");
        int option = Convert.ToInt16(Console.ReadLine());
        return option;
    }

    
    public void DisplayDelivery(DataTable tableDelivery){
        Console.WriteLine("---------------Delivery List-------------------");
        foreach(DataRow row in tableDelivery.Rows){
           Console.WriteLine($"Package_id: {row["Package_id"]} \t Package Agency: {row["PackageAgency"]} \t Unit{row["Unit"]}");
        }
    }
}

