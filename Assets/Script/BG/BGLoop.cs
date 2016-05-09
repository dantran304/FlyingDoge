using UnityEngine;
using System.Collections;

public class BGLoop : MonoBehaviour {

    // Use this for initialization
    public GameObject spawnPosition;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BG")
        {
            other.gameObject.transform.position = spawnPosition.transform.position;
        }
    }
}
