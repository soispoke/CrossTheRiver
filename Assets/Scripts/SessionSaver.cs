//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;

//[System.Serializable]
//public class MySessionData
//{
//    private List<SessionTrialStones> trials = new List<SessionTrialStones>();
//    public List<int> map_order = new List<int>();

//    public string session_id;
//    public int CountTrials()
//    {
//        return this.trials.Count;
//    }

//    public void AddTrial(SessionTrialStones trialstone)
//    {
//        this.trials.Add(trialstone);
//    }
//}

//public class SessionSaver : MonoBehaviour
//{
//    public const string OUTDIR = "./Assets/ExperimentData/";

//    public MySessionData data = new MySessionData();

//    public void AddTrial(SessionTrialStones trialstone)
//    {
//        if (data.CountTrials() >= trialstone.trial_id_stones)
//        {
//            Debug.Log("Already saved?");
//        }
//        else
//        {
//            data.AddTrial(trialstone);
//        }
//    }

//    public int CountTrials()
//    {
//        return data.CountTrials();
//    }

//    public string outfile()
//    {
//        return OUTDIR + "session_" + this.data.session_id + "_meta.json";
//    }


//    public void SaveToFile()
//    {
//        string json = JsonUtility.ToJson(this.data);
//        string path = this.outfile();
//        StreamWriter sw = File.CreateText(path);
//        sw.Close();
//        File.WriteAllText(path, json);
//    }
//}