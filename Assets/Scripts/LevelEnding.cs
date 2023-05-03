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
    private bool badCubeAlive = true;
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
            StartCoroutine(burnSound());
            good_cube.goInvisible();





            StartCoroutine(loseLevel());
        }
        if (bad_cube.inHole && badCubeAlive)
        {
            StartCoroutine(burnSound());
            bad_cube.goInvisible();
            badCubeAlive = false;


        }

        if (good_portal.isPlayerHere)
        {
            good_cube.FreezeCube();
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

    IEnumerator burnSound()
    {

        audioSource.volume = 0.9f;
        audioSource.PlayOneShot(burn);
        yield return new WaitForSeconds(0.6f);
        audioSource.volume = 0.098f;
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
