# Pokemon Gen 2 Style Tilemap

## Objectives
1. Similar but different tiles. The kind that when side by side you can't really work out which is the original.
1. Same colour palette 

These will be addressed via:

### Compiler
There's a *crusty* compiler that extracts data from the tables in this readme.md file to generate:
1. A tilemap for both the [original](Original.png) and [custom](Custom.png) tiles
1. A JSON output of the tilemap with tile names, the filename, and coordinates: [TilemapDetails.json](TilemapDetails.json)

If there are missing tiles, a fuchsia square is used instead. 

This helps me create tilemaps easily by only having to document them here. The tilemaps themselves look like:

| Tilemap from original tiles | Tilemap from custom tiles |
| --------------------------- | ------------------------- |
| ![image](Original.png)      | ![image](Custom.png)      |

### Colouriser
Also included is a colouriser which turns each tile into the 4 colour GameBoy colours. This is useful to directly import the sheet into something like GBStudio.

## Notes
- Gameboy tiles are 8x8 pixels
- However, lots of things (including people) are 16x16 pixels (i.e. 2x2 tiles) or bigger like trees and buildings.
- Inspiration from [Pokemon Gold/Silver](https://www.spriters-resource.com/game_boy_gbc/pokemongoldsilver/sheet/60234/). This is also the spritesheet the originals come from.
- Slight inspiration from [The Legend of Zelda: Oracle of Ages](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofages/) and [The Legend of Zelda: Oracle of Seasons](https://www.spriters-resource.com/game_boy_gbc/thelegendofzeldaoracleofseasons/)
- [Full map of Gen 2 Johto and Kanto](https://www.reddit.com/r/pokemon/comments/ez1v43/gen_ii_map_of_overworld_and_dungeons_as_they/). Copying this into Aseprite, setup the grid as `{X: 1, Y: 6, Width: 8, Height: 8}` to align the main map to the grid. Grid toggle is `ctrl + '`
- Tile naming convention: \<Object> - \<type> - \<index>
    - Object: The thing the tile represents.
    - Type: The type/subclass/description of the Object
    - Index: If it is a multi-tile Object, the index of the tile. From left to right, top to bottom.
- Each tile has a large version. Exported from Aseprite at 800% size with `_large` in the filename.


## Outdoor

### Tiles

| Tile                      | Original                                           | Custom                                           | Notes                                                                                                                                                                                                                                                                  |
| ------------------------- | -------------------------------------------------- | ------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Path                      | ![image](Original/Path_large.png)                  | ![image](Custom/Path_large.png)                  | Hard to make distinct when using the same colours.                                                                                                                                                                                                                     |
| Path with gravel          | ![image](Original/Path-Gravel_large.png)           | ![image](Custom/Path-Gravel_large.png)           | Just some dots.                                                                                                                                                                                                                                                        |
| Grass - flat              | ![image](Original/Grass-flat_large.png)            | ![image](Custom/Grass-flat_large.png)            | Basically a whole bunch of checkerboarding with some bits cut out.                                                                                                                                                                                                     |
| Grass - tall              | ![image](Original/Grass-tall_large.png)            | ![image](Custom/Grass-tall_large.png)            | Couldn't make nice looking grass on my own. Might have to revisit. Maybe get inspiration fron gen 1 or 3?                                                                                                                                                              |
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
| Flower - Johto 00         | ![image](Original/Flower-johto-00_large.png)       | ![image](Custom/Flower-johto-00_large.png)       | Flipped the background pixels. The original did a great job with the space it had.                                                                                                                                                                                     |
| Flower - Johto 01         | ![image](Original/Flower-johto-01_large.png)       | ![image](Custom/Flower-johto-01_large.png)       | Maybe move the flower the other way? Maybe do a V shaped flower like a tulip?                                                                                                                                                                                          |
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
| Building - Window         | ![image](Original/Building-window_large.png)       | ![image](Custom/Building-window_large.png)       | Window. Similar to the hatched design, couldn't come up with anything better. However in my first building linked above, I did have a nice window design inspired by Kanto, but I couldnt' get it to suit the look here.                                               |
| Building - Door 00        | ![image](Original/Building-door-00_large.png)      | ![image](Custom/Building-door-00_large.png)      | Top left door. Never realised the door was so highlighted in the top half. I'm assuming this is to show the light coming out of the window. And perhaps this is the same door used in the night scenes, so it would look nicelyl it without having toc hange the tile. |
| Building - Door 01        | ![image](Original/Building-door-01_large.png)      | ![image](Custom/Building-door-01_large.png)      | Top right door                                                                                                                                                                                                                                                         |
| Building - Door 02        | ![image](Original/Building-door-02_large.png)      | ![image](Custom/Building-door-02_large.png)      | Bottom left door                                                                                                                                                                                                                                                       |
| Building - Door 03        | ![image](Original/Building-door-03_large.png)      | ![image](Custom/Building-door-03_large.png)      | Bottom right door                                                                                                                                                                                                                                                      |
| Outdoor Exit Mat          | ![image](Original/Outdoor-exit-mat_large.png)      | ![image](Custom/Outdoor-exit-mat_large.png)      |                                                                                                                                                                                                                                                                        |

### Constructed tiles

| Constructed Tile         | Original                                                          | Custom                                                          |
| ------------------------ | ----------------------------------------------------------------- | --------------------------------------------------------------- |
| Tree - short             | ![image](Original/Constructed/Tree-short_large.png)               | ![image](Custom/Constructed/Tree-short_large.png)               |
| Tree - tall              | ![image](Original/Constructed/Tree-tall_large.png)                | ![image](Custom/Constructed/Tree-tall_large.png)                |
| Sign                     | ![image](Original/Constructed/Sign_large.png)                     | ![image](Custom/Constructed/Sign_large.png)                     |
| Ridge                    | ![image](Original/Constructed/Ridge_large.png)                    | ![image](Custom/Constructed/Ridge_large.png)                    |
| Water                    | ![image](Original/Constructed/Water_large.gif)                    |                                                                 |
| Grass - rustle           | ![image](Original/Constructed/Grass-rustle_large.png)             |                                                                 |
| Flower - Johto           | ![image](Original/Constructed/Flower-johto_large.gif)             | ![image](Custom/Constructed/Flower-johto_large.gif)             |
| Building                 | ![image](Original/Constructed/Building_large.png)                 | ![image](Custom/Constructed/Building_large.png)                 |
| Outdoor exit mat type 01 | ![image](Original/Constructed/Outdoor-exit-mat-type-01_large.png) | ![image](Custom/Constructed/Outdoor-exit-mat-type-01_large.png) |
| Outdoor exit mat type 02 | ![image](Original/Constructed/Outdoor-exit-mat-type-02_large.png) | ![image](Custom/Constructed/Outdoor-exit-mat-type-02_large.png) |

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

#### Flowers
- There are Johto flowers and Kanto flowers, But I'll be focusing on Johto. 
- I think Johto flowers run at 24 frames per animation frame. Assembly [here](https://github.com/pret/pokegold/blob/c133efea5f8438ea40be83dc3b2039494574c768/engine/tilesets/tileset_anims.asm#L408).
- Also both seem to [run at different speeds](https://twitter.com/crystal_rby/status/1163503969429336066).

## Indoor

### Tiles
| Tile                         | Original                                                | Custom                                                | Notes                                                          |
| ---------------------------- | ------------------------------------------------------- | ----------------------------------------------------- | -------------------------------------------------------------- |
| Void                         | ![image](Original/Void_large.png)                       | ![image](Custom/Void_large.png)                       |                                                                |
| Back wall - painted          | ![image](Original/Back-wall-painted_large.png)          | ![image](Custom/Back-wall-painted_large.png)          |                                                                |
| Back wall - wood             | ![image](Original/Back-wall-wood_large.png)             | ![image](Custom/Back-wall-wood_large.png)             | ╚(ಠ_ಠ)=┐ ┌=(ಠ_ಠ)╝                                              |
| Back wall - window 00        | ![image](Original/Back-wall-window-00_large.png)        | ![image](Custom/Back-wall-window-00_large.png)        |                                                                |
| Back wall - window 01        | ![image](Original/Back-wall-window-01_large.png)        | ![image](Custom/Back-wall-window-01_large.png)        |                                                                |
| Back wall - window 02        | ![image](Original/Back-wall-window-02_large.png)        | ![image](Custom/Back-wall-window-02_large.png)        |                                                                |
| Back wall - window 03        | ![image](Original/Back-wall-window-03_large.png)        | ![image](Custom/Back-wall-window-03_large.png)        |                                                                |
| Back wall - art 00           | ![image](Original/Back-wall-art-00_large.png)           | ![image](Custom/Back-wall-art-00_large.png)           |                                                                |
| Back wall - art 01           | ![image](Original/Back-wall-art-01_large.png)           | ![image](Custom/Back-wall-art-01_large.png)           |                                                                |
| Back wall - art 02           | ![image](Original/Back-wall-art-02_large.png)           | ![image](Custom/Back-wall-art-02_large.png)           |                                                                |
| Back wall - art 03           | ![image](Original/Back-wall-art-03_large.png)           | ![image](Custom/Back-wall-art-03_large.png)           |                                                                |
| Flooring - type 01           | ![image](Original/Flooring-type-01_large.png)           | ![image](Custom/Flooring-type-01_large.png)           |                                                                |
| Flooring - type 02           | ![image](Original/Flooring-type-02_large.png)           | ![image](Custom/Flooring-type-02_large.png)           |                                                                |
| Table - type 01 - 00         | ![image](Original/Table-type-1-00_large.png)            | ![image](Custom/Table-type-1-00_large.png)            |                                                                |
| Table - type 01 - 01         | ![image](Original/Table-type-1-01_large.png)            | ![image](Custom/Table-type-1-01_large.png)            |                                                                |
| Table - type 01 - 02         | ![image](Original/Table-type-1-02_large.png)            | ![image](Custom/Table-type-1-02_large.png)            |                                                                |
| Table - type 01 - 03         | ![image](Original/Table-type-1-03_large.png)            | ![image](Custom/Table-type-1-03_large.png)            |                                                                |
| Table - type 01 - 04         | ![image](Original/Table-type-1-04_large.png)            | ![image](Custom/Table-type-1-04_large.png)            |                                                                |
| Table - type 01 - 05         | ![image](Original/Table-type-1-05_large.png)            | ![image](Custom/Table-type-1-05_large.png)            |                                                                |
| Table - type 01 - 06         | ![image](Original/Table-type-1-06_large.png)            | ![image](Custom/Table-type-1-06_large.png)            |                                                                |
| Table - type 01 - 07         | ![image](Original/Table-type-1-07_large.png)            | ![image](Custom/Table-type-1-07_large.png)            |                                                                |
| Table - type 01 - 08         | ![image](Original/Table-type-1-08_large.png)            | ![image](Custom/Table-type-1-08_large.png)            |                                                                |
| Table - type 01 - 09         | ![image](Original/Table-type-1-09_large.png)            | ![image](Custom/Table-type-1-09_large.png)            |                                                                |
| Table - type 01 - 10         | ![image](Original/Table-type-1-10_large.png)            | ![image](Custom/Table-type-1-10_large.png)            |                                                                |
| Table - type 01 - 11         | ![image](Original/Table-type-1-11_large.png)            | ![image](Custom/Table-type-1-11_large.png)            |                                                                |
| Indoor plant - type 01 - 00  | ![image](Original/Indoor-plant-type-01-00_large.png)    | ![image](Custom/Indoor-plant-type-01-00_large.png)    |                                                                |
| Indoor plant - type 01 - 01  | ![image](Original/Indoor-plant-type-01-01_large.png)    | ![image](Custom/Indoor-plant-type-01-01_large.png)    |                                                                |
| Indoor plant - type 01 - 02  | ![image](Original/Indoor-plant-type-01-02_large.png)    | ![image](Custom/Indoor-plant-type-01-02_large.png)    |                                                                |
| Indoor plant - type 01 - 03  | ![image](Original/Indoor-plant-type-01-03_large.png)    | ![image](Custom/Indoor-plant-type-01-03_large.png)    |                                                                |
| Indoor plant - type 01 - 04  | ![image](Original/Indoor-plant-type-01-04_large.png)    | ![image](Custom/Indoor-plant-type-01-04_large.png)    |                                                                |
| Indoor plant - type 01 - 05  | ![image](Original/Indoor-plant-type-01-05_large.png)    | ![image](Custom/Indoor-plant-type-01-05_large.png)    |                                                                |
| Indoor plant - type 01 - 06  | ![image](Original/Indoor-plant-type-01-06_large.png)    | ![image](Custom/Indoor-plant-type-01-06_large.png)    |                                                                |
| Indoor plant - type 01 - 07  | ![image](Original/Indoor-plant-type-01-07_large.png)    | ![image](Custom/Indoor-plant-type-01-07_large.png)    |                                                                |
| Computer - type 01 - 00      | ![image](Original/Computer-type-01-00_large.png)        | ![image](Custom/Computer-type-01-00_large.png)        |                                                                |
| Computer - type 01 - 01      | ![image](Original/Computer-type-01-01_large.png)        | ![image](Custom/Computer-type-01-01_large.png)        | Looks like I drew a rare wide screen old CRT                   |
| Computer - type 01 - 02      | ![image](Original/Computer-type-01-02_large.png)        | ![image](Custom/Computer-type-01-02_large.png)        |                                                                |
| Computer - type 01 - 03      | ![image](Original/Computer-type-01-03_large.png)        | ![image](Custom/Computer-type-01-03_large.png)        |                                                                |
| Computer - type 01 - 04      | ![image](Original/Computer-type-01-04_large.png)        | ![image](Custom/Computer-type-01-04_large.png)        |                                                                |
| Computer - type 01 - 05      | ![image](Original/Computer-type-01-05_large.png)        | ![image](Custom/Computer-type-01-05_large.png)        | Uses the bottom of the bookshelf as the bottom of the computer |
| TV - type 01 - 00            | ![image](Original/TV-type-01-00_large.png)              | ![image](Custom/TV-type-01-00_large.png)              |                                                                |
| TV - type 01 - 01            | ![image](Original/TV-type-01-01_large.png)              | ![image](Custom/TV-type-01-01_large.png)              |                                                                |
| TV - type 01 - 02            | ![image](Original/TV-type-01-02_large.png)              | ![image](Custom/TV-type-01-02_large.png)              |                                                                |
| TV - type 01 - 03            | ![image](Original/TV-type-01-03_large.png)              | ![image](Custom/TV-type-01-03_large.png)              |                                                                |
| Bookshelf - type 01 - 00     | ![image](Original/Bookshelf-type-01-00_large.png)       | ![image](Custom/Bookshelf-type-01-00_large.png)       |                                                                |
| Bookshelf - type 01 - 01     | ![image](Original/Bookshelf-type-01-01_large.png)       | ![image](Custom/Bookshelf-type-01-01_large.png)       |                                                                |
| Bookshelf - type 01 - 02     | ![image](Original/Bookshelf-type-01-02_large.png)       | ![image](Custom/Bookshelf-type-01-02_large.png)       |                                                                |
| Bookshelf - type 01 - 03     | ![image](Original/Bookshelf-type-01-03_large.png)       | ![image](Custom/Bookshelf-type-01-03_large.png)       |                                                                |
| Bookshelf - type 01 - 04     | ![image](Original/Bookshelf-type-01-04_large.png)       | ![image](Custom/Bookshelf-type-01-04_large.png)       |                                                                |
| Bookshelf - type 01 - 05     | ![image](Original/Bookshelf-type-01-05_large.png)       | ![image](Custom/Bookshelf-type-01-05_large.png)       |                                                                |
| Bookshelf - type 01 - 06     | ![image](Original/Bookshelf-type-01-06_large.png)       | ![image](Custom/Bookshelf-type-01-06_large.png)       |                                                                |
| Bookshelf - type 01 - 07     | ![image](Original/Bookshelf-type-01-07_large.png)       | ![image](Custom/Bookshelf-type-01-07_large.png)       |                                                                |
| Bed - type 01 - 00           | ![image](Original/Bed-type-01-00_large.png)             | ![image](Custom/Bed-type-01-00_large.png)             |                                                                |
| Bed - type 01 - 01           | ![image](Original/Bed-type-01-01_large.png)             | ![image](Custom/Bed-type-01-01_large.png)             |                                                                |
| Bed - type 01 - 02           | ![image](Original/Bed-type-01-02_large.png)             | ![image](Custom/Bed-type-01-02_large.png)             |                                                                |
| Bed - type 01 - 03           | ![image](Original/Bed-type-01-03_large.png)             | ![image](Custom/Bed-type-01-03_large.png)             |                                                                |
| Bed - type 01 - 04           | ![image](Original/Bed-type-01-04_large.png)             | ![image](Custom/Bed-type-01-04_large.png)             |                                                                |
| Bed - type 01 - 05           | ![image](Original/Bed-type-01-05_large.png)             | ![image](Custom/Bed-type-01-05_large.png)             |                                                                |
| Bed - type 01 - 06           | ![image](Original/Bed-type-01-06_large.png)             | ![image](Custom/Bed-type-01-06_large.png)             |                                                                |
| Bed - type 01 - 07           | ![image](Original/Bed-type-01-07_large.png)             | ![image](Custom/Bed-type-01-07_large.png)             |                                                                |
| Fridge - type 01 - 00        | ![image](Original/Fridge-type-01-00_large.png)          | ![image](Custom/Fridge-type-01-00_large.png)          |                                                                |
| Fridge - type 01 - 01        | ![image](Original/Fridge-type-01-01_large.png)          | ![image](Custom/Fridge-type-01-01_large.png)          |                                                                |
| Fridge - type 01 - 02        | ![image](Original/Fridge-type-01-02_large.png)          | ![image](Custom/Fridge-type-01-02_large.png)          |                                                                |
| Fridge - type 01 - 03        | ![image](Original/Fridge-type-01-03_large.png)          | ![image](Custom/Fridge-type-01-03_large.png)          |                                                                |
| Fridge - type 01 - 04        | ![image](Original/Fridge-type-01-04_large.png)          | ![image](Custom/Fridge-type-01-04_large.png)          |                                                                |
| Fridge - type 01 - 05        | ![image](Original/Fridge-type-01-05_large.png)          | ![image](Custom/Fridge-type-01-05_large.png)          |                                                                |
| Sink - 01                    | ![image](Original/Sink-00_large.png)                    | ![image](Custom/Sink-00_large.png)                    | This custom sink might be my favorite piece of this project.   |
| Sink - 02                    | ![image](Original/Sink-01_large.png)                    | ![image](Custom/Sink-01_large.png)                    |                                                                |
| Stove - 00                   | ![image](Original/Stove-00_large.png)                   | ![image](Custom/Stove-00_large.png)                   |                                                                |
| Stove - 01                   | ![image](Original/Stove-01_large.png)                   | ![image](Custom/Stove-01_large.png)                   |                                                                |
| Stove - 02                   | ![image](Original/Stove-02_large.png)                   | ![image](Custom/Stove-02_large.png)                   |                                                                |
| Stove - 03                   | ![image](Original/Stove-03_large.png)                   | ![image](Custom/Stove-03_large.png)                   |                                                                |
| Cabnet - 00                  | ![image](Original/Cabnet-00_large.png)                  | ![image](Custom/Cabnet-00_large.png)                  | I guess it's a drawer now                                      |
| Cabnet - 01                  | ![image](Original/Cabnet-01_large.png)                  | ![image](Custom/Cabnet-01_large.png)                  |                                                                |
| Stool - type 01 - 00         | ![image](Original/Stool-type-01-00_large.png)           | ![image](Custom/Stool-type-01-00_large.png)           |                                                                |
| Stool - type 01 - 01         | ![image](Original/Stool-type-01-01_large.png)           | ![image](Custom/Stool-type-01-01_large.png)           |                                                                |
| Stool - type 01 - 02         | ![image](Original/Stool-type-01-02_large.png)           | ![image](Custom/Stool-type-01-02_large.png)           |                                                                |
| Stool - type 01 - 03         | ![image](Original/Stool-type-01-03_large.png)           | ![image](Custom/Stool-type-01-03_large.png)           |                                                                |
| Stool - type 02 - 00         | ![image](Original/Stool-type-02-00_large.png)           | ![image](Custom/Stool-type-02-00_large.png)           |                                                                |
| Stool - type 02 - 01         | ![image](Original/Stool-type-02-01_large.png)           | ![image](Custom/Stool-type-02-01_large.png)           |                                                                |
| Stool - type 02 - 02         | ![image](Original/Stool-type-02-02_large.png)           | ![image](Custom/Stool-type-02-02_large.png)           |                                                                |
| Stool - type 02 - 03         | ![image](Original/Stool-type-02-03_large.png)           | ![image](Custom/Stool-type-02-03_large.png)           |                                                                |
| Radio - type 01 - 00         | ![image](Original/Radio-type-01-00_large.png)           | ![image](Custom/Radio-type-01-00_large.png)           |                                                                |
| Radio - type 01 - 01         | ![image](Original/Radio-type-01-01_large.png)           | ![image](Custom/Radio-type-01-01_large.png)           |                                                                |
| Radio - type 01 - 02         | ![image](Original/Radio-type-01-02_large.png)           | ![image](Custom/Radio-type-01-02_large.png)           |                                                                |
| Radio - type 01 - 03         | ![image](Original/Radio-type-01-03_large.png)           | ![image](Custom/Radio-type-01-03_large.png)           |                                                                |
| Radio - type 02 - 00         | ![image](Original/Radio-type-02-00_large.png)           | ![image](Custom/Radio-type-02-00_large.png)           |                                                                |
| Radio - type 02 - 01         | ![image](Original/Radio-type-02-01_large.png)           | ![image](Custom/Radio-type-02-01_large.png)           |                                                                |
| Radio - type 02 - 02         | ![image](Original/Radio-type-02-02_large.png)           | ![image](Custom/Radio-type-02-02_large.png)           |                                                                |
| Radio - type 02 - 03         | ![image](Original/Radio-type-02-03_large.png)           | ![image](Custom/Radio-type-02-03_large.png)           |                                                                |
| Indoor Exit Mat type 01 - 00 | ![image](Original/Indoor-exit-mat-type-01-00_large.png) | ![image](Custom/Indoor-exit-mat-type-01-00_large.png) |                                                                |
| Indoor Exit Mat type 01 - 01 | ![image](Original/Indoor-exit-mat-type-01-01_large.png) | ![image](Custom/Indoor-exit-mat-type-01-01_large.png) |                                                                |
| Indoor Exit Mat type 02 - 00 | ![image](Original/Indoor-exit-mat-type-02-00_large.png) | ![image](Custom/Indoor-exit-mat-type-02-00_large.png) |                                                                |
| Indoor Exit Mat type 02 - 00 | ![image](Original/Indoor-exit-mat-type-02-01_large.png) | ![image](Custom/Indoor-exit-mat-type-02-01_large.png) |                                                                |

### Constructed Tiles 
| Constructed Tile        | Original                                                         | Custom                                                         |
| ----------------------- | ---------------------------------------------------------------- | -------------------------------------------------------------- |
| Back wall - window      | ![image](Original/Constructed/Back-wall-window_large.png)        | ![image](Custom/Constructed/Back-wall-window_large.png)        |
| Back wall - art         | ![image](Original/Constructed/Back-wall-art_large.png)           | ![image](Custom/Constructed/Back-wall-art_large.png)           |
| Table - type 01         | ![image](Original/Constructed/Table-type-01_large.png)           | ![image](Custom/Constructed/Table-type-01_large.png)           |
| Indoor plant - type 01  | ![image](Original/Constructed/Indoor-plant-type-01_large.png)    | ![image](Custom/Constructed/Indoor-plant-type-01_large.png)    |
| Computer - type 01      | ![image](Original/Constructed/Computer-type-01_large.png)        | ![image](Custom/Constructed/Computer-type-01_large.png)        |
| TV - type 01            | ![image](Original/Constructed/Tv-type-01_large.png)              | ![image](Custom/Constructed/Tv-type-01_large.png)              |
| Bookshelf - type 01     | ![image](Original/Constructed/Bookshelf-type-01_large.png)       | ![image](Custom/Constructed/Bookshelf-type-01_large.png)       |
| Bed - type 01           | ![image](Original/Constructed/Bed-type-01_large.png)             | ![image](Custom/Constructed/Bed-type-01_large.png)             |
| Fridge - type 01        | ![image](Original/Constructed/Fridge-type-01_large.png)          | ![image](Custom/Constructed/Fridge-type-01_large.png)          |
| Sink                    | ![image](Original/Constructed/Sink_large.png)                    | ![image](Custom/Constructed/Sink_large.png)                    |
| Stove                   | ![image](Original/Constructed/Stove_large.png)                   | ![image](Custom/Constructed/Stove_large.png)                   |
| Cabinet                 | ![image](Original/Constructed/Cabinet_large.png)                 | ![image](Custom/Constructed/Cabinet_large.png)                 |
| Stool - type 01         | ![image](Original/Constructed/Stool-type-01_large.png)           | ![image](Custom/Constructed/Stool-type-01_large.png)           |
| Stool - type 02         | ![image](Original/Constructed/Stool-type-02_large.png)           | ![image](Custom/Constructed/Stool-type-02_large.png)           |
| Radio - type 01         | ![image](Original/Constructed/Radio-type-01_large.png)           | ![image](Custom/Constructed/Radio-type-01_large.png)           |
| Radio - type 02         | ![image](Original/Constructed/Radio-type-02_large.png)           | ![image](Custom/Constructed/Radio-type-02_large.png)           |
| Indoor Exit Mat type 01 | ![image](Original/Constructed/Indoor-exit-mat-type-01_large.png) | ![image](Custom/Constructed/Indoor-exit-mat-type-01_large.png) |
| Indoor Exit Mat type 02 | ![image](Original/Constructed/Indoor-exit-mat-type-02_large.png) | ![image](Custom/Constructed/Indoor-exit-mat-type-02_large.png) |


#### Indoor Plant Type 01 Attempts
For fun, here are some attempts at the indoor plant. The first two are from the game, the latter four are my attempts.

![image](Custom/Drafts/Indoor-plant-00-drafts_large.png)

While what I settled on wasn't perfect (see in the tables above), I did learn:
1. The flooring that is 1px hatched tiles also applies to the green area
1. The shading for the plants really makes it. Having the light, medium then dark greens from top to bottom of each leaf.
1. That the pot looks like it's a plant pot from Zelda.

#### Let that sink in
Like noted above, I'm really proud of the sink. I just think it looks neat. Showed it to a friend, and he returned with:

![image](Etc/UpgradingSinkMeme.png)
