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
    public Transform player;
    private bool playing;
    public int level;
    private float position;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        winAudio = GetComponent<AudioSource>();
        if(level == 1)
        {
            position = 15.5f;
        }else if(level == 2)
        {
            position = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!playing)
        {
            winAudio.Play(0);
            playing = true;
        }
        StartCoroutine(Wait());
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        GlobalLight.SetActive(true);
        Spotlight.SetActive(false);
        Light2D.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        player.position = new Vector3(position, 0, 0); //slight teleporation glitch where you can't move for a second
        GlobalLight.SetActive(false);
        Spotlight.SetActive(true);
        Light2D.SetActive(true);
        playing = false;
    }
}
//15.5, 30