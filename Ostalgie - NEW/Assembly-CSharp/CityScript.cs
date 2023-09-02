using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class CityScript : MonoBehaviour
{
	// Token: 0x0600003C RID: 60 RVA: 0x0000A26E File Offset: 0x0000846E
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0000A288 File Offset: 0x00008488
	public void Repaint()
	{
		this.text.text = this.global1.regions[this.buildmanager1.now_region].city_level.ToString();
		if (this.global1.regions[this.buildmanager1.now_region].city_level <= 4 && this.global1.data[58] != this.buildmanager1.now_region)
		{
			base.GetComponent<OkoshkoScript>().text = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " из бюджета";
			base.GetComponent<OkoshkoScript>().text_en = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " from the budget";
			return;
		}
		if (this.global1.regions[this.buildmanager1.now_region].city_level < 2 && this.global1.data[58] == this.buildmanager1.now_region)
		{
			base.GetComponent<OkoshkoScript>().text = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " из бюджета";
			base.GetComponent<OkoshkoScript>().text_en = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " from the budget";
			return;
		}
		if (this.global1.data[58] == this.buildmanager1.now_region)
		{
			base.GetComponent<OkoshkoScript>().text = "Здесь есть автономия";
			base.GetComponent<OkoshkoScript>().text_en = "There is autonomy here";
			return;
		}
		base.GetComponent<OkoshkoScript>().text = "Невозможно";
		base.GetComponent<OkoshkoScript>().text_en = "Impossible";
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000A4A8 File Offset: 0x000086A8
	private void OnMouseDown()
	{
		if (this.global1.data[8] >= (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2) * 10 && ((this.global1.regions[this.buildmanager1.now_region].city_level <= 4 && this.global1.data[58] != this.buildmanager1.now_region) || (this.global1.regions[this.buildmanager1.now_region].city_level < 2 && this.global1.data[58] == this.buildmanager1.now_region)))
		{
			this.global1.data[1] += this.global1.regions[this.buildmanager1.now_region].city_level * 5;
			this.global1.data[4] -= this.global1.regions[this.buildmanager1.now_region].city_level * 5;
			this.global1.data[5] += this.global1.regions[this.buildmanager1.now_region].city_level * 5;
			this.global1.data[8] -= (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2) * 10;
			this.global1.regions[this.buildmanager1.now_region].city_level++;
			if (this.global1.regions[this.buildmanager1.now_region].city_level <= 4 && this.global1.data[58] != this.buildmanager1.now_region)
			{
				base.GetComponent<OkoshkoScript>().text = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " из бюджета";
				base.GetComponent<OkoshkoScript>().text_en = "-" + (this.global1.regions[this.buildmanager1.now_region].city_level * 2 + 2).ToString() + " from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].city_level < 2 && this.global1.data[58] == this.buildmanager1.now_region)
			{
				base.GetComponent<OkoshkoScript>().text = "Здесь есть автономия";
				base.GetComponent<OkoshkoScript>().text_en = "There is autonomy here";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text = "Невозможно";
				base.GetComponent<OkoshkoScript>().text_en = "Impossible";
			}
		}
		this.bl1.Repaint();
		this.Repaint();
	}

	// Token: 0x0600003F RID: 63 RVA: 0x0000A7AC File Offset: 0x000089AC
	private void OnMouseEnter()
	{
		if (this.global1.regions[this.buildmanager1.now_region].city_level <= 4)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0000A7DE File Offset: 0x000089DE
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x0400004B RID: 75
	private GlobalScript global1;

	// Token: 0x0400004C RID: 76
	public BuildingManager buildmanager1;

	// Token: 0x0400004D RID: 77
	public TextMesh text;

	// Token: 0x0400004E RID: 78
	public Sprite on;

	// Token: 0x0400004F RID: 79
	public Sprite off;

	// Token: 0x04000050 RID: 80
	public BuildingManager bl1;
}
