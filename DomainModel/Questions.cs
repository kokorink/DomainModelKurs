using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeQuestion { get; set; }
        public string Question { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        //[ForeignKey("Answer")]
        ////[System.Data.Linq.Mapping.Column(CanBeNull = true)]
        //public int IdAnswer { get; set; }
        //public Answers Answers { get; set; }
    }
}
