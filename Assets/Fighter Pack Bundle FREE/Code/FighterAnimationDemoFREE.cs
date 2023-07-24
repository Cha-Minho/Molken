using UnityEngine;
using System.Collections;

public class FighterAnimationDemoFREE : MonoBehaviour
{

    public Animator animator;
    
    private Transform defaultCamTransform;
    private Vector3 resetPos;
    private Quaternion resetRot;
    private GameObject cam;
    private GameObject fighter;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        defaultCamTransform = cam.transform;
        resetPos = defaultCamTransform.position;
        resetRot = defaultCamTransform.rotation;
        fighter = GameObject.Find("Black Ninja");
        fighter.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        bool wKeyPressed = Input.GetKey(KeyCode.W);
        bool aKeyPressed = Input.GetKey(KeyCode.A);
        bool sKeyPressed = Input.GetKey(KeyCode.S);
        bool dKeyPressed = Input.GetKey(KeyCode.D);
        bool uKeyPressed = Input.GetKey(KeyCode.U);
        bool iKeyPressed = Input.GetKey(KeyCode.I);
        bool kKeyPressed = Input.GetKey(KeyCode.K);
        bool jKeyPressed = Input.GetKey(KeyCode.J);

        if (sKeyPressed && dKeyPressed && jKeyPressed)
        {
            animator.SetTrigger("sdj");
        }
        else if (sKeyPressed && dKeyPressed && kKeyPressed)
        {
            animator.SetTrigger("sdk");
        }
        else if (wKeyPressed && dKeyPressed && uKeyPressed)
        {
            animator.SetTrigger("wdu");
        }
        else if (sKeyPressed && dKeyPressed && iKeyPressed)
        {
            animator.SetTrigger("sdi");
        }
        else if (sKeyPressed && dKeyPressed && uKeyPressed)
        {
            animator.SetTrigger("sdu");
        }
        else if (wKeyPressed && dKeyPressed && iKeyPressed)
        {
            animator.SetTrigger("wdi");
        }
        else if (sKeyPressed && kKeyPressed)
        {
            animator.SetTrigger("sk");
        }
        else if (sKeyPressed && jKeyPressed)
        {
            animator.SetTrigger("sj");
        }
        else if (aKeyPressed)
        {
            animator.SetTrigger("a");
        }
        else if (kKeyPressed)
        {
            animator.SetTrigger("k");
        }
        else if (jKeyPressed)
        {
            animator.SetTrigger("j");
        }
        else if (uKeyPressed)
        {
            animator.SetTrigger("u");
        }
        else if (dKeyPressed)
        {
            animator.SetTrigger("d");
        }
        else if (iKeyPressed)
        {
            animator.SetTrigger("i");
        }
        else
        {
            animator.ResetTrigger("sdj");
            animator.ResetTrigger("sdk");
            animator.ResetTrigger("wdu");
            animator.ResetTrigger("sdi");
            animator.ResetTrigger("sdu");
            animator.ResetTrigger("wdi");
            animator.ResetTrigger("sk");
            animator.ResetTrigger("sj");
            animator.ResetTrigger("a");
            animator.ResetTrigger("k");
            animator.ResetTrigger("j");
            animator.ResetTrigger("u");
            animator.ResetTrigger("d");
            animator.ResetTrigger("i");
        }
        //if (Input.GetKeyDown(KeyCode.D))
        //{

        //    animator.SetBool("move_forward_B", true);
        //}
        //else
        //{
        //    animator.SetBool("Walk Forward", false);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetBool("Walk Backward", true);
        //}
        //else
        //{
        //    animator.SetBool("Walk Backward", false);
        //}

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    animator.SetTrigger("PunchTrigger");
        //}
    }

    void OnGUI()
    {
    }
}
