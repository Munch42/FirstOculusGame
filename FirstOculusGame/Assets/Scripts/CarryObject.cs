using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public GameObject BaseSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosBase = BaseSpawnLocation.transform.position;

        float scaleX = this.gameObject.transform.localScale.x;
        float scaleY = this.gameObject.transform.localScale.y;
        float scaleZ = this.gameObject.transform.localScale.z;

        // Must work on the dynamic loading of position based on scale of object.
        Vector3 spawnPos = new Vector3(0f, -0.5f, ((0.5f * ((scaleX + scaleY + scaleZ) / 3f)) - 0.5f));
        this.gameObject.transform.position = spawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
