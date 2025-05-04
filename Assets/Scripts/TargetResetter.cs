using System.Collections.Generic;
using UnityEngine;

public class TargetResetter : MonoBehaviour
{
    public List<GameObject> targetsToReset;    //a list of the targets that can be reset in the inspector
    private class TargetData
    {
        public GameObject target;       //references the target object
        public Vector3 originalPosition;    //the position that the targets spawn at so that it can be referenced when respawning
        public Quaternion originalRotation; //the roation that the targets spawn with so that it can be referenced when respawing is triggered

        public TargetData(GameObject obj)   
        {
            target = obj;
            originalPosition = obj.transform.position;      //stores the starting position of the target
            originalRotation = obj.transform.rotation;      //stores the starting rotation of the target
        }
    }

    private List<TargetData> targetDataList = new List<TargetData>();   //stores original data for each target

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject target in targetsToReset)       //loop through each target in the list
        {
            if (target != null)         //tells it to only run if the game object "target" still exists
            {
                targetDataList.Add(new TargetData(target));     //save the original position and rotation
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))       //if the R key is pressed down it will run this function
        {
            foreach (TargetData data in targetDataList)     //loop through each target 
            {
                if (data.target != null)        //this makes sure the target hasn't been destroyed completely
                {
                    data.target.SetActive(true);       //this reactivates the target
                    data.target.transform.position = data.originalPosition;       //resets position
                    data.target.transform.rotation = data.originalRotation;       //resets rotation

                    Rigidbody rb = data.target.GetComponent<Rigidbody>();     //get the Rigidbody if it has one
                    if (rb != null && !rb.isKinematic)
                    {
                        rb.linearVelocity = Vector3.zero;        //stops all movement 
                        rb.angularVelocity = Vector3.zero;       //stops all spinning       (my targets were spinning still when reset so this makes them stop)
                    }
                }
            }
        }
    }
}
