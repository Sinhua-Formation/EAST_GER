using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class BuildingManager : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x000028B2 File Offset: 0x00000AB2
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000028C9 File Offset: 0x00000AC9
	private void Start()
	{
		this.Repaint();
		this.HideSelects();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000028D8 File Offset: 0x00000AD8
	public void Repaint()
	{
		for (int i = 0; i < this.buildings.Length; i++)
		{
			this.buildings[i].Repaint();
		}
		this.city.Repaint();
		for (int j = 0; j < this.region_buttons.Length; j++)
		{
			this.region_buttons[j].Repaint();
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002930 File Offset: 0x00000B30
	public void ShowSelects()
	{
		for (int i = 0; i < this.selects.Length; i++)
		{
			if ((this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18) && ((!this.global1.science[3] && i == 1) || (!this.global1.science[5] && (i == 2 || i == 7)) || (!this.global1.science[6] && i == 0)))
			{
				this.selects[i].transform.gameObject.SetActive(false);
			}
			else if (this.global1.data[14] > 3 && i == 17)
			{
				this.selects[i].transform.gameObject.SetActive(false);
			}
			else
			{
				this.selects[i].transform.gameObject.SetActive(true);
				this.selects[i].Repaint();
			}
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002A34 File Offset: 0x00000C34
	public void HideSelects()
	{
		for (int i = 0; i < this.selects.Length; i++)
		{
			this.selects[i].transform.gameObject.SetActive(false);
		}
	}

	// Token: 0x04000010 RID: 16
	public Sprite[] resprite_on;

	// Token: 0x04000011 RID: 17
	public Sprite[] respriteoff;

	// Token: 0x04000012 RID: 18
	public string[] types_names_ru;

	// Token: 0x04000013 RID: 19
	public string[] types_names_en;

	// Token: 0x04000014 RID: 20
	public string[] usloviya_ru = new string[18];

	// Token: 0x04000015 RID: 21
	public string[] usloviya_en = new string[18];

	// Token: 0x04000016 RID: 22
	public CityScript city;

	// Token: 0x04000017 RID: 23
	public int selected_thing = -1;

	// Token: 0x04000018 RID: 24
	public BuildSelectScript[] selects;

	// Token: 0x04000019 RID: 25
	public Sprite[] sprites = new Sprite[18];

	// Token: 0x0400001A RID: 26
	public BuildingScript[] buildings;

	// Token: 0x0400001B RID: 27
	public int now_region = 2;

	// Token: 0x0400001C RID: 28
	private GlobalScript global1;

	// Token: 0x0400001D RID: 29
	public Sprite empty_build;

	// Token: 0x0400001E RID: 30
	public int[] yugreg = new int[3];

	// Token: 0x0400001F RID: 31
	public bool[] yugown = new bool[3];

	// Token: 0x04000020 RID: 32
	public RegionChangeScript[] region_buttons = new RegionChangeScript[5];
}
