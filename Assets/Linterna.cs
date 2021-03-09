using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject lg;
    bool lz;

    public GameObject sof;
    public GameObject katan;
    AudioSource au;
    
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        lz = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (lg)
            {
                lz = !lz;
                lg.SetActive(!lg.activeSelf);
                au.Play();
            }
        }


        Ray myRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(myRay.origin, myRay.direction * 5, Color.red);
        RaycastHit hitInfo;

        if(Physics.Raycast(myRay,out hitInfo,5f))
        {
            if (hitInfo.collider.CompareTag("sofa"))
            {
                sof.SetActive(true);
                katan.SetActive(false);
                print("SOFA");
               
            }
            else if(hitInfo.collider.CompareTag("Katana"))
            {
                katan.SetActive(true);
                sof.SetActive(false);
                print("KATANA");
            }
            else
            {
                sof.SetActive(false);
                katan.SetActive(false);
            }

        }
        else
        {
            sof.SetActive(false);
            katan.SetActive(false);
        }




    }

   


}
