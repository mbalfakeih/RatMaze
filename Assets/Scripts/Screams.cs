using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screams : MonoBehaviour
{
    private CircleCollider2D collider;
    private AudioSource screams;
    public Transform player;
    private bool screaming;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        screams = GetComponent<AudioSource>();
        screaming = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!screaming)
        {
            screams.Play(0);
            screaming = true;
        }
    }
}
