using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Vector3 targetPosition;
    private GridPosition currentGridPosition;

    public void Awake() {
        targetPosition = transform.position;
    }

    public void Start() {
        currentGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(currentGridPosition, this);
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

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newGridPosition != currentGridPosition) {
            LevelGrid.Instance.UnitMoved(this, currentGridPosition, newGridPosition);
            currentGridPosition = newGridPosition;
        }
    }
    public void Move(Vector3 targetPosition) {
        Vector3 groundHeight = new Vector3(0f, .5f, .5f);
        this.targetPosition = targetPosition + groundHeight;
    }

}
