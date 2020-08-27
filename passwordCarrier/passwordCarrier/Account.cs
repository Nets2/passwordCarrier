using System.ComponentModel;
using System.Runtime.Remoting.Activation;

namespace passwordCarrier
{
    public class Account
    {
        /* ItemName : url : Login : password : e-mail : question secrete : réponse */
        public Account(string itemName,string email,  PasswordPropertyTextAttribute password, UrlAttribute url=null, string question="", string answer="")
        {
            ItemName = itemName;
            Url = url;
            Password = password;
            Email = email;
            Question = question;
            Answer = answer;
        }

        public string ItemName { get; private set; }
        public UrlAttribute Url { get; private set; }
        public PasswordPropertyTextAttribute Password { get; private set; }
        public string Email { get; private set; }
        public string Question { get; private set; }
        public string Answer { get; private set; }
        
        
        
    }
}