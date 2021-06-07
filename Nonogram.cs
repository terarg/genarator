using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace NonogramGen
{
    
    class Nonogram: ISerializable
    {
        int[,] rows; //ряды
        int[,] cols; // колонки
        public Nonogram(int[,] rows, int[,] cols) //конструктор
        {
            this.cols = cols;
            this.cols = cols;
        }

        public void Serialize(string path) //сохраняем кроссворд в файл
        {
            var workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Nonogram";
           
        }
         public Nonogram Deserialize(string path) //этот метод в листинг не надо я хз как его писать (но он по идее считывает кроссворд из файла)
        {
             return new Nonogram(new int[5,5], new int[5,5]);
         }
        public string RowToString(int[] row) //метод, форматирующий значения ряда(или колонки) в строку
        {
            string text = "";
            for(int i =0; i<row.Length; i++)
            {
                text += row[i] + " ";
            }
            return text;
        }
    }
}
