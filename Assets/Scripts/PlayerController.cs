using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody RB;

    public CharacterController controller;

    public float jumpForce;

    private Vector3 moveDirection;

    public float gravityScale;

    public Animator anim;

    public Transform pivot;

    public float rotateSpeed;

    public GameObject playerModel;

    public float knockBackForce;

    public float knockBackTime;

    private float knockBackCounter;

    public AudioSource Sound;

    public AudioClip collideSound;

    public AudioClip jumpSound;

    public AudioClip hurtSound;

     private float yvalue;
     bool jumpbtn=false;
    // Start is called before the first frame update
    void Start()
    {
        Sound=GetComponent<AudioSource>();
        
        controller=GetComponent<CharacterController>();

        //RB=GetComponent<Rigidbody>();
    }
     public void jumpbutton()
    {
        jumpbtn=true;
    }

    // Update is called once per frame
    void Update()
    {
        //RB.velocity=new Vector3(Input.GetAxis("Horizontal")*moveSpeed,RB.velocity.y,Input.GetAxis("Vertical")*moveSpeed);
        /* if(Input.GetButtonDown("Jump"))
        {
            RB.velocity=new Vector3(RB.velocity.x,jumpForce,RB.velocity.z);
        }*/

        //moveDirection=new Vector3(Input.GetAxis("Horizontal")*moveSpeed,moveDirection.y,Input.GetAxis("Vertical")*moveSpeed);
        if(knockBackCounter<=0)
        {
            float yStore=moveDirection.y;
            yvalue=Input.GetAxis("Horizontal");
            if(Input.GetMouseButton(0))
            {
                if(Input.mousePosition.x>Screen.width/2)
                    yvalue=0.3f;
                else
                    yvalue=-0.3f;
            }
            moveDirection=(transform.forward*1)+(transform.right*yvalue);      //move the target forward or right along the direction of camera
            moveDirection=moveDirection.normalized*moveSpeed;
            moveDirection.y=yStore;

            if(controller.isGrounded) 
            {
                moveDirection.y=0f;
                if(Input.GetButtonDown("Jump") || jumpbtn)
                {
                    moveDirection.y=jumpForce;
                    Sound.PlayOneShot(jumpSound);
                    jumpbtn=false;

                }
            }
        }else
        {
            knockBackCounter-=Time.deltaTime;
        }
        moveDirection.y=moveDirection.y+(Physics.gravity.y*gravityScale*Time.deltaTime);
        controller.Move(moveDirection*Time.deltaTime);

        /*if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0 )
        {
            transform.rotation=Quaternion.Euler(0f,pivot.rotation.eulerAngles.y,0f);
            Quaternion newRotation=Quaternion.LookRotation(new Vector3(moveDirection.x,0f,moveDirection.z));
            playerModel.transform.rotation=Quaternion.Slerp(playerModel.transform.rotation,newRotation,rotateSpeed*Time.deltaTime);
        }*/

        anim.SetBool("isGrounded",controller.isGrounded);
        anim.SetFloat("speed",(Mathf.Abs(yvalue)));
    }
        public void knockBack(Vector3 direction)
        {
            knockBackCounter=knockBackTime;
            moveDirection=direction*knockBackForce;
            moveDirection.y=knockBackForce;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag=="Chocolate" || other.tag=="Candy1" || other.tag=="candy6")
            {
                Sound.PlayOneShot(collideSound);
            }
            if(other.tag=="Cactus" || other.tag=="spider" || other.tag=="fire")
            {
                Sound.PlayOneShot(hurtSound);
            }
            
        }
}
