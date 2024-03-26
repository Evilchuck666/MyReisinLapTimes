using System.Drawing.Imaging;
using System.Text.Json;

namespace MyReisinLapTimes
{
    internal class Helper
    {
        public static void LoadList(List<Car> list, ListView LstView, bool top)
        {
            foreach (var car in list)
            {
                string[] row;
                if (top)
                {
                    row = new string[] { car.Name, car.Time };
                }
                else
                {
                    row = new string[] { car.Name, car.Tires, car.Time };
                }

                ListViewItem item = new(row);
                LstView.Items.Add(item);
            }
        }

        public static List<Car> OrderList(List<Car> list, string? filter = null)
        {
            if (filter != null && (filter.Trim()).Length > 0)
            {
                return list.Where(car => car.Tires == filter).OrderBy<Car, TimeSpan>(car => TimeSpan.Parse(car.Time), new TimeSpanComparer()).ToList();
            }
            return list.OrderBy<Car, TimeSpan>(car => TimeSpan.Parse(car.Time), new TimeSpanComparer()).ToList();
        }

        public static Image ScaleImage(Image image)
        {
            Bitmap scaled = new(200, 200);
            using (Graphics g = Graphics.FromImage(scaled))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, 200, 200);
            }
            return scaled;
        }

        public static void ResetControls(TextBox TxtCar, TextBox TxtTime, RadioButton RadRace, RadioButton RadStreet, PictureBox ImgCar)
        {
            TxtCar.Text = string.Empty;
            TxtTime.Text = string.Empty;
            RadRace.Checked = false;
            RadStreet.Checked = false;
            ImgCar.Image = null;
        }

        public static List<Car>? Deserialize()
        {
            try
            {
                string localAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyReisin");
                Directory.CreateDirectory(localAppDataPath);

                string filePath = Path.Combine(localAppDataPath, "data.json");
                string json = File.ReadAllText(filePath).Trim();

                return JsonSerializer.Deserialize<List<Car>>(json);
            }
            catch (Exception)
            {
                return new List<Car>();
            }
        }

        public static void Serialize(List<Car> cars)
        {
            string localAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyReisin");
            Directory.CreateDirectory(localAppDataPath);

            string jsonData = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(localAppDataPath, "data.json");

            File.WriteAllText(filePath, jsonData);
        }

        public static void ValidateForm(TextBox TxtCar, TextBox TxtTime, RadioButton RadRace, RadioButton RadStreet, PictureBox ImgCar)
        {
            if (TxtCar.Text.Length == 0)
            {
                throw new Exception("Please, write a name for your car");
            }

            if (TxtTime.Text.Length == 0)
            {
                throw new Exception("Please, write the time of your car");
            }

            if (!RadRace.Checked && !RadStreet.Checked)
            {
                throw new Exception("Please, select the type of your tires");
            }

            if (ImgCar.Image == null)
            {
                throw new Exception("Please upload an image before adding a car and its lap time.");
            }
        }
    }
}
