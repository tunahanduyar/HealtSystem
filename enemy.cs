using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class enemy : MonoBehaviour
{

   
    public ParticleSystem kan_efekti;
    public ParticleSystem yaralanma;




    NavMeshAgent takip;
    Transform hedef;
    Animator anim;

    float can = 100.0f;

    float mesafe;

    bool saldir = false;
    

    Coroutine can_azaltma_fonksiyon;

    yonetici yonet;


    void Start()
    {


      
        

        takip = GetComponent<NavMeshAgent>();

        hedef = GameObject.FindWithTag("Player").transform;

        anim = GetComponent<Animator>();

        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();

        kan_efekti.Stop();

        yaralanma.Stop();

        
    }


    void Update()
    {
        if (hedef != null)
        {
            if (can > 0.0f)
            {
                mesafe = Vector3.Distance(transform.position, hedef.position);

                if (mesafe <= 3.0f)
                {
                    anim.SetTrigger("saldir");

                    if (saldir == false)
                    {
                        saldir = true;
                        can_azaltma_fonksiyon = StartCoroutine(player_can_azalt(-5.0f));
                    

                    }

                }
                else if (mesafe > 3.0f)

                {
                    anim.SetBool("kos", true);
                    saldir = false;
               
                }

                takip.SetDestination(hedef.position);

            }
            else if (can <= 0.0f)
            {
                ol();
                kan_efekti.Stop();
                
            }
        }
    }


    IEnumerator player_can_azalt(float deger)
    {
        if (saldir == true)
        {
            hedef.GetComponent<healt>().can_degisimi(deger);
            kan_efekti.Play();
        




            yield return new WaitForSeconds(1.0f);
            yield return player_can_azalt(deger);
            
           
        }

        else

        {
            StopCoroutine(can_azaltma_fonksiyon);
            kan_efekti.Stop();
        }
           

    }

    void ol()
    {
        
            anim.SetTrigger("ol");

       

        Destroy(takip);
        Destroy(this);
        Destroy(gameObject, 10.0f);

    }

   

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kursun")
        {
            other.gameObject.SetActive(false);
            
            can_azalt(-20);
          
        }
    }



    void can_azalt(float deger)
    {
    
        {
           
            can += deger;
            yaralanma.Play();
            anim.SetTrigger("tepki");
            


        }


        if (can <= 0.0f)
        {
            ol();
            kan_efekti.Stop();
            
        }
    }


}
