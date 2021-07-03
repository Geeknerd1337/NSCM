#if UNITY_EDITOR

using System.Threading.Tasks;
using Steamworks;
using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public struct UserStats
	{
		public int Followers;
	}

	public partial class SteamManager
	{
		public static UserStats ClientStats = new UserStats();

		public static void GetStats()
		{
			GetUserFollowerCount();
		}

		private async static void GetUserFollowerCount() => ClientStats.Followers = await SteamFriends.GetFollowerCount(SteamClient.SteamId);
	}
}

#endif