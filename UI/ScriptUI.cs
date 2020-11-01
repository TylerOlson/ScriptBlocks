using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ScriptBlocks.UI
{
	internal class ScriptUI : UIState
	{
		public override void OnInitialize()
		{
			UIPanel panel = new UIPanel(); // 2
			panel.Width.Set(300, 0); // 3
			panel.Height.Set(300, 0); // 3
			Append(panel); // 4

			UIText text = new UIText("Hello world!"); // 1
			panel.Append(text); // 2
		}

	}
}