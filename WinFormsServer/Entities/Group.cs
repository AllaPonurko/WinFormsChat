using Lib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FormsServer.Entities
{
    [Serializable]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users;
        public Guid ChatId { get; set; }
        public Group(string name)
        {
            Name = name;
            Users = new List<User>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
