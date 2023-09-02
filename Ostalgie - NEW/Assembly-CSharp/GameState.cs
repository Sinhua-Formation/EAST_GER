using System;

// Token: 0x02000054 RID: 84
[Serializable]
public class GameState
{
	// Token: 0x0400026D RID: 621
	public YugoCountry[] yugcountries = new YugoCountry[12];

	// Token: 0x0400026E RID: 622
	public YugoRegion[] yugregions = new YugoRegion[12];

	// Token: 0x0400026F RID: 623
	public int[] modifies = new int[24];

	// Token: 0x04000270 RID: 624
	public int[] modifies_time = new int[24];

	// Token: 0x04000271 RID: 625
	public int regionUnderAttack = -1;

	// Token: 0x04000272 RID: 626
	public int who_attack = -1;

	// Token: 0x04000273 RID: 627
	public int[] regionsAttacked = new int[]
	{
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x04000274 RID: 628
	public int[] whoAttacked = new int[]
	{
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x04000275 RID: 629
	public int player;

	// Token: 0x04000276 RID: 630
	public bool battle_royal;

	// Token: 0x04000277 RID: 631
	public bool has_ally;

	// Token: 0x04000278 RID: 632
	public bool done;
}
