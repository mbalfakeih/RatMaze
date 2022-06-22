using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private Collider2D collider;
    public GameObject GlobalLight;
    public GameObject Spotlight;
    public GameObject Light2D;
    public GameObject Camera;
    private AudioSource winAudio;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        winAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        winAudio.Play(0);
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        GlobalLight.SetActive(true);
        Spotlight.SetActive(false);
        Light2D.SetActive(false);
    }
}
