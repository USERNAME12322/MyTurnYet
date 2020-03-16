using System.Configuration;

namespace MyTurnYet.Database
{
    public class Connectionstring
    {
        public static string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
    }
}