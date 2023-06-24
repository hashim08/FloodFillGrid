using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;
    public GameObject square;
    public Transform squareParent;
    public List<GameObject> gridElements = new List<GameObject>();
    public List<Color> squareColors;

    public void GenerateGrid()
    {
        for (int x=0; x<gridWidth; x++)
        {
            for (int y=0; y<gridHeight; y++)
            {
                Vector2 positionVector = new Vector2();

                if (gridWidth%2 == 0)
                {
                    // positionVector.x = x - (gridWidth / 2f) + 0.5f;
                    // positionVector.y = y - (gridHeight / 2f) + 0.5f;
                    positionVector.x = y - (gridHeight / 2f) + 0.5f;
                    positionVector.y = x - (gridWidth / 2f) + 0.5f;
                }
                else
                {
                    // positionVector.x = x - gridWidth / 2;
                    // positionVector.y = y - gridHeight / 2;
                    positionVector.x = y - gridHeight / 2;
                    positionVector.y = x - gridWidth / 2;
                }

                GameObject _obj = Instantiate(square, positionVector, Quaternion.identity);
                _obj.GetComponent<SpriteRenderer>().color = squareColors[Random.Range(0, squareColors.Count)];
                Square _s = _obj.GetComponent<Square>();
                _s.isOwned = x == 0 && y == 0? true : false;
                _s.x = x;
                _s.y = y;
                _s.isFirst = x == 0 && y == 0? true : false;
                _obj.transform.parent = squareParent; 
                gridElements.Add(_obj);
            }
        }

        // Get neighbour squares for each square
        for (int i=0; i<gridElements.Count; i++)
        {
            gridElements[i].GetComponent<Square>().GetNeighbourSquares();
        }
    }

    public void ClearGrid()
    {
        SpriteRenderer[] objects = FindObjectsOfType<SpriteRenderer>();
        for (int i=0; i<objects.Length; i++)
        {
            DestroyImmediate(objects[i].gameObject);
        }
        gridElements = new List<GameObject>();
    }

    public Color GetSelectedColor()
    {
        switch(FindObjectOfType<ColorButtons>().selectedColor)
        {
            case 0:
                return Color.red;

            case 1:
                return Color.green;

            case 2:
                return Color.blue;

            case 3:
                return Color.yellow;

            case 4:
                return Color.magenta;
        }

        return Color.black;
    }
}
