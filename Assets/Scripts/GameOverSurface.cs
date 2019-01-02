using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSurface : HitSurface
{
    public Transform SpawnPoint;
    private SceneFader fade;
        
    new void Start()
    {
        base.Start();
        fade = FindObjectOfType<SceneFader>();
    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpearHead1" || col.gameObject.tag == "SpearHead2" || col.gameObject.tag == "SpearBody")
        {
            fade.FadeTo();
            knife.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            player.transform.position = new Vector2(SpawnPoint.position.x,SpawnPoint.position.y);
        }
    }
    public override void OnTriggerExit2D(Collider2D col)
    {
        player.transform.parent = null;
        
        knife.IsLanding = true;

    }
   

}
