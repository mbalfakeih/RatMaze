using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//stop the screams
//start playing the dialogue one by one, multiple coroutines I believe
public class RatDialogue : MonoBehaviour
{
    private AudioSource screams;
    private AudioSource singularScream;
    private CircleCollider2D collider;
    public TextMeshPro DialogueText;
    public GameObject screamer;
    public string[] Sentences;
    private int index = 0;
    private float DialogueSpeed;
    public GameObject dyingRat;
    public GameObject cutToBlack;
    private bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        DialogueSpeed = 0.25f;
        screams = screamer.GetComponent<AudioSource>();
        singularScream = GetComponent<AudioSource>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (!playing)
        {
            screams.Stop();
            StartCoroutine(Dialogue());
            StartCoroutine(Blackout());
            playing = true;
        }
    }

    IEnumerator Dialogue()
    {
        while(index < Sentences.Length)
        {
            StartCoroutine(WriteSentence());
            yield return new WaitForSeconds(15);
        }
    }

    IEnumerator WriteSentence()
    {
        if (index < Sentences.Length)
        {
            DialogueText.text = "";
            foreach (char Character in Sentences[index].ToCharArray())
            {
                DialogueText.text += Character;
                yield return new WaitForSeconds(DialogueSpeed); //use parity to determine speed, having player speak faster?
            }
            index = index + 1;
        }
        else
        {
            DialogueText.text = "";
        }
    }

    IEnumerator Blackout()
    {
        yield return new WaitForSeconds(65);
        cutToBlack.SetActive(true);
        singularScream.Play(0);
        Debug.Log("Killed");
        yield return new WaitForSeconds(1);
        cutToBlack.SetActive(false);
        dyingRat.SetActive(false);
    }
}
