using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject LockMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit door");
        if (keyObject.GetComponent<Key>().key)
        {
            LockMessage.SetActive(false);
            Debug.Log("open door");
            Destroy(gameObject);
        }
        else
        {
            LockMessage.SetActive(true);
        }
    }
}
