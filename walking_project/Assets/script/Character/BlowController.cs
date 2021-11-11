using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowController : MonoBehaviour
{
    [SerializeField] private Transform camera;

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = camera.position;

        this.transform.LookAt(cameraPosition);
        var angle = this.transform.rotation.eulerAngles.x;
        angle = angle > 180f ? angle - 360f : angle;
        transform.localRotation
            = Quaternion.Euler(90f + Mathf.Clamp(angle, -30f, 30f), 0f, 0f);

        this.transform.LookAt(cameraPosition);
    }
}
