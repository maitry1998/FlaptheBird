﻿using System.Collections;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
	
	public GameObject ColumnPrefab;                                
	public int columnPoolSize = 5;                                
	public float spawnRate = 10f;                                    
	public float columnMin = -1f;                                   
	public float columnMax = 3.5f;  
	private GameObject[] columns;                                   
	private int currentColumn = 0;                                

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);    
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;
	// Use this for initialization
	void Start () {
		
		timeSinceLastSpawned = 0f;


		columns = new GameObject[columnPoolSize];
	
		for(int i = 0; i < columnPoolSize; i++)
		{
			
			columns[i] = (GameObject)Instantiate(ColumnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;


			float spawnYPosition = Random.Range(columnMin, columnMax);


			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);


			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}

	}

}
