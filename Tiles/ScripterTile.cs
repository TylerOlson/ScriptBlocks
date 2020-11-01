using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ScriptBlocks.Tiles
{
	public class ScripterTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			dustType = mod.DustType("Sparkle");
			drop = ModContent.ItemType<Items.Placeable.Scripter>();
			AddMapEntry(new Color(200, 200, 200));
		}

		public override void RightClick(int i, int j)
		{
			//Main.PlaySound(SoundID.Item14, Main.LocalPlayer.Center);
			if (ScriptBlocks.scriptUiVisibility)
            {
				ScriptBlocks.instance.HideScriptUI();
            } else
            {
				ScriptBlocks.instance.ShowScriptUI();
            }
		}
	}
}