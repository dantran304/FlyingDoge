using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Animator anim;
    Rigidbody2D rigid;
    public float force;

    public AudioClip flapWing;
    public AudioClip hit;
    public AudioClip getScore;

    [HideInInspector] public bool isDead; 
    [HideInInspector] public int score;
    [HideInInspector] public int highScore;

    public static Player Instance;
    AudioSource audio;
	// Use this for initialization
	void Start () {
        Instance = this;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        isDead = false;
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("high score = " + highScore);
        if (isDead == false)
        {
            if (Input.GetButton("Fire1"))
            {
                if (GameManager.Instance.isGame == true)
                {
                    Fly();
                }
                return;
            }
        }
        return;
        }

    void Fly()
    {
        rigid.velocity = Vector3.up * force;
        audio.clip = flapWing;
        audio.Play();
    }

    void Death()
    {
        anim.SetTrigger("die");
        audio.clip = hit;
        audio.Play();
        isDead = true;
        GameManager.Instance.GameOver();
    }

    public void SetupPlayer()
    {
        score = 0;
        gameObject.transform.position = new Vector3(-1, 1, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        anim.Play("Doge_Fly");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Trap")
        {
            //die
            Debug.Log("Death");
            Death();
        }

        if(other.gameObject.tag == "Coin")
        {
            //get score

            GetScore();
            GameManager.Instance.CalculateHighScore();
        }
    }

    public void GetScore()
    {
        score++;
        audio.clip = getScore;
        audio.Play();
        HUDManager.Instance.DisplayScoreInGame();
    }

}
