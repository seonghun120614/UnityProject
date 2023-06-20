
using UnityEngine;

public class BallTransform : MonoBehaviour
{
    public Vector3 positionChange;
    public bool front = true;

    private void Update()
    {
        if(front) transform.position -= positionChange;
        if(!front) transform.position += positionChange;
        if(transform.position.z < -5) front = false;
        if(transform.position.z > 5) front = true;
    }
}