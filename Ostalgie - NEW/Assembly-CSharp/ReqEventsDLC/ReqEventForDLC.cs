using System;

namespace ReqEventsDLC
{
	// Token: 0x0200005C RID: 92
	public class ReqEventForDLC
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x0018CC45 File Offset: 0x0018AE45
		public static bool RequrementsDLC04(ref int this_num_event, ref int this_num_place, ref GlobalScript global1)
		{
			if (global1.allcountries[0].isOVD)
			{
				this_num_event = 300;
				this_num_place = 0;
				return true;
			}
			if (global1.allcountries[0].isOVD)
			{
				this_num_event = 301;
				this_num_place = 1;
				return true;
			}
			return false;
		}
	}
}
