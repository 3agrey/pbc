using System;

namespace Aim.Web.Controls.Panels
{
	internal sealed class PanelFactory
	{
		public static PanelBase CreateRenderer(Panel panel)
		{
			if (panel == null) throw new ArgumentNullException("panel");

			switch (panel.Mode)
			{
				case PanelMode.Window:
					return new PanelWindow(panel);
				case PanelMode.Blue:
					return new PanelBlue(panel);
				case PanelMode.Grey:
					return new PanelGrey(panel);
				default:
					throw new NotSupportedException("PanelMode is not supported");
			}
		}
	}
}