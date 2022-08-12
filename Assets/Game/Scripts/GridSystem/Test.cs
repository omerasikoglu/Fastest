using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField] private Unit unit;
    public void Start() {

    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            unit.GetMoveAction().GetValidActionGridPositionList();
        }
    }
}
