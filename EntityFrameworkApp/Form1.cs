﻿using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
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
        private readonly IStudent _studentImplementation;
        private readonly IAddress _addressImplementation;

        public Form1()
        {
            InitializeComponent();
            var serviceProvider = ServiceProviderFactory.ServiceProvider;
            _studentImplementation = serviceProvider.GetService<IStudent>();
            _addressImplementation = serviceProvider.GetService<IAddress>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = _studentImplementation.GetAll();
            var studentViewModels = students.Select(s => new
            {
                s.IdStudent,
                s.LastName,
                s.FirstName,
                s.Patronymic,
                FullAddress = (s.AddressObject?.Name ?? "") + " " +
                (s.AddressObject?.City ?? "") + " " +
                (s.AddressObject?.State ?? "") + " " +
                (s.AddressObject?.ZipCode ?? "")
            }).ToList();

            guna2DataGridView1.DataSource = studentViewModels.ToList();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var address = new Address
            {
                Name = AddressName.Text,
                City = AddressCity.Text,
                State = AddressState.Text,
                ZipCode = AddressZipCode.Text,
            };
            _addressImplementation.Add(address);

            var student = new Student
            {
                LastName = LastName.Text,
                FirstName = FirstName.Text,
                Patronymic = Patronymic.Text,
                AddressId = address.IdAddress
            };
            _studentImplementation.Add(student);
            LoadStudents();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!ValidationStudent())
            {
                MessageBox.Show("Персональные данные не могут быть пустыми.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRow = guna2DataGridView1.SelectedRows[0];
            int studentId = (int)selectedRow.Cells["IdStudent"].Value;

            var student = _studentImplementation.GetById(studentId);

            if (student != null)
            {
                student.LastName = LastName.Text;
                student.FirstName = FirstName.Text;
                student.Patronymic = Patronymic.Text;
                
                if(student.AddressObject == null)
                {
                    student.AddressObject = new Address();
                }

                student.AddressObject.Name = AddressName.Text;
                student.AddressObject.City = AddressCity.Text;
                student.AddressObject.State = AddressState.Text;
                student.AddressObject.ZipCode = AddressZipCode.Text;

                _studentImplementation.Update(student);

                LoadStudents();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];
                int studentId = (int)selectedRow.Cells["IdStudent"].Value;

                var student = _studentImplementation.GetById(studentId);

                if (student != null)
                {
                    LastName.Text = student.LastName;
                    FirstName.Text = student.FirstName;
                    Patronymic.Text = student.Patronymic;

                    if (student.AddressObject != null)
                    {
                        AddressName.Text = student.AddressObject.Name;
                        AddressCity.Text = student.AddressObject.City;
                        AddressState.Text = student.AddressObject.State;
                        AddressZipCode.Text = student.AddressObject.ZipCode;
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var student = (Student)guna2DataGridView1.SelectedRows[0].DataBoundItem;
                _studentImplementation.Delete(student.IdStudent);
                LoadStudents();
            }
        }

        private bool ValidationStudent()
        {
            return new[] { LastName.Text, FirstName.Text, Patronymic.Text }.All(text => !string.IsNullOrEmpty(text));
        }
    }
}
