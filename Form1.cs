using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonogramGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           /* dataGridView1.Columns[0].Name = "Название";
            dataGridView1.Columns[1].Name = "Изображение";*/
        }
        Bitmap img;
        string[] rows;
        string[] cols;

        private void button1_Click(object sender, EventArgs e) //основной метод, открывает диалог выбора изображения и из него делает кроссворд
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения (*.png)|*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    parseImage(new Bitmap(openFileDialog.FileName), openFileDialog.FileName, true);
                }

            }
        }
        private void parseImage(Bitmap img, string name, Boolean save)
        {

            if (img.Height % 5 != 0 || img.Width % 5 != 0)
            {
                MessageBox.Show("Неверное изображение!", "Ошибка!");
                return;
            }
            int colC = 0;
            int w = img.Width;
            int h = img.Height;
            var rowsStr = string.Empty;
            var colsStr = string.Empty;
            rows = new string[h];
            cols = new string[w];
            for (int i = 0; i < h; i++) //используем алгоритм для рядов
            {
                int rowC = 0;
                for (int j = 0; j < w; j++)
                {
                    var currP = img.GetPixel(j, i);
                    var currRowN = 0;
                    if (isWhiteOrTransparent(currP))
                    {
                        if (rowC > 0)
                        {
                            rows[i] += rowC + " ";
                            rowC = currRowN;
                        }
                    }
                    else
                    {
                        if (isBlack(currP))
                        {
                            rowC++;
                        }
                        else
                        {
                            MessageBox.Show("Неверное изображение!", "Ошибка!");
                            return;
                        }
                    }

                }
            }
            foreach (var row in rows)
            {
                rowsStr += row + "\n";
            }
            MessageBox.Show(rowsStr, "Ряды:");
            for (int j = 0; j < w; j++)//используем алгоритм для колонок
            {
                int rowC = 0;
                var currCol = 0;
                for (int i = 0; i < h; i++)
                {
                    var currP = img.GetPixel(j, i);
                    var currRowN = 0;
                    if (isWhiteOrTransparent(currP))
                    {
                        if (rowC > 0)
                        {
                            cols[i] += rowC + " ";
                            rowC = currRowN;
                        }
                    }
                    else
                    {
                        if (isBlack(currP))
                        {
                            rowC++;
                        }
                        else
                        {
                            MessageBox.Show("Неверное изображение!", "Ошибка!");
                            return;
                        }
                    }
                }

            }
            foreach (var row in cols)
            {
                colsStr += row + "\t";
            }
            MessageBox.Show(colsStr, "Колонки:");
            object[] new_row = { name, img };
            if(save)dataGridView1.Rows.Add(new_row);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex].Cells;
            parseImage((Bitmap)row[1].Value, (string)row[0].Value, false);
        }
        private bool isWhiteOrTransparent(Color c) //проверка, белый или пустой ли пиксель
        {
            if (c.A == 0) return true;
            if (c.R == 255 && c.G == 255 && c.B == 255) return true;
             return false;
        }
        private bool isBlack(Color c) //проверка, черный ли пиксель
        {
            if (c.R == 0 && c.G == 0 && c.B == 0) return true;
            return false;
        }
    }
}
