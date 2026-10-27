# 🏁 MyReisinLapTimes

**Keep your car lap times, rank them and export shareable Top 10 images.**

MyReisinLapTimes is a small Windows desktop app for logging lap times of
different cars. Every time is stored with the car's name, a photo and the type
of tires it ran on, and the app keeps three live leaderboards: overall, street
tires and race tires. Each leaderboard can be exported as a poster-style
Top 10 image, ready to share.

## ✨ What it does

- Add a lap time with the car's name, its time (`h:mm:ss.fff`), the tire type
  (**Street** or **Race**) and a photo.
- Delete a time by selecting it in the list.
- Click a time to see its car, tires and photo again.
- Shows three rankings sorted from fastest to slowest:
  - **Top Cars**: every time.
  - **Top Cars with Street Tires**.
  - **Top Cars with Race Tires**.
- Exports any of the three rankings as a 2700 × 2700 PNG with the ten fastest
  cars, their photos and their times, and opens it straight away.
- Saves everything automatically.

## 🚀 Getting started

1. Download `MyReisinLapTimes-windows-x64.zip` from the
   [latest release](https://github.com/Evilchuck666/MyReisinLapTimes/releases/latest).
2. Extract it anywhere and open **MyReisinLapTimes.exe**. The package is
   self-contained, so you do not need to install .NET.
3. Type the car's name and its lap time, pick the tires, press **Add Image** to
   choose a photo and press **New Time**.
4. Use the **Export Top 10** buttons to create the ranking images.

## 💾 Where your data lives

Everything is stored in `%LOCALAPPDATA%\MyReisin`:

| File | Contents |
| --- | --- |
| `data.json` | Every car and lap time, with its photo embedded (base64 PNG, scaled to 200 × 200). |
| `Top10.png`, `Top10Street.png`, `Top10Race.png` | The last exported ranking images. |

Back up `data.json` to keep your times.

## 🖼️ Export assets

The exporter draws on top of the background images found in an `assets`
folder next to the executable:

```
MyReisinLapTimes.exe
assets/
├── Top10.png
├── Top10Street.png
├── Top10Race.png
└── Racing.otf
```

The release package already includes the three backgrounds. `Racing.otf` is
the font used for titles, names and times. If it is missing, export shows a
warning instead of creating the image.

## 🛠️ Building from source

Requirements: Windows and the [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
(or Visual Studio 2022 with the .NET desktop workload).

```powershell
git clone https://github.com/Evilchuck666/MyReisinLapTimes.git
cd MyReisinLapTimes
dotnet run
```

To create the same self-contained package as the release:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true -o dist/MyReisinLapTimes
```

Then copy the three `Top10*.png` files and `Racing.otf` into
`dist/MyReisinLapTimes/assets`.

## 📦 Releases

Releases are built by GitHub Actions (`.github/workflows/build.yml`) on a
Windows runner:

- **Actions → Build Windows app → Run workflow** with an empty version only
  builds the package and uploads it as a workflow artifact.
- The same with a version such as `1.0.0` also creates the `v1.0.0` tag and a
  GitHub release with the zip and a `SHA256SUMS.txt` file. Releases are only
  published from `master`.
- Pushes and pull requests build automatically only when the repository
  variable `MYREISIN_CI` is set to `true`.

## 🧱 Project layout

| File | Purpose |
| --- | --- |
| `Program.cs` | Entry point. |
| `Form1.cs` / `Form1.Designer.cs` | Main window: form, lists and buttons. |
| `Car.cs` | A lap time: car name, time, tires and photo. |
| `Helper.cs` | Sorting, validation, list loading and JSON save/load. |
| `ImageBuilder.cs` | Draws the Top 10 PNG images. |
| `TimeSpanComparer.cs` | Orders times from fastest to slowest. |
