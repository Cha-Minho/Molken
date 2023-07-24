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
        string animationTrigger = "";

        if (Input.GetKey(KeyCode.S))
            animationTrigger += "s";
            
        if (Input.GetKey(KeyCode.D))
            animationTrigger += "d";
        if (Input.GetKey(KeyCode.J))
            animationTrigger += "j";
        if (Input.GetKey(KeyCode.K))
            animationTrigger += "k";
        if (Input.GetKey(KeyCode.U))
            animationTrigger += "u";
        if (Input.GetKey(KeyCode.I))
            animationTrigger += "i";
        if (Input.GetKey(KeyCode.A))
            animationTrigger += "a";
        if (Input.GetKey(KeyCode.W))
            animationTrigger += "w";

        if (!string.IsNullOrEmpty(animationTrigger))
        {
            animator.SetTrigger(animationTrigger);
        }
        else
        {
            animator.ResetTrigger("s");
            animator.ResetTrigger("d");
            animator.ResetTrigger("j");
            animator.ResetTrigger("k");
            animator.ResetTrigger("u");
            animator.ResetTrigger("i");
            animator.ResetTrigger("a");
            animator.ResetTrigger("w");
            animator.ResetTrigger("sdj");
            animator.ResetTrigger("sdk");
            animator.ResetTrigger("duw");
            animator.ResetTrigger("sdi");
            animator.ResetTrigger("sdu");
            animator.ResetTrigger("wdi");
            animator.ResetTrigger("sk");
            animator.ResetTrigger("sj");

        }
    }

    void OnGUI()
    {
    }
}
