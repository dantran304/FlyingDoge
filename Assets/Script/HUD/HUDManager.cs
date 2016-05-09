using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    [Header("Các panel")]
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject gamePausePanel;
    public GameObject gameOverPanel;

    [Header("Tính điểm số người chơi")]
    public Text scoreInGame;                //score in game while playing

    public Text scoreResult;                //result board 
    public Text highScore;                  //result board

    [Header("Hình ảnh medal")]
    public Image medal;                     //reward

    public Sprite silverMedal;
    public Sprite goldMedal;
    public Sprite loseMedal0;
    public Sprite loseMedal1;
    public Sprite loseMedal2;

    public static HUDManager Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
	}

    #region Bật tắt các panel
    public void PanelStart_Open()
    {
        startPanel.SetActive(true);
    }

    public void PanelStart_Close()
    {
        startPanel.SetActive(false);
    }

    public void PanelGame_Open()
    {
        gamePanel.SetActive(true);
    }

    public void PanelGame_Close()
    {
        gamePanel.SetActive(false);
    }

    public void PanelGamePause_Open()
    {
        gamePausePanel.SetActive(true);
    }

    public void PanelGamePause_Close()
    {
        gamePausePanel.SetActive(false);
    }

    public void PanelGameOver_Open()
    {
        gameOverPanel.SetActive(true);
    }

    public void PanelGameOver_Close()
    {
        gameOverPanel.SetActive(false);
    }
    #endregion

    #region Hàm xử lí trong panel start

    public void GameStart()
    {
        GameManager.Instance.GameStart();
        PanelStart_Close();
        PanelGame_Open();
    }
    #endregion

    #region Hàm xử lí trong panel game
    public void DisplayScoreInGame()
    {
        scoreInGame.text = "Score  " + Player.Instance.score;
    }

    public void ResetScoreInGame()
    {
        scoreInGame.text = "Score  ";
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        PanelGamePause_Open();
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        PanelGamePause_Close();
    }

    #endregion

    #region Hàm xử lí trong panel game over
    //hiển thị điểm số hiện tại và high score

    public void DisplayScoreResult()
    {
        scoreResult.text = "" + Player.Instance.score;
    }

    public void ResetScoreResult()
    {
        scoreResult.text = "";
    }

    public void DisplayHighScore()
    {
        highScore.text = "" + PlayerPrefs.GetInt("highScore");
    }
    public void ResetHighScore()
    {
        highScore.text = "";
    }

    public void DisplayMedal()
    {
        if(Player.Instance.score < 5)
        {
            medal.sprite = loseMedal0;
        }
        else if(Player.Instance.score >= 5 && Player.Instance.score < 10)
        {
            medal.sprite = loseMedal1;
        }
        else if (Player.Instance.score >= 10 && Player.Instance.score < 20)
        {
            medal.sprite = loseMedal2;
        }
        else if (Player.Instance.score >= 20 && Player.Instance.score < 50)
        {
            medal.sprite = silverMedal;
        }
        else if (Player.Instance.score >= 50)
        {
            medal.sprite = goldMedal;
        }
       
    }

    //
    public void GameOver()
    {
        PanelGameOver_Open();

        DisplayScoreResult();
        DisplayHighScore();
        DisplayMedal();
    }

    public void GameRestart()
    {
        GameManager.Instance.GameRestart();
        PanelGameOver_Close();

        ResetScoreInGame();
        ResetScoreResult();
        
       
        
    }
    #endregion




    

   
}
