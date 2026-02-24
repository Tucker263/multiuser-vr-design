using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_Switching : MonoBehaviour
{
    public GameObject stickMovementScript;
    public GameObject teleportInteractorLeft;
    public GameObject teleportInteractorRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switching()
    {
        stickMovementScript.SetActive(true);
        teleportInteractorLeft.SetActive(false);
        teleportInteractorRight.SetActive(false);
    }
}
