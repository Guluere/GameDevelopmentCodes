using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraControl : Intelligence
{
    [SerializeField] Transform Parent;

    Sentient.OffsetRotationByVector OffsetByCursor;

    [SerializeField]
    InputActionReference ActionReferenceMousePos;

    public override void ChangeStateTo(int StateChoice)
    {
        switch(StateChoice) //0 is free move
        {
            case 0:
                Brain.AddToAllRotationalControl( new Sentient.MaintainRotationOppositeOf(Parent));
                OffsetByCursor = new Sentient.OffsetRotationByVector();
                Brain.AddToAllRotationalControl(OffsetByCursor);
                break;
            default: 
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeStateTo(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = ActionReferenceMousePos.action.ReadValue<Vector2>();
        OffsetByCursor.OffsetVector = new Vector2(Mathf.Clamp(MousePos.y, -75, 75), MousePos.x);
        transform.localEulerAngles = Brain.GetAllRotationalControlVector3();
    }
}
