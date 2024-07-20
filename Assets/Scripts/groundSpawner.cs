
using UnityEngine;
using UnityEngine.UIElements;
//plane defines tile and newspawnpoint defines where to start new tile
public class groundSpawner : MonoBehaviour
{
     [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
   public void SpawnTile( bool SpawnItems)
    {
       GameObject temp= Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);//how to spwan an object in unity
        //1st object is the one you want to instantiate
        //2nd where you want to spawn
        //3rd is rotation of spawned object
        //Quaternion.identity means no rotation
        //
        
        nextSpawnPoint=temp.transform.GetChild(1).transform.position; //2nd child
        if(SpawnItems)
        {
            temp.GetComponent<groundTile>().spawnObstacle();
            temp.GetComponent<groundTile>().SpawnCoins();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<15;i++)
        {
            if(i<3)
            {
                SpawnTile(false);
            }
            else{
                SpawnTile(true);
            }
        }
       
    }


}
