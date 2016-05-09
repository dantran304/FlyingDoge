using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    public static Trap Instance;
	// Use this for initialization
	void Start () {
        Instance = this;
        gameObject.transform.position = new Vector3(4, Random.Range(-2, 3), 0);
    }

    public void RandomTrapPosition()
    {
        gameObject.transform.position = new Vector3(Random.Range(3,6) , Random.Range(-2, 3), 0);
    }

}
