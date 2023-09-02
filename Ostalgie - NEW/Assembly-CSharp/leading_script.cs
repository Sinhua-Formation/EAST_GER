using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class leading_script : MonoBehaviour
{
	// Token: 0x060000B6 RID: 182 RVA: 0x0005F7CF File Offset: 0x0005D9CF
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x0005F7E6 File Offset: 0x0005D9E6
	private void Start()
	{
		this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0005F800 File Offset: 0x0005DA00
	private void OnMouseEnter()
	{
		if (this.Cam == null)
		{
			this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
		this.pidor = UnityEngine.Object.Instantiate<GameObject>(this.okno, new Vector3(this.Cam.ScreenToWorldPoint(Input.mousePosition).x, this.Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.6f), new Quaternion(0f, 0f, 0f, 0f));
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = "Constitutional majority: \n";
			if (this.global1.is_konst_max)
			{
				TextMesh component = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component.text += "<color=red>Yes</color>";
			}
			else
			{
				TextMesh component2 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component2.text += "<color=yellow>No</color>";
			}
			TextMesh component3 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component3.text += "\nLeading: ";
			if (this.global1.data[41] == 0)
			{
				TextMesh component4 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component4.text += "Our alliance\n";
			}
			else if (this.global1.data[41] == 1)
			{
				TextMesh component5 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component5.text += "Leftists alliance\n";
			}
			else if (this.global1.data[41] == 2)
			{
				TextMesh component6 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component6.text += "Centrists alliance\n";
			}
			else if (this.global1.data[41] == 3)
			{
				TextMesh component7 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component7.text += "Rightists alliance\n";
			}
			else if (this.global1.data[41] == 4)
			{
				TextMesh component8 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component8.text += "Radicals alliance\n";
			}
			for (int i = 0; i < this.global1.is_party_enabled.Length; i++)
			{
				if (this.global1.is_party_enabled[i])
				{
					if (i == 3)
					{
						TextMesh component9 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
						component9.text += "\n";
					}
					TextMesh component10 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
					component10.text = component10.text + this.global1.party_name[i] + ": ";
					TextMesh component11 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
					component11.text = component11.text + "<color=yellow>" + this.global1.party_number[i].ToString() + "; </color>";
				}
			}
			return;
		}
		this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = "Конституционное большинство: \n";
		if (this.global1.is_konst_max)
		{
			TextMesh component12 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component12.text += "<color=red>Да</color>";
		}
		else
		{
			TextMesh component13 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component13.text += "<color=yellow>Нет</color>";
		}
		TextMesh component14 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
		component14.text += "\nЛидирует: ";
		if (this.global1.data[41] == 0)
		{
			TextMesh component15 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component15.text += "Наш союз\n";
		}
		else if (this.global1.data[41] == 1)
		{
			TextMesh component16 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component16.text += "Союз левых\n";
		}
		else if (this.global1.data[41] == 2)
		{
			TextMesh component17 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component17.text += "Союз центристов\n";
		}
		else if (this.global1.data[41] == 3)
		{
			TextMesh component18 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component18.text += "Союз правых\n";
		}
		else if (this.global1.data[41] == 4)
		{
			TextMesh component19 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
			component19.text += "Союз радикалов\n";
		}
		for (int j = 0; j < this.global1.is_party_enabled.Length; j++)
		{
			if (this.global1.is_party_enabled[j])
			{
				if (j == 3)
				{
					TextMesh component20 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
					component20.text += "\n";
				}
				TextMesh component21 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component21.text = component21.text + this.global1.party_name[j] + ": ";
				TextMesh component22 = this.pidor.transform.Find("Text").GetComponent<TextMesh>();
				component22.text = component22.text + "<color=yellow>" + this.global1.party_number[j].ToString() + "; </color>";
			}
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0005FE90 File Offset: 0x0005E090
	private void OnMouseExit()
	{
		UnityEngine.Object.Destroy(this.pidor);
	}

	// Token: 0x0400014E RID: 334
	private GlobalScript global1;

	// Token: 0x0400014F RID: 335
	private GameObject pidor;

	// Token: 0x04000150 RID: 336
	public GameObject okno;

	// Token: 0x04000151 RID: 337
	public Camera Cam;
}
