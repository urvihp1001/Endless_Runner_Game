using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnSpeed=90f;//90 deg every sec rotate
    private void OnTriggerEnter(Collider other)
    {
     //check if obj collided with is player
        if(other.gameObject.name!="Player")
        {
            return;//do nothing
        }//gameObject refers to this game object
     //add score

    GameManager.inst.IncrementScore();
     //destroy coin obj
    Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);//turn along 90 degrees
        
    }
}
