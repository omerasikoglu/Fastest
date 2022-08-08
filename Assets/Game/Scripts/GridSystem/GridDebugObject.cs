using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour {

    private GridObject gridObject;
    [SerializeField] private TextMeshPro textMesh;

    public void Update() {
        textMesh.text = gridObject.ToString();
    }

    public void SetGridObject(GridObject gridObject) {
        this.gridObject = gridObject;
    }


}
