using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TargetResetter : MonoBehaviour
{
    public List<GameObject> targetsToReset;    //a list of the targets that can be reset in the inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))       //if they R key is pressed down it will run this funciton
        {
            foreach (GameObject target in targetsToReset)     //loops through each gameobject in the list
            {
                if (target != null)        //this makes sure the target hasn't been destroyed completely
                {
                    target.SetActive(true);       //this reactivates the target
                }
            }
        }
    }
}
