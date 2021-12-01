using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject[] scenes;
    [SerializeField]
    private GameObject activeScene;
    private GameObject targetScene;


    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LevelChangeEffect(sceneName));
    }
    
    public void GiveLootToPlayer(Item item, int cuantity)
    {
        player.inventory.AddItem(item, cuantity);
    }

    private IEnumerator LevelChangeEffect(string sceneName)
    {
        Time.timeScale = 0;
        Debug.Log("TimeStop");
        yield return new WaitForSecondsRealtime(1);

        //Bloom effect

        PostProcessVolume volume = GameObject.Find("Post processor").GetComponent<PostProcessVolume>();
        Bloom bloom = null;
        volume.profile.TryGetSettings(out bloom);
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Intensity increased");
            bloom.intensity.Override(Mathf.Lerp(2f, 40f, i / 10f));
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(0.5f);

        Debug.Log("Load Level");

        foreach (GameObject scene in scenes)
        {
            if (scene.name == sceneName)
            {
                targetScene = scene;

            }
        }
        targetScene.SetActive(true);
        activeScene.SetActive(false);
        activeScene = targetScene;


        Debug.Log("Begin Stabolizing");
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Intensity increased");
            bloom.intensity.Override(Mathf.Lerp(40f, 2f, i / 10f));
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Debug.Log("Intensity Stabilised");
        Time.timeScale = 1;
        Debug.Log("TimeResume");


    }
}
