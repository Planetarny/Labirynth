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

            key.SetBool("useKey", true);
            
        }
    }
}
