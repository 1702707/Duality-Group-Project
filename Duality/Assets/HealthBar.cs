using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] Pips;
    public Sprite Full;
    public Sprite Half;
    public Sprite Empty;

    public void Updatebar(int health)
    {
        switch (health)
        {
            case 0:
                {
                    Pips[0].sprite = Empty;
                    Pips[1].sprite = Empty;
                    Pips[2].sprite = Empty;
                }
                break;
            case 1:
                {
                    Pips[0].sprite = Half;
                    Pips[1].sprite = Empty;
                    Pips[2].sprite = Empty;
                }
                break;
            case 2:
                {
                    Pips[0].sprite = Full;
                    Pips[1].sprite = Empty;
                    Pips[2].sprite = Empty;
                }
                break;
            case 3:
                {
                    Pips[0].sprite = Full;
                    Pips[1].sprite = Half;
                    Pips[2].sprite = Empty;
                }
                break;
            case 4:
                {
                    Pips[0].sprite = Full;
                    Pips[1].sprite = Full;
                    Pips[2].sprite = Empty;
                }
                break;
            case 5:
                {
                    Pips[0].sprite = Full;
                    Pips[1].sprite = Full;
                    Pips[2].sprite = Half;
                }
                break;
            case 6:
                {
                    Pips[0].sprite = Full;
                    Pips[1].sprite = Full;
                    Pips[2].sprite = Full;
                }
                break;
        }
    }
}
