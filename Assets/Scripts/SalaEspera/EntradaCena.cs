using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaCena : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private string nomeSala;
    private void Start()
    {
        nomeSala = gameObject.name;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<CapsuleCollider2D>()))
        {
            SceneManager.LoadScene(nomeSala);
        }
    }


}
