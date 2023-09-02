using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class BuildSelectScript : MonoBehaviour
{
	// Token: 0x06000024 RID: 36 RVA: 0x000087CC File Offset: 0x000069CC
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00008838 File Offset: 0x00006A38
	public void Repaint()
	{
		base.transform.Find("image").GetComponent<SpriteRenderer>().sprite = this.buildmanager1.sprites[this.this_type];
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.text_fake = this.buildmanager1.types_names_en[this.this_type];
			base.transform.Find("Uslovie").GetComponent<TextMesh>().text = this.buildmanager1.usloviya_en[this.this_type];
		}
		else
		{
			this.text_fake = this.buildmanager1.types_names_ru[this.this_type];
			base.transform.Find("Uslovie").GetComponent<TextMesh>().text = this.buildmanager1.usloviya_ru[this.this_type];
		}
		base.transform.Find("Name").GetComponent<TextMesh>().text = this.Text(this.text_fake, 20);
		if (this.this_type == 1)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет +0.1;\nУровень жизни +0.1;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget +0.1;\nStandard of living +0.1;";
			return;
		}
		if (this.this_type == 2)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет +0.2; Вестальгия +0.1;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget +0.2; Westalgia +0.1;";
			return;
		}
		if (this.this_type == 3)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.2; Вестальгия -0.1;\nУровень жизни +0.1;\nРазвивает науку;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.2; Westalgia -0.1;\nStandard of living +0.1;\nDevelops science;";
			return;
		}
		if (this.this_type == 4)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.2; Вестальгия -0.2;\nАгентурная сеть +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.2; Westalgia -0.2;\nAgent networks +0.2;";
			return;
		}
		if (this.this_type == 5)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Поддержка народа +0.2; Вестальгия +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> Support of the people +0.2; Westalgia +0.2;";
			return;
		}
		if (this.this_type == 6)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Каждые 2 месяца:</color> Деньги +0.1;\nВестальгия +0.1;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Every 2 month:</color> The budget +0.1;\nWestalgia +0.1;";
			return;
		}
		if (this.this_type == 7)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Нельзя в столице, 1 на регион.</color>\n";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>Not in the capital, 1 per region.</color>\n";
			OkoshkoScript component = base.GetComponent<OkoshkoScript>();
			component.text += "<color=yellow>Еженедельно:</color>\nЕдинство Партии +0.1; Поддержка народа +0.1;\nНедовольство НАТО +0.2; Одобрение СССР -0.2;";
			OkoshkoScript component2 = base.GetComponent<OkoshkoScript>();
			component2.text_en += "<color=yellow>Weekly:</color>\nUnity of the Party +0.1; Support of the people +0.1;\nDissatisfaction of NATO +0.2; Approval from the USSR -0.2;";
			return;
		}
		if (this.this_type == 8)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.2; Вестальгия -0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.2; Westalgia -0.2;";
			return;
		}
		if (this.this_type == 9)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.1;\nРазвивает науку;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.1;\nDevelops science;";
			return;
		}
		if (this.this_type == 10)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.2; Агентурная сеть +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.2; Agent networks +0.2;";
			return;
		}
		if (this.this_type == 11)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет -0.2; Поддержка народа +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget -0.2; Support of the people +0.2;";
			return;
		}
		if (this.this_type == 12)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Одобрение СССР -0.1; Вестальгия -0.2;\nАгентурная сеть +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> Approval from the USSR -0.1; Westalgia -0.2;\nAgent networks +0.2;";
			return;
		}
		if (this.this_type == 13)
		{
			base.GetComponent<OkoshkoScript>().text = string.Concat(new string[]
			{
				"Еженедельно: Единство Партии +0.4; Бюджет +0.1; \nПоддержка народа ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				"; Вестальгия ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				";"
			});
			base.GetComponent<OkoshkoScript>().text_en = string.Concat(new string[]
			{
				"Weekly: Unity of the Party +0.4; The budget +0.1; \nSupport of the people ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				"; Westalgia ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				";"
			});
			return;
		}
		if (this.this_type == 14)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Единство Партии +0.4; Суверенитет +0.2;\nНедовольство НАТО +0.1; Одобрение СССР -0.1;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> Unity of the Party +0.4; Sovereignity +0.2;\nDissatisfaction of NATO +0.1; Approval from the USSR -0.1;";
			return;
		}
		if (this.this_type == 15)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=yellow>Еженедельно:</color> Бюджет +0.3; Вестальгия +0.1;\nУровень жизни +0.2;";
			base.GetComponent<OkoshkoScript>().text_en = "<color=yellow>Weekly:</color> The budget +0.3; Westalgia +0.1.;\nStandard of living +0.2;";
			return;
		}
		if (this.this_type == 17)
		{
			if (this.global1.data[14] < 3)
			{
				base.GetComponent<OkoshkoScript>().text = "Ежемесячно: Поддержка народа +0.1;";
				base.GetComponent<OkoshkoScript>().text_en = "Monthly: Support of the people +0.1;";
			}
			else if (this.global1.data[14] > 3)
			{
				base.GetComponent<OkoshkoScript>().text = "Ежемесячно: Поддержка народа -0.1;";
				base.GetComponent<OkoshkoScript>().text_en = "Monthly: Support of the people -0.1;";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text = "Ничего;";
				base.GetComponent<OkoshkoScript>().text_en = "Nothing;";
			}
			OkoshkoScript component3 = base.GetComponent<OkoshkoScript>();
			component3.text += "\n<color=red>1 на регион</color>";
			OkoshkoScript component4 = base.GetComponent<OkoshkoScript>();
			component4.text_en += "\n<color=red>1 per region</color>";
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00008E08 File Offset: 0x00007008
	private void OnMouseDown()
	{
		if (this.buildmanager1.now_region != 2 && (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51))
		{
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].level + 5 > this.buildmanager1.selected_thing)
			{
				if (!this.buildmanager1.yugown[0])
				{
					this.Vyzov.text = this.yug1.science_text[65];
					return;
				}
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].level + 5 > this.buildmanager1.selected_thing)
			{
				if (!this.buildmanager1.yugown[1])
				{
					this.Vyzov.text = this.yug1.science_text[65];
					return;
				}
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].level + 5 > this.buildmanager1.selected_thing && !this.buildmanager1.yugown[2])
			{
				this.Vyzov.text = this.yug1.science_text[65];
				return;
			}
		}
		if (this.buildmanager1.selected_thing != -1)
		{
			if (this.global1.data[8] >= 25)
			{
				if (this.this_type == 1 || this.this_type == 3)
				{
					this.global1.data[8] -= 80;
					this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
					this.buildmanager1.selected_thing = -1;
					this.buildmanager1.HideSelects();
					this.Vyzov.text = "";
				}
				else if (this.this_type == 6)
				{
					if (this.global1.data[16] > 11)
					{
						this.global1.data[8]--;
						this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
						this.buildmanager1.selected_thing = -1;
						this.buildmanager1.HideSelects();
					}
				}
				else if (this.this_type == 7)
				{
					if (this.buildmanager1.now_region != 2)
					{
						bool flag = false;
						if (!flag)
						{
							for (int i = 0; i < 15; i++)
							{
								if (this.global1.regions[this.buildmanager1.now_region].buildings[i].type == 7 && this.global1.regions[this.buildmanager1.now_region].buildings[i].is_builded && this.global1.regions[this.buildmanager1.now_region].buildings[i].is_working)
								{
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							this.global1.data[8] -= 100;
							this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
							this.buildmanager1.selected_thing = -1;
							this.buildmanager1.HideSelects();
							this.Vyzov.text = "";
						}
						else if (PlayerPrefs.GetInt("language") == 0)
						{
							this.Vyzov.text = "Only one";
						}
						else
						{
							this.Vyzov.text = "Только один";
						}
					}
					else if (PlayerPrefs.GetInt("language") == 0)
					{
						this.Vyzov.text = "This is the capital";
					}
					else
					{
						this.Vyzov.text = "Вы сейчас в столице";
					}
				}
				else if (this.this_type == 9)
				{
					int num = 0;
					for (int j = 0; j < 15; j++)
					{
						if (this.global1.regions[this.buildmanager1.now_region].buildings[j].type == 9 && this.global1.regions[this.buildmanager1.now_region].buildings[j].is_builded)
						{
							num++;
							if (num >= this.global1.regions[this.buildmanager1.now_region].city_level)
							{
								break;
							}
						}
					}
					if (num >= this.global1.regions[this.buildmanager1.now_region].city_level)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.Vyzov.text = "1 per each\ncity level";
						}
						else
						{
							this.Vyzov.text = "1 за каждый\nуровень города";
						}
					}
					else
					{
						this.global1.data[8] -= 50;
						this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
						this.buildmanager1.selected_thing = -1;
						this.buildmanager1.HideSelects();
						this.Vyzov.text = "";
					}
				}
				else if (this.this_type == 4)
				{
					int num2 = 0;
					if (this.global1.regions[this.buildmanager1.now_region].city_level % 2 == 1)
					{
						for (int k = 0; k < 15; k++)
						{
							if (this.global1.regions[this.buildmanager1.now_region].buildings[k].type == 4 && this.global1.regions[this.buildmanager1.now_region].buildings[k].is_builded)
							{
								num2++;
								if (num2 >= (this.global1.regions[this.buildmanager1.now_region].city_level + 1) / 2)
								{
									break;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < 15; l++)
						{
							if (this.global1.regions[this.buildmanager1.now_region].buildings[l].type == 4 && this.global1.regions[this.buildmanager1.now_region].buildings[l].is_builded)
							{
								num2++;
								if (num2 >= this.global1.regions[this.buildmanager1.now_region].city_level / 2)
								{
									break;
								}
							}
						}
					}
					if ((this.global1.regions[this.buildmanager1.now_region].city_level % 2 == 1 && num2 >= (this.global1.regions[this.buildmanager1.now_region].city_level + 1) / 2) || (this.global1.regions[this.buildmanager1.now_region].city_level % 2 == 0 && num2 >= this.global1.regions[this.buildmanager1.now_region].city_level / 2))
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.Vyzov.text = "1 per each 2nd\ncity level";
						}
						else
						{
							this.Vyzov.text = "1 за каждый 2-й\nуровень города";
						}
					}
					else
					{
						this.global1.data[8] -= 80;
						this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
						this.buildmanager1.selected_thing = -1;
						this.buildmanager1.HideSelects();
						this.Vyzov.text = "";
					}
				}
				else if (this.this_type == 17)
				{
					bool flag2 = false;
					if (!flag2)
					{
						for (int m = 0; m < 15; m++)
						{
							if (this.global1.regions[this.buildmanager1.now_region].buildings[m].type == 17 && this.global1.regions[this.buildmanager1.now_region].buildings[m].is_builded && this.global1.regions[this.buildmanager1.now_region].buildings[m].is_working)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						if (this.global1.data[14] < 5)
						{
							this.global1.data[8] -= 25;
							this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
							this.buildmanager1.selected_thing = -1;
							this.buildmanager1.HideSelects();
						}
						this.Vyzov.text = "";
					}
					else if (PlayerPrefs.GetInt("language") == 0)
					{
						this.Vyzov.text = "Only one";
					}
					else
					{
						this.Vyzov.text = "Только один";
					}
				}
				else if (this.this_type == 2)
				{
					this.global1.data[8] -= 40;
					this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
					this.buildmanager1.selected_thing = -1;
					this.buildmanager1.HideSelects();
					this.Vyzov.text = "";
				}
				else
				{
					this.global1.data[8] -= 50;
					this.buildmanager1.buildings[this.buildmanager1.selected_thing].BuildThis(this.this_type);
					this.buildmanager1.selected_thing = -1;
					this.buildmanager1.HideSelects();
					this.Vyzov.text = "";
				}
				base.GetComponent<OkoshkoScript>().OnMouseExit();
				return;
			}
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.Vyzov.text = "Too little money";
				return;
			}
			this.Vyzov.text = "Слишком мало денег";
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000980C File Offset: 0x00007A0C
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

	// Token: 0x0400002B RID: 43
	public int this_type;

	// Token: 0x0400002C RID: 44
	private GlobalScript global1;

	// Token: 0x0400002D RID: 45
	public BuildingManager buildmanager1;

	// Token: 0x0400002E RID: 46
	private string text_fake;

	// Token: 0x0400002F RID: 47
	public TextMesh Vyzov;

	// Token: 0x04000030 RID: 48
	private Yugoglobal yug1;
}
