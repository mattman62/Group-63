﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

	public GameObject mapArea;
	public GameObject rooms, start, end, blank, currentRoom;
	GridLayoutGroup grid;
	private int[,] map = ProceduralGeneration.mapLayout;
	static int[] bosslocation = new int[2];
	static GameObject[,] minimap;
	static int[] currentlocation;
	int rows;
	int cols;


	void Start (){
		rows = map.GetLength (0);
		cols = map.GetLength (1);
		minimap = new GameObject[rows, cols];
		grid = mapArea.GetComponent<GridLayoutGroup> ();
		grid.cellSize = new Vector2 (150 / rows, 150 / cols);
		drawMinimap ();
		currentlocation = Doors.location;
		minimap [currentlocation [0], currentlocation [1]].GetComponent<Image> ().color = new Color (234, 210, 0, 139);
	}

	void drawMinimap(){
		for (int r = 0; r < rows; r++) {
			for (int c = 0; c < cols; c++) {
				if (map [r, c] < 0)
					minimap [r, c] = Instantiate (blank, mapArea.transform);
				else {
					minimap [r, c] = Instantiate (rooms, mapArea.transform);
					if (map [r, c] == 1){
						minimap [r, c].GetComponent<Image>().color = new Color(255,0,0, 139);
						bosslocation [0] = r;
						bosslocation [1] = c;
					}
				}
			}
		}
	}
	public static void setGrey(){
		if (currentlocation[0] == bosslocation[0] && currentlocation[1] == bosslocation[1])
			minimap [currentlocation [0], currentlocation [1]].GetComponent<Image> ().color = new Color (255, 0, 0, 139);
		else
			minimap [currentlocation [0], currentlocation [1]].GetComponent<Image> ().color = new Color (0, 0, 150, 139);
	}

	public static void setGold(){
		minimap [currentlocation [0], currentlocation [1]].GetComponent<Image> ().color = new Color (234, 210, 0, 139);
	}
}
