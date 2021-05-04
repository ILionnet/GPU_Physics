using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU_Balls : MonoBehaviour
{
    public GameObject ballPrefab;
    private GameObject[] balls;

    public struct Ball
    {
        public Vector3 position;
        public Vector3 velocity;
        public Color color;
    
        public Ball(float posRange, float maxVel)
        {
            position.x = Random.value * posRange - posRange / 2;
            position.y = Random.value * posRange;
            position.z = Random.value * posRange - posRange / 2;
            velocity.x = Random.value * maxVel - maxVel / 2;
            velocity.y = Random.value * maxVel - maxVel / 2;
            velocity.z = Random.value * maxVel - maxVel / 2;
            color.r = Random.value;
            color.g = Random.value;
            color.b = Random.value;
            color.a = 1;
        }
    }


    public int ballsCount;

    Ball[] ballsArray;
    int numOfBalls;

    MaterialPropertyBlock props;

    void Start()
    {
        numOfBalls = ballsCount;
        InitBalls();
    }

    private void InitBalls()
    {
        ballsArray = new Ball[numOfBalls];

        for (int i = 0; i < numOfBalls; i++)
        {
            ballsArray[i] = new Ball(10, 0.01f);
            ballsArray[i].velocity.x *= 0.98f;
            ballsArray[i].velocity.y -= 9.8f;
        }

        balls = new GameObject[ballsArray.Length];

        for (int i = 0; i < ballsArray.Length; i++)
        {
            balls[i] = GameObject.Instantiate(ballPrefab, ballsArray[i].position, Quaternion.identity);
            balls[i].GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

    }
}
