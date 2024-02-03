using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    private float increaseScale = 1.0f;

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(transform.localScale.x, transform.localScale.y, 0) * increaseScale;
    }
}
