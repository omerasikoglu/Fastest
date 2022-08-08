using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {


    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width, int height, float cellSize) {

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {

                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(this, gridPosition);

                //float drawLength = .2f;
                //Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + Vector3.right * drawLength, Color.white, 1000f);
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
        );
    }

    public void CreateDebugObjects(Transform pfDebug) {
        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {

                GridPosition gridPosition = new GridPosition(x,z);
                Transform debugTransform = Instantiate(pfDebug, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDbugObkject = debugTransform.GetComponent<GridDebugObject>();
                gridDbugObkject.SetGridObject(gridObjectArray[x, z]);
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition) {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }
}
