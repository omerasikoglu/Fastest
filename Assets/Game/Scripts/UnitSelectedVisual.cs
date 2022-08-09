using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour {

    [SerializeField] private Unit unit;
    private MeshRenderer meshRenderer;

    public void OnEnable() {
        UnitActionSystem.Instance.OnSelectedUnitChanged += Instance_OnSelectedUnitChanged;
    }
    public void OnDisable() {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= Instance_OnSelectedUnitChanged;
    }
    private void Instance_OnSelectedUnitChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        meshRenderer.enabled = UnitActionSystem.Instance.GetSelectedUnit() == unit;
    }

    public void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateVisual();
    }


}
