// using System;
// using System.Collections;
// using Sirenix.OdinInspector;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

namespace CrowdFight
{
    // [Serializable]
    public class HealthSystem
    {
  //       // Mono Behaviour.
		// // Regen.
		//
		// public event Action DidDie;
  //       
  //       [ShowInInspector, ReadOnly] private bool _isAlive;
  //       [Space]
  //       [ShowInInspector, ReadOnly] private int _health;
  //       [ShowInInspector, ReadOnly] private int _maxHealth;
  //       [Space]
  //       [ShowInInspector, ReadOnly] private bool _hasUI;
  //       [ShowInInspector, ReadOnly] private bool _hasAnimation;
  //       [ShowInInspector, ReadOnly] private Image _healthBarImage;
  //       [ShowInInspector, ReadOnly] private TMP_Text _healthText;
  //       
  //       private const int MIN_HEALTH = 0;
  //       private float _animationDuration = 1f;
  //       private float _timer = 0f;
  //       
  //       private int Health
  //       {
  //           get => _health;
  //           set
  //           {
  //               if (!_isAlive) return;
  //               
  //               _health = value;
  //               _health = Mathf.Clamp(_health, MIN_HEALTH, _maxHealth);
  //               UIUpdate();
  //               
  //               if (_health != 0) return;
  //               _isAlive = false;
  //               DidDie?.Invoke();
  //           }
  //       }
  //
  //       public HealthSystem(
  //           int initialHealth, 
  //           int maxHealth = 100, 
  //           bool hasUI = false,
  //           bool hasAnimation = false,
  //           Image healthBarImage = null, 
  //           TMP_Text healthText = null)
  //       {
  //           _isAlive = true;
  //           
  //           _health = initialHealth;
  //           _maxHealth = maxHealth;
  //           
  //           _hasUI = hasUI;
  //           _hasAnimation = hasAnimation;
  //           _healthBarImage = healthBarImage;
  //           _healthText = healthText;
  //
  //           UIUpdate();
  //       }
  //
  //       public void FullHealth()
  //       {
  //           Health = _maxHealth;
  //       }
  //
  //       public void IncreaseMaxHealth(int value)
  //       {
  //           Health += value;
  //           _maxHealth += value;
  //       }
  //
  //       public void GetHit(int damage)
  //       {
  //           var currentValue = Health;
  //           var nextValue = Health -= damage;
  //           
  //           //UIAnimation(currentValue, nextValue);
  //           //CoroutineRunner.Run(Routine(currentValue, nextValue));
  //       }
  //       
  //       private void UIAnimation(int currentValue, int nextValue)
  //       {
  //           if (!_hasAnimation) return;
  //
  //           while (_timer < _animationDuration && _isAlive)
  //           {
  //               _timer += Time.deltaTime;
  //               var tVal = Mathf.InverseLerp(0, _animationDuration, _timer);
  //               Health = (int)Mathf.Lerp(currentValue, nextValue, tVal);
  //           }
  //       }
  //       
  //       private IEnumerator Routine(int currentValue, int nextValue)
  //       {
  //           if (!_hasAnimation) yield return null;
  //           
  //           while (_timer < _animationDuration && _isAlive)
  //           {
  //               _timer += Time.deltaTime;
  //               var tVal = Mathf.InverseLerp(0, _animationDuration, _timer);
  //               Health = (int)Mathf.Lerp(currentValue, nextValue, tVal);
  //               yield return new WaitForSeconds(Time.deltaTime);
  //           }
  //       }
  //
  //       private void UIUpdate()
  //       {
  //           if (!_hasUI) return;
  //           
  //           var fillAmount = Mathf.InverseLerp(MIN_HEALTH, _maxHealth, _health);
  //           _healthBarImage.fillAmount = fillAmount;
  //           _healthText.text = $"{_health}";
  //       }
    }
}