using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnding : MonoBehaviour
{
    public PortalControl good_portal;
    public PortalControl bad_portal;

    public PlayerController good_cube;
    public PlayerController bad_cube;

    public string next_scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (good_cube.inHole)
        {
            StartCoroutine(loseLevel());
        }
        if (bad_cube.inHole)
        {
            Destroy(bad_cube, 0.001f); // TODO: not destroying properly
        }

        if (good_portal.isPlayerHere)
        {
            if (!bad_portal.isPlayerHere)
            {
                StartCoroutine(endLevel());
            }
            else
            {
                StartCoroutine(loseLevel());
            }
        }
    }

    IEnumerator endLevel()
    {
        //audioSource.PlayOneShot(tada);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(next_scene);
    }

    IEnumerator loseLevel()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("LoseScene");
    }
}
