using System.Drawing.Imaging;

namespace MyReisinLapTimes
{
    internal class Car
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public string Tires { get; set; }
        public string Photo { get; set; }

        public Car()
        {
            Name = string.Empty;
            Time = string.Empty;
            Tires = string.Empty;
            Photo = string.Empty;
        }

        public Car(string carName, string timestamp, string tiresType, Image img)
        {
            Name = carName;
            Time = timestamp;
            Tires = tiresType;
            Photo = SaveImage(img);
        }

        private static string SaveImage(Image image)
        {
            using MemoryStream ms = new();
            image.Save(ms, ImageFormat.Png);

            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

        public Image LoadImage()
        {
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(Photo)));
        }
    }
}
