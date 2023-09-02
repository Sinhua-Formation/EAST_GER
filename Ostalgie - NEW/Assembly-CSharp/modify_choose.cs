using System;
using UnityEngine;

// Token: 0x0200002E RID: 46
public class modify_choose : MonoBehaviour
{
	// Token: 0x060000DF RID: 223 RVA: 0x00062D70 File Offset: 0x00060F70
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.num_this == 3 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.transform.GetChild(0).GetComponent<TextMesh>().text = "Modifies";
				return;
			}
			base.transform.GetChild(0).GetComponent<TextMesh>().text = "Модификатор";
		}
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00062E00 File Offset: 0x00061000
	private void Start()
	{
		if (this.num_this == 3 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.transform.GetChild(0).GetComponent<TextMesh>().text = "Modifies";
				return;
			}
			base.transform.GetChild(0).GetComponent<TextMesh>().text = "Модификатор";
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00062E7C File Offset: 0x0006107C
	private void OnMouseDown()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.num_this == 0)
			{
				this.num_names = 3;
				this.Name_1.text = "Current export";
				this.Name_2.text = "Need for import";
				this.Name_3.text = "Differences";
				if (this.global1.data[0] != 20)
				{
					this.Text_1.text = "% of 1985:\n" + this.global1.data[23].ToString() + "%";
					this.Text_2.text = "% of 1985:\n" + this.global1.data[24].ToString() + "%";
					this.Text_3.text = "% of 1985:\n" + (this.global1.data[23] - this.global1.data[24]).ToString() + "%";
				}
				else
				{
					this.Text_1.text = "% of 1961:\n" + this.global1.data[23].ToString() + "%";
					this.Text_2.text = "% of 1961:\n" + this.global1.data[24].ToString() + "%";
					this.Text_3.text = "% of 1961:\n" + (this.global1.data[23] - this.global1.data[24]).ToString() + "%";
				}
				if (this.global1.data[23] > this.global1.data[24])
				{
					TextMesh textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nProfit from deals\n(weekly): +",
						((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
						".",
						Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSupport of the people\n(weekly): +",
						((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
						".",
						Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
					});
				}
				else
				{
					TextMesh textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nProfit from deals\n(weekly): -",
						((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
						".",
						Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSupport of the people\n(weekly): -",
						((this.global1.data[23] - this.global1.data[24]) / 30).ToString(),
						".",
						Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 3 % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nStandard of living\n(weekly): -",
						((this.global1.data[23] - this.global1.data[24]) / 40).ToString(),
						".",
						Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 4 % 10).ToString()
					});
				}
			}
			else if (this.num_this == 1)
			{
				this.num_names = 3;
				this.Name_1.text = "Trading partners";
				this.Name_2.text = "";
				this.Name_3.text = "Condition";
				if (this.global1.data[19] > 1)
				{
					this.Text_1.text = string.Concat(new string[]
					{
						"For the last (",
						(this.global1.data[19] - 1).ToString(),
						") day:\n",
						this.global1.data[25].ToString(),
						" countries."
					});
				}
				else
				{
					this.Text_1.text = "For the 31st day:\n" + this.global1.data[25].ToString() + " countries.";
				}
				TextMesh text_ = this.Text_1;
				text_.text += "\n\n<color=red>Trade:</color>\n";
				string text = "";
				string text2 = "";
				string text3 = "";
				for (int i = 0; i < this.global1.allcountries.Length; i++)
				{
					if (this.global1.allcountries[i] != null)
					{
						if (this.global1.allcountries[i].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[i].Torg && i != this.global1.data[0])
						{
							text3 = text3 + this.global1.allcountries[i].name + "; ";
						}
						else if (((this.global1.allcountries[i].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV) || (this.global1.allcountries[i].Vyshi && this.global1.allcountries[this.global1.data[0]].Vyshi)) && !this.global1.allcountries[i].Torg && i != this.global1.data[0])
						{
							text2 = text2 + this.global1.allcountries[i].name + "; ";
						}
						else if (this.global1.allcountries[i].Torg)
						{
							text = text + this.global1.allcountries[i].name + "; ";
						}
					}
				}
				text = this.Text(text, 30);
				TextMesh text_2 = this.Text_1;
				text_2.text += text;
				TextMesh text_3 = this.Text_1;
				text_3.text += "\n<color=red>Economy alliance:</color>\n";
				text2 = this.Text(text2, 30);
				TextMesh text_4 = this.Text_1;
				text_4.text += text2;
				TextMesh text_5 = this.Text_1;
				text_5.text += "\n<color=red>Strategic partners:</color>\n";
				text3 = this.Text(text3, 30);
				TextMesh text_6 = this.Text_1;
				text_6.text += text3;
				if (this.global1.data[25] < 4)
				{
					this.Text_3.text = "Isolation";
					TextMesh textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nWestalgia (weekly): -",
						((-4 + this.global1.data[25]) / 10).ToString(),
						".",
						Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSovereignty (weekly): +",
						((4 - this.global1.data[25]) / 10).ToString(),
						".",
						Mathf.Abs((4 - this.global1.data[25]) % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nStandard of living\n(weekly): -",
						((-4 + this.global1.data[25]) / 10).ToString(),
						".",
						Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nAgents (weekly): -",
						((-4 + this.global1.data[25]) / 10).ToString(),
						".",
						Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
					});
				}
				else if (this.global1.data[25] > 8)
				{
					this.Text_3.text = "Globalization";
					TextMesh textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nWestalgia (weekly): +",
						((this.global1.data[25] - 8) / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[25] - 8) % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSovereignty (weekly): -",
						((8 - this.global1.data[25]) / 10).ToString(),
						".",
						Mathf.Abs((8 - this.global1.data[25]) % 10).ToString()
					});
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nStandard of living\n(weekly): +",
						((this.global1.data[25] - 8) / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[25] - 8) % 10).ToString()
					});
				}
				else
				{
					this.Text_3.text = "Balance";
				}
				this.Text_2.text = "";
			}
			else if (this.num_this == 2)
			{
				if (this.global1.data[0] != 5 || this.global1.data[26] <= 0 || (this.global1.data[0] == 5 && !this.global1.event_done[94]))
				{
					if (this.global1.data[26] > 0)
					{
						this.num_names = 2;
						this.Name_1.text = "State debt";
						this.Name_2.text = "Differences";
						this.Text_1.text = "Debts: " + (this.global1.data[26] / 10).ToString() + "." + Mathf.Abs(this.global1.data[26] % 10).ToString();
						if (this.global1.data[34] >= 0)
						{
							this.Text_2.text = "between take and pay off.\nRelease of funds from\npayment of debts\n(weekly):\n+" + (this.global1.data[34] / 10).ToString() + "." + Mathf.Abs(this.global1.data[34] % 10).ToString();
							TextMesh text_7 = this.Text_2;
							text_7.text = text_7.text + "\nWeeks to fully pay off\nare about: " + (this.global1.data[26] / this.global1.data[34]).ToString();
						}
						else
						{
							this.Text_2.text = "between take and pay off.\nRelease of funds from\npayment of debts\n(weekly):\n0";
						}
					}
					else
					{
						this.num_names = 1;
						this.Name_1.text = "State debt";
						this.Text_1.text = "Debts: 0";
					}
				}
				else
				{
					this.num_names = 1;
					this.Name_1.text = "Five-year saving";
					this.Text_1.text = "Profit:\n+" + (this.global1.data[34] / 10).ToString() + "." + Mathf.Abs(this.global1.data[34] % 10).ToString();
				}
			}
			else if (this.num_this == 3 && this.global1.data[0] != 12)
			{
				if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					this.num_names = 1;
					Yugoglobal component = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
					this.Name_1.text = component.science_text[106];
					this.Text_1.text = "";
					this.Text_1.characterSize = 0.08f;
					for (int j = 1; j < component.gameState.modifies.Length; j++)
					{
						if (component.gameState.modifies[j] > 0)
						{
							TextMesh text_8 = this.Text_1;
							text_8.text = text_8.text + "\n" + string.Format(component.science_text[190 + j - 1], component.gameState.modifies[j]);
							int num = 0;
							int num2 = 0;
							string text4 = component.science_text[215 + j - 1];
							string text5 = component.science_text[215 + j - 1];
							for (int k = 0; k < text4.Length; k++)
							{
								num2++;
								if (text4[k] == char.Parse(":"))
								{
									num++;
								}
								if (num == component.gameState.modifies[j])
								{
									text5 = text5.Remove(0, num2);
									num2 = -1;
									num = 100;
								}
								else if (num > 100)
								{
									text5 = text5.Remove(num2);
									break;
								}
							}
							TextMesh text_9 = this.Text_1;
							text_9.text = text_9.text + "\n<color=red>" + text5 + "</color>";
						}
					}
				}
				else
				{
					this.num_names = 3;
					this.Name_1.text = "Fully open";
					this.Name_2.text = "Paid open";
					this.Name_3.text = "Restricted";
					this.Text_1.text = "Borders: " + this.global1.data[27].ToString();
					TextMesh textMesh = this.Text_1;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSupport of the USSR and people\nWeekly: +",
						(this.global1.data[27] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[27] % 10).ToString()
					});
					textMesh = this.Text_1;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nWestalgia\nWeekly: +",
						(this.global1.data[28] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[28] % 10).ToString()
					});
					this.Text_2.text = "Borders: " + this.global1.data[28].ToString();
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nCustoms profit\nWeekly: +",
						(this.global1.data[28] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[28] % 10).ToString()
					});
					this.Text_3.text = "Borders: " + this.global1.data[29].ToString();
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nWestalgia\nWeekly: -",
						(this.global1.data[29] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[29] % 10).ToString()
					});
					TextMesh text_10 = this.Text_3;
					text_10.text = text_10.text + "\n\nClosed borders: " + (5 - this.global1.data[27] - this.global1.data[28] - this.global1.data[29]).ToString();
				}
			}
			else if (this.num_this == 3)
			{
				this.num_names = 1;
				this.Name_1.text = "Maximum border";
				this.Text_1.text = "";
				if (this.global1.data[80] - 20 < 80)
				{
					int num3 = (80 - (this.global1.data[80] - 20)) / 20;
					TextMesh text_11 = this.Text_1;
					text_11.text = text_11.text + "\nUpper limit:\nUnity of the party: " + (100 - num3 * 10);
					TextMesh text_12 = this.Text_1;
					text_12.text = text_12.text + "\nUpper limit:\nSupport of the people: " + (100 - num3 * 10);
					TextMesh text_13 = this.Text_1;
					text_13.text = text_13.text + "\nUpper limit:\nStandards of living: " + (100 - num3 * 10);
					TextMesh text_14 = this.Text_1;
					text_14.text = text_14.text + "\nLower limit:\nWestalgia: " + num3 * 15;
				}
			}
			else if (this.num_this == 4)
			{
				this.num_names = 2;
				this.Name_1.text = "Soviet aid";
				this.Text_1.text = "\nIn total: " + (this.global1.data[30] / 10).ToString() + "." + Mathf.Abs(this.global1.data[30] % 10).ToString();
				this.Name_2.text = "\nCurrent\nSoviet Doctrine";
				if (this.global1.data[0] == 10)
				{
					this.num_names = 3;
					this.Name_3.text = "Chinese aid";
					this.Text_3.text = "\nIn total: " + (this.global1.data[73] / 10).ToString() + "." + Mathf.Abs(this.global1.data[73] % 10).ToString();
				}
				if (this.global1.event_done[35] && this.global1.data[21] <= 1991 && (!this.global1.is_gkchp || (this.global1.allcountries[7].Gosstroy > 1 && this.global1.is_gkchp)))
				{
					this.Text_2.text = "\n\n\nRefusal of aid\nto socialist camp";
					TextMesh text_15 = this.Text_2;
					text_15.text += "\nMonthly influence:";
					TextMesh text_16 = this.Text_2;
					text_16.text += "\nSocialist camp stability: -1";
					TextMesh text_17 = this.Text_2;
					text_17.text += "\nNo help!";
				}
				else if (this.global1.event_done[4] && this.global1.data[21] <= 1991 && (!this.global1.is_gkchp || (this.global1.allcountries[7].Gosstroy > 1 && this.global1.is_gkchp)))
				{
					this.Text_2.text = "\n\n\nSinatra Doctrine";
					TextMesh text_18 = this.Text_2;
					text_18.text += "\nMonthly influence:";
					TextMesh text_19 = this.Text_2;
					text_19.text += "\nSocialist camp stability: -1";
					TextMesh text_20 = this.Text_2;
					text_20.text += "\nSoviet aid: -2%";
				}
				else if (this.global1.data[21] > 1991 || (this.global1.allcountries[7].isOVD && this.global1.is_gkchp))
				{
					this.Text_2.text = "\n\n\nStabilization";
					TextMesh text_21 = this.Text_2;
					text_21.text += "\nThe exterior policy";
					TextMesh text_22 = this.Text_2;
					text_22.text += "\nis trying to be stabilized.";
				}
				else
				{
					this.Text_2.text = "\n\n\nThe Doctrine of Brezhnev";
					TextMesh text_23 = this.Text_2;
					text_23.text += "\nStability";
				}
			}
			else if (this.num_this == 5)
			{
				this.num_names = 2;
				this.Name_1.text = "World view";
				this.Name_2.text = "Special influence";
				this.Text_1.text = "Now:";
				if (this.global1.data[31] > 700)
				{
					TextMesh textMesh = this.Text_1;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nNationalism\n(",
						(this.global1.data[31] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[31] % 10).ToString(),
						"/100)"
					});
					this.Text_2.text = "Westalgia\nWeekly: -" + ((this.global1.data[31] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString();
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nUnity of the party\nWeekly: +",
						((this.global1.data[31] - 500) / 100 / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
					});
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSovereignty\nWeekly: +",
						((this.global1.data[31] - 500) / 50 / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[31] - 500) / 50 % 10).ToString()
					});
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nApproval from the USSR\nWeekly: -",
						((this.global1.data[31] - 500) / 100 / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
					});
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nDissatisfaction of NATO\nWeekly: +",
						((this.global1.data[31] - 500) / 100 / 10).ToString(),
						".",
						Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
					});
				}
				else if (this.global1.data[31] >= 400 && this.global1.data[31] <= 700)
				{
					TextMesh textMesh = this.Text_1;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSoviet type patriotism\n(",
						(this.global1.data[31] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[31] % 10).ToString(),
						"/100)"
					});
					this.Text_2.text = "Nothing".ToString();
				}
				else
				{
					TextMesh textMesh = this.Text_1;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nCosmopolitanism\n(",
						(this.global1.data[31] / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[31] % 10).ToString(),
						"/100)"
					});
					this.Text_2.text = "Westalgia\nWeekly: +" + ((500 - this.global1.data[31]) / 100 / 10).ToString() + "." + Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString();
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nUnity of the party\nWeekly: +",
						((500 - this.global1.data[31]) / 100 / 10).ToString(),
						".",
						Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString()
					});
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nSovereignty\nWeekly: -",
						((500 - this.global1.data[31]) / 50 / 10).ToString(),
						".",
						Mathf.Abs((500 - this.global1.data[31]) / 50 % 10).ToString()
					});
					textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nDissatisfaction of NATO\nWeekly: -",
						((500 - this.global1.data[31]) / 100 / 10).ToString(),
						".",
						Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString()
					});
				}
			}
			else if (this.num_this == 6)
			{
				this.num_names = 2;
				this.Name_1.text = "Sovereignty";
				this.Name_2.text = "Special influence";
				this.Text_1.text = string.Concat(new string[]
				{
					"Now: ",
					(this.global1.data[22] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[22] % 10).ToString(),
					"/100"
				});
				if (this.global1.data[22] - 500 < 0)
				{
					this.Text_2.text = "Westalgia\nWeekly: +" + ((this.global1.data[22] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[22] - 500) / 100 % 10).ToString();
				}
				else
				{
					this.Text_2.text = "Westalgia\nWeekly: -" + ((this.global1.data[22] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[22] - 500) / 100 % 10).ToString();
				}
				if (this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV)
				{
					TextMesh textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nUnity of the party\nWeekly: +",
						(this.global1.data[22] / 100 / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[22] / 100 % 10).ToString()
					});
				}
				else
				{
					TextMesh textMesh = this.Text_2;
					textMesh.text = string.Concat(new string[]
					{
						textMesh.text,
						"\nUnity of the party\nWeekly: +",
						(this.global1.data[22] / 50 / 10).ToString(),
						".",
						Mathf.Abs(this.global1.data[22] / 50 % 10).ToString()
					});
				}
				TextMesh text_24 = this.Text_2;
				text_24.text += "\nAlso it influences\nprobability of our defeat.";
				if (this.global1.data[0] == 10)
				{
					this.num_names = 3;
					this.Name_3.text = "Nuclear program";
					if (this.global1.data[100] > 0 && this.global1.event_done[255])
					{
						this.Text_3.text = "Monthly:\nAgents: -0.5\nPatriotism +0.5\nThe budget -10%";
					}
					else if (this.global1.data[100] > 0)
					{
						this.Text_3.text = "Monthly:\nAgents: -0.5\nPatriotism +0.5";
					}
					else
					{
						this.Text_3.text = "We don't have it";
					}
				}
			}
			else if (this.num_this == 7)
			{
				this.num_names = 2;
				this.Name_1.text = "Ostalgia";
				this.Name_2.text = "Special influence";
				if (this.global1.data[0] == 10)
				{
					this.num_names = 3;
					this.Name_3.text = "Western Sanctions";
					if (this.global1.data[72] > 0)
					{
						this.Text_3.text = "Weekly:\nDipreputation: +0.2;\nDissatisfaction of NATO: +0.2\nBudget: -0.5\nSovereignty: +0.2\nStandard of living: -0.2";
					}
				}
				else if (this.global1.data[0] == 18)
				{
					this.num_names = 3;
					this.Name_3.text = "Embargo from the US";
					if (this.global1.data[77] > 0)
					{
						this.Text_3.text = string.Concat(new object[]
						{
							"Weekly:\nSovereignty: +0.2\nBudget: -0.",
							this.global1.data[77],
							"\nDissatisfaction of NATO: +0.",
							this.global1.data[77] / 2,
							"\nSupport of the people:: +0.",
							this.global1.data[77]
						});
					}
					else
					{
						this.Text_3.text = "None";
					}
				}
				else if (this.global1.data[0] >= 1 && this.global1.data[0] <= 6)
				{
					this.num_names = 3;
					this.Name_3.text = "Western Sanctions";
					if (this.global1.data[72] > 0)
					{
						this.Text_3.text = "Weekly:\nDipreputation: +0.2;\nDissatisfaction of NATO: +0.2\nBudget: -0.5\nSovereignty: +0.2";
					}
					else
					{
						this.Text_3.text = "None";
					}
				}
				this.Text_1.text = string.Concat(new string[]
				{
					"Discontent of western citizens\nand their sympathy\nfor left ideas:\n",
					(this.global1.allcountries[17].Westalgie / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[17].Westalgie % 10).ToString(),
					"/100"
				});
				this.Text_2.text = "Westalgia\nWeekly: -" + (this.global1.allcountries[17].Westalgie / 80 / 10).ToString() + "." + Mathf.Abs(this.global1.allcountries[17].Westalgie / 80 % 10).ToString();
				TextMesh textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nDissatisfaction of NATO\nWeekly: -",
					(this.global1.allcountries[17].Westalgie / 120 / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[17].Westalgie / 120 % 10).ToString()
				});
			}
			else if (this.num_this == 8 && this.global1.data[0] != 12)
			{
				this.num_names = 3;
				this.Name_1.text = "ASIA";
				this.Name_2.text = "EUROPE";
				this.Name_3.text = "AFRICA";
				this.Text_1.text = "Control in Afganistan: ";
				int num4 = 30;
				if (this.global1.allcountries[7].isSEV || this.global1.allcountries[16].isSEV || this.global1.allcountries[19].Gosstroy <= 0)
				{
					num4 += 25;
				}
				if (this.global1.allcountries[31].Help)
				{
					num4 += 5;
				}
				if (this.global1.data[37] <= 6)
				{
					num4 += this.global1.data[37] * 4;
				}
				else if (this.global1.data[37] <= 8)
				{
					num4 += this.global1.data[37] * 5;
				}
				else
				{
					num4 += 40;
				}
				TextMesh text_25 = this.Text_1;
				text_25.text = text_25.text + num4.ToString() + " %";
				TextMesh text_26 = this.Text_1;
				text_26.text += "\nDevelpoment of YDR: ";
				num4 = 40;
				if (this.global1.allcountries[24].Stasi)
				{
					num4 += 25;
				}
				if (this.global1.allcountries[24].Gosstroy == 0)
				{
					num4 += 5;
				}
				if (this.global1.data[55] <= 1)
				{
					num4 += this.global1.data[55] * 10;
				}
				else
				{
					num4 += 30;
				}
				TextMesh text_27 = this.Text_1;
				text_27.text = text_27.text + num4.ToString() + " %";
				TextMesh text_28 = this.Text_1;
				text_28.text += "\nControl in Nepal: ";
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					(this.global1.allcountries[43].Westalgie / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[43].Westalgie % 10).ToString(),
					" %"
				});
				if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
				{
					this.Text_2.text = "Control in Yugoslavia: ";
					num4 = 25;
					if (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD)
					{
						num4 += 20;
					}
					if (this.global1.allcountries[this.global1.data[0]].isOVD)
					{
						num4 += 20;
					}
					if (this.global1.data[54] <= 4)
					{
						num4 += this.global1.data[54] * 3;
					}
					else if (this.global1.data[54] <= 6)
					{
						num4 += this.global1.data[54] * 5;
					}
					else
					{
						num4 += 35;
					}
					if (this.global1.data[59] == 2)
					{
						num4 -= num4 / 3;
					}
					TextMesh text_29 = this.Text_2;
					text_29.text = text_29.text + num4.ToString() + " %";
					num4 = 0;
					TextMesh text_30 = this.Text_2;
					text_30.text += "\nThe strength of the faction\n\"Soyuz\" in the USSR: ";
					if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 0 && !this.global1.allcountries[7].Vyshi)
					{
						num4 = 100;
					}
					else if (this.global1.allcountries[7].isOVD && this.global1.allcountries[7].isSEV && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
					{
						num4 = 80;
						num4 -= this.global1.allcountries[7].Gosstroy * 15;
					}
					else if ((this.global1.allcountries[7].isSEV || this.global1.allcountries[7].isOVD) && this.global1.data[7] >= 250 && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
					{
						num4 = 60;
						num4 -= this.global1.allcountries[7].Gosstroy * 15;
					}
					else if ((this.global1.allcountries[7].isSEV && !this.global1.is_gkchp) || (this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi) || (this.global1.data[7] >= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi))
					{
						num4 = 40;
						num4 -= this.global1.allcountries[7].Gosstroy * 15;
					}
					else if ((!this.global1.allcountries[7].Vyshi && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2 && !this.global1.allcountries[7].Vyshi) || (!this.global1.is_gkchp && this.global1.data[7] <= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].Vyshi))
					{
						num4 = 20;
					}
					else if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 1 && !this.global1.allcountries[7].Vyshi)
					{
						num4 = 70;
					}
					else
					{
						num4 = num4;
					}
					num4 += this.global1.data[51] + this.global1.data[52] * 3;
					if (num4 > 100)
					{
						num4 = 100;
					}
					TextMesh text_31 = this.Text_2;
					text_31.text = text_31.text + num4.ToString() + " %";
				}
				else
				{
					this.Text_2.text = "Go save Yugoslavia!";
				}
				this.Text_3.text = "Control in Algeria: ";
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					(this.global1.allcountries[40].Westalgie / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[40].Westalgie % 10).ToString(),
					" %"
				});
				TextMesh text_32 = this.Text_3;
				text_32.text += "\nControl in Ethiopia: ";
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					(this.global1.allcountries[41].Westalgie / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[41].Westalgie % 10).ToString(),
					" %"
				});
				TextMesh text_33 = this.Text_3;
				text_33.text += "\nControl in Somalia: ";
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					(this.global1.allcountries[42].Westalgie / 10).ToString(),
					".",
					Mathf.Abs(this.global1.allcountries[42].Westalgie % 10).ToString(),
					" %"
				});
			}
			else if (this.num_this == 8)
			{
				this.num_names = 3;
				this.Name_1.text = "REGIONS";
				this.Name_2.text = "LOSSES";
				this.Name_3.text = "BATTLES";
				this.Text_1.text = "East: " + ((this.global1.data[90] == 1) ? "Under control" : "Lost");
				TextMesh text_34 = this.Text_1;
				text_34.text = text_34.text + "\nWest: " + ((this.global1.data[92] == 1) ? "Under control" : "Lost");
				TextMesh text_35 = this.Text_1;
				text_35.text = text_35.text + "\nNorth: " + ((this.global1.data[93] == 1) ? "Under control" : "Lost");
				TextMesh text_36 = this.Text_1;
				text_36.text = text_36.text + "\nSouth: " + ((this.global1.data[94] == 1) ? "Under control" : "Lost");
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nTotal: ",
					this.global1.data[80],
					"%"
				});
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				if (this.global1.data[90] != 1)
				{
					num9 -= 2;
					num7++;
					num6--;
				}
				if (this.global1.data[93] != 1)
				{
					num8 -= 2;
					num7++;
					num6--;
				}
				if (this.global1.data[92] != 1)
				{
					num5 -= 2;
					num7++;
					num6--;
				}
				if (this.global1.data[94] != 1)
				{
					num8--;
					num7++;
					num6--;
				}
				this.Text_2.text = string.Concat(new object[]
				{
					"-0.",
					num9 * -1,
					" Living standarts\n+0.",
					num7,
					" Westalgie\n-0.",
					num6 * -1,
					" People's support\n-0.",
					num8 * -1,
					" Budget\n-0.",
					num5 * -1,
					" Agent networks"
				});
				if (this.global1.data[88] == 0)
				{
					this.Text_3.text = "Everything is stable";
				}
				else if (this.global1.data[88] == 1)
				{
					this.Text_3.text = "We are advancing: ";
				}
				else if (this.global1.data[88] == 2)
				{
					this.Text_3.text = "We are defending: ";
				}
				if (this.global1.data[107] == 1)
				{
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new object[]
					{
						textMesh.text,
						"\nEast\nControl: ",
						this.global1.data[108],
						"%"
					});
				}
				else if (this.global1.data[107] == 2)
				{
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new object[]
					{
						textMesh.text,
						"\nWest\nControl: ",
						this.global1.data[108],
						"%"
					});
				}
				else if (this.global1.data[107] == 3)
				{
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new object[]
					{
						textMesh.text,
						"\nNorth\nControl: ",
						this.global1.data[108],
						"%"
					});
				}
				else if (this.global1.data[107] == 4)
				{
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new object[]
					{
						textMesh.text,
						"\nSouth\nControl: ",
						this.global1.data[108],
						"%"
					});
				}
				else if (this.global1.data[107] == 10)
				{
					textMesh = this.Text_3;
					textMesh.text = string.Concat(new object[]
					{
						textMesh.text,
						"\nКabul\nControl: ",
						this.global1.data[108],
						"%"
					});
				}
			}
			else if (this.num_this == 9)
			{
				this.num_names = 2;
				this.Name_1.text = "Admin. Expenses";
				this.Name_2.text = "Special influence";
				if (this.global1.data[0] == 10)
				{
					this.num_names = 3;
					this.Name_3.text = "Famine";
					if (this.global1.data[71] > 0)
					{
						this.Text_3.text = "Weekly:\nSupport of the people: -0.5;\nUnity of the Party: -0.4\nBudget: -0.2\nSovereignty: -0.2";
					}
					else
					{
						this.Text_3.text = "Everything is alright\nwhile Standard of living\nis more than 20.0";
					}
				}
				else if (this.global1.data[0] == 18)
				{
					this.num_names = 3;
					this.Name_3.text = "Special period";
					if (this.global1.data[102] > 0)
					{
						this.Text_3.text = "Weekly:\nBudget changes on 0." + (this.global1.data[102] - 1);
						if (this.global1.data[5] > 400 - this.global1.data[102] * 30)
						{
							TextMesh text_37 = this.Text_3;
							text_37.text = text_37.text + "\nStandard of living: -0." + this.global1.data[102];
						}
						if (this.global1.allcountries[this.global1.data[0]].isSEV || this.global1.allcountries[7].isSEV)
						{
							TextMesh textMesh = this.Text_3;
							textMesh.text = string.Concat(new object[]
							{
								textMesh.text,
								"\nWestalgia: +0.",
								this.global1.data[102] / 2,
								"\nSupport of the people: -0.",
								this.global1.data[102] / 2
							});
						}
						if (!this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							TextMesh text_38 = this.Text_3;
							text_38.text = text_38.text + "\nBudget: +0." + this.global1.data[102] * 2;
						}
					}
					else
					{
						this.Text_3.text = "Everything is alright";
					}
				}
				else if (this.global1.data[0] >= 1 && this.global1.data[0] <= 6)
				{
					this.num_names = 3;
					this.Name_3.text = "Ration stamp";
					if (this.global1.data[71] > 0)
					{
						int num10 = 0;
						for (int l = 0; l < this.global1.science.Length; l++)
						{
							if (this.global1.science[l])
							{
								num10++;
							}
						}
						this.Text_3.text = "Weekly:\nSupport of the people: -0.5;\nUnity of the Party: -0.4\nBudget: -0.2\n";
						TextMesh text_39 = this.Text_3;
						text_39.text = text_39.text + "while Standard of living\nis less than " + (49 - num10);
					}
					else
					{
						int num11 = 0;
						for (int m = 0; m < this.global1.science.Length; m++)
						{
							if (this.global1.science[m])
							{
								num11++;
							}
						}
						this.Text_3.text = "Everything is alright\nwhile Standard of living\nis more than " + (35 - num11);
					}
				}
				this.Text_1.text = "Currently:\n" + this.global1.data[63].ToString();
				if (this.global1.data[21] <= 1991)
				{
					if (this.global1.science[5])
					{
						TextMesh text_40 = this.Text_1;
						text_40.text = text_40.text + "\nMinimum size:\n" + ((this.global1.data[21] - 1989) * 2).ToString();
					}
					else if (this.global1.science[4])
					{
						TextMesh text_41 = this.Text_1;
						text_41.text = text_41.text + "\nMinimum size:\n" + ((this.global1.data[21] - 1988) * 2).ToString();
					}
					else if (this.global1.science[3])
					{
						TextMesh text_42 = this.Text_1;
						text_42.text = text_42.text + "\nMinimum size:\n" + ((this.global1.data[21] - 1987) * 2).ToString();
					}
					else
					{
						TextMesh text_43 = this.Text_1;
						text_43.text = text_43.text + "\nMinimum size:\n" + ((this.global1.data[21] - 1986) * 2).ToString();
					}
				}
				TextMesh text_44 = this.Text_1;
				text_44.text += "\nIncreased from\nconcluded trade deals\nand actions\non the political map.";
				this.Text_2.text = "Budget reduction\nMonthly: -" + (this.global1.data[63] / 2 / 10).ToString() + "." + Mathf.Abs(this.global1.data[63] / 2 % 10).ToString();
				TextMesh text_45 = this.Text_2;
				text_45.text += "\nExpenses reduction\nMonthly: - 4";
			}
		}
		else if (this.num_this == 0)
		{
			this.num_names = 3;
			this.Name_1.text = "Текущий экспорт";
			this.Name_2.text = "Нужда в импорте";
			this.Name_3.text = "Разница";
			if (this.global1.data[0] != 20 && this.global1.data[0] != 12)
			{
				this.Text_1.text = "% от 1985:\n" + this.global1.data[23].ToString() + "%";
				this.Text_2.text = "% от 1985:\n" + this.global1.data[24].ToString() + "%";
				this.Text_3.text = "% от 1985:\n" + (this.global1.data[23] - this.global1.data[24]).ToString() + "%";
			}
			else if (this.global1.data[0] == 12)
			{
				this.Text_1.text = "% от 1973:\n" + this.global1.data[23].ToString() + "%";
				this.Text_2.text = "% от 1973:\n" + this.global1.data[24].ToString() + "%";
				this.Text_3.text = "% от 1973:\n" + (this.global1.data[23] - this.global1.data[24]).ToString() + "%";
			}
			else
			{
				this.Text_1.text = "% от 1961:\n" + this.global1.data[23].ToString() + "%";
				this.Text_2.text = "% от 1961:\n" + this.global1.data[24].ToString() + "%";
				this.Text_3.text = "% от 1961:\n" + (this.global1.data[23] - this.global1.data[24]).ToString() + "%";
			}
			if (this.global1.data[23] > this.global1.data[24])
			{
				TextMesh textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВыручка от сделок\n(еженедельно): +",
					((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
					".",
					Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nУдовлетворение народа\n(еженедельно): +",
					((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
					".",
					Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
				});
			}
			else
			{
				TextMesh textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВыручка от сделок\n(еженедельно): -",
					((this.global1.data[23] - this.global1.data[24]) / 20).ToString(),
					".",
					Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 2 % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nУдовлетворение народа\n(еженедельно): -",
					((this.global1.data[23] - this.global1.data[24]) / 30).ToString(),
					".",
					Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 3 % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nУровень жизни\n(еженедельно): -",
					((this.global1.data[23] - this.global1.data[24]) / 40).ToString(),
					".",
					Mathf.Abs((this.global1.data[23] - this.global1.data[24]) / 4 % 10).ToString()
				});
			}
		}
		else if (this.num_this == 1)
		{
			this.num_names = 3;
			this.Name_1.text = "Торговые партнёры";
			this.Name_2.text = "";
			this.Name_3.text = "Статус";
			if (this.global1.data[19] > 1)
			{
				this.Text_1.text = string.Concat(new string[]
				{
					"За прошлое (",
					(this.global1.data[19] - 1).ToString(),
					") число:\n",
					this.global1.data[25].ToString(),
					" шт."
				});
			}
			else
			{
				this.Text_1.text = "За 31 число:\n" + this.global1.data[25].ToString() + " шт.";
			}
			TextMesh text_46 = this.Text_1;
			text_46.text += "\n\n<color=red>Торговые:</color>\n";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			for (int n = 0; n < this.global1.allcountries.Length; n++)
			{
				if (this.global1.allcountries[n] != null)
				{
					if (this.global1.allcountries[n].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[n].Torg && n != this.global1.data[0])
					{
						text8 = text8 + this.global1.allcountries[n].name + "; ";
					}
					else if (((this.global1.allcountries[n].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV) || (this.global1.allcountries[n].Vyshi && this.global1.allcountries[this.global1.data[0]].Vyshi)) && !this.global1.allcountries[n].Torg && n != this.global1.data[0])
					{
						text7 = text7 + this.global1.allcountries[n].name + "; ";
					}
					else if (this.global1.allcountries[n].Torg)
					{
						text6 = text6 + this.global1.allcountries[n].name + "; ";
					}
				}
			}
			text6 = this.Text(text6, 30);
			TextMesh text_47 = this.Text_1;
			text_47.text += text6;
			TextMesh text_48 = this.Text_1;
			text_48.text += "\n<color=red>Экономические:</color>\n";
			text7 = this.Text(text7, 30);
			TextMesh text_49 = this.Text_1;
			text_49.text += text7;
			TextMesh text_50 = this.Text_1;
			text_50.text += "\n<color=red>Стратегические:</color>\n";
			text8 = this.Text(text8, 30);
			TextMesh text_51 = this.Text_1;
			text_51.text += text8;
			if (this.global1.data[25] < 4)
			{
				this.Text_3.text = "Изоляция";
				TextMesh textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВестальгия (еженедельно): -",
					((-4 + this.global1.data[25]) / 10).ToString(),
					".",
					Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nСуверенитет (еженедельно): +",
					((4 - this.global1.data[25]) / 10).ToString(),
					".",
					Mathf.Abs((4 - this.global1.data[25]) % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nУровень жизни\n(еженедельно): -",
					((-4 + this.global1.data[25]) / 10).ToString(),
					".",
					Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nАгенты (еженедельно): -",
					((-4 + this.global1.data[25]) / 10).ToString(),
					".",
					Mathf.Abs((-4 + this.global1.data[25]) % 10).ToString()
				});
			}
			else if (this.global1.data[25] > 8)
			{
				this.Text_3.text = "Глобализация";
				TextMesh textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВестальгия (еженедельно): +",
					((this.global1.data[25] - 8) / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[25] - 8) % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nСуверенитет (еженедельно): -",
					((8 - this.global1.data[25]) / 10).ToString(),
					".",
					Mathf.Abs((8 - this.global1.data[25]) % 10).ToString()
				});
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nУровень жизни\n(еженедельно): +",
					((this.global1.data[25] - 8) / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[25] - 8) % 10).ToString()
				});
			}
			else
			{
				this.Text_3.text = "Баланс";
			}
			this.Text_2.text = "";
		}
		else if (this.num_this == 2)
		{
			if (this.global1.data[0] != 5 || this.global1.data[26] <= 0 || (this.global1.data[0] == 5 && !this.global1.event_done[94]))
			{
				if (this.global1.data[26] > 0)
				{
					this.num_names = 2;
					this.Name_1.text = "Государственный долг";
					this.Name_2.text = "Разница";
					this.Text_1.text = "Задолжность: " + (this.global1.data[26] / 10).ToString() + "." + Mathf.Abs(this.global1.data[26] % 10).ToString();
					if (this.global1.data[34] >= 0)
					{
						this.Text_2.text = "между взятием и выплатой.\nВысвобождение средств от\nвыплаты долгов\n(еженедельно):\n+" + (this.global1.data[34] / 10).ToString() + "." + Mathf.Abs(this.global1.data[34] % 10).ToString();
						TextMesh text_52 = this.Text_2;
						text_52.text = text_52.text + "\nОсталось недель до выплаты\nПримерно: " + (this.global1.data[26] / this.global1.data[34]).ToString();
					}
					else
					{
						this.Text_2.text = "между взятием и выплатой.\nВысвобождение средств от\nвыплаты долгов\n(еженедельно):\n0";
					}
				}
				else
				{
					this.num_names = 1;
					this.Name_1.text = "Государственный долг";
					this.Text_1.text = "Задолжность: 0";
				}
			}
			else
			{
				this.num_names = 1;
				this.Name_1.text = "Пятилетка экономии";
				this.Text_1.text = "Прибыль:\n+" + (this.global1.data[34] / 10).ToString() + "." + Mathf.Abs(this.global1.data[34] % 10).ToString();
			}
		}
		else if (this.num_this == 3 && this.global1.data[0] != 12)
		{
			if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.num_names = 1;
				Yugoglobal component2 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
				this.Name_1.text = component2.science_text[106];
				this.Text_1.text = "";
				this.Text_1.characterSize = 0.08f;
				for (int num12 = 1; num12 < component2.gameState.modifies.Length; num12++)
				{
					if (component2.gameState.modifies[num12] > 0)
					{
						TextMesh text_53 = this.Text_1;
						text_53.text = text_53.text + "\n" + string.Format(component2.science_text[190 + num12 - 1], component2.gameState.modifies[num12]);
						int num13 = 0;
						int num14 = 0;
						string text9 = component2.science_text[215 + num12 - 1];
						string text10 = component2.science_text[215 + num12 - 1];
						for (int num15 = 0; num15 < text9.Length; num15++)
						{
							num14++;
							if (text9[num15] == char.Parse(":"))
							{
								num13++;
							}
							if (num13 == component2.gameState.modifies[num12])
							{
								text10 = text10.Remove(0, num14);
								num14 = -1;
								num13 = 100;
							}
							else if (num13 > 100)
							{
								text10 = text10.Remove(num14);
								break;
							}
						}
						TextMesh text_54 = this.Text_1;
						text_54.text = text_54.text + "\n<color=red>" + text10 + "</color>";
					}
				}
			}
			else
			{
				this.num_names = 3;
				this.Name_1.text = "Полностью открытые";
				this.Name_2.text = "Открытые платно";
				this.Name_3.text = "Ограниченные";
				this.Text_1.text = "Границ: " + this.global1.data[27].ToString();
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nОдобрение СССР и народа\nЕженедельно: +",
					(this.global1.data[27] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[27] % 10).ToString()
				});
				textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВестальгия\nЕженедельно: +",
					(this.global1.data[28] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[28] % 10).ToString()
				});
				this.Text_2.text = "Границ: " + this.global1.data[28].ToString();
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nТаможенная выручка\nЕженедельно: +",
					(this.global1.data[28] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[28] % 10).ToString()
				});
				this.Text_3.text = "Границ: " + this.global1.data[29].ToString();
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nВестальгия\nЕженедельно: -",
					(this.global1.data[29] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[29] % 10).ToString()
				});
				TextMesh text_55 = this.Text_3;
				text_55.text = text_55.text + "\n\nЗакрытые границы: " + (5 - this.global1.data[27] - this.global1.data[28] - this.global1.data[29]).ToString();
			}
		}
		else if (this.num_this == 3)
		{
			this.num_names = 1;
			this.Name_1.text = "Максимальная\nграница";
			this.Text_1.text = "";
			if (this.global1.data[80] - 20 < 80)
			{
				int num16 = (80 - (this.global1.data[80] - 20)) / 20;
				TextMesh text_56 = this.Text_1;
				text_56.text = text_56.text + "\nВерхний предел:\nЕдинство партии: " + (100 - num16 * 10);
				TextMesh text_57 = this.Text_1;
				text_57.text = text_57.text + "\nВерхний предел:\nПоддержка народа: " + (100 - num16 * 10);
				TextMesh text_58 = this.Text_1;
				text_58.text = text_58.text + "\nВерхний предел:\nУровень жизни: " + (100 - num16 * 10);
				TextMesh text_59 = this.Text_1;
				text_59.text = text_59.text + "\nНижний предел:\nВестальгия: " + num16 * 15;
			}
		}
		else if (this.num_this == 4)
		{
			this.num_names = 2;
			this.Name_1.text = "Советская помощь";
			this.Text_1.text = "\nИтого: " + (this.global1.data[30] / 10).ToString() + "." + Mathf.Abs(this.global1.data[30] % 10).ToString();
			this.Name_2.text = "\nТекущая\nсоветская доктрина";
			if (this.global1.data[0] == 10)
			{
				this.num_names = 3;
				this.Name_3.text = "Китайская помощь";
				this.Text_3.text = "\nИтого: " + (this.global1.data[73] / 10).ToString() + "." + Mathf.Abs(this.global1.data[73] % 10).ToString();
			}
			if (this.global1.data[21] > 1991 || (this.global1.allcountries[7].isOVD && this.global1.is_gkchp) || (this.global1.allcountries[7].paths == 3 && this.global1.event_done[1075]))
			{
				this.Text_2.text = "\n\n\nСтабилизация";
				TextMesh text_60 = this.Text_2;
				text_60.text += "\nВнешняя политика пытается";
				TextMesh text_61 = this.Text_2;
				text_61.text += "\nбыть стабилизирована.";
			}
			else if (this.global1.event_done[35] && this.global1.data[21] <= 1991 && (!this.global1.is_gkchp || (this.global1.allcountries[7].Gosstroy > 1 && this.global1.is_gkchp)))
			{
				this.Text_2.text = "\n\n\nОтказ от помощи\nсоциалистическому лагерю";
				TextMesh text_62 = this.Text_2;
				text_62.text += "\nВлияние ежемесячно:";
				TextMesh text_63 = this.Text_2;
				text_63.text += "\nСтабильность соцлагеря: -1";
				TextMesh text_64 = this.Text_2;
				text_64.text += "\nНикакой помощи!";
			}
			else if (this.global1.event_done[4] && this.global1.data[21] <= 1991 && (!this.global1.is_gkchp || (this.global1.allcountries[7].Gosstroy > 1 && this.global1.is_gkchp)))
			{
				this.Text_2.text = "\n\n\nДоктрина Синатры";
				TextMesh text_65 = this.Text_2;
				text_65.text += "\nВлияние ежемесячно:";
				TextMesh text_66 = this.Text_2;
				text_66.text += "\nСтабильность соцлагеря: -1";
				TextMesh text_67 = this.Text_2;
				text_67.text += "\nСоветская помощь: -2%";
			}
			else
			{
				this.Text_2.text = "\n\n\nДоктрина Брежнева";
				TextMesh text_68 = this.Text_2;
				text_68.text += "\nСтабильность";
			}
		}
		else if (this.num_this == 5)
		{
			this.num_names = 2;
			this.Name_1.text = "Мировоззрение";
			this.Name_2.text = "Особое влияние";
			this.Text_1.text = "Сейчас:";
			if (this.global1.data[31] > 700)
			{
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nНационализм\n(",
					(this.global1.data[31] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[31] % 10).ToString(),
					"/100)"
				});
				this.Text_2.text = "Вестальгия\nЕженедельно: -" + ((this.global1.data[31] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString();
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nПоддержка партии\nЕженедельно: +",
					((this.global1.data[31] - 500) / 100 / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
				});
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nСуверенитет\nЕженедельно: +",
					((this.global1.data[31] - 500) / 50 / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[31] - 500) / 50 % 10).ToString()
				});
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nОдобрение СССР\nЕженедельно: -",
					((this.global1.data[31] - 500) / 100 / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
				});
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nНедовольство НАТО\nЕженедельно: +",
					((this.global1.data[31] - 500) / 100 / 10).ToString(),
					".",
					Mathf.Abs((this.global1.data[31] - 500) / 100 % 10).ToString()
				});
			}
			else if (this.global1.data[31] >= 400 && this.global1.data[31] <= 700)
			{
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nПатриотизм советского типа\n(",
					(this.global1.data[31] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[31] % 10).ToString(),
					"/100)"
				});
				this.Text_2.text = "Отсутствует".ToString();
			}
			else
			{
				TextMesh textMesh = this.Text_1;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nКосмополитизм\n(",
					(this.global1.data[31] / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[31] % 10).ToString(),
					"/100)"
				});
				this.Text_2.text = "Вестальгия\nЕженедельно: +" + ((500 - this.global1.data[31]) / 100 / 10).ToString() + "." + Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString();
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nПоддержка партии\nЕженедельно: +",
					((500 - this.global1.data[31]) / 100 / 10).ToString(),
					".",
					Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString()
				});
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nСуверенитет\nЕженедельно: -",
					((500 - this.global1.data[31]) / 50 / 10).ToString(),
					".",
					Mathf.Abs((500 - this.global1.data[31]) / 50 % 10).ToString()
				});
				textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nНедовольство НАТО\nЕженедельно: -",
					((500 - this.global1.data[31]) / 100 / 10).ToString(),
					".",
					Mathf.Abs((500 - this.global1.data[31]) / 100 % 10).ToString()
				});
			}
		}
		else if (this.num_this == 6)
		{
			this.num_names = 2;
			this.Name_1.text = "Суверенитет";
			this.Name_2.text = "Особое влияние";
			this.Text_1.text = string.Concat(new string[]
			{
				"Сейчас: ",
				(this.global1.data[22] / 10).ToString(),
				".",
				Mathf.Abs(this.global1.data[22] % 10).ToString(),
				"/100"
			});
			if (this.global1.data[22] - 500 < 0)
			{
				this.Text_2.text = "Вестальгия\nЕженедельно: +" + ((this.global1.data[22] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[22] - 500) / 100 % 10).ToString();
			}
			else
			{
				this.Text_2.text = "Вестальгия\nЕженедельно: -" + ((this.global1.data[22] - 500) / 100 / 10).ToString() + "." + Mathf.Abs((this.global1.data[22] - 500) / 100 % 10).ToString();
			}
			if (this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV)
			{
				TextMesh textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nПоддержка Партии\nЕженедельно: +",
					(this.global1.data[22] / 100 / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[22] / 100 % 10).ToString()
				});
			}
			else
			{
				TextMesh textMesh = this.Text_2;
				textMesh.text = string.Concat(new string[]
				{
					textMesh.text,
					"\nПоддержка Партии\nЕженедельно: +",
					(this.global1.data[22] / 50 / 10).ToString(),
					".",
					Mathf.Abs(this.global1.data[22] / 50 % 10).ToString()
				});
			}
			TextMesh text_69 = this.Text_2;
			text_69.text += "\nТакже влияет на\nвероятность поражения.";
			if (this.global1.data[0] == 10)
			{
				this.num_names = 3;
				this.Name_3.text = "Ядерная программа";
				if (this.global1.data[100] > 0 && this.global1.event_done[255])
				{
					this.Text_3.text = "ежемесячно:\nАгенты: -0.5\nПатриотизм +0.5\nБюджет -10%";
				}
				else if (this.global1.data[100] > 0)
				{
					this.Text_3.text = "ежемесячно:\nАгенты: -0.5\nПатриотизм +0.5";
				}
				else
				{
					this.Text_3.text = "У нас её нет";
				}
			}
		}
		else if (this.num_this == 7)
		{
			this.num_names = 2;
			this.Name_1.text = "Остальгия";
			this.Name_2.text = "Особое влияние";
			if (this.global1.data[0] == 10)
			{
				this.num_names = 3;
				this.Name_3.text = "Западные санкции";
				if (this.global1.data[72] > 0)
				{
					this.Text_3.text = "Еженедельно:\nДипрепутация: +0.2;\nНедовольство НАТО: +0.2\nБюджет: -0.5\nСуверенитет: +0.2\nУровень жизни: -0.2";
				}
				else
				{
					this.Text_3.text = "Нет";
				}
			}
			else if (this.global1.data[0] == 18)
			{
				this.num_names = 3;
				this.Name_3.text = "Американское эмбарго";
				if (this.global1.data[77] > 0)
				{
					this.Text_3.text = string.Concat(new object[]
					{
						"Еженедельно:\nСуверенитет: +0.2\nБюджет: -0.",
						this.global1.data[77],
						"\nНедовольство НАТО: +0.",
						this.global1.data[77] / 2,
						"\nПоддержка народа: +0.",
						this.global1.data[77]
					});
				}
				else
				{
					this.Text_3.text = "Нет";
				}
			}
			else if (this.global1.data[0] >= 1 && this.global1.data[0] <= 6)
			{
				this.num_names = 3;
				this.Name_3.text = "Западные санкции";
				if (this.global1.data[72] > 0)
				{
					this.Text_3.text = "Еженедельно:\nДипрепутация: +0.2;\nНедовольство НАТО: +0.2\nБюджет: -0.5\nСуверенитет: +0.2";
				}
				else
				{
					this.Text_3.text = "Нет";
				}
			}
			this.Text_1.text = string.Concat(new string[]
			{
				"Недовольство граждан Запада\nи их сочуствие левым идеям:\n",
				(this.global1.allcountries[17].Westalgie / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[17].Westalgie % 10).ToString(),
				"/100"
			});
			this.Text_2.text = "Вестальгия\nЕженедельно: -" + (this.global1.allcountries[17].Westalgie / 80 / 10).ToString() + "." + Mathf.Abs(this.global1.allcountries[17].Westalgie / 80 % 10).ToString();
			TextMesh textMesh = this.Text_2;
			textMesh.text = string.Concat(new string[]
			{
				textMesh.text,
				"\nНедовольство НАТО\nЕженедельно: -",
				(this.global1.allcountries[17].Westalgie / 120 / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[17].Westalgie / 120 % 10).ToString()
			});
		}
		else if (this.num_this == 8 && this.global1.data[0] != 12)
		{
			this.num_names = 3;
			this.Name_1.text = "АЗИЯ";
			this.Name_2.text = "ЕВРОПА";
			this.Name_3.text = "АФРИКА";
			this.Text_1.text = "Контроль в Афганистане: ";
			int num17 = 30;
			if (this.global1.allcountries[7].isSEV || this.global1.allcountries[16].isSEV || this.global1.allcountries[19].Gosstroy <= 0)
			{
				num17 += 25;
			}
			if (this.global1.allcountries[31].Help)
			{
				num17 += 5;
			}
			if (this.global1.data[37] <= 6)
			{
				num17 += this.global1.data[37] * 4;
			}
			else if (this.global1.data[37] <= 8)
			{
				num17 += this.global1.data[37] * 5;
			}
			else
			{
				num17 += 40;
			}
			TextMesh text_70 = this.Text_1;
			text_70.text = text_70.text + num17.ToString() + " %";
			TextMesh text_71 = this.Text_1;
			text_71.text += "\nРазвитость НДРЙ: ";
			num17 = 40;
			if (this.global1.allcountries[24].Stasi)
			{
				num17 += 25;
			}
			if (this.global1.allcountries[24].Gosstroy == 0)
			{
				num17 += 5;
			}
			if (this.global1.data[55] <= 1)
			{
				num17 += this.global1.data[55] * 10;
			}
			else
			{
				num17 += 30;
			}
			TextMesh text_72 = this.Text_1;
			text_72.text = text_72.text + num17.ToString() + " %";
			TextMesh text_73 = this.Text_1;
			text_73.text += "\nКонтроль в Непале: ";
			TextMesh textMesh = this.Text_1;
			textMesh.text = string.Concat(new string[]
			{
				textMesh.text,
				(this.global1.allcountries[43].Westalgie / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[43].Westalgie % 10).ToString(),
				" %"
			});
			if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
			{
				this.Text_2.text = "Контроль в Югославии: ";
				num17 = 25;
				if (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD)
				{
					num17 += 20;
				}
				if (this.global1.allcountries[this.global1.data[0]].isOVD)
				{
					num17 += 20;
				}
				if (this.global1.data[54] <= 4)
				{
					num17 += this.global1.data[54] * 3;
				}
				else if (this.global1.data[54] <= 6)
				{
					num17 += this.global1.data[54] * 5;
				}
				else
				{
					num17 += 35;
				}
				if (this.global1.data[59] == 2)
				{
					num17 -= num17 / 3;
				}
				TextMesh text_74 = this.Text_2;
				text_74.text = text_74.text + num17.ToString() + " %";
				num17 = 0;
				TextMesh text_75 = this.Text_2;
				text_75.text += "\nСила фракции\n\"Союз\" в СССР: ";
				if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 0 && !this.global1.allcountries[7].Vyshi)
				{
					num17 = 100;
				}
				else if (this.global1.allcountries[7].isOVD && this.global1.allcountries[7].isSEV && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
				{
					num17 = 80;
					num17 -= this.global1.allcountries[7].Gosstroy * 15;
				}
				else if ((this.global1.allcountries[7].isSEV || this.global1.allcountries[7].isOVD) && this.global1.data[7] >= 250 && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
				{
					num17 = 60;
					num17 -= this.global1.allcountries[7].Gosstroy * 15;
				}
				else if ((this.global1.allcountries[7].isSEV && !this.global1.is_gkchp) || (this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi) || (this.global1.data[7] >= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi))
				{
					num17 = 40;
					num17 -= this.global1.allcountries[7].Gosstroy * 15;
				}
				else if ((!this.global1.allcountries[7].Vyshi && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2 && !this.global1.allcountries[7].Vyshi) || (!this.global1.is_gkchp && this.global1.data[7] <= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].Vyshi))
				{
					num17 = 20;
				}
				else if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 1 && !this.global1.allcountries[7].Vyshi)
				{
					num17 = 70;
				}
				else
				{
					num17 = num17;
				}
				num17 += this.global1.data[51] + this.global1.data[52] * 3;
				if (num17 > 100)
				{
					num17 = 100;
				}
				TextMesh text_76 = this.Text_2;
				text_76.text = text_76.text + num17.ToString() + " %";
			}
			else
			{
				this.Text_2.text = "Иди спасай Югославию!";
			}
			this.Text_3.text = "Контроль в Алжире: ";
			textMesh = this.Text_3;
			textMesh.text = string.Concat(new string[]
			{
				textMesh.text,
				(this.global1.allcountries[40].Westalgie / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[40].Westalgie % 10).ToString(),
				" %"
			});
			TextMesh text_77 = this.Text_3;
			text_77.text += "\nКонтроль в Эфиопии: ";
			textMesh = this.Text_3;
			textMesh.text = string.Concat(new string[]
			{
				textMesh.text,
				(this.global1.allcountries[41].Westalgie / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[41].Westalgie % 10).ToString(),
				" %"
			});
			TextMesh text_78 = this.Text_3;
			text_78.text += "\nКонтроль в Сомали: ";
			textMesh = this.Text_3;
			textMesh.text = string.Concat(new string[]
			{
				textMesh.text,
				(this.global1.allcountries[42].Westalgie / 10).ToString(),
				".",
				Mathf.Abs(this.global1.allcountries[42].Westalgie % 10).ToString(),
				" %"
			});
		}
		else if (this.num_this == 8)
		{
			this.num_names = 3;
			this.Name_1.text = "РЕГИОНЫ";
			this.Name_2.text = "ПОТЕРИ";
			this.Name_3.text = "БОЕВЫЕ ДЕЙСТВИЯ";
			this.Text_1.text = "Восток: " + ((this.global1.data[90] == 1) ? "Под контролем" : "Нет контроля");
			TextMesh text_79 = this.Text_1;
			text_79.text = text_79.text + "\nЗапад: " + ((this.global1.data[92] == 1) ? "Под контролем" : "Нет контроля");
			TextMesh text_80 = this.Text_1;
			text_80.text = text_80.text + "\nСевер: " + ((this.global1.data[93] == 1) ? "Под контролем" : "Нет контроля");
			TextMesh text_81 = this.Text_1;
			text_81.text = text_81.text + "\nЮг: " + ((this.global1.data[94] == 1) ? "Под контролем" : "Нет контроля");
			TextMesh textMesh = this.Text_1;
			textMesh.text = string.Concat(new object[]
			{
				textMesh.text,
				"\nИтого: ",
				this.global1.data[80],
				"%"
			});
			int num18 = 0;
			int num19 = 0;
			int num20 = 0;
			int num21 = 0;
			int num22 = 0;
			if (this.global1.data[90] != 1)
			{
				num22 -= 2;
				num20++;
				num19--;
			}
			if (this.global1.data[93] != 1)
			{
				num21 -= 2;
				num20++;
				num19--;
			}
			if (this.global1.data[92] != 1)
			{
				num18 -= 2;
				num20++;
				num19--;
			}
			if (this.global1.data[94] != 1)
			{
				num21--;
				num20++;
				num19--;
			}
			this.Text_2.text = string.Concat(new object[]
			{
				"-0.",
				num22 * -1,
				" Уровень жизни\n+0.",
				num20,
				" Вестальгия\n-0.",
				num19 * -1,
				" Поддержка народа\n-0.",
				num21 * -1,
				" Бюджет\n-0.",
				num18 * -1,
				" Агентурных сетей"
			});
			if (this.global1.data[88] == 0)
			{
				this.Text_3.text = "Всё стабильно";
			}
			else if (this.global1.data[88] == 1)
			{
				this.Text_3.text = "Нападаем: ";
			}
			else if (this.global1.data[88] == 2)
			{
				this.Text_3.text = "Обороняемся: ";
			}
			if (this.global1.data[107] == 1)
			{
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nВосток\nКонтроль: ",
					this.global1.data[108],
					"%"
				});
			}
			else if (this.global1.data[107] == 2)
			{
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nЗапад\nКонтроль: ",
					this.global1.data[108],
					"%"
				});
			}
			else if (this.global1.data[107] == 3)
			{
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nСевер\nКонтроль: ",
					this.global1.data[108],
					"%"
				});
			}
			else if (this.global1.data[107] == 4)
			{
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nЮг\nКонтроль: ",
					this.global1.data[108],
					"%"
				});
			}
			else if (this.global1.data[107] == 10)
			{
				textMesh = this.Text_3;
				textMesh.text = string.Concat(new object[]
				{
					textMesh.text,
					"\nКабул\nКонтроль: ",
					this.global1.data[108],
					"%"
				});
			}
		}
		else if (this.num_this == 9)
		{
			this.num_names = 2;
			this.Name_1.text = "Админтраты";
			this.Name_2.text = "Особое влияние";
			if (this.global1.data[0] == 10)
			{
				this.num_names = 3;
				this.Name_3.text = "Голод";
				if (this.global1.data[71] > 0)
				{
					this.Text_3.text = "Еженедельно:\nПоддержка народа: -0.5;\nЕдинство партии: -0.4\nБюджет: -0.2\nСуверенитет: -0.2";
				}
				else
				{
					this.Text_3.text = "Всё хорошо\nпока уровень жизни\nбольше 20.0";
				}
			}
			else if (this.global1.data[0] == 18)
			{
				this.num_names = 3;
				this.Name_3.text = "Особый период";
				if (this.global1.data[102] > 0)
				{
					this.Text_3.text = "Еженедельно:\nИзменяет бюджет на 0." + (this.global1.data[102] - 1);
					if (this.global1.data[5] > 400 - this.global1.data[102] * 30)
					{
						TextMesh text_82 = this.Text_3;
						text_82.text = text_82.text + "\nУровень жизни: -0." + this.global1.data[102];
					}
					if (this.global1.allcountries[this.global1.data[0]].isSEV || this.global1.allcountries[7].isSEV)
					{
						TextMesh textMesh = this.Text_3;
						textMesh.text = string.Concat(new object[]
						{
							textMesh.text,
							"\nВестальгия: +0.",
							this.global1.data[102] / 2,
							"\nПоддержка народа: -0.",
							this.global1.data[102] / 2
						});
					}
					if (!this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						TextMesh text_83 = this.Text_3;
						text_83.text = text_83.text + "\nБюджет: +0." + this.global1.data[102] * 2;
					}
				}
				else
				{
					this.Text_3.text = "Всё хорошо";
				}
			}
			else if (this.global1.data[0] >= 1 && this.global1.data[0] <= 6)
			{
				this.num_names = 3;
				this.Name_3.text = "Карточная система";
				if (this.global1.data[71] > 0)
				{
					int num23 = 0;
					for (int num24 = 0; num24 < this.global1.science.Length; num24++)
					{
						if (this.global1.science[num24])
						{
							num23++;
						}
					}
					this.Text_3.text = "Еженедельно:\nПоддержка народа: -0.5;\nЕдинство партии: -0.4\nБюджет: -0.2\n";
					TextMesh text_84 = this.Text_3;
					text_84.text = text_84.text + "пока уровень жизни\nменьше " + (49 - num23);
				}
				else
				{
					int num25 = 0;
					for (int num26 = 0; num26 < this.global1.science.Length; num26++)
					{
						if (this.global1.science[num26])
						{
							num25++;
						}
					}
					this.Text_3.text = "Всё хорошо\nпока уровень жизни\nбольше " + (35 - num25);
				}
			}
			this.Text_1.text = "Текущий размер:\n" + this.global1.data[63].ToString();
			if (this.global1.data[21] <= 1991)
			{
				if (this.global1.science[5])
				{
					TextMesh text_85 = this.Text_1;
					text_85.text = text_85.text + "\nМинимальный размер:\n" + ((this.global1.data[21] - 1989) * 2).ToString();
				}
				else if (this.global1.science[4])
				{
					TextMesh text_86 = this.Text_1;
					text_86.text = text_86.text + "\nМинимальный размер:\n" + ((this.global1.data[21] - 1988) * 2).ToString();
				}
				else if (this.global1.science[3])
				{
					TextMesh text_87 = this.Text_1;
					text_87.text = text_87.text + "\nМинимальный размер:\n" + ((this.global1.data[21] - 1987) * 2).ToString();
				}
				else
				{
					TextMesh text_88 = this.Text_1;
					text_88.text = text_88.text + "\nМинимальный размер:\n" + ((this.global1.data[21] - 1986) * 2).ToString();
				}
			}
			TextMesh text_89 = this.Text_1;
			text_89.text += "\nПовышается от заключенных\nторговых сделок и\nдействий на политической\nкарте.";
			this.Text_2.text = "Сокращение бюджета\nЕжемесячно: -" + (this.global1.data[63] / 2 / 10).ToString() + "." + Mathf.Abs(this.global1.data[63] / 2 % 10).ToString();
			TextMesh text_90 = this.Text_2;
			text_90.text += "\nСокращение трат\nЕжемесячно: - 4";
		}
		if (this.num_names != 3)
		{
			if (this.num_names == 2)
			{
				this.Name_3.text = null;
				this.Text_3.text = null;
				return;
			}
			if (this.num_names == 1)
			{
				this.Name_3.text = null;
				this.Text_3.text = null;
				this.Name_2.text = null;
				this.Text_2.text = null;
			}
		}
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00069CAD File Offset: 0x00067EAD
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00069CC0 File Offset: 0x00067EC0
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00069CD4 File Offset: 0x00067ED4
	private string Text(string text, int col)
	{
		int num = 0;
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			if (num >= col)
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

	// Token: 0x0400017F RID: 383
	public GlobalScript global1;

	// Token: 0x04000180 RID: 384
	public Sprite on;

	// Token: 0x04000181 RID: 385
	public Sprite off;

	// Token: 0x04000182 RID: 386
	public int num_this;

	// Token: 0x04000183 RID: 387
	public int num_names;

	// Token: 0x04000184 RID: 388
	public TextMesh Name_1;

	// Token: 0x04000185 RID: 389
	public TextMesh Name_2;

	// Token: 0x04000186 RID: 390
	public TextMesh Name_3;

	// Token: 0x04000187 RID: 391
	public TextMesh Text_1;

	// Token: 0x04000188 RID: 392
	public TextMesh Text_2;

	// Token: 0x04000189 RID: 393
	public TextMesh Text_3;
}
