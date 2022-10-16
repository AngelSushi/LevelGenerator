using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D level;

    public List<Color> blocksColor = new List<Color>();
    public List<GameObject> blocksToSpawn = new List<GameObject>();

    public Transform ldParent;
}
