using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStart : MonoBehaviour
{
    public GameObject SpotLight;
    public GameObject light2D;
    private UnityEngine.Rendering.Universal.Light2D Spotlight;
    // Start is called before the first frame update
    void Start()
    {
        light2D.SetActive(false);
        Spotlight = SpotLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        Spotlight.intensity = 0;
        StartCoroutine(Wait());
        StartCoroutine(Wait2());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(8);
        light2D.SetActive(true);
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSecondsRealtime(10);
        Spotlight.intensity = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
