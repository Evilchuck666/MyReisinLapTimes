# CI-only: renders the actual WinForms app on a fresh Windows runner.
$ErrorActionPreference = 'Stop'
if ($env:GITHUB_ACTIONS -ne 'true' -or $env:OS -ne 'Windows_NT') {
    throw 'Run this through Capture Windows application on a fresh GitHub Windows runner.'
}
$captureProject = Join-Path $env:RUNNER_TEMP 'myreisin-capture-project'
$captureOutput = Join-Path $env:RUNNER_TEMP 'myreisin-capture-output'
New-Item -ItemType Directory -Force $captureProject, $captureOutput | Out-Null
$appProject = [System.Security.SecurityElement]::Escape((Join-Path $env:GITHUB_WORKSPACE 'MyReisinLapTimes.csproj'))
@"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net10.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup><ProjectReference Include="$appProject" /></ItemGroup>
</Project>
"@ | Set-Content (Join-Path $captureProject 'Capture.csproj') -Encoding utf8
@'
using System.Drawing.Imaging;
using System.Text.Json;
using MyReisinLapTimes;

internal static class CaptureProgram
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        var dataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MyReisin", "data.json");
        if (File.Exists(dataPath))
            throw new InvalidOperationException("Refusing to use an existing personal data file.");
        using var form = new FrmMain();
        form.Show();
        Application.DoEvents();
        T Field<T>(string name) where T : Control =>
            (T)form.Controls.Find(name, true).Single();
        var sampleRows = new[] {
            ("Example hatchback", "0:01:32.450", false, Color.Goldenrod),
            ("Example coupe", "0:01:28.125", true, Color.SteelBlue),
            ("Example roadster", "0:01:35.800", false, Color.SeaGreen)
        };
        foreach (var (name, time, race, colour) in sampleRows)
        {
            Field<TextBox>("TxtCar").Text = name;
            Field<TextBox>("TxtTime").Text = time;
            Field<RadioButton>("RadRace").Checked = race;
            Field<RadioButton>("RadStreet").Checked = !race;
            var sample = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(sample))
            {
                g.Clear(colour);
                using var font = new Font("Segoe UI", 16);
                g.DrawString("SAMPLE", font, Brushes.Black, 40, 85);
            }
            Field<PictureBox>("ImgCar").Image = sample;
            Field<Button>("BtnAddTime").PerformClick();
            Application.DoEvents();
        }
        var list = Field<ListView>("LstCarTimes");
        if (list.Items.Count != 3)
            throw new InvalidOperationException("The real application did not add all sample records.");
        list.Items[0].Selected = true;
        list.Select();
        Application.DoEvents();
        form.Refresh();
        using var bitmap = new Bitmap(form.Width, form.Height);
        form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
        Directory.CreateDirectory(args[0]);
        bitmap.Save(Path.Combine(args[0], "windows-app.png"), ImageFormat.Png);
        File.WriteAllText(Path.Combine(args[0], "provenance.json"), JsonSerializer.Serialize(new {
            application = "MyReisinLapTimes",
            capture = "Actual WinForms controls via DrawToBitmap",
            data = "Three fictional sample cars; colour blocks labelled SAMPLE",
            records = list.Items.Count,
            commit = Environment.GetEnvironmentVariable("GITHUB_SHA")
        }, new JsonSerializerOptions { WriteIndented = true }));
        form.Close();
    }
}
'@ | Set-Content (Join-Path $captureProject 'Program.cs') -Encoding utf8
& dotnet run --project (Join-Path $captureProject 'Capture.csproj') --configuration Release -- $captureOutput
if ($LASTEXITCODE -ne 0) { throw 'The Windows application capture failed.' }
if (-not (Test-Path (Join-Path $captureOutput 'windows-app.png'))) { throw 'No capture was produced.' }
