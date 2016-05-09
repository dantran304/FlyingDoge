using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject player;
    public GameObject trap;
    public Transform trapSpawnPosition;
    Rigidbody2D rigid;
    [HideInInspector]
    public bool isGame;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rigid = player.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        isGame = false;

    }

    #region gameplay
    IEnumerator spawnTrap()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(trap, trapSpawnPosition.position, Quaternion.identity);
        Debug.Log("spawn trap");
    }

    void clearTrap()
    {
        GameObject trapTemp = GameObject.FindGameObjectWithTag("Trap");
        Destroy(trapTemp);
    }

    public void GameStart()
    {
        Player.Instance.isDead = false;
        rigid.gravityScale = 1;
        isGame = true;
        StartCoroutine(spawnTrap());
    }

    public void GameOver()
    {
        StopAllCoroutines();
        //tính điểm, lưu điểm
        saveHighScore();
        isGame = false;
        clearTrap();

        HUDManager.Instance.GameOver();
    }

    public void GameRestart()
    {
        Player.Instance.isDead = false;
        Player.Instance.SetupPlayer();
        isGame = true;
        StartCoroutine(spawnTrap());
        Player.Instance.highScore = 0;
    }
    #endregion

    #region player data

    bool isHighScoreSave;

    public void CalculateHighScore()
    {
        Player.Instance.highScore = Player.Instance.score;

        if (PlayerPrefs.GetInt("highScore") == null)
        {
            PlayerPrefs.SetInt("highScore", 0);
        }

        else if (PlayerPrefs.GetInt("highScore") < Player.Instance.highScore)
        {
            //isHighScoreSave = true;
            PlayerPrefs.SetInt("highScore", Player.Instance.highScore);
        }
        return;
    }

    public void saveHighScore()
    {
        //if (isHighScoreSave == false)
        //{
        //    PlayerPrefs.SetInt("highScore", Player.Instance.highScore);
        //}
        PlayerPrefs.Save();
    }
    #endregion
}
