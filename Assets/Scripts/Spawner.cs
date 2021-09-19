using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Spirit spiritPrefab = null;
    [SerializeField]
    private bool invertX = false;

    private Spirit spirit = null;

    public void Spawn()
    {
        if(spirit != null)
        {
            return;
        }
        spirit = Instantiate(spiritPrefab, transform.position, Quaternion.identity);
        spirit.transform.localScale = new Vector3(invertX ? -1f : 1f, 1f, 1f);
    }
}
