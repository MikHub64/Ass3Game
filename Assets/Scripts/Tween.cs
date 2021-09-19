using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tween
{   
    public Transform Target { get; set; }
    public Vector3 StartPos { get; set; }
    public Vector3 EndPos { get; set; }
    public float StartTime { get; set; }
    public float Duration { get; set; }

    public Tween(Transform a, Vector3 b, Vector3 c, float d, float e)
    {
        Target = a;
        StartPos = b;
        EndPos = c;
        StartTime = d;
        Duration = e;
    }
}

