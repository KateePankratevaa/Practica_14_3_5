using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRACTICA14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
               
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n=0;
           
            if(textBox1.Text ==" ")
            {
                MessageBox.Show("Пустое поле");
                n = Convert.ToInt32(textBox1.Text);
            }
            Queue Q = new Queue();
            n = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i < n; i++)
            {

                Q.Enqueue(i);
                label2.Text = ("Размер очереди равно " + Q.Count);
                label3.Text = ("Верхний элемент в очереди" + Q.Peek());
                label4.Text = ("Содержимое равно ");
                while (Q.Count != 0)
                {
                    label5.Text ="{0}"+Q.Dequeue();
                }
                label6.Text = ("Новая размерность " + Q.Count);
            }
        }

        Queue<string[]> peopleQueue;


        private void Display()
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Фамилия");
            datatable.Columns.Add("Имя");
            datatable.Columns.Add("Отчество");
            datatable.Columns.Add("Возраст");
            datatable.Columns.Add("Вес");
            foreach (var person in peopleQueue)
            {
                datatable.Rows.Add(person[0], person[1], person[2], person[3], person[4]);
            }
            dataGridView1.DataSource = datatable;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            peopleQueue = new Queue<string[]>();
            using (var sr = new StreamReader("text.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line.Length == 0)
                    {
                        MessageBox.Show("Файл пуст");
                    }
                    else
                    {
                        var parts = line.Split(' ');
                        peopleQueue.Enqueue(parts);
                    }
                }
                Display();
            }
        }

        private void SortYiungButton_Click(object sender, EventArgs e)
        {
            var youngPerson = new Queue<string[]>();
            var oldPerson = new Queue<string[]>();
            foreach (var person in peopleQueue)
            {
                var age = int.Parse(person[3]);
                if (age < numericUpDown1.Value)
                {
                    youngPerson.Enqueue(person);
                }
                else
                {
                    oldPerson.Enqueue(person);
                }
                peopleQueue = new Queue<string[]>(youngPerson.Concat(oldPerson));

            }
            Display();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            var list = peopleQueue.ToList();
            list.Sort((a, b) => int.Parse(a[3]).CompareTo(int.Parse(b[3])));
            peopleQueue = new Queue<string[]>(list);
            Display();
        }
    }
}
