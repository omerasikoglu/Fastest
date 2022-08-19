using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridSystemVisual : MonoBehaviour {

    public static GridSystemVisual Instance { get; private set; }

    [SerializeField] private Transform pfGridSystemVisualSingle;

    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    public void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Start() {

        int width = LevelGrid.Instance.GetWidth();
        int height = LevelGrid.Instance.GetHeight();

        gridSystemVisualSingleArray = new GridSystemVisualSingle[width, height];

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform pfGridSystemVisualSingleTransform = Object.Instantiate(
                    pfGridSystemVisualSingle, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = pfGridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
            }
        }
    }
    public void Update() {
        UpdateGridVisual();
    }
    public void UpdateGridVisual() {

        HideAllGridPosition();
        Unit unit = UnitActionSystem.Instance.GetSelectedUnit();
        if (unit == null) return;
        List<GridPosition> validPositionList = unit.GetMoveAction().GetValidActionGridPositionList();
        ShowGridPositionList(validPositionList);
    }
    public void HideAllGridPosition() {

        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++) {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++) {
                gridSystemVisualSingleArray[x, z].Hide();
            }
        }

    }
    public void ShowGridPositionList(List<GridPosition> gridPositionList) {
        foreach (GridPosition gridPosition in gridPositionList) {
            gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show();
        }
    }
    //public void ShowAllGridPosition() {
    //    for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++) {
    //        for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++) {
    //            gridSystemVisualSingleArray[x, z].Show();
    //        }
    //    }


}
