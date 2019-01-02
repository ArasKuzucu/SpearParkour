using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSurface : MonoBehaviour
{
    protected GameObject player;
    protected Knife knife;
    protected void Start()
    {
        knife = FindObjectOfType<Knife>();
        player = GameObject.Find("Player");
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2")
        {

            knife.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            knife.knifeRigidBody.isKinematic = true;
            knife.knifeRigidBody.WakeUp();

        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2")
        {
            player.transform.parent = transform.parent;
            knife.IsLanding = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2")
        {
            knife.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            knife.knifeRigidBody.isKinematic = false;
            knife.knifeRigidBody.WakeUp();

            player.transform.parent = null;
            knife.IsLanding = false;
        }

    }
    
    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "SpearBody")
        {
            knife.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            knife.knifeRigidBody.isKinematic = false;
            knife.knifeRigidBody.WakeUp();

            player.transform.parent = null;
            knife.IsLanding = true;
        }

    }


}
