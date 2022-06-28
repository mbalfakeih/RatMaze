using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool key;
    private SpriteRenderer sprite;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        key = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        key = true;
        sprite.enabled = false;
        text.SetActive(true);
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(20);
        text.SetActive(false);
    }

}
