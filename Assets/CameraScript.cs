using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  //  public static CameraScript instance;

    public GameObject followTarget;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float cameraZ = 0;

    private Camera cam;

    public float shakeDuration = 0.5f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    void Awake()
    {
       // instance = this;
    }


    void Start()
    {
        cameraZ = transform.position.z;
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (followTarget)
        {
            Vector3 delta = followTarget.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
            Vector3 destination = transform.position + delta;
            destination.z = cameraZ;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

        if (shakeDuration > 0)
        {
            transform.localPosition = transform.position + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            //camTransform.localPosition = originalPos;
        }
    }
}
