using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveText : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(8);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
