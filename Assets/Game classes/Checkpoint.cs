using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class Checkpoint:MonoBehaviour
{
    public int playerid;
    public int level_id; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB
    public string checkpoint; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB

    public Checkpoint(int playerid, int level_id, string checkpoint)
    {
        this.playerid = playerid;
        this.level_id = level_id;
        this.checkpoint = checkpoint;
    }
    // GETTERS
    public string getCheckpoint()
    {
        return checkpoint;
    }
    public void setCheckpoint(string point)
    {
        this.checkpoint = point;
        // update function must called to update DB
        StartCoroutine(UpdateCheckpointDB(checkpoint));
    }

    IEnumerator UpdateCheckpointDB(string checkpt)
    {
        WWWForm form = new WWWForm();
        form.AddField("checkpt", checkpt);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Updaters/updateCheckpoint.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            
        }
    }

   public IEnumerator InsertNewLine(int playerid, int level_id, string checkpoint)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerid", playerid);
        form.AddField("level_id", level_id);
        form.AddField("checkpoint", checkpoint);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Inserters/insertCheckpoint.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }

        }
    }

}
