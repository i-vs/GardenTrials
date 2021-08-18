using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization; 

public class Garden : MonoBehaviour
{
    private static int SCREEN_WIDTH = 128;   //64 // 1024 px  the X axis -> COLUMNS!!
    private static int SCREEN_HEIGHT = 96;  //48  // 768 px   the Y axis -> ROWS!!
    public float speed = 0.1f;
    private float timer = 0;

    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];   
    public HUD hud;
    public PlayButton playButton;
    public PauseButton pauseButton;
    public bool simulationEnabled = false;
    private Sprite yellow;
    private Sprite black;
    private Sprite red;

    void Start()
    {
        yellow = Resources.Load<Sprite>("Sprites/one"); 
        black = Resources.Load<Sprite>("Sprites/four");
        red = Resources.Load<Sprite>("Sprites/zero");
        EventManager.StartListening("SavePattern", SavePattern);
        EventManager.StartListening("LoadPattern", LoadPattern);
        //EventManager.StartListening("LoadInfo", LoadInfo);
        PlaceCells();
    }

    void Update()
    {
        if (pauseButton.IsButtonClicked && simulationEnabled)
        {
            simulationEnabled = false;
        }
        else if (playButton.IsButtonClicked && !simulationEnabled)
        {
            simulationEnabled = true;
        }

        playButton.ResetButton();
        pauseButton.ResetButton();

        if (simulationEnabled)
        {
            if (timer >= speed)
            {
                timer = 0f;
                CountNeighbors();
                PopulationControl();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        UserInput();
    }


    private void LoadPattern()
    {
        string path = "gardenpatterns";
        if (!Directory.Exists(path))
        {
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
        string patternName = hud.loadPatternMenu.dropDownMenu.options[hud.loadPatternMenu.dropDownMenu.value].text;
        path = path + "\\" + patternName + ".xml";


        StreamReader reader = new StreamReader(path);
        Pattern pattern = (Pattern)serializer.Deserialize(reader.BaseStream);
        reader.Close();

        bool isAliVe;
        int x = 0, y = 0;

        foreach (char c in pattern.patternString)
        {
            if (c.ToString() == "O")
            {
                isAliVe = true;
            }
            else
            {
                isAliVe = false;
            }

            grid[x, y].SetAlive(isAliVe);
            grid[x, y].LoadSprite(yellow);
            x++;

            if (x == SCREEN_WIDTH)      // reached the end of the screen
            {
                x = 0;
                y++;                    // y will only be incremented when it reaches the end of the screen 
            }
        }
    }


    private void SavePattern()
    {
        // set a directory to save/store the patterns/ pattern files
        string path = "gardenpatterns";   // the name of the folder that will live in the root of the project 
        // check to see if that directory already exists.

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        Pattern pattern = new Pattern();
        string patternString = null;
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                if (grid[x, y].isAlive == false)
                {
                    patternString += ".";
                }
                else
                {
                    patternString += "O";
                }
            }
        }

        pattern.patternString = patternString;
        XmlSerializer serializer = new XmlSerializer(typeof(Pattern));
        StreamWriter writer = new StreamWriter(path + "\\" + hud.savePatternMenu.patternNameField.text + ".xml");
        serializer.Serialize(writer.BaseStream, pattern);
        writer.Close();
    }


    void UserInput()
    {
        if (!hud.active)
        {
            if (Input.GetMouseButtonDown(0))  // zero = left
            {
                Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                int x = Mathf.RoundToInt(mousePoint.x);
                int y = Mathf.RoundToInt(mousePoint.y);

                // check screen bounds
                if (x >= 0 && y >= 0 && x < SCREEN_WIDTH && y < SCREEN_HEIGHT)
                {
                    // then it's inside the bounds. if true, not true, if false, not false 
                    grid[x, y].SetAlive(!grid[x, y].isAlive);
                    if (simulationEnabled)
                    {
                        grid[x, y].LoadSprite(red);
                    }
                    else
                    {
                        grid[x, y].LoadSprite(yellow);
                    }
                }
            }

/*            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Pause
                if (!playButton.IsButtonClicked && !pauseButton.IsButtonClicked)
                {
                    simulationEnabled = !simulationEnabled;
                }
            }*/

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Pause
                if (!playButton.IsButtonClicked && !pauseButton.IsButtonClicked)
                {
                    simulationEnabled = !simulationEnabled;
                }
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                //SavePattern();
                hud.ShowSaveMenu();
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                //LoadPattern();
                hud.ShowLoadMenu();
            }
        }
    }


    void PlaceCells()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                Cell cell;                    
                cell = Instantiate(Resources.Load("Prefabs/CellOne", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                    
                grid[x, y] = cell;
                grid[x, y].SetAlive(false);
            }
        }
        QueenBee();
    }

    private void QueenBee()
    {
        var y1 = new List<int> { 52, 51, 50, 46, 45, 44 };
        var y2 = new List<int> { 49, 48, 47 };
        var y3 = new List<int> { 50, 46 };
        var y4 = new List<int> { 49, 47 };

        for (int x = 62; x < 67; x++)
        {
            if (x == 62)
            {
                foreach (int y in y1)
                {
                    grid[x, y].SetAlive(true);
                    grid[x, y].LoadSprite(black);
                }
            }

            if (x == 63)
            {
                foreach (int y in y2)
                {
                    grid[x, y].SetAlive(true);
                    grid[x, y].LoadSprite(yellow);
                }
            }

            if (x == 64)
            {
                foreach (int y in y3)
                {
                    grid[x, y].SetAlive(true);
                    grid[x, y].LoadSprite(black);
                }
            }

            if (x == 65)
            {
                foreach (int y in y4)
                {
                    grid[x, y].SetAlive(true);
                    grid[x, y].LoadSprite(yellow);
                }
            }

            if (x == 66)
            {
                grid[x, 48].SetAlive(true);
                grid[x, 48].LoadSprite(black);
            }
        }
    }


    void CountNeighbors()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)    // 0 to 47 THE NEIGHBOR WOULD BE 48
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)      // 0 to 63 -> the highest x can get
            {
                int numNeighbors = 0;

                //========NORTH==========//
                if (y + 1 < SCREEN_HEIGHT) // Ex: if y it's at 63, 63 +1 == 64 Vizinho
                {
                    if (grid[x, y + 1].isAlive) // if the cell's property is set to true
                    {
                        numNeighbors++;
                    }
                }

                //========EAST==========//
                if (x + 1 < SCREEN_WIDTH)
                {
                    if (grid[x + 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========SOUTH==========//
                if (y - 1 >= 0)
                {
                    if (grid[x, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========WEST==========//
                if (x - 1 >= 0)
                {
                    if (grid[x - 1, y].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========NORTHEAST==========// bounds
                if (x + 1 < SCREEN_WIDTH && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x + 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========NORTHWEST==========// 
                if (x - 1 >= 0 && y + 1 < SCREEN_HEIGHT)
                {
                    if (grid[x - 1, y + 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========SOUTHEAST==========//
                if (x + 1 < SCREEN_WIDTH && y - 1 >= 0)
                {
                    if (grid[x + 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                //========SOUTHWEST==========//
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (grid[x - 1, y - 1].isAlive)
                    {
                        numNeighbors++;
                    }
                }

                // setting this numNeighbors value to numNeighbors from the cell class property
                grid[x, y].numNeighbors = numNeighbors;
            }
        }
    }


    void PopulationControl()
    {
        for (int y = 0; y < SCREEN_HEIGHT; y++)
        {
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                bool shouldBeAlive = grid[x,y].isAlive;
                if (grid[x, y].isAlive) // cell is alive
                {
                    if (grid[x, y].numNeighbors != 2 && grid[x, y].numNeighbors != 3)
                    {
                        shouldBeAlive = false;
                    }
                }
                else  // if the cell is dead
                {
                    if (grid[x, y].numNeighbors == 3)  // if it has exactly 3 neighbors, brings it to life
                    {
                        shouldBeAlive = true;
                    }
                }
                grid[x, y].SetAlive(shouldBeAlive);
                grid[x, y].LoadSprite();
            }
        }
    }

    // Rules:
    // Each cell with one or no neighbors dies, as if by solitude.
    // Each cell with four or more neighbors dies, as if by overpopulation.
    // Each cell with two or three neighbors survives.
    // For a space that is empty or unpopulated
    // Each cell with three neighbors becomes populated.
}

