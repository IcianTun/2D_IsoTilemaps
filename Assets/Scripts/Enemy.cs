using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Image currentHealthImage;
    float healthOriginalSize;
    public GameObject particleSystem;

    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; } }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthOriginalSize = currentHealthImage.rectTransform.rect.width;
    }
    
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth <= 0)
        {
            Instantiate(particleSystem, transform.position,particleSystem.transform.rotation);
            Destroy(gameObject);
        }

        currentHealthImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthOriginalSize * ((float)currentHealth/maxHealth));
    }
}
