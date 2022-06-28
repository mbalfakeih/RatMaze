using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtController : MonoBehaviour
{
    public TextMeshPro DialogueText;
    public string[] Sentences;
    private int index = 0;
    private float DialogueSpeed;
    // Start is called before the first frame update
    void Start()
    {
        DialogueSpeed = 0.5f; //Higher is slower
        //NextSentence();
        StartCoroutine(WriteSentence());
    }

    // Update is called once per frame
    void Update()
    {
        //NextSentence();
        //StartCoroutine(WriteSentence());
    }

    void NextSentence()
    {
        if(index < Sentences.Length)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        index++;
    }

}
