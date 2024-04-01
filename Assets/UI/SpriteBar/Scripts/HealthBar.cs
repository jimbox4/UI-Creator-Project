using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Heart _hertPrefab;
    [SerializeField] private int _maxValuePerHeart;
    [Header("Sprites")]
    [SerializeField] private Sprite _fullSprite;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private List<Sprite> _intermediateSprites;
    [Space]

    private int _maxHealth;
    private int _currentHealth;
    private int _heartsCount;
    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _health.Increased += UpdateHearts;
        _health.Decreased += UpdateHearts;
        _health.MaxValueChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.Increased -= UpdateHearts;
        _health.Decreased -= UpdateHearts;
        _health.MaxValueChanged -= UpdateBar;
    }

    [ContextMenu(nameof(Initialize))]
    public void Initialize()
    {
        _currentHealth = _health.CurrentHealth;
        _maxHealth = _health.MaxHealth;

        _heartsCount = Mathf.CeilToInt((float)_maxHealth / _maxValuePerHeart);

        Clear();
        Fill();
        UpdateHearts();
    }

    private void UpdateBar()
    {
        _maxHealth = _health.MaxHealth;

        _heartsCount = Mathf.CeilToInt((float)_maxHealth / _maxValuePerHeart);

        Clear();
        Fill();
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        _currentHealth = _health.CurrentHealth;

        for (int i = 0; i < _hearts.Count; i++)
        {
            int minValue = (int)MathF.Min(_maxValuePerHeart, _currentHealth - _maxValuePerHeart * i);

            if (minValue <= 0)
            {
                _hearts[i].ChangeSprite(_emptySprite);
            }
            else if (minValue < _maxValuePerHeart)
            {
                _hearts[i].ChangeSprite(_intermediateSprites[_currentHealth - _maxValuePerHeart * i - 1]);
            }
            else
            {
                _hearts[i].ChangeSprite(_fullSprite);
            }
        }
    }

    private void Clear()
    {
        if (_hearts.Count == 0)
        {
            return;
        }

        foreach (Heart heart in _hearts)
        {
            heart.Destroy();
        }
        
        _hearts.Clear();
    }

    private void Fill()
    {
        for (int i = 0; i < _heartsCount; i++)
        {
            _hearts.Add(Instantiate(_hertPrefab, transform));
        }
    }
}
