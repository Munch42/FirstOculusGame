using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    public GameObject BaseSpawnLocation;

    [SerializeField]
    private Collider objectCollider;
    [SerializeField]
    private bool isBeingCarried = false;
    private bool lastFrameWasBeingCarried = false;
    private Vector3 spawnPosBase;
    private Transform originalParent;

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider>();

        spawnPosBase = BaseSpawnLocation.transform.position;
        originalParent = this.gameObject.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isBeingCarried = !isBeingCarried;
        }

        if (isBeingCarried && !lastFrameWasBeingCarried)
        {
            //float scaleX = this.gameObject.transform.localScale.x;
            float scaleY = this.gameObject.transform.localScale.y;
            float scaleZ = this.gameObject.transform.localScale.z;

            this.gameObject.transform.parent = BaseSpawnLocation.transform;

            // Once it is under the parent, it has a value of Y = -0.8 and Z = -1 while x is still 0
            Vector3 spawnPos = new Vector3(0f, 0.3f - ((0.5f * scaleY) - 0.5f), (((0.5f * scaleZ) - 0.5f) + 1f));
            this.gameObject.transform.position = spawnPos;
            this.gameObject.transform.rotation = BaseSpawnLocation.transform.root.rotation;

            lastFrameWasBeingCarried = true;
        } else if(!isBeingCarried && lastFrameWasBeingCarried)
        {
            lastFrameWasBeingCarried = false;
            this.gameObject.transform.parent = originalParent;
        }
    }

    public void setIsBeingCarried(bool isBeingCarried)
    {
        this.isBeingCarried = isBeingCarried;
    }
    
    public bool getIsBeingCarried()
    {
        return isBeingCarried;
    }
}
