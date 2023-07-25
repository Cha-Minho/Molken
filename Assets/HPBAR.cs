using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour
{
    [SerializeField]
    private Slider BlackHP;

    [SerializeField]
    private Slider WhiteHP;

    private float maxHP = 180;
    private float curHP = 180;

    // Start is called before the first frame update
    void Start()
    {
        BlackHP.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHP();
    }

    private void HandleHP()
    {
        BlackHP.value = (float)curHP / (float)maxHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collided object has tag "OpponentAttack"
        if (other.gameObject.CompareTag("OpponentAttack"))
        {
            // Decrease health by 10
            curHP -= 10;
            HandleHP();
        }
    }

}
