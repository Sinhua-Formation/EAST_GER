using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class BuildingScript : MonoBehaviour
{
	// Token: 0x06000017 RID: 23 RVA: 0x00002AD8 File Offset: 0x00000CD8
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002B44 File Offset: 0x00000D44
	public void Repaint()
	{
		if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded)
		{
			base.transform.Find("image").GetComponent<SpriteRenderer>().sprite = this.buildmanager1.sprites[this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type];
		}
		else if (this.this_number > 3 * this.global1.regions[this.buildmanager1.now_region].city_level - 1)
		{
			base.transform.Find("image").GetComponent<SpriteRenderer>().sprite = this.buildmanager1.empty_build;
		}
		else
		{
			base.transform.Find("image").GetComponent<SpriteRenderer>().sprite = this.buildmanager1.sprites[0];
		}
		if (this.buildmanager1.now_region == 2)
		{
			this.TextRepaint();
			return;
		}
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].level + 5 > this.this_number)
			{
				if (!this.buildmanager1.yugown[0])
				{
					base.GetComponent<OkoshkoScript>().text = "Владелец: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].owner].name + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].name;
					base.GetComponent<OkoshkoScript>().text_en = "Owner: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].owner].name + "\nRegion: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].name;
					return;
				}
				this.TextRepaint();
				return;
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].level + 5 > this.this_number)
			{
				if (!this.buildmanager1.yugown[1])
				{
					base.GetComponent<OkoshkoScript>().text = "Владелец: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].owner].name + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].name;
					base.GetComponent<OkoshkoScript>().text_en = "Owner: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].owner].name + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].name;
					return;
				}
				this.TextRepaint();
				return;
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].level + 5 > this.this_number)
			{
				if (!this.buildmanager1.yugown[2])
				{
					base.GetComponent<OkoshkoScript>().text = "Владелец: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].owner].name + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].name;
					base.GetComponent<OkoshkoScript>().text_en = "Owner: " + this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].owner].name + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].name;
					return;
				}
				this.TextRepaint();
				return;
			}
		}
		else
		{
			this.TextRepaint();
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00003034 File Offset: 0x00001234
	private void TextRepaint()
	{
		if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded && this.this_number <= 3 * this.global1.regions[this.buildmanager1.now_region].city_level - 1)
		{
			base.GetComponent<OkoshkoScript>().text = "Пусто";
			base.GetComponent<OkoshkoScript>().text_en = "Empty";
			return;
		}
		if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded && this.this_number > 3 * this.global1.regions[this.buildmanager1.now_region].city_level - 1)
		{
			base.GetComponent<OkoshkoScript>().text = "Нет мест";
			base.GetComponent<OkoshkoScript>().text_en = "No places";
			return;
		}
		if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Приватизировано</color>\nЕжемесячно Вестальгии: +0." + (13 - this.global1.data[16]) + "\n";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>Privatized</color>\nWestalgia monthly: +0." + (13 - this.global1.data[16]) + "\n";
		}
		else if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Приостановлено</color>\n";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>Stopped</color>\n";
		}
		else
		{
			base.GetComponent<OkoshkoScript>().text = "<color=lime>Работает</color>\n";
			base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Working</color>\n";
		}
		if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1)
		{
			if (this.global1.data[0] != 18)
			{
				OkoshkoScript component = base.GetComponent<OkoshkoScript>();
				component.text += "<color=yellow>Сельхоз учреждение\n</color>";
				OkoshkoScript component2 = base.GetComponent<OkoshkoScript>();
				component2.text_en += "<color=yellow>Agricultural estaBlishment\n</color>";
			}
			else
			{
				OkoshkoScript component3 = base.GetComponent<OkoshkoScript>();
				component3.text += "<color=yellow>Плантация\n</color>";
				OkoshkoScript component4 = base.GetComponent<OkoshkoScript>();
				component4.text_en += "<color=yellow>Plantation\n</color>";
			}
			OkoshkoScript component5 = base.GetComponent<OkoshkoScript>();
			component5.text += "Еженедельно: Бюджет +0.1;\nУровень жизни +0.1;";
			OkoshkoScript component6 = base.GetComponent<OkoshkoScript>();
			component6.text_en += "Weekly: The budget +0.1;\nStandard of living +0.1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2)
		{
			OkoshkoScript component7 = base.GetComponent<OkoshkoScript>();
			component7.text += "<color=yellow>Промышленность\n</color>";
			OkoshkoScript component8 = base.GetComponent<OkoshkoScript>();
			component8.text_en += "<color=yellow>Industry\n</color>";
			OkoshkoScript component9 = base.GetComponent<OkoshkoScript>();
			component9.text += "Еженедельно: Бюджет +0.2; Вестальгия +0.1;";
			OkoshkoScript component10 = base.GetComponent<OkoshkoScript>();
			component10.text_en += "Weekly: The budget +0.2; Westalgia +0.1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3)
		{
			OkoshkoScript component11 = base.GetComponent<OkoshkoScript>();
			component11.text += "<color=yellow>Завод электроники\n</color>";
			OkoshkoScript component12 = base.GetComponent<OkoshkoScript>();
			component12.text_en += "<color=yellow>Factory of electronics\n</color>";
			OkoshkoScript component13 = base.GetComponent<OkoshkoScript>();
			component13.text += "Еженедельно: Бюджет -0.2; Вестальгия -0.1;\nУровень жизни +0.1;\nРазвивает науку;";
			OkoshkoScript component14 = base.GetComponent<OkoshkoScript>();
			component14.text_en += "Weekly: The budget -0.2; Westalgia -0.1;\nStandard of living +0.1;\nDevelops science;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 4)
		{
			OkoshkoScript component15 = base.GetComponent<OkoshkoScript>();
			component15.text += "<color=yellow>Военная база\n</color>";
			OkoshkoScript component16 = base.GetComponent<OkoshkoScript>();
			component16.text_en += "<color=yellow>Army Base\n</color>";
			OkoshkoScript component17 = base.GetComponent<OkoshkoScript>();
			component17.text += "Еженедельно: Бюджет -0.2; Вестальгия -0.2;\nАгентурная сеть +0.2;";
			OkoshkoScript component18 = base.GetComponent<OkoshkoScript>();
			component18.text_en += "Weekly: The budget -0.2; Westalgia -0.2;\nAgent networks +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5)
		{
			OkoshkoScript component19 = base.GetComponent<OkoshkoScript>();
			component19.text += "<color=yellow>Алкогольный завод\n</color>";
			OkoshkoScript component20 = base.GetComponent<OkoshkoScript>();
			component20.text_en += "<color=yellow>Alcohol factory\n</color>";
			OkoshkoScript component21 = base.GetComponent<OkoshkoScript>();
			component21.text += "Еженедельно: Поддержка народа +0.2; Вестальгия +0.2;";
			OkoshkoScript component22 = base.GetComponent<OkoshkoScript>();
			component22.text_en += "Weekly: Support of the people +0.2; Westalgia +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 6)
		{
			OkoshkoScript component23 = base.GetComponent<OkoshkoScript>();
			component23.text += "<color=yellow>Частное предприятие\n</color>";
			OkoshkoScript component24 = base.GetComponent<OkoshkoScript>();
			component24.text_en += "<color=yellow>Private sector\n</color>";
			OkoshkoScript component25 = base.GetComponent<OkoshkoScript>();
			component25.text += "Каждые 2 месяца: Деньги +0.1;\nВестальгия +0.1;";
			OkoshkoScript component26 = base.GetComponent<OkoshkoScript>();
			component26.text_en += "Every 2 month: The budget +0.1;\nWestalgia +0.1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 7)
		{
			OkoshkoScript component27 = base.GetComponent<OkoshkoScript>();
			component27.text += "<color=yellow>Ядерный полигон\n</color>";
			OkoshkoScript component28 = base.GetComponent<OkoshkoScript>();
			component28.text_en += "<color=yellow>Nuclear Test Site\n</color>";
			OkoshkoScript component29 = base.GetComponent<OkoshkoScript>();
			component29.text += "Еженедельно:\nЕдинство Партии +0.1; Поддержка народа +0.1;\nНедовольство НАТО +0.2; Одобрение СССР -0.2;";
			OkoshkoScript component30 = base.GetComponent<OkoshkoScript>();
			component30.text_en += "Weekly:\nUnity of the Party +0.1; Support of the people +0.1;\nDissatisfaction of NATO +0.2; Approval from the USSR -0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 8)
		{
			OkoshkoScript component31 = base.GetComponent<OkoshkoScript>();
			component31.text += "<color=yellow>Штаб-квартира спецслужб\n</color>";
			OkoshkoScript component32 = base.GetComponent<OkoshkoScript>();
			component32.text_en += "<color=yellow>Special Services Headquarter\n</color>";
			OkoshkoScript component33 = base.GetComponent<OkoshkoScript>();
			component33.text += "Еженедельно: Бюджет -0.2; Вестальгия -0.2;";
			OkoshkoScript component34 = base.GetComponent<OkoshkoScript>();
			component34.text_en += "Weekly: The budget -0.2; Westalgia -0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 9)
		{
			OkoshkoScript component35 = base.GetComponent<OkoshkoScript>();
			component35.text += "<color=yellow>НИИ\n</color>";
			OkoshkoScript component36 = base.GetComponent<OkoshkoScript>();
			component36.text_en += "<color=yellow>Research Institute\n</color>";
			OkoshkoScript component37 = base.GetComponent<OkoshkoScript>();
			component37.text += "Еженедельно: Бюджет -0.1;\nРазвивает науку;";
			OkoshkoScript component38 = base.GetComponent<OkoshkoScript>();
			component38.text_en += "Weekly: The budget -0.1;\nDevelops science;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 10)
		{
			OkoshkoScript component39 = base.GetComponent<OkoshkoScript>();
			component39.text += "<color=yellow>Штаб внешней разведки\n</color>";
			OkoshkoScript component40 = base.GetComponent<OkoshkoScript>();
			component40.text_en += "<color=yellow>Foreign Intelligence Department\n</color>";
			OkoshkoScript component41 = base.GetComponent<OkoshkoScript>();
			component41.text += "Еженедельно: Бюджет -0.2; Агентурная сеть +0.2;";
			OkoshkoScript component42 = base.GetComponent<OkoshkoScript>();
			component42.text_en += "Weekly: The budget -0.2; Agent networks +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 11)
		{
			OkoshkoScript component43 = base.GetComponent<OkoshkoScript>();
			component43.text += "<color=yellow>Телецентр\n</color>";
			OkoshkoScript component44 = base.GetComponent<OkoshkoScript>();
			component44.text_en += "<color=yellow>TV Center\n</color>";
			OkoshkoScript component45 = base.GetComponent<OkoshkoScript>();
			component45.text += "Еженедельно: Бюджет -0.2; Поддержка народа +0.2;";
			OkoshkoScript component46 = base.GetComponent<OkoshkoScript>();
			component46.text_en += "Weekly: The budget -0.2; Support of the people +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 12)
		{
			OkoshkoScript component47 = base.GetComponent<OkoshkoScript>();
			component47.text += "<color=yellow>Берлинская стена\n</color>";
			OkoshkoScript component48 = base.GetComponent<OkoshkoScript>();
			component48.text_en += "<color=yellow>Berlin Wall\n</color>";
			OkoshkoScript component49 = base.GetComponent<OkoshkoScript>();
			component49.text += "Еженедельно: Одобрение СССР -0.1; Вестальгия -0.2;\nАгентурная сеть +0.2;";
			OkoshkoScript component50 = base.GetComponent<OkoshkoScript>();
			component50.text_en += "Weekly: Approval from the USSR -0.1; Westalgia -0.2;\nAgent networks +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 13)
		{
			OkoshkoScript component51 = base.GetComponent<OkoshkoScript>();
			component51.text += "<color=yellow>Бузлуджа\n</color>";
			OkoshkoScript component52 = base.GetComponent<OkoshkoScript>();
			component52.text_en += "<color=yellow>Buzludzha\n</color>";
			OkoshkoScript component53 = base.GetComponent<OkoshkoScript>();
			component53.text = string.Concat(new string[]
			{
				component53.text,
				"Еженедельно: Единство Партии +0.4; Бюджет +0.1; \nПоддержка народа ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				"; Вестальгия ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				";"
			});
			component53 = base.GetComponent<OkoshkoScript>();
			component53.text_en = string.Concat(new string[]
			{
				component53.text_en,
				"Weekly: Unity of the Party +0.4; The budget +0.1; \nSupport of the people ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				"; Westalgia ",
				(this.global1.data[1] < 500) ? "0." : "+0.",
				((this.global1.data[1] - 500) / 250).ToString(),
				";"
			});
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 14)
		{
			OkoshkoScript component54 = base.GetComponent<OkoshkoScript>();
			component54.text += "<color=yellow>Институт атомной энергетики\n</color>";
			OkoshkoScript component55 = base.GetComponent<OkoshkoScript>();
			component55.text_en += "<color=yellow>Nuclear Power Institute\n</color>";
			OkoshkoScript component56 = base.GetComponent<OkoshkoScript>();
			component56.text += "Еженедельно: Единство Партии +0.4; Суверенитет +0.2;\nНедовольство НАТО +0.1; Одобрение СССР -0.1;";
			OkoshkoScript component57 = base.GetComponent<OkoshkoScript>();
			component57.text_en += "Weekly: Unity of the Party +0.4; Sovereignity +0.2;\nDissatisfaction of NATO +0.1; Approval from the USSR -0.1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15)
		{
			OkoshkoScript component58 = base.GetComponent<OkoshkoScript>();
			component58.text += "<color=yellow>Генномодифицированная ферма\n</color>";
			OkoshkoScript component59 = base.GetComponent<OkoshkoScript>();
			component59.text_en += "<color=yellow>Genetically modified farm\n</color>";
			OkoshkoScript component60 = base.GetComponent<OkoshkoScript>();
			component60.text += "Еженедельно: Бюджет +0.3; Вестальгия +0.1;\nУровень жизни +0.2;";
			OkoshkoScript component61 = base.GetComponent<OkoshkoScript>();
			component61.text_en += "Weekly: The budget +0.3; Westalgia +0.1.;\nStandard of living +0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 16)
		{
			OkoshkoScript component62 = base.GetComponent<OkoshkoScript>();
			component62.text += "<color=yellow>Киберсин\n</color>";
			OkoshkoScript component63 = base.GetComponent<OkoshkoScript>();
			component63.text_en += "<color=yellow>Cybersyn\n</color>";
			OkoshkoScript component64 = base.GetComponent<OkoshkoScript>();
			component64.text += "Еженедельно: Бюджет +0.2; Вестальгия -0.1;\nУровень жизни +0.1;\nРазвивает науку;";
			OkoshkoScript component65 = base.GetComponent<OkoshkoScript>();
			component65.text_en += "Weekly: The budget +0.2; Westalgia -0.1;\nStandard of living +0.1;\nDevelops science;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 17)
		{
			OkoshkoScript component66 = base.GetComponent<OkoshkoScript>();
			component66.text += "<color=yellow>Площадь Ленина\n</color>";
			OkoshkoScript component67 = base.GetComponent<OkoshkoScript>();
			component67.text_en += "<color=yellow>Lenin Square\n</color>";
			OkoshkoScript component68 = base.GetComponent<OkoshkoScript>();
			component68.text += "<color=red>1 на регион\n</color>";
			OkoshkoScript component69 = base.GetComponent<OkoshkoScript>();
			component69.text_en += "<color=red>1 per region\n</color>";
			if (this.global1.data[14] < 3)
			{
				OkoshkoScript component70 = base.GetComponent<OkoshkoScript>();
				component70.text += "Ежемесячно: Поддержка народа +0.1;";
				OkoshkoScript component71 = base.GetComponent<OkoshkoScript>();
				component71.text_en += "Monthly: Support of the people +0.1;";
			}
			else if (this.global1.data[14] > 3)
			{
				OkoshkoScript component72 = base.GetComponent<OkoshkoScript>();
				component72.text += "Ежемесячно: Поддержка народа -0.1;";
				OkoshkoScript component73 = base.GetComponent<OkoshkoScript>();
				component73.text_en += "Monthly: Support of the people -0.1;";
			}
			else
			{
				OkoshkoScript component74 = base.GetComponent<OkoshkoScript>();
				component74.text += "Ничего;";
				OkoshkoScript component75 = base.GetComponent<OkoshkoScript>();
				component75.text_en += "Nothing;";
			}
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 18)
		{
			OkoshkoScript component76 = base.GetComponent<OkoshkoScript>();
			component76.text += "<color=yellow>Соляная шахта (Величка)\n</color>";
			OkoshkoScript component77 = base.GetComponent<OkoshkoScript>();
			component77.text_en += "<color=yellow>Wieliczka Salt Mine\n</color>";
			OkoshkoScript component78 = base.GetComponent<OkoshkoScript>();
			component78.text += "Еженедельно: Бюджет +0.3;\nПоддержка народа +0.1; \nНедовольство НАТО -0.1;";
			OkoshkoScript component79 = base.GetComponent<OkoshkoScript>();
			component79.text_en += "Weekly: The budget +0.3;\nSupport of the people +0.1;\nDissatisfaction of NATO -0.1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 19)
		{
			OkoshkoScript component80 = base.GetComponent<OkoshkoScript>();
			component80.text += "<color=yellow>Országház\n</color>";
			OkoshkoScript component81 = base.GetComponent<OkoshkoScript>();
			component81.text_en += "<color=yellow>Országház\n</color>";
			OkoshkoScript component82 = base.GetComponent<OkoshkoScript>();
			component82.text += "Еженедельно: Единство партии +0.3;\nСуверенитет +0.1; Вестальгия +0.3\nНедовольство НАТО -0.1; Одобрение СССР +0.1";
			OkoshkoScript component83 = base.GetComponent<OkoshkoScript>();
			component83.text_en += "Weekly: Unity of the Party +0.3;\nSovereignity +0.1; Westalgia +0.3\nDissatisfaction of NATO -0.1; Approval from the USSR +0.1";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 20)
		{
			OkoshkoScript component84 = base.GetComponent<OkoshkoScript>();
			component84.text += "<color=yellow>Автомобильный мегаконцерн\n</color>";
			OkoshkoScript component85 = base.GetComponent<OkoshkoScript>();
			component85.text_en += "<color=yellow>Automobile megaconcern\n</color>";
			OkoshkoScript component86 = base.GetComponent<OkoshkoScript>();
			component86.text += "Еженедельно: Поддержка народа +0.2;\nВестальгия -0.2; \nУровень жизни +0.1; Бюджет - 0.3";
			OkoshkoScript component87 = base.GetComponent<OkoshkoScript>();
			component87.text_en += "Weekly: Support of the people +0.2;\nWestalgia -0.2;\nStandard of living +0.1; The budget - 0.3";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 21)
		{
			OkoshkoScript component88 = base.GetComponent<OkoshkoScript>();
			component88.text += "<color=yellow>Сеть бункеров\n</color>";
			OkoshkoScript component89 = base.GetComponent<OkoshkoScript>();
			component89.text_en += "<color=yellow>Line of bunkers\n</color>";
			OkoshkoScript component90 = base.GetComponent<OkoshkoScript>();
			component90.text += "Ежемесячно: Бюджет - 0.5;\nУровень жизни -1; Суверенитет +0.5;\nВестальгия +3; Агентурная сеть +1;";
			OkoshkoScript component91 = base.GetComponent<OkoshkoScript>();
			component91.text_en += "Monthly: The budget - 0.5;\nStandard of living -1; Sovereignity +0.5\nWestalgia +3; Agent networks +1;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 22)
		{
			OkoshkoScript component92 = base.GetComponent<OkoshkoScript>();
			component92.text += "<color=yellow>Монумент идей Чучхе\n</color>";
			OkoshkoScript component93 = base.GetComponent<OkoshkoScript>();
			component93.text_en += "<color=yellow>Juche Tower\n</color>";
			OkoshkoScript component94 = base.GetComponent<OkoshkoScript>();
			component94.text += "Еженедельно: Поддержка народа +0.2;\nБюджет -0.1; Вестальгия -0.2;";
			OkoshkoScript component95 = base.GetComponent<OkoshkoScript>();
			component95.text_en += "Weekly: Support of the people +0.2;\nThe budget - 0.1; Westalgia -0.2;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 24)
		{
			OkoshkoScript component96 = base.GetComponent<OkoshkoScript>();
			component96.text += "<color=yellow>Генеральный штаб\n</color>";
			OkoshkoScript component97 = base.GetComponent<OkoshkoScript>();
			component97.text_en += "<color=yellow>General staff\n</color>";
			OkoshkoScript component98 = base.GetComponent<OkoshkoScript>();
			component98.text += "Еженедельно: Поддержка народа +0.2;\nАгентурная сеть +0.5; Единство партии +0.4;";
			OkoshkoScript component99 = base.GetComponent<OkoshkoScript>();
			component99.text_en += "Weekly: Support of the people +0.2;\nAgent networks +0.5; Unity of the Party +0.4;";
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 23)
		{
			if (!this.global1.allcountries[7].Vyshi)
			{
				OkoshkoScript component100 = base.GetComponent<OkoshkoScript>();
				component100.text += "<color=yellow>Советская военная база\n</color>";
				OkoshkoScript component101 = base.GetComponent<OkoshkoScript>();
				component101.text_en += "<color=yellow>Soviet military base\n</color>";
				OkoshkoScript component102 = base.GetComponent<OkoshkoScript>();
				component102.text += "Еженедельно: Агентурные сети +0.2;\nНедовольство НАТО -0.2;\nОдобрение СССР +0.4; Суверенитет -0.2;";
				OkoshkoScript component103 = base.GetComponent<OkoshkoScript>();
				component103.text_en += "Weekly: Agent networks +0.2;\nDissatisfaction of NATO -0.2;\nApproval from the USSR +0.4; Sovereignity -0.2;";
			}
			else
			{
				OkoshkoScript component104 = base.GetComponent<OkoshkoScript>();
				component104.text += "<color=yellow>Российская военная база\n</color>";
				OkoshkoScript component105 = base.GetComponent<OkoshkoScript>();
				component105.text_en += "<color=yellow>Russian military base\n</color>";
				OkoshkoScript component106 = base.GetComponent<OkoshkoScript>();
				component106.text += "Одобрение России +0.4;\nБюджет -0.1;";
				OkoshkoScript component107 = base.GetComponent<OkoshkoScript>();
				component107.text_en += "Approval from the Russia +0.4;\nThe budget - 0.1;";
			}
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type < 37)
		{
			OkoshkoScript component108 = base.GetComponent<OkoshkoScript>();
			component108.text += string.Format(this.yug1.science_text[41 + this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type], '\n', "<color=yellow>", "</color>");
			OkoshkoScript component109 = base.GetComponent<OkoshkoScript>();
			component109.text_en += string.Format(this.yug1.science_text[41 + this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type], '\n', "<color=yellow>", "</color>");
		}
		if (this.buildmanager1.now_region != 2 && (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51))
		{
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].level + 5 > this.this_number)
			{
				OkoshkoScript component110 = base.GetComponent<OkoshkoScript>();
				component110.text = component110.text + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].name;
				OkoshkoScript component111 = base.GetComponent<OkoshkoScript>();
				component111.text_en = component111.text_en + "\nRegion: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].name;
				return;
			}
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].level + 5 > this.this_number)
			{
				OkoshkoScript component112 = base.GetComponent<OkoshkoScript>();
				component112.text = component112.text + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].name;
				OkoshkoScript component113 = base.GetComponent<OkoshkoScript>();
				component113.text_en = component113.text_en + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].name;
				return;
			}
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].level + 5 > this.this_number)
			{
				OkoshkoScript component114 = base.GetComponent<OkoshkoScript>();
				component114.text = component114.text + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].name;
				OkoshkoScript component115 = base.GetComponent<OkoshkoScript>();
				component115.text_en = component115.text_en + "\nРегион: " + this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].name;
			}
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00004708 File Offset: 0x00002908
	public void DoSomething(int thing)
	{
		if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded)
		{
			if (thing == 0)
			{
				if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type < 6 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type > 9 || (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 9 && this.global1.data[16] > 11)) && (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 4 || (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 4 && this.global1.data[16] > 11)) && (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type < 12 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15) && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 10 && !this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private && (this.global1.data[16] > 11 || this.global1.data[8] < 0))
				{
					if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1)
					{
						this.global1.data[8] += 20;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2)
					{
						this.global1.data[8] += 10;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3)
					{
						this.global1.data[8] += 20;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 4)
					{
						this.global1.data[8] += 30;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5)
					{
						this.global1.data[8] += 20;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 9)
					{
						this.global1.data[8] += 30;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 11)
					{
						this.global1.data[8] += 30;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15)
					{
						this.global1.data[8] += 30;
					}
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private = true;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = true;
					if (this.global1.data[16] <= 11)
					{
						this.global1.data[39] += 2;
						this.global1.data[33] -= 10;
						this.global1.data[1] -= 50;
						this.global1.data[2] += 10;
						this.global1.data[22] -= 4;
						this.global1.data[10] -= 2;
						this.global1.data[6] -= 4;
						this.global1.data[3] += 30;
						this.global1.data[4] += 10;
					}
					else if (this.global1.data[16] == 12)
					{
						if (this.global1.data[39] < 5)
						{
							this.global1.data[39]++;
						}
						this.global1.data[33] -= 10;
						this.global1.data[1] += 10;
						this.global1.data[2] += 5;
						this.global1.data[22] -= 4;
						this.global1.data[10]--;
						this.global1.data[6] -= 2;
						this.global1.data[3] += 15;
						this.global1.data[4] += 10;
					}
					else
					{
						this.global1.data[33]--;
						this.global1.data[2] += 5;
						this.global1.data[22] -= 2;
						this.global1.data[10]--;
						this.global1.data[6] -= 2;
						this.global1.data[3] += 15;
						this.global1.data[4] += 5;
					}
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private && this.global1.data[16] <= 11)
				{
					if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5)
					{
						this.global1.data[8] -= 20;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2)
					{
						this.global1.data[8] -= 10;
					}
					else
					{
						this.global1.data[8] -= 30;
					}
					this.global1.data[3] -= 40;
					this.global1.data[4] += 20;
					this.global1.data[39]--;
					this.global1.data[1] += 40;
					this.global1.data[2] -= 5;
					this.global1.data[22] += 2;
					this.global1.data[6] += 4;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private = false;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = true;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private && this.global1.data[16] == 12)
				{
					if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5)
					{
						this.global1.data[8] -= 20;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2)
					{
						this.global1.data[8] -= 10;
					}
					else
					{
						this.global1.data[8] -= 30;
					}
					this.global1.data[3] -= 80;
					this.global1.data[4] += 40;
					this.global1.data[1] += 40;
					this.global1.data[2] -= 10;
					this.global1.data[22] += 2;
					this.global1.data[6] += 4;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private = false;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = true;
					if (this.global1.data[39] > 5)
					{
						this.global1.data[39]--;
					}
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private && this.global1.data[16] == 13 && (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5))
				{
					this.global1.data[8] -= 30;
					this.global1.data[3] -= 80;
					this.global1.data[4] += 40;
					this.global1.data[1] += 40;
					this.global1.data[2] -= 10;
					this.global1.data[22] += 2;
					this.global1.data[6] += 4;
				}
			}
			else if (thing == 1)
			{
				if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type < 12 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15) && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 6 && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working && !this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private)
				{
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = false;
				}
				else if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type <= 11 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15) && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 6 && !this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private)
				{
					if (this.global1.data[16] > 11)
					{
						if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15)
						{
							this.global1.data[8] -= 20;
						}
						else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3)
						{
							this.global1.data[8] -= 20;
						}
						else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 4)
						{
							this.global1.data[8] -= 20;
						}
						else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 7)
						{
							this.global1.data[8] -= 20;
						}
					}
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = true;
				}
			}
			else if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private)
			{
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 15)
				{
					this.global1.data[8] -= 30;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 2)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 3)
				{
					this.global1.data[8] -= 30;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 4)
				{
					this.global1.data[8] -= 30;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 5)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 6)
				{
					this.global1.data[8]++;
					this.global1.data[4] += 30;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 7)
				{
					this.global1.data[8] -= 70;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 8)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 9)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 10)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 11)
				{
					this.global1.data[8] -= 10;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 23 && this.global1.allcountries[7].Vyshi)
				{
					this.global1.data[8] -= 20;
					this.global1.data[10] += 50;
					this.global1.data[9] -= 20;
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded = false;
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type > 11)
				{
					if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 12 && this.global1.event_done[33])
					{
						this.global1.data[8] -= 30;
						this.global1.data[1] -= 50;
						this.global1.data[4] += 100;
						this.global1.data[6] -= 50;
						this.global1.data[10] -= 30;
						this.global1.data[2] += 150;
						this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded = false;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 13)
					{
						this.global1.data[8] -= 10;
						this.global1.data[1] += (this.global1.data[14] - 4) * 50;
						this.global1.data[6] -= 30;
						this.global1.data[10] -= 30;
						this.global1.data[3] += (this.global1.data[14] - 3) * 10;
						this.global1.data[4] -= (this.global1.data[14] - 3) * 10;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 21)
					{
						this.global1.data[8] -= 150;
						this.global1.data[6] -= 25;
						this.global1.data[10] -= 50;
						this.global1.data[2] += 150;
						this.global1.povod = false;
						this.global1.data[36] = 0;
						this.global1.data[1] -= (4 - this.global1.data[14]) * 100;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 20)
					{
						this.global1.data[8] -= 50;
						this.global1.data[3] -= 100;
						this.global1.data[4] += 200;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 22 && this.global1.data[75] > 0)
					{
						this.global1.data[8] -= 30;
						this.global1.data[3] += 100;
						this.global1.data[4] += 200;
						this.global1.data[2] += 200;
						this.global1.data[10] -= 200;
						this.global1.data[1] -= 250;
						this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded = false;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 16)
					{
						this.global1.data[8] += 10;
						this.global1.data[1] += 50;
						this.global1.data[10] -= 10;
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type == 17)
					{
						this.global1.data[3] += (this.global1.data[14] - 3) * 10;
						this.global1.data[1] += (this.global1.data[14] - 3) * 10;
						this.global1.data[4] -= (this.global1.data[14] - 3) * 10;
					}
				}
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 12 && (this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type < 25 || this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type > 36 || this.global1.event_done[375]) && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 23 && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 24 && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 22 && this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type != 19)
				{
					this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded = false;
				}
			}
		}
		this.Repaint();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000062AC File Offset: 0x000044AC
	public void BuildThis(int type)
	{
		this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded = true;
		this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_working = true;
		this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_private = false;
		this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].type = type;
		this.Repaint();
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00006364 File Offset: 0x00004564
	private void OnMouseDown()
	{
		if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.this_number].is_builded && this.this_number <= 3 * this.global1.regions[this.buildmanager1.now_region].city_level - 1)
		{
			this.buildmanager1.selected_thing = this.this_number;
			this.buildmanager1.ShowSelects();
			return;
		}
		this.buildmanager1.HideSelects();
	}

	// Token: 0x04000021 RID: 33
	public int this_number = -1;

	// Token: 0x04000022 RID: 34
	private GlobalScript global1;

	// Token: 0x04000023 RID: 35
	public BuildingManager buildmanager1;

	// Token: 0x04000024 RID: 36
	private Yugoglobal yug1;
}
