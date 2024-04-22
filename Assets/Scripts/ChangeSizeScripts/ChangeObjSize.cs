using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjSize : MonoBehaviour
{
    private Rigidbody2D rb;
    public string targetTag = "Ball";
    public float shrinkFactor;
    public string[] collisionTags = {"JumpAndMakeSmallerPlatform" };
    private bool needToChangeSize = true;

    void OnEnable()
    {
        EventManager.OnCollision2D += ChangeObjectSize;
    }

    void OnDisable()
    {
        EventManager.OnCollision2D -= ChangeObjectSize;
    }
    private void Start()
    {
        GameObject objectsWithTag = GameObject.FindGameObjectWithTag(targetTag);
        rb = objectsWithTag.GetComponent<Rigidbody2D>();

    }
    private void ChangeObjectSize(Collision2D collision)
    {
        foreach (string tag in collisionTags)
        {
            if (collision.gameObject.CompareTag(tag) && needToChangeSize)
            {
                rb.gameObject.transform.localScale *= shrinkFactor;
                needToChangeSize = false;
            }
        }
    }
}

