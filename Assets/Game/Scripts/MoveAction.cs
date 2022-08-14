using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour {

    [SerializeField] private int maxMoveDistance;

    private Vector3 targetPosition;
    private Unit unit => GetComponent<Unit>();
    public void Awake() {
        targetPosition = transform.position;
    }

    public void Update() {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance) {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveSpeed * moveDirection * Time.deltaTime;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        }
    }

    public void Move(GridPosition gridPosition) {
        Vector3 groundHeight = new Vector3(0f, .5f, 0f);
        Vector3 targetPositionWithoutHeight = LevelGrid.Instance.GetWorldPosition(gridPosition);
        this.targetPosition = targetPositionWithoutHeight + groundHeight;
    }

    public bool IsValidActionToGridPosition(GridPosition gridPosition) {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);

    }

    public List<GridPosition> GetValidActionGridPositionList() {

        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPos = unit.GetGridPosition();

        for (int x = -maxMoveDistance; x < maxMoveDistance + 1; x++) {
            for (int z = -maxMoveDistance; z < maxMoveDistance + 1; z++) {
                GridPosition offsetGridPos = new GridPosition(x, z);
                GridPosition testGridPos = offsetGridPos + unitGridPos;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPos)) continue;
                if (LevelGrid.Instance.HasAnyObjectInGridPosition(testGridPos)) continue;
                if (unitGridPos == testGridPos) continue;

                validGridPositionList.Add(testGridPos);
                //Debug.Log(testGridPos);
            }
        }




        return validGridPositionList;
    }

}
