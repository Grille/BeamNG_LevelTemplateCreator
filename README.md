# BeamNG_LevelTemplateCreator
 
Setting up a new scenario from scratch can be a bit tiresome, especially if you have limited knowledge on how BeamNG handles things.
The goal of this project is to provide an easy solution to create empty map templates. 
I also aimed to make it easily extendable for people with deeper knowledge of BeamNG.

## Features
•	Setup of needed level folder structure without manual renaming.
•	Asset System based on beaming’s Json structure.
•	Ability to reference built-in BeamNG content, on export the referenced files are extracted to the template level.

## Assets

### Asset Types

 `LevelPreset`
Contains a collection of items that are sorted into `Level_object` on export, preset can by selected in the GUI.

`TerrainMaterial`
BeamNG PBR Terrain Material, multiple can be chosen by user.

`GroundCover`
Ground Cover like grass, indirectly added if used by `TerrainMaterial`

`Material`
Object material, indirectly added if used by any other object.

### Paths

`.`
Relative path from the folder containing the Json file.

`/`
Absolute path either from the local package folder, or alternatively if beginning with `/level` and contains an valid BeamNG-level name e.g `/levels/driver_training/` an pointer to an BeamNG resource.

`#`
Hex color code `#ffffff` used to generate a single-color texture file on export.
