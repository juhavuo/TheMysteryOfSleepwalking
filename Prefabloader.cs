using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabloader {

	private List<MapObject> levelmap;
	private int xBegin, yBegin;
	private char[] acceptedCodes;

	public Prefabloader(){
		this.acceptedCodes = new char[]{'B','G','P','R'};
	}

	public void LoadLevel(string mapfile){

		GameObject grassprefab = (GameObject)Resources.Load ("Prefabs/GrassPrefab");
		Transform grasstransform = grassprefab.GetComponent<Transform> ();
		GameObject pathprefab = (GameObject)Resources.Load ("Prefabs/PathPrefab");
		Transform pathtransform = pathprefab.GetComponent<Transform> ();
		GameObject brickprefab = (GameObject)Resources.Load ("Prefabs/BrickwallPrefab");
		Transform bricktransform = brickprefab.GetComponent<Transform> ();
		GameObject bushprefab = (GameObject)Resources.Load ("Prefabs/BushPrefab");
		Transform bushtransform = bushprefab.GetComponent<Transform> ();
		this.levelmap = new List<MapObject> ();

		TextAsset leveltext = Resources.Load (mapfile) as TextAsset;
		string text = leveltext.text;
		string[] textInLines = text.Split ('\n');

		Vector3 vector;
		int w = textInLines.Length * textInLines [0].Length;
		Debug.Log (w);
		char code;
		for (int i = 0; i < textInLines.Length; i++) {
			string line = textInLines [i];
			char[] lineInChar= line.ToCharArray();
			Debug.Log (line);
			for (int j = 0;j<lineInChar.Length ; ++j) {
				code = line [j];
				if (this.AcceptCode (code)) {
					
					vector = new Vector3 (this.xBegin + 2 * j, this.yBegin + -2 * i, 0);
					switch (code) {
					case 'B':
						this.levelmap.Add(new MapObject(bushtransform,vector));
						break;
					case'G':
						this.levelmap.Add(new MapObject(grasstransform,vector));
						break;
					case 'P':
						this.levelmap.Add(new MapObject(pathtransform,vector));
						break;
					case 'R':
						this.levelmap.Add(new MapObject(bricktransform,vector));
						break;
					default:
						this.levelmap.Add(new MapObject(grasstransform,vector));
						break;
					}
				}
			
			}
		}


	}

	public void defineUpperLeftCorner(int x, int y){
		this.xBegin = x;
		this.yBegin = y;
	}

	public List<MapObject> getLevelMap(){
		return this.levelmap;
	}

	private bool AcceptCode(char code){
		for (int i = 0; i < this.acceptedCodes.Length; i++) {
			if (code == this.acceptedCodes [i]) {
				return true;
			}
		}

		return false;
	}
		
}