using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Armadillo.Netscape
{
    public struct Map
    {
        public string Name;
        public string Description;
        public ulong ID; // Will be used for Steam Workshop integration

        public string MapPath;
        public AssetBundle MapBundle;
        public Scene MapScene;

        public static async Task<Map?> GetMap(string mapPath)
        {
            var bundle = AssetBundle.LoadFromFileAsync(mapPath);

            // Probably display some loading shit here, or make a load manager

            while (!bundle.isDone)
                await Task.Yield();

            return new Map()
            {
                Name = "",
                Description = "",
                ID = 0,

                MapPath = mapPath,
                MapBundle = bundle.assetBundle,
                MapScene = SceneManager.GetSceneByPath(bundle.assetBundle.GetAllScenePaths()[0])
            };
        }
    }
}