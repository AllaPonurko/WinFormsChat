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
        public ICollection<string> Messages { get; set; }
        public Guid GroupId;
        
        public User()
        {
            Messages = new List<string>();
        }
        public override string ToString()
        {
            return Login;
        }

    }
}
