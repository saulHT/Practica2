using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.position.x +4f;
        var y = player.position.y-1f;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
