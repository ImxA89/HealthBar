using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField, GameObjectOfType(typeof(IAttackable))] private GameObject _gameObjectWithHealth;
    [SerializeField] private Slider _healthBar;

    private IAttackable _health;
    private int _maxHealth;

    private void Awake()
    {
        _health = _gameObjectWithHealth.GetComponent<IAttackable>();
        _maxHealth = _health.MaxHealth;
        _healthBar.minValue = 0f;
        _healthBar.maxValue = 1f;
    }

    private void Start()
    {
        _healthBar.value = _maxHealth / _maxHealth;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth)
    {
        _healthBar.value = (float)currentHealth/_maxHealth;
    }
}
