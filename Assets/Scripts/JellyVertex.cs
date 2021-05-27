using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyVertex
{
    public int ID;
    public Vector3 Position;
    public Vector3 velocity, Force;
    public JellyVertex(int _id, Vector3 _pos)
    {
        ID = _id;
        Position = _pos;
    }

    public void Shake(Vector3 target, float m, float s, float d)
    {
        Force = (target - Position) * s;
        velocity = (velocity + Force / m) * d;
        Position += velocity;
        if ((velocity + Force + Force / m ).magnitude < 0.001f )
        {
            Position = target;
        }
    }
}
