namespace MyReisinLapTimes
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnAddTime = new Button();
            GrpBxTimes = new GroupBox();
            BtnImageCar = new Button();
            BtnDelTime = new Button();
            ImgCar = new PictureBox();
            TxtTime = new TextBox();
            LblTime = new Label();
            GrpTires = new GroupBox();
            RadRace = new RadioButton();
            RadStreet = new RadioButton();
            TxtCar = new TextBox();
            LblCar = new Label();
            LstCarTimes = new ListView();
            ColCarName = new ColumnHeader();
            colTires = new ColumnHeader();
            colTime = new ColumnHeader();
            OfdCarImage = new OpenFileDialog();
            GrpAllCars = new GroupBox();
            BtnExportTopCars = new Button();
            LstTopCar = new ListView();
            ColHeadTopCar = new ColumnHeader();
            ColHeadTopTime = new ColumnHeader();
            GrpTopStreet = new GroupBox();
            BtnTopStreetCars = new Button();
            LstTopStreet = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            GrpTopRace = new GroupBox();
            BtnTopRaceCars = new Button();
            LstTopRace = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            GrpBxTimes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ImgCar).BeginInit();
            GrpTires.SuspendLayout();
            GrpAllCars.SuspendLayout();
            GrpTopStreet.SuspendLayout();
            GrpTopRace.SuspendLayout();
            SuspendLayout();
            // 
            // BtnAddTime
            // 
            BtnAddTime.Location = new Point(6, 381);
            BtnAddTime.Name = "BtnAddTime";
            BtnAddTime.Size = new Size(75, 23);
            BtnAddTime.TabIndex = 6;
            BtnAddTime.Text = "New Time";
            BtnAddTime.UseVisualStyleBackColor = true;
            BtnAddTime.Click += BtnAddTime_Click;
            // 
            // GrpBxTimes
            // 
            GrpBxTimes.Controls.Add(BtnImageCar);
            GrpBxTimes.Controls.Add(BtnDelTime);
            GrpBxTimes.Controls.Add(ImgCar);
            GrpBxTimes.Controls.Add(TxtTime);
            GrpBxTimes.Controls.Add(LblTime);
            GrpBxTimes.Controls.Add(GrpTires);
            GrpBxTimes.Controls.Add(TxtCar);
            GrpBxTimes.Controls.Add(LblCar);
            GrpBxTimes.Controls.Add(LstCarTimes);
            GrpBxTimes.Controls.Add(BtnAddTime);
            GrpBxTimes.Location = new Point(12, 12);
            GrpBxTimes.Name = "GrpBxTimes";
            GrpBxTimes.Size = new Size(342, 414);
            GrpBxTimes.TabIndex = 1;
            GrpBxTimes.TabStop = false;
            GrpBxTimes.Text = "Times";
            // 
            // BtnImageCar
            // 
            BtnImageCar.Location = new Point(261, 381);
            BtnImageCar.Name = "BtnImageCar";
            BtnImageCar.Size = new Size(75, 23);
            BtnImageCar.TabIndex = 5;
            BtnImageCar.Text = "Add Image";
            BtnImageCar.UseVisualStyleBackColor = true;
            BtnImageCar.Click += BtnImageCar_Click;
            // 
            // BtnDelTime
            // 
            BtnDelTime.Location = new Point(87, 381);
            BtnDelTime.Name = "BtnDelTime";
            BtnDelTime.Size = new Size(80, 23);
            BtnDelTime.TabIndex = 7;
            BtnDelTime.Text = "Delete Time";
            BtnDelTime.UseVisualStyleBackColor = true;
            BtnDelTime.Click += BtnDelTime_Click;
            // 
            // ImgCar
            // 
            ImgCar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ImgCar.BackgroundImageLayout = ImageLayout.None;
            ImgCar.BorderStyle = BorderStyle.Fixed3D;
            ImgCar.Location = new Point(226, 265);
            ImgCar.Name = "ImgCar";
            ImgCar.Size = new Size(110, 110);
            ImgCar.SizeMode = PictureBoxSizeMode.StretchImage;
            ImgCar.TabIndex = 7;
            ImgCar.TabStop = false;
            // 
            // TxtTime
            // 
            TxtTime.Location = new Point(45, 294);
            TxtTime.Name = "TxtTime";
            TxtTime.Size = new Size(150, 23);
            TxtTime.TabIndex = 1;
            TxtTime.KeyPress += TxtTimeKeyPressEvent;
            // 
            // LblTime
            // 
            LblTime.AutoSize = true;
            LblTime.Location = new Point(6, 297);
            LblTime.Name = "LblTime";
            LblTime.Size = new Size(39, 15);
            LblTime.TabIndex = 5;
            LblTime.Text = "Time :";
            // 
            // GrpTires
            // 
            GrpTires.Controls.Add(RadRace);
            GrpTires.Controls.Add(RadStreet);
            GrpTires.Location = new Point(6, 323);
            GrpTires.Name = "GrpTires";
            GrpTires.Size = new Size(189, 52);
            GrpTires.TabIndex = 2;
            GrpTires.TabStop = false;
            GrpTires.Text = "Tires";
            // 
            // RadRace
            // 
            RadRace.AutoSize = true;
            RadRace.Location = new Point(100, 27);
            RadRace.Name = "RadRace";
            RadRace.Size = new Size(50, 19);
            RadRace.TabIndex = 4;
            RadRace.TabStop = true;
            RadRace.Text = "Race";
            RadRace.UseVisualStyleBackColor = true;
            // 
            // RadStreet
            // 
            RadStreet.AutoSize = true;
            RadStreet.Location = new Point(39, 27);
            RadStreet.Name = "RadStreet";
            RadStreet.Size = new Size(55, 19);
            RadStreet.TabIndex = 3;
            RadStreet.TabStop = true;
            RadStreet.Text = "Street";
            RadStreet.UseVisualStyleBackColor = true;
            // 
            // TxtCar
            // 
            TxtCar.Location = new Point(45, 265);
            TxtCar.Name = "TxtCar";
            TxtCar.Size = new Size(150, 23);
            TxtCar.TabIndex = 0;
            // 
            // LblCar
            // 
            LblCar.AutoSize = true;
            LblCar.Location = new Point(14, 268);
            LblCar.Name = "LblCar";
            LblCar.Size = new Size(31, 15);
            LblCar.TabIndex = 2;
            LblCar.Text = "Car :";
            // 
            // LstCarTimes
            // 
            LstCarTimes.Columns.AddRange(new ColumnHeader[] { ColCarName, colTires, colTime });
            LstCarTimes.Location = new Point(6, 22);
            LstCarTimes.MultiSelect = false;
            LstCarTimes.Name = "LstCarTimes";
            LstCarTimes.Size = new Size(330, 237);
            LstCarTimes.TabIndex = 8;
            LstCarTimes.UseCompatibleStateImageBehavior = false;
            LstCarTimes.View = View.Details;
            LstCarTimes.SelectedIndexChanged += LstCarTimes_SelectedIndexChanged;
            // 
            // ColCarName
            // 
            ColCarName.Tag = "Car";
            ColCarName.Text = "Car";
            ColCarName.Width = 150;
            // 
            // colTires
            // 
            colTires.Tag = "Tires";
            colTires.Text = "Tires";
            colTires.Width = 75;
            // 
            // colTime
            // 
            colTime.Tag = "Time";
            colTime.Text = "Time";
            colTime.Width = 100;
            // 
            // OfdCarImage
            // 
            OfdCarImage.Filter = "JPG, JPEG, PNG, GIF, BMP Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            // 
            // GrpAllCars
            // 
            GrpAllCars.Controls.Add(BtnExportTopCars);
            GrpAllCars.Controls.Add(LstTopCar);
            GrpAllCars.Location = new Point(360, 12);
            GrpAllCars.Name = "GrpAllCars";
            GrpAllCars.Size = new Size(200, 414);
            GrpAllCars.TabIndex = 2;
            GrpAllCars.TabStop = false;
            GrpAllCars.Text = "Top Cars";
            // 
            // BtnExportTopCars
            // 
            BtnExportTopCars.Location = new Point(78, 381);
            BtnExportTopCars.Name = "BtnExportTopCars";
            BtnExportTopCars.Size = new Size(116, 23);
            BtnExportTopCars.TabIndex = 10;
            BtnExportTopCars.Text = "Export Top 10 Cars";
            BtnExportTopCars.UseVisualStyleBackColor = true;
            BtnExportTopCars.Click += BtnExportTopCars_Click;
            // 
            // LstTopCar
            // 
            LstTopCar.Columns.AddRange(new ColumnHeader[] { ColHeadTopCar, ColHeadTopTime });
            LstTopCar.Location = new Point(6, 22);
            LstTopCar.MultiSelect = false;
            LstTopCar.Name = "LstTopCar";
            LstTopCar.Size = new Size(188, 237);
            LstTopCar.TabIndex = 9;
            LstTopCar.UseCompatibleStateImageBehavior = false;
            LstTopCar.View = View.Details;
            // 
            // ColHeadTopCar
            // 
            ColHeadTopCar.Text = "Car";
            ColHeadTopCar.Width = 94;
            // 
            // ColHeadTopTime
            // 
            ColHeadTopTime.Text = "Time";
            ColHeadTopTime.Width = 94;
            // 
            // GrpTopStreet
            // 
            GrpTopStreet.Controls.Add(BtnTopStreetCars);
            GrpTopStreet.Controls.Add(LstTopStreet);
            GrpTopStreet.Location = new Point(566, 12);
            GrpTopStreet.Name = "GrpTopStreet";
            GrpTopStreet.Size = new Size(200, 414);
            GrpTopStreet.TabIndex = 3;
            GrpTopStreet.TabStop = false;
            GrpTopStreet.Text = "Top Cars with Street Tires";
            // 
            // BtnTopStreetCars
            // 
            BtnTopStreetCars.Location = new Point(47, 381);
            BtnTopStreetCars.Name = "BtnTopStreetCars";
            BtnTopStreetCars.Size = new Size(147, 23);
            BtnTopStreetCars.TabIndex = 11;
            BtnTopStreetCars.Text = "Export Top 10 Street Cars";
            BtnTopStreetCars.UseVisualStyleBackColor = true;
            BtnTopStreetCars.Click += BtnTopStreetCars_Click;
            // 
            // LstTopStreet
            // 
            LstTopStreet.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            LstTopStreet.Location = new Point(6, 22);
            LstTopStreet.MultiSelect = false;
            LstTopStreet.Name = "LstTopStreet";
            LstTopStreet.Size = new Size(188, 237);
            LstTopStreet.TabIndex = 10;
            LstTopStreet.UseCompatibleStateImageBehavior = false;
            LstTopStreet.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Car";
            columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Time";
            columnHeader2.Width = 94;
            // 
            // GrpTopRace
            // 
            GrpTopRace.Controls.Add(BtnTopRaceCars);
            GrpTopRace.Controls.Add(LstTopRace);
            GrpTopRace.Location = new Point(772, 12);
            GrpTopRace.Name = "GrpTopRace";
            GrpTopRace.Size = new Size(200, 414);
            GrpTopRace.TabIndex = 4;
            GrpTopRace.TabStop = false;
            GrpTopRace.Text = "Top Cars with Race Tires";
            // 
            // BtnTopRaceCars
            // 
            BtnTopRaceCars.Location = new Point(47, 381);
            BtnTopRaceCars.Name = "BtnTopRaceCars";
            BtnTopRaceCars.Size = new Size(147, 23);
            BtnTopRaceCars.TabIndex = 12;
            BtnTopRaceCars.Text = "Export Top 10 Race Cars";
            BtnTopRaceCars.UseVisualStyleBackColor = true;
            BtnTopRaceCars.Click += BtnTopRaceCars_Click;
            // 
            // LstTopRace
            // 
            LstTopRace.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            LstTopRace.Location = new Point(6, 22);
            LstTopRace.MultiSelect = false;
            LstTopRace.Name = "LstTopRace";
            LstTopRace.Size = new Size(188, 237);
            LstTopRace.TabIndex = 11;
            LstTopRace.UseCompatibleStateImageBehavior = false;
            LstTopRace.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Car";
            columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Time";
            columnHeader4.Width = 94;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 438);
            Controls.Add(GrpTopRace);
            Controls.Add(GrpTopStreet);
            Controls.Add(GrpAllCars);
            Controls.Add(GrpBxTimes);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmMain";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyReisinLapTimes";
            Load += FrmMain_Load;
            GrpBxTimes.ResumeLayout(false);
            GrpBxTimes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ImgCar).EndInit();
            GrpTires.ResumeLayout(false);
            GrpTires.PerformLayout();
            GrpAllCars.ResumeLayout(false);
            GrpTopStreet.ResumeLayout(false);
            GrpTopRace.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnAddTime;
        private GroupBox GrpBxTimes;
        private ListView LstCarTimes;
        private ColumnHeader ColCarName;
        private ColumnHeader colTires;
        private ColumnHeader colTime;
        private TextBox TxtCar;
        private Label LblCar;
        private GroupBox GrpTires;
        private RadioButton RadRace;
        private RadioButton RadStreet;
        private TextBox TxtTime;
        private Label LblTime;
        private Button BtnDelTime;
        private OpenFileDialog OfdCarImage;
        private Button BtnImageCar;
        private PictureBox ImgCar;
        private GroupBox GrpAllCars;
        private GroupBox GrpTopStreet;
        private GroupBox GrpTopRace;
        private ListView LstTopCar;
        private ColumnHeader ColHeadTopCar;
        private ColumnHeader ColHeadTopTime;
        private ListView LstTopStreet;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView LstTopRace;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button BtnExportTopCars;
        private Button BtnTopStreetCars;
        private Button BtnTopRaceCars;
    }
}
