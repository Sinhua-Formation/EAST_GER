using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
public class YugoMapManager : MonoBehaviour, IButtonPressReceiver
{
	// Token: 0x060001B5 RID: 437 RVA: 0x0018964C File Offset: 0x0018784C
	public void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		if (this.is_separate)
		{
			this.Repaint();
		}
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x001896BC File Offset: 0x001878BC
	public void AddButtons(bool yes_man = true)
	{
		for (int i = 0; i < this.buttons.Length; i++)
		{
			this.buttons[i].SetActive(yes_man);
		}
		if (!yes_man)
		{
			this.description.text = "";
			return;
		}
		if (!this.yug1.gameState.battle_royal && this.is_separate)
		{
			this.buttons[5].SetActive(false);
			if (this.global1.data[0] == 51)
			{
				if (this.global1.party_name[1] != this.yug1.science_text[118])
				{
					this.buttons[4].SetActive(false);
					return;
				}
			}
			else if (this.global1.data[0] == 50)
			{
				if (this.global1.party_name[1] != this.yug1.science_text[125])
				{
					this.buttons[4].SetActive(false);
					return;
				}
			}
			else if (this.global1.data[0] == 49 && this.global1.party_name[1] != this.yug1.science_text[132])
			{
				this.buttons[4].SetActive(false);
			}
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x001897F8 File Offset: 0x001879F8
	public void Repaint()
	{
		int num = this.yug1.gameState.yugregions.Length;
		for (int i = 0; i < this.countries.Length; i++)
		{
			int owner = this.yug1.gameState.yugregions[this.countries[i].GetComponent<YugoMapButtons>().num].owner;
			this.countries[i].GetComponent<SpriteRenderer>().color = new Color(1f / (float)(owner + 1), (owner >= num / 2) ? (1f / (float)(owner - num / 2 + 1)) : (1f / (float)(num / 2 - owner)), (owner < num / 2) ? (1f / (float)(num / 2 - owner)) : (1f / (float)(num - owner)));
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x001898BC File Offset: 0x00187ABC
	private void ReRepaint()
	{
		this.requirements.text = this.yug1.science_text[61];
		int num = (this.global1.science[1] ? 1 : 0) + (this.global1.science[5] ? 1 : 0) + (this.global1.science[9] ? 1 : 0);
		int num2 = this.yug1.gameState.yugcountries[this.country].army;
		this.yug1.ArmyAutoGrowth(this.country, ref num2);
		num2 -= this.yug1.gameState.yugcountries[this.country].army;
		if (this.country == this.yug1.gameState.player)
		{
			if (this.is_separate)
			{
				this.description.text = string.Format(this.yug1.science_text[52], new object[]
				{
					'\n',
					this.yug1.gameState.yugcountries[this.country].name,
					this.yug1.gameState.yugregions[this.region].name,
					this.yug1.gameState.yugregions[this.region].defence,
					this.yug1.gameState.yugregions[this.region].control,
					this.yug1.gameState.yugcountries[this.country].army,
					this.yug1.gameState.yugregions[this.region].population,
					num2
				});
				return;
			}
			this.description.text = string.Format(this.yug1.science_text[62], new object[]
			{
				'\n',
				this.yug1.gameState.yugcountries[this.country].name,
				this.yug1.gameState.yugregions[this.region].name,
				this.yug1.gameState.yugregions[this.region].defence,
				this.yug1.gameState.yugregions[this.region].control,
				this.yug1.gameState.yugcountries[this.country].army,
				this.yug1.gameState.yugregions[this.region].population,
				num2
			});
			return;
		}
		else
		{
			int num3 = num2 - num2 / 30 * (this.global1.data[21] - 1988);
			int num4 = num2 / 10 * (3 - num) + num2;
			int num5 = this.yug1.gameState.yugcountries[this.country].army - this.yug1.gameState.yugcountries[this.country].army / 30 * (this.global1.data[21] - 1988);
			int num6 = this.yug1.gameState.yugcountries[this.country].army / 10 * (3 - num) + this.yug1.gameState.yugcountries[this.country].army;
			if (num5 < 0)
			{
				num5 = 0;
			}
			int num7 = (this.yug1.gameState.yugregions[this.region].defence - this.yug1.gameState.yugregions[this.region].defence / 50 * (this.global1.data[21] - 1988)) * ((num <= 0) ? 0 : 1);
			int num8 = (this.yug1.gameState.yugregions[this.region].defence / 25 * (3 - num) + this.yug1.gameState.yugregions[this.region].defence) * ((num <= 0) ? 13 : 1);
			if (this.yug1.gameState.yugregions[this.region].defence <= 0)
			{
				num8 = (num7 = this.yug1.gameState.yugregions[this.region].defence);
			}
			else if (num7 <= 0)
			{
				num7 = 1;
			}
			if (this.is_separate)
			{
				this.description.text = string.Format(this.yug1.science_text[53], new object[]
				{
					'\n',
					this.yug1.gameState.yugcountries[this.country].name,
					this.yug1.gameState.yugregions[this.region].name,
					num7,
					num5,
					(num3 + num4) / 2,
					this.yug1.gameState.yugregions[this.region].population,
					num,
					(num4 - num3) / 2,
					num6,
					num8
				});
				return;
			}
			this.description.text = string.Format(this.yug1.science_text[63], new object[]
			{
				'\n',
				this.yug1.gameState.yugcountries[this.country].name,
				this.yug1.gameState.yugregions[this.region].name,
				num7,
				num5,
				(num3 + num4) / 2,
				this.yug1.gameState.yugregions[this.region].population,
				num,
				(num4 - num3) / 2,
				num6,
				num8
			});
			return;
		}
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00189F20 File Offset: 0x00188120
	void IButtonPressReceiver.OnButtonDown(int num)
	{
		if (num < this.yug1.gameState.yugregions.Length && num >= 0)
		{
			this.country = this.yug1.gameState.yugregions[num].owner;
			this.region = num;
			this.AddButtons(true);
			int num2 = (this.global1.science[1] ? 1 : 0) + (this.global1.science[5] ? 1 : 0) + (this.global1.science[9] ? 1 : 0);
			int num3 = this.yug1.gameState.yugcountries[this.country].army;
			this.yug1.ArmyAutoGrowth(this.country, ref num3);
			num3 -= this.yug1.gameState.yugcountries[this.country].army;
			if (this.country == this.yug1.gameState.player)
			{
				if (this.is_separate)
				{
					this.description.text = string.Format(this.yug1.science_text[52], new object[]
					{
						'\n',
						this.yug1.gameState.yugcountries[this.country].name,
						this.yug1.gameState.yugregions[this.region].name,
						this.yug1.gameState.yugregions[this.region].defence,
						this.yug1.gameState.yugregions[this.region].control,
						this.yug1.gameState.yugcountries[this.country].army,
						this.yug1.gameState.yugregions[this.region].population,
						num3
					});
				}
				else
				{
					this.description.text = string.Format(this.yug1.science_text[62], new object[]
					{
						'\n',
						this.yug1.gameState.yugcountries[this.country].name,
						this.yug1.gameState.yugregions[this.region].name,
						this.yug1.gameState.yugregions[this.region].defence,
						this.yug1.gameState.yugregions[this.region].control,
						this.yug1.gameState.yugcountries[this.country].army,
						this.yug1.gameState.yugregions[this.region].population,
						num3
					});
				}
			}
			else
			{
				int num4 = num3 - num3 / 30 * (this.global1.data[21] - 1988);
				int num5 = num3 / 10 * (3 - num2) + num3;
				int num6 = this.yug1.gameState.yugcountries[this.country].army - this.yug1.gameState.yugcountries[this.country].army / 30 * (this.global1.data[21] - 1988);
				int num7 = this.yug1.gameState.yugcountries[this.country].army / 10 * (3 - num2) + this.yug1.gameState.yugcountries[this.country].army;
				if (num6 < 0)
				{
					num6 = 0;
				}
				int num8 = (this.yug1.gameState.yugregions[num].defence - this.yug1.gameState.yugregions[num].defence / 50 * (this.global1.data[21] - 1988)) * ((num2 <= 0) ? 0 : 1);
				int num9 = (this.yug1.gameState.yugregions[num].defence / 25 * (3 - num2) + this.yug1.gameState.yugregions[num].defence) * ((num2 <= 0) ? 13 : 1);
				if (this.yug1.gameState.yugregions[num].defence <= 0)
				{
					num9 = (num8 = this.yug1.gameState.yugregions[num].defence);
				}
				else if (num8 <= 0)
				{
					num8 = 1;
				}
				if (this.is_separate)
				{
					if (this.yug1.gameState.yugcountries[this.country].is_independent || this.country == this.yug1.gameState.player)
					{
						this.description.text = string.Format(this.yug1.science_text[53], new object[]
						{
							'\n',
							this.yug1.gameState.yugcountries[this.country].name,
							this.yug1.gameState.yugregions[this.region].name,
							num8,
							num6,
							(num4 + num5) / 2,
							this.yug1.gameState.yugregions[this.region].population,
							num2,
							(num5 - num4) / 2,
							num7,
							num9
						});
					}
					else
					{
						this.description.text = string.Format(this.yug1.science_text[110], new object[]
						{
							'\n',
							this.yug1.gameState.yugcountries[this.country].name,
							this.yug1.gameState.yugregions[this.region].name,
							num8,
							num6,
							(num4 + num5) / 2,
							this.yug1.gameState.yugregions[this.region].population,
							num2,
							(num5 - num4) / 2,
							num7,
							num9
						});
					}
				}
				else if (this.country == this.yug1.gameState.player)
				{
					this.description.text = string.Format(this.yug1.science_text[62], new object[]
					{
						'\n',
						this.yug1.gameState.yugcountries[this.country].name,
						this.yug1.gameState.yugregions[this.region].name,
						num8,
						num6,
						(num4 + num5) / 2,
						this.yug1.gameState.yugregions[this.region].population,
						num2,
						(num5 - num4) / 2,
						num7,
						num9
					});
				}
				else
				{
					this.description.text = string.Format(this.yug1.science_text[63], new object[]
					{
						'\n',
						this.yug1.gameState.yugcountries[this.country].name,
						this.yug1.gameState.yugregions[this.region].name,
						num8,
						num6,
						(num4 + num5) / 2,
						this.yug1.gameState.yugregions[this.region].population,
						num2,
						(num5 - num4) / 2,
						num7,
						num9
					});
				}
			}
		}
		else if (num == -1)
		{
			if (!this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country] && !this.yug1.gameState.yugcountries[this.country].temp_peace && this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 50 && this.country != this.yug1.gameState.player && this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, false))
			{
				this.yug1.AttackAgainstBot(this.region, this.yug1.gameState.player);
				this.ReRepaint();
			}
		}
		else if (num == -7)
		{
			if (!this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country] && !this.yug1.gameState.yugcountries[this.country].temp_peace && this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 150 && this.country != this.yug1.gameState.player && this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, false))
			{
				this.yug1.AttackAgainstBotx3(this.region, this.yug1.gameState.player);
				this.ReRepaint();
			}
		}
		else if (num == -2)
		{
			if (this.yug1.gameState.yugregions[this.region].control < 100 && this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 50)
			{
				this.yug1.RegionDefence(this.region, this.yug1.gameState.player);
				this.ReRepaint();
			}
		}
		else if (num == -3)
		{
			if (!this.yug1.gameState.yugcountries[this.country].temp_peace && !this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= this.yug1.gameState.yugcountries[this.country].army * 2 && this.global1.data[9] >= 30 && this.country != this.yug1.gameState.player)
			{
				this.global1.data[9] -= 30;
				this.yug1.MakeTempPeace(this.country);
				this.ReRepaint();
			}
		}
		else if (num == -4)
		{
			if (this.global1.science[7] && (this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) && this.global1.data[8] >= 30 && this.country != this.yug1.gameState.player && this.yug1.gameState.yugcountries[this.country].army > 0)
			{
				this.global1.data[8] -= 30;
				this.yug1.gameState.yugcountries[this.country].army -= 30;
				if (this.yug1.gameState.yugcountries[this.country].army < 0)
				{
					this.yug1.gameState.yugcountries[this.country].army = 0;
				}
				this.yug1.gameState.yugcountries[this.country].money += 30;
				this.yug1.gameState.yugcountries[this.yug1.gameState.player].army += 30;
				if (this.yug1.gameState.yugcountries[this.country].last)
				{
					this.yug1.gameState.yugregions[this.region].defence = this.yug1.DefenceRegionalPower(this.region);
				}
				this.ReRepaint();
			}
		}
		else if (num == -5)
		{
			if (this.global1.science[1] && (this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])))
			{
				if (this.yug1.gameState.yugcountries[this.country].money >= 15)
				{
					if (this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30 && this.country != this.yug1.gameState.player && this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, true) && (!this.yug1.gameState.yugcountries[this.country].traded || this.yug1.gameState.battle_royal))
					{
						this.yug1.gameState.yugcountries[this.yug1.gameState.player].army -= 30;
						this.yug1.gameState.yugcountries[this.country].army += 30;
						this.global1.data[8] += 15;
						this.yug1.gameState.yugcountries[this.country].money -= 15;
						this.yug1.gameState.yugcountries[this.country].traded = true;
						if (this.yug1.gameState.yugcountries[this.country].last)
						{
							this.yug1.gameState.yugregions[this.region].defence = this.yug1.DefenceRegionalPower(this.region);
						}
						this.ReRepaint();
					}
				}
				else if (this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30 && this.country != this.yug1.gameState.player)
				{
					this.yug1.gameState.yugcountries[this.yug1.gameState.player].army -= 30;
					this.yug1.gameState.yugcountries[this.country].army += 30;
					if (this.yug1.gameState.yugcountries[this.country].last)
					{
						this.yug1.gameState.yugregions[this.region].defence = this.yug1.DefenceRegionalPower(this.region);
					}
					this.ReRepaint();
				}
			}
		}
		else if (num == -8)
		{
			if (this.global1.science[1] && (this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) && this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30 && this.country != this.yug1.gameState.player)
			{
				this.yug1.gameState.yugcountries[this.yug1.gameState.player].army -= 30;
				this.yug1.gameState.yugcountries[this.country].army += 30;
				if (this.yug1.gameState.yugcountries[this.country].last)
				{
					this.yug1.gameState.yugregions[this.region].defence = this.yug1.DefenceRegionalPower(this.region);
				}
				this.ReRepaint();
			}
		}
		else if (num == -6 && this.yug1.gameState.yugcountries[this.country].temp_peace_count >= 2 && this.yug1.gameState.yugcountries[this.country].temp_peace && this.global1.data[9] >= 30 && !this.yug1.gameState.has_ally)
		{
			this.global1.data[9] -= 30;
			this.yug1.gameState.has_ally = true;
			this.yug1.gameState.yugcountries[this.country].is_ally = true;
			this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] = true;
			this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country] = true;
			this.ReRepaint();
		}
		this.Repaint();
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0018B3E4 File Offset: 0x001895E4
	void IButtonPressReceiver.OnButtonEnter(int num, SpriteRenderer spr)
	{
		if (num < 0)
		{
			spr.color = new Color(1f, 0.74f, 0f);
		}
		if (num < this.yug1.gameState.yugregions.Length && num >= 0)
		{
			spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 0f);
			return;
		}
		if (num == -1)
		{
			this.requirements.text = string.Format(this.yug1.science_text[56], new object[]
			{
				'\n',
				(!this.yug1.gameState.yugcountries[this.country].temp_peace && !this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country]) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 50) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, false) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				"49"
			});
			return;
		}
		if (num == -7)
		{
			this.requirements.text = string.Format(this.yug1.science_text[56], new object[]
			{
				'\n',
				(!this.yug1.gameState.yugcountries[this.country].temp_peace && !this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country]) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 150) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, false) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				"149"
			});
			return;
		}
		if (num == -2)
		{
			this.requirements.text = string.Format(this.yug1.science_text[57], '\n', (this.yug1.gameState.yugregions[this.region].control < 100) ? this.yug1.science_text[54] : this.yug1.science_text[55], (this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 50) ? this.yug1.science_text[54] : this.yug1.science_text[55]);
			return;
		}
		if (num == -3)
		{
			this.requirements.text = string.Format(this.yug1.science_text[58], new object[]
			{
				'\n',
				(!this.yug1.gameState.yugcountries[this.country].temp_peace && !this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && !this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country]) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= this.yug1.gameState.yugcountries[this.country].army * 2) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.global1.data[9] >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				this.yug1.gameState.yugcountries[this.country].temp_peace_time
			});
			return;
		}
		if (num == -4)
		{
			this.requirements.text = string.Format(this.yug1.science_text[59], new object[]
			{
				'\n',
				(this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.global1.data[8] >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				this.global1.science[7] ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.country].army > 0) ? this.yug1.science_text[54] : this.yug1.science_text[55]
			});
			return;
		}
		if (num == -5)
		{
			if (!this.yug1.gameState.battle_royal && this.yug1.gameState.yugcountries[this.country].money >= 15)
			{
				this.requirements.text = string.Format(this.yug1.science_text[179], new object[]
				{
					'\n',
					(this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.country].money >= 15) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.global1.science[1] ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, true) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(!this.yug1.gameState.yugcountries[this.country].traded) ? this.yug1.science_text[54] : this.yug1.science_text[55]
				});
				return;
			}
			if (this.yug1.gameState.yugcountries[this.country].money >= 15)
			{
				this.requirements.text = string.Format(this.yug1.science_text[113], new object[]
				{
					'\n',
					(this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.country].money >= 15) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.global1.science[1] ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.yug1.IsBorderedreion(this.region, this.yug1.gameState.player, true) ? this.yug1.science_text[54] : this.yug1.science_text[55]
				});
				return;
			}
			this.requirements.text = string.Format(this.yug1.science_text[108], new object[]
			{
				'\n',
				(this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.country].money < 50) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
				this.global1.science[1] ? this.yug1.science_text[54] : this.yug1.science_text[55]
			});
			return;
		}
		else
		{
			if (num == -8)
			{
				this.requirements.text = string.Format(this.yug1.science_text[108], new object[]
				{
					'\n',
					(this.yug1.gameState.yugcountries[this.country].temp_peace || (this.yug1.gameState.yugcountries[this.country].peace_with[this.yug1.gameState.player] && this.yug1.gameState.yugcountries[this.yug1.gameState.player].peace_with[this.country])) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.country].money < 50) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.yug1.gameState.yugcountries[this.yug1.gameState.player].army >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.global1.science[1] ? this.yug1.science_text[54] : this.yug1.science_text[55]
				});
				return;
			}
			if (num == -6)
			{
				this.requirements.text = string.Format(this.yug1.science_text[64], new object[]
				{
					'\n',
					(this.yug1.gameState.yugcountries[this.country].temp_peace_count >= 2) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(!this.yug1.gameState.has_ally) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					(this.global1.data[9] >= 30) ? this.yug1.science_text[54] : this.yug1.science_text[55],
					this.yug1.gameState.yugcountries[this.country].temp_peace_count
				});
			}
			return;
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0018C348 File Offset: 0x0018A548
	void IButtonPressReceiver.OnButtonExit(int num, SpriteRenderer spr)
	{
		if (num < 0)
		{
			spr.color = new Color(1f, 1f, 1f);
		}
		if (num < this.yug1.gameState.yugregions.Length && num >= 0)
		{
			spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1f);
			return;
		}
		this.requirements.text = "";
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0005AE31 File Offset: 0x00059031
	void IButtonPressReceiver.OnButtonStay(int num)
	{
	}

	// Token: 0x0400027E RID: 638
	public bool is_separate = true;

	// Token: 0x0400027F RID: 639
	public TextMesh description;

	// Token: 0x04000280 RID: 640
	public TextMesh requirements;

	// Token: 0x04000281 RID: 641
	public Yugoglobal yug1;

	// Token: 0x04000282 RID: 642
	private GlobalScript global1;

	// Token: 0x04000283 RID: 643
	public GameObject[] countries = new GameObject[12];

	// Token: 0x04000284 RID: 644
	public GameObject[] buttons = new GameObject[6];

	// Token: 0x04000285 RID: 645
	private int country = -1;

	// Token: 0x04000286 RID: 646
	private int region = -1;

	// Token: 0x04000287 RID: 647
	private Color a;
}
