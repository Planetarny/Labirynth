using Unity.VisualScripting;
using UnityEngine;

public class Unlock : MonoBehaviour
{

    public Door[] doors;
    public KeyColor myColor;
    public KeyType myType;
    bool canOpen;
    bool unlocked;
    Animator key;

    private void Start()
    {
        
        key = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {

            canOpen = true;
            Debug.Log("canOpen = "+ canOpen);

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            canOpen = false;
            Debug.Log("canOpen = " + canOpen);

        }

    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1)) && !unlocked && canOpen) 
        {

            key.SetBool("useKey", checkKey());
            
        }

    }
    public void UseKey() 
    {

        foreach (var door in doors) 
        {

            door.Open();

        }

    }
    public bool checkKey() 
    {
        
        if (GameManager.gameManager.redKeys[(int)myType] >0 && myColor == KeyColor.Red)
        {

            unlocked = true;
            GameManager.gameManager.redKeys[(int)myType]--;
            return true;

        }
        else if (GameManager.gameManager.greenKeys[(int)myType] > 0 && myColor == KeyColor.Green)
        {

            unlocked = true;
            GameManager.gameManager.greenKeys[(int)myType]--;
            return true;

        }
        else if (GameManager.gameManager.blueKeys[(int)myType] > 0 && myColor == KeyColor.Blue)
        {

            unlocked = true;
            GameManager.gameManager.blueKeys[(int)myType]--;
            return true;

        }
        else if (GameManager.gameManager.goldKeys[(int)myType] > 0 && myColor == KeyColor.Gold)
        {

            unlocked = true;
            GameManager.gameManager.goldKeys[(int)myType]--;
            return true;

        }
        return false;

    }
}
