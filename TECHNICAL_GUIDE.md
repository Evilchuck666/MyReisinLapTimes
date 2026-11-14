# MyReisinLapTimes technical guide

[Back to the project overview](README.md)

MyReisinLapTimes is a Windows Forms desktop app written in C# 14 for .NET 10.
It stores lap times locally and exports Top 10 ranking images.

## Export assets

The exporter draws on top of the background images in the repository's
`assets` folder:

```
assets/
├── Top10.png
├── Top10Street.png
├── Top10Race.png
├── Racing.otf
└── Racing-OFL.txt
```

Every file in `assets/` is copied next to the executable when building, and
bundled inside the single-file `.exe` of the releases (it is extracted to a
temporary folder on first run). `Racing.otf` is the font used for titles,
names and times. If it is missing, export shows a warning instead of creating
the image.

`Racing.otf` is [Racing Sans One](https://fonts.google.com/specimen/Racing+Sans+One)
by Pablo Impallari and Rodrigo Fuenzalida, licensed under the
[SIL Open Font License 1.1](assets/Racing-OFL.txt).

## Building from source

Requirements: Windows and the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
(or Visual Studio 2026 with the .NET desktop workload).

```powershell
git clone https://github.com/Evilchuck666/MyReisinLapTimes.git
cd MyReisinLapTimes
dotnet run
```

To create the same single-file executable as the release:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true `
  -p:PublishSingleFile=true `
  -p:IncludeAllContentForSelfExtract=true `
  -p:EnableCompressionInSingleFile=true `
  -p:DebugType=none `
  -o dist/publish
```

## Releases

Releases are built by GitHub Actions (`.github/workflows/release.yaml`) on a
Windows runner:

- **Actions → Build Windows app → Run workflow** with an empty version only
  builds the `.exe` and uploads it as a workflow artifact.
- The same with a version such as `1.0.0` also creates the `v1.0.0` tag and a
  GitHub release with the `.exe` and a `SHA256SUMS.txt` file. Releases are only
  published from `main`.
- Pushes and pull requests build automatically only when the repository
  variable `MYREISIN_CI` is set to `true`.

## Project layout

| File | Purpose |
| --- | --- |
| `Program.cs` | Entry point. |
| `Form1.cs` / `Form1.Designer.cs` | Main window: form, lists and buttons. |
| `Car.cs` | A lap time: car name, time, tires and photo. |
| `Helper.cs` | Sorting, validation, list loading and JSON save/load. |
| `ImageBuilder.cs` | Draws the Top 10 PNG images. |
| `TimeSpanComparer.cs` | Orders times from fastest to slowest. |
| `assets/` | Backgrounds and font for the Top 10 export. |
