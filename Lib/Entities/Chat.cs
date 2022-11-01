using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WinFormsServer.Entities;

namespace Lib.Entities
{
    [Serializable]
    public class Chat
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id;
        public List<User> Companions { get; set; }
        public List<MyMessage> Correspondence { get; set; }
}
}
