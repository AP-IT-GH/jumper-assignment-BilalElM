using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AgentMovement : Agent
{
    public Transform coin;
    public Transform obstacle;

    public override void OnEpisodeBegin()
    {
        this.transform.localPosition = new Vector3(-1.67f, 0.435f, -3.912f);
        this.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate 90 degrees around the y-axis


    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(coin.localPosition);
        sensor.AddObservation(obstacle.localPosition);

    }

    public float jumpSpeed = 1.1f;
    public float maxJumpHeight = 2f;

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Acties
        Vector3 controlSignal = Vector3.zero;

        float jumpHeight = actions.ContinuousActions[0] * maxJumpHeight;
        if (jumpHeight > 0 && transform.position.y >= maxJumpHeight)
        {
            jumpHeight = 0;
        }

        controlSignal.y = jumpHeight;

        this.transform.Translate(controlSignal * jumpSpeed);

        // Beloningen
        AddReward(0.001f);

        if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;

       continuousActionsOut[0] = Input.GetAxis("Vertical");
    }

    void OnCollisionEnter(Collision collision)
    {
        
        
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                AddReward(-1f);

                // Destroy all obstacles
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    Destroy(obstacle);
                }

                EndEpisode();
                print(GetCumulativeReward());
            }

        if (collision.gameObject.CompareTag("Coin"))
        {
            AddReward(1f);

            // Destroy all obstacles
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }

            EndEpisode();
            print(GetCumulativeReward());
        }
    }

}