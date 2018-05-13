using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Answers
    {
        public DateTime TimeAnswer { get; set; }
        public string Answer { get; set; }
        [Key]
        [ForeignKey("Questions")]
        public int IdQuestions { get; set; }
        public Questions Questions { get; set; }
    }
}
