using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        offset=target.position-transform.position;          //distance to maintain from the target

        pivot.transform.position=target.transform.position;
        //pivot.transform.parent=target.transform;
        pivot.transform.parent=null;
        
        //Cursor.lockState=CursorLockMode.Locked;         //remove the cursor once the game starts
    }

    // Update is called once per frame
    void LateUpdate()       //Called after update is called
    {
        pivot.transform.position=target.transform.position;
        //Get the X position of the mouse and rotate the target
        /*float horizontal=Input.GetAxis("Mouse X")*rotateSpeed;
        pivot.Rotate(0,horizontal,0);

        //Get the Y position of the mouse and rotate the pivot
        float vertical=Input.GetAxis("Mouse Y")*rotateSpeed;

        if(invertY)
        {
            pivot.Rotate(vertical,0,0);
        }else
        {
            pivot.Rotate(-vertical,0,0);
        }

        //Limit up/down camera position
        if(pivot.rotation.eulerAngles.x >maxViewAngle  && pivot.rotation.eulerAngles.x<180f)
        {
            pivot.rotation=Quaternion.Euler(maxViewAngle,0,0);
        }

        if(pivot.rotation.eulerAngles.x >180f && pivot.rotation.eulerAngles.x<360f+minViewAngle)
        {
            pivot.rotation=Quaternion.Euler(360f+minViewAngle,0,0);
        }*/

        //Move the camera based on the current rotation of the target and the original offset
        float desiredYAngle=pivot.eulerAngles.y;
        float desiredXAngle=pivot.eulerAngles.x;

        Quaternion rotation=Quaternion.Euler(desiredXAngle,desiredYAngle,0);
        transform.position=target.position-(rotation*offset);

        //To keep the camera movement restricted only upto y position of the target
        if (transform.position.y<target.position.y)
        {
            transform.position=new Vector3(transform.position.x,target.position.y-0.5f,transform.position.z);
        }

        transform.position=target.position-offset;
        //transform.LookAt(target);
    }
}
