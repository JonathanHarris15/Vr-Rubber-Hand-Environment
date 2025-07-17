using System.Collections.Generic;
using UnityEngine;
using Leap;
using LeapInternal;


public class HandShift : PostProcessProvider
{
    [SerializeField]
    private Vector3 rightHandOffset = new Vector3(0f, 0f, 0f); // 10 cm to the right

    [SerializeField]
    private Vector3 shift_increment = new Vector3(0.05f, 0f, 0f);

    [SerializeField]
    private GameObject real_index_pos;

    [SerializeField]
    private GameObject index_collider;

    [SerializeField]
    private KeyCode shift_right;
    [SerializeField]
    private KeyCode shift_left;

    public override void ProcessFrame(ref Frame inputFrame)
    {
        foreach (var hand in inputFrame.Hands)
        {
            if (hand.IsRight)
            {
                real_index_pos.transform.position = hand.Index.TipPosition;
                // Apply the offset using SetTransform
                hand.SetTransform(hand.PalmPosition+rightHandOffset, hand.Rotation);

                index_collider.transform.position = hand.Index.TipPosition;
                
            }
        }
        if (Input.GetKeyUp(shift_right))
        {
            rightHandOffset += shift_increment;
        }
        if (Input.GetKeyUp(shift_left))
        {
            rightHandOffset -= shift_increment;
        }
    }
}
