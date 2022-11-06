using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FormsServer.Entities;

namespace FormsServer.Entities
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<MyMessage> Messages { get; set; }
        public Guid GroupId;
        public Guid ChatId;
        public User(string login,string password)
        {
            Login = login;
            Password = password;
            Messages = new List<MyMessage>();
        }
        public override string ToString()
        {
            return Login;
        }

    }
}
