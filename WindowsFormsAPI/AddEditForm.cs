using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAPI.ApiModel;
using System.Net.Http;
using Newtonsoft.Json;


namespace WindowsFormsAPI
{
    public partial class AddEditForm : Form
    {
        public Questions item = new Questions();
        public AddEditForm()
        {

            InitializeComponent();

         }

        public AddEditForm(Questions question)
        {
            InitializeComponent();
            item = question;
            textBoxQuestion.Text = question.Question;
            textBoxMail.Text = question.UserMail;
            textBoxName.Text = question.UserName;



        }

        private void buttonОК_Click(object sender, EventArgs e)
        {
            item.Question = textBoxQuestion.Text;
            item.UserMail = textBoxMail.Text;
            item.UserName = textBoxName.Text;
           
            this.Close();
        }
            
    }
}
