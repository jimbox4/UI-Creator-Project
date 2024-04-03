using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Heart _hertPrefab;
    [SerializeField] private int _maxValuePerHeart;
    [Header("Sprites")]
    [SerializeField] private Sprite _fullSprite;
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private List<Sprite> _intermediateSprites;
    [Space]

    private int _maxValue;
    private int _currentValue;
    private int _heartsCount;
    private List<Heart> _hearts = new List<Heart>();

    [ContextMenu(nameof(Initialize))]
    public void Initialize()
    {
        _currentValue = Health.CurrentValue;
        _maxValue = Health.MaxValue;

        _heartsCount = Mathf.CeilToInt((float)_maxValue / _maxValuePerHeart);

        Clear();
        Fill();
        UpdateHearts();
    }

    protected override void UpdateCurrentValue()
    {
        UpdateHearts();
    }

    protected override void UpdateMaxValue()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        _maxValue = Health.MaxValue;

        _heartsCount = Mathf.CeilToInt((float)_maxValue / _maxValuePerHeart);

        Clear();
        Fill();
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        _currentValue = Health.CurrentValue;

        for (int i = 0; i < _hearts.Count; i++)
        {
            int minValue = (int)MathF.Min(_maxValuePerHeart, _currentValue - _maxValuePerHeart * i);

            if (minValue <= 0)
            {
                _hearts[i].ChangeSprite(_emptySprite);
            }
            else if (minValue < _maxValuePerHeart)
            {
                _hearts[i].ChangeSprite(_intermediateSprites[_currentValue - _maxValuePerHeart * i - 1]);
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
