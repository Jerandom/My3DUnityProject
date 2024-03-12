using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float DynamicHealthBarAmount = 100f;
    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] private Image HealthBarImage;

    private void Awake()
    {
        HealthBarImage.fillAmount = getDynamicHealthBarAmountNomalized();
        HealthBarImage.color = GetHealthBarColour(DynamicHealthBarAmount);
    }

    private void Update()
    {
        HealthBarImage.fillAmount = getDynamicHealthBarAmountNomalized();
        HealthBarImage.color = GetHealthBarColour(DynamicHealthBarAmount);

    }

    public void addHealth(float health)
    {
        DynamicHealthBarAmount += health;
    }

    public void minusHealth(float health)
    {
        DynamicHealthBarAmount -= health;
    }

    private Color GetHealthBarColour(float value)
    {
        return Color.Lerp(Color.red, Color.green, Mathf.Pow(value / 100f, 2));
    }

    public float getDynamicHealthBarAmountNomalized()
    {
        return Mathf.Lerp(HealthBarImage.fillAmount, DynamicHealthBarAmount / MaxHealth, 3f * Time.deltaTime);
    }
}
