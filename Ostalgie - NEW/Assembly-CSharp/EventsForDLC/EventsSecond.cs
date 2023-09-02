using System;
using UnityEngine;

namespace EventsForDLC
{
	// Token: 0x0200005D RID: 93
	public abstract class EventsSecond : MonoBehaviour
	{
		// Token: 0x060001CA RID: 458
		public abstract void TextOfEvents(ref string name, ref string text, ref GlobalScript global1);

		// Token: 0x060001CB RID: 459
		public abstract void VariantsOfEvents(ref int kolvo_variant, ref string[] fake_text, ref GameObject[] button, ref GlobalScript global1);

		// Token: 0x060001CC RID: 460
		public abstract void ResultsOfEvents(ref string name, ref string text, int result_num, ref GlobalScript global1);
	}
}
