using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    void Start()
    {
        gameObject.transform.position = new Vector3(0, Random.Range(-2, 4), 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            // score
            Debug.Log("Coin");
            Player.Instance.GetScore();
        }
    }
    }
