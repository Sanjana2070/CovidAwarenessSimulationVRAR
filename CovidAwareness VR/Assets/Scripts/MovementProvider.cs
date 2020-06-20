using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
    public List<XRController> controllers = null;

    private CharacterController characterController = null;
    private GameObject head = null;



    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        PositionController();
    }

    // Update is called once per frame
    void Update()
    {
        PositionController();        
    }

    private void PositionController()
    {
        //Get the head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1.5f, 2f);
        characterController.height = headHeight;

        //Cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        //Let's move the capsule in local space as well
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;


        //Apply
        characterController.center = newCenter;
    }

    private void CheckForInput()
    {

    }

    private void CheckForMovement(InputDevice device)
    {

    }

    private void StartMove(Vector2 position)
    {
        //Apply the touch position to the head's forward Vector

        //Rotate the input direction by the horizontal head rotation

        //Apply speed and move

    }

    private void ApplyGravity()
    {

    }
}
