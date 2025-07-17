using UnityEngine;

public class toggle_hand_visibility : MonoBehaviour
{
    [SerializeField]
    private GameObject[] right_objects;
    [SerializeField]
    private GameObject[] left_objects;

    [SerializeField]
    private KeyCode right_b;
    [SerializeField]
    private KeyCode left_b;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(right_b))
        {
            for(int i = 0; i < right_objects.Length; i++)
            {
                right_objects[i].SetActive(!right_objects[i].activeInHierarchy);
            }
        }
        if (Input.GetKeyUp(left_b))
        {
            for (int i = 0; i < left_objects.Length; i++)
            {
                left_objects[i].SetActive(!left_objects[i].activeInHierarchy);
            }
        }

    }
}
