using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotationSpeed;
    public AudioClip picked;

    public virtual void Picked()
    {
        Debug.Log("Pickup collected");
        Destroy(this.gameObject);
        GameManager.gameManager.PlayMusic(picked);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0f, 0f));
    }

    private void Update()
    {
        Rotate();
    }
}
