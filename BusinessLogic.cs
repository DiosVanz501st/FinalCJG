namespace Final2;
using System.Data;
using MySql.Data.MySqlClient;
using Azure;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        GuiTier appGUI = new GuiTier();
        DataTier database = new DataTier();

        
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    
                    case 1:
                        DataTable tableDelivery = database.CheckRecord(user);
                        if(tableDelivery != null)
                            appGUI.DisplayDelivery(tableDelivery);
                        break;
                    
                    case 2:
                        Console.WriteLine("Add a Package");
                        break;
                    
                    case 3:
                        Console.WriteLine("Drop a Package");
                        break;
                    
                     case 4:
                        Console.WriteLine("Send out Email");
                        break;
                    
                    case 5:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
    string serviceConnectionString =  "endpoint=https://cgomezcommunicationservice.communication.azure.com/;accesskey=8/69Hn7m8CUXmPG8tPIa2/Adhi4n2a8cGiCz8FlBYETJ1i9HAQtBSdzxBMEz8s4Sq6BmjKQfHQFfkgpTlSYGvQ==";
        EmailClient emailClient = new EmailClient(serviceConnectionString);
        var subject = "Hell this is the leasing office";
        var emailContent = new EmailContent(subject);
        
        emailContent.Html = @"
                    <html>
                        <body>
                            <h1 style=color:red>Your package is ready for you to pick up</h1>
                            <h4>This is a HTML content</h4>
                            <p>Thank you!</p>
                        </body>
                    </html>";

        


}

