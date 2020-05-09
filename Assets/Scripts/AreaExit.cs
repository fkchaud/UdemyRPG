using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName = "";

    [SerializeField]
    private string transitionPointName = "";
    public string TransitionPointName => transitionPointName;

    private void Start()
    {
        if (string.IsNullOrWhiteSpace(targetSceneName))
            Debug.LogError($"{this.GetType().Name} object has not set targetSceneName variable.", this);
        if (string.IsNullOrWhiteSpace(transitionPointName))
            Debug.LogError($"{this.GetType().Name} object has not set transitionPointName variable.", this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        PlayerController.Instance.LastTransitionPointName = transitionPointName;
        SceneManager.LoadScene(targetSceneName);
    }
}
