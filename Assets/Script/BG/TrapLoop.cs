using UnityEngine;
using System.Collections;

public class TrapLoop : MonoBehaviour
{

    public GameObject trapSpawnPosition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            other.gameObject.transform.position = trapSpawnPosition.transform.position;

            //set random vi tri cho trap
            Trap.Instance.RandomTrapPosition();
        }

        //destroy coin
        //if (other.gameObject.tag == "Coin")
        //{
        //    Destroy(other.gameObject);
        //}
    }
}
