using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    public AudioClip bgSound;
    public AudioClip hit;
    public AudioClip getScore;
    
    // Use this for initialization
	void Start () {
        Instance = this;
	}
	



}
