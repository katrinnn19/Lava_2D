using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    public float bounceForce;
    public string targetTag = "Ball";
    public string[] collisionTags = { "JumpUpPlatform", "JumpAndMakeSmallerPlatform" };
    private Rigidbody2D rb;

    private void Start()
    {
        GameObject objectsWithTag = GameObject.FindGameObjectWithTag(targetTag);
        rb = objectsWithTag.GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        EventManager.OnCollision2D += ChangeBounce;
    }

    void OnDisable()
    {
        EventManager.OnCollision2D -= ChangeBounce;
    }

    private void ChangeBounce(Collision2D collision)
    {
        foreach (string tag in collisionTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Debug.Log("here");
                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
