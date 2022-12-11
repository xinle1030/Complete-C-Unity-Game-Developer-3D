using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    // add the audioclips in the GUI for success and crash
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update() 
    {
        RespondToDebugKeys();    
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;  // toggle collision
        } 
    }

    // callback function that will be triggered upon collision
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled) { return; }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    /*
    Invoke() allows us to call a method so it executes after a delay of x seconds
    Invoke("MethodName", delayInSeconds)
    */

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();                         // stop all sound source
        audioSource.PlayOneShot(success);           // play success audio source
        successParticles.Play();                    // emit success particles
        GetComponent<Movement>().enabled = false;   // disable Movement script when move to next level
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();                         // stop all sound source
        audioSource.PlayOneShot(crash);             // play crash audio source
        crashParticles.Play();                      // emit crash particles
        GetComponent<Movement>().enabled = false;   // disable Movement script when crash into obstacle
        Invoke("ReloadLevel", levelLoadDelay);      // reload and restart current scene
    }

    /*
    Use SceneManager.LoadScene()
    -> to load current scene, therefore respawning our rocket ship to when it collides with the ground
    -> need to use "using UnityEngine.SceneManagement;" namespace
    */

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // get next scene index

        // if get over the end of the level, return to first level
        // .sceneCountInBuildSettings means total number of scenes
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        // get current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
