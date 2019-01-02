using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{

    public int point;
    private GameManager gm;
    public GameObject destroyvfx;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2" || col.gameObject.tag == "SpearBody")
        {
           
            gm.SetPoint(point);
            StartCoroutine(WaitParticleVfx());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2" || col.gameObject.tag == "SpearBody")
        {
            
            gm.SetPoint(point);
            StartCoroutine(WaitParticleVfx());
        }
    }
    IEnumerator WaitParticleVfx()
    {
        Instantiate(destroyvfx,transform.position,transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
  
}