using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class whitecollision : MonoBehaviourPunCallbacks
{
    public Animator animator;

    private Transform defaultCamTransform;
    private Vector3 resetPos;
    private Quaternion resetRot;
    private GameObject cam;
    private GameObject fighter;

    public int startingHP = 180;
    private int currentHP;
    public Slider WhiteHP;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        defaultCamTransform = cam.transform;
        resetPos = defaultCamTransform.position;
        resetRot = defaultCamTransform.rotation;
        fighter = GameObject.Find("Black Ninja");
        fighter.transform.position = new Vector3(0, 0, 0);
        currentHP = startingHP;
    }
    // Update is called once per frame

    void Update()
    {
        if (!photonView.IsMine)
            return;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OpponentBody"))
        {
            // HP 皑家 贸府
            TakeDamage(10); // HP 皑家
        }
    }

    private void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            OnCharacterDeath();
        }
        UpdateHPBar();
    }

    private void OnCharacterDeath()
    {
        gameObject.SetActive(false);

    }

    private void UpdateHPBar()
    {
        float hpPercentage = (float)currentHP / startingHP;
        WhiteHP.value = hpPercentage;
    }
}
