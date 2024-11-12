using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    public Image hpIconPrefab;
    public PlayerController player;

    private List<Image> icons = new();
    private int numShown;

    // Start is called before the first frame update
    void Start()
    {
        numShown = player.maxHealth;

        for (int i = 0; i < numShown; ++i)
        {
            Image icon = Instantiate(hpIconPrefab);
            icon.rectTransform.SetParent(transform, false);
            icons.Add(icon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numShown != player.GetHP())
        {
            numShown = player.GetHP();

            for(int i = numShown; i < icons.Count; ++i)
            {
                icons[i].gameObject.SetActive(false);
            }
               
        }
    }
}
