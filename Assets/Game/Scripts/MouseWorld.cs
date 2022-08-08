using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseWorld : MonoBehaviour {

    private static MouseWorld instance;


    [SerializeField] private LayerMask mousePlaneLayerMask;
    [SerializeField] private Camera cam;

    private void Awake() {
        instance = this;
    }

    public static Vector3 GetPosition() {
        Ray ray = MouseWorld.instance.cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }

}