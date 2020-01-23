using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private float fSpeed = 200;
    private Animator aAnim;
    private Rigidbody rBody;
    private bool bRIght = true;
    [SerializeField]
    private GameObject cameraObj = null;
    private Quaternion rRotation;

    public float fDistance = 5;
    public ItemInventory inventory;

    private void Start()
    {
        aAnim = transform.GetChild(0).GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void FixedUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float speed = Mathf.Abs(hMove) > Mathf.Abs(vMove) ? hMove : vMove;
        aAnim.SetFloat("speed", Mathf.Abs(speed));
        Vector3 output = Vector3.zero;
        output.x = hMove * Mathf.Sqrt(1 - (vMove * vMove) / 2.0f);
        output.z = vMove * Mathf.Sqrt(1 - (hMove * hMove) / 2.0f);

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
        transform.rotation = Quaternion.Lerp(transform.rotation, rRotation*q, 1);
        Vector3 mov = new Vector3(output.x, 0, output.z) * fSpeed * Time.fixedDeltaTime;
        mov.y = rBody.velocity.y;
        rBody.velocity = q * mov;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IItem item = collision.collider.GetComponent<IItem>();

        if(item != null)
        {
            inventory.AddItem(item);
        }
    }
}