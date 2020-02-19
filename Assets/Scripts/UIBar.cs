using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

    public Image fill;

    public float PlayerHealth;
    public float LastPlayerHealth;
    public float HealthToShow;
    public float ChangeSpeed;

    public Color maxHealthColor;
    public Color highHealthColor;
    public Color midHealthColor;
    public Color minHealthColor;

    public float lowHealthFlash;

    public float flashAdjustment;
    public float flashTimer;
    public float timeBetweenFlashes;
    public float timeBetweenFlashesCurrent;

    public bool flashChanged;

    public float max;
    public float current;

    private float midHealth;
    //EnemyMovement bossStats;
    public Slider hb;


    void Start()
    {
        hb = GetComponent<Slider>();
        midHealth = (100 - lowHealthFlash) / 2;
    }

    public void UpdateHealthBar()
    {
        if (true)//(Time.unscaledDeltaTime < 0.25f)
        {
            PlayerHealth = (float)(current / max) * 100f;
            LastPlayerHealth += (PlayerHealth - LastPlayerHealth) * ChangeSpeed * Time.unscaledDeltaTime;
            HealthToShow = LastPlayerHealth;

            hb.value = HealthToShow;

            if (HealthToShow > lowHealthFlash)
            {
                if (HealthToShow >= 99.8f)
                {
                    fill.color = maxHealthColor;
                }
                else if (HealthToShow < midHealth)
                {
                    fill.color = Color.Lerp(minHealthColor, midHealthColor, (HealthToShow - lowHealthFlash) / (midHealth - lowHealthFlash));

                }
                else
                {
                    fill.color = Color.Lerp(midHealthColor, highHealthColor, (HealthToShow - (100 - midHealth)) / (midHealth - lowHealthFlash));
                }
            }
            else
            {
                flashTimer -= Time.unscaledDeltaTime;
                timeBetweenFlashesCurrent -= Time.unscaledDeltaTime;
                if (timeBetweenFlashesCurrent < 0)
                {
                    timeBetweenFlashesCurrent += timeBetweenFlashes;
                    flashTimer = flashAdjustment;

                    //flashChanged = !flashChanged;
                }
                fill.color = Color.Lerp(minHealthColor, Color.white, flashTimer / flashAdjustment);
            }
        }
    }


    void Update()
    {

    }



}