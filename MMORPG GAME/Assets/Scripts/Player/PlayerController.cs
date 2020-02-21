using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controllerPy;
    private Vector3 movePlayer=Vector3.zero;
    public float speed=6f;
    public float gravity=20f;
    private Animator animPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        controllerPy=GetComponent<CharacterController>();
        animPlayer=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


      private void MovePlayer()
      {

          if(controllerPy.isGrounded)
        {
            movePlayer=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            movePlayer=transform.TransformDirection(movePlayer);
            movePlayer*=speed;






        }
        movePlayer.y-=gravity*Time.deltaTime;
        controllerPy.Move(movePlayer*Time.deltaTime);

          animPlayer.SetBool("isWalking",true);

          if(controllerPy.velocity==Vector3.zero)
          {
              animPlayer.SetBool("isWalking",false);
          }






      }







}
