namespace MyReisinLapTimes
{
    public partial class FrmMain : Form
    {
        readonly private List<Car> Cars;
        
        private List<Car> TopTop;
        private List<Car> TopRace;
        private List<Car> TopStreet;

        private void FrmMain_Load(object? sender, EventArgs e)
        {

        }

        public FrmMain()
        {
            InitializeComponent();
            FormClosing += SaveFile;

            TxtTime.Text = "0:00:00.000";

            Cars = Helper.Deserialize() ?? new List<Car>();

            TopStreet = Helper.OrderList(Cars, "Street") ?? new List<Car>();
            TopRace = Helper.OrderList(Cars, "Race") ?? new List<Car>();
            TopTop = Helper.OrderList(Cars) ?? new List<Car>();

            if (Cars.Count > 0)
            {
                Helper.LoadList(Cars, LstCarTimes, false);
                Helper.LoadList(TopStreet, LstTopStreet, true);
                Helper.LoadList(TopRace, LstTopRace, true);
                Helper.LoadList(TopTop, LstTopCar, true);
            }
        }

        private void SaveFile(object? sender, FormClosingEventArgs e)
        {
            Helper.Serialize(Cars);
        }

        private void TxtTimeKeyPressEvent(object? sender, KeyPressEventArgs e)
        {
            if (sender != null && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private void BtnAddTime_Click(object? sender, EventArgs e)
        {
            try
            {
                Helper.ValidateForm(TxtCar, TxtTime, RadRace, RadStreet, ImgCar);

                string tireType = RadRace.Checked ? "Race" : "Street";

                string[] row = { TxtCar.Text, tireType, TxtTime.Text };

                ListViewItem item = new(row);

                LstCarTimes.Items.Add(item);

                Car newCar = new(TxtCar.Text, TxtTime.Text, tireType, ImgCar.Image);
                Cars.Add(newCar);

                TopStreet = Helper.OrderList(Cars, "Street") ?? new List<Car>();
                TopRace = Helper.OrderList(Cars, "Race") ?? new List<Car>();
                TopTop = Helper.OrderList(Cars) ?? new List<Car>();

                Helper.ResetControls(TxtCar, TxtTime, RadRace, RadStreet, ImgCar);
                Helper.Serialize(Cars);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelTime_Click(object? sender, EventArgs e)
        {
            if (LstCarTimes.SelectedItems.Count > 0)
            {
                int absoluteIndex = LstCarTimes.SelectedItems[0].Index;

                LstCarTimes.Items.Remove(LstCarTimes.SelectedItems[0]);
                Cars.RemoveAt(absoluteIndex);

                TopStreet = Helper.OrderList(Cars, "Street") ?? new List<Car>();
                TopRace = Helper.OrderList(Cars, "Race") ?? new List<Car>();
                TopTop = Helper.OrderList(Cars) ?? new List<Car>();

                Helper.Serialize(Cars);

                TxtCar.Text = string.Empty;
                TxtTime.Text = string.Empty;
                ImgCar.Image = null;
            }
            else
            {
                MessageBox.Show("Please, if you want to delete a lap time, select it first.");
            }
        }

        private void BtnImageCar_Click(object? sender, EventArgs e)
        {
            if (OfdCarImage.ShowDialog() == DialogResult.OK)
            {
                string filePath = OfdCarImage.FileName;

                try
                {
                    Bitmap image = new(filePath);
                    ImgCar.Image = Helper.ScaleImage(image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LstCarTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helper.ResetControls(TxtCar, TxtTime, RadRace, RadStreet, ImgCar);
            ListView items = (ListView)sender;
            if (items.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = items.SelectedItems[0];
                TxtCar.Text = selectedItem.SubItems[0].Text;

                string tiresType = selectedItem.SubItems[1].Text;
                if (tiresType == "Street")
                {
                    RadStreet.Checked = true;
                    RadRace.Checked = false;
                }
                else
                {
                    RadStreet.Checked = false;
                    RadRace.Checked = true;
                }

                TxtTime.Text = selectedItem.SubItems[2].Text;

                int absoluteIndex = LstCarTimes.SelectedItems[0].Index;
                ImgCar.Image = Cars[absoluteIndex].LoadImage();
            }
        }

        private void BtnExportTopCars_Click(object sender, EventArgs e)
        {
            ImageBuilder.ExportImage(0, TopTop);
        }

        private void BtnTopStreetCars_Click(object sender, EventArgs e)
        {
            ImageBuilder.ExportImage(1, TopStreet);
        }

        private void BtnTopRaceCars_Click(object sender, EventArgs e)
        {
            ImageBuilder.ExportImage(2, TopRace);
        }
    }
}
