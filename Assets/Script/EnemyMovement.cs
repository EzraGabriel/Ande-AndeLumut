using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints1;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;
    private int tanda = 0;
    private int waypointIndexTemp;
    //private int muter = 0;

    // Update is called once per frame
    void Update()
    {
        if (tanda == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (gameObject.transform.position == waypoints1[waypointIndex].transform.position)
            {
                if (waypointIndex != waypoints1.Length - 1)
                {
                    waypointIndex++;
                    ubahArah(waypointIndex - 1, waypointIndex);
                }
                else
                {
                    tanda = 1;
                    waypointIndex--;
                    ubahArah(waypointIndex + 1, waypointIndex);
                }
            }
        }
        else if(tanda == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints1[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (gameObject.transform.position == waypoints1[waypointIndex].transform.position)
            {
                if (waypointIndex != 0)
                {
                    waypointIndex--;
                    ubahArah(waypointIndex + 1, waypointIndex);
                }
                else
                {
                    tanda = 0;
                    waypointIndex++;
                    ubahArah(waypointIndex - 1, waypointIndex);
                }
            }
        }
    }

    private void ubahArah(int index1, int index2)
    {
        if (waypoints1[index1].transform.position.y > waypoints1[index2].transform.position.y)
        {
            Debug.Log("jalan1");
            transform.eulerAngles = new Vector3(0, 0, 180);
            return;
        }
        else if(waypoints1[index1].transform.position.y < waypoints1[index2].transform.position.y)
        {
            Debug.Log("jalan2");
            transform.eulerAngles = new Vector3(0, 0, 0);
            return;
        }
        else if (waypoints1[index1].transform.position.x > waypoints1[index2].transform.position.x)
        {
            Debug.Log("jalan3");
            transform.eulerAngles = new Vector3(0, 0, 90);
            return;
        }
        else if (waypoints1[index1].transform.position.x < waypoints1[index2].transform.position.x)
        {
            Debug.Log("jalan4");
            transform.eulerAngles = new Vector3(0, 0, -90);
            return;
        }
    }
}
