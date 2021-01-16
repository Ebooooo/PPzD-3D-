using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODFootsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputsound;
    bool playerismoving;
    public float walkingspeed;

    void Update()
    {
        if (Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis ("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= 0.01f || Input.GetAxis("Horizontal") <= 0.01f)
        {
            Debug.Log ("Rusza sie");
            playerismoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            Debug.Log ("NIe Rusza sie");
            playerismoving = false;
        }
    }

    void CallFootspets ()
    {
        if (playerismoving == true)
        {
            
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }

    void Start ()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void OnDisable()
    {
        playerismoving = false;
    }
}