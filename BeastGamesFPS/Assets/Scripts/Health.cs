using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField, Tooltip("Scriptable object zawieraj�cy informacje o celu.")]
    private TargetInfo targetInfo;
    private int currentHealth;
    [SerializeField, Header("Metody kt�re zostan� wywo�ane przy '�mierci' obiektu.")]   //nie da�o si� u�y� toolTipa wi�c da�em header
    private UnityEvent onDeath;
    private TextMeshProUGUI text;
    [SerializeField]
    private bool displayInfo = true;

    public TargetInfo TargetInfo { get => targetInfo; }

    private void Start()
    {
        currentHealth = targetInfo.maxHealth;
        text = GetComponentInChildren<TextMeshProUGUI>();
        UpdateInfoDisplay();
    }

    /// <summary>
    /// Metoda odpowiadaj�ca za wykonanie operacji po przyj�ciu damage'u.
    /// </summary>
    /// <param name="damage">Ile �ycia powinno zosta� zabrane.</param>
    public void TakeHit(int damage)
    {
        if (currentHealth - damage <= 0) { Die(); return; }
        
        currentHealth -= damage;
        UpdateInfoDisplay();
        print("Current Health: " + targetInfo.maxHealth + "/" + currentHealth);
    }

    /// <summary>
    /// Metoda odpowiadaj�ca za wykonanie operacji przed zniszczeniem obiektu. 
    /// Wywo�ywana gdy currenyHealth jest mniejszy/rowny 0.
    /// </summary>
    public void Die()
    {
        onDeath.Invoke();
        //particles
        Destroy(gameObject);
    }

    /// <summary>
    /// Uaktualnia informacje o objekcie.
    /// </summary>
    public void UpdateInfoDisplay()
    {
        if (displayInfo)
            text.text = $"MATERIAL {targetInfo.vulnerability.ToString()}\nHP {currentHealth}/{targetInfo.maxHealth}";
    }
}
