using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject {

    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private Unit unit;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) {

        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public void SetUnit(Unit unit) {
        this.unit = unit;
    }
    public Unit GetUnit() => unit;

    public override string ToString() {
        return $" <color=yellow>{gridPosition}</color>\n <color=red>{unit}</color>";
        //return gridPosition.ToString() + "\n" + unit;
    }


}
