using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = 1;
        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomOut()
    {
        yield return new WaitForSeconds(2);
        for (double i = 1; i <= 2; i = i + 0.001)
        {
            yield return new WaitForSeconds((float)0.001);
            Camera.main.orthographicSize = (float)i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -1);
    }
}
