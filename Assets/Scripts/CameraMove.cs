using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform target = null;
    float distance = 3;
    public float eulerAngles_x;
    float eulerAngles_y = 30;
    float distanceMax = 5;
    float distanceMin = 2;

    float xSpeed = 70.0f;

    Vector3 Teme;
    float XX;

    Vector3 screenPoint, offset, OldPoint;

    float MouseScrollWheelSensitivity = 1.0f;

    LayerMask CollisionLayerMask;

    void Start()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        this.eulerAngles_x = eulerAngles.y;
    }
    void Update()
    {
        if (Time.timeScale < 0.5)   
            return;
        if(Input.GetMouseButtonDown(1))
        {
            XX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(1))
        {
            this.eulerAngles_x += (Input.mousePosition.x - XX) * Time.deltaTime * this.xSpeed;
            //if(this.eulerAngles_x > 30)
            //{
            //    this.eulerAngles_x = 30;
            //}
            //else if(this.eulerAngles_x < -30)
            //{
            //    this.eulerAngles_x = -30;
            //}
            XX = Input.mousePosition.x;
        }

        this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);

        Quaternion quaternion = Quaternion.Euler(eulerAngles_y, this.eulerAngles_x, (float)0);

        Vector3 vector = ((Vector3)(quaternion * new Vector3(0, 0, -this.distance))) + this.target.position;

        this.transform.rotation = quaternion;
        this.transform.position = vector;
    }
}








