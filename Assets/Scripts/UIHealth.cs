using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image healthValue;

    private void OnEnable()
    {
        PlayerHealthController.damageEvent = new UnityEngine.Events.UnityEvent<float>();
        PlayerHealthController.damageEvent.AddListener(UpdateHealth);
    }

    private void OnDisable()
    {
        PlayerHealthController.damageEvent.RemoveListener(UpdateHealth);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float health)
    {
        healthValue.transform.localScale = new Vector3(health / 100, 1, 1);
    }
}
