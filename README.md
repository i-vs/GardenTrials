# Garden Trials

#### 
An interactive visualization of John Conway’s cellular automaton [Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)


## Undecidable Problems, Patterns, and _Life_

Most computer science problems are like logical puzzles: they can be solved with practice and pattern recognition.
Data structures and algorithms are patterns that can help us find different solutions for things that normally have *predictable behavior*. However, some problems are simply [undecidable](https://en.wikipedia.org/wiki/Halting_problem).

A great example of (_generally_) unpredictable patterns can be experimented in John Conway’s cellular automaton ["Game of Life"](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life); a “no-player, never-ending game.”, in the author's words. 

The Game of Life was only one of Conway’s innumerable contributions to game theory and mathematics. This popular cellular automata simulation takes place on a 2-dimensional grid. Cells can either survive for generations or die, given the following rules:

- If a live cell has less than two live neighbors, it dies of underpopulation.
- If a live cell has more than three live neighbors, it dies of overpopulation.
- If a live cell has exactly two or three live neighbors, it survives.
- If a dead cell has three live neighbors, it will come to life.

For this project I implemented a "garden" of *Life*, as simple as it should be: a garden where the user can plant seeds (or cells) and bring plants and flowers to life. The plants can either survive through generations or die, according to the game's rules. 

[As a tribute to the author](https://www.youtube.com/watch?v=E8kUJL04ELA), every lone [glider](https://conwaylife.com/wiki/Glider) in the garden is considered an *ant*.

## Features

- Two-dimensional cellular automata viewer.

- Interactive gameplay:
  - Possible to insert yellow <img src="Assets/Resources/Sprites/one.png" alt="yellow Cell" width="8" height="8"> seeds and create patterns while the game is paused, and red <img src="Assets/Resources/Sprites/zero.png" alt="Cell" width="8" height="8"> seeds while the game is running to modify the _garden_ state.

  - ```Pause```, ```Play```, and ```Exit``` options (buttons and shortcuts).

  - A ```Rules``` button with a brief explanation of the game's rules.

  - ```Save``` and ```Load``` options for user-created patterns.

  - Some common patterns to load from the ```gardenpatterns``` file (names are used within the game context).

- Color-changing seeds according to the population growth: 
  - <img src="Assets/Resources/Sprites/two.png" alt="red Cell" width="8" height="8"> for 2 neighbors and <img src="Assets/Resources/Sprites/three.png" alt="green Cell" width="8" height="8"> for 3 neighbors.

## Technology Choices

- Written and developed in C#, using Unity 2D ([Engine](https://store.unity.com/download?ref=personal) and [Script API](https://docs.unity3d.com/ru/2020.1/ScriptReference/index.html))
- UI Canvas system
- Executable (.exe only)

### Future improvements

1. Population counter.
1. Expand/unbound the grid area. 
1. Sliders to control the seeds' growth speed.
1. Add information about the project and the game.

### To install:
- Download the files tagged #gardentrials on [Releases](https://github.com/ivsgit/GardenTrials/releases) (Windows 7 SP1+, 8, 10, 64-bit versions only; Full screen and Window versions included).
- Or clone this repo and run with Unity's editor (created with Unity 2D Version 2020.3.15f2).
#
###
####
######
*Please note that this is a work in progress. My goal with this project was to learn and understand new concepts for study purposes and personal interest. Some of the features and algorithms I would like to implement (such as allowing patterns with quadractic growth to expand the grid dynamically) may require more than just a few weeks of study; I plan to use different platforms and technologies in the future.
