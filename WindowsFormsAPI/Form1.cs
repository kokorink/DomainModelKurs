using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using WindowsFormsAPI.ApiModel;

namespace WindowsFormsAPI
{
    public partial class Form1 : Form
    {
        Questions question = new Questions();
        private string App_path = "http://localhost:27043/";
        public Form1()
        {
            InitializeComponent();
            IEnumerable<Questions> ss = new List<Questions>() { new Questions() { Id = 1, Question = "sf", TimeQuestion = DateTime.Now, UserMail = "sdf", UserName = "sdf" } };

            var items = GetQuestions();
            dataGridView1.DataSource = items;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditForm f = new AddEditForm();
            f.ShowDialog();
            AddQuestionApi(f.item);

            var items = GetQuestions();
            dataGridView1.DataSource = items;

        }

        public IEnumerable<Questions> GetQuestions()
        {
            using (var client = new HttpClient())
            { 
                var response = client.GetAsync(App_path + "api/questions/").Result;
                return JsonConvert.DeserializeObject<IEnumerable<Questions>>(response.Content.ReadAsStringAsync().Result);
            }
        }
         
        public Questions GetIdApi(int id)
        {
            using (var client = new HttpClient())
            { 
                var response = client.GetAsync(App_path + "api/questions/" + id).Result;
                return JsonConvert.DeserializeObject<Questions>(response.Content.ReadAsStringAsync().Result); 
            }
        }


        public void EditQuestionApi(Questions question)
        {
            using (var client = new HttpClient())
            {
                var response = client.PutAsJsonAsync(App_path + "/api/questions/" + question.Id, question).Result;
            }
        }

        public void AddQuestionApi(Questions question)
        {
            question.TimeQuestion = DateTime.Now;
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(App_path + "/api/questions/", question).Result;
            }
        }

        public void DeleteQuestionApi(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(App_path + "/api/questions/" + id).Result;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var indexItem = Convert.ToInt16(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var but = (DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex];
                if (but.Text == "Изменить")
                {
                    question = GetIdApi(indexItem);
                    AddEditForm f = new AddEditForm(question);
                    f.ShowDialog();
                    EditQuestionApi(f.item);


            }

            else
            {
                    DeleteQuestionApi(indexItem);

            }

            var items = GetQuestions();
                dataGridView1.DataSource = items;

            }
        }
    }
}
