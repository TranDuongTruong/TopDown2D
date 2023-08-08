using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 7f;
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
