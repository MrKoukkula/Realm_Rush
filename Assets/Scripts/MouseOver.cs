using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    private void OnMouseOver()
    {
        print("Eek! A Mouse is on "+ gameObject.name);
    }
}
