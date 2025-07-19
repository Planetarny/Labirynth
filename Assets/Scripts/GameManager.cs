using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public Text TimeTxt;
    public Text BlueKeys;
    public Text RedKeys;
    public Text GoldKeys;
    public Text GreenKeys;
    public Text Coins;
    public Text InfoTxt;
    public Text PauseTxt;
    public Text PauseInfo;
    public Image Freeze;
    public GameObject Pickup;
    public GameObject Pause;
    public GameObject Info;

    public int timeToEnd;
    public int points;
    public float speedModifier;

    public int[] redKeys={0,0,0,0 };
    public int[] greenKeys= { 0, 0, 0, 0 };
    public int[] blueKeys= { 0, 0, 0, 0 };
    public int[] goldKeys= { 0, 0, 0, 0 };

    bool gamePaused = false;
    bool win = false;

    AudioSource sound;

    public AudioClip resume;
    public AudioClip pause;
    public AudioClip winClip;
    public AudioClip lose;
    public AudioClip ambient;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        InvokeRepeating(nameof(Stopper), 1f, 1f);
        points = PlayerPrefs.GetInt("CoinNum");
        sound = GetComponent<AudioSource>();

        Info.SetActive(false);
        Pause.SetActive(false);
        Pickup.SetActive(true);
        TimeTxt.text = timeToEnd.ToString();
        InfoTxt.text = null;
        BlueKeys.text = "0";
        RedKeys.text = "0";
        GreenKeys.text = "0";
        GoldKeys.text = "0";
        Coins.text = points.ToString();

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
        Freeze.enabled = true;
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
        Freeze.enabled = false;
        Debug.Log($"Time: {timeToEnd} s");
        if (timeToEnd<=0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        Time.timeScale=0f;
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
            PlayMusic(winClip);
            Pause.SetActive(true);
            PauseTxt.text = "You Won!";
            PauseInfo.text = "Press Space to play again";
        }
        else 
        {
            Debug.Log("You Lose!!! Reload?");
            PlayMusic(lose);
            Pause.SetActive(true);
            PauseTxt.text = "You Lost!";
            PauseInfo.text = "Press Space to play again";
        }
    }

    private void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        TimeTxt.text = timeToEnd.ToString();
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
        PlayMusic(pause);
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
        Pause.SetActive (true);
        PauseTxt.text = "Game Paused";
        PauseInfo.text = "Press ESC to continue";

    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        PlayMusic(resume);
        gamePaused = false;
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    public void PlayMusic(AudioClip clip)
    {

        sound.clip = clip;
        sound.Play();

    }
}
