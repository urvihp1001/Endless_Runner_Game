using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
     offset=transform.position-player.position;//camera kept at the same distance from player at all times   
    }

    // Update is called once per frame
    void Update()
    {   //camera stays in middle regardless of position of player
        Vector3 targetPosition=player.position+offset;
        targetPosition.x=0;//x goes left and right but if x=0 camera stays in middle even if player moves sideways
        transform.position=targetPosition;
    }
}
