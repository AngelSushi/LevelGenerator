using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGeneratorEditor : Editor {

    private LevelGenerator instance;

    
    private void OnEnable()
    {
        instance = (LevelGenerator)target;
    }

    public override void OnInspectorGUI() {
        this.DrawDefaultInspector();

        if (GUILayout.Button("Generate Level")) {

            for (int i = 0; i < instance.level.height; i++) {
                for (int j = 0; j < instance.level.width; j++) {
                    int value = instance.level.width * i + j;

                    Color targetColor = instance.level.GetPixel(j, i);

                    if (instance.blocksColor.Contains(targetColor)) {
                        int colorIndex = instance.blocksColor.IndexOf(targetColor);

                        if (instance.blocksToSpawn.Count > colorIndex) {
                            GameObject blockToInstantiate = instance.blocksToSpawn[colorIndex];
                            
                            
                            Vector3 blockPosition = Vector3.zero;
                            blockPosition.x = blockToInstantiate.transform.localScale.x * j;
                            blockPosition.y = blockToInstantiate.transform.localScale.y * i;
                            
                            GameObject newBlock = Instantiate(blockToInstantiate,blockPosition,Quaternion.identity);
                            newBlock.transform.parent = instance.ldParent;
                        }

                    }
                }
            }

            
        }
    }
}
