using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    public float distance;

    private GameObject target;

    void Start()
    {
        target = GameObject.Find("SpearRotatePoint");
            
    }
    void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(target.transform.position.x, xMin, xMax), Mathf.Clamp(target.transform.position.y, yMin, yMax));

    }
}
