using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    bool alive=true;
    // Start is called before the first frame update
    public float speed=5;
    public float speedIncreasePerPoint=0.1f;
    [SerializeField] Rigidbody rb;
    [SerializeField]float horizontalInput;
    public float horizontalMultiplier=2;
    public void FixedUpdate() //get player moving
    {
        if(!alive)
        {
            return;//stop running function of movement if player not alive
        }
        //at 50rps to give physics engine a stable base to work with every 0.2s
        Vector3 forwardMove=transform.forward*speed*Time.fixedDeltaTime;//transform.forward- dirn where player is facing
        Vector3 horizontalMove=transform.right*horizontalInput*speed*Time.fixedDeltaTime*horizontalMultiplier;//a and d, left right keys press for horiz movement
        rb.MovePosition(rb.position+forwardMove+horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        if(transform.position.y<-5)//if player has fallen off platform-- vert posn <5
        {
            Die();
        }
    }
    public void Die()
    {
        alive=false;
        //restart game
        Invoke("Restart",2);

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load current scene again
    }
}
