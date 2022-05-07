# Pokemon Gen 2 Style Tilemap

## Objectives
1. Similar but different tiles. The kind that when side by side you can't really work out which is the original.
1. Same colour palette 

## Notes
- Gameboy tiles are 8x8 pixels
- However, lots of things (including people) are 16x16 pixels (i.e. 2x2 tiles)
- Inspiration from [Pokemon Gold/Silver](https://www.spriters-resource.com/game_boy_gbc/pokemongoldsilver/sheet/60234/). This is also the spritesheet the originals come from.
- Slight inspiration from [The Legend of Zelda: Oracle of Ages](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofages/) and [The Legend of Zelda: Oracle of Seasons](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofseasons/)
- [Full map of Gen 2 Johto and Kanto](https://www.reddit.com/r/pokemon/comments/ez1v43/gen_ii_map_of_overworld_and_dungeons_as_they/). Copying this into Aseprite, setup the grid as `{X: 1, Y: 6, Width: 8, Height: 8}` to align the main map to the grid. Grid toggle is `ctrl + '`


## Outdoor

### Tiles

| Tile type                 | Original                                           | Custom                                           | Notes                                                                                                                                                                                                                                                                  |
| ------------------------- | -------------------------------------------------- | ------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Path                      | ![image](Original/Path_large.png)                  | ![image](Custom/Path_large.png)                  | Hard to make distinct when using the same colours.                                                                                                                                                                                                                     |
| Path with gravel          | ![image](Original/Path-Gravel_large.png)           | ![image](Custom/Path-Gravel_large.png)           | Just some dots.                                                                                                                                                                                                                                                        |
| Grass - flat              | ![image](Original/Grass-flat_large.png)            | ![image](Custom/Grass-flat_large.png)            | Basically a whole bunch of checkerboarding with some bits cut out.                                                                                                                                                                                                     |
| Grass - tall              | ![image](Original/Grass-tall_large.png)            |                                                  |                                                                                                                                                                                                                                                                        |
| Tree - short 00           | ![image](Original/Tree-short-00_large.png)         | ![image](Custom/Tree-short-00_large.png)         | Background is just the grass texture. Followed the same shading style.  Ended up looking more bulbus at the top.                                                                                                                                                       |
| Tree - short 01           | ![image](Original/Tree-short-01_large.png)         | ![image](Custom/Tree-short-01_large.png)         | Background is just the grass texture. Followed the same shading style. Ended up looking more bulbus at the top.                                                                                                                                                        |
| Tree - short 02           | ![image](Original/Tree-short-02_large.png)         | ![image](Custom/Tree-short-02_large.png)         | Little shadow takes most of the space around the trunk. Ended up not using the same spiky tree look for the lower branches                                                                                                                                             |
| Tree - short 03           | ![image](Original/Tree-short-03_large.png)         | ![image](Custom/Tree-short-03_large.png)         | Little shadow takes most of the space around the trunk. Ended up not using the same spiky tree look for the lower branches                                                                                                                                             |
| Tree - tall 00            | ![image](Original/Tree-tall-00_large.png)          | ![image](Custom/Tree-tall-00_large.png)          | I think this also uses the normal grass background as a base                                                                                                                                                                                                           |
| Tree - tall 01            | ![image](Original/Tree-tall-01_large.png)          | ![image](Custom/Tree-tall-01_large.png)          | I think this also uses the normal grass background as a base                                                                                                                                                                                                           |
| Sign - metal 00           | ![image](Original/Sign-metal-00_large.png)         | ![image](Custom/Sign-metal-00_large.png)         | A taller sign.                                                                                                                                                                                                                                                         |
| Sign - metal 01           | ![image](Original/Sign-metal-01_large.png)         | ![image](Custom/Sign-metal-01_large.png)         | A taller sign.                                                                                                                                                                                                                                                         |
| Sign - metal 02           | ![image](Original/Sign-metal-02_large.png)         | ![image](Custom/Sign-metal-02_large.png)         | A taller sign.                                                                                                                                                                                                                                                         |
| Sign - metal 03           | ![image](Original/Sign-metal-03_large.png)         | ![image](Custom/Sign-metal-03_large.png)         | A taller sign.                                                                                                                                                                                                                                                         |
| Ridge 00                  | ![image](Original/Ridge-00_large.png)              | ![image](Custom/Ridge-00_large.png)              | Checkerboard design behind.                                                                                                                                                                                                                                            |
| Ridge 01                  | ![image](Original/Ridge-01_large.png)              | ![image](Custom/Ridge-01_large.png)              | Just lots of light shading on the top.                                                                                                                                                                                                                                 |
| Ridge 02                  | ![image](Original/Ridge-02_large.png)              | ![image](Custom/Ridge-02_large.png)              | Checkerboard design behind.                                                                                                                                                                                                                                            |
| Ridge 03                  | ![image](Original/Ridge-03_large.png)              | ![image](Custom/Ridge-03_large.png)              | This one looks like a dog's breakfast without the context of other tiles.                                                                                                                                                                                              |
| Ridge 04                  | ![image](Original/Ridge-04_large.png)              | ![image](Custom/Ridge-04_large.png)              | Surprisingly, this took a little bit of time to look okay and not overdone.                                                                                                                                                                                            |
| Ridge 05                  | ![image](Original/Ridge-05_large.png)              | ![image](Custom/Ridge-05_large.png)              | Initially looks less defined, but together with other tiles it looks fine.                                                                                                                                                                                             |
| Ridge 06                  | ![image](Original/Ridge-06_large.png)              | ![image](Custom/Ridge-06_large.png)              | Used a basic circle design. Might be worth looking into exaggerating the curve.                                                                                                                                                                                        |
| Ridge 07                  | ![image](Original/Ridge-07_large.png)              | ![image](Custom/Ridge-07_large.png)              | First run of this design looked like Hank Hill's ass.                                                                                                                                                                                                                  |
| Ridge 08                  | ![image](Original/Ridge-08_large.png)              | ![image](Custom/Ridge-08_large.png)              | I'm assuming the bottom right corner light pixel is the light peeking over the top of the rock at the top of the shadow.                                                                                                                                               |
| Water 00                  | ![image](Original/Water-00_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 01                  | ![image](Original/Water-01_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 02                  | ![image](Original/Water-02_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 03                  | ![image](Original/Water-03_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 04                  | ![image](Original/Water-04_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 05                  | ![image](Original/Water-05_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Water 06                  | ![image](Original/Water-06_large.png)              |                                                  |                                                                                                                                                                                                                                                                        |
| Grass - rustle 00         | ![image](Original/Grass-rustle-00_large.png)       |                                                  |                                                                                                                                                                                                                                                                        |
| Grass - rustle 01         | ![image](Original/Grass-rustle-01_large.png)       |                                                  |                                                                                                                                                                                                                                                                        |
| Flower - Johto 00         | ![image](Original/Flower-johto-00_large.png)       |                                                  |                                                                                                                                                                                                                                                                        |
| Flower - Johto 01         | ![image](Original/Flower-johto-01_large.png)       |                                                  |                                                                                                                                                                                                                                                                        |
| Building - Roof - flat 00 | ![image](Original/Building-roof-flat-00_large.png) | ![image](Custom/Building-roof-flat-00_large.png) | Top left corner. Though there are many roof colours in game and a couple of roof designs too. I took inspriation from my [first building](https://github.com/nikouu/Pixelart-Practice/blob/main/first%20building.aseprite).                                            |
| Building - Roof - flat 01 | ![image](Original/Building-roof-flat-01_large.png) | ![image](Custom/Building-roof-flat-01_large.png) | Top middle. Hard to be different here too I think when explicitly making a flat roof                                                                                                                                                                                   |
| Building - Roof - flat 02 | ![image](Original/Building-roof-flat-02_large.png) | ![image](Custom/Building-roof-flat-02_large.png) | Top right corner                                                                                                                                                                                                                                                       |
| Building - Roof - flat 03 | ![image](Original/Building-roof-flat-03_large.png) | ![image](Custom/Building-roof-flat-03_large.png) | Left middle                                                                                                                                                                                                                                                            |
| Building - Roof - flat 04 | ![image](Original/Building-roof-flat-04_large.png) | ![image](Custom/Building-roof-flat-04_large.png) | Centre fill                                                                                                                                                                                                                                                            |
| Building - Roof - flat 05 | ![image](Original/Building-roof-flat-05_large.png) | ![image](Custom/Building-roof-flat-05_large.png) | Right middle                                                                                                                                                                                                                                                           |
| Building - Roof - flat 06 | ![image](Original/Building-roof-flat-06_large.png) | ![image](Custom/Building-roof-flat-06_large.png) | Bottom left corner. A skinnier look inspired by Kanto.                                                                                                                                                                                                                 |
| Building - Roof - flat 07 | ![image](Original/Building-roof-flat-07_large.png) | ![image](Custom/Building-roof-flat-07_large.png) | Bottom middle                                                                                                                                                                                                                                                          |
| Building - Roof - flat 08 | ![image](Original/Building-roof-flat-08_large.png) | ![image](Custom/Building-roof-flat-08_large.png) | Bottom right corner                                                                                                                                                                                                                                                    |
| Building - Wall 00        | ![image](Original/Building-wall-00_large.png)      | ![image](Custom/Building-wall-00_large.png)      | Left building wall                                                                                                                                                                                                                                                     |
| Building - Wall 01        | ![image](Original/Building-wall-01_large.png)      | ![image](Custom/Building-wall-01_large.png)      | Right building wall                                                                                                                                                                                                                                                    |
| Building - Wall 02        | ![image](Original/Building-wall-02_large.png)      | ![image](Custom/Building-wall-02_large.png)      | Bottom left building corner                                                                                                                                                                                                                                            |
| Building - Wall 03        | ![image](Original/Building-wall-03_large.png)      | ![image](Custom/Building-wall-03_large.png)      | Bottom middle building floor. I never realised this had the dots, even when a brick cladding is used. Originally I didn't have the dots, but they ended up providing a unconscious smoothness to the design.                                                           |
| Building - Wall 04        | ![image](Original/Building-wall-04_large.png)      | ![image](Custom/Building-wall-04_large.png)      | Bottom right building corner                                                                                                                                                                                                                                           |
| Building - Cladding 00    | ![image](Original/Building-cladding-00_large.png)  | ![image](Custom/Building-cladding-00_large.png)  | Hatched design. I'm awful at designs and couldn't come up with anything better.                                                                                                                                                                                        |
| Building - Cladding 01    | ![image](Original/Building-cladding-01_large.png)  | ![image](Custom/Building-cladding-01_large.png)  | Brick. The pink building bricks were also used as the paths in Goldenrod                                                                                                                                                                                               |
| Building - Window         | ![image](Original/Building-window_large.png)       | ![image](Custom/Building-window_large.png)       | Window. SImilar to the hatched design, couldn't come up with anything better. However in my first building linked above, I did have a nice window design inspired by Kanto, but I couldnt' get it to suit the look here.                                               |
| Building - Door 00        | ![image](Original/Building-door-00_large.png)      | ![image](Custom/Building-door-00_large.png)      | Top left door. Never realised the door was so highlighted in the top half. I'm assuming this is to show the light coming out of the window. And perhaps this is the same door used in the night scenes, so it would look nicelyl it without having toc hange the tile. |
| Building - Door 01        | ![image](Original/Building-door-01_large.png)      | ![image](Custom/Building-door-01_large.png)      | Top right door                                                                                                                                                                                                                                                         |
| Building - Door 02        | ![image](Original/Building-door-02_large.png)      | ![image](Custom/Building-door-02_large.png)      | Bottom left door                                                                                                                                                                                                                                                       |
| Building - Door 03        | ![image](Original/Building-door-03_large.png)      | ![image](Custom/Building-door-03_large.png)      | Bottom right door                                                                                                                                                                                                                                                      |
|                           |                                                    |                                                  |                                                                                                                                                                                                                                                                        |

### Constructed tiles

| Sprite         | Original                                              | Custom                                            |
| -------------- | ----------------------------------------------------- | ------------------------------------------------- |
| Tree - short   | ![image](Original/Constructed/Tree-short_large.png)   | ![image](Custom/Constructed/Tree-short_large.png) |
| Tree - tall    | ![image](Original/Constructed/Tree-tall_large.png)    | ![image](Custom/Constructed/Tree-tall_large.png)  |
| Sign           | ![image](Original/Constructed/Sign_large.png)         | ![image](Custom/Constructed/Sign_large.png)       |
| Ridge          | ![image](Original/Constructed/Ridge_large.png)        | ![image](Custom/Constructed/Ridge_large.png)      |
| Water          | ![image](Original/Constructed/Water_large.gif)        |                                                   |
| Grass - rustle | ![image](Original/Constructed/Grass-rustle_large.png) |                                                   |
| Flower - Johto | ![image](Original/Constructed/Flower-johto_large.gif) |                                                   |
| Building       | ![image](Original/Constructed/Building_large.png)     | ![image](Custom/Constructed/Building_large.png)   |
|                |                                                       |                                                   |

### Observations
- Due to the GBC limitation, only 4 colours per sprite. Often this is a "black", "white", main colour light, and main colour dark.
- I have no idea how shading works
- Checkerboards, checkerboards everywhere
- Weird asymmertry everywhere
- If an object doesn't fill in the entire space of the tile, the empty space is often the blank path without gravel colour

#### Water
⚠️**On further analysis, I beleve this to be kinda wrong, but left here because it's interesting and might be worth picking up in the future**⚠️
- I think water tiles are actually only 4 tiles rather than the 7 pulled from the sprite sheet. I say this because 
  - The local label(?) [.WaterTileFrames](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L405) points to a [4 frame png](https://github.com/pret/pokegold/blob/master/gfx/tilesets/water/water.png)
  - Via [AnimateWaterPalette](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L649), water palette seems to [cycle 4 colours](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L672) - `none(?)`, `light`, `dark`, `light` . I assume this is what changes the shading of the light coloured pixels in the frames. As some of the water frames are the same, just lighter/darker depending where in the cycle they are. Then ultimately the blank and just blue frame is either the palette colours swapping in no or blue value for the pixels. I find it difficult to read Assembly, but it seems to be something like this. 
  - An educated assumption might look like this:

  | Frame | Visible in-game Tile                  | Palette cycle | Original animation frame index (0 - 4) | Original frame                                        | Approx number of frames visible |
  | ----- | ------------------------------------- | ------------- | -------------------------------------- | ----------------------------------------------------- | ------------------------------- |
  | 1     | ![image](Original/Water-00_large.png) | 0 (none)      | Frame 2                                | ![image](Original/Raw-water/Water-frame-02_large.png) | ~14?                            |
  | 2     | ![image](Original/Water-00_large.png) | 0 (none)      | Frame 3                                | ![image](Original/Raw-water/Water-frame-03_large.png) | ~14?                            |
  | 3     | ![image](Original/Water-01_large.png) | 1 (light)     | Frame 3                                | ![image](Original/Raw-water/Water-frame-03_large.png) | ~20?                            |
  | 4     | ![image](Original/Water-02_large.png) | 1 (light)     | Frame 0                                | ![image](Original/Raw-water/Water-frame-00_large.png) | ~4?                             |
  | 5     | ![image](Original/Water-03_large.png) | 2 (dark)      | Frame 0                                | ![image](Original/Raw-water/Water-frame-00_large.png) | ~24?                            |
  | 6     | ![image](Original/Water-04_large.png) | 2 (dark)      | Frame 1                                | ![image](Original/Raw-water/Water-frame-01_large.png) | ~4?                             |
  | 7     | ![image](Original/Water-05_large.png) | 1 (light)     | Frame 1                                | ![image](Original/Raw-water/Water-frame-01_large.png) | ~20?                            |
  | 8     | ![image](Original/Water-06_large.png) | 1 (light)     | Frame 2                                | ![image](Original/Raw-water/Water-frame-02_large.png) | ~4?                             |

    - **The above is a sketchy understanding at best**
    - The tiles except the blank one add to 60 frames, or 1 second (GB/GBC runs at 60fps)
    - Makes sense that the minimum length is 4 frames due to [this comment](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L384). Maybe 4 frames is a "tick" here.
 - However, as neat as these are, I'll probably just be using the 7 frame water animation
 - The water animation gif above might be a bit fast
 - [bgb notes](https://github.com/doeg/gb-skeleton/blob/master/docs/bgb.md) 
 - [More bgb notes](https://eldred.fr/gb-asm-tutorial/part1/tracing.html)

### Wanted tiles
A list of types of tiles I'd like to have. 

#### Simple tiles
- Path
  - A completely blank tile. Usually intersperced with the path with  
- Path with gravel 
  - This is the most common path in Gen 2 Pokemon
gravel.
- Flat grass
  - The general green outside floor tile
- Short tree
  - The headbutt trees
- Tall tree
  - The trees that are double the short tree height
- Sign
  - The route/city signs
- Ridge
  - The ledges the player can jump off
  - The tiles that create rocky hills and mountains

#### Animated tiles
- Water
- Tall grass
- Flowers 
  - There are Johto flowers and Kanto flowers, But I'll be focusing on Johto. 
  - I think Johto flowers run at 24 frames per animation frame. Assembly [here](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L408).
  - Also both seem to [run at different speeds](https://twitter.com/crystal_rby/status/1163503969429336066).

#### Building tiles 
- Door
- Window
- Flat roof style
- Fill in for building (hatched?)
- Fill in for building (brick)

## Indoor