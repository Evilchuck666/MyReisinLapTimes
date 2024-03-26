using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Reflection;

namespace MyReisinLapTimes
{
    internal static class ImageBuilder
    {
        public static readonly string AssemblyLocation = Assembly.GetExecutingAssembly().Location ?? "";
        public static readonly string CurrentDirectory = Path.GetDirectoryName(AssemblyLocation) ?? "";
        public static readonly string AssetsDirectory = Path.Combine(CurrentDirectory, "assets") ?? "";

        public static readonly string[] ImagesPath = {
            Path.Combine(AssetsDirectory, "Top10.png"),
            Path.Combine(AssetsDirectory, "Top10Street.png"),
            Path.Combine(AssetsDirectory, "Top10Race.png")
        };

        public static readonly string[] Titles = { "Top 10", "Top 10 Street", "Top 10 Race" };

        public static readonly Rectangle[] ImageLocations = {
            new(200, 325, 200, 200),
            new(1500, 545, 200, 200),
            new(200, 765, 200, 200),
            new(1500, 985, 200, 200),
            new(200, 1205, 200, 200),
            new(1500, 1425, 200, 200),
            new(200, 1645, 200, 200),
            new(1500, 1865, 200, 200),
            new(200, 2085, 200, 200),
            new(1500, 2305, 200, 200)
        };

        public static readonly PointF[] TextCarLocations = {
            new(420, 360),
            new(1720, 580),
            new(420, 800),
            new(1720, 1020),
            new(420, 1240),
            new(1720, 1460),
            new(420, 1680),
            new(1720, 1900),
            new(420, 2120),
            new(1720, 2340)
        };

        public static readonly PointF[] TextTireLocations = {
            new(200, 545),
            new(1500, 765),
            new(200, 985),
            new(1500, 1205),
            new(200, 1425),
            new(1500, 1645),
            new(200, 1865),
            new(1500, 2085),
            new(200, 2305),
            new(1500, 2525)
        };


        public static void ExportImage(int topType, List<Car> cars)
        {
            try
            {
                PrivateFontCollection pfc = new();
                pfc.AddFontFile(Path.Combine(AssetsDirectory, @"Racing.otf"));

                Image backgroundImg = Image.FromFile(ImageBuilder.ImagesPath[topType]);
                List<Car> top = cars.GetRange(0, Math.Min(10, cars.Count));

                Graphics gfx = Graphics.FromImage(backgroundImg);
                
                Font titleFont = new(pfc.Families[0], 50);
                Font tireFont = new(pfc.Families[0], 30);
                Font carFont = new(pfc.Families[0], 14);

                SizeF titleSize = gfx.MeasureString(Titles[topType], titleFont);

                PointF pointTitle = new((backgroundImg.Width - titleSize.Width) / 2, 100);
                gfx.DrawString(Titles[topType], titleFont, Brushes.White, pointTitle);

                foreach ((Car car, int index) in top.Select((car, i) => (car, i)))
                {
                    Image carImg = car.LoadImage();

                    PointF carNamePoint = ImageBuilder.TextCarLocations[index];
                    PointF tirePoint = ImageBuilder.TextTireLocations[index];
                    Rectangle location = ImageBuilder.ImageLocations[index];

                    if (topType == 0)
                    {
                        gfx.DrawString($"{car.Tires[0..1].ToUpper()}", tireFont, Brushes.White, tirePoint);
                    }

                    gfx.DrawString($"{car.Name}\n\n{car.Time}", carFont, Brushes.White, carNamePoint);
                    gfx.DrawImage(carImg, location);
                }

                string imageFilename = GetFileName(topType);
                backgroundImg.Save(imageFilename, ImageFormat.Png);

                Process.Start(new ProcessStartInfo() { FileName = imageFilename, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string GetFileName(int index)
        {
            string localAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyReisin");
            string basename = Path.GetFileName(ImagesPath[index]);

            Directory.CreateDirectory(localAppDataPath);

            return Path.Combine(localAppDataPath, basename);
        }
    }
}
