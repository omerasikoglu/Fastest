using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitActionSystem : MonoBehaviour {

    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private Camera mainCam;
    [SerializeField] private LayerMask unitLayerMask;

    public void Awake() {
        Instance = this;
    }

    public void Update() {
        CheckMouseClick(); void CheckMouseClick() {
            if (Input.GetMouseButtonDown(0)) {

                if (TryHandleUnitSelection()) return; //try to pick unit if not picked chosen unit will be move
                if (selectedUnit == null) return;

                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
                if (selectedUnit.GetMoveAction().IsValidActionToGridPosition(mouseGridPosition)) {
                    selectedUnit.GetMoveAction().Move(mouseGridPosition);
                }
            }
        }

    }
    private bool TryHandleUnitSelection() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask)) {

            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit)) {
                SetSelectedUnit(unit);

                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit) {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit() => selectedUnit;
}
