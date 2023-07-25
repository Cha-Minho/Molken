using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteHpbar : MonoBehaviour
{
    public GameObject HPBarObject; // Drag your HP Bar GameObject in the Unity Editor
    private Slider WhiteHP;

    private float maxHP = 180;
    private float curHP = 180;

    // Start is called before the first frame update
    void Start()
    {
        WhiteHP = HPBarObject.GetComponent<Slider>();
        HandleHP();
    }

    // Update is called once per frame
    void Update()
    {
        HandleHP();
    }

    private void HandleHP()
    {
        WhiteHP.value = (float)curHP / (float)maxHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // If collided object has tag "OpponentAttack"
        if (other.gameObject.CompareTag("OpponentAttack"))
        {
            // Decrease health by 10
            curHP -= 10;
            HandleHP();
        }
    }
}
