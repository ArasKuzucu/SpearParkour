using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelUp : HitSurface
{
    public int nextlevel;
    private GameManager gm;

    new void Start()
    {
        base.Start();
        knife = FindObjectOfType<Knife>();
        gm = FindObjectOfType<GameManager>();

    }

    public override void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2")
        {

            gm.SetLevel(nextlevel);
           
        }

    }
}