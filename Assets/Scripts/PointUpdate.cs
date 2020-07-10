using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUpdate : MonoBehaviour
{
    public static TextMeshPro points;
    public static int point;

    public static int level;


    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<TextMeshPro>();
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = point.ToString();

    }
}
