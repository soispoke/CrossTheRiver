using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Proyecto26;

public static class FirebaseDBHandler
{
    private const string projectId = "cross-the-river";
    private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";

    public delegate void PostTrialCallback();
    public delegate void GetTrialCallback(SessionTrial trial);


    public static void SaveTrial(SessionTrial trial, string trialId, PostTrialCallback callback)
    {
        Debug.Log("Posting trial...");
        RestClient.Put<SessionTrial>($"{databaseURL}trials/{trialId}.json", trial)
            .Then(response => { callback(); }).Catch(Debug.LogException);
    }

    public static void GetTrial(string trialId, GetTrialCallback callback)
    {
        RestClient.Get<SessionTrial>($"{databaseURL}trials/{trialId}.json").Then(trial => { callback(trial); });
    }
}