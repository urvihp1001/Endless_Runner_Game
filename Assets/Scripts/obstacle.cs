using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    playerMovement pm;
    void Start()
    {
        pm=GameObject.FindObjectOfType<playerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //kill player
        if(collision.gameObject.name=="Player")
        {
            //checks if obstacle collided with player
            pm.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
