using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBAR : MonoBehaviour
{
    public GameObject HPBarObject; // Drag your HP Bar GameObject in the Unity Editor
    private Slider BlackHP;

    private float maxHP = 180;
    public float curHP = 180;

    // Start is called before the first frame update
    void Start()
    {
        BlackHP = HPBarObject.GetComponent<Slider>();
        HandleHP();
    }

    // Update is called once per frame
    void Update()
    {
        HandleHP();
    }

    public void HandleHP()
    {
        BlackHP.value = (float)curHP / (float)maxHP;
    }

}
