using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class BlackNinja : MonoBehaviourPunCallbacks
{
    public Animator animator;
    public PhotonView photonView;
    private Vector3 resetPos;
    private Quaternion resetRot;
    private GameObject fighter;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            // If this object is not controlled by the local player, ignore inputs
            enabled = false;
        }

        fighter = GameObject.Find("White Ninja(Clone)");
        fighter.transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // Ignore inputs if this object is not controlled by the local player
            return;
        }

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
            photonView.RPC("SetAnimationTrigger", RpcTarget.All, animationTrigger);
        }
        else
        {
            photonView.RPC("ResetAllTriggers", RpcTarget.All);
        }
    }

    [PunRPC]
    void SetAnimationTrigger(string animationTrigger)
    {
        animator.SetTrigger(animationTrigger);
        // Note: reset all triggers other than the one just set
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
            {
                if (parameter.name != animationTrigger)
                {
                    animator.ResetTrigger(parameter.name);
                }
            }
        }
    }
    [PunRPC]
    void ResetAllTriggers()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(parameter.name);
            }
        }
    }

}
