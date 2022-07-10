using GamePackage.Runtime.Systems;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemTest : MonoBehaviour
{
    [SerializeField] private int _InitialHealth;
    [SerializeField] private int _MaxHealth;
    [SerializeField] private float _AnimationDuration;
    [Space] 
    [SerializeField] private bool _HasUI;
    [SerializeField] private bool _HasAnimation;
    [Space]
    [SerializeField] private Image _HealthImage;
    [SerializeField] private TMP_Text _HealthText;
    
    [ShowInInspector, ReadOnly] private HealthSystem _health;
    
    private void Awake()
    {
        if (_health) return; 
        _health = gameObject.AddComponent<HealthSystem>();
        _health.InitialSettings(100);
        
        _health.DidDie += HealthOnDidDie;
    }

    [Button]
    private void UpdateValues()
    {
        _health.InitialSettings(_InitialHealth, _MaxHealth, _HasUI, _HasAnimation, _AnimationDuration, _HealthImage, _HealthText);
    }

    [Button]
    private void GetHit(int value)
    {
        _health.GetHit(value);
    }

    [Button]
    private void IncreaseMaxHealth(int value)
    {
        _health.IncreaseMaxHealth(value);
    }

    [Button]
    private void FullHealth()
    {
        _health.FullHealth();
    }
    
    private void HealthOnDidDie()
    {
        Debug.Log("Dead");
    }
}
