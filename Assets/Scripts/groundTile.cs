

using UnityEngine;

public class groundTile : MonoBehaviour
{
    groundSpawner groundspawner;
    // Start is called before the first frame update
    void Start()
    {
        groundspawner=GameObject.FindObjectOfType<groundSpawner>();
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<obstacle>()!=null)
        {
            Destroy(gameObject);//so that coins are not on obstacle
            return;
        }
        //check if player has exited the tile- coz nothing else is moving
        //groundSpawner.spawnTile() is private so can't access
        groundspawner.SpawnTile(true);
        //destroy gameobject 2 seconds after player leaves trigger
        Destroy(gameObject,2);

    }
    
    [SerializeField]public GameObject obstaclePrefab;
    public void spawnObstacle()
    {
        //choose a random point to spawn obstacle
        int obstacleSPawnIndex=Random.Range(2,5);//random number between 2 and 4 inclusive all
        Transform spawnPoint=transform.GetChild(obstacleSPawnIndex).transform;//specify game object's transform
        //spawn obstacle at that position
        Instantiate(obstaclePrefab,spawnPoint.position,UnityEngine.Quaternion.identity,transform);
    }
    [SerializeField] GameObject coinPrefab;
    public void SpawnCoins()
    {
        int coinsToSpawn=10;
        for(int i=0; i<coinsToSpawn;i++)
        {
            GameObject temp=Instantiate(coinPrefab, transform);
            temp.transform.position=GetRandomPointInCollider(GetComponent<Collider>());
        }
        
    }
    UnityEngine.Vector3 GetRandomPointInCollider(Collider collider)
    {
      UnityEngine.Vector3 point =new UnityEngine.Vector3(  Random.Range(collider.bounds.min.x,collider.bounds.max.x), //left to right
         Random.Range(collider.bounds.min.y,collider.bounds.max.y),//up to down
          Random.Range(collider.bounds.min.z,collider.bounds.max.z));//fwd to back)
          if(point!=collider.ClosestPoint(point)){
            point=GetRandomPointInCollider(collider);
          }
          point.y=1;//coins all spawn at same height
          return point;
    }
}
