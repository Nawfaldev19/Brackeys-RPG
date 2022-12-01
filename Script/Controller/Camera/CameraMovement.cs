using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Follow Attributes")]
    [SerializeField]
    float smoothness;
    [SerializeField]
    Vector3 offset;
    [System.Serializable]
    public struct ZoomAtt
    {
        public float zoomSpeed,ZoomLimitMax,ZoomLimitMin;
    }
    
    [SerializeField]
    ZoomAtt zoomTarget;
    [SerializeField]
    float yawSpeed;

    float currentYaw;
    float currentZoom;

    [Header("Following Target")]
    [SerializeField]
    GameObject target;
    
    [SerializeField]
    float targetHeight;
    // Start is called before the first frame update
    void Start()
    {
        currentZoom=1;
        transform.position=target.transform.position+offset;
    }
    void ScrollMovement()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel")*zoomTarget.zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom,zoomTarget.ZoomLimitMin,zoomTarget.ZoomLimitMax);
    }

    void YawControl()
    {
        currentYaw -= Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
        transform.RotateAround(target.transform.position,Vector3.up,currentYaw);
    }

    void SetPositionOfTarget()
    {
        Vector3 toGoPos=target.transform.position + offset*currentZoom;
        transform.position=Vector3.Lerp(transform.position,toGoPos,smoothness);
        transform.LookAt(target.transform.position+Vector3.up*targetHeight);
    }
  
 
    void LateUpdate()
    {
        ScrollMovement();
        SetPositionOfTarget();
        YawControl();
    }
}
