using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private PhotonView view;

    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        

        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Move();
        }
    }

    void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
        transform.position += (Vector3)moveAmount;

        if (moveAmount != Vector2.zero)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
    }

}
