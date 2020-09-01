using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScripts : ScrollRect
{
    float radius = 0f;
    float x;
    float y;
    float z;
    public Vector3 vector3;
    protected override void Start()
    {
        radius = viewport.rect.width / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (content.localPosition.magnitude > radius)
        {
            content.localPosition = content.localPosition.normalized * radius;
        }
        x = content.localPosition.normalized.x;
        y = content.localPosition.normalized.y;
        z = content.localPosition.normalized.z;
        vector3 = new Vector3(y,x,z);
    }
}
