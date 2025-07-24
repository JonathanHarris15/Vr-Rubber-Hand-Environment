using UnityEngine;
using System.IO;

public class distance_to_button : MonoBehaviour
{
    [SerializeField]
    private GameObject target_button;
    [SerializeField]
    private GameObject index_tracker;

    private string filePath;

    private void Start()
    {
        filePath = Path.Combine("C:\\Users\\jonathan.h.1505\\Hand Tracking Demo", "distance_log.txt");

        // Check if the file exists; if not, create it
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Distance Log\n"); // Optional: add a header
        }
        else
        {
            File.AppendAllText(filePath, "-----------\n");//to signify a new run of the environment
        }

        print("Logging to: " + filePath);
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (target_button != null && index_tracker != null)
            {
                float distance = target_button.transform.position.x - index_tracker.transform.position.x;
                distance *= -100; //from meters to cm
                // Append the distance to the file
                File.AppendAllText(filePath, distance.ToString("F4") + "\n");
                print(distance);
            }
            else
            {
                Debug.LogWarning("Target button or index tracker is not assigned.");
            }
        }
    }
}
