
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", Random.Range(3,5));
    }


    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        randomInt = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        Instantiate(ballPrefabs[randomInt], spawnPos, ballPrefabs[randomInt].transform.rotation);

        Invoke("SpawnRandomBall", Random.Range(3, 5));
    }

}
