# Pokemon gen 2 style tilemap

## Wanted simple tiles
- Path with gravel(?)
  - This is the most common path in Gen 2 Pokemon
- Path without gravel 
  - A completely blank tile. Usually intersperced with the path with gravel.
- Flat grass
  - In Gen 2, the green that isn't tall, wild Pokemon grass
- Tall grass
  - In Gen 2, the majority of the grass Pokemon will appear in. Shakes when player walks through it.
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
