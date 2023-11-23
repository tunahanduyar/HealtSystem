using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class can: MonoBehaviour
{

    Animator anim;

    public Image canbari;
    public GameObject olm_pnl;
    public GameObject tekraroyna;   
    public GameObject dusman;
    public GameObject silah;
    public GameObject ates_btn;
    public GameObject sarjor_btn;
    public GameObject hedef;
    public GameObject kursun_txt;
    public GameObject joystick;
    public GameObject zipla;



    float max_can = 100.0f;
    float can = 100.0f;

  void start()
    {
        anim = GetComponent<Animator>();
    }

    public void can_degisimi(float deger)
    {
        can += deger;
        canbari.fillAmount = can / max_can;
     

        if (can <= 0.0f)
        {
            olum();
        }

    }
    void olum()
    {
        
        olm_pnl.SetActive(true);
        tekraroyna.SetActive(true);
        silah.SetActive(false);
        ates_btn.SetActive(false);
        sarjor_btn.SetActive(false);
        hedef.SetActive(false);
        kursun_txt.SetActive(false);
        joystick.SetActive(false);
        zipla.SetActive(false);
        
    }

 
}
