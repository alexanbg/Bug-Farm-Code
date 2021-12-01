using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Receiver : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private DebugStation[] debugStations;
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private string BugType;
    
    private NameSpritePair pair;

    [HideInInspector]
    public bool isHit = false;
    [HideInInspector]
    public float timer = 0;

    private void Awake()
    {
        pair = GameObject.Find("NameSpritePair").GetComponent<NameSpritePair>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        button.interactable = isHit;
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            isHit = false;
        }
    }
    public void Complete()
    {
        Item reward = new Item(BugType,pair.pairs[BugType]);
        //Discover all bugged blocks
        
        levelManager.GiveLootToPlayer(reward, debugStations.Where(x => x.hasBuggedBlock).Count());
        foreach(DebugStation debugStation in debugStations)
        {
            debugStation.BegginDebugging();
        }
        StartCoroutine(ChangeLevel());
    }
    public void Exit()
    {
        levelManager.ChangeScene("World");
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        levelManager.ChangeScene("World");
    }
}
