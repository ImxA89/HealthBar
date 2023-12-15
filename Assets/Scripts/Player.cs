using System;
using UnityEngine;

public class Player : MonoBehaviour, IAttackable
{
    [SerializeField][Min(2)] private int _maxHealth;
    [SerializeField][Min(2)] private int _damage;

    private Health _health;

    public int MaxHealth => _maxHealth;

    public event Action<int> HealthChanged;

    private void Awake()
    {
        _health = new Health(_maxHealth);
    }

    private void OnEnable()
    {
        _health.Died += OnDied;
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _health.HealthChanged -= OnHealthChanged;
    }

    public void TakeHeal(int healPower)
    {
            _health.TakeHeal(healPower);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }

    private void OnHealthChanged(int currentHealth)
    {
        HealthChanged?.Invoke(currentHealth);
    }
}
