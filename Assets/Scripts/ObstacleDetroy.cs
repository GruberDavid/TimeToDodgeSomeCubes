using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetroy : MonoBehaviour
{
    private float timeToDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
