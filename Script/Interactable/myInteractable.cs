using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myInteractable : MonoBehaviour
{
    bool isFocused=false;
    Transform player=null;
    [SerializeField]
    public float radius=3f;
    public Transform interactionTransform;
    bool hasInteract=false;
    void Update()
    {
        if(isFocused && !hasInteract)
        {
            // Debug.Log("distance"+ player.GetComponent<myPlayerMotor>().GetDistanceOfNavAgent());
            // player.GetComponent<myPlayerMotor>().GetDistanceOfNavAgent()
            //brackeys better if used..Used .....
            float distance=Vector3.Distance(player.position,interactionTransform.position);
            // Debug.Log("dis"+distance);
            if (distance<=radius)
            {
                hasInteract=true;
                Interact();
            }
        }    
    }

    public virtual void Interact()
    {
        //this is a funtion meant to be interactable
        // Debug.Log("interact with "+ interactionTransform.name);
    }

    private void OnDrawGizmosSelected() {
        if(interactionTransform==null)
            interactionTransform=transform;
        Gizmos.color=Color.cyan;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);        
    }

    public void OnFocused(Transform playerTransform)
    {
        player = playerTransform;
        isFocused=true;
    }

    public void OnDeFocused()
    {
        hasInteract=false;
        isFocused=false;
        player=null;
    }

}
