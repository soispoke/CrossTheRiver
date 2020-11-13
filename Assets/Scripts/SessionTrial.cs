using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class CollisionRecord
{
    public float x;
    public float y;
    public float z;
    public float ts;

    public CollisionRecord(float x, float y, float z, float ts)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.ts = ts;
    }
}

[System.Serializable]
public class SessionTrial
{
    public int trial_id;
    public string SessionId;

    public List<CollisionRecord> collisions;

    public SessionTrial(int trial_id, string SessionId)
    {
        this.trial_id = trial_id;
        this.SessionId = SessionId;
        this.collisions = new List<CollisionRecord>();
    }

    public CollisionRecord ColRecord(float x, float y, float z, float ts)
    {
        CollisionRecord c = new CollisionRecord(x, y, z, ts);
        this.collisions.Add(c);
        return c;
    }

    public string getUniqueTrialKey()
    {
        return string.Format("p:{0}_d:{1}_t:{2}", PlayerPrefs.GetString("PlayerName"), this.SessionId, this.trial_id);
    }

    public void Save()
    {
        this.SaveToFirebase(); // Cloud
    }

    public void SaveToFirebase()
    {
        string trial_id = this.getUniqueTrialKey();
        Debug.Log(trial_id);
        FirebaseDBHandler.SaveTrial(this, trial_id, () => {
            Debug.Log("Saved " + trial_id + " to firestore");
        });
    }
}
