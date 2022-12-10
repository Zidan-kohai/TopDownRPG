using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    private Color firstColor;
    private void OnMouseEnter()
    {
        firstColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = firstColor;
    }
}
