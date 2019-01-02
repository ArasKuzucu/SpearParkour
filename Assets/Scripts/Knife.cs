using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Knife : MonoBehaviour
{

    public Rigidbody2D knifeRigidBody;
    private Vector2 startSwipe;
    private Vector2 endSwipe;
    public CircleCollider2D spearhead1;
    public CircleCollider2D spearhead2;

    private float speed;

    [HideInInspector]
    public bool IsLanding;

    public float force = 300f;
    public float torque = 20f;
    
    private bool flag;

    void Start()
    {
        knifeRigidBody = GetComponent<Rigidbody2D>();
        IsLanding = true;
        flag = true;
    }

    void Update()
    {


        if (knifeRigidBody.angularVelocity >= 800)
        {
            knifeRigidBody.angularVelocity = 800;
        }

        speed = Vector3.Magnitude(knifeRigidBody.velocity);
        if (speed >= 80)
        {
            speed = 80;
        }
        //this value is zero so that the player does not shift twice in the air
        if (!IsLanding)
        {
            swipe = Vector2.zero;
        }

        foreach (Touch touch in Input.touches)
        {
            if (IsLanding)
            {
                
                if (touch.phase == TouchPhase.Began)
                {
                    startSwipe = Camera.main.ScreenToViewportPoint(touch.position);
                    flag = true;
                }
                else if (touch.phase == TouchPhase.Ended && flag)
                {

                    this.gameObject.transform.parent = null;
                    endSwipe = Camera.main.ScreenToViewportPoint(touch.position);
                    StartCoroutine(WaitToStick());
                    Swipe();
                }
            }
            else
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began)
                {
                    if (knifeRigidBody.angularVelocity >= 800)
                    {
                        knifeRigidBody.angularVelocity = 800;
                    }
                    else
                    {
                        knifeRigidBody.AddTorque(Time.deltaTime * 200, ForceMode2D.Impulse);
                    }

                    flag = false;
                }
            }

        }

    }
    private Vector2 swipe;
    private void Swipe()
    {
        IsLanding = false;
        knifeRigidBody.isKinematic = false;
        knifeRigidBody.WakeUp();
        //The distance and direction between the two vectors determine the direction and the slide force of the spear.
        swipe = endSwipe - startSwipe;

        knifeRigidBody.AddForce(swipe * force, ForceMode2D.Impulse);

        knifeRigidBody.AddTorque(torque * swipe.magnitude, ForceMode2D.Impulse);
    }
    //After swipe the spear should not to collide any object for moving softly therefore a short time sphere colliders disable
    IEnumerator WaitToStick()
    {
        spearhead1.enabled = false;
        spearhead2.enabled = false;
        yield return new WaitForSeconds(0.2f);
        spearhead1.enabled = true;
        spearhead2.enabled = true;

    }

}