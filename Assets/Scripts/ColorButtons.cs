using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour
{
    /***
    * 0 : Red
    * 1 : Green
    * 2 : Blue
    * 3 : Yellow
    * 4 : Purple
    */

    private GridGenerator _grid;
    public Button[] buttons;
    public int selectedColor;


    private void Awake()
    {
        _grid = FindObjectOfType<GridGenerator>();
    }

    private void Start()
    {
        selectedColor = -1;
        for (int i=0; i<buttons.Length; i++)
        {
            int _colorIndex = i;
            buttons[i].onClick.AddListener(() => OnClick_ColorButton(_colorIndex));
        }
    }

    private void OnClick_ColorButton(int colorIndex)
    {
        selectedColor = colorIndex;
        for (int i=0; i<_grid.gridElements.Count; i++)
        {
            if (i == 0 && _grid.gridElements[i].GetComponent<Square>().isFirst)
            {
                _grid.gridElements[0].GetComponent<SpriteRenderer>().color = _grid.GetSelectedColor();
                _grid.gridElements[0].GetComponent<Square>().GoRight();
                _grid.gridElements[0].GetComponent<Square>().GoLeft();
                _grid.gridElements[0].GetComponent<Square>().GoUp();
                _grid.gridElements[0].GetComponent<Square>().GoDown();
            }
            else if (i > 0 && _grid.gridElements[i].GetComponent<Square>().isOwned)
            {
                _grid.gridElements[i].GetComponent<Square>().GoRight();
                _grid.gridElements[i].GetComponent<Square>().GoLeft();
                _grid.gridElements[i].GetComponent<Square>().GoUp();
                _grid.gridElements[i].GetComponent<Square>().GoDown();
            }
        }
    }
}
