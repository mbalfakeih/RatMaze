using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeHole : MonoBehaviour
{
    public GameObject Thought;
    public Transform player;
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
        Thought.SetActive(true);
        StartCoroutine(EscapeTeleport());
    }

    IEnumerator EscapeTeleport()
    {
        yield return new WaitForSeconds(5);
        player.position = new Vector3(49, 15.69f, 0);
    }
}
