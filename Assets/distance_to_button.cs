using UnityEngine;
using System.Collections;
public class distance_to_button : MonoBehaviour
{
    [SerializeField]
    private GameObject target_button;
    [SerializeField]
    private GameObject index_tracker;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float distance = target_button.transform.position.x - index_tracker.transform.position.x;
            print(distance);
        }
    }
}
