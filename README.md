# Pokemon gen 2 style tilemap

## Objectives
1. Similar but different tiles
1. Use of same colour palette 

## Notes
- Gameboy tiles are 8x8 pixels
- However, lots of things (including people) are 16x16 pixels (i.e. 2x2 tiles)
- Inspiration from [Pokemon Gold/Silver](https://www.spriters-resource.com/game_boy_gbc/pokemongoldsilver/sheet/60234/)
- Inspiration from [The Legend of Zelda: Oracle of Ages](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofages/) and [The Legend of Zelda: Oracle of Seasons](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofseasons/)
- [Full map of Gen 2 Johto and Kanto](https://www.reddit.com/r/pokemon/comments/ez1v43/gen_ii_map_of_overworld_and_dungeons_as_they/). Copying this into Aseprite, setup the grid as `{X: 1, Y: 6, Width: 8, Height: 8}` to align the main map to the grid. Grid toggle is `ctrl + '`
- If an object doesn't fill in the entire space of the tile, the empty space is often the blank path without gravel colour


## Tiles

| Tile type        | Original                                   | Custom                                   | Notes                                                                                                                      |
| ---------------- | ------------------------------------------ | ---------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| Path             | ![image](Original/Path_large.png)          | ![image](Custom/Path_large.png)          | Hard to make distinct when using the same colours.                                                                         |
| Path with gravel | ![image](Original/Path-Gravel_large.png)   | ![image](Custom/Path-Gravel_large.png)   | Just some dots.                                                                                                            |
| Grass - flat     | ![image](Original/Grass-flat_large.png)    | ![image](Custom/Grass-flat_large.png)    | Basically a whole bunch of checkerboarding with some bits cut out.                                                         |
| Tree - short 00  | ![image](Original/Tree-short-00_large.png) | ![image](Custom/Tree-short-00_large.png) | Background is just the grass texture. Followed the same shading style.  Ended up looking more bulbus at the top.           |
| Tree - short 01  | ![image](Original/Tree-short-01_large.png) | ![image](Custom/Tree-short-01_large.png) | Background is just the grass texture. Followed the same shading style. Ended up looking more bulbus at the top.            |
| Tree - short 02  | ![image](Original/Tree-short-02_large.png) | ![image](Custom/Tree-short-02_large.png) | Little shadow takes most of the space around the trunk. Ended up not using the same spiky tree look for the lower branches |
| Tree - short 03  | ![image](Original/Tree-short-03_large.png) | ![image](Custom/Tree-short-03_large.png) | Little shadow takes most of the space around the trunk. Ended up not using the same spiky tree look for the lower branches |
| Tree - tall 00   | ![image](Original/Tree-tall-00_large.png)  | ![image](Custom/Tree-tall-00_large.png)  | I think this also uses the normal grass background as a base                                                               |
| Tree - tall 01   | ![image](Original/Tree-tall-01_large.png)  | ![image](Custom/Tree-tall-01_large.png)  | I think this also uses the normal grass background as a base                                                               |
| Sign - metal 00  | ![image](Original/Sign-metal-00_large.png) | ![image](Custom/Sign-metal-00_large.png) | A taller sign.                                                                                                             |
| Sign - metal 01  | ![image](Original/Sign-metal-01_large.png) | ![image](Custom/Sign-metal-01_large.png) | A taller sign.                                                                                                             |
| Sign - metal 02  | ![image](Original/Sign-metal-02_large.png) | ![image](Custom/Sign-metal-02_large.png) | A taller sign.                                                                                                             |
| Sign - metal 03  | ![image](Original/Sign-metal-03_large.png) | ![image](Custom/Sign-metal-03_large.png) | A taller sign.                                                                                                             |
| Ridge 00         | ![image](Original/Ridge-00_large.png)      | ![image](Custom/Ridge-00_large.png)      | Checkerboard design behind.                                                                                                |
| Ridge 01         | ![image](Original/Ridge-01_large.png)      | ![image](Custom/Ridge-01_large.png)      | Just lots of light shading on the top.                                                                                     |
| Ridge 02         | ![image](Original/Ridge-02_large.png)      | ![image](Custom/Ridge-02_large.png)      | Checkerboard design behind.                                                                                                |
| Ridge 03         | ![image](Original/Ridge-03_large.png)      | ![image](Custom/Ridge-03_large.png)      | This one looks like a dog's breakfast without the context of other tiles.                                                  |
| Ridge 04         | ![image](Original/Ridge-04_large.png)      | ![image](Custom/Ridge-04_large.png)      | Surprisingly, this took a little bit of time to look okay and not overdone.                                                |
| Ridge 05         | ![image](Original/Ridge-05_large.png)      | ![image](Custom/Ridge-05_large.png)      | Initially looks less defined, but together with other tiles it looks fine.                                                 |
| Ridge 06         | ![image](Original/Ridge-06_large.png)      | ![image](Custom/Ridge-06_large.png)      | Used a basic circle design. Might be worth looking into exaggerating the curve.                                            |
| Ridge 07         | ![image](Original/Ridge-07_large.png)      | ![image](Custom/Ridge-07_large.png)      | First run of this design looked like Hank Hill's ass.                                                                      |
| Ridge 08         | ![image](Original/Ridge-08_large.png)      | ![image](Custom/Ridge-08_large.png)      | I'm assuming the bottom right corner light pixel is the light peeking over the top of the rock at the top of the shadow.   |
|                  |                                            |                                          |                                                                                                                            |

## Constructed sprites

| Sprite       | Original                                            | Custom |
| ------------ | --------------------------------------------------- | ------ |
| Tree - short | ![image](Original/Constructed/Tree-short_large.png) | ![image](Custom/Constructed/Tree-short_large.png)       |
| Tree - tall  | ![image](Original/Constructed/Tree-tall_large.png)  | ![image](Custom/Constructed/Tree-tall_large.png)       |
| Sign         | ![image](Original/Constructed/Sign_large.png)       | ![image](Custom/Constructed/Sign_large.png)       |
| Ridge        | ![image](Original/Constructed/Ridge_large.png)      | ![image](Custom/Constructed/Ridge_large.png)       |

## Observations
- Due to the GBC limitation, only 4 colours per sprite. Often this is a "black", "white", main colour light, and main colour dark.
- I have no idea how shading works
- Checkerboards, checkerboards everywhere
- Weird asymmertry everywhere

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

