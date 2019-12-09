using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private float fSpeed = 500;
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
        aAnim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        rRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    void Update()
    {

        float hMove = Input.GetAxis("Horizontal") * fSpeed;
        float vMove = Input.GetAxis("Vertical") * fSpeed;
        float speed = Mathf.Abs(hMove) > Mathf.Abs(vMove) ? hMove : vMove;
        aAnim.SetFloat("speed", Mathf.Abs(speed));
        
        
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