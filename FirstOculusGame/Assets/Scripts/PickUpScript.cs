using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    public Transform theDest;
    private void OnMouseDown() {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }


    void OnMouseUp() {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
