
using TMPro;
using UnityEngine;

public class CoinTrackerUI : MonoBehaviour
{
    [SerializeField] private TrackerScriptableObject _coinCounter;
    [SerializeField] private TextMeshProUGUI scoreUI;

    private void Awake()
    {   
        scoreUI = gameObject.GetComponent<TextMeshProUGUI>();
        PlayerPickup.OnCoinPickup += coinPickup;
        scoreUI.text = _coinCounter.Value.ToString();
    }
    private void Update()
    {
        scoreUI.text = _coinCounter.Value.ToString();
    }
    private void coinPickup()
    {
        _coinCounter.Value++;
        scoreUI.text = _coinCounter.Value.ToString();
    }

    private void OnDisable()
    {
        PlayerPickup.OnCoinPickup -= coinPickup;
    }
}
