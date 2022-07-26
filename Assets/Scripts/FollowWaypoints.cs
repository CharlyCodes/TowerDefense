using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField]private string _pathName;
    [SerializeField] private List<Vector3> _waypointsPositions = new List<Vector3>();
    [SerializeField] private float _distanceThreshold = 0.3f;
    [SerializeField] private float _walkSpeed = 5;
    private int _currentWaypoint;
    private void Start() {
        StartCoroutine(MoveToNextWaypoint());
    }
    void GetWaypoints(){
        Transform path = GameObject.Find(_pathName).transform;
        for (int i = 0; i < path.childCount; i++)
        {
            _waypointsPositions.Add(path.GetChild(i).position);
        }
    }
    IEnumerator MoveToNextWaypoint(){
        if(_waypointsPositions.Count == 0){
            GetWaypoints();
        }
        float distance = Vector3.Distance(transform.position, _waypointsPositions[_currentWaypoint]);
        while (distance > _distanceThreshold){
            transform.position = Vector3.MoveTowards(transform.position, _waypointsPositions[_currentWaypoint], Time.deltaTime * _walkSpeed);
            distance = Vector3.Distance(transform.position, _waypointsPositions[_currentWaypoint]);
            yield return null;
        }
        if (_currentWaypoint < _waypointsPositions.Count -1){
            _currentWaypoint++;
            StartCoroutine(MoveToNextWaypoint());
        }        
    }
}
