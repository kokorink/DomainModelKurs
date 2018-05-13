﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class QuestionsAnswersModel
    {
        public DateTime? TimeAnswer { get; set; }
        public string Answer { get; set; }
        public int Id { get; set; }
        public DateTime TimeQuestion { get; set; }
        public string Question { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }

    }
}