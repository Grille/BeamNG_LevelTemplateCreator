# BeamNG_LevelTemplateCreator
 
Setting up a new scenario from scratch can be a bit tiresome, especially if you have limited knowledge on how BeamNG handles things.
The goal of this project is to provide an easy solution to create empty map templates. 
I also aimed to make it easily extendable for people with deeper knowledge of BeamNG.

## Dependencies
- [.NET Desktop Runtime 6.0 or Later](https://dotnet.microsoft.com/en-us/download/dotnet)
- [Packages](https://github.com/Grille/BeamNG_LevelTemplateCreator_Packages)

## Links
- [\[GitHub\] https://github.com/Grille/BeamNG_LevelTemplateCreator](https://github.com/Grille/BeamNG_LevelTemplateCreator)
- [\[NuGet\] https://www.nuget.org/packages/Grille.BeamNG.Lib](https://www.nuget.org/packages/Grille.BeamNG.Lib)
- [\[BeamNG Forum\] https://www.beamng.com/threads/beamng_leveltemplatecreator-pbr-v0-2.98334/](https://www.beamng.com/threads/beamng_leveltemplatecreator-pbr-v0-2.98334/)

## Features
* Setup of needed level folder structure without manual renaming.
* Asset System based on BeamNG's Json structure.
* Ability to reference built-in BeamNG content, on export the referenced files are extracted to the template level.

## Future
* I would like to add support for Tree Objects, currently they still must be copied over manually.

## Usage
Just click the assets on the rights side, and press save when you're happy.

## Paths
* Gamedata:
Path to the BeamNG installation files, the folder should contain the BeamNG.drive.exe file.

* Userdata:
BeamNG user data folder that contains settings and mods, path should point to the folder containing the version.txt
Can usually be found under User\AppData\Local\BeamNG.drive

* Packages:
Must point to the packages folder that comes with the download.

## Assets
If you want to create custom template assets, you’re can mostly use the same file structure as in BeamNG.
But there a few things to be noted: all names are prefixed with the folder they are in to prevent conflicts.
So, if your want assets to reference each other they should generally be in the same folder.

### Asset Types

*  `LevelObjects`
Contains a collection of generic items that are sorted into `Level_object` on export.

* `TerrainMaterial`
BeamNG PBR Terrain Material.

* `GroundCover`
Ground Cover like grass, indirectly added if used by `TerrainMaterial`

* `Material`
Object material, indirectly added if used by any other object.

### Paths

* `/`
Absolute path either from the local package folder, or alternatively if beginning with `/level` and contains an valid BeamNG-level name e.g `/levels/driver_training/` an pointer to an BeamNG resource.

* `.`
Relative path from the folder containing the Json file.

* `#`
Hex color code `#ffffff` used to generate a single-color texture file on export.

* `$`
Variable

Each part must start with one of the above characters.

## Requirements
This program is dependent on .NET6 x64
