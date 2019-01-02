using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{

    public Image img;
    public AnimationCurve curve;
   

    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());

    }

    void Update()
    {

    }

    public void FadeTo(string scene)
    {

        StartCoroutine(FadeOut(scene));
    }
    //Overload for death
    public void FadeTo()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }


    }
    IEnumerator FadeOut(string _scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(_scene);

    }
    IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        StartCoroutine(FadeIn());


    }
}
