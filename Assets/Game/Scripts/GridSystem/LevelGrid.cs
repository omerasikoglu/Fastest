﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour {

    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform pfGridDebugObject;
    private GridSystem gridSystem;
    public void Awake() {
        Instance = this;
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(pfGridDebugObject);
    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(unit);
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnit();
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition) {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(null);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return gridSystem.GetGridPosition(worldPosition);
    }

}
