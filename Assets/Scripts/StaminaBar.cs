using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 25;
    private float currentStamina;
    // Start is called before the first frame update

    private WaitForSeconds regenTick = new WaitForSeconds(0.25f);
    private Coroutine regen;

    public static StaminaBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sprinting()
    {

    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            StartCoroutine(ReduceStamina(amount));

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not enough stamina");
            staminaBar.value = 0;
        }
    }

    IEnumerator ReduceStamina(float amount) 
    {
        yield return new WaitForSeconds(0.5f);
        currentStamina -= amount;
        staminaBar.value = currentStamina;
    }

    IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 200;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
