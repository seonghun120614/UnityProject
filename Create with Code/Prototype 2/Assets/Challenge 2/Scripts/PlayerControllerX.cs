
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool enableSpace = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && enableSpace)
        {
            enableSpace = false;
            SpawnDog();
        }
    }

    void EnableSpace()
    {
        enableSpace = !enableSpace;
    }

    void SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        Invoke("EnableSpace", 0.5f);
    }
}
