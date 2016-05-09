using UnityEngine;
using System.Collections;

public class BGMove : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.Instance.isDead == false)
        {
            if (Time.timeScale == 1)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            return;
        }
        }
}
