using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "FoodTileData", menuName = "Custom/Food Tile Data")]
public class FoodTileData : ScriptableObject
{
    public string levelName;
    public List<TileBase> correctTiles;
    public List<TileBase> incorrectTiles;
}
