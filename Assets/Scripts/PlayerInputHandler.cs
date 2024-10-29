using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Creature playerDino; 



    // Update is called once per frame
    void FixedUpdate()
        
    {
        Vector3 movement = Vector3.zero; 
        if(Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1, 0, 0);
        }
        playerDino.Move(movement);
    }
}
