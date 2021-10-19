using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampGreen : MonoBehaviour
{
    public Image green;

   

   
    void Update()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(this.transform.position);
        green.transform.position = temp;
    }
}
