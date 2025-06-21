using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd;
    public int points;
    public float speedModifier;

    public int[] redKeys={0,0,0,0 };
    public int[] greenKeys= { 0, 0, 0, 0 };
    public int[] blueKeys= { 0, 0, 0, 0 };
    public int[] goldKeys= { 0, 0, 0, 0 };

    bool gamePaused = false;
    bool win = false;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        InvokeRepeating(nameof(Stopper), 1f, 1f);
        points = PlayerPrefs.GetInt("CoinNum");
    }

    private void ResetSpeed()
    {
        speedModifier = 1f;
    }

    public void SetSpeedModifier(float value, int time)
    {
        speedModifier = value;
        Invoke(nameof(ResetSpeed), time);
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freeze, 1f);
    }

    public void AddPoints(int point)
    {
        points += point;
        PlayerPrefs.SetInt("CoinNum", points);
    }    

    public void AddKey(KeyColor color, KeyType type)
    {
        if (color==KeyColor.Red) redKeys[(int)type]++;
        else if (color==KeyColor.Green) greenKeys[(int)type]++;
        else if (color==KeyColor.Gold) goldKeys[(int)type]++;
        else blueKeys[(int)type]++;
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");
        if (timeToEnd<=0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        //Time.timeScale=0f;
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        }
        else 
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    private void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseCheck();
        ReloadScene();
    }

    public void PauseCheck()
    {
        if (gamePaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
