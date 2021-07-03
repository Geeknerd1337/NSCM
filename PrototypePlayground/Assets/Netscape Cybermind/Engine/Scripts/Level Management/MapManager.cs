using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armadillo.Netscape
{
    public class MapManager
    {
        public static async void LoadMap(string mapPath)
        {
            var map = await Map.GetMap(mapPath);

            if (map.HasValue)
                LoadMap(map.Value);
        }

        public static void LoadMap(Map map)
        {

        }
    }

}
