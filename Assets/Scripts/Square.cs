using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [System.Serializable]
    public class Neighbours
    {
        public Square leftNeighbour;
        public Square rightNeighbour;
        public Square upperNeighbour;
        public Square lowerNeighbour; 
    }

    public bool isFirst;
    public bool isOwned;
    public float x;
    public float y;
    public Neighbours neighbourSquares = new Neighbours();

    public Square(bool _isOwned, float _x, float _y)
    {
        isOwned = _isOwned;
        x = _x;
        y = _y;
    }

    public void GetNeighbourSquares()
    {
        Square[] allSquares = FindObjectsOfType<Square>();
        
        int leftNeighbour = Mathf.RoundToInt(y) - 1;
        int rightNeighbour = Mathf.RoundToInt(y) + 1;
        int upperNieghbour = Mathf.RoundToInt(x) + 1;
        int lowerNeighbour = Mathf.RoundToInt(x) - 1;

        for (int i=0; i<allSquares.Length; i++)
        {
            // Left neighbour
            if (allSquares[i].x == x && allSquares[i].y == leftNeighbour)
            {
                neighbourSquares.leftNeighbour = allSquares[i];
            }

            // Right neighbour
            if (allSquares[i].x == x && allSquares[i].y == rightNeighbour)
            {
                neighbourSquares.rightNeighbour = allSquares[i];
            }

            // Upper neighbour
            if (allSquares[i].x == upperNieghbour && allSquares[i].y == y)
            {
                neighbourSquares.upperNeighbour = allSquares[i];
            }

            // Lower neighbour
            if (allSquares[i].x == lowerNeighbour && allSquares[i].y == y)
            {
                neighbourSquares.lowerNeighbour = allSquares[i];
            }
        }
    }

    /**
    * DIRECTIONS
    * 0: RIGHT
    * 1: LEFT
    * 2: UP
    * 3: DOWN
    */

    public void GoLeft()
    {
        ChangeColor(neighbourSquares.leftNeighbour, 1);
    }

    public void GoRight()
    {
        ChangeColor(neighbourSquares.rightNeighbour, 0);
    }

    public void GoUp()
    {
        ChangeColor(neighbourSquares.upperNeighbour, 2);
    }

    public void GoDown()
    {
        ChangeColor(neighbourSquares.lowerNeighbour, 3);
    }

    private void ChangeColor(Square s, int direction)
    {
        Color selectedColor = FindObjectOfType<GridGenerator>().GetSelectedColor();

        if (s != null)
        {
            if (s.GetComponent<SpriteRenderer>().color == selectedColor)
            {
                s.isOwned = true;
                Move(s, direction);
            }
            else if (s.GetComponent<SpriteRenderer>().color != selectedColor && s.isOwned)
            {
                s.GetComponent<SpriteRenderer>().color = selectedColor;
                Move(s, direction);
            }
        }
    }

    private void Move(Square s, int direction)
    {
        switch(direction)
        {
            case 0:
                s.GoRight();
            break;
            
            case 1:
                s.GoLeft();
            break;

            case 2:
                s.GoUp();
            break;
            
            case 3:
                s.GoDown();
            break;
        }
    }
}
