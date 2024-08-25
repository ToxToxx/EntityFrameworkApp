using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using EntityFrameworkApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkApp
{
    public partial class Form1 : Form
    {
        private readonly IStudent _studentRepository;
        public Form1()
        {
            InitializeComponent();
            var serviceProvider = ServiceProviderFactory.ServiceProvider;
            _studentRepository = serviceProvider.GetService<IStudent>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadStudents()
        {
            var students = _studentRepository.GetAll();
            guna2DataGridView1.DataSource = students.ToList();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                LastName = LastName.Text,
                FirstName = FirstName.Text,
                Patronymic = Patronymic.Text,
                AddressId = int Parse(AddressId.Text)
            };
            _studentRepository.Add(student);
            LoadStudents();
            
        }
    }
}
