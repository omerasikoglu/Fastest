using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour {

    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform pfGridDebugObject;
    private GridSystem gridSystem;

    [SerializeField] private int width = 3;
    [SerializeField] private int height = 3;
    [SerializeField] private float cellSize = 5;

    public void Awake() {
        Instance = this;
        gridSystem = new GridSystem(width, height, cellSize);
        gridSystem.CreateDebugObjects(pfGridDebugObject);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMoved(Unit unit, GridPosition from, GridPosition to) {
        RemoveUnitAtGridPosition(from, unit);
        AddUnitAtGridPosition(to, unit);
    }


    public GridPosition GetGridPosition(Vector3 worldPosition) {
        return gridSystem.GetGridPosition(worldPosition);
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) {
        return gridSystem.GetWorldPosition(gridPosition);
    }

    public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

    public bool HasAnyObjectInGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyUnit();
    }

    public int GetWidth() => width;
    public int GetHeight() => height;
    public float GetCellSize() => cellSize;

}
