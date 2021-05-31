using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldFloat : MonoBehaviour
{
    private Vector3 positionn;
    // Start is called before the first frame update
    void Start()
    {
        positionn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = positionn;
    }
}
