using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Creature playerDino; 

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero; 
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }
        playerDino.Move(movement);

         // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump dectected!");
            playerDino.Jump();
        }

    }

    public Vector3 GetMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");
        return new Vector3(moveX, 0, 0);
    }


}
