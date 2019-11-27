using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fSpeed = 100;
    private Animator anim;
    private Rigidbody rgd;
    private bool bRIght = true;
    [SerializeField]
    private GameObject cameraObj = null;
    private Quaternion rRotation;

    public float fDistance = 5;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rgd = GetComponent<Rigidbody>();
        rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update()
    {

        float hMove = Input.GetAxis("Horizontal") * fSpeed;
        float vMove = Input.GetAxis("Vertical") * fSpeed;
        float speed = Mathf.Abs(hMove) > Mathf.Abs(vMove) ? hMove : vMove;
        anim.SetFloat("speed", Mathf.Abs(speed));
        
        
        if (hMove > 0.01 && !bRIght)
        {
            bRIght = true;
            rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (hMove < -0.01 && bRIght)
        {
            bRIght = false;
            rRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        Quaternion q = Quaternion.Euler(new Vector3(0, cameraObj.GetComponent<CameraMove>().eulerAngles_x, 0));
        transform.rotation = rRotation * q;
        Vector3 mov = new Vector3(hMove, 1, vMove) * Time.deltaTime;
        rgd.velocity = q * mov;
   
    }
}