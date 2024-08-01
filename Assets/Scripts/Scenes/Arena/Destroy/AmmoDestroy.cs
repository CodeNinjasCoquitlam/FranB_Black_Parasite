using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AmmoBox")
        {
            Destroy(other.gameObject);
        }
    }
}
