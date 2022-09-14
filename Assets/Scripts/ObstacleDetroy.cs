using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if(transform.position.z < -15)
            Destroy(gameObject);
    }
}
