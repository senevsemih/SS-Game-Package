using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePackage.Runtime.Systems
{
    [Serializable]
    public class HealthSystem : MonoBehaviour
    {
        public event Action DidDie;
        
        [ShowInInspector, ReadOnly] private bool _isAlive;
        [Space]
        [ShowInInspector, ReadOnly] private int _health;
        [ShowInInspector, ReadOnly] private int _maxHealth;
        [Space]
        [ShowInInspector, ReadOnly] private bool _hasUI;
        [ShowInInspector, ReadOnly] private bool _hasAnimation;
        [ShowInInspector, ReadOnly] private float _animationDuration;
        [Space]
        [ShowInInspector, ReadOnly] private Image _healthBarImage;
        [ShowInInspector, ReadOnly] private TMP_Text _healthText;
        
        private const int MIN_HEALTH = 0;
        private float _timer;
        private int _storedHealth;

        private Coroutine _healthTransitionRoutine;
        
        private int Health
        {
            get => _health;
            set
            {
                if (!_isAlive) return;
                
                _health = value;
                _health = Mathf.Clamp(_health, MIN_HEALTH, _maxHealth);
                UIUpdate();
                
                if (_health != 0) return;
                _isAlive = false;
                DidDie?.Invoke();
            }
        }

        private int StoredHealth
        {
            get => _storedHealth;
            set
            {
                _storedHealth = value;
                _storedHealth = Mathf.Clamp(_storedHealth, MIN_HEALTH, _maxHealth);
            }
        }

        public void InitialSettings(
            int initialHealth, 
            int maxHealth = 100, 
            bool hasUI = false,
            bool hasAnimation = false,
            float animationDuration = 0.5f,
            Image healthBarImage = null, 
            TMP_Text healthText = null)
        {
            _isAlive = true;
            
            _health = initialHealth;
            _maxHealth = maxHealth;
            _storedHealth = _health;
            
            _hasUI = hasUI;
            _hasAnimation = hasAnimation;
            _animationDuration = animationDuration;
            _healthBarImage = healthBarImage;
            _healthText = healthText;
		
            UIUpdate();
        }
        
        public void FullHealth()
        {
            Health = _maxHealth;
            StoredHealth = _maxHealth;
        }
		
        public void IncreaseMaxHealth(int value)
        {
            _maxHealth += value;
            Health += value;
            StoredHealth += value;
        }
		
        public void GetHit(int damage)
        {
            var currentValue = Health;
            StoredHealth -= damage;

            if (_healthTransitionRoutine != null)
            {
                StopCoroutine(_healthTransitionRoutine);
                _timer = 0;
            }
            _healthTransitionRoutine = StartCoroutine(HealthTransitionRoutine(currentValue, _storedHealth));
        }
        
        private IEnumerator HealthTransitionRoutine(int currentValue, int nextValue)
        {
            if (!_hasAnimation) yield return null;
            
            while (_timer < _animationDuration && _isAlive)
            {
                _timer += Time.deltaTime;
                var tVal = Mathf.InverseLerp(0, _animationDuration, _timer);
                Health = (int)Mathf.Lerp(currentValue, nextValue, tVal);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
		
        private void UIUpdate()
        {
            if (!_hasUI) return;
            
            var fillAmount = Mathf.InverseLerp(MIN_HEALTH, _maxHealth, _health);
            _healthBarImage.fillAmount = fillAmount;
            _healthText.text = $"{_health}";
        }
    }
}