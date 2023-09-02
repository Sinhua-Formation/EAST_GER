using System;

// Token: 0x02000053 RID: 83
[Serializable]
public class YugoCountry
{
	// Token: 0x0400025D RID: 605
	public string name;

	// Token: 0x0400025E RID: 606
	public bool is_exist;

	// Token: 0x0400025F RID: 607
	public bool is_player;

	// Token: 0x04000260 RID: 608
	public int army;

	// Token: 0x04000261 RID: 609
	public int money;

	// Token: 0x04000262 RID: 610
	public int[] build = new int[9];

	// Token: 0x04000263 RID: 611
	public bool[] peace_with = new bool[12];

	// Token: 0x04000264 RID: 612
	public bool is_independent;

	// Token: 0x04000265 RID: 613
	public int Gosstroy = -1;

	// Token: 0x04000266 RID: 614
	public bool last;

	// Token: 0x04000267 RID: 615
	public int have_regions;

	// Token: 0x04000268 RID: 616
	public bool temp_peace;

	// Token: 0x04000269 RID: 617
	public int temp_peace_time;

	// Token: 0x0400026A RID: 618
	public int temp_peace_count;

	// Token: 0x0400026B RID: 619
	public bool is_ally;

	// Token: 0x0400026C RID: 620
	public bool traded;
}
