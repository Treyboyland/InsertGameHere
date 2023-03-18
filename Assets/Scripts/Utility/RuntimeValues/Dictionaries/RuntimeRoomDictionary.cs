using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeRoomDictionary", menuName = "RuntimeValues/Room Dictionary")]
public class RuntimeRoomDictionary : RuntimeDictionary<Vector2Int, Room>
{
    public Room GetRoomAtLocation(Vector2Int location)
    {
        if (!_dict.ContainsKey(location))
        {
            return null;
        }
        return _dict[location];
    }
}
