using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(myPlayerMotor))]
public class MyPlayerController : MonoBehaviour
{
    Camera cam;
    [Header("layer")]
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask interactableLayer;

    myPlayerMotor motor;

    [Header("test")]
    [SerializeField]
    public myInteractable focus;
    public static MyPlayerController instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance=this;
        cam=Camera.main;
    }

    void Start()
    {
        motor = GetComponent<myPlayerMotor>();
    }
    // Update is called once per frame

    void SetFocus(myInteractable newFocus)//everything depends on player controller focus// be careful
    {
        if(newFocus!=null)
        {
            {//brackeys INTERACTION 11:09
            // if(newFocus != focus)
            // {
            //     if(focus !=null)
            //         focus.OnDeFocused();
            //     focus=newFocus;
            // }    
            }
            if(focus !=null)
                focus.OnDeFocused();
            focus=newFocus;
            newFocus.OnFocused(transform);
            motor.StartPursuit();
        }
    }
    void EndFocus()
    {
        if(focus !=null)
            focus.OnDeFocused();
        focus=null;
        motor.StopPursuitObj();
    }

    void MouseEvents()
    {
        if(Input.GetMouseButtonDown(0))//       LEFT CLICK
        {
            if(EventSystem.current.IsPointerOverGameObject())// to avoid movement when click occurs on UI
                return;
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100,groundLayer))
            {
                EndFocus();
                motor.MovePlayerPoint(hit.point);   
            }
        }
        else if(Input.GetMouseButtonDown(1))//   RIGHT CLICK
        {
            Ray ray=cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100,interactableLayer))
            {
                SetFocus(hit.collider.GetComponent<myInteractable>());
                //see if the object is interactable and if it really is
                //make the object its focus
            
            }
        }
    }

    void Update()
    {

        MouseEvents();
    }
}
