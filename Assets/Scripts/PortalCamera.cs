using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void FixedUpdate()
    {
        PortalCameraController();
    }

    void PortalCameraController()
    {

        Vector3 playerOffset = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffset;
        float angularDiffrence= Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationalDiffrence = Quaternion.AngleAxis(angularDiffrence, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDiffrence * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection,Vector3.up);

    }
}
