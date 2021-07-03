#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

using UnityEditor.IMGUI.Controls;

namespace Armadillo.Netscape
{
	public class WorkshopItemsList : AdvancedDropdown
	{
		public WorkshopItemsList(AdvancedDropdownState state) : base(state)
		{
			this.minimumSize = new Vector2(0, 200);
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			base.ItemSelected(item);
			if (!item.enabled) { return; }

			if (item.id != -1)
			{
				WorkshopItems.CurrentItem = WorkshopItems.ClientItems[item.id];
				WorkshopItems.UploadNewItem = false;
				ToolsWindow.cachedName = WorkshopItems.CurrentItem.Title;
				ToolsWindow.cachedDesc = WorkshopItems.CurrentItem.Description;
				WorkshopItems.GetCurrentItemThumbnail();
			}
			else
			{
				ToolsWindow.cachedName = string.Empty;
				ToolsWindow.cachedDesc = string.Empty;
				// ToolsWindow.cachedThumbnail = IconCache.NoThumbnail;
				WorkshopItems.UploadNewItem = true;
			}
		}

		protected override AdvancedDropdownItem BuildRoot()
		{
			var root = new AdvancedDropdownItem($"{Steamworks.SteamClient.Name} Workshop Items");

			root.AddChild(new AdvancedDropdownItem("New Workshop Item") { id = -1, icon = (Texture2D)EditorGUIUtility.IconContent("d_CreateAddNew").image });
			root.AddSeparator();

			foreach (var item in WorkshopItems.ClientItems)
			{
				root.AddChild(new AdvancedDropdownItem(item.Value.Title) { id = item.Key });
			}

			return root;
		}
	}
}

#endif
