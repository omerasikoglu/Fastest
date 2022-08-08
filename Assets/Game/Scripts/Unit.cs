using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Vector3 targetPosition;

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
    public void Move(Vector3 targetPosition) {
        Vector3 groundHeight = new Vector3(0f, .5f, .5f);
        this.targetPosition = targetPosition + groundHeight;
    }

}
