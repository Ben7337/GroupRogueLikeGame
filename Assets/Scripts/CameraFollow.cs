using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum Mode
    {
        Static, StaticMultiple
    }

    public GameObject followedObject;
    public float maxOffset = .2f;
    public float maxRoll = 4;
    public Mode mode;

    private Vector3 centerPosition;
    private float trauma = 0;
    private float xOffset;
    private float yOffset;
    private float rollOffset;
    private List<Vector3> objectList;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case (Mode.Static):
                centerObject(followedObject, .1f);
                break;
            case (Mode.StaticMultiple):
                centerObject(followedObject, .1f);

                break;
        }
        


        xOffset = maxOffset * (trauma / 100) * Random.Range(-1, 1);
        yOffset = maxOffset * (trauma / 100) * Random.Range(-1, 1);
        rollOffset = maxRoll * (trauma / 100) * Random.Range(-1, 1);

        transform.position = centerPosition + new Vector3(xOffset, yOffset);
        transform.rotation = Quaternion.Euler(0,0,rollOffset);
        if(trauma > 0)
            trauma -= 1f;
    }

    public void centerObject(GameObject followObject, float yOffset)
    {
        centerPosition = new Vector3(followObject.transform.position.x, followObject.transform.position.y + .1f, this.transform.position.z);
    }

    public void addTrauma(float addedTrauma)
    {
        if (addedTrauma <= 0)
            return;
        trauma += addedTrauma;
        if (trauma > 100)
            trauma = 100;
    }

    public void setObjectList(List<Vector3> list)
    {
        objectList = list;
    }

    public void setFollowObject(GameObject obj)
    {
        followedObject = obj;
    }


}
