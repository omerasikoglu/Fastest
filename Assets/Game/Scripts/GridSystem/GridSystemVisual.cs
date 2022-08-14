using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour {

    [SerializeField] private Transform pfGridSystemVisualSingle;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;


    public void Start() {

        int width = LevelGrid.Instance.GetWidth();
        int height = LevelGrid.Instance.GetHeight();

        gridSystemVisualSingleArray = new GridSystemVisualSingle[width, height];

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {
                GridPosition gridPosition = new GridPosition(width, height);
                Transform pfGridSystemVisualSingleTransform = Object.Instantiate(
                    pfGridSystemVisualSingle, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = pfGridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
            }
        }
    }

    public void HideAllGridPosition() {

    }


}
