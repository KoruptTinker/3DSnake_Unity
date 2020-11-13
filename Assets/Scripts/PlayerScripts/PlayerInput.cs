using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerController playerController;
    private int Horizontal=0;
    private int Vertical=0;
    
    public enum axes{
        Horizontal,
        Vertical
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerController=GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal=0;
        Vertical=0;
        GetKeyboardInput();
        SetMovement();
    }

    void GetKeyboardInput(){
        Horizontal= (int) Input.GetAxisRaw("Horizontal");
        Vertical= (int) Input.GetAxisRaw("Vertical");
        if(Horizontal !=0){

            Vertical=0;
        }

    }

    void SetMovement(){

        if(Vertical!=0){

            playerController.SetInputDirection((Vertical==1) ?
                                                PlayerDirection.UP : PlayerDirection.DOWN);
        }

        else if(Horizontal!=0){

            if(Horizontal==1){
                playerController.SetInputDirection((Horizontal==0) ?
                                                    PlayerDirection.RIGHT : PlayerDirection.LEFT);
            }
        }

    }
}
