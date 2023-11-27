using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        // Rotate the camera based on keyboard input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Rotate(-vertical, horizontal, 0);
        // limit the rotation of the camera to 30 degrees up and down
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.z = 0;
        if (rotation.x > 30 && rotation.x < 180)
        {
            rotation.x = 30;
        }
        else if (rotation.x < 330 && rotation.x > 180)
        {
            rotation.x = 330;
        }
        // limit the rotation of the camera to 30 degrees left and right
        if (rotation.y > 30 && rotation.y < 180)
        {
            rotation.y = 30;
        }
        else if (rotation.y < 330 && rotation.y > 180)
        {
            rotation.y = 330;
        }
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
