using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class MapChangesScript : MonoBehaviour
{
	// Token: 0x060000CE RID: 206 RVA: 0x000624F8 File Offset: 0x000606F8
	public void EventWrite()
	{
		for (int i = 0; i < this.events.Length; i++)
		{
			if (this.events[i] != null && this.global1.Events_active[i])
			{
				this.events[i].SetActive(true);
				this.events[i].GetComponent<EventScript>().Reset(this.global1.Events_number[i], this.global1.Events_time[i]);
				this.global1.Events_active[i] = false;
			}
		}
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00062580 File Offset: 0x00060780
	public void EventRead()
	{
		for (int i = 0; i < this.events.Length; i++)
		{
			if (this.events[i] != null)
			{
				if (this.events[i].activeSelf)
				{
					this.global1.Events_time[i] = this.events[i].GetComponent<EventScript>().time;
					this.global1.Events_number[i] = this.events[i].GetComponent<EventScript>().this_event;
				}
				this.global1.Events_active[i] = this.events[i].activeSelf;
			}
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0006261C File Offset: 0x0006081C
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.flagok.sprite = this.flagoks[this.global1.data[0] - 1];
		this.UpdateMap();
		this.EventWrite();
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0006266C File Offset: 0x0006086C
	public void ShowHideOcno(bool active)
	{
		if (active)
		{
			if (!this.okno.active)
			{
				this.save_speed = this.global1.speed;
			}
			this.global1.speed = 0;
			this.okno.transform.Find("TextIf (0)").GetComponent<TextMesh>().text = null;
			this.okno.transform.Find("TextIf (1)").GetComponent<TextMesh>().text = null;
			this.okno.transform.Find("TextIf (2)").GetComponent<TextMesh>().text = null;
			this.okno.transform.Find("TextIf (3)").GetComponent<TextMesh>().text = null;
			this.okno.transform.Find("TextIf (0)").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			this.okno.transform.Find("TextIf (1)").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			this.okno.transform.Find("TextIf (2)").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			this.okno.transform.Find("TextIf (3)").transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			this.okno.transform.Find("Text (1)").GetComponent<TextMesh>().text = null;
		}
		else
		{
			this.global1.speed = this.save_speed;
		}
		for (int i = 0; i < 4; i++)
		{
			this.speed[i].GetComponent<SpeedScript>().Repaint();
		}
		this.okno.SetActive(active);
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00062844 File Offset: 0x00060A44
	public void UpdateMap()
	{
		if (this.global1.allcountries[7].Vyshi)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.global1.allcountries[7].name = "Former Union";
			}
			else
			{
				this.global1.allcountries[7].name = "Бывший Союз";
			}
		}
		if (this.global1.allcountries[1].Vyshi && this.global1.allcountries[1].Gosstroy == 2 && this.global1.data[0] != 1)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.global1.allcountries[1].name = "FRG";
			}
			else
			{
				this.global1.allcountries[1].name = "ФРГ";
			}
		}
		for (int i = 0; i < this.cont.Length; i++)
		{
			if (this.cont[i] != null)
			{
				this.cont[i].Repaint();
			}
		}
	}

	// Token: 0x04000164 RID: 356
	private int save_speed;

	// Token: 0x04000165 RID: 357
	public GameObject[] speed = new GameObject[4];

	// Token: 0x04000166 RID: 358
	public GameObject[] buttons = new GameObject[4];

	// Token: 0x04000167 RID: 359
	public GameObject[] event_icons = new GameObject[27];

	// Token: 0x04000168 RID: 360
	public Sprite[] znachki = new Sprite[10];

	// Token: 0x04000169 RID: 361
	public Sprite[] subIdZ = new Sprite[16];

	// Token: 0x0400016A RID: 362
	public GameObject okno;

	// Token: 0x0400016B RID: 363
	public SpriteRenderer flagok;

	// Token: 0x0400016C RID: 364
	public Sprite[] flagoks = new Sprite[6];

	// Token: 0x0400016D RID: 365
	private GlobalScript global1;

	// Token: 0x0400016E RID: 366
	public CountryScript[] cont = new CountryScript[56];

	// Token: 0x0400016F RID: 367
	public GameObject[] events = new GameObject[27];
}
