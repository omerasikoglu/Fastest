using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform pfGridDebugObjects;
    private GridSystem gridSystem;
    public void Start() {
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(pfGridDebugObjects);
    }
    public void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
    }
}
