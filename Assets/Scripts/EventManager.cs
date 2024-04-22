using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CollisionAction(Collision2D collision);
    public static event CollisionAction OnCollision2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnCollision2D != null)
        {
            OnCollision2D(collision);
        }
    }
}
