using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001B RID: 27
public class EventScript : MonoBehaviour
{
	// Token: 0x06000082 RID: 130 RVA: 0x000587A9 File Offset: 0x000569A9
	private void Awake()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.sp = base.GetComponent<SpriteRenderer>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x06000083 RID: 131 RVA: 0x000587E1 File Offset: 0x000569E1
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000587F4 File Offset: 0x000569F4
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00058808 File Offset: 0x00056A08
	public void Reset(int event_number)
	{
		if (this.global1 == null)
		{
			this.Awake();
		}
		this.this_event = event_number;
		this.sp.color = new Color(1f, 1f, 1f, 1f);
		this.time = 40f;
		this.is_down = true;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00058868 File Offset: 0x00056A68
	public void Reset(int event_number, float time_need)
	{
		if (this.global1 == null)
		{
			this.Awake();
		}
		this.this_event = event_number;
		this.sp.color = new Color(1f, 1f, 1f, 1f);
		this.time = time_need;
		this.is_down = true;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000588C4 File Offset: 0x00056AC4
	private void OnMouseDown()
	{
		this.global1.number_event = this.this_event;
		this.global1.is_progorel = false;
		this.global1.speed = 0;
		base.gameObject.SetActive(false);
		this.map1.EventRead();
		SceneManager.LoadScene("Event");
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0005891C File Offset: 0x00056B1C
	private void Update()
	{
		if (this.global1.speed != 0)
		{
			this.time -= Time.deltaTime * (float)this.global1.speed;
			if (this.time <= 0.1f)
			{
				this.global1.number_event = this.this_event;
				this.global1.is_progorel = true;
				this.global1.speed = 0;
				base.gameObject.SetActive(false);
				if (this.global1.number_event == 5)
				{
					if (this.global1.data[0] != 20 && this.global1.data[0] != 10 && this.global1.data[0] != 12)
					{
						this.global1.number_otvet = 2;
					}
					else
					{
						this.global1.number_otvet = 4;
					}
				}
				else if (this.global1.number_event == 6)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 13)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 15)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 14)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 16)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 17)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 19)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 20)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 30)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 9)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 8)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 3)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 12)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 23)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 24)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 25)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 26)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 18)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 33)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 10)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 11)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 7)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 4)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 21)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 22)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 27)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 28)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 29)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 31)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 32)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 59)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 60)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 61)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 35)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 36)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 37)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 51)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 42)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 41)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 55)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 53)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 56)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 38)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 34)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 58)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 45)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 47)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 39)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 50)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 57)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 48)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 40)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 44)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 43)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 54)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 49)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 46)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 87)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 76)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 62)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 65)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 66)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 67)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 68)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 69)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 77)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 80)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 70)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 71)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 72)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 74)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 73)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 78)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 81)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 86)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 63)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 64)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 85)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 82)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 83)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 79)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 89)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 90)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 91)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 107)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 102)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 95)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 99)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 100)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 106)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 103)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 96)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 93)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 94)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 110)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 92)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 97)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 98)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 101)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 105)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 111)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 112)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 113)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 114)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 116)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 117)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 119)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 120)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 123)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 125)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 126)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 118)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 121)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 122)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 108)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 127)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 115)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 128)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 124)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 130)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 131)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 132)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 133)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 134)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 135)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 136)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 137)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 138)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 139)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 140)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 141)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 142)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 143)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 144)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 145)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 146)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 147)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 148)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 149)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 150)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 151)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 152)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 153)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 154)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 155)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 156)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 157)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 158)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 159)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 160)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 161)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 162)
				{
					this.global1.number_otvet = 5;
				}
				else if (this.global1.number_event == 163)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 164)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 165)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 166)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 167)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 168)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 169)
				{
					this.global1.number_otvet = 5;
				}
				else if (this.global1.number_event == 170)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 171)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 172)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 173)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 174)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 175)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 176)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 177)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 178)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 179)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 180)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 181)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 182)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 183)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 184)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 185)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 186)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 187)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 188)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 189)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 190)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 191)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 192)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 193)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 205)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 195)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 196)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 207)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 199)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 194)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 202)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 208)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 210)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 243)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 198)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 204)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 205)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 254)
				{
					this.global1.number_otvet = 5;
				}
				else if (this.global1.number_event == 255)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 197)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 199)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 255)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 203)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 206)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 209)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 242)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 213)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 222)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 211)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 218)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 215)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 221)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 226)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 223)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 224)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 245)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 214)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 220)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 256)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 212)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 214)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 215)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 216)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 217)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 219)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 225)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 244)
				{
					this.global1.number_otvet = 5;
				}
				else if (this.global1.number_event == 257)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 231)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 240)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 235)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 236)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 252)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 250)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 228)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 247)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 239)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 248)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 253)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 234)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 237)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 229)
				{
					this.global1.number_otvet = 4;
				}
				else if (this.global1.number_event == 230)
				{
					this.global1.number_otvet = 2;
				}
				else if (this.global1.number_event == 232)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 233)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 246)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 249)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 251)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 287)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 318)
				{
					this.global1.number_otvet = 5;
				}
				else if (this.global1.number_event == 355)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 285)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 317)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 297)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 316)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 323)
				{
					this.global1.number_otvet = 3;
				}
				else if (this.global1.number_event == 337)
				{
					if (this.global1.data[155] == 0)
					{
						this.global1.number_otvet = 3;
					}
					else if (this.global1.data[155] != 0)
					{
						this.global1.number_otvet = 2;
					}
				}
				else if (this.global1.number_event == 344 && this.global1.data[178] == 0)
				{
					this.global1.number_otvet = 1;
				}
				else if (this.global1.number_event == 402)
				{
					this.global1.number_otvet = 3;
				}
				else
				{
					this.global1.number_otvet = 2;
				}
				this.map1.EventRead();
				this.global1.event_done[this.this_event] = true;
				SceneManager.LoadScene("Results");
			}
		}
		if (this.is_down && this.sp.color.a > 0.1f)
		{
			this.sp.color = new Color(1f, 1f, 1f, this.sp.color.a - 0.01f * (float)this.global1.speed);
			if (this.sp.color.a <= 0.1f)
			{
				this.is_down = false;
				return;
			}
		}
		else if (!this.is_down && this.sp.color.a < 1f)
		{
			this.sp.color = new Color(1f, 1f, 1f, this.sp.color.a + 0.01f * (float)this.global1.speed);
			if (this.sp.color.a >= 1f)
			{
				this.is_down = true;
			}
		}
	}

	// Token: 0x040000C6 RID: 198
	public int this_event = -1;

	// Token: 0x040000C7 RID: 199
	public Sprite off;

	// Token: 0x040000C8 RID: 200
	public Sprite on;

	// Token: 0x040000C9 RID: 201
	private GlobalScript global1;

	// Token: 0x040000CA RID: 202
	private SpriteRenderer sp;

	// Token: 0x040000CB RID: 203
	private bool is_down = true;

	// Token: 0x040000CC RID: 204
	public float time = 10f;

	// Token: 0x040000CD RID: 205
	private MapChangesScript map1;
}
