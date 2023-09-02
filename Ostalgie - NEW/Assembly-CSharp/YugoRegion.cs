using System;

// Token: 0x02000052 RID: 82
[Serializable]
public class YugoRegion
{
	// Token: 0x04000255 RID: 597
	public string name;

	// Token: 0x04000256 RID: 598
	public int owner = -1;

	// Token: 0x04000257 RID: 599
	public int population = -1;

	// Token: 0x04000258 RID: 600
	public int control = 100;

	// Token: 0x04000259 RID: 601
	public int inreg = -1;

	// Token: 0x0400025A RID: 602
	public int level = -1;

	// Token: 0x0400025B RID: 603
	public int defence = -1;

	// Token: 0x0400025C RID: 604
	public int[] borders;
}
