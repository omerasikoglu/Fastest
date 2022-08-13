using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {


    private GridPosition currentGridPosition;
    private MoveAction moveAction;


    public void Awake() {
        moveAction = GetComponent<MoveAction>();
    }
    public void Start() {
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);
    }
    public void Update() {

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newGridPosition != currentGridPosition) {
            LevelGrid.Instance.UnitMoved(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
    }


    public MoveAction GetMoveAction() => moveAction;
    public GridPosition GetGridPosition() => currentGridPosition;


}
