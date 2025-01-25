using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller;
    
    public float runSpeed = 40f;
    
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetAxisRaw("Horizontal") !=0)
        {
            anim.SetBool("Andar", true);
        }
        else
        {
            anim.SetBool("Andar", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Salto");
            anim.SetBool("Salto_aire", true);
            //Debug.Log(anim.GetBool("Salto_aire"));
            jump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            StartCoroutine(jumpCoroutine());
            //anim.SetBool("Salto_aire", false);

        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }

    IEnumerator jumpCoroutine()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Salto_aire", false);
    }
}
