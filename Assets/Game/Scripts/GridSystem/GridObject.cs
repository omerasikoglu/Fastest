using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridObject {

    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) {

        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public void AddUnit(Unit unit) {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit) {
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList() {
        return unitList;
    }

    public bool HasAnyUnit() => unitList.Count > 0;


    public override string ToString() {

        string result = string.Empty;
        foreach (Unit unit in unitList) {
            result += $" <b><color=blue>{gridPosition}</color>\n <color=red>{unit}</color></b>\n";
        }
        return $" <color=black  >{gridPosition}</color>\n{result}";

        //string result2 = unitList.Aggregate(string.Empty,
        //    (o, next) => o + $" <color=yellow>{gridPosition}</color>\n <color=red>{unit}</color>\n",
        //    o => o.ToUpper());
        //return $" <color=yellow>{gridPosition}</color>\n{result2}";
    }


}
