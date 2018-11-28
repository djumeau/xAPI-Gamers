using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    void Start()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;
    public Transform spawnPrefab;

    public IEnumerator RespawnPlayer ()
    {
        // respawn timer sound
        yield return new WaitForSeconds(spawnDelay);

        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        GBL_Interface.SendDied();
        gm.StartCoroutine (gm.RespawnPlayer());
    }

}
