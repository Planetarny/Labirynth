using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform player;
    public Transform receiver;
    
    private bool playerIsOverlapping = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            playerIsOverlapping = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            playerIsOverlapping = false;

        }

    }
    void Tp()
    {

        if (playerIsOverlapping)
        {

            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if (dotProduct < 0) 
            { 

                float rotationDiff = Quaternion.Angle(transform.rotation,receiver.rotation);
                rotationDiff += 180;
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;
                playerIsOverlapping = false ;
            }
            //player.position = receiver.position;

        }

    }

    private void FixedUpdate()
    {
        Tp();
    }

}
