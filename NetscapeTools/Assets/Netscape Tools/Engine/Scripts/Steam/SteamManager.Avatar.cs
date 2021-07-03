#if UNITY_EDITOR

using System.Threading.Tasks;
using Steamworks;
using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class SteamManager
	{
		public static Texture Avatar { get; private set; }

		public static async void GetAvatar()
		{
			var result = await GetAvatarAsync();

			if (!result.HasValue) { return; }

			var avatar = new Texture2D((int)result.Value.Width, (int)result.Value.Height, TextureFormat.ARGB32, false);
			avatar.filterMode = FilterMode.Trilinear;

			// Flip image
			for (int x = 0; x < result.Value.Width; x++)
			{
				for (int y = 0; y < result.Value.Height; y++)
				{
					var p = result.Value.GetPixel(x, y);
					avatar.SetPixel(x, (int)result.Value.Height - y, new UnityEngine.Color(p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f));
				}
			}

			avatar.Apply();
			Avatar = avatar;
		}

		private static async Task<Steamworks.Data.Image?> GetAvatarAsync() => await SteamFriends.GetLargeAvatarAsync(SteamClient.SteamId);
	}
}

#endif