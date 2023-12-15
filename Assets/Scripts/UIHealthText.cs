using UnityEngine;
using UnityEngine.UI;

public class UIHealthText : MonoBehaviour
{
    [SerializeField, GameObjectOfType(typeof(IAttackable))] private GameObject _gameObjectWithHealth;
    [SerializeField] private Text _healthText;

    private IAttackable _health;
    private int _maxHealth;
    private char _separator = '/';

    private void Awake()
    {
        _health = _gameObjectWithHealth.GetComponent<IAttackable>();
        _maxHealth = _health.MaxHealth;
    }

    private void Start()
    {
        _healthText.text = BuildText(_maxHealth);
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
        _healthText.text = BuildText(currentHealth);
    }

    private string BuildText(int currentHealth)
    {
        return currentHealth.ToString() + _separator + _maxHealth.ToString();
    }
}
