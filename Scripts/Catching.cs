using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Catching : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    private string[] levelName;
    private int levelsPlayed;

    private void Awake()
    {
        levelName = new string[3];
        levelsPlayed = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Bug"))
        {
            StartCoroutine(DestroyBug(collision));
            ChangeLevel();
        }
        else if (collision.collider.CompareTag("Shop"))
        {
            if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
            {
                levelManager.ChangeScene("ShopUI");
            }
        }
        else if (collision.collider.CompareTag("Incubator"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                collision.collider.gameObject.GetComponent<Incubator>().EnterIncubator();
            }
        }
        else if (collision.collider.CompareTag("Boulder"))
        {
            Debug.Log("Attemt to destroy block occured!");
            collision.collider.gameObject.GetComponent<DestroyableObject>().DestroyBoulder();
        }
    }


    private void ChangeLevel()
    {
        levelsPlayed++;
        levelName = new string[]{
            "Laser",
            "Level",
            $"{levelsPlayed}"
        };
        Debug.Log(string.Join("", levelName));
        levelManager.ChangeScene(string.Join("",levelName));
        
    }

    private IEnumerator DestroyBug(Collision2D collision)
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(collision.collider.gameObject);
    }
}
