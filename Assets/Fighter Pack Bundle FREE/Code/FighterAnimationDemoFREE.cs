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
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk Forward", true);
        }
        else
        {
            animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Walk Backward", true);
        }
        else
        {
            animator.SetBool("Walk Backward", false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("PunchTrigger");
        }
    }

    void OnGUI()
    {
    }
}
