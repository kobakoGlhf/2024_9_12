using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    Vector2 Target
    {
        get ; set;
    }
    void SetTarget();
}
