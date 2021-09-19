using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Items Items => items;

    public Player Player => GameObject.FindObjectOfType<Player>();

    [SerializeField]
    private Items items = null;

    [SerializeField]
    private List<Spawner> spawners = null;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    public Item GetItem(string name)
    {
        foreach (var item in Items.ItemsList)
        {
            if (name.Equals(item.ItemName))
            {
                return item;
            }
        }
        return null;
    }

    public Item GetRandomItem()
    {
        var index = UnityEngine.Random.Range(0, Items.ItemsList.Count);
        return Items.ItemsList[index];
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(5f);
        int index = UnityEngine.Random.Range(0, spawners.Count);
        spawners[index].Spawn();
        StartCoroutine(SpawnLoop());
    }
}