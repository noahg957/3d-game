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
    public AudioSource audioSource;
    public AudioClip burn;
    public AudioClip success;
    public AudioClip failure;

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
            good_cube.goInvisible();
            audioSource.PlayOneShot(burn);
            StartCoroutine(loseLevel());
        }
        if (bad_cube.inHole)
        {
            audioSource.PlayOneShot(burn);
            bad_cube.goInvisible();
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
        if (good_cube.fellOff)
        {
            StartCoroutine(loseLevel());
        }
    }

    IEnumerator endLevel()
    {
        //audioSource.PlayOneShot(tada);
        audioSource.PlayOneShot(success);
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(next_scene);
    }

    IEnumerator loseLevel()
    {
        audioSource.PlayOneShot(failure);
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
