using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Color invincibilityColor;
    [SerializeField] private Color normalColor;

    [SerializeField] private Enemy enemy;

    public Enemy Enemy { get => enemy; set => enemy = value; }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            UpdateHealth();
        }
        else
        {
            healthImage.gameObject.SetActive(false);
        }
    }

    void UpdateHealth()
    {
        healthImage.fillAmount = 1.0f * enemy.CurrentHealth / enemy.Stats.Health;
        healthImage.color = enemy.IsInvincible ? invincibilityColor : normalColor;
    }
}
