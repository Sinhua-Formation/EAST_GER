using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class at_war_script : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x0000256C File Offset: 0x0000076C
	public void Repaint()
	{
		if (this.global1 == null)
		{
			this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		}
		if (this.this_num == 15 && this.global1.event_done[48])
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 19 && this.global1.allcountries[19].Stasi)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 14 && this.global1.event_done[53] && !this.global1.event_done[81])
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 23)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 12 && this.global1.data[0] != 12)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 12 && this.global1.data[0] == 12 && this.global1.data[88] > 0)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 40 && this.global1.allcountries[40].Westalgie <= 800 && this.global1.allcountries[40].Westalgie > 0)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 41 && this.global1.allcountries[40].Westalgie > 0 && this.global1.allcountries[41].Westalgie <= 950)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 42 && this.global1.allcountries[42].Westalgie > 0 && this.global1.allcountries[42].Westalgie <= 950)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (this.this_num == 43 && this.global1.allcountries[43].Westalgie >= 200 && this.global1.allcountries[43].Westalgie <= 950)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.war;
			return;
		}
		if (base.GetComponent<SpriteRenderer>().sprite != null)
		{
			base.GetComponent<SpriteRenderer>().sprite = null;
		}
	}

	// Token: 0x04000009 RID: 9
	private GlobalScript global1;

	// Token: 0x0400000A RID: 10
	public Sprite war;

	// Token: 0x0400000B RID: 11
	public int this_num;
}
