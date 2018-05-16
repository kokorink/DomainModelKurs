using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAPI.ApiModel
{
   public class Questions
   {
        public int Id { get; set; }
        public DateTime TimeQuestion { get; set; }
        public string Question { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
    }
}
