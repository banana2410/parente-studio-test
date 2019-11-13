using TMPro;
using UnityEngine;

//Class that is responsible for updating UI on collectables pickup
public class SkullTrackerUI : MonoBehaviour
{
    //Reference to score UI
    [SerializeField]
    private TextMeshProUGUI scoreUI;
    //Data container for skull count
    [SerializeField] private TrackerScriptableObject _skullCounter;

    //Subscribing skullPickup method to OnSkullPickup, so it gets called when skull is picked up, setting UI score count with data container count
    private void Awake()
    {
        PlayerPickup.OnSkullPickup += skullPickup;
        scoreUI = gameObject.GetComponent<TextMeshProUGUI>();
        scoreUI.text = _skullCounter.Value.ToString();
    }
    private void Update()
    {
        scoreUI.text = _skullCounter.Value.ToString();
    }
    //Increments value by one and converts it to string to be able to show it in UI
    private void skullPickup()
    {
        _skullCounter.Value++;
        scoreUI.text = _skullCounter.Value.ToString();
    }
    //Unsubscribing from OnSkullPickup to stop memory leaking and potential bugs
    private void OnDisable()
    {
        PlayerPickup.OnSkullPickup -=skullPickup;
    }

}
