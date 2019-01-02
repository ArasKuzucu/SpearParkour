using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronHitSurface : HitSurface
{


    public override void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2")
        {

            // Ilerde Kullanılabilir!!!---->a.AddForce(b * Time.deltaTime * 100,ForceMode2D.Impulse); ------- a.AddForce(-b * Time.deltaTime * 7100,ForceMode2D.Force);
            return;
            //Debug.Log(b);

        }
    }

}
