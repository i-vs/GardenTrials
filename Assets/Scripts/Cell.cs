using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isAlive = false;  // initial state
    public int numNeighbors = 0;
    private Sprite[] sprites = new Sprite[5];

    enum Colors
    {
        Red = 0,
        Yellow = 1,
        Pink = 2,
        Green = 3,
        Black = 4
    }

    private int ColorsToInt(Colors color)
    {
        return (int)color;
    }

    private void Start()
    {
        sprites[ColorsToInt(Colors.Red)] = Resources.Load<Sprite>("Sprites/zero");
        sprites[ColorsToInt(Colors.Yellow)] = Resources.Load<Sprite>("Sprites/one");
        sprites[ColorsToInt(Colors.Pink)] = Resources.Load<Sprite>("Sprites/two");
        sprites[ColorsToInt(Colors.Green)] = Resources.Load<Sprite>("Sprites/three");
        sprites[ColorsToInt(Colors.Black)] = Resources.Load<Sprite>("Sprites/four");
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
        if (alive)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[ColorsToInt(Colors.Yellow)];
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    /// <summary>
    /// Loads sprites based on number of neighbors
    /// </summary>
    public void LoadSprite()
    {
        if (numNeighbors == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[ColorsToInt(Colors.Green)];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[ColorsToInt(Colors.Pink)];
        }
    }

    /// <summary>
    /// Loads a sprite
    /// </summary>
    /// <param name="sprite"></param>
    public void LoadSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
