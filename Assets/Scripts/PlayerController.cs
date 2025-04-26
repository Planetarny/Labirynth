using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    Vector3 velocity;
    CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),out hit,1f,groundMask)) 
        {

            string terrainType = hit.collider.gameObject.tag;
            switch (terrainType)
            {

                case "fast":
                    speed = 6f;
                    break;
                case "slow":
                    speed = 1.5f;
                    break;
                default:
                    speed = 3f;
                    break ;
            }

        }


        Vector3 move = transform.right*x+transform.forward*z;
        move += Vector3.down;
        characterController.Move(move*speed*Time.deltaTime);

    }
}
