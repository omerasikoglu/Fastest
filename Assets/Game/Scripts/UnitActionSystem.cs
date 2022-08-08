using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour {

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private Camera mainCam;
    [SerializeField] private LayerMask unitLayerMask;

    public void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (TryHandleUnitSelection()) return;
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }
    private bool TryHandleUnitSelection() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask)) {

            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit)) {
                selectedUnit = unit;
                return true;
            }
        }
        return false;
    }
}
