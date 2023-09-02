using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class BuildReScript : MonoBehaviour
{
	// Token: 0x0600001E RID: 30 RVA: 0x000063FC File Offset: 0x000045FC
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.build1 = base.transform.parent.GetComponent<BuildingScript>();
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000647C File Offset: 0x0000467C
	private void OnMouseDown()
	{
		this.Change();
		this.buildmanager1.HideSelects();
		if (this.enabled)
		{
			base.transform.parent.GetComponent<BuildingScript>().DoSomething(this.this_force);
		}
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000064B4 File Offset: 0x000046B4
	private void Change()
	{
		if (this.buildmanager1.now_region != 2 && (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51))
		{
			if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[0]].level + 5 > this.build1.this_number)
			{
				if (!this.buildmanager1.yugown[0])
				{
					this.enabled = false;
					return;
				}
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[1]].level + 5 > this.build1.this_number)
			{
				if (!this.buildmanager1.yugown[1])
				{
					this.enabled = false;
					return;
				}
			}
			else if (this.yug1.gameState.yugregions[this.buildmanager1.yugreg[2]].level + 5 > this.build1.this_number && !this.buildmanager1.yugown[2])
			{
				this.enabled = false;
				return;
			}
		}
		if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_builded)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Невозможно</color>";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>Impossible</color>";
			this.enabled = false;
			return;
		}
		if (this.this_force == 0)
		{
			if (this.global1.data[0] == 12 && !this.global1.science[3])
			{
				base.GetComponent<OkoshkoScript>().text = "<color=red>Вы не можете,\nпока не закончите\nисследование\n\"Строительство промышленности\"</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>You can't,\nuntil you complete\n the esearch\n\"Construction of industry\"</color>";
			}
			else if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 6 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 9 || (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 9 && this.global1.data[16] > 11)) && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 4 || (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 4 && this.global1.data[16] > 11)) && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 12 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 15) && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 10 && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 25 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 36) && !this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && (this.global1.data[16] > 11 || this.global1.data[8] < 0))
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Приватизировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Privatize</color>";
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 1)
				{
					OkoshkoScript component = base.GetComponent<OkoshkoScript>();
					component.text += "\n<color=yellow>Выгода:</color> +2 к бюджету";
					OkoshkoScript component2 = base.GetComponent<OkoshkoScript>();
					component2.text_en += "\n<color=yellow>Profit:</color> +2 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2)
				{
					OkoshkoScript component3 = base.GetComponent<OkoshkoScript>();
					component3.text += "\n<color=yellow>Выгода:</color> +1 к бюджету";
					OkoshkoScript component4 = base.GetComponent<OkoshkoScript>();
					component4.text_en += "\n<color=yellow>Profit:</color> +1 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3)
				{
					OkoshkoScript component5 = base.GetComponent<OkoshkoScript>();
					component5.text += "\n<color=yellow>Выгода:</color> +2 к бюджету";
					OkoshkoScript component6 = base.GetComponent<OkoshkoScript>();
					component6.text_en += "\n<color=yellow>Profit:</color> +2 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 4)
				{
					OkoshkoScript component7 = base.GetComponent<OkoshkoScript>();
					component7.text += "\n<color=yellow>Выгода:</color> +3 к бюджету";
					OkoshkoScript component8 = base.GetComponent<OkoshkoScript>();
					component8.text_en += "\n<color=yellow>Profit:</color> +3 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5)
				{
					OkoshkoScript component9 = base.GetComponent<OkoshkoScript>();
					component9.text += "\n<color=yellow>Выгода:</color> +2 к бюджету";
					OkoshkoScript component10 = base.GetComponent<OkoshkoScript>();
					component10.text_en += "\n<color=yellow>Profit:</color> +2 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 9)
				{
					OkoshkoScript component11 = base.GetComponent<OkoshkoScript>();
					component11.text += "\n<color=yellow>Выгода:</color> +3 к бюджету";
					OkoshkoScript component12 = base.GetComponent<OkoshkoScript>();
					component12.text_en += "\n<color=yellow>Profit:</color> +3 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 11)
				{
					OkoshkoScript component13 = base.GetComponent<OkoshkoScript>();
					component13.text += "\n<color=yellow>Выгода:</color> +3 к бюджету";
					OkoshkoScript component14 = base.GetComponent<OkoshkoScript>();
					component14.text_en += "\n<color=yellow>Profit:</color> +3 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 15)
				{
					OkoshkoScript component15 = base.GetComponent<OkoshkoScript>();
					component15.text += "\n<color=yellow>Выгода:</color> +3 к бюджету";
					OkoshkoScript component16 = base.GetComponent<OkoshkoScript>();
					component16.text_en += "\n<color=yellow>Profit:</color> +3 to the budget";
				}
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && this.global1.data[16] <= 11)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Национализировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Nationalize</color>";
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5)
				{
					OkoshkoScript component17 = base.GetComponent<OkoshkoScript>();
					component17.text += "\n<color=yellow>Расходы:</color> -2 из бюджета,\n+ 2 к Вестальгии, -4 к Поддержке народа";
					OkoshkoScript component18 = base.GetComponent<OkoshkoScript>();
					component18.text_en += "\n<color=yellow>Costs:</color> -2 from the budget,\n+2 to Westalgia, -4 to Support of the people";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2)
				{
					OkoshkoScript component19 = base.GetComponent<OkoshkoScript>();
					component19.text += "\n<color=yellow>Расходы:</color> -1 из бюджета,\n+ 2 к Вестальгии, -4 к Поддержке народа";
					OkoshkoScript component20 = base.GetComponent<OkoshkoScript>();
					component20.text_en += "\n<color=yellow>Costs:</color> -1 from the budget,\n+2 to Westalgia, -4 to Support of the people";
				}
				else
				{
					OkoshkoScript component21 = base.GetComponent<OkoshkoScript>();
					component21.text += "\n<color=yellow>Расходы:</color> -3 из бюджета,\n+ 2 к Вестальгии, -4 к Поддержке народа";
					OkoshkoScript component22 = base.GetComponent<OkoshkoScript>();
					component22.text_en += "\n<color=yellow>Costs:</color> -3 from the budget,\n+2 to Westalgia, -4 to Support of the people";
				}
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && this.global1.data[16] == 12)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Национализировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Nationalize</color>";
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5)
				{
					OkoshkoScript component23 = base.GetComponent<OkoshkoScript>();
					component23.text += "\n<color=yellow>Расходы:</color> -2 из бюджета,\n+ 4 к Вестальгии, -8 к Поддержке народа";
					OkoshkoScript component24 = base.GetComponent<OkoshkoScript>();
					component24.text_en += "\n<color=yellow>Costs:</color> -2 from the budget,\n+4 to Westalgia, -8 to Support of the people";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2)
				{
					OkoshkoScript component25 = base.GetComponent<OkoshkoScript>();
					component25.text += "\n<color=yellow>Расходы:</color> -1 из бюджета,\n+ 4 к Вестальгии, -8 к Поддержке народа";
					OkoshkoScript component26 = base.GetComponent<OkoshkoScript>();
					component26.text_en += "\n<color=yellow>Costs:</color> -1 from the budget,\n+4 to Westalgia, -8 to Support of the people";
				}
				else
				{
					OkoshkoScript component27 = base.GetComponent<OkoshkoScript>();
					component27.text += "\n<color=yellow>Расходы:</color> -3 из бюджета,\n+ 4 к Вестальгии, -8 к Поддержке народа";
					OkoshkoScript component28 = base.GetComponent<OkoshkoScript>();
					component28.text_en += "\n<color=yellow>Costs:</color> -3 from the budget,\n+4 to Westalgia, -8 to Support of the people";
				}
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && this.global1.data[16] == 13 && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5))
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Национализировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Nationalize</color>";
				OkoshkoScript component29 = base.GetComponent<OkoshkoScript>();
				component29.text += "\n<color=yellow>Расходы:</color> -3 из бюджета,\n+ 4 к Вестальгии, -8 к Поддержке народа";
				OkoshkoScript component30 = base.GetComponent<OkoshkoScript>();
				component30.text_en += "\n<color=yellow>Costs:</color> -3 from the budget,\n+4 to Westalgia, -8 to Support of the people";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && this.global1.data[16] > 11)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Национализировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Nationalize</color>";
				base.GetComponent<OkoshkoScript>().text = "<color=red>Требуется плановая экономика</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Need a planned economy</color>";
			}
			else if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 5 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 9) || (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 11 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 15) || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 10)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Приватизировать</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Privatize</color>";
				base.GetComponent<OkoshkoScript>().text = "<color=red>Невозможно</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Impossible</color>";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 4 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 9)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=red>Не плановая экономика</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Not a planned economy</color>";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text = "<color=red>Не плановая экономика\nили бюджет отрицателен</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Not a planned economy\nor your budget is negative</color>";
			}
		}
		else if (this.this_force == 1)
		{
			if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 12 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 15) && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 6 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_working && !this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Остановить</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Stop work</color>";
			}
			else if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 11 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 15) || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 6 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private)
			{
				base.GetComponent<OkoshkoScript>().text = "<color=red>Невозможно</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Impossible</color>";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text = "<color=red>Возобновить</color>";
				base.GetComponent<OkoshkoScript>().text_en = "<color=red>Reopen</color>";
				if (this.global1.data[16] > 11)
				{
					if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 15)
					{
						OkoshkoScript component31 = base.GetComponent<OkoshkoScript>();
						component31.text += "\n<color=yellow>Расходы:</color> -2 из бюджета";
						OkoshkoScript component32 = base.GetComponent<OkoshkoScript>();
						component32.text_en += "\n<color=yellow>Costs:</color> -2 from the budget";
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3)
					{
						OkoshkoScript component33 = base.GetComponent<OkoshkoScript>();
						component33.text += "\n<color=yellow>Расходы:</color> -2 из бюджета";
						OkoshkoScript component34 = base.GetComponent<OkoshkoScript>();
						component34.text_en += "\n<color=yellow>Costs:</color> -2 from the budget";
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 4)
					{
						OkoshkoScript component35 = base.GetComponent<OkoshkoScript>();
						component35.text += "\n<color=yellow>Расходы:</color> -2 из бюджета";
						OkoshkoScript component36 = base.GetComponent<OkoshkoScript>();
						component36.text_en += "\n<color=yellow>Costs:</color> -2 from the budget";
					}
					else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 7)
					{
						OkoshkoScript component37 = base.GetComponent<OkoshkoScript>();
						component37.text += "\n<color=yellow>Расходы:</color> -2 из бюджета";
						OkoshkoScript component38 = base.GetComponent<OkoshkoScript>();
						component38.text_en += "\n<color=yellow>Costs:</color> -2 from the budget";
					}
				}
			}
		}
		else if (!this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type < 25 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 36 || this.global1.event_done[375]) && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 19 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 24)
		{
			if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 12)
			{
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Demolish</color>";
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Снести</color>";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text_en = "<color=lime>Tear down</color>";
				base.GetComponent<OkoshkoScript>().text = "<color=lime>Снести эту стену</color>";
			}
			if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 1 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 15)
			{
				OkoshkoScript component39 = base.GetComponent<OkoshkoScript>();
				component39.text += "\n<color=yellow>Расходы:</color> -3 из бюджета";
				OkoshkoScript component40 = base.GetComponent<OkoshkoScript>();
				component40.text_en += "\n<color=yellow>Costs:</color> -3 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2)
			{
				OkoshkoScript component41 = base.GetComponent<OkoshkoScript>();
				component41.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component42 = base.GetComponent<OkoshkoScript>();
				component42.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3)
			{
				OkoshkoScript component43 = base.GetComponent<OkoshkoScript>();
				component43.text += "\n<color=yellow>Расходы:</color> -3 из бюджета";
				OkoshkoScript component44 = base.GetComponent<OkoshkoScript>();
				component44.text_en += "\n<color=yellow>Costs:</color> -3 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 4)
			{
				OkoshkoScript component45 = base.GetComponent<OkoshkoScript>();
				component45.text += "\n<color=yellow>Расходы:</color> -3 из бюджета";
				OkoshkoScript component46 = base.GetComponent<OkoshkoScript>();
				component46.text_en += "\n<color=yellow>Costs:</color> -3 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5)
			{
				OkoshkoScript component47 = base.GetComponent<OkoshkoScript>();
				component47.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component48 = base.GetComponent<OkoshkoScript>();
				component48.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 7)
			{
				OkoshkoScript component49 = base.GetComponent<OkoshkoScript>();
				component49.text += "\n<color=yellow>Расходы:</color> -7 из бюджета";
				OkoshkoScript component50 = base.GetComponent<OkoshkoScript>();
				component50.text_en += "\n<color=yellow>Costs:</color> -7 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 8)
			{
				OkoshkoScript component51 = base.GetComponent<OkoshkoScript>();
				component51.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component52 = base.GetComponent<OkoshkoScript>();
				component52.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 9)
			{
				OkoshkoScript component53 = base.GetComponent<OkoshkoScript>();
				component53.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component54 = base.GetComponent<OkoshkoScript>();
				component54.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 10)
			{
				OkoshkoScript component55 = base.GetComponent<OkoshkoScript>();
				component55.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component56 = base.GetComponent<OkoshkoScript>();
				component56.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 11)
			{
				OkoshkoScript component57 = base.GetComponent<OkoshkoScript>();
				component57.text += "\n<color=yellow>Расходы:</color> -1 из бюджета";
				OkoshkoScript component58 = base.GetComponent<OkoshkoScript>();
				component58.text_en += "\n<color=yellow>Costs:</color> -1 from the budget";
			}
			else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type > 11)
			{
				if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 16)
				{
					OkoshkoScript component59 = base.GetComponent<OkoshkoScript>();
					component59.text += "\n<color=yellow>Расходы:</color> +1 в бюджет";
					OkoshkoScript component60 = base.GetComponent<OkoshkoScript>();
					component60.text_en += "\n<color=yellow>Costs:</color> +1 to the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 21)
				{
					OkoshkoScript component61 = base.GetComponent<OkoshkoScript>();
					component61.text += "\n<color=yellow>Расходы:</color> -15 из бюджета";
					OkoshkoScript component62 = base.GetComponent<OkoshkoScript>();
					component62.text_en += "\n<color=yellow>Costs:</color> -15 from the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 20)
				{
					OkoshkoScript component63 = base.GetComponent<OkoshkoScript>();
					component63.text += "\n<color=yellow>Расходы:</color> -5 из бюджета";
					OkoshkoScript component64 = base.GetComponent<OkoshkoScript>();
					component64.text_en += "\n<color=yellow>Costs:</color> -5 from the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 23)
				{
					OkoshkoScript component65 = base.GetComponent<OkoshkoScript>();
					component65.text += "\n<color=yellow>Расходы:</color> -2 из бюджета\n<color=red>Если СССР распался</color>";
					OkoshkoScript component66 = base.GetComponent<OkoshkoScript>();
					component66.text_en += "\n<color=yellow>Costs:</color> -2 from the budget\n<color=red>if USSR collapsed</color>";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 22 && this.global1.data[75] > 0)
				{
					OkoshkoScript component67 = base.GetComponent<OkoshkoScript>();
					component67.text += "\n<color=yellow>Расходы:</color> -3 из бюджета";
					OkoshkoScript component68 = base.GetComponent<OkoshkoScript>();
					component68.text_en += "\n<color=yellow>Costs:</color> -3 from the budget";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 13)
				{
					OkoshkoScript component69 = base.GetComponent<OkoshkoScript>();
					component69.text = string.Concat(new string[]
					{
						component69.text,
						"\n<color=yellow>Поддержка народа:</color> ",
						(this.global1.data[14] - 3).ToString(),
						".",
						Mathf.Abs((this.global1.data[14] - 3) * 8 % 10).ToString()
					});
					component69 = base.GetComponent<OkoshkoScript>();
					component69.text_en = string.Concat(new string[]
					{
						component69.text_en,
						"\n<color=yellow>Support of the people:</color> ",
						(this.global1.data[14] - 3).ToString(),
						".",
						Mathf.Abs((this.global1.data[14] - 3) * 8 % 10).ToString()
					});
					OkoshkoScript component70 = base.GetComponent<OkoshkoScript>();
					component70.text_en = component70.text_en + "\n<color=yellow>Unity of the Party:</color> " + ((this.global1.data[14] > 4) ? "+" : "") + ((this.global1.data[14] - 4) * 5).ToString();
					OkoshkoScript component71 = base.GetComponent<OkoshkoScript>();
					component71.text = component71.text + "\n<color=yellow>Единство Партии:</color> " + ((this.global1.data[14] > 4) ? "+" : "") + ((this.global1.data[14] - 4) * 5).ToString();
					component69 = base.GetComponent<OkoshkoScript>();
					component69.text_en = string.Concat(new string[]
					{
						component69.text_en,
						"\n<color=yellow>Westalgia:</color> ",
						(3 - this.global1.data[14]).ToString(),
						".",
						Mathf.Abs((3 - this.global1.data[14]) * 8 % 10).ToString()
					});
					component69 = base.GetComponent<OkoshkoScript>();
					component69.text = string.Concat(new string[]
					{
						component69.text,
						"\n<color=yellow>Вестальгия:</color> ",
						(3 - this.global1.data[14]).ToString(),
						".",
						Mathf.Abs((3 - this.global1.data[14]) * 8 % 10).ToString()
					});
					OkoshkoScript component72 = base.GetComponent<OkoshkoScript>();
					component72.text += "\n<color=yellow>Репутация:</color> -3.0 ";
					OkoshkoScript component73 = base.GetComponent<OkoshkoScript>();
					component73.text_en += "\n<color=yellow>Reputation:</color> -3.0 ";
					OkoshkoScript component74 = base.GetComponent<OkoshkoScript>();
					component74.text += "<color=yellow>Недовольство НАТО:</color> -3.0";
					OkoshkoScript component75 = base.GetComponent<OkoshkoScript>();
					component75.text_en += "<color=yellow>Dissatisfaction of NATO:</color> -3.0";
				}
				else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 17)
				{
					OkoshkoScript component76 = base.GetComponent<OkoshkoScript>();
					component76.text = component76.text + "\n<color=yellow>Поддержка народа:</color> " + (this.global1.data[14] - 3).ToString();
					OkoshkoScript component77 = base.GetComponent<OkoshkoScript>();
					component77.text_en = component77.text_en + "\n<color=yellow>Support of the people:</color> " + (this.global1.data[14] - 3).ToString();
					OkoshkoScript component78 = base.GetComponent<OkoshkoScript>();
					component78.text_en = component78.text_en + "\n<color=yellow>Unity of the Party:</color> " + (this.global1.data[14] - 3).ToString();
					OkoshkoScript component79 = base.GetComponent<OkoshkoScript>();
					component79.text = component79.text + "\n<color=yellow>Единство Партии:</color> " + (this.global1.data[14] - 3).ToString();
					OkoshkoScript component80 = base.GetComponent<OkoshkoScript>();
					component80.text_en = component80.text_en + "\n<color=yellow>Westalgia:</color> " + (3 - this.global1.data[14]).ToString();
					OkoshkoScript component81 = base.GetComponent<OkoshkoScript>();
					component81.text = component81.text + "\n<color=yellow>Вестальгия:</color> " + (3 - this.global1.data[14]).ToString();
				}
				else if ((this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 12 && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 22) || this.global1.event_done[33])
				{
					OkoshkoScript component82 = base.GetComponent<OkoshkoScript>();
					component82.text += "\n<color=yellow>Расходы:</color> -3 из бюджета";
					OkoshkoScript component83 = base.GetComponent<OkoshkoScript>();
					component83.text_en += "\n<color=yellow>Costs:</color> -3 from the budget";
				}
				else
				{
					OkoshkoScript component84 = base.GetComponent<OkoshkoScript>();
					component84.text += "\n<color=red>Нет повода</color>";
					OkoshkoScript component85 = base.GetComponent<OkoshkoScript>();
					component85.text_en += "\n<color=red>No reason</color>";
				}
			}
		}
		else if (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type != 12)
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Невозможно</color>";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>Impossible</color>";
		}
		else
		{
			base.GetComponent<OkoshkoScript>().text = "<color=red>Нет повода</color>";
			base.GetComponent<OkoshkoScript>().text_en = "<color=red>No reason</color>";
		}
		if (this.this_force != 0)
		{
			this.enabled = true;
			return;
		}
		if ((!this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private || ((this.global1.data[16] <= 12 || (this.global1.data[16] == 13 && (this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 2 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 3 || this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].type == 5))) && this.global1.regions[this.buildmanager1.now_region].buildings[this.build1.this_number].is_private)) && (this.global1.data[0] != 12 || this.global1.science[3]))
		{
			this.enabled = true;
			return;
		}
		this.enabled = false;
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00008768 File Offset: 0x00006968
	private void OnMouseExit()
	{
		this.Change();
		base.GetComponent<SpriteRenderer>().sprite = this.buildmanager1.respriteoff[this.this_force];
	}

	// Token: 0x06000022 RID: 34 RVA: 0x0000878D File Offset: 0x0000698D
	private void OnMouseEnter()
	{
		this.Change();
		if (this.enabled)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.buildmanager1.resprite_on[this.this_force];
		}
	}

	// Token: 0x04000025 RID: 37
	public new bool enabled = true;

	// Token: 0x04000026 RID: 38
	public BuildingManager buildmanager1;

	// Token: 0x04000027 RID: 39
	private GlobalScript global1;

	// Token: 0x04000028 RID: 40
	private BuildingScript build1;

	// Token: 0x04000029 RID: 41
	private Yugoglobal yug1;

	// Token: 0x0400002A RID: 42
	public int this_force;
}
