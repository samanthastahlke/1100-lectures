using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public float energyChange = 20.0f;

    private float energy = 100.0f;
    private bool isGaining = false;

    private Image barImage;

    // Start is called before the first frame update
    void Start()
    {
        barImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaining)
            energy += Time.deltaTime * energyChange;
        else
            energy -= Time.deltaTime * energyChange;

        barImage.fillAmount = energy / 100.0f;
    }

    public void FishEnteredBar()
    {
        isGaining = true;
    }

    public void FishExitedBar()
    {
        isGaining = false;
    }

}
