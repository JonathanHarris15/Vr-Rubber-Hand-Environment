using System;
using UnityEngine;
using Leap;
using Unity.VisualScripting;

public class Offset_Manager : MonoBehaviour
{

    public Transform right_brush_offset;
    public Transform left_brush_offset;
    public Transform table_offset;

    public Transform left_brush_point;
    public Transform right_brush_point;
    public Transform table_point;

    public SkinnedMeshRenderer right_hand;

    public float manual_table_offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp("b"))
        {
           
            Vector3 rightDeltaWorld = table_point.position - right_brush_point.position;
            Vector3 leftDeltaWorld = table_point.position - left_brush_point.position;

            Vector3 rightDeltaLocal = right_brush_offset.parent.InverseTransformVector(rightDeltaWorld);
            Vector3 leftDeltaLocal = left_brush_offset.parent.InverseTransformVector(leftDeltaWorld);

            right_brush_offset.localPosition += rightDeltaLocal;
            left_brush_offset.localPosition += leftDeltaLocal;
        }

        


        if (Input.GetKeyUp("t"))
        {
            Vector3 palm_position = right_hand.bounds.center;

            float height_delta = table_point.position.y - palm_position.y;

            Vector3 tablePos = table_offset.position;
            tablePos.y -= height_delta - manual_table_offset;
            table_offset.position = tablePos;
        }


    }
}
