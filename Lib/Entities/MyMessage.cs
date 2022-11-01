using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WinFormsServer.Entities
{
    [Serializable]
    public class MyMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }
        public string Msg { get; set; }
        public DateTime time { get; set; }
        public MyMessage ()
        {
            time = DateTime.Now.ToLocalTime();
        }
        public override string ToString()
        {
            return Msg+"/n"+time;
        }

    }
}
