using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd;
    private bool isPaused=false;
    public bool win;
    private void Start()
    {
        if (gameManager == null) { gameManager = this; }
        InvokeRepeating(nameof(Stoper),1f,1f);
    }
    private void Update()
    {
        PauseCheck();
    }

    void Stoper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");
        if (timeToEnd <= 0) 
        {

            Debug.Log("Time 's up!");
            EndGame();
        }


    }
    public void PauseGame()
    {

        Debug.Log("Game Paused");
        isPaused = true;
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {

        Debug.Log("Game Resumed");
        isPaused = false;
        Time.timeScale = 1f;

    }
    public void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            if (isPaused) ResumeGame();
            else PauseGame();

        }
        

    }
    void PauseCheckbtn()
    {

        if(isPaused) ResumeGame();
        else PauseGame();

    }
    public void EndGame()
    {

        CancelInvoke(nameof(Stoper));
        PauseGame();
        if (win)
        {

            Debug.Log("You won! Restart?");

        }
        else { Debug.Log("You lost! Restart?"); }


    }



}
