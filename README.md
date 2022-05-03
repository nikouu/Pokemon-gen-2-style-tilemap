# Pokemon gen 2 style tilemap

## Custom tiles

| Tile type        | Original                                   | Custom |
| ---------------- | ------------------------------------------ | ------ |
| Path             | ![image](Original/Path_large.png)          |        |
| Path with gravel | ![image](Original/Path-Gravel_large.png)   |        |
| Grass - flat     | ![image](Original/Grass-flat_large.png)    |        |
| Tree - short 00  | ![image](Original/Tree-short-00_large.png) |        |
| Tree - short 01  | ![image](Original/Tree-short-01_large.png) |        |
| Tree - short 02  | ![image](Original/Tree-short-02_large.png) |        |
| Tree - short 03  | ![image](Original/Tree-short-03_large.png) |        |
| Tree - tall 00   | ![image](Original/Tree-tall-00_large.png)  |        |
| Tree - tall 01   | ![image](Original/Tree-tall-01_large.png)  |        |
| Sign - metal 00  | ![image](Original/Sign-metal-00_large.png) |        |
| Sign - metal 01  | ![image](Original/Sign-metal-01_large.png) |        |
| Sign - metal 02  | ![image](Original/Sign-metal-02_large.png) |        |
| Sign - metal 03  | ![image](Original/Sign-metal-03_large.png) |        |
| Ridge 00         | ![image](Original/Ridge-00_large.png)      |        |
| Ridge 01         | ![image](Original/Ridge-01_large.png)      |        |
| Ridge 02         | ![image](Original/Ridge-02_large.png)      |        |
| Ridge 03         | ![image](Original/Ridge-03_large.png)      |        |
| Ridge 04         | ![image](Original/Ridge-04_large.png)      |        |
| Ridge 05         | ![image](Original/Ridge-05_large.png)      |        |
| Ridge 06         | ![image](Original/Ridge-06_large.png)      |        |
| Ridge 07         | ![image](Original/Ridge-07_large.png)      |        |
| Ridge 08         | ![image](Original/Ridge-08_large.png)      |        |

## Wanted simple tiles
- Path
  - A completely blank tile. Usually intersperced with the path with  
- Path with gravel 
 - This is the most common path in Gen 2 Pokemon
gravel.
- Flat grass
- Short tree
  - In Gen 2, the headbutt trees
- Tall tree
  - In gen 2, the trees that are double the short tree height
- Sign
  - The route/city signs
- Ledge
  - The ledge the player can jump off. Needs only 3 sides (left, right, bottom)
- Mountain tiles
  - Filled in ledge tiles that create rocky hills and mountains

## Wanted animated tiles
- Water
- Flowers 
- Tall grass

## Wanted building tiles 
- Door
- Window
- Flat roof style
- Fill in for building (hatched?)
- Fill in for building (brick)

## Notes
- Gameboy tiles are 8x8 pixels
- However, lots of things (including people) are 16x16 pixels (i.e. 2x2 tiles)
- Inspiration from [Pokemon Gold/Silver](https://www.spriters-resource.com/game_boy_gbc/pokemongoldsilver/sheet/60234/)
- Inspiration from [The Legend of Zelda: Oracle of Ages](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofages/) and [The Legend of Zelda: Oracle of Seasons](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofseasons/)
- [Full map of Gen 2 Johto and Kanto](https://www.reddit.com/r/pokemon/comments/ez1v43/gen_ii_map_of_overworld_and_dungeons_as_they/). Copying this into Aseprite, setup the grid as `{X: 1, Y: 6, Width: 8, Height: 8}` to align the main map to the grid. Grid toggle is `ctrl + '`
- If an object doesn't fill in the entire space of the tile, the empty space is often the blank path without gravel colour
