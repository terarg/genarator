using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramGen
{
    class BitmapImage: ISerializable //класс изображения
    {
        Bitmap img;

        public BitmapImage(Bitmap img) //конструктор
        {
            this.img = img;
        }

        public void Serialize(string path)//сохраням в файл
        {
            img.Save(path, ImageFormat.Png);
        }
        public BitmapImage Deserialize(string path) // читаем из файла
        {
            return new BitmapImage(new Bitmap(path));
        }
    }
}
