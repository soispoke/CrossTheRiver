//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;

//public class AvatarAgent : Agent
//{
//    CharacterController player;
//    void Start()
//    {
//        player = GetComponent<CharacterController>();
//    }

//    public Transform Target;
//    public override void OnEpisodeBegin()
//    {
//    }


//    public override void CollectObservations(VectorSensor sensor)
//    {
//        // Target and Agent positions
 
//        sensor.AddObservation(this.transform.localPosition.x);
//        sensor.AddObservation(this.transform.localPosition.y);
//        sensor.AddObservation(this.transform.localPosition.z);
//        sensor.AddObservation(this.transform.transform.localRotation.y);
//    }



//    public override void OnActionReceived(ActionBuffers actionBuffers)
//    {
//        // The dictionary with all the body parts in it are in the jdController
//        var bpDict = m_JdController.bodyPartsDict;

//        var i = -1;
//        var continuousActions = actionBuffers.ContinuousActions;
//        // Pick a new target joint rotation
//        bpDict[bodySegment0].SetJointTargetRotation(continuousActions[++i], continuousActions[++i], 0);
//        bpDict[bodySegment1].SetJointTargetRotation(continuousActions[++i], continuousActions[++i], 0);
//        bpDict[bodySegment2].SetJointTargetRotation(continuousActions[++i], continuousActions[++i], 0);

//        // Update joint strength
//        bpDict[bodySegment0].SetJointStrength(continuousActions[++i]);
//        bpDict[bodySegment1].SetJointStrength(continuousActions[++i]);
//        bpDict[bodySegment2].SetJointStrength(continuousActions[++i]);

//        //Reset if Worm fell through floor;
//        if (bodySegment0.position.y < m_StartingPos.y - 2)
//        {
//            EndEpisode();
//        }
//    }


//    public override void OnActionReceived(float[] vectorAction)
//    {
//        // Actions, size = 2
//        Vector3 controlSignal = Vector3.zero;
//        controlSignal.x = vectorAction[0];
//        controlSignal.z = vectorAction[1];
//        rBody.AddForce(controlSignal * forceMultiplier);

//        // Rewards
//        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);


//        // Reached target
//        if (transform.localPosition.x > 110 && transform.localPosition.x < 115 && transform.localPosition.z > 241 && transform.localPosition.z < 244)
//        {
//            SetReward(1.0f);
//            EndEpisode();
//        }

//        // Fell off platform
//        if (this.transform.localPosition.y < 0)
//        {
//            SetReward(-1.0f);
//            EndEpisode();
//        }
//    }
//}

