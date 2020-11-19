using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Лабораторная_1_аттестация
{
    public partial class Form1 : Form
    {      
        public int min, max;
        public int min2, max2;
        Random rnd;


        public Form1()
        {
            InitializeComponent();
        }

        //Вызываемые функции
        public void ClearError()
        {
            Error.Text = "";
        }

        public void ErrorColor()
        {
            Error.BackColor = Error.BackColor;
            Error.ForeColor = Color.Red;
        }

        
        public void CallMessageBox(string MessageText, string Cuption, string ErrorText )
        {
            string message = MessageText;
            string cuption = Cuption;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (message != "")
            {
                MessageBox.Show(message, cuption, buttons);
            }
            else 
            {
                Error.Text = ErrorText;
            }
        }


        //Выыод сообщения
        private void button1_Click(object sender, EventArgs e)
        {
            ErrorColor();
            ClearError();
            CallMessageBox(textBox1.Text, "Cообщение", "Поле ввода сообщения пустое! Введите текст для вывода сообщения!");
            

        }


        // Одномерный массив
        private void button2_Click(object sender, EventArgs e)
        {

            textBox2.Text = null;
            textBox2.Clear();

            ErrorColor();
            ClearError();

            int ec = 0;
           
            if (textBox3.Text != "" && Int32.TryParse(textBox3.Text, out ec) && ec != 0 && ec > 0 && Int32.TryParse(textBox4.Text, out min) && Int32.TryParse(textBox5.Text, out max) && min <= max)
            {
                int[] array = new int[ec];
                Random rnd = new Random();

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(min, max + 1);
                    textBox2.Text += Convert.ToString(array[i]) + "; ";
                }
            }

            else
            {
                Error.Text = "Не верно введены длина или диапазон массива! ";
            }
        }

        //Удаление одномерного массива
        private void button3_Click(object sender, EventArgs e)
        {
            ErrorColor();
            ClearError();

            textBox2.Text = null;
            textBox2.Clear();
            textBox3.Text = null;
            textBox3.Clear();
            textBox4.Text = null;
            textBox4.Clear();
            textBox5.Text = null;
            textBox5.Clear();
        }




        //Двумерный массив
        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox10.Clear();

            ErrorColor();
            ClearError();

            int rows = 0;
            int columns = 0;
            
            if (textBox6.Text != "" && Int32.TryParse(textBox6.Text, out rows) && rows != 0 && rows > 0 && textBox9.Text != "" && Int32.TryParse(textBox9.Text, out columns) && columns != 0 && columns > 0 && Int32.TryParse(textBox7.Text, out min2) && Int32.TryParse(textBox8.Text, out max2) && min2 <= max2)
            {
                int[,] array2 = new int[rows, columns];
                rnd = new Random();

                //Дмумерный массив через for

                /* for (int k = 0; k < rows; k++)
                 {
                     for (int j = 0; j < columns; j++)
                     {
                         massive2[k, j] = rnd.Next(min2, max2 + 1);
                         textBox10.Text += "  " + massive2[k, j].ToString() + "\t";
                     }
                     textBox10.Text += "\r\n";
                 } */

                //Двумерный масив через while

                int k = 0;
                int j = 0;

                while (k < rows)
                {
                                     
                    while (j < columns)
                    {                      
                       array2[k, j] = rnd.Next(min2, max2 + 1);
                       textBox10.Text += "  " + array2[k, j].ToString() + "\t";
                       j++;
                    }
                    k++;
                    j = 0;
                    textBox10.Text += "\r\n";
                }               
            }
            else
            {
                Error.Text = "Не верно введены длина или диапазон двумерного массива!";
            }
        }
   

        //Удаление двумерного массива
        private void button5_Click(object sender, EventArgs e)
        {
            ErrorColor();
            ClearError();

            textBox6.Text = null;
            textBox6.Clear();
            textBox7.Text = null;
            textBox7.Clear();
            textBox8.Text = null;
            textBox8.Clear();
            textBox9.Text = null;
            textBox9.Clear();
            textBox10.Text = null;
            textBox10.Clear();
           
        }

       

        //Запись двумерного массива в файл
        private void button6_Click(object sender, EventArgs e)
        {
            ErrorColor();
            ClearError();
            DialogResult result = openFileDialog1.ShowDialog();

            if (textBox10.Text != "" && result == DialogResult.OK)
            {
                string directory = openFileDialog1.FileName;
                try
                {
                    using (StreamWriter sw = new StreamWriter(directory, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(textBox10.Text);
                    }
                    CallMessageBox("Запись в файл завершена", "Запись в файл", "");
                }
                catch (Exception exc)
                {
                    Error.Text = "Не удалось записать массив в файл!";
                }
            }
            else
            {
                Error.Text = "Сначала сгенерируйте массив!";
            }
        }                
    }
}
