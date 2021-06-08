using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private BoxCollider box;
    public int buildIndex = 1;
    
    private GameObject player;
    private GlitchControl glitch;

    void Start()
    {
        player = FindObjectOfType<CyberSpaceFirstPerson>().gameObject;
        glitch = FindObjectOfType<GlitchControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            glitch.StartCoroutine("TransitionToLevel", buildIndex);

            //SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
        }
    }

}
