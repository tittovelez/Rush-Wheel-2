using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeUI : MonoBehaviour
{
    public Image[] livesImages;

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            livesImages[i].enabled = i < livesRemaining;
        }
    }
}
