using System;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class in1992_script : MonoBehaviour
{
	// Token: 0x060000A9 RID: 169 RVA: 0x0005E13B File Offset: 0x0005C33B
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.navel;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0005E14E File Offset: 0x0005C34E
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.nenavel;
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0005E164 File Offset: 0x0005C364
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.is_left)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.Name.text = "New beginnings";
				this.End.text = "The End";
				if (this.global1.data[19] == 1 && this.global1.data[20] == 1 && this.global1.data[21] == 1992)
				{
					this.time1 = GameObject.Find("Text_time").GetComponent<TimeScript>();
					this.fake_text = "Comrade!|The year 1991 has ended, which means that the world has changed beyond recognition, of course, further there will be unforgettable and difficult times of bitter achievements and great victories, but we laid the foundation of our bright future right now. However, you are our, similar to the sun, leader and you decide how to proceed:|You can decide to play further - from 1992 to infinity, at any time having the opportunity to finish the game, in order to reshape the world as you see fit. However, then you will not be able to get any achievement, starting with a new date.|Otherwise, you can put an end to all this and, just selecting the right button, finish the game and go to the summary window, where you will draw the line under your many years of work, and also will describe the state of the whole world for years to come. And, most importantly, you can open achievements!|The choice is yours.";
					this.this_text.text = this.Text(this.fake_text, 72);
					return;
				}
			}
			else if (this.global1.data[19] == 1 && this.global1.data[20] == 1 && this.global1.data[21] == 1992)
			{
				this.time1 = GameObject.Find("Text_time").GetComponent<TimeScript>();
				this.fake_text = "Товарищ!| 1991 год закончился, а значит и мир изменился до неузнаваемости. Конечно, дальше нас ждут незабываемые и тяжелые времена горьких свершений и великих побед, однако фундамент нашего светлого будущего мы заложили уже сейчас. Впрочем, вы - наш солнцеликий руководитель и вам решать, как поступить дальше:|Вы можете решить играть дальше - с 1992 года до бесконечности, в любой момент имея возможность закончить игру, дабы перекроить мир так, как вы считаете нужным. Однако, тогда вы не сможете добиться ни одного достижения, начиная с новой даты.|В ином случае вы можете положить всему этому конец и, просто выбрав правую кнопку, закончить игру и перейти к окну итогов, где будет подведена черта под вашей многолетней работой, а также будет описано состояние всего мира на грядущие годы. И, самое главное, вы сможете открыть достижения!|Выбор за вами.";
				this.this_text.text = this.Text(this.fake_text, 72);
			}
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0005E2AC File Offset: 0x0005C4AC
	private void OnMouseDown()
	{
		if (this.is_left)
		{
			this.time1.Reborn();
			this.global1.iron_and_blood = false;
			return;
		}
		if (this.global1.data[4] - this.global1.data[22] / 10 >= 940 || (this.global1.data[3] <= 350 && this.global1.data[4] - this.global1.data[22] / 10 >= 850) || (this.global1.data[3] <= 550 && this.global1.data[4] - this.global1.data[22] / 10 >= 900))
		{
			this.global1.data[46] = 2;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (this.global1.data[1] < 300 || (this.global1.data[1] < 500 && this.global1.data[2] + this.global1.data[22] / 5 <= 450))
		{
			this.global1.data[46] = 3;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (this.global1.data[3] + this.global1.data[22] / 100 <= 200)
		{
			this.global1.data[46] = 1;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (this.global1.data[11] == 1 && this.global1.data[68] <= -3 && (!this.global1.science[9] || this.global1.allcountries[16].Gosstroy != 0))
		{
			this.global1.data[46] = 8;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if (this.global1.data[0] == 12 && this.global1.data[80] <= 60 && this.global1.data[106] == 0 && this.global1.data[81] == 1 && this.global1.allcountries[7].Vyshi)
		{
			this.global1.data[46] = 10;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return;
		}
		if ((this.global1.data[0] < 49 || this.global1.data[0] > 51) && ((this.global1.data[10] > 499 && this.global1.regions[2].buildings[0].type != 21 && this.global1.regions[1].buildings[0].type == 23) || this.global1.data[10] > 549) && (!this.global1.allcountries[7].isOVD || !this.global1.allcountries[this.global1.data[0]].isOVD))
		{
			if (this.global1.data[0] == 18)
			{
				this.global1.data[76] = this.global1.data[10];
				if (this.global1.regions[1].buildings[0].type == 23 && this.global1.allcountries[7].Gosstroy < 2)
				{
					this.global1.data[10] -= 500;
				}
				else if (this.global1.regions[1].buildings[0].type == 23 && !this.global1.allcountries[7].Vyshi)
				{
					this.global1.data[10] -= 250;
				}
				else if (this.global1.regions[1].buildings[0].type == 23)
				{
					this.global1.data[10] -= 100;
				}
			}
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.global1.allcountries.Length; i++)
			{
				if (this.global1.allcountries[i] != null)
				{
					if (this.global1.allcountries[i].isOVD)
					{
						num++;
						num2++;
					}
					else if (this.global1.allcountries[i].isSEV)
					{
						num++;
					}
				}
			}
			if (num2 >= 6)
			{
				this.global1.data[10] -= (num2 - 6) * 30;
			}
			else
			{
				this.global1.data[10] += (num2 - 6) * 30;
			}
			if (num >= 9)
			{
				this.global1.data[10] -= (num - 9) * 10;
			}
			else
			{
				this.global1.data[10] += (num - 9) * 10;
			}
			if (this.global1.science_time[9] > 0)
			{
				this.global1.data[10] -= 50;
				if (this.global1.science[9])
				{
					this.global1.data[10] -= 250;
				}
			}
			if (this.global1.data[0] == 1)
			{
				this.global1.data[10] += 50;
			}
			if (!this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV)
			{
				this.global1.data[10] += 50;
			}
			if (this.global1.allcountries[7].Gosstroy <= 0)
			{
				this.global1.data[10] -= 50;
				if (this.global1.data[0] == 10)
				{
					this.global1.data[10] -= 500;
				}
			}
			else if (this.global1.allcountries[7].Gosstroy <= 1)
			{
				this.global1.data[10] -= 25;
			}
			if (this.global1.allcountries[16].Gosstroy <= 0 && this.global1.data[14] <= 3 && this.global1.allcountries[16].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
			{
				this.global1.data[10] -= 100;
			}
			else if (this.global1.allcountries[16].Gosstroy >= 1 && this.global1.data[14] >= 3 && this.global1.allcountries[16].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
			{
				this.global1.data[10] -= 100;
			}
			if (this.global1.allcountries[10].Stasi)
			{
				this.global1.data[10] -= 50;
			}
			if (this.global1.allcountries[this.global1.data[0]].isOVD && (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD) && (this.global1.data[54] >= 7 || (this.global1.allcountries[15].isOVD && this.global1.data[54] >= 5)) && !this.global1.allcountries[15].Help)
			{
				this.global1.data[10] -= 25;
			}
			if ((this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1 && this.global1.data[10] > 450) || (!this.global1.allcountries[7].isSEV && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 1 && this.global1.data[10] > 550) || (!this.global1.allcountries[7].isSEV && !this.global1.is_gkchp && this.global1.data[10] > 700) || (this.global1.allcountries[7].isSEV && this.global1.data[10] > 850))
			{
				this.global1.data[46] = 4;
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				return;
			}
			this.global1.data[46] = 0;
			this.GoodEnding();
			return;
		}
		else
		{
			if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
			{
				this.global1.data[46] = 0;
				this.GoodEnding();
				return;
			}
			Yugoglobal component = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
			int num3 = 0;
			foreach (YugoRegion yugoRegion in component.gameState.yugregions)
			{
				if (num3 > 2)
				{
					break;
				}
				if (yugoRegion.owner == component.gameState.player)
				{
					num3++;
				}
			}
			if (GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>().gameState.battle_royal)
			{
				for (int k = 0; k < component.gameState.yugcountries.Length; k++)
				{
					if (k != component.gameState.player && component.gameState.yugcountries[k].is_exist && !component.gameState.yugcountries[k].is_ally)
					{
						this.global1.data[46] = -1;
						GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
						GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
					}
				}
				this.global1.data[46] = 0;
				this.GoodEnding();
				return;
			}
			if (num3 <= 0)
			{
				this.global1.data[46] = -6;
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				return;
			}
			if ((!this.global1.allcountries[this.global1.data[0]].isOVD || (this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[7].isOVD) || !this.global1.allcountries[this.global1.data[0]].Vyshi || (this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[10] >= 501)) && (this.global1.data[3] <= 500 || this.global1.data[9] <= 250) && this.global1.data[161] > 2 && ((this.global1.data[150] == 1 && this.global1.data[0] == 49) || (((this.global1.data[136] == 1 && this.global1.data[137] == 0) || (this.global1.data[136] == 0 && this.global1.data[138] == 0)) && this.global1.data[0] == 50) || (((this.global1.data[118] == 1 && this.global1.data[116] == 1) || (this.global1.data[118] == 0 && this.global1.data[117] == 0)) && this.global1.data[0] == 51)))
			{
				this.global1.data[46] = -10;
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
				GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				return;
			}
			if (!this.CheckNATO())
			{
				this.global1.data[46] = 0;
				this.GoodEnding();
			}
			return;
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0005F06C File Offset: 0x0005D26C
	private bool CheckNATO()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.global1.allcountries.Length; i++)
		{
			if (this.global1.allcountries[i] != null)
			{
				if (this.global1.allcountries[i].isOVD)
				{
					num++;
					num2++;
				}
				else if (this.global1.allcountries[i].isSEV)
				{
					num++;
				}
			}
		}
		if (num2 >= 6)
		{
			this.global1.data[10] -= (num2 - 6) * 30;
		}
		else
		{
			this.global1.data[10] += (num2 - 6) * 30;
		}
		if (num >= 9)
		{
			this.global1.data[10] -= (num - 9) * 10;
		}
		else
		{
			this.global1.data[10] += (num - 9) * 10;
		}
		if (this.global1.science_time[9] > 0)
		{
			this.global1.data[10] -= 50;
			if (this.global1.science[9])
			{
				this.global1.data[10] -= 250;
			}
		}
		if (this.global1.data[0] == 1)
		{
			this.global1.data[10] += 50;
		}
		if (!this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV)
		{
			this.global1.data[10] += 50;
		}
		if (this.global1.allcountries[7].Gosstroy <= 0)
		{
			this.global1.data[10] -= 50;
			if (this.global1.data[0] == 10)
			{
				this.global1.data[10] -= 500;
			}
		}
		else if (this.global1.allcountries[7].Gosstroy <= 1)
		{
			this.global1.data[10] -= 25;
		}
		if (this.global1.allcountries[16].Gosstroy <= 0 && this.global1.data[14] <= 3 && this.global1.allcountries[16].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
		{
			this.global1.data[10] -= 100;
		}
		else if (this.global1.allcountries[16].Gosstroy >= 1 && this.global1.data[14] >= 3 && this.global1.allcountries[16].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
		{
			this.global1.data[10] -= 100;
		}
		if (this.global1.allcountries[10].Stasi)
		{
			this.global1.data[10] -= 50;
		}
		if (this.global1.allcountries[this.global1.data[0]].isOVD && (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD) && (this.global1.data[54] >= 7 || (this.global1.allcountries[15].isOVD && this.global1.data[54] >= 5)) && !this.global1.allcountries[15].Help)
		{
			this.global1.data[10] -= 25;
		}
		if ((this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1 && this.global1.data[10] > 450) || (!this.global1.allcountries[7].isSEV && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 1 && this.global1.data[10] > 550) || (!this.global1.allcountries[7].isSEV && !this.global1.is_gkchp && this.global1.data[10] > 700) || (this.global1.allcountries[7].isSEV && this.global1.data[10] > 850))
		{
			this.global1.data[46] = 4;
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
			GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
			return true;
		}
		return false;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0005F586 File Offset: 0x0005D786
	private void GoodEnding()
	{
		GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
		GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
	}

	// Token: 0x060000AF RID: 175 RVA: 0x0005F5B8 File Offset: 0x0005D7B8
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

	// Token: 0x04000140 RID: 320
	public bool is_left;

	// Token: 0x04000141 RID: 321
	public Sprite navel;

	// Token: 0x04000142 RID: 322
	public Sprite nenavel;

	// Token: 0x04000143 RID: 323
	private GlobalScript global1;

	// Token: 0x04000144 RID: 324
	private TimeScript time1;

	// Token: 0x04000145 RID: 325
	public TextMesh this_text;

	// Token: 0x04000146 RID: 326
	public TextMesh Name;

	// Token: 0x04000147 RID: 327
	public TextMesh End;

	// Token: 0x04000148 RID: 328
	private string fake_text;
}
