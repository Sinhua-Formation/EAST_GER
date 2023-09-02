using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class VersioNScript : MonoBehaviour
{
	// Token: 0x06000173 RID: 371 RVA: 0x00185A6D File Offset: 0x00183C6D
	private void Awake()
	{
		if (this.active)
		{
			this.Vivod();
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00185A7D File Offset: 0x00183C7D
	private void OnMouseEnter()
	{
		if (this.active)
		{
			base.GetComponent<TextMesh>().color = Color.green;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.navel;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00185AA9 File Offset: 0x00183CA9
	private void OnMouseExit()
	{
		if (this.active)
		{
			base.GetComponent<TextMesh>().color = Color.red;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.nenavel;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00185AD5 File Offset: 0x00183CD5
	private void OnMouseDown()
	{
		if (!this.planshet.activeSelf)
		{
			this.planshet.SetActive(true);
			this.TextAfter();
			return;
		}
		this.planshet.SetActive(false);
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00185B04 File Offset: 0x00183D04
	private void TextAfter()
	{
		string text;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			text = "YUGOSLAVIA IS RELEASED|DLC \"Disorder in Yugoslavia\" is released, you can buy it here now:|https://store.steampowered.com/app/1886380/Ostalgie/";
		}
		else
		{
			text = "ЮГОСЛАВИЯ ДОСТУПНА|Дополнение \"Раздор в Югославии\" было выпущено, вы можете купить его уже сейчас:|https://store.steampowered.com/app/1886380/Ostalgie/|<color=red>О том как покупать игры из России вы можете узнать в нашем телеграмм канале или дискорд сервере или группе Вконтакте!</color>";
		}
		this.text.text = this.Text(text, 54);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00185B48 File Offset: 0x00183D48
	private void Vivod()
	{
		if (!PlayerPrefs.HasKey("versionlast") || PlayerPrefs.GetInt("versionlast") != this.versionlast)
		{
			PlayerPrefs.SetInt("versionlast", this.versionlast);
			this.planshet.SetActive(true);
			this.TextAfter();
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00185B98 File Offset: 0x00183D98
	private string Text(string text, int col)
	{
		int num = 0;
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
			}
			else if (num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
				}
				else
				{
					text2 += text[i].ToString();
					for (int j = i; j >= 0; j--)
					{
						if (text2[j] == char.Parse(" "))
						{
							text2 = text2.Substring(0, j) + "\n" + text2.Substring(j + 1, text2.Length - 1 - (j + 1) + 1);
							num = text2.Length - 1 - (j + 1) + 1;
							break;
						}
					}
				}
			}
			else
			{
				text2 += text[i].ToString();
				num++;
			}
		}
		return text2;
	}

	// Token: 0x04000240 RID: 576
	public TextMesh text;

	// Token: 0x04000241 RID: 577
	public Sprite navel;

	// Token: 0x04000242 RID: 578
	public Sprite nenavel;

	// Token: 0x04000243 RID: 579
	public GameObject planshet;

	// Token: 0x04000244 RID: 580
	public bool active;

	// Token: 0x04000245 RID: 581
	public bool button;

	// Token: 0x04000246 RID: 582
	public int versionlast;
}
