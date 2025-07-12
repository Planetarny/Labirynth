using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource source;
    double pauseClipTime = 1;
    public AudioClip[] clips;
    int currentClip = 0;
    private void Start()
    {
        
        source = GetComponent<AudioSource>();
        source.clip = clips[currentClip];
        source.Play();

    }
    private void Update()
    {
        if (source.time >= clips[currentClip].length)
        {

            currentClip++;
            if (currentClip > clips.Length - 1) 
            {
            
                currentClip = 0;
            
            }
        
        }
    }
}
