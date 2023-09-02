using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class ending_script : MonoBehaviour
{
	// Token: 0x06000074 RID: 116 RVA: 0x00043874 File Offset: 0x00041A74
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.achieves = GameObject.Find("Ach(Clone)");
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
		this.dlce1.Init();
		if (this.global1.data[46] == 0)
		{
			for (int i = 40; i < 44; i++)
			{
				if (this.global1.allcountries[i] != null && this.global1.allcountries[i].Westalgie >= 1000)
				{
					this.guevara++;
				}
			}
			if (this.guevara >= 4 && this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(43);
			}
			for (int j = 0; j < this.global1.allcountries.Length; j++)
			{
				if (this.global1.allcountries[j] != null)
				{
					if (this.global1.allcountries[j].isOVD && !this.global1.allcountries[7].isOVD && j != this.global1.data[0])
					{
						this.military_ally++;
					}
					if (this.global1.allcountries[j].isSEV && !this.global1.allcountries[7].isSEV && j != this.global1.data[0])
					{
						this.economy_ally++;
						this.greece_ally++;
					}
					else if (this.global1.allcountries[j].isSEV && j != this.global1.data[0])
					{
						this.greece_ally++;
					}
				}
			}
			if (this.military_ally > 5)
			{
				this.yeye++;
			}
			if (this.economy_ally > 7)
			{
				this.yeye++;
			}
			if (this.yeye > 1 && this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(35);
			}
			if (this.global1.data[0] == 5)
			{
				if (this.global1.data[11] == 0 && this.global1.data[50] == 3)
				{
					this.sinochek = true;
					this.global1.data[5] -= 100;
				}
				else if (this.global1.data[11] == 0 && this.global1.data[50] == 4)
				{
					this.sinochek = true;
					this.global1.data[1] -= 100;
					this.global1.data[5] += 50;
				}
				if (this.global1.data[58] == 1)
				{
					this.global1.data[1] += 100;
					this.global1.data[3] += 100;
					this.global1.data[4] -= 100;
					this.global1.data[5] += 50;
				}
				else
				{
					this.global1.data[3] -= 50;
					this.global1.data[4] += 50;
					this.global1.data[5] -= 50;
				}
			}
			int num = this.global1.data[5] - (18 - this.global1.data[17]) * 100;
			int num2 = this.global1.data[4] + this.global1.data[10] / 3;
			GameObject.Find("Back").GetComponent<SpriteRenderer>().sprite = this.winfon;
			GameObject.Find("plane").GetComponent<SpriteRenderer>().sprite = this.winplan;
			if (this.global1.iron_and_blood)
			{
				if (this.global1.data[0] == 4 && this.global1.data[11] == 2)
				{
					this.achieves.GetComponent<achievements>().Set(50);
				}
				if (this.global1.data[0] == 20 && this.global1.data[11] == 2 && this.global1.data[15] == 6 && this.global1.data[16] == 10 && this.global1.data[17] == 14 && !this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					this.achieves.GetComponent<achievements>().Set(53);
				}
			}
			if (this.global1.data[14] <= 2 && this.global1.data[31] > 700 && this.global1.data[16] <= 12 && this.global1.data[18] <= 20)
			{
				this.global1.data[42] = 9;
				this.global1.data[5] -= 50;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(20);
				}
			}
			else if (this.global1.data[14] <= 3 && this.global1.data[31] > 700 && this.global1.data[16] >= 12 && (this.global1.data[18] >= 23 || this.global1.data[18] <= 18))
			{
				this.global1.data[42] = 10;
				this.global1.data[5] -= 50;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(21);
				}
			}
			else if (this.global1.data[14] <= 0 && (this.global1.data[1] < 500 || this.global1.data[22] < 500 || this.global1.data[31] < 300))
			{
				this.global1.data[42] = 1;
				this.sinochek = false;
				this.otstavnoysinochek = true;
			}
			else if (this.global1.data[14] <= 0 && this.global1.data[31] <= 700)
			{
				this.global1.data[42] = 2;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(15);
				}
				this.global1.data[5] -= 50;
			}
			else if (this.global1.data[14] <= 1 && this.global1.data[31] > 700 && this.global1.data[16] <= 11)
			{
				this.global1.data[42] = 9;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(20);
				}
			}
			else if (this.global1.data[14] <= 2 && this.global1.data[15] <= 7 && num < num2)
			{
				this.global1.data[42] = 3;
				this.sinochek = false;
				this.otstavnoysinochek = true;
			}
			else if (this.global1.data[14] <= 2 && this.global1.data[15] <= 7)
			{
				this.global1.data[42] = 4;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(16);
				}
			}
			else if (this.global1.data[14] <= 3 && ((this.global1.data[15] <= 8 && this.global1.data[17] <= 16) || this.global1.data[15] <= 7) && (this.global1.data[1] < 700 || this.global1.data[3] < 500 || this.global1.data[4] > 500))
			{
				this.global1.data[42] = 5;
				this.sinochek = false;
				this.otstavnoysinochek = true;
			}
			else if (this.global1.data[14] <= 3 && ((this.global1.data[15] <= 8 && this.global1.data[17] <= 16) || this.global1.data[15] <= 7))
			{
				this.global1.data[42] = 6;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(17);
				}
			}
			else if (this.global1.data[14] >= 4 && this.global1.data[16] >= 13 && this.global1.data[17] >= 16)
			{
				this.global1.data[42] = 7;
				this.sinochek = false;
			}
			else if (this.global1.data[14] >= 3)
			{
				this.global1.data[42] = 8;
				this.global1.data[5] += 50;
				this.sinochek = false;
				if (this.global1.iron_and_blood && this.global1.data[16] != 11)
				{
					this.achieves.GetComponent<achievements>().Set(19);
				}
			}
			else
			{
				this.global1.data[42] = 5;
				this.sinochek = false;
				this.otstavnoysinochek = true;
			}
			if (this.global1.data[0] == 20 && this.global1.data[56] >= 100 && this.global1.data[11] == 2 && this.global1.data[31] > 700)
			{
				this.global1.data[42] = 10;
			}
			else if (this.global1.data[0] == 20 && this.global1.data[56] >= 100 && this.global1.data[11] == 2)
			{
				this.global1.data[42] = 6;
			}
			if ((this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.data[42] == 10 || (this.global1.data[42] == 8 && (!this.global1.allcountries[this.global1.data[0]].isOVD || (this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.data[16] <= 10)))) && this.global1.data[16] <= 11)
			{
				this.global1.data[43] = 5;
				this.global1.data[5] += 50;
				if (this.global1.iron_and_blood && this.global1.data[42] == 8)
				{
					this.achieves.GetComponent<achievements>().Set(19);
				}
			}
			else if (this.global1.data[16] == 10)
			{
				this.global1.data[43] = 1;
				if (this.global1.science[5] && this.global1.data[43] == 1 && this.global1.data[18] <= 21 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18)
				{
					this.global1.data[43] = 2;
					this.global1.data[5] += 100;
					if (this.global1.iron_and_blood && this.global1.data[42] == 8)
					{
						this.achieves.GetComponent<achievements>().Set(18);
					}
				}
				else
				{
					this.global1.data[5] -= 50;
					this.global1.data[43] = 1;
				}
			}
			else if (this.global1.data[16] == 11)
			{
				this.global1.data[43] = 2;
				this.global1.data[5] += 200;
				if (this.global1.iron_and_blood && this.global1.data[42] == 8)
				{
					this.achieves.GetComponent<achievements>().Set(18);
				}
			}
			else if (this.global1.data[16] == 12)
			{
				this.global1.data[43] = 3;
			}
			else if (this.global1.data[16] == 13)
			{
				this.global1.data[43] = 4;
				this.global1.data[5] += 50;
			}
			else
			{
				this.global1.data[43] = 5;
			}
			if (this.global1.allcountries[24].Stasi && this.global1.data[55] >= 2)
			{
				this.global1.data[5] += 50;
			}
			if (this.global1.data[5] >= 990)
			{
				this.global1.data[44] = 1;
			}
			else if (this.global1.data[5] >= 750)
			{
				this.global1.data[44] = 2;
			}
			else if (this.global1.data[5] >= 500)
			{
				this.global1.data[44] = 3;
			}
			else
			{
				this.global1.data[44] = 4;
			}
			if (this.global1.data[44] == 1 && this.global1.data[43] == 2 && this.global1.data[42] == 3)
			{
				this.global1.data[42] = 4;
			}
			if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 0 && !this.global1.allcountries[7].Vyshi)
			{
				this.global1.data[45] = 7;
			}
			else if (this.global1.allcountries[7].isOVD && this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
			{
				this.global1.data[45] = 1;
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(30);
				}
			}
			else if ((this.global1.allcountries[7].isSEV || this.global1.allcountries[7].isOVD) && this.global1.data[7] >= 250 && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi)
			{
				this.global1.data[45] = 2;
			}
			else if ((this.global1.allcountries[7].isSEV && !this.global1.is_gkchp) || (this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi) || (this.global1.data[7] >= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.is_gkchp && !this.global1.allcountries[7].Vyshi))
			{
				this.global1.data[45] = 3;
			}
			else if ((!this.global1.allcountries[7].Vyshi && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2 && !this.global1.allcountries[7].Vyshi) || (!this.global1.is_gkchp && this.global1.data[7] <= 600 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].Vyshi))
			{
				this.global1.data[45] = 4;
			}
			else if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy == 1 && !this.global1.allcountries[7].Vyshi)
			{
				this.global1.data[45] = 6;
			}
			else
			{
				this.global1.data[45] = 5;
			}
			if (this.global1.data[0] == 1)
			{
				if (this.global1.data[11] == 0 && this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(3);
				}
				else if (this.global1.data[11] == 1 && this.global1.iron_and_blood && ((this.global1.data[15] <= 6 && this.global1.data[16] >= 13 && this.global1.data[17] <= 14 && this.global1.data[18] <= 18) || (this.global1.data[14] <= 0 && this.global1.data[16] >= 13)))
				{
					this.achieves.GetComponent<achievements>().Set(4);
				}
				else if (this.global1.data[11] == 3 && this.global1.iron_and_blood && this.global1.data[42] == 9)
				{
					this.achieves.GetComponent<achievements>().Set(13);
				}
			}
			if (this.global1.iron_and_blood)
			{
				if (!this.global1.is_save_bylo)
				{
					this.achieves.GetComponent<achievements>().Set(12);
				}
				if (this.global1.data[11] == 2 && this.global1.data[0] == 6 && this.global1.data[14] <= 0 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[7].isOVD && this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 1)
				{
					this.achieves.GetComponent<achievements>().Set(42);
				}
				int num3 = 0;
				for (int k = 0; k < 12; k++)
				{
					if (this.global1.allcountries[k] != null)
					{
						if (k != 4 && k != 7 && k != 8 && k != 10 && k != 11 && k != this.global1.data[0])
						{
							if (this.global1.allcountries[k].Gosstroy < 1)
							{
								num3++;
							}
						}
						else if ((k == 4 || k == 11) && this.global1.allcountries[k].Gosstroy <= 1)
						{
							num3++;
						}
					}
				}
				if (num3 >= 7)
				{
					this.achieves.GetComponent<achievements>().Set(14);
				}
			}
			if (this.global1.data[0] != 1 && this.global1.data[14] < 4 && this.global1.data[16] < 13 && (this.global1.iron_and_blood & this.global1.diff[4]))
			{
				this.achieves.GetComponent<achievements>().Set(48);
			}
			if (this.global1.iron_and_blood)
			{
				int num4 = 0;
				int num5 = 0;
				for (int l = 0; l < this.global1.allcountries.Length; l++)
				{
					if (this.global1.allcountries[l].Gosstroy == 0 && l != 7 && l != this.global1.data[0])
					{
						num4++;
					}
					else if (this.global1.allcountries[l].Gosstroy == 1 && l != 7 && l != this.global1.data[0])
					{
						num5++;
					}
				}
				if (this.global1.allcountries[4].Gosstroy == 0)
				{
					num5++;
					num4--;
				}
				else if (this.global1.data[0] == 4)
				{
					num5++;
					num4--;
				}
				if (num4 >= 17 && num5 >= 7)
				{
					this.achieves.GetComponent<achievements>().Set(49);
				}
			}
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.global1.data[46] == 1 && this.global1.data[0] != 12)
			{
				this.Name.text = "OVERTHROWN BY THE REVOLUTION";
				if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
				{
					this.text_fake = "Because of your conservative policy";
				}
				else if (this.global1.data[14] < 1 || this.global1.data[14] > 4)
				{
					this.text_fake = "Because of your extremely radical and hasty policy";
					if (this.global1.data[14] > 4 && this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(6);
					}
				}
				else
				{
					this.text_fake = "Because of your uncertain and unstable policy";
				}
				if (this.global1.data[5] < 400)
				{
					this.text_fake += " and broad social problems";
				}
				this.text_fake += " people, expecting much more, get furious. They were completely dissatisfied with the reforms you carried out and the situation in the country became even more heated. Enraged crowds took to the streets demanding the resignation of the leadership, however, when the police arrived for rallies to ensure security, it was perceived as an attempt to disperse the people's marches (although perhaps foreign provocateurs took part in it), as a result, the confrontation began. The police retreated, refusing to shoot at the people, and crowds began pogroms and seizure of the administrative buildings and archives of the special services. The soldiers refused to leave the barracks and the resistance of the special services and individual policemen was soon suppressed.";
				if (this.global1.allcountries[19].Help)
				{
					this.text_fake += "|However, the higher ranks of the party managed to escape in time from the country through established channels and obtain political asylum in India.";
					if (this.global1.allcountries[19].Gosstroy <= 1 && this.global1.data[21] > 1989)
					{
						this.text_fake = this.text_fake + " And despite the international pressure, the INC government, to reward for supporting them, did not extradit anyone, having settled the 'refugees' in goverment buildings, where, afterwards, " + this.global1.politics_name[this.global1.data[11]] + " wrote memoirs and autobiography in which he declared himself the last and missed chance of his country to save.";
					}
					else
					{
						this.text_fake += " However, under international pressure, the new Indian government was forced to begin the process of extradition of the incoming party members, as a result of which you all took refuge in the Argentine embassy and, through secret channels, were taken to various countries of Latin America, having changed passport data. ";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|",
						this.global1.politics_name[this.global1.data[11]],
						",  while attempting to escape, was captured and executed without trial and investigation by a hastily organized revolutionary tribunal, along with some higher party leaders. The rest were imprisoned for different periods, but by ",
						this.global1.data[21] + 5,
						" they received an amnesty for health reasons."
					});
				}
				if (this.global1.data[0] == 1)
				{
					if (this.global1.data[16] <= 12)
					{
						this.text_fake += "|The SED was banned, and a single center-right coalition won the election, which decided to join the FRG. The industry was privatized by different owners, as a result  the centralized unified management of the economy of the former GDR was violated, after which most of the enterprises were found to be unprofitable and closed, so the central government of Germany had to impose a special tax to redirect finance to the development of the territories of the former GDR.";
					}
					else
					{
						this.text_fake += "|The SED was banned, and a single center-right coalition won the election, which decided to join the FRG. The industry was privatized by different owners, but earlier reforms of the East German government made it easier to survive integration into the market economy of West Germany.";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|The first, according to Western journalists, most free election was won by the center-right coalition, and as a result, the country became a permanent member of NATO by ",
						this.global1.data[21] + 8,
						"."
					});
				}
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 1)
			{
				this.Name.text = "OVERTHROW BY THE REVOLUTION";
				this.text_fake = "Due to your uncertain and unstable policy, the people who lost hope in the PDPA regime began to take the side of the opposition, the desertion was not uncommon in the army, and the last military defeats of the DRA became the last straw and in the cradle of the April Revolution - Kabul mass protests erupted, which quickly transformed into rebellion. Attempts to disperse the demonstration were unsuccessful, and the rebels broke into government offices, starting lynching against managers and party workers. As a result, anarchy erupted in Kabul, against which terrorists were able to successfully launch an offensive and take the capital, declaring Afghanistan an Islamic republic.";
			}
			else if (this.global1.data[46] == 2 && this.global1.data[0] != 12)
			{
				this.Name.text = "PEOPLE'S UNREST";
				if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
				{
					this.text_fake = "Because of your conservative policy";
				}
				else if (this.global1.data[14] < 1 || this.global1.data[14] > 4)
				{
					this.text_fake = "Because of your extremely radical and hasty policy";
				}
				else
				{
					this.text_fake = "Because of your uncertain and unstable policy";
				}
				if (this.global1.data[5] < 400)
				{
					this.text_fake += " and broad social problems";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(7);
					}
				}
				this.text_fake = string.Concat(new string[]
				{
					this.text_fake,
					"  the people, who had lost patience, began organizing mass strikes and rallies, which lasted several weeks and turned into whole tent cities. In the meantime, the party apparatus began to doubt its leader and some of its representatives secretly organized a conspiracy, as a result of which ",
					this.global1.politics_name[this.global1.data[11]],
					" was overthrown, and after him his other approximate figures. But the rallies did not stop and under their pressure and pressure of young cadres, moderate representatives also left. A consequence of this was a massive update of the governing leadership of ",
					this.global1.party_name[0],
					" and the final liberalization of the regime. The leading party was renamed, criminal case was opened against the former leaders."
				});
				if (this.global1.allcountries[19].Help)
				{
					this.text_fake += "|However, the higher ranks of the party managed to escape in time from the country through established channels and obtain political asylum in India.";
					if (this.global1.allcountries[19].Gosstroy <= 1)
					{
						this.text_fake = this.text_fake + " And despite the international pressure, the INC government, to reward for supporting them, did not extradit anyone, having settled the 'refugees' in goverment buildings, where, afterwards, " + this.global1.politics_name[this.global1.data[11]] + " wrote memoirs and autobiography in which he declared himself the last and missed chance of his country to save.";
					}
					else
					{
						this.text_fake += " However, under international pressure, the new Indian government was forced to begin the process of extradition of the incoming party members, as a result of which you all took refuge in the Argentine embassy and, through secret channels, were taken to various countries of Latin America, having changed passport data. ";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|",
						this.global1.politics_name[this.global1.data[11]],
						", while attempting to escape, was seized and isolated in solitary confinement. The rest were imprisoned for different periods, but by ",
						this.global1.data[21] + 5,
						" they received an amnesty for health reasons."
					});
				}
				if (this.global1.data[0] == 1)
				{
					if (this.global1.data[16] <= 12)
					{
						this.text_fake += "|The SED was transformed into the Party of Democratic Socialism by joining the coalition with the opposition, and a single center-right alliance won the election, which decided to join the FRG. The industry was privatized by different owners, as a result  the centralized unified management of the economy of the former GDR was violated, after which most of the enterprises were found to be unprofitable and closed, so the central government of Germany had to impose a special tax to redirect finance to the development of the territories of the former GDR.";
					}
					else
					{
						this.text_fake += "|The SED was transformed into the Party of Democratic Socialism by joining the coalition with the opposition, and a single center-right alliance won the election, which decided to join the FRG. The industry was privatized by different owners, but earlier reforms of the East German government made it easier to survive integration into the market economy of West Germany.";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|The first, according to Western journalists, most free election was won by the center-right coalition, and as a result, the country became a permanent member of NATO by ",
						this.global1.data[21] + 8,
						"."
					});
				}
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 2)
			{
				this.Name.text = "PEOPLE RIOTS";
				this.text_fake = "Due to your uncertain and unstable policy, the people who lost hope in the PDPA regime began to take the side of the opposition, the desertion was not uncommon in the army, and the last military defeats of the DRA became the last straw and in the cradle of the April Revolution - Kabul erupted protests against the current government. Unhappy with your weakness and inaction, the generals tried to organize a military coup in order to establish order in the capital, but the army refused to shoot at the townspeople and switched to their side. As a result, anarchy erupted in Kabul, against which terrorists were able to successfully launch an offensive and take the capital, declaring Afghanistan an Islamic republic.";
			}
			else if (this.global1.data[46] == 3 && this.global1.data[0] != 12)
			{
				bool flag = false;
				this.Name.text = "PARTY COUP";
				this.text_fake = "Your political steps have make more and more angry the party apparatus and their patience has come to an end. Some high-ranking personalities of " + this.global1.party_name[0] + " colluded in which was involved even ";
				int num6 = UnityEngine.Random.Range(0, 3);
				if (num6 == 0)
				{
					this.text_fake += "Minister of Internal Affairs. ";
				}
				else if (num6 == 1)
				{
					this.text_fake += "Minister of Defense. ";
				}
				else if (num6 == 2)
				{
					this.text_fake += "Head of special services. ";
				}
				if (this.global1.data[0] == 1)
				{
					this.global1.data[10] += 250;
				}
				this.text_fake = this.text_fake + "The next day after the conspiracy was organized at the Politburo meeting, a group of conspirators made harsh accusations against " + this.global1.politics_name[this.global1.data[11]] + " during which even second secretary decided not to argue and, under the silence of other members of the Politburo, our leader resigned for health reasons.";
				if (this.global1.data[22] >= 700 && this.global1.data[31] >= 700 && (this.global1.data[14] > 2 || !this.global1.allcountries[10].Help) && this.global1.data[10] < 500)
				{
					this.text_fake = this.text_fake + " In the course of the party reshuffles, a coalition of supporters of sovereignty and previously raised up nationalists came to power, having formed an updated people's government: " + this.global1.party_name[0] + " was renamed into the People's Rebirth Party, the government signed a concordat with the church, and the state became the largest shareholder in the the domestic market, which, together with the opening of free trade and the legalization of all kinds of entrepreneurship, led to the formation of the state capitalism. The new leadership began to lead the country in the mainstream of the national way of building a society of class solidarity.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(9);
					}
					flag = true;
				}
				else if (this.global1.data[22] >= 500 && this.global1.data[31] >= 700 && this.global1.data[14] <= 2 && this.global1.allcountries[10].Help && this.global1.data[10] < 500)
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						" In the course of the party reshuffles, a coalition of supporters of socialism with reliance on internal force came to power, having formed a national-people's government. ",
						this.global1.party_name[0],
						" condemned the revisionism of other left-wing parties, adopting an updated program: \"a world view centered on a person, and revolutionary ideas aimed at exercising the independence of the masses.\" ",
						this.global1.allcountries[this.global1.data[0]].name,
						" became a closed country, with brutal authoritarian power and militaristic centralized control, by ",
						this.global1.data[21] + 21,
						" year announcing the creation of its own nuclear weapons, however, despite the massive sanctions, the country continues to exist..."
					});
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(8);
					}
					flag = true;
				}
				else if (this.global1.data[22] >= 500 && this.global1.data[31] >= 700 && this.global1.data[10] >= 500)
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						" In the course of the party reshuffles, a coalition of supporters of sovereignty, socialism with reliance on internal forces and previously raised up nationalists came to power, which led to serious hysteria in the West. In the end, public opinion was expressed by the American side at a meeting of the UN Security Council, during which unanimously a decision was made to introduce a no-flight zone, to recognize the coup as illegitimate, and to approve mass sanctions. As a consequence, the opposition financed by Western special services launched an armed uprising in the country. Bombers and aviation of NATO joined it. The ruling regime fell and the country returned to democratic positions, by ",
						this.global1.data[21] + 8,
						" year having entered NATO."
					});
				}
				else
				{
					this.text_fake += " In the course of the party reshuffles, a coalition of supporters of reform - democratic socialists, democratic communists and left-wing Social Democrats, came to power, beginning a complete withdrawal of state control over the army and other institutions, substantially cutting down the rights of special services and liberalized the regime.";
				}
				if (this.global1.allcountries[19].Help)
				{
					this.text_fake += "|However, the higher ranks of the party managed to escape in time from the country through established channels and obtain political asylum in India.";
					if (this.global1.allcountries[19].Gosstroy <= 1)
					{
						this.text_fake = this.text_fake + " And despite the international pressure, the INC government, to reward for supporting them, did not extradit anyone, having settled the 'refugees' in goverment buildings, where, afterwards, " + this.global1.politics_name[this.global1.data[11]] + " wrote memoirs and autobiography in which he declared himself the last and missed chance of his country to save.";
					}
					else
					{
						this.text_fake += " However, under international pressure, the new Indian government was forced to begin the process of extradition of the incoming party members, as a result of which you all took refuge in the Argentine embassy and, through secret channels, were taken to various countries of Latin America, having changed passport data. ";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|",
						this.global1.politics_name[this.global1.data[11]],
						", while attempting to escape, was seized and isolated in solitary confinement. The rest were imprisoned for different periods, but by ",
						this.global1.data[21] + 5,
						" they received an amnesty for health reasons."
					});
				}
				if (this.global1.data[0] == 1 && (this.global1.data[22] < 700 || this.global1.data[31] < 700))
				{
					if (this.global1.data[16] <= 12)
					{
						this.text_fake += "|The SED was transformed into the Party of Democratic Socialism by joining the coalition with the opposition, and a single center-right alliance won the election, which decided to join the FRG. The industry was privatized by different owners, as a result  the centralized unified management of the economy of the former GDR was violated, after which most of the enterprises were found to be unprofitable and closed, so the central government of Germany had to impose a special tax to redirect finance to the development of the territories of the former GDR.";
					}
					else
					{
						this.text_fake += "|The SED was transformed into the Party of Democratic Socialism by joining the coalition with the opposition, and a single center-right alliance won the election, which decided to join the FRG. The industry was privatized by different owners, but earlier reforms of the East German government made it easier to survive integration into the market economy of West Germany.";
					}
				}
				else if ((this.global1.data[22] < 700 || this.global1.data[31] < 700) && !flag)
				{
					this.text_fake += "In the first elections, the renewed Socialist Party won out confidently, taking up most of the seats in the parliament, but their celebration did not last long: among the people was found a compromising evidence on the first secretary of the renewed Party, who mentioned that it would be better to introduce Soviet tanks than to indulge the right opposition, as a result of which new mass rallies were held all over the country and the entire leadership of the Party resigned, and the center-right coalition came to power. The country became a permanent member of NATO by " + (this.global1.data[21] + 8);
				}
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 3)
			{
				this.Name.text = "PARTY COUP";
				if (this.global1.data[11] == 2)
				{
					this.text_fake = "The thoughtless and inconsistent policy of Najibullah began to anger the Parchamists, who decided to enter into a conspiracy against the president, with the support of the USSR. The day after the conspiracy was organized at a meeting of the Politburo, a group of conspirators made sharp accusations against Najibullah, and he, under the pressure of party members, was forced to resign due to health reasons. The government of the next country's leader, in an attempt to start negotiations with the opposition, more and more making concessions to terrorists, failed. As a result, after the collapse of the USSR, the DRA government lost its support, and the opposition entered Kabul without a fight, establishing an Islamic republic in Afghanistan.";
				}
				else if (this.global1.data[11] == 1)
				{
					this.text_fake = "The thoughtless and inconsistent policy of Tanai began to anger the Khalqists, who decided to enter into a conspiracy against the president, with the support of the generals. The day after the conspiracy was organized at a meeting of the Politburo, a group of conspirators made sharp accusations against Tanai, and he, under the pressure of party members, was forced to resign due to health reasons. The tough policies of the next leader and his multiple failed attacks on terrorists lead to large-scale desertion from the Afghan army and the transition to the side of the opposition. As a result, after the collapse of the USSR, the DRA government lost its support, and the opposition entered Kabul without a fight, establishing an Islamic republic in Afghanistan.";
				}
				else if (this.global1.data[11] == 3)
				{
					this.text_fake = "The thoughtless and inconsistent policy of Dostum began to anger more and more representatives of the government, who decided to enter into a conspiracy against the president, with the support of the generals. The day after the conspiracy was organized at a meeting of the Politburo, a group of conspirators made sharp accusations against Dostum, and he, under the pressure of party members, was forced to resign due to health reasons. The tough policies of the next leader and his multiple failed attacks on terrorists lead to large-scale desertion from the Afghan army and the transition to the side of the opposition. As a result, after the collapse of the USSR, the DRA government lost its support, and the opposition entered Kabul without a fight, establishing an Islamic republic in Afghanistan.";
				}
				else if (this.global1.data[11] == 0)
				{
					this.text_fake = "The thoughtless and inconsistent policy began to anger more and more representatives of the government, who decided to enter into a conspiracy against the president, with the support of the generals. The day after the conspiracy was organized at a meeting of the Politburo, a group of conspirators made sharp accusations against the President, and he, under the pressure of party members, was forced to resign due to health reasons. The tough policies of the next leader and his multiple failed attacks on terrorists lead to large-scale desertion from the Afghan army and the transition to the side of the opposition. As a result, after the collapse of the USSR, the DRA government lost its support, and the opposition entered Kabul without a fight, establishing an Islamic republic in Afghanistan.";
				}
			}
			else if (this.global1.data[46] == 4 && this.global1.data[0] == 10)
			{
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(59);
				}
				this.Name.text = "Washington - Moscow - Beijing";
				this.text_fake = "Your unfriendly and overly militaristic foreign policy has begun to anger nearby countries, which were afraid of strengthening the military-strategic independence of the DPRK. As a result, in June 1992, Washington, Beijing and Moscow put forward a proposal to the UN Security Council for a «Settlement of the Korean Question». The leading countries of the world accuse North Korea of actively developing nuclear weapons, brutal and repressive domestic policies, as well as of numerous provocations near the demilitarized zone. As a result, most countries of the world, with few exceptions, adopt a UN resolution that prohibits the maintenance of any trade and economic ties with the blockade, and sanctions are imposed on the DPRK top leadership. Despite this, the North managed to resist political and economic pressure for some time, however, soon a UN peacekeeping contingent was sent to the country to eliminate the «Korean threat». UN forces quickly occupy strategic military points in the country and launch an attack on Pyongyang. Despite the abundant propaganda in the spirit of the Korean War, the Koreans themselves are enthusiastic about peacekeepers, calling them «saviors». In the end, the leadership of the DPRK was isolated in the Kumsusan Palace. After a successful assault, they were all sent to the Hague for «crimes against peace and humanity». By decision of the UN Security Council, a temporary unlimited demilitarized zone was established in North Korea, and the Transitional Administration was established, headed by the son of Kim Jong Il, Kim Jong Nam, who is actually a UN puppet. After all this, agreements were reached between the PRC and the USA, according to which the US undertake not to deploy troops in the territory of the former DPRK, and the PRC, in turn, vows not to interfere in the affairs of New Korea.";
			}
			else if (this.global1.data[46] == 4)
			{
				this.Name.text = "NATO INVASION";
				if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
				{
					this.text_fake = "Your authoritarian and brutal rule, along with active intervention in international events, led to serious hysteria in the West.";
				}
				else if (this.global1.data[14] < 1)
				{
					this.text_fake = "Your brutal and bloody rule, along with active intervention in international events, led to serious hysteria in the West.";
				}
				else if (this.global1.data[14] > 3 && this.global1.data[22] >= 700 && this.global1.data[31] >= 700)
				{
					this.text_fake = "Your brutal and nationalist rule, along with active intervention in international events, led to serious hysteria in the West.";
				}
				else
				{
					this.text_fake = "Your independent and sovereign rule and your attempts to actively intervene in international events in an attempt to become a new leading force in the world have led to widespread discontent in the West.";
				}
				this.text_fake += " The Americans called an urgent meeting of the UN Security Council, where they announced the infringement of national minorities in our country, the active production of chemical weapons, the active development of nuclear weapons and the existence of an authoritarian mafia government with massive repressions of unwanted.";
				if (this.global1.data[14] < 3 || (this.global1.data[14] > 4 && this.global1.data[22] >= 700 && this.global1.data[31] >= 700))
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"At this meeting unanimously a decision was made to introduce a no-flight zone and to approve mass sanctions. As a consequence, the opposition financed by Western special services launched an armed uprising in the country. Bombers and aviation of NATO joined it. The ruling regime fell and the country returned to democratic positions, by ",
						this.global1.data[21] + 8,
						" year having entered NATO."
					});
				}
				else if (this.global1.data[14] < 4)
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"At this meeting, only NATO members supported American initiatives, and China and Russia abstained from voting, as a result of which a decision was made to introduce a no-flight zone and to approve mass sanctions. As a consequence, the opposition financed by Western special services launched an armed uprising in the country. Bombers and aviation of NATO joined it. The ruling regime fell and the country returned to democratic positions, by ",
						this.global1.data[21] + 8,
						" year having entered NATO."
					});
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"At this meeting, China and Russia sharply opposed the US initiative, because even NATO members, with the exception of Great Britain, abstained from voting, as a result of which a joint decision was not adopted to introduce a no-fly zone and to approve mass sanctions. However, despite the UN decision, the Americans announced the introduction of a no-fly zone, all kinds of sanctions and blockade, and then the opposition financed by Western special services launched an armed uprising in the country. It was joined by bombers, marines and aviation of US. The ruling regime fell and the country returned to democratic positions, by ",
						this.global1.data[21] + 8,
						" year having entered NATO."
					});
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(10);
					}
				}
				if (this.global1.allcountries[19].Help)
				{
					this.text_fake += "|However, the higher ranks of the party managed to escape in time from the country through established channels and obtain political asylum in India.";
					if (this.global1.allcountries[19].Gosstroy <= 1)
					{
						this.text_fake = this.text_fake + " And despite the international pressure, the INC government, to reward for supporting them, did not extradit anyone, having settled the 'refugees' in goverment buildings, where, afterwards, " + this.global1.politics_name[this.global1.data[11]] + " wrote memoirs and autobiography in which he declared himself the last and missed chance of his country to save.";
					}
					else
					{
						this.text_fake += " However, under international pressure, the new Indian government was forced to begin the process of extradition of the incoming party members, as a result of which you all took refuge in the Argentine embassy and, through secret channels, were taken to various countries of Latin America, having changed passport data. ";
					}
				}
				else
				{
					this.text_fake = string.Concat(new object[]
					{
						this.text_fake,
						"|",
						this.global1.politics_name[this.global1.data[11]],
						", while attempting to escape, was seized and isolated in solitary confinement, and then hanged by the people's tribunal. The rest were imprisoned for different periods, but by ",
						this.global1.data[21] + 5,
						" they received an amnesty for health reasons."
					});
				}
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 5)
			{
				this.Name.text = "INVASION OF THE USSR";
				if (this.global1.allcountries[7].Gosstroy == 0)
				{
					this.text_fake = "Your overly independent and revisionist rule has infuriated the new Soviet leaders. And since you could not provide due support of the people, nor a strong army, nor external diplomatic protection, the Soviet Union was able to re-establish its control over your territory with joy.|After that, the USSR regained control over most of its international sphere. Under the leadership of the new President of the USSR, Comrade Alksnis, the Soviet Union, led by a mixed economy, once again became a world power.";
				}
				else
				{
					this.text_fake = "Your overly independent and revisionist rule has infuriated the new Soviet leaders. And since you could not provide due support of the people, nor a strong army, nor external diplomatic protection, the Soviet Union was able to re-establish its control over your territory with joy.|After that, the USSR regained control over most of its international sphere. Under the leadership of the new President of the USSR, Comrade Pugo, the Soviet Union, led by a mixed economy, once again became a world power.|A couple of years later, in perfect secrecy, Gorbachev was retired for health reasons and began to live quietly under the supervision of the KGB.";
				}
				this.text_fake = string.Concat(new string[]
				{
					this.text_fake,
					"|",
					this.global1.politics_name[this.global1.data[11]],
					" was expelled from the ruling party with shame and sent into exile, and the ",
					this.global1.party_name[0],
					" was renamed the Communist Party."
				});
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(11);
				}
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 6 && this.global1.data[0] != 12)
			{
				this.Name.text = "YOUR LAST ELECTIONS";
				this.text_fake = "You lost the election. And losers aren't needed by anyone.";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 6)
			{
				this.Name.text = "LAST ELECTIONS";
				this.text_fake = "Despite our peacekeeping goals, we were not able to win the first free elections, and as a result, the absolute majority in the parliament was occupied by Islamic fundamentalists, who, after the formation of the government, repealed all the PDPA decrees, having previously banned it and started arresting its leaders. As a result, due to the reactionary policies of the new leadership, in the traditionally pro-socialist regions, unrest begins, transiently turning into pogroms and bloody uprisings. It seems that a new civil war cannot be avoided.";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 7)
			{
				this.Name.text = "Afterglow of Hoxhaism";
				this.text_fake = "Albania is transforming into theocracy. There are not very many dissatisfied with these changes, but women's rights are already declining, the burqa has become mandatory, the introduction of Sharia law has begun, and the imams are gaining more power. Nexhmije Hoxha, the first and only female ruler, became nothing more than a puppet of the clergy of her own free will. ";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 8)
			{
				this.Name.text = "Fall of Juche's Sun";
				this.text_fake = "Because of the increased militarization and the aggressive foreign policy of North Korea, The United States of America, with the support of their allies, managed to get their resolution approved by the UN Security Council - to immediately intervene militarily into DPRK, to put an end to the North's  very much independent and unpredictable political course and to prevent a massive military conflict with the South. And even our former ally China betrayed us, not having said anything in our support. After the imperialist invasion into North Korea, and the first great catastrophical defeats of the North Korean Army, the Army commanders decide to not use nuclear weapons, and conspiring together with the USA, do a coup d'etat against the country's leader O Jin-u and then give him up to the UN military contingent. There is essentially a \"new Nuremberg Trial\" which occurs with the Generalissimus of the DPRK, as a result of which he is executed together with some of his closest conspirators. After the massive defeat of the DPRK, the process of integration of it into the Republic of Korea began, and now after so many casualties, the Korean people are united gain and many troubles await them in the future.";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 9)
			{
				this.Name.text = "THIRD KOREAN WAR";
				this.text_fake = string.Concat(new string[]
				{
					"In early December 1991, North Korea began full militarization. The divisions and armaments of the Korean People’s Army were transported in complete secret from the outside world and the public to the 38th parallel. December 31, on the eve of the new 1992, the DPRK leader ",
					this.global1.politics_name[this.global1.data[11]],
					" announced that «American puppet - South Korea launched a missile attack on North Korean positions, thereby violating the demilitarized zone between the two countries». After that, the North Korean troops, under the guise of artillery, attacked the positions of South Korea, and soon the tank divisions in the reserve joined them. The effect of surprise and lightning blitzkrieg was able to ensure the DPRK's successful offensive in the early days of the new Korean War. North Korean propaganda during this time has already begun to agitate «For the war to the victory end» and «Liberation of the Homeland from Colonial Slavery of the USA». Head of the DPRK ",
					this.global1.politics_name[this.global1.data[11]],
					" was equated with the rank of the great Korean military commanders, standing on a par with Li Songsin and Jong Bon-soo. Nevertheless, the Korean offensive was quickly drowned, and the mobilized forces of the US military base in Korea with renewed vigor began the operation to liberate the South. Exalted by official propaganda «the victorious workers' army of Korea» fell apart under the blows of the Americans and did not hold the front, after which a stampede began, the war quickly moved to the territory of the North. Contrary to the expectations of the leadership, the PRC did not intercede for the North, and, as a result, the high command disobeyed the order of the incumbent president to launch a nuclear attack on South Korea, deciding to extradite the DPRK president to America in exchange for preserving his own skins. A few days later, Pyongyang fell almost without resistance. Korea has become united, and a new tribunal is convening in The Hague to sentence leaders to the DPRK."
				});
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(59);
				}
			}
			else if (this.global1.data[46] == 10)
			{
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(64);
				}
				this.Name.text = "Islamic State of\nAfghanistan";
				this.text_fake = "|||After the withdrawal of Soviet troops, the situation in Afghanistan began to deteriorate rapidly - the inconsistent PDPA policy, together with disagreements in it and in the army leadership, led the people to turn their backs on the Afghan government, and the army hardly restrained the onslaught of terrorists. Caught in international isolation, Afghanistan could not get outside support, and Pakistan continued to send more and more Islamist groups with impunity. Terrorists managed to take Kabul, proclaiming Afghanistan an Islamic state. All the gains of Soviet power in social, economic and legal fields were destroyed. And after 4 years, " + this.global1.politics_name[this.global1.data[11]] + " himself was brutally murdered without trial.";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 11)
			{
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(64);
				}
				this.Name.text = "Islamic State of\nAfghanistan";
				this.text_fake = "|||After the withdrawal of soviet army, situation in Afghanistan began to deteriorate rapidly - inconsistent policy of PDPA together with disagreements inside it and among military leadership resulted in that the people became more opposed to the government and army could hardly resist mujahadeen's onslaught. Afghanistan appeared in international isolation, could not get any external support, while Pakistan continued to send more and more islamists without any negative consequences for itself. Mujahadeen managed to capture Kabul and proclaim Afghanistan an islamic state. All socialist achievments in social, economical and legal areas were destroyed. 4 years later " + this.global1.politics_name[this.global1.data[11]] + " himself was brutally murdered without trial.";
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 23)
			{
				this.Name.text = this.dlce1.credits_text[240];
				this.text_fake = this.dlce1.credits_text[202];
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 12)
			{
				this.Name.text = "Hungarian Romania";
				this.text_fake = this.dlce1.credits_text[29];
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] >= 13 && this.global1.data[46] <= 22)
			{
				Debug.LogError(this.global1.data[46]);
				this.Name.text = this.dlce1.credits_text[51 + this.global1.data[46]];
				this.text_fake = this.dlce1.credits_text[61 + this.global1.data[46]];
				Debug.LogError(this.dlce1.credits_text[51 + this.global1.data[46]]);
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == -1)
			{
				this.Name.text = this.dlce1.credits_text[114];
				this.text_fake = this.dlce1.credits_text[112];
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == -2)
			{
				this.Name.text = this.dlce1.credits_text[115];
				this.text_fake = this.dlce1.credits_text[113];
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
				GameObject.Find("Back").GetComponent<SpriteRenderer>().sprite = this.winfon;
				GameObject.Find("plane").GetComponent<SpriteRenderer>().sprite = this.winplan;
			}
			else if (this.global1.data[46] <= -3 && this.global1.data[46] >= -6)
			{
				this.Name.text = this.dlce1.credits_text[119 - this.global1.data[46] - 3];
				this.text_fake = this.dlce1.credits_text[123 - this.global1.data[46] - 3];
				UnityEngine.Object.Destroy(this.button_l);
				UnityEngine.Object.Destroy(this.button_r);
			}
			else if (this.global1.data[46] == 0)
			{
				if (this.global1.data[128] == 2)
				{
					this.yug1.gameState.yugregions[1].owner = 1;
				}
				if (this.global1.data[136] == 1 && this.global1.data[137] == 1)
				{
					this.yug1.gameState.yugregions[3].owner = 3;
				}
				this.ThisEndingWindow(null, 0);
			}
		}
		else if (this.global1.data[46] == 1 && this.global1.data[0] != 12)
		{
			this.Name.text = "СВЕРЖЕНИЕ РЕВОЛЮЦИЕЙ";
			if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
			{
				this.text_fake = "Из-за вашей консервативной политики";
			}
			else if (this.global1.data[14] < 1 || this.global1.data[14] > 4)
			{
				this.text_fake = "Из-за вашей чрезмерно радикальной и поспешной политики";
				if (this.global1.data[14] > 4 && this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(6);
				}
			}
			else
			{
				this.text_fake = "Из-за вашей неуверенной и неустойчивой политики";
			}
			if (this.global1.data[5] < 400)
			{
				this.text_fake += " и широких социальных проблем";
			}
			this.text_fake += " народ, ожидавший куда большего, пришел в ярость. Его абсолютно не удовлетворили проводимые вами реформы и ситуация в стране накалилась еще больше. Разъяренные толпы вышли на улицы с требованиями отставки руководства, однако, когда полиция подоспела к митингам для обеспечения безопасности, это было воспринято как попытка разогнать народные шествия (хотя, может быть, здесь постарались и иностранные провокаторы), вследствие чего началось противостояние. Полиция отступила, отказываясь стрелять в народ, и толпы начали погромы и захват административных зданий и архивов спецслужб. Солдаты отказались выходить из казарм, и сопротивление сотрудников спецслужб и отдельных полицейских вскоре было подавлено.";
			if (this.global1.allcountries[19].Help)
			{
				this.text_fake += "|Однако, высшие чины партаппарата сумели вовремя сбежать из страны по налаженным каналам и получить политическое убежище в Индии.";
				if (this.global1.allcountries[19].Gosstroy <= 1 && this.global1.data[21] > 1989)
				{
					this.text_fake = this.text_fake + " И, несмотря на международное давление, благодарное нам за поддержку правительство ИНК никого не выдало, поселив 'беженцев' в казённых помещениях, где, впоследствии, " + this.global1.politics_name[this.global1.data[11]] + " написал мемуары и автобиографию, в которых объявил себя последним и упущенным шансом своей страны на спасение.";
				}
				else
				{
					this.text_fake += " Впрочем, под международным давлением, новое индийское правительство вынуждено было начать процесс экстрадиции прибывших партаппаратчиков, следствием чего вы все укрылись в аргентинском посольстве и по тайным каналам были вывезены в разные страны Латинской Америки, сменив паспортные данные. ";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|",
					this.global1.politics_name[this.global1.data[11]],
					", при попытке бегства, был схвачен и казнен без суда и следствия наспех организованным революционным трибуналом, вместе с некоторыми высшими партийными деятелями. Остальные были посажены в тюрьму на разные сроки, но к ",
					this.global1.data[21] + 5,
					" году получили амнистию по состоянию здоровья."
				});
			}
			if (this.global1.data[0] == 1)
			{
				if (this.global1.data[16] <= 12)
				{
					this.text_fake += "|СЕПГ была запрещена, а на выборах победила единая правоцентристская коалиция, принявшая решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, вследствие этого было нарушено централизованное единое управление экономикой бывшей ГДР, после чего большая часть предприятий были признаны убыточными и закрыты, поэтому центральному правительству ФРГ пришлось вводить специальный налог для перенаправления финансов в развитие территорий бывшей ГДР.";
				}
				else
				{
					this.text_fake += "|СЕПГ была запрещена, а на выборах победила единая правоцентристская коалиция, принявшая решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, однако ранее проведенные реформы восточногерманского правительства позволили более легко пережить интеграцию в рыночную экономику Западной Германии.";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|На первых, по словам западных журналистов, самых свободных выборах победила правоцентристская коалиция, вследствие чего к ",
					this.global1.data[21] + 8,
					" году страна тала постоянным членом НАТО."
				});
			}
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 2 && this.global1.data[0] != 12)
		{
			this.Name.text = "НАРОДНЫЕ ВОЛНЕНИЯ";
			if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
			{
				this.text_fake = "Из-за вашей консервативной политики";
			}
			else if (this.global1.data[14] < 1 || this.global1.data[14] > 4)
			{
				this.text_fake = "Из-за вашей чрезмерно радикальной и поспешной политики";
			}
			else
			{
				this.text_fake = "Из-за вашей неуверенной и неустойчивой политики";
			}
			if (this.global1.data[5] < 400)
			{
				this.text_fake += " и широких социальных проблем";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(7);
				}
			}
			this.text_fake = string.Concat(new string[]
			{
				this.text_fake,
				" народ, потерявший терпение, начал организацию массовых стачек и митингов, которые продолжались несколько недель и превратились в целые палаточные городки. За это время партаппарат стал сомневаться в своем лидере и отдельные его представители тайно организовали заговор, вследствие чего ",
				this.global1.politics_name[this.global1.data[11]],
				" был смещен, а затем и другие его приближенные деятели. Но митинги не прекращались и под их давлением и давлением молодых кадров в отставку ушли и умеренные представители. Следствием этого стало масштабное обновление руководящих рядов ",
				this.global1.party_name[0],
				" и окончательная либерализация режима. Лидирующая партия была переименована, а на бывших руководителей открыли уголовное дело."
			});
			if (this.global1.allcountries[19].Help)
			{
				this.text_fake += "|Однако, высшие чины партаппарата сумели вовремя сбежать из страны по налаженным каналам и получить политическое убежище в Индии.";
				if (this.global1.allcountries[19].Gosstroy <= 1)
				{
					this.text_fake = this.text_fake + " И, несмотря на международное давление, благодарное нам за поддержку правительство ИНК никого не выдало, поселив 'беженцев' в казённых помещениях, где, впоследствии, " + this.global1.politics_name[this.global1.data[11]] + " написал мемуары и автобиографию, в которых объявил себя последним и упущенным шансом своей страны на спасение.";
				}
				else
				{
					this.text_fake += " Впрочем, под международным давлением, новое индийское правительство вынуждено было начать процесс экстрадиции прибывших партаппаратчиков, следствием чего вы все укрылись в аргентинском посольстве и по тайным каналам были вывезены в разные страны Латинской Америки, сменив паспортные данные. ";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|",
					this.global1.politics_name[this.global1.data[11]],
					", при попытке бегства, был схвачен и изолирован в одиночной камере. Остальные были посажены в тюрьму на разные сроки, но к ",
					this.global1.data[21] + 5,
					" году получили амнистию по состоянию здоровья."
				});
			}
			if (this.global1.data[0] == 1)
			{
				if (this.global1.data[16] <= 12)
				{
					this.text_fake += "|СЕПГ была преобразована в Партию Демократического Социализма, вступив в коалицию с оппозицией, а на выборах победил единый правоцентристский альянс, принявший решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, вследствие этого было нарушено централизованное единое управление экономикой бывшей ГДР, после чего большая часть предприятий были признаны убыточными и закрыты, поэтому центральному правительству ФРГ пришлось вводить специальный налог для перенаправления финансов в развитие территорий бывшей ГДР.";
				}
				else
				{
					this.text_fake += "|СЕПГ была преобразована в Партию Демократического Социализма, вступив в коалицию с оппозицией, а на выборах победил единый правоцентристский альянс, принявший решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, однако ранее проведенные реформы восточногерманского правительства позволили более легко пережить интеграцию в рыночную экономику Западной Германии.";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|На первых, по словам западных журналистов, самых свободных выборах победила правоцентристская коалиция, вследствие чего к ",
					this.global1.data[21] + 8,
					" году страна стала постоянным членом НАТО."
				});
			}
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 1)
		{
			this.Name.text = "СВЕРЖЕНИЕ РЕВОЛЮЦИЕЙ";
			this.text_fake = "Из-за вашей неуверенной и неустойчивой политики, народ, потерявший надежду в режиме НДПА, начал переходить на сторону оппозиции, в армии стали нередки случае дезертирства, и последние военные поражения ДРА стали последней каплей в чаше терпения народа, и в колыбели Апрельской революции – Кабуле разразились массовые протесты, которые скоротечно перетекли в мятеж. Попытки разогнать демонстрацию не увенчались успехом, и мятежники ворвались в правительственные учреждения, начав самосуд против управленцев и партийных работников. В итоге, в Кабуле разразилась анархия, на фоне которой террористы смогли успешно начать наступление и взять столицу, провозгласив Афганистан исламской республикой.";
		}
		else if (this.global1.data[46] == 2)
		{
			this.Name.text = "НАРОДНЫЕ ВОЛНЕНИЯ";
			this.text_fake = "Из-за вашей неуверенной и неустойчивой политики, народ, потерявший надежду в режиме НДПА, начал переходить на сторону оппозиции, в армии стали нередки случае дезертирства, и последние военные поражения ДРА стали последней каплей в чаше терпения народа, и в колыбели Апрельской революции – Кабуле разразились протесты против действующего правительства. Недовольный вашей слабостью и бездействием генералитет попытался организовать военный переворот, чтобы установить в столице порядок, однако армия отказалась стрелять в горожан и перешла на их сторону. В итоге, в Кабуле разразилась анархия, на фоне которой террористы смогли успешно начать наступление и взять столицу, провозгласив Афганистан исламской республикой.";
		}
		else if (this.global1.data[46] == 3 && this.global1.data[0] != 12)
		{
			bool flag2 = false;
			this.Name.text = "ПАРТИЙНЫЙ ПЕРЕВОРОТ";
			this.text_fake = "Ваши политические шаги стали всё больше и больше злить партаппарат и их терпению пришёл конец. Некоторые высокопоставленные деятели " + this.global1.party_name[0] + " вступили в сговор, в который был вовлечен даже ";
			int num7 = UnityEngine.Random.Range(0, 3);
			if (num7 == 0)
			{
				this.text_fake += "Министр Внутренних Дел. ";
			}
			else if (num7 == 1)
			{
				this.text_fake += "Министр Обороны. ";
			}
			else if (num7 == 2)
			{
				this.text_fake += "Начальник спецслужб. ";
			}
			if (this.global1.data[0] == 1)
			{
				this.global1.data[10] += 250;
			}
			this.text_fake = this.text_fake + "На следующий день после организации заговора на собрании Политбюро группа заговорщиков выступила с резкими обвинениями в адрес " + this.global1.politics_name[this.global1.data[11]] + ", в ходе которых даже 2 секретарь принял решение не встревать в спор и, под молчанием других членов Политбюро, наш лидер ушел в отставку по состоянию здоровья.";
			if (this.global1.data[22] >= 700 && this.global1.data[31] >= 700 && (this.global1.data[14] > 2 || !this.global1.allcountries[10].Help) && this.global1.data[10] < 500)
			{
				this.text_fake = this.text_fake + "В ходе партийных перестановок к власти пришла коалиция сторонников суверенитета и ранее поднявших голову националистов, сформировав обновленное народное правительство: " + this.global1.party_name[0] + " была переименована в Партию Народного Возрождения, правительство подписало конкордат с церковью, а государство стало крупнейшим акционером на внутреннем рынке, что вкупе с открытием свободной торговли и легализацией всех родов предпринимательства привело к формированию государственного капитализма. Новое руководство стало вести страну в русле национального пути построения общества классовой солидарности.";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(9);
				}
				flag2 = true;
			}
			else if (this.global1.data[22] >= 500 && this.global1.data[31] >= 700 && this.global1.data[14] <= 2 && this.global1.allcountries[10].Help && this.global1.data[10] < 500)
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"В ходе партийных перестановок к власти пришла коалиция сторонников социализма с опорой на внутренние силы, сформировав национально-народное правительство. ",
					this.global1.party_name[0],
					" осудило ревизионизм других левых партий, приняв обновленную программу: «мировоззрение, в центре которого — человек, и революционные идеи, нацеленные на осуществление самостоятельности народных масс». ",
					this.global1.allcountries[this.global1.data[0]].name,
					" стала закрытой страной с жестокой авторитарной властью и милитаристическим централизованным управлением, к ",
					this.global1.data[21] + 21,
					" году объявив о создании собственного ядерного оружия, впрочем, несмотря на массовые санкции, страна продолжает существовать..."
				});
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(8);
				}
				flag2 = true;
			}
			else if (this.global1.data[22] >= 500 && this.global1.data[31] >= 700 && this.global1.data[10] >= 800)
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"В ходе партийных перестановок к власти пришла коалиция сторонников суверенитета, социализма с опорой на внутренние силы и ранее поднявших голову националистов, что привело к нешуточной истерии на Западе. В конечном итоге общественное мнение было выражено американской стороной на заседании Совбеза ООН, в ходе которого единогласно было принято решение о вводе бесполётной зоны, признании переворота нелегитимным, утверждении массовых санкций. Как следствие этого, профинансированная западными спецслужбами оппозиция начала вооруженное восстание в стране. К ней присоединились бомбардировщики и авиация НАТО. Правящий режим пал и страна вернулась на демократические позиции, к ",
					this.global1.data[21] + 8,
					" году выступив в НАТО."
				});
			}
			else
			{
				this.text_fake += "В ходе партийных перестановок к власти пришла коалиция сторонников реформ - демократических социалистов, демократических коммунистов и левых социал-демократов, начав полный вывод государственного контроля над армией и другими учреждениями, существенно урезав права спецслужб и проведя либерализацию режима.";
			}
			if (this.global1.allcountries[19].Help)
			{
				this.text_fake += "|Однако, высшие чины партаппарата сумели вовремя сбежать из страны по налаженным каналам и получить политическое убежище в Индии.";
				if (this.global1.allcountries[19].Gosstroy <= 1)
				{
					this.text_fake = this.text_fake + " И, несмотря на международное давление, благодарное нам за поддержку правительство ИНК никого не выдало, поселив 'беженцев' в казённых помещениях, где, впоследствии, " + this.global1.politics_name[this.global1.data[11]] + " написал мемуары и автобиографию, в которых объявил себя последним и упущенным шансом своей страны на спасение.";
				}
				else
				{
					this.text_fake += " Впрочем, под международным давлением, новое индийское правительство вынуждено было начать процесс экстрадиции прибывших партаппаратчиков, следствием чего вы все укрылись в аргентинском посольстве и по тайным каналам были вывезены в разные страны Латинской Америки, сменив паспортные данные. ";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|",
					this.global1.politics_name[this.global1.data[11]],
					", при попытке бегства, был схвачен и изолирован в одиночной камере. Остальные были посажены в тюрьму на разные сроки, но к ",
					this.global1.data[21] + 5,
					" году получили амнистию по состоянию здоровья."
				});
			}
			if (this.global1.data[0] == 1 && (this.global1.data[22] < 700 || this.global1.data[31] < 700))
			{
				if (this.global1.data[16] <= 12)
				{
					this.text_fake += "|СЕПГ была преобразована в Партию Демократического Социализма, вступив в коалицию с оппозицией, а на выборах победил единый правоцентристский альянс, принявший решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, вследствие этого было нарушено централизованное единое управление экономикой бывшей ГДР, после чего большая часть предприятий были признаны убыточными и закрыты, поэтому центральному правительству ФРГ пришлось вводить специальный налог для перенаправления финансов в развитие территорий бывшей ГДР.";
				}
				else
				{
					this.text_fake += "|СЕПГ была преобразована в Партию Демократического Социализма, вступив в коалицию с оппозицией, а на выборах победил единый правоцентристский альянс, принявший решение войти в состав ФРГ. Промышленность была приватизирована разными владельцами, однако ранее проведенные реформы восточногерманского правительства позволили более легко пережить интеграцию в рыночную экономику Западной Германии.";
				}
			}
			else if ((this.global1.data[22] < 700 || this.global1.data[31] < 700) && !flag2)
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"На первых выборах обновлённая Социалистическая Партия уверенно победила, заняв большую часть мест в парламенте, однако их торжество продлилось недолго: среди народа всплыл компромат на 1 секретаря обновлённой Партии, который упоминал, что лучше бы были бы введены советские танки, чем потакать правой оппозиции, вследствие чего по стране прошли новые массовые митинги и всё руководство Партии подало в отставку, а на перевыборах к власти пришла правоцентристская коалиция. К ",
					this.global1.data[21] + 8,
					" году страна стала постоянным членом НАТО."
				});
			}
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 3)
		{
			this.Name.text = "ПАРТИЙНЫЙ ПЕРЕВОРОТ";
			if (this.global1.data[11] == 2)
			{
				this.text_fake = "Необдуманная и непоследовательная политика Наджибуллы стала всё больше и больше злить парчамистов, которые решились вступить в заговор против президента, заручившись поддержкой СССР. На следующий день после организации заговора на собрании Политбюро группа заговорщиков выступила с резкими обвинениями в адрес Наджибуллы, и тот, под давлением партийцев был вынужден уйти в отставку по состоянию здоровья. Правительство следующего лидера страны, в попытках начать переговоры с оппозицией, всё больше и больше идя на уступки террористам, потерпело фиаско. В итоге, после распада СССР, правительство ДРА лишилось своей поддержки, и оппозиция без боя вошла в Кабул, установив в Афганистане исламскую республику.";
			}
			else if (this.global1.data[11] == 1)
			{
				this.text_fake = "Необдуманная и непоследовательная политика Таная стала всё больше и больше злить халькистов, которые решились вступить заговор против президента, заручившись поддержкой генералитета. На следующий день после организации заговора на собрании Политбюро группа заговорщиков выступила с резкими обвинениями в адрес Таная, и тот, под давлением партийцев был вынужден уйти в отставку по состоянию здоровья. Жёсткая политика следующего лидера и его множественные провальные наступления на террористов приведи к масштабному дезертирству из афганской армии и переходу на сторону оппозиции. В итоге, после распада СССР, правительство ДРА лишилось своей поддержки, и оппозиция без боя вошла в Кабул, установив в Афганистане исламскую республику.";
			}
			else if (this.global1.data[11] == 3)
			{
				this.text_fake = "Необдуманная и непоследовательная политика Дустума стала всё больше и больше злить представителей правительства, которые решились вступить заговор против президента, заручившись поддержкой генералитета. На следующий день после организации заговора на собрании правительства группа заговорщиков выступила с резкими обвинениями в адрес Дустума, и тот, под давлением партийцев был вынужден уйти в отставку по состоянию здоровья. Жёсткая политика следующего лидера и его множественные провальные наступления на террористов приведи к масштабному дезертирству из афганской армии и переходу на сторону оппозиции. В итоге, после распада СССР, правительство ДРА лишилось своей поддержки, и оппозиция без боя вошла в Кабул, установив в Афганистане исламскую республику.";
			}
			else if (this.global1.data[11] == 0)
			{
				this.text_fake = "Необдуманная и непоследовательная политика стала всё больше и больше злить представителей правительства, которые решились вступить заговор против президента, заручившись поддержкой генералитета. На следующий день после организации заговора на собрании правительства группа заговорщиков выступила с резкими обвинениями в адрес Президента, и тот, под давлением партийцев был вынужден уйти в отставку по состоянию здоровья. Жёсткая политика следующего лидера и его множественные провальные наступления на террористов приведи к масштабному дезертирству из афганской армии и переходу на сторону оппозиции. В итоге, после распада СССР, правительство ДРА лишилось своей поддержки, и оппозиция без боя вошла в Кабул, установив в Афганистане исламскую республику.";
			}
		}
		else if (this.global1.data[46] == 4 && this.global1.data[0] == 10)
		{
			if (this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(59);
			}
			this.Name.text = "Вашингтон - Москва - Пекин";
			this.text_fake = "Ваша недружелюбная и чрезмерно милитаристская внешняя политика стала злить близлежащие страны, которые опасались усиления военно-стратегической независимости КНДР. Вследствие этого, в июне 1992 года Вашингтон, Пекин и Москва выносят предложение в Совете Безопасности ООН о «Решении Корейского вопроса». Ведущие страны мира обвиняют Северную Корею в ведении активных разработок ядерного вооружения, жестокой и репрессивной внутренней политике, а также в многочисленных провокациях близ демилитаризованной зоны. В итоге большинство стран мира, за малым исключением, принимают резолюцию ООН, по которой воспрещается поддержание любых торгово-экономических связей с блокадой, а на высшее руководство КНДР накладываются санкции. Несмотря на это, Северу некоторое время удавалось сопротивляться политическому и экономическому давлению, однако, вскоре в страну был отправлен миротворческий контингент ООН для ликвидации «корейской угрозы». Силы ООН быстро занимают стратегические военные точки в стране и начинают наступление на Пхеньян. Несмотря, на обильную пропаганду в духе Корейской войны, сами корейцы с воодушевлением относятся к военнослужащим-миротворцам, именуя их «спасителями». В конце концов, руководство КНДР оказалось изолировано в Кымсусанском дворце. После его успешного штурма все они были переправлены на суд в Гаагу «за преступления против мира и человечности». Решением Совбеза ООН установилась временная бессрочная демилитаризованная зона в Северной Корее, а также утвердилась Переходная администрация во главе с сыном Ким Чен Ира Ким Чен Намом, который на деле является марионеткой ООН. После всего этого, между КНР и США были достигнуты соглашения, по которым Штаты обязуются не размещать войска на территории бывшей КНДР, а КНР, в свою очередь, клянётся не вмешиваться в дела Новой Кореи.";
		}
		else if (this.global1.data[46] == 4)
		{
			this.Name.text = "ВТОРЖЕНИЕ НАТО";
			if (this.global1.data[14] > 0 && this.global1.data[14] < 3)
			{
				this.text_fake = "Ваше авторитарное и жестокое правление, наряду с активным вмешательством в международные события, привели к нешуточной истерии на Западе.";
			}
			else if (this.global1.data[14] < 1)
			{
				this.text_fake = "Ваше жестокое и кровавое правление, наряду с активным вмешательством в международные события, привели к нешуточной истерии на Западе.";
			}
			else if (this.global1.data[14] > 3 && this.global1.data[22] >= 700 && this.global1.data[31] >= 700)
			{
				this.text_fake = "Ваше жестокое и националистическое правление, наряду с активным вмешательством в международные события, привели к нешуточной истерии на Западе.";
			}
			else
			{
				this.text_fake = "Ваше независимое и суверенное правление и ваши попытки активно вмешиваться в международные события в попытке стать новой ведущей силой в мире привели к широкому недовольству на Западе.";
			}
			this.text_fake += " Американцы созвали срочное заседание Совбеза ООН, где объявили об ущемлении нацменьшинств в нашей стране, активном производстве химического оружия, активной разработке ядерного оружия и существовании авторитарного мафиозного правления с массовыми репрессиями неугодных.";
			if (this.global1.data[14] < 3 || (this.global1.data[14] > 4 && this.global1.data[22] >= 700 && this.global1.data[31] >= 700))
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"На данном заседании единогласно было принято решение о вводе бесполётной зоны и утверждении массовых санкций. Как следствие этого, профинансированная западными спецслужбами оппозиция начала вооруженное восстание в стране. К ней присоединились бомбардировщики и авиация НАТО. Правящий режим пал и страна вернулась на демократические позиции, к ",
					this.global1.data[21] + 8,
					" году выступив в НАТО."
				});
			}
			else if (this.global1.data[14] < 4)
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"На данном заседании лишь члены НАТО поддержали американские инициативы, а Китай и Россия воздержались от голосования, вследствие чего было принято решение о вводе бесполётной зоны и утверждении массовых санкций. Как следствие этого, профинансированная западными спецслужбами оппозиция начала вооруженное восстание в стране. К ней присоединились бомбардировщики и авиация НАТО. Правящий режим пал и страна вернулась на демократические позиции, к ",
					this.global1.data[21] + 8,
					" году выступив в НАТО."
				});
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"На данном заседании Китай и Россия резко выступили против американской инициативы, ведь даже члены НАТО, кроме Великобритании, воздержались от голосования, вследствие чего не было принято совместного решения о вводе бесполётной зоны и утверждении массовых санкций. Однако, американцы, несмотря на решение ООН, объявили о вводе бесполетной зоны, всевозможных санкциях и блокаде, а затем профинансированная западными спецслужбами оппозиция начала вооруженное восстание в стране. К ней присоединились бомбардировщики, морпехи и авиация США. Правящий режим пал и страна вернулась на демократические позиции, к ",
					this.global1.data[21] + 8,
					" году выступив в НАТО."
				});
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(10);
				}
			}
			if (this.global1.allcountries[19].Help)
			{
				this.text_fake += "|Однако, высшие чины партаппарата сумели вовремя сбежать из страны по налаженным каналам и получить политическое убежище в Индии.";
				if (this.global1.allcountries[19].Gosstroy <= 1)
				{
					this.text_fake = this.text_fake + " И, несмотря на международное давление, благодарное нам за поддержку правительство ИНК никого не выдало, поселив 'беженцев' в казённых помещениях, где, впоследствии, " + this.global1.politics_name[this.global1.data[11]] + " написал мемуары и автобиографию, в которых объявил себя последним и упущенным шансом своей страны на спасение.";
				}
				else
				{
					this.text_fake += " Впрочем, под международным давлением, новое индийское правительство вынуждено было начать процесс экстрадиции прибывших партаппаратчиков, следствием чего вы все укрылись в аргентинском посольстве и по тайным каналам были вывезены в разные страны Латинской Америки, сменив паспортные данные. ";
				}
			}
			else
			{
				this.text_fake = string.Concat(new object[]
				{
					this.text_fake,
					"|",
					this.global1.politics_name[this.global1.data[11]],
					", при попытке бегства, был схвачен и изолирован в одиночной камере, а затем повешен народным трибуналом. Остальные были посажены в тюрьму на разные сроки, но к ",
					this.global1.data[21] + 5,
					" году получили амнистию по состоянию здоровья."
				});
			}
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 5)
		{
			this.Name.text = "ВТОРЖЕНИЕ СССР";
			if (this.global1.allcountries[7].Gosstroy == 0)
			{
				this.text_fake = "Ваше чересчур независимое и ревизионистское правление привело в ярость новых советских лидеров. А так как вы не смогли обеспечить ни должной поддержки народа, ни сильной укрепленной армии, ни внешней дипломатической защиты, то Советский Союз смог с радостью восстановить свой контроль над вашей территорией.|Вслед за этим СССР вернул контроль и над большей частью своей международной сферы. Под лидерством нового Президента СССР товарища Алкснис Советский Союз, руководимый смешанной экономикой, вновь стал мировой державой.";
			}
			else
			{
				this.text_fake = "Ваше чересчур независимое и ревизионистское правление привело в ярость новых советских лидеров. А так как вы не смогли обеспечить ни должной поддержки народа, ни сильной укрепленной армии, ни внешней дипломатической защиты, то Советский Союз смог с радостью восстановить свой контроль над вашей территорией.|Вслед за этим СССР вернул контроль и над большей частью своей международной сферы. Под лидерством нового Президента СССР товарища Пуго Советский Союз, руководимый смешанной экономикой, вновь стал мировой державой.|А через пару лет в совершенной секретности Горбачёв был отправлен на пенсию по состоянию здоровья и стал тихо жить под присмотром КГБ.";
			}
			this.text_fake = string.Concat(new string[]
			{
				this.text_fake,
				"|",
				this.global1.politics_name[this.global1.data[11]],
				" был исключен из правящей Партии с позором и отправлен в ссылку, а ",
				this.global1.party_name[0],
				" была переименована в Коммунистическую Партию."
			});
			if (this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(11);
			}
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 6 && this.global1.data[0] != 12)
		{
			this.Name.text = "ПОСЛЕДНИЕ ВЫБОРЫ";
			this.text_fake = "Вы проиграли на выборах. А проигравшие никому не нужны!";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 6)
		{
			this.Name.text = "ПОСЛЕДНИЕ ВЫБОРЫ";
			this.text_fake = "Несмотря на наши миротворческие цели, нам не удалось победить на первых свободных выборах, и в итоге, абсолютное большинство в парламенте заняли исламские фундаменталисты, которые после сформирования правительства отменили все декреты НДПА, предварительно запретив её и начав аресты её лидеров. В итоге, из-за реакционной политики нового руководства, в традиционно просоциалистических регионах начинаются волнения, скоротечно переходящие в погромы и кровопролитные восстания. Похоже, что новой гражданской войны не избежать.";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 7)
		{
			this.Name.text = "ЗАКАТ ХОДЖАИЗМА";
			this.text_fake = "Албания преображается в теократию. Недовольных этими переменами не очень много, но права женщин уже сокращаются, паранджа стала обязательной к ношению, началось внедрение законов Шариата, а имамы получают все больше власти. Неджимие Ходжа, первый и единственный правитель-женщина, стала не более чем марионеткой духовенства по собственному желанию. ";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 8)
		{
			this.Name.text = "ЗАКАТ СОЛНЦА ЧУЧХЕ";
			this.text_fake = "Из-за чрезмерной милитаризации и агрессивной внешней политики Северной Кореи, Соединенные штаты, при поддержке своих союзников, смогли протолкнуть в Совет безопасности ООН резолюцию о необходимости военного вмешательства в КНДР, чтобы пресечь враждебную политику севера и не допустить масштабного конфликта с Югом. И даже наш бывший союзник Китай не заступился за нас, нанеся нам очередной подлый удар в спину. После вторжения империалистов в КНДР и первых крупномасштабных поражений северокорейской армии, генералитет отказывается от применения ядерного оружие, и сговорившись с Соединёнными штатами, производит мятеж против лидера страны О Джин У, а затем выдаёт его военному контингенту ООН. Над генералиссимусом КНДР фактически разворачивается «новый Нюрнбергский процесс», в результате которого он, и несколько его подельников, был приговорены к смертной казни. После сокрушительного поражения КНДР начался процесс интеграции севера в Республику Корею, и теперь, после стольких жертв и потерь, корейский народ един и ему придётся пережить ещё очень много трудностей.";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 9)
		{
			this.Name.text = "ТРЕТЬЯ КОРЕЙСКАЯ ВОЙНА";
			this.text_fake = string.Concat(new string[]
			{
				"В начале декабря 1991 в Северной Корее началась полная милитаризация. В полном секрете от внешнего мира и общественности к 38-й параллели перевозились дивизии и вооружение Корейской Народной Армии. 31 декабря,  в канун нового 1992 года, лидер КНДР ",
				this.global1.politics_name[this.global1.data[11]],
				" заявил, что «американская марионетка Южная Корея совершила ракетный удар по позициям Северной Кореи, тем самым нарушив демилитаризованную зону между двумя странами» . После этого, северокорейские войска под прикрытием артиллерии, атаковали позиции Южной Кореи, вскоре к ним присоединились и имеющиеся в резерве танковые дивизии. Эффект неожиданности и молниеносный блицкриг смог обеспечить КНДР успешное наступление в первые дни новой Корейской войны. Северокорейская пропаганда за это время уже начала во всю агитировать «За войну до победного конца» и «Освобождение Родины от колониального рабства США». Руководитель КНДР  ",
				this.global1.politics_name[this.global1.data[11]],
				" был приравнен к рангу великих корейские военачальников, встав в один ряд с Ли Сунсином и Чоном Бон Су. Тем не менее, корейское наступление быстро захлебнулось, а мобилизованные силы военной базы США в Корее с новой силой начали операцию по освобождению Юга. Возвеличенная официальной пропагандой «победоносная рабочая армия Кореи» развалилась под ударами американцев и не удержала фронт, после чего началось паническое бегство, война быстро перешла на территорию Севера. Вопреки ожиданиям руководства, КНР никак не заступилась за Север, и, вследствие этого, высшее командование ослушалось приказа действующего президента о нанесении ядерного удара по Южной Корее, приняв решение выдать Америке президента КНДР, в обмен на сохранение собственных шкур. Через несколько Пхеньян, практически без сопротивления, пал. Корея стала единой, а в Гааге собирается новый трибунал для вынесения приговора лидерам КНДР."
			});
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
			if (this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(59);
			}
		}
		else if (this.global1.data[46] == 10)
		{
			if (this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(64);
			}
			this.Name.text = "Исламское Государство\nАфганистан";
			this.text_fake = "|||После вывода советских войск положение Афганистана начало стремительно ухудшаться - непоследовательная политика НДПА вместе с разногласиями в ней и в армейском руководстве привели к тому, что народ стал отворачиваться от Афганского правительства, а армия с трудом сдерживала натиск террористов. Оказавшись в международной изоляции, Афганистан не мог получить поддержку извне, а Пакистан продолжал безнаказанно отправлять всё новые отряды исламистов. террористам удалось взять Кабул, провозгласив Афганистан исламским государством. Все завоевания советской власти в социальных, экономических и правовых областях оказались уничтожены. А через 4 года и сам " + this.global1.politics_name[this.global1.data[11]] + " был зверски убит без суда и следствия.";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 11)
		{
			if (this.global1.iron_and_blood)
			{
				this.achieves.GetComponent<achievements>().Set(64);
			}
			this.Name.text = "Исламское Государство\nАфганистан";
			this.text_fake = "|||После вывода советских войск положение Афганистана начало стремительно ухудшаться - непоследовательная политика НДПА вместе с разногласиями в ней и в армейском руководстве привели к тому, что народ стал отворачиваться от Афганского правительства, а армия с трудом сдерживала натиск моджахедов. Оказавшись в международной изоляции, Афганистан не мог получить поддержку извне, а Пакистан продолжал безнаказанно отправлять всё новые отряды исламистов. Моджахедам удалось взять Кабул, провозгласив Афганистан исламским государством. Все завоевания советской власти в социальных, экономических и правовых областях оказались уничтожены. А через 4 года и сам " + this.global1.politics_name[this.global1.data[11]] + " был зверски убит без суда и следствия.";
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 12)
		{
			this.Name.text = "Венгерская Румыния";
			this.text_fake = this.dlce1.credits_text[29];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 23)
		{
			this.Name.text = this.dlce1.credits_text[240];
			this.text_fake = this.dlce1.credits_text[202];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] >= 13 && this.global1.data[46] <= 22)
		{
			this.Name.text = this.dlce1.credits_text[51 + this.global1.data[46] - 13];
			this.text_fake = this.dlce1.credits_text[61 + this.global1.data[46] - 13];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == -1)
		{
			this.Name.text = this.dlce1.credits_text[114];
			this.text_fake = this.dlce1.credits_text[112];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == -2)
		{
			this.Name.text = this.dlce1.credits_text[115];
			this.text_fake = this.dlce1.credits_text[113];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
			GameObject.Find("Back").GetComponent<SpriteRenderer>().sprite = this.winfon;
			GameObject.Find("plane").GetComponent<SpriteRenderer>().sprite = this.winplan;
		}
		else if (this.global1.data[46] == -10)
		{
			this.Name.text = this.dlce1.credits_text[228];
			this.text_fake = this.dlce1.credits_text[237];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] <= -3 && this.global1.data[46] >= -6)
		{
			this.Name.text = this.dlce1.credits_text[119 - this.global1.data[46] - 3];
			this.text_fake = this.dlce1.credits_text[123 - this.global1.data[46] - 3];
			UnityEngine.Object.Destroy(this.button_l);
			UnityEngine.Object.Destroy(this.button_r);
		}
		else if (this.global1.data[46] == 0)
		{
			if (this.global1.data[128] == 2)
			{
				this.yug1.gameState.yugregions[1].owner = 1;
			}
			if (this.global1.data[136] == 1 && this.global1.data[137] == 1)
			{
				this.yug1.gameState.yugregions[3].owner = 3;
			}
			this.ThisEndingWindow(null, 0);
		}
		this.text.text = this.Text(this.text_fake, 72);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00047D84 File Offset: 0x00045F84
	public void ChangeOkno()
	{
		if (this.global1.data[46] == 0)
		{
			int num = 0;
			List<int> list = new List<int>();
			for (int i = 1; i < 7; i++)
			{
				if (this.global1.allcountries[i].paths > 1)
				{
					num++;
					list.Add(i);
				}
			}
			if ((this.this_okno > 12 + num && this.global1.data[21] <= 1991) || (this.this_okno > 12 + num && this.global1.data[19] <= 1 && this.global1.data[20] <= 1 && this.global1.data[21] >= 1991) || (this.this_okno > 13 + num && this.global1.data[21] >= 1992))
			{
				this.this_okno = 0;
				this.this_vrem = 0;
			}
			else if ((this.this_okno < 0 && this.global1.data[21] <= 1991) || (this.this_okno < 0 && this.global1.data[19] <= 1 && this.global1.data[20] <= 1 && this.global1.data[21] >= 1991))
			{
				this.this_okno = 12 + num;
				if (num == 0)
				{
					this.this_okno = 12;
				}
			}
			else if (this.this_okno < 0 && ((this.global1.data[19] > 1 && this.global1.data[20] > 1 && this.global1.data[21] >= 1992) || this.global1.data[21] >= 1993))
			{
				this.this_okno = 13 + num;
				if (num == 0)
				{
					this.this_okno = 13;
				}
			}
			this.ThisEndingWindow(list, num);
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00047F58 File Offset: 0x00046158
	private void YugoAchievement()
	{
		if (this.global1.iron_and_blood)
		{
			if ((((this.global1.data[118] == 1 && this.global1.data[0] == 51) || this.global1.data[0] != 51) && (this.global1.allcountries[51].Gosstroy == 0 || this.global1.allcountries[15].Gosstroy == 0)) || (this.global1.data[136] == 1 && this.global1.data[0] == 50 && (this.global1.allcountries[50].Gosstroy == 0 || this.global1.allcountries[15].Gosstroy == 0)) || (this.global1.data[148] == 1 && this.global1.data[0] == 49 && (this.global1.allcountries[49].Gosstroy == 0 || this.global1.allcountries[15].Gosstroy == 0)))
			{
				this.achieves.GetComponent<achievements>().Set(114);
			}
			if (this.global1.data[46] == 22)
			{
				this.achieves.GetComponent<achievements>().Set(115);
			}
			if (this.yug1.gameState.modifies[10] == 1 && this.yug1.gameState.modifies[9] == 1)
			{
				this.achieves.GetComponent<achievements>().Set(116);
			}
			if (((this.global1.data[118] == 0 && this.global1.data[0] == 51 && (this.global1.allcountries[51].Gosstroy == 2 || this.global1.allcountries[15].Gosstroy == 2)) || (this.global1.data[136] == 0 && this.global1.data[0] == 50 && (this.global1.allcountries[50].Gosstroy == 2 || this.global1.allcountries[15].Gosstroy == 2)) || (this.global1.data[148] != 1 && this.global1.data[0] == 49 && (this.global1.allcountries[49].Gosstroy == 2 || this.global1.allcountries[15].Gosstroy == 2))) && this.global1.allcountries[20].Gosstroy == 2 && this.global1.allcountries[4].Gosstroy == 2 && this.global1.allcountries[6].Gosstroy == 2 && this.global1.allcountries[5].Gosstroy == 2 && this.global1.allcountries[45].Gosstroy == 2 && this.global1.allcountries[20].Gosstroy == 2 && this.global1.allcountries[54].Gosstroy == 2 && ((this.global1.data[0] == 49 && this.global1.allcountries[49].Vyshi) || (this.global1.data[0] == 50 && this.global1.allcountries[50].Vyshi) || (this.global1.data[0] == 51 && this.global1.allcountries[51].Vyshi)))
			{
				this.achieves.GetComponent<achievements>().Set(119);
			}
			if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] <= 300)
			{
				this.achieves.GetComponent<achievements>().Set(111);
			}
			else if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] >= 301)
			{
				this.achieves.GetComponent<achievements>().Set(112);
			}
			if (!this.yug1.gameState.battle_royal && this.global1.data[0] == 49 && this.yug1.gameState.yugregions[0].owner == 8 && this.yug1.gameState.yugregions[1].owner == 8 && this.yug1.gameState.yugregions[2].owner == 8 && this.yug1.gameState.yugregions[3].owner == 8 && this.yug1.gameState.yugregions[4].owner == 8 && this.yug1.gameState.yugregions[5].owner == 8 && this.yug1.gameState.yugregions[6].owner == 8 && this.yug1.gameState.yugregions[7].owner == 8 && this.yug1.gameState.yugregions[8].owner == 8 && this.yug1.gameState.yugregions[9].owner == 8 && this.yug1.gameState.yugregions[10].owner == 8 && this.yug1.gameState.yugregions[11].owner == 8 && this.global1.data[162] != 3)
			{
				this.achieves.GetComponent<achievements>().Set(120);
			}
			if (this.yug1.gameState.yugregions[10].owner != 10 && this.yug1.gameState.yugcountries[10].is_exist && (this.global1.eventVariantChosen[335] == 3 || this.global1.eventVariantChosen[399] == 0 || this.yug1.gameState.yugcountries[10].is_independent))
			{
				this.achieves.GetComponent<achievements>().Set(121);
			}
			if (this.global1.data[112] == 10)
			{
				this.achieves.GetComponent<achievements>().Set(122);
			}
			if (this.global1.data[177] == 3)
			{
				this.achieves.GetComponent<achievements>().Set(123);
			}
			if (this.global1.data[155] == 3)
			{
				if (this.global1.data[118] == 1 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && this.global1.data[130] == 3 && this.global1.data[148] == 1 && this.global1.data[150] == 1 && this.global1.data[156] == 4 && this.global1.data[157] == 2 && (this.global1.data[176] == 2 || this.global1.data[176] == 7 || this.global1.data[176] == 8))
				{
					this.achieves.GetComponent<achievements>().Set(124);
				}
			}
			else if (this.global1.data[118] == 1 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && this.global1.data[130] == 3 && this.global1.data[148] == 1 && this.global1.data[150] == 1 && this.global1.data[156] == 4 && this.global1.data[157] == 2)
			{
				this.achieves.GetComponent<achievements>().Set(124);
			}
			if (this.global1.event_done[395])
			{
				this.achieves.GetComponent<achievements>().Set(125);
			}
			if (this.global1.data[168] == 2)
			{
				this.achieves.GetComponent<achievements>().Set(126);
			}
			if (this.global1.data[46] == 21)
			{
				this.achieves.GetComponent<achievements>().Set(127);
			}
			if (this.global1.data[176] == 9 && this.global1.data[148] == 2 && this.yug1.gameState.yugregions[10].owner == 10)
			{
				this.achieves.GetComponent<achievements>().Set(130);
			}
			bool flag = true;
			for (int i = 0; i < this.global1.regions.Length; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					if (this.global1.regions[i].buildings[j].type >= 25 && this.global1.regions[i].buildings[j].type <= 36 && this.global1.regions[i].buildings[j].is_builded)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				this.achieves.GetComponent<achievements>().Set(118);
			}
			flag = true;
			for (int k = 0; k < this.yug1.gameState.yugregions.Length; k++)
			{
				if (this.yug1.gameState.yugregions[k].owner == this.yug1.gameState.player && k != 8)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				this.achieves.GetComponent<achievements>().Set(128);
			}
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00048A08 File Offset: 0x00046C08
	private void YugoEndings()
	{
		if (!this.yug1.gameState.battle_royal)
		{
			this.YugoAchievement();
			int num = 0;
			foreach (YugoRegion yugoRegion in this.yug1.gameState.yugregions)
			{
				if (yugoRegion.owner == this.yug1.gameState.player || this.yug1.gameState.yugcountries[yugoRegion.owner].is_ally || this.yug1.gameState.yugcountries[yugoRegion.owner].peace_with[this.yug1.gameState.player])
				{
					num++;
				}
			}
			bool flag = false;
			if (this.global1.data[114] == 100 && this.global1.data[162] == 3 && this.global1.data[131] != 1)
			{
				if (num >= this.yug1.gameState.yugregions.Length - 1)
				{
					if (this.global1.data[0] == 49)
					{
						if (this.global1.data[14] == 1 || this.global1.data[14] == 2 || this.global1.data[16] <= 11)
						{
							this.Name.text = this.dlce1.credits_text[133];
							this.text_fake = this.dlce1.credits_text[134];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(89);
							}
						}
						else
						{
							this.Name.text = this.dlce1.credits_text[127];
							this.text_fake = this.dlce1.credits_text[130];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(86);
							}
						}
					}
					else if (this.global1.data[0] == 50)
					{
						if (this.global1.data[14] == 1 || this.global1.data[14] == 2 || this.global1.data[16] <= 11)
						{
							this.Name.text = this.dlce1.credits_text[133];
							this.text_fake = this.dlce1.credits_text[134];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(89);
							}
						}
						else
						{
							this.Name.text = this.dlce1.credits_text[129];
							this.text_fake = this.dlce1.credits_text[132];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(88);
							}
						}
					}
					else if (this.global1.data[14] == 1 || this.global1.data[14] == 2 || this.global1.data[16] <= 11)
					{
						this.Name.text = this.dlce1.credits_text[133];
						this.text_fake = this.dlce1.credits_text[134];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(89);
						}
					}
					else
					{
						this.Name.text = this.dlce1.credits_text[128];
						this.text_fake = this.dlce1.credits_text[131];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(87);
						}
					}
					if (this.this_okno == 2)
					{
						this.this_okno = 0;
						this.this_vrem = 0;
						return;
					}
					if (this.this_okno == 0)
					{
						this.this_okno = 2;
						this.this_vrem = 9;
						return;
					}
				}
				else
				{
					this.Name.text = this.dlce1.credits_text[135];
					if (this.global1.data[0] == 49)
					{
						this.text_fake = this.dlce1.credits_text[136];
					}
					else if (this.global1.data[0] == 50)
					{
						this.text_fake = this.dlce1.credits_text[138];
					}
					else
					{
						this.text_fake = this.dlce1.credits_text[137];
					}
					if (this.this_okno == 2)
					{
						this.this_okno = 0;
						this.this_vrem = 0;
						return;
					}
					if (this.this_okno == 0)
					{
						this.this_okno = 2;
						this.this_vrem = 9;
						return;
					}
				}
			}
			else
			{
				this.Name.text = this.dlce1.credits_text[71 + this.this_vrem];
				if (this.global1.iron_and_blood)
				{
					if (this.global1.data[138] == 0 && this.global1.data[136] == 0 && this.global1.data[118] == 0 && this.global1.data[117] == 0 && this.global1.data[157] == 0 && this.global1.data[148] == 0)
					{
						this.achieves.GetComponent<achievements>().Set(100);
					}
					if (this.yug1.gameState.modifies[2] > 0)
					{
						this.achieves.GetComponent<achievements>().Set(103);
					}
					if (this.global1.data[160] == 1 && this.global1.data[15] == 7 && this.global1.data[16] == 12 && this.global1.data[17] == 16 && this.global1.data[18] == 21)
					{
						this.achieves.GetComponent<achievements>().Set(104);
					}
				}
				if (this.this_vrem == 0)
				{
					if (this.global1.data[157] == 1 && this.global1.data[121] == 0 && this.global1.data[164] == 8)
					{
						this.text_fake = this.dlce1.credits_text[189];
						return;
					}
					if (this.global1.data[170] == 1)
					{
						this.text_fake = this.dlce1.credits_text[205];
						return;
					}
					if (this.global1.data[157] == 1 && this.global1.data[121] == 0)
					{
						this.text_fake = this.dlce1.credits_text[190];
						return;
					}
					if (this.yug1.gameState.yugregions[0].owner == this.yug1.gameState.player)
					{
						this.text_fake = this.dlce1.credits_text[146];
						return;
					}
					this.text_fake = this.dlce1.credits_text[79 + this.global1.data[157]];
					return;
				}
				else if (this.this_vrem == 1)
				{
					if (((!this.yug1.gameState.yugcountries[1].is_independent && !this.yug1.gameState.yugcountries[1].is_exist) || this.yug1.gameState.yugregions[1].owner == this.yug1.gameState.player) && this.yug1.gameState.player != 1)
					{
						this.text_fake = this.dlce1.credits_text[147];
						return;
					}
					if (this.global1.data[169] == 1)
					{
						this.text_fake = this.dlce1.credits_text[206];
						return;
					}
					if (!this.yug1.gameState.yugcountries[1].is_independent && this.global1.data[118] == 1 && this.global1.data[116] == 1)
					{
						this.text_fake = this.dlce1.credits_text[201];
						return;
					}
					if (this.global1.data[3] + this.global1.data[9] < 550 && this.global1.data[166] == 3)
					{
						this.text_fake = this.dlce1.credits_text[176];
						return;
					}
					if (this.yug1.gameState.modifies[2] == 3 && this.yug1.gameState.modifies[4] == 1)
					{
						this.text_fake = this.dlce1.credits_text[170];
						return;
					}
					if (this.yug1.gameState.modifies[2] == 3 && this.yug1.gameState.modifies[4] == 0 && this.yug1.gameState.modifies[5] == 0)
					{
						this.text_fake = this.dlce1.credits_text[171];
						return;
					}
					if (this.yug1.gameState.modifies[2] == 3 && this.global1.data[166] == 1)
					{
						this.text_fake = this.dlce1.credits_text[172];
						return;
					}
					if (this.global1.data[166] == 2)
					{
						this.text_fake = this.dlce1.credits_text[173];
						return;
					}
					if (this.yug1.gameState.modifies[16] == 1)
					{
						this.text_fake = this.dlce1.credits_text[174];
						return;
					}
					this.text_fake = this.dlce1.credits_text[82 + this.global1.data[128]];
					if (this.yug1.gameState.yugcountries[2].is_exist)
					{
						this.text_fake += this.dlce1.credits_text[85];
						return;
					}
				}
				else if (this.this_vrem == 2)
				{
					if (this.global1.data[136] == 1 && this.global1.data[137] == 0 && this.global1.data[115] >= 10 && !this.yug1.gameState.yugcountries[1].is_independent)
					{
						this.text_fake = this.dlce1.credits_text[188];
						return;
					}
					if (this.global1.data[172] == 1)
					{
						this.text_fake = this.dlce1.credits_text[207];
						return;
					}
					if (this.yug1.gameState.yugregions[3].owner == this.yug1.gameState.player && this.yug1.gameState.player != 3)
					{
						this.text_fake = this.dlce1.credits_text[151];
						return;
					}
					this.text_fake = this.dlce1.credits_text[86 + this.global1.data[158]];
					if (this.yug1.gameState.yugcountries[4].is_exist)
					{
						this.text_fake += this.dlce1.credits_text[89];
					}
					if (this.yug1.gameState.yugcountries[5].is_exist)
					{
						this.text_fake += this.dlce1.credits_text[90];
					}
					if (this.global1.data[46] == 23)
					{
						this.text_fake += this.dlce1.credits_text[202];
						return;
					}
				}
				else if (this.this_vrem == 3)
				{
					if (this.yug1.gameState.yugregions[8].owner == this.yug1.gameState.player && this.yug1.gameState.player != 8)
					{
						this.global1.data[148] = 0;
					}
					if (this.global1.data[179] == 0 && (this.global1.data[154] == 3 || this.global1.data[154] == 2) && this.global1.data[148] == 2)
					{
						this.text_fake = this.dlce1.credits_text[203];
						return;
					}
					if (this.global1.data[171] == 1)
					{
						this.text_fake = this.dlce1.credits_text[208];
						return;
					}
					if (this.global1.data[179] >= 1 && (this.global1.data[154] == 3 || this.global1.data[154] == 2) && this.global1.data[148] == 2)
					{
						this.text_fake = this.dlce1.credits_text[204];
						return;
					}
					this.text_fake = this.dlce1.credits_text[92 + this.global1.data[148]];
					return;
				}
				else if (this.this_vrem == 4)
				{
					if (this.yug1.gameState.yugregions[7].owner == this.yug1.gameState.player)
					{
						this.global1.data[156] = 0;
					}
					if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] >= 300)
					{
						this.text_fake = this.dlce1.credits_text[239];
						if (this.global1.data[112] == 6)
						{
							this.achieves.GetComponent<achievements>().Set(113);
							return;
						}
					}
					else if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] <= 300)
					{
						this.text_fake = this.dlce1.credits_text[238];
						if (this.global1.data[112] == 6)
						{
							this.achieves.GetComponent<achievements>().Set(112);
							return;
						}
					}
					else
					{
						if (this.global1.data[156] == 3)
						{
							this.text_fake = this.dlce1.credits_text[181];
							return;
						}
						if (this.global1.data[156] == 4)
						{
							this.text_fake = this.dlce1.credits_text[242];
							return;
						}
						this.text_fake = this.dlce1.credits_text[96 + this.global1.data[156]];
						return;
					}
				}
				else if (this.this_vrem == 5)
				{
					if (this.yug1.gameState.yugregions[11].owner == this.yug1.gameState.player)
					{
						this.text_fake = this.dlce1.credits_text[148];
						return;
					}
					if (((this.yug1.gameState.yugcountries[11].is_independent && this.yug1.gameState.yugcountries[11].is_exist) || !this.yug1.gameState.yugcountries[11].peace_with[this.yug1.gameState.player]) && (this.global1.event_done[361] || (this.global1.event_done[313] && this.global1.allcountries[6].Gosstroy == 9)))
					{
						this.text_fake = this.dlce1.credits_text[150];
						return;
					}
					if (this.global1.data[130] == 4)
					{
						this.text_fake = this.dlce1.credits_text[192];
						return;
					}
					if (this.global1.data[130] == 5)
					{
						this.text_fake = this.dlce1.credits_text[193];
						return;
					}
					if (this.global1.data[130] == 6 && this.yug1.gameState.modifies[5] == 1)
					{
						this.text_fake = this.dlce1.credits_text[194];
						return;
					}
					if (this.global1.data[130] == 6 && this.yug1.gameState.modifies[5] == 0)
					{
						this.text_fake = this.dlce1.credits_text[195];
						return;
					}
					if (this.global1.event_done[361])
					{
						this.text_fake = this.dlce1.credits_text[149];
						return;
					}
					if (this.yug1.gameState.yugcountries[11].is_independent)
					{
						this.text_fake = this.dlce1.credits_text[101];
						return;
					}
					this.text_fake = this.dlce1.credits_text[99];
					return;
				}
				else if (this.this_vrem == 6)
				{
					if (this.global1.iron_and_blood && this.global1.data[146] == 1 && this.yug1.gameState.modifies[4] != 1 && this.yug1.gameState.modifies[5] != 1)
					{
						this.achieves.GetComponent<achievements>().Set(90);
					}
					if (this.global1.data[168] == 2 && this.global1.data[115] >= 12)
					{
						this.text_fake = this.dlce1.credits_text[196];
						return;
					}
					if (this.global1.data[168] == 2 && this.global1.data[115] < 12)
					{
						this.text_fake = this.dlce1.credits_text[197];
						return;
					}
					if (this.global1.data[118] == 1 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && this.global1.data[130] == 3 && this.global1.data[148] == 1 && this.global1.data[150] == 1 && this.global1.data[156] == 4 && this.global1.data[157] == 2)
					{
						this.text_fake = this.dlce1.credits_text[198];
						return;
					}
					if (this.global1.data[112] == 10)
					{
						this.text_fake = this.dlce1.credits_text[199];
						return;
					}
					if (this.global1.data[135] <= 4)
					{
						this.text_fake = this.dlce1.credits_text[106];
						return;
					}
					if (this.global1.data[155] == 3)
					{
						if (this.global1.data[128] == 1 && this.global1.data[157] == 1 && this.global1.data[158] == 1 && this.global1.data[156] == 3 && this.global1.data[148] == 1 && (this.global1.data[130] == 3 || this.global1.data[130] == 6) && (this.global1.allcountries[49].Vyshi || this.global1.allcountries[50].Vyshi || this.global1.allcountries[51].Vyshi) && (this.global1.data[176] == 3 || this.global1.data[176] == 5 || this.global1.data[176] == 9))
						{
							this.text_fake = this.dlce1.credits_text[182];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(111);
								return;
							}
						}
					}
					else if (this.global1.data[128] == 1 && this.global1.data[157] == 1 && this.global1.data[158] == 1 && this.global1.data[156] == 3 && this.global1.data[148] == 1 && (this.global1.data[130] == 3 || this.global1.data[130] == 6) && (this.global1.allcountries[49].Vyshi || this.global1.allcountries[50].Vyshi || this.global1.allcountries[51].Vyshi) && this.global1.data[155] != 3)
					{
						this.text_fake = this.dlce1.credits_text[182];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(111);
							return;
						}
					}
					else if (this.global1.data[131] == 1)
					{
						this.text_fake = this.dlce1.credits_text[105];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(93);
							return;
						}
					}
					else if (this.yug1.gameState.modifies[5] > 0)
					{
						this.text_fake = this.dlce1.credits_text[104];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(92);
							return;
						}
					}
					else if (this.yug1.gameState.modifies[4] > 0)
					{
						this.text_fake = this.dlce1.credits_text[103];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(91);
							return;
						}
					}
					else
					{
						if (this.global1.data[126] == 0 && this.global1.data[115] <= 4)
						{
							this.Name.text = this.dlce1.credits_text[119];
							this.text_fake = this.dlce1.credits_text[123];
							return;
						}
						if (this.global1.data[126] != 0)
						{
							this.text_fake = this.dlce1.credits_text[102];
							return;
						}
						if (this.global1.data[126] == 0 && this.global1.data[115] >= 16)
						{
							this.Name.text = this.dlce1.credits_text[121];
							this.text_fake = this.dlce1.credits_text[125];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(91);
								return;
							}
						}
						else
						{
							this.Name.text = this.dlce1.credits_text[120];
							this.text_fake = this.dlce1.credits_text[124];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(94);
								return;
							}
						}
					}
				}
				else if (this.this_vrem == 7)
				{
					if (this.global1.data[155] == 3)
					{
						if (this.global1.data[128] == 1 && this.global1.data[157] == 1 && this.global1.data[158] == 1 && this.global1.data[156] == 3 && this.global1.data[148] == 1 && (this.global1.data[130] == 3 || this.global1.data[130] == 6) && (this.global1.allcountries[49].Vyshi || this.global1.allcountries[50].Vyshi || this.global1.allcountries[51].Vyshi) && (this.global1.data[176] == 3 || this.global1.data[176] == 5 || this.global1.data[176] == 9))
						{
							this.text_fake = this.dlce1.credits_text[183];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(111);
							}
						}
					}
					else if (this.global1.data[128] == 1 && this.global1.data[157] == 1 && this.global1.data[158] == 1 && this.global1.data[156] == 3 && this.global1.data[148] == 1 && (this.global1.data[130] == 3 || this.global1.data[130] == 6) && (this.global1.allcountries[49].Vyshi || this.global1.allcountries[50].Vyshi || this.global1.allcountries[51].Vyshi) && this.global1.data[155] != 3)
					{
						this.text_fake = this.dlce1.credits_text[183];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(111);
						}
					}
					else if (this.global1.data[131] == 1)
					{
						if (this.global1.data[45] == 5)
						{
							this.text_fake = this.dlce1.credits_text[107];
						}
						else
						{
							this.text_fake = this.dlce1.credits_text[144];
						}
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(97);
						}
					}
					else if (this.global1.data[112] == 10)
					{
						this.text_fake = this.dlce1.credits_text[200];
					}
					else if (this.global1.data[112] == 11)
					{
						this.text_fake = this.dlce1.credits_text[245];
					}
					else if (this.global1.data[112] == 9)
					{
						this.text_fake = this.dlce1.credits_text[191];
					}
					else if (this.global1.data[112] == 3)
					{
						this.text_fake = this.dlce1.credits_text[108];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(95);
							if (this.global1.data[160] == -100 && this.yug1.gameState.modifies[5] > 0 && this.global1.data[16] <= 11 && (this.global1.data[14] == 1 || this.global1.data[14] == 2))
							{
								this.achieves.GetComponent<achievements>().Set(99);
							}
						}
					}
					else if (this.global1.data[112] == 4)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(96);
						}
						this.text_fake = this.dlce1.credits_text[109];
					}
					else if (this.global1.data[112] == 6)
					{
						if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] <= 300)
						{
							this.text_fake = this.dlce1.credits_text[184];
						}
						else if (this.yug1.gameState.yugcountries[7].is_independent && this.yug1.gameState.yugregions[7].owner == 7 && this.global1.data[9] >= 301)
						{
							this.text_fake = this.dlce1.credits_text[185];
						}
						else
						{
							this.text_fake = this.dlce1.credits_text[110];
						}
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(97);
						}
					}
					else if (this.global1.data[112] == 7)
					{
						this.text_fake = this.dlce1.credits_text[116];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(98);
						}
					}
					else if (this.global1.data[112] == 8)
					{
						this.text_fake = this.dlce1.credits_text[168];
					}
					else if (this.global1.data[112] == 5 && !flag && !this.yug1.gameState.yugcountries[1].is_independent && this.yug1.gameState.yugcountries[1].is_exist && this.yug1.gameState.yugregions[1].owner == 1)
					{
						this.text_fake = this.dlce1.credits_text[178];
					}
					else
					{
						this.text_fake = this.dlce1.credits_text[179];
					}
					if (this.global1.data[113] == 1)
					{
						this.text_fake += this.dlce1.credits_text[139];
						return;
					}
				}
				else if (this.this_vrem == 8)
				{
					this.Name.text = this.dlce1.credits_text[140];
					this.text_fake = this.dlce1.credits_text[142];
					if (this.global1.data[177] == 3)
					{
						this.text_fake = this.dlce1.credits_text[219];
						return;
					}
					if (this.global1.data[153] == 1 && this.global1.data[131] == 0)
					{
						this.text_fake = this.dlce1.credits_text[141];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(102);
							return;
						}
					}
					else if (this.global1.data[166] == 3 && this.global1.data[3] + this.global1.data[9] >= 550)
					{
						this.text_fake = this.dlce1.credits_text[175];
						return;
					}
				}
				else if (this.this_vrem == 9)
				{
					this.Name.text = this.dlce1.credits_text[145];
					this.text_fake = this.dlce1.credits_text[142];
					if (this.global1.data[177] == 2)
					{
						this.text_fake = this.dlce1.credits_text[218];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.yug1.gameState.yugcountries[10].is_independent && this.yug1.gameState.yugregions[10].owner != 10)
					{
						this.text_fake = this.dlce1.credits_text[241];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 3)
					{
						this.text_fake = this.dlce1.credits_text[209];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 9 && this.global1.data[148] == 2)
					{
						this.text_fake = this.dlce1.credits_text[244];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
						}
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(130);
							return;
						}
					}
					else if (this.global1.data[176] == 9)
					{
						this.text_fake = this.dlce1.credits_text[243];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 1)
					{
						this.text_fake = this.dlce1.credits_text[210];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 2 && !this.yug1.gameState.yugcountries[10].is_independent)
					{
						this.text_fake = this.dlce1.credits_text[211];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 2 && this.yug1.gameState.yugcountries[10].is_independent)
					{
						this.text_fake = this.dlce1.credits_text[212];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 8)
					{
						this.text_fake = this.dlce1.credits_text[213];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 7)
					{
						this.text_fake = this.dlce1.credits_text[214];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 5)
					{
						this.text_fake = this.dlce1.credits_text[215];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 6)
					{
						this.text_fake = this.dlce1.credits_text[216];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[176] == 4)
					{
						this.text_fake = this.dlce1.credits_text[217];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.global1.data[155] == 3)
					{
						this.text_fake = this.dlce1.credits_text[95];
						if (this.yug1.gameState.yugcountries[6].is_exist)
						{
							this.text_fake += this.dlce1.credits_text[91];
							return;
						}
					}
					else if (this.yug1.gameState.yugcountries[6].is_exist)
					{
						this.text_fake = this.dlce1.credits_text[91];
						return;
					}
				}
				else if (this.this_vrem == 10)
				{
					if (this.global1.data[164] == 8 && this.yug1.gameState.modifies[5] == 0 && this.global1.data[157] != 2 && this.global1.data[158] != 2 && this.global1.data[128] != 2 && this.global1.data[10] <= 400)
					{
						this.Name.text = this.dlce1.credits_text[152];
						this.text_fake = this.dlce1.credits_text[155];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(106);
							return;
						}
					}
					else
					{
						if (this.global1.data[164] == 8 && this.global1.data[10] <= 400)
						{
							this.Name.text = this.dlce1.credits_text[153];
							this.text_fake = this.dlce1.credits_text[156];
							return;
						}
						if (this.global1.data[164] == 8 && this.global1.data[10] >= 401)
						{
							this.Name.text = this.dlce1.credits_text[154];
							this.text_fake = this.dlce1.credits_text[157];
							return;
						}
						this.Name.text = this.dlce1.credits_text[169];
						this.text_fake = this.dlce1.credits_text[180];
						return;
					}
				}
				else if (this.this_vrem == 11)
				{
					if (!this.global1.event_done[371] && this.global1.data[164] <= 5)
					{
						this.Name.text = this.dlce1.credits_text[158];
						this.text_fake = this.dlce1.credits_text[177];
						return;
					}
					if (this.global1.data[164] == 8)
					{
						this.Name.text = this.dlce1.credits_text[162];
						this.text_fake = this.dlce1.credits_text[167];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(110);
							return;
						}
					}
					else
					{
						if (this.global1.event_done[372] && this.global1.data[164] <= 5)
						{
							this.Name.text = this.dlce1.credits_text[158];
							this.text_fake = this.dlce1.credits_text[163];
							return;
						}
						if (this.global1.data[164] == 7 && this.global1.allcountries[17].Westalgie + this.global1.data[7] + this.global1.data[9] / 10 + this.global1.data[6] / 10 + this.global1.data[8] / 20 >= 1350)
						{
							this.Name.text = this.dlce1.credits_text[160];
							this.text_fake = this.dlce1.credits_text[165];
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(108);
								return;
							}
						}
						else
						{
							if (this.global1.allcountries[17].Westalgie + this.global1.data[7] + this.global1.data[9] / 10 >= 1000)
							{
								this.Name.text = this.dlce1.credits_text[186];
								this.text_fake = this.dlce1.credits_text[187];
								return;
							}
							if (this.global1.data[164] == 7 && this.global1.allcountries[17].Westalgie >= 300)
							{
								this.Name.text = this.dlce1.credits_text[161];
								this.text_fake = this.dlce1.credits_text[166];
								if (this.global1.iron_and_blood)
								{
									this.achieves.GetComponent<achievements>().Set(109);
									return;
								}
							}
							else
							{
								this.Name.text = this.dlce1.credits_text[159];
								this.text_fake = this.dlce1.credits_text[164];
								if (this.global1.iron_and_blood)
								{
									this.achieves.GetComponent<achievements>().Set(107);
									return;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			if (this.this_okno == 2)
			{
				this.this_okno = 0;
				this.this_vrem = 0;
			}
			else if (this.this_okno == 0)
			{
				this.this_okno = 2;
				this.this_vrem = 9;
			}
			this.Name.text = this.dlce1.credits_text[115];
			this.text_fake = this.dlce1.credits_text[113];
			if (this.global1.iron_and_blood)
			{
				if (this.yug1.gameState.player == 5 && this.yug1.gameState.yugcountries[8].is_ally)
				{
					this.achieves.GetComponent<achievements>().Set(81);
				}
				else if (this.yug1.gameState.player == 7 && this.yug1.gameState.yugcountries[3].is_ally)
				{
					this.achieves.GetComponent<achievements>().Set(82);
				}
				else if (this.yug1.gameState.player == 10 && this.yug1.gameState.yugcountries[1].is_ally)
				{
					this.achieves.GetComponent<achievements>().Set(83);
				}
				else if (this.yug1.gameState.player == 1 || this.yug1.gameState.player == 3 || this.yug1.gameState.player == 8)
				{
					this.achieves.GetComponent<achievements>().Set(84);
				}
				if (this.global1.event_done[1102] && this.global1.event_done[1103] && this.global1.event_done[1105] && this.global1.event_done[1106])
				{
					this.achieves.GetComponent<achievements>().Set(85);
				}
			}
		}
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0004B820 File Offset: 0x00049A20
	private void ThisEndingWindow(List<int> havepaths, int plus_max)
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.this_okno >= 0 && this.this_okno <= 2)
			{
				this.YugoEndings();
				this.SovToRus(this.text_fake);
			}
			else if (this.this_okno == 0 && this.global1.data[0] != 12)
			{
				this.Name.text = "POLITICAL STANCE";
				this.text_fake = "";
				if (this.global1.data[42] == 1)
				{
					if (this.global1.data[0] != 10 && this.global1.data[0] != 18 && this.global1.data[0] != 12)
					{
						this.text_fake = string.Concat(new string[]
						{
							"Thanks to decisive actions,  ",
							this.global1.politics_name[this.global1.data[11]],
							" was able to defeat his opponents and preserve the socialist system. And after our analogue of the Cultural Revolution, even at the cost of some victims, ",
							this.global1.politics_name[this.global1.data[11]],
							" finally consolidated his power. |Unfortunately, after his death, in ",
							this.global1.party_name[0],
							" began a strife for the place of the head of state, as a result of which, at the party congress, the personality cult of the past ruler was refuted, and he himself was posthumously convicted. Was that the reason for personal dislike or was it a necessity for keeping power - who knows?... And it does not matter, because the stories of previous leader's bloody crimes are passed down from generation to generation. |In the country there was a thaw. The establishment of more friendly relations with the West began, as well as relaxations in the sphere of pluralism, culture and censorship. Party bureaucrats received protection from special services and all the power, trying to maintain the current conservative position of government. Perhaps this is even for the best..."
						});
					}
					else
					{
						this.text_fake = string.Concat(new string[]
						{
							"Thanks to decisive actions,  ",
							this.global1.politics_name[this.global1.data[11]],
							" was able to defeat his opponents and preserve the socialist system. And after our analogue of the Cultural Revolution, even at the cost of some victims, ",
							this.global1.politics_name[this.global1.data[11]],
							" finally consolidated his power. |After the death of the great leader, his son, chosen in advance by the successor, continued the work of his father - the Leader of the nation. However, his attempts to modify something in the country were thwarted by the top party leadership, and he gradually began to grow cold towards politics, and toward the country's leadership, transferring this matter to the Politburo. Thus, his presence in the post becomes more and more nominal. Although the word “republic” appears in the name of the state, in fact, a new dynasty of monarchs reigned in the country."
						});
					}
				}
				else if (this.global1.data[42] == 2)
				{
					this.text_fake = "Thanks to your decisive actions, you were able to defeat your opponents, and to preserve the socialist system. And after the Cultural Revolution, even at the cost of some victims, you finally strengthened your power. Without wishing to repeat the fate of Stalin, you began to build your own personality cult, putting yourself in the same place with Marx, Engels and other theorists of communism, gradually forming your ideology. Your child was the Party. Completely renewed and completely devoted to you. |Unfortunately, your life was interrupted by an unknown disease. And was it disease?..|You, as alive and real person, no longer needed for the Party, the child who absorb it's creator. You shouldn't be just a human any more. You had to become an icon, an \"eternal leader\". |Freedom of thought and freedom of speech were significantly curtailed, and control over citizens was greatly enhanced. But this has yield results: now our citizens are selflessly loyal to the Party, and the Party is the state.";
					if (this.global1.data[0] != 10)
					{
						this.text_fake += "|Unfortunately, our country is increasingly called the \"European DPRK\" - Western imperialists can't stand us, however, like the ideals of socialism . Or... Maybe it's still we went somewhere wrong?";
					}
					this.text_fake += "|As it were, our country continues to exist, like your cult. You are our eternal and only posthumous president! Ave for you!|And yet, where did we go, and where do we go next? The question is, perhaps, rhetorical...";
				}
				else if (this.global1.data[42] == 3)
				{
					this.text_fake = this.global1.politics_name[this.global1.data[11]] + " determinedly established a one-party democracy headed by " + this.global1.party_name[0] + ",whose idea was to sweep away all counter-revolutionary ideas, moving towards to build of Marxism-Leninism and assert the leading role of democratic centralism and collective government. However, the people took it as an affront, that the current government mired in the bureaucracy, \"eating\" honest people. Citizens are trading tales and making fun of the Party.";
				}
				else if (this.global1.data[42] == 4)
				{
					this.text_fake = this.global1.politics_name[this.global1.data[11]] + " and " + this.global1.party_name[0] + " determinedly established a one-party democracy in the country, allowing all counter-revolutionary ideas to be swept aside and moving towards to build of Marxism-Leninism. Despite some miscalculations by the ruler, the people have reacted with understanding to the policy pursued and are ready to support him and the Party further. Thus, the leading role of democratic centralism and collective government has been established in the country.";
				}
				else if (this.global1.data[42] == 5)
				{
					this.text_fake = string.Concat(new string[]
					{
						"Thanks to decisive actions,  ",
						this.global1.politics_name[this.global1.data[11]],
						"was able to defeat his opponents and retain power. Unfortunately, over time, his vigilance weakened. ",
						this.global1.politics_name[this.global1.data[11]],
						" did not notice when in the parliament formed groups dissatisfied with his rule...|And now, after another polemic in parliament, the secretary of our esteemed leader brought him tea, with strange smell of almonds. ",
						this.global1.politics_name[this.global1.data[11]],
						" did not even have time to realize that it was potassium cyanide....|After the \"untimely death\" of the Great Leader, the power passed to other people who began to slowly curtail attempt to introduce his cult of personality in the country, and then simply erase the previous ruler from memory and history.|However, as such, there have been no significant changes, and the state still dominates the economy. Is it good or bad - who knows?.."
					});
				}
				else if (this.global1.data[42] == 6)
				{
					this.text_fake = string.Concat(new string[]
					{
						"During the fall of the socialist regimes around the world, ",
						this.global1.politics_name[this.global1.data[11]],
						", fearing for his own power, began feverishly looking for compromises with representatives of the opposition and political opponents, while simultaneously trying to please the power structures. Unfortunately, in order to preserve power, he also had to bow to the Western powers ...|As a result, by ",
						(this.global1.data[21] + 3).ToString(),
						" , the country had changed beyond recognition. Being driven into a corner, ",
						this.global1.politics_name[this.global1.data[11]],
						" rejected the ideals of Marxism-Leninism. In a fit of feverish struggle for the preservation of power, he conducted an ultra-rapid liberalization of the diplomatic, political and social spheres. As a result - globalization, dependence on foreign powers and the emergence of a corrupt bureaucratic system.|Managed democracy has been established in the country. All the parties represented in the parliament are, in fact, only puppets. And the power is now quite strong and ",
						this.global1.politics_name[this.global1.data[11]],
						" can calmly rule further. But the question arises - is it necessary at all?.. "
					});
				}
				else if (this.global1.data[42] == 7)
				{
					this.text_fake = string.Concat(new string[]
					{
						this.global1.politics_name[this.global1.data[11]],
						" was a controversial figure, for some he will forever remain the \"winner of communism\", and for others only a traitor. The share of the ",
						this.global1.party_name[0],
						" had the difficult mission of winning over the past system, democratization of the country according to the Western standards. The time of our president will forever be remembered as an era of liberalism, however, conservative right-wing and more radical left-wing oppositionists still sharply criticize the reforms of those times. Eventually came the presidential elections, which won the legal opposition, and the leader went to rest. The oppositionists took advantage of the population's discontent with economic policy to come to power, but the economy was exposed only to cosmetic reforms. This led to the fact that the ",
						this.global1.party_name[0],
						", still not lost in weight, returned to power in the next election.|"
					});
					if (this.global1.data[0] == 1)
					{
						this.text_fake += "When the GDR and the FRG became so similar to each other as the twin brothers, the question arose about unification. However, complete unification did not happen: Ossi and Wessi, although they were Germans, but the years of life under different regimes did their job. Therefore, the union of the west and the east took place in the form of a confederation: Germany became formally united, the customs borders disappeared, and the army became a single Bundeswehr, but all the same in the rest of the east the changes were minimal, and the autonomies of all other structures are quite significant. Nothing shook the new order of things. ";
					}
					this.text_fake = this.text_fake + "But " + this.global1.politics_name[this.global1.data[11]] + " was later accused of being a freelance agent of the special services of the old communist regime, before coming to power. This is the only thing that disturbed the former president, who was disappointed with what his successors had done with the country, but it was no longer possible to return to politics: the times had changed. And the Supreme Court acquitted him.";
				}
				else if (this.global1.data[42] == 8 && this.global1.data[43] == 2)
				{
					this.text_fake = this.global1.politics_name[this.global1.data[11]] + " was a controversial figure, for some he will forever remain the \"perfect communist\", and for others only a traitor. The share of the " + this.global1.party_name[0] + " had the difficult mission of winning over the past system, democratization of the country according to the Western standards. The time of our president will forever be remembered as an era of prosperity of our country's economy, although some radicals will dare to say that it was better before. The policy pursued by the national leader was supported by all classes so much that he held the post of president until his death. There were no sensible opponents in the country, and the media is still comparing our all-respected president with Roosevelt himself!|";
					if (this.global1.data[0] == 1)
					{
						this.text_fake = this.text_fake + "And " + this.global1.politics_name[this.global1.data[11]] + " was later immortalized in a monument on one of the specially preserved sections of the Berlin Wall.";
					}
				}
				else if (this.global1.data[42] == 8)
				{
					this.text_fake = this.global1.politics_name[this.global1.data[11]] + " was a controversial figure, for some he will forever remain the \"winner of communism\", and for others only a traitor. The share of the " + this.global1.party_name[0] + " had the difficult mission of winning over the past system, democratization of the country according to the Western standards. The time of our president will forever be remembered as an era of prosperity of our country's economy, although some radicals will dare to say that it was better before. The policy pursued by the national leader was supported by all classes so much that he held the post of president until his death. There were no sensible opponents in the country, and the media is still comparing our all-respected president with Roosevelt himself!|";
					if (this.global1.data[0] == 1)
					{
						this.text_fake = this.text_fake + "When the GDR and the FRG became so similar to each other as the twin brothers, the question arose about unification. However, complete unification did not happen: Ossi and Wessi, although they were Germans, but the years of life under different regimes did their job. Yes, and " + this.global1.politics_name[this.global1.data[11]] + " himself during his life delayed this issue to the last. Therefore, the union of the west and the east took place in the form of a confederation: Germany became formally united, the customs borders disappeared, and the army became a single Bundeswehr, but all the same in the rest of the east the changes were minimal, and the autonomies of all other structures are quite significant. In the East, even its own Parliament and the decorative People's Guard remained. Nothing shook the new order of things.|";
					}
					this.text_fake = this.text_fake + "And " + this.global1.politics_name[this.global1.data[11]] + " was later immortalized in a monument on one of the specially preserved sections of the Berlin Wall.";
				}
				else if (this.global1.data[42] == 9)
				{
					this.text_fake = "After the fall of the socialist camp, you, fearing for your own power, having enlisted the support of the Intelligence agents and the army, began feverishly to suppress any dissent in your country. After a wave of repression, you fell under the first wave of sanctions by the UN, after which the country finally went into isolation and, having reduced trade and diplomatic ties with the outside world, founded even more iron curtain. |Now in your country, ideology is elevated to the rank of religion, and any dissident is immediately destroyed physicaly. And the ideology itself has completely separated from Marxism-Leninism by forming a new structure, based on folk traditions and national forces.|After your death, many mystical legends gathered around you, making you almost a god in the new ideological-religious Pantheon, opening the mausoleum and starting the countdown of a new calendar from your birth. And the country began to rule your son, giving rise to a new dynasty. ";
				}
				else if (this.global1.data[42] == 10)
				{
					this.text_fake = string.Concat(new string[]
					{
						"Because of the wise policy of our leader, the country has withstood in troubled years. ",
						this.global1.politics_name[this.global1.data[11]],
						" will always be remembered as the savior of the country, at least so will be written in history textbooks. Despite the screams of individual \"derelicts\", the special forces, the police and the army restored their orders: all opposition media and parties were banned, the country was mired in xenophobia and militarism, and the censorship committees worked without stopping. The Church also rose its head, having concluded an unspoken concordat with the government ... However, no one dared to speak out loud about it. Occasionally, accusations of \"fascization\" were coming from abroad, but they were repeatedly declared as false propaganda, the conflict was cover up, and diplomatic and economic relations continued. So the leader of the ",
						this.global1.party_name[0],
						" rule until his sudden death from a stroke. After that, the country was headed by his closest associates, who immediately began the struggle for power. Probably, someday this corrupt military-bureaucratic system will fall under its own weight, but it will not be very soon."
					});
				}
				if (this.global1.data[0] == 1 && this.global1.data[42] != 8 && this.global1.data[42] != 7 && this.global1.allcountries[this.global1.data[0]].Vyshi && !this.global1.allcountries[7].isOVD)
				{
					this.text_fake = this.text_fake + "When the GDR and the FRG became so similar to each other as the twin brothers, the question arose about unification. However, complete unification did not happen: Ossi and Wessi, although they were Germans, but the years of life under different regimes did their job. Yes, and " + this.global1.politics_name[this.global1.data[11]] + " himself during his life delayed this issue to the last. Therefore, the union of the west and the east took place in the form of a confederation: Germany became formally united, the customs borders disappeared, and the army became a single Bundeswehr, but all the same in the rest of the east the changes were minimal, and the autonomies of all other structures are quite significant. In the East, even its own Parliament and the decorative People's Guard remained. Nothing shook the new order of things.|";
				}
				else if (this.global1.eventVariantChosen[1098] == 2)
				{
					if (this.global1.data[16] < 12 && this.global1.data[14] < 3)
					{
						this.text_fake += "|First the SED, CDU and NDPG were merged into the CSU/CDU bloc with a formally new official ideology, followed by the introduction of a purely nominal office of President, elected by Parliament, and the final step was a return to the 1949 Constitution with the introduction of formal federalism and German acronyms. But despite the expectations of certain individuals and organisations, East Germany did not succumb to Western influence, nor was it Westernised or liberalised: portraits of Marx and Engels continued to hang in the streets, Marxist works and dialectic were taught in schools, and the planned economy and socialist regime were still in place.";
					}
					else
					{
						this.text_fake += "|Many believed in the best, but expected the transformation of the GDR to remain a mere formality. Their fears did not materialise: although East Germany continued to oppose Western liberalism, the GDR underwent serious reforms, and a regime jokingly referred to as a \"mirror of the FRG\" was established within the country. And even the East German government does not hide its \"mirror\" status and proudly calls itself \"better version of West Germany\" in its propaganda.";
					}
				}
				else if (this.global1.eventVariantChosen[58] == 1 && this.global1.event_done[58])
				{
					this.text_fake += "|Remaining in power, adopting the ideas of Austro-Marxism and Eurocommunism, our party changed the vector of the class struggle to the struggle for tolerance, acceptance of any difference and social individualism. By implementing a new political program by 2020, our country has successfully managed to become an example for many Western opposition social movements despite all our new social problems, such as a low level of collectivism and a high level of depression and aggression among the population.";
				}
				else if (this.global1.eventVariantChosen[58] == 0 && this.global1.event_done[58])
				{
					if (this.global1.data[16] < 12)
					{
						this.text_fake += "|Remaining in power, adopting the ideas of the old National Bolshevism and Nikisch, our party changed the vector of the class struggle to the struggle for national welfare and a nationwide state, the struggle against the West and for unity with the East. By implementing a new political program by 2020, our country has successfully managed to become an example for many world socialist organizations, which, seeing our successful course, adopted and popularized the National Bolshevik movement. Let's hope that the eclectic system of uniting peasants, workers, the petty bourgeoisie and the intelligentsia will continue to hold on, and will not go over to the classic \"union of a swan, pike and crawfish.\"";
					}
					else
					{
						this.text_fake += "|Remaining in power, adopting the ideas of the old National Bolshevism and Nikisch, our party changed the vector of the class struggle to the struggle for national welfare and a nationwide state, the struggle against the West and for unity with the East. Implementing a new political program for 2020, our country also moved away from the original ideas of Nikisch, inspired by the Strasser brothers, but managed to become an example for many world nationalist parties and organizations, showing an example of building a national-corporatist state without ethnic cleansing and imperial ambitions. Let's hope that the solidarity of workers and corporations, mediated by the state, will work longer than in all past historical examples.";
					}
				}
				if (this.global1.iron_and_blood)
				{
					if (this.global1.eventVariantChosen[1098] == 2 && this.global1.eventVariantChosen[57] == 4 && this.global1.eventVariantChosen[34] == 0 && this.global1.data[14] <= 0)
					{
						this.achieves.GetComponent<achievements>().Set(131);
					}
					else if (this.global1.eventVariantChosen[1098] == 0 && this.global1.eventVariantChosen[58] == 1 && this.global1.data[16] > 12)
					{
						this.achieves.GetComponent<achievements>().Set(132);
					}
					else if (this.global1.eventVariantChosen[1098] == 1 && this.global1.eventVariantChosen[58] == 0 && this.global1.data[16] == 11)
					{
						this.achieves.GetComponent<achievements>().Set(133);
					}
				}
			}
			else if (this.this_okno == 0)
			{
				if (this.global1.iron_and_blood && !this.global1.allcountries[7].Vyshi && this.global1.data[90] == 0 && this.global1.data[92] == 0 && this.global1.data[93] == 0 && this.global1.data[94] == 0)
				{
					this.achieves.GetComponent<achievements>().Set(65);
				}
				this.Name.text = "POLITICAL POSITION";
				if (this.global1.data[103] == 1 && this.global1.data[80] >= 80)
				{
					this.text_fake = string.Concat(new string[]
					{
						"By decisive action, ",
						this.global1.politics_name[this.global1.data[11]],
						" and ",
						this.global1.party_name[0],
						" established one-party democracy in the country, which made it possible to sweep away all counter-revolutionary ideas and move towards building Marxism-Leninism. Despite some miscalculations of the ruler, the people treated the policy with understanding and were ready to support him and the Party further. Thus, the leading role of democratic centralism and collective governance has been established in the country.."
					});
				}
				else if (this.global1.data[104] == 1)
				{
					this.text_fake = "Tanai and the Khalqist wing of the party were able to deal with the opposition in the PDPA and establish the party’s official ideology as «Islamic Socialism», thereby combining the teachings of the Koran and the Prophet Muhammad with the progressive principles of social justice, freedom and equality. These measures helped the Afghan government enlist the support of the clergy and cause discord among the rebels, some of whom began to actively side with the PDPA. Despite some miscalculations by President Tanai, the Democratic Republic of Afghanistan continues to exist, and that's what counts.";
				}
				else if (this.global1.data[105] == 1 && this.global1.data[106] == 0)
				{
					this.text_fake = "Influenced by Soviet perestroika and the desire to implement a «policy of national reconciliation», the People's Democratic Party of Afghanistan changed its name to «Watan» (Fatherland), starting a retreat from Marxist-Leninist theory to democratic socialism with Islamic characteristics. The multi-party system was again legalized, however, only pro-democratic and government-loyal parties were able to take part in the subsequent elections, and as a result, the reformed PDPA received an absolute majority of votes. Due to the relative liberalization of the regime and the consolidation of the status of state religion for Islam, a small part of the opposition went to cooperate with the government, but there were still enough dissatisfied with half-hearted reforms.";
				}
				else if (this.global1.data[105] == 1 && this.global1.data[106] == 1)
				{
					this.text_fake = "Influenced by Soviet perestroika and the desire to implement a «policy of national reconciliation», the People's Democratic Party of Afghanistan changed its name to «Watan» (Fatherland), starting a retreat from Marxist-Leninist theory to democratic socialism with Islamic characteristics. The DRA government also cooperated with the «moderate part of the opposition», agreeing to hold free democratic elections and create a joint coalition government. Thanks to the relative liberalization of the regime and the proclamation of Islam as the state religion, a significant part of the opposition sided with the DRA, abandoning the guerrilla warfare. Over time, the country fully transformed into an analogue of liberal democracy with two leading parties - the Social Democratic Party «Watan» and the right-wing conservative «Islamic Party of Afghanistan».";
				}
				else
				{
					this.text_fake = "The civil war caused serious damage to the political system of Afghanistan, so now it is very difficult to say what the country expects in the future. Nevertheless, the Democratic Republic of Afghanistan continues to exist, and that's what counts. ";
				}
			}
			else if (this.this_okno == 1 && this.global1.data[0] != 12)
			{
				this.Name.text = "ECONOMIC SYSTEM";
				this.text_fake = "";
				if (this.global1.data[43] == 1)
				{
					this.text_fake = "In spite of everything, we were able to maintain the classical planned economy with its advantages and disadvantages. Although the worldwide development of computerization and the gradual introduction of automated management systems and republican automated control system into our enterprises complicates corruption and forgery of officials,it is still too early to talk about the full computerization of the Gosplan. So forgery and corruption in Gosplan are still common, because of what certain goods are sometimes not enough, but handicraftsmen and cooperatives are gradually compensating for this deficit. State control over foreign trade provides us with independence from the external market. The economy is developing steadily, money is coming to the budget, and we have proved to the whole world that there is a real alternative to capitalism.";
				}
				else if (this.global1.data[43] == 2)
				{
					this.text_fake = "Despite the demands to reform the economy, we successfully built OGAS and implemented it in our Gosplan. Thanks to this, we were able to almost completely overcome the forgeries and corruption within it, which gave a sharp push to the development of our economy, allowing us to accomplish our economic miracle. Now our economy is impartially managed by a single automated system, so that it develops rapidly, and goods are produced enough for everyone. The people are happy, the budget is filled with money, and automated communism seems to the people more and more real.";
				}
				else if (this.global1.data[43] == 3)
				{
					this.text_fake = "Realizing the need to reform our economy, but not seeing the future in capitalism, we carried out reforms based on the Hungarian Kadar's system. Refusal to centralize planning in favor of expanding the independence of enterprises, while preserving state property on them, gave impetus to the development of our economy. The competitiveness and quality of our goods have increased, even new products have appeared for our country, and foreign trade is flourishing. However, at the same time, corruption and shadow schemes developed, dependence on the external market increased, and \"unprofitable\" enterprises either get subsidized from the budget or fall apart. However, we showed that the market can be organized under socialism and ensure the welfare of the country.";
				}
				else if (this.global1.data[43] == 4)
				{
					this.text_fake = "Obeying the wind of change, we made the transition to a free market economy. State enterprises were privatized, and control over prices and foreign trade was a thing of the past. This allowed enterprising and skilful leaders to rise and now they are moving our economy, and the people received long-awaited jeans and cola and the opportunity to organize their business. However, at the same time people looking for ways to earn money are not shy in methods, which contributes to the flowering of shadow schemes and corruption, many workers have become unemployed, and many beginning businessmen are very quickly bankrupted. Now you will have to face the problems of capitalism - growing inequality, corruption and unemployment, but the problems of the planned economy will now definitely not disturb us.";
				}
				else if (this.global1.data[43] == 5)
				{
					this.text_fake = "While public organizations began to call for more freedom for the people in the production of their own goods, in the " + this.global1.party_name[0] + ", on the wave of liberalization, the supporters of fraction of liberalization of the economy came to leadership: first, were allowed collective forms of entrepreneurship - artels, cooperatives, proprietorships, family farms instead of kolkhozes, which were given multiple freedom. The next step was the transition of state-owned enterprises to self-financing, under the guise of fighting bureaucracy. Then foreign investments were allowed inward and the opening of joint ventures with foreign companies began, as a form of using foreign capital for the benefit of our people. Gradually, the entire planned economy came to naught, and in the country, state capitalism reigned with all the working mechanisms of a market economy.";
				}
				if (this.global1.allcountries[this.global1.data[0]].subideology >= 300)
				{
					this.text_fake = this.text_fake + "\n" + this.dlce1.credits_text[48];
				}
			}
			else if (this.this_okno == 1)
			{
				this.Name.text = "ECONOMIC SYSTEM";
				this.text_fake = "";
				if (this.global1.data[16] == 10 && !this.global1.allcountries[7].Vyshi)
				{
					this.text_fake = "The gradual stabilization of the situation made it possible to launch full-fledged socialist reforms in the country with the subsequent installation of economic planning in the country. Small business and handicraft have been fully legalized, and in agriculture, uniting into family contracts and cooperatives is encouraged. Along with this, the government is carrying out large-scale social transformations: the construction of apartments, schools, hospitals, kindergartens. Peaceful situation and support for the USSR enabled the Afghan economy to develop stably.";
				}
				else if (this.global1.data[16] == 12 && !this.global1.allcountries[7].Vyshi)
				{
					this.text_fake = "The gradual stabilization of the situation enabled the government to launch economic reforms within the framework of socialism. Large enterprises are still in state ownership, but the production of light industry and consumer goods was completely transferred to the management of work collectives. Campaigns to support the sole peasantry are being carried out in agricultural regions, and the government is actively providing loans and incentives to rural workers to purchase equipment. The massive construction of schools, hospitals and housing complexes were able to significantly raise the standard of living of the population, and thanks to Soviet help and specialists, Afghanistan is developing more and more knowledge-intensive sectors in the national economy every year.";
				}
				else if (this.global1.data[16] == 13 && !this.global1.allcountries[7].Vyshi)
				{
					this.text_fake = "The gradual stabilization of the situation enabled the government to launch economic reforms. Most medium-sized enterprises, as well as some large enterprises built by the USSR, were privatized and transferred into the hands of entrepreneurs. In agriculture, campaigns have been launched to encourage farmers to whom the government grants loans to buy equipment. Thanks to Soviet support, mass construction of schools, hospitals and housing complexes began, the standard of living of the population is growing steadily, and the economy of Afghanistan is gradually recovering from the consequences of the civil war.";
				}
				else if (this.global1.allcountries[7].Vyshi)
				{
					this.text_fake = "The collapse of the socialist camp and the USSR seriously hit our already weak economy. The government’s post-war attempt to introduce any economic reforms led only to resistance from the opposition, which to this day considers private property a «divine gift», demanding respect for its inviolability and protection from the state. As a result, even though the state still had a regulatory role, small and medium-sized enterprises were transferred under the control of entrepreneurs, and among the peasants there was growing discontent due to low land and poor mechanization of agriculture. Despite this, our economy shows a small but steady growth, although feudal survivals still dominate in some regions.";
				}
				else if (!this.global1.allcountries[7].Vyshi)
				{
					this.text_fake = "Transformations in the socialist camp seriously hit our already weak economy. The government’s post-war attempt to introduce any economic reforms led only to resistance from the opposition, which to this day defends tribal property with a «divine gift», demanding respect for its inviolability and protection from the state. As a result, even though the state still had a regulatory role, small and medium-sized enterprises were transferred under the control of entrepreneurs, and among the peasants there was growing discontent due to low land and poor mechanization of agriculture. Despite this, our economy shows a small but steady growth, although feudal survivals still dominate the country.";
				}
			}
			else if (this.this_okno == 2)
			{
				this.Name.text = "WELFARE OF THE PEOPLE";
				this.text_fake = "";
				if (this.global1.data[44] == 1)
				{
					this.text_fake = string.Concat(new string[]
					{
						"Our leader, ",
						this.global1.politics_name[this.global1.data[11]],
						" and his brilliant rule made it possible to create a thriving economy and excellent social security, whereby all our people live in luxury and prosperity. Our country ranks first in the world in terms of living standards, even ahead of the Scandinavian countries. ",
						this.global1.politics_name[this.global1.data[11]],
						" will go down in history as one of the most successful rulers, and our citizens are happy to prosper under his wise leadership."
					});
					if (this.global1.data[58] == 1)
					{
						this.text_fake += "|The decision to modernize the oil production allowed us to significantly increase the level of imports and carry out in-depth social reforms, thanks to which the people are now very pleased.";
					}
				}
				else if (this.global1.data[44] == 2)
				{
					this.text_fake = "Our leader, " + this.global1.politics_name[this.global1.data[11]] + " and his able leadership created a developed economy and social sphere and were able to provide all people with a comfortable and stable life. Our country is proud of quality of life same with Europe, and many people from less successful countries, most of whom, dream of leaving for us. Our people are happy to have such a worthy life and the ruler who provided it.";
					if (this.global1.data[58] == 1)
					{
						this.text_fake += "|The decision to modernize the oil production allowed us to significantly increase the level of imports and carry out in-depth social reforms, thanks to which the people are now very pleased.";
					}
				}
				else if (this.global1.data[44] == 3 && this.global1.allcountries[7].isSEV)
				{
					this.text_fake = "Our leader, " + this.global1.politics_name[this.global1.data[11]] + " and his rule created an economy that allowed the people to live a more or less dignified life. And although we are lagging behind Europe, our people have food, housing, education and some luxury. The Soviet Union was able to recover from the social crisis and reach our level only by the 2010s, and our citizens at least do not have to worry about hunger and a roof over their heads.";
					if (this.global1.data[58] == 1)
					{
						this.text_fake += "|The decision to modernize the oil production allowed us to significantly increase the level of imports and carry out in-depth social reforms, thanks to which the people are now pleased.";
					}
				}
				else if (this.global1.data[44] == 3)
				{
					this.text_fake = "Our leader, " + this.global1.politics_name[this.global1.data[11]] + " and his rule created an economy that allowed the people to live a more or less dignified life. And although we are lagging behind Europe, our people have food, housing, education and some luxury. The countries of the former USSR were able to reach our level only by the 2010s, and our citizens at least do not have to worry about hunger and a roof over their heads.";
					if (this.global1.data[58] == 1)
					{
						this.text_fake += "|The decision to modernize the oil production allowed us to significantly increase the level of imports and carry out in-depth social reforms, thanks to which the people are now pleased.";
					}
				}
				else if (this.global1.data[44] == 4)
				{
					this.text_fake = "Our leader, " + this.global1.politics_name[this.global1.data[11]] + " and his rule led to the collapse of the social sphere, plunging the population into poverty. Unemployment, homelessness and periodic malnutrition have become commonplace for our citizens, and our country is forced to accept humanitarian aid from international organizations. There is no need to talk about comfort, and our citizens will forever remember these difficult times.";
				}
			}
			else if (this.this_okno == 3)
			{
				this.Name.text = "SOVIET UNION";
				this.text_fake = "";
				if (this.global1.allcountries[7].paths == 2)
				{
					this.text_fake = "Despite the reforms that have taken place in the USSR and the countries of the socialist camp, the world is still multi-polar, and renewed communism is still a decisive international force.";
				}
				else if (this.global1.allcountries[7].paths == 3)
				{
					this.text_fake = "Despite the reforms that have taken place in the USSR and the countries of the socialist camp, the Soviet Union has remained one of the undisputed hegemons in the world, and renewed communism is still a decisive international force. |Stabilizing the external situation and remaining as a powerful force, with the active support of the newly formed Security Council, consisting of pragmatic reformists, the Soviet government was able to stop internal strife and direct the people's views from the ideas of disengagement to the ideas of deep economic reforms.";
				}
				else if (this.global1.data[45] == 1)
				{
					this.text_fake = "Despite the reforms that have taken place in the USSR and the countries of the socialist camp, the Soviet Union has remained one of the undisputed hegemons in the world, and renewed communism is still a decisive international force. |Stabilizing the external situation and remaining as a powerful force, with the active support of the newly formed Security Council, consisting of pragmatic reformists, the Soviet government was able to stop internal strife and direct the people's views from the ideas of disengagement to the ideas of deep economic reforms. |Taking a cue from China and having established relations with them, President Gorbachev ruled the country for two presidential terms, himself having introduced a board limit. After the second term, he resigned his post and promised not to run for more, remaining the General Secretary of the CPSU Central Committee. However, Gorbachev's reforms, although they gave more freedom to the country and helped to rise for certain enterprising organizers, but, on the whole, the social situation continues to deteriorate year after year. |And people with great hope expects qualitative changes, linking them with the new presidential elections.";
				}
				else if (this.global1.data[45] == 2)
				{
					this.text_fake = "Despite the reforms that have taken place in the USSR and the countries of the socialist camp, the Soviet Union has remained one of the undisputed leaders in the world, and renewed communism is still a decisive international force. |All attempts made by the right-liberal opposition to carry out reforms aimed at dismantling of the Union quickly collapsed when, in spite of Yeltsin's promises to give more sovereignty to Russia and not feed other nations, the candidate from the CPSU, Nikolai Ryzhkov, won the first presidential election in the RSFSR. |With the active support of the newly formed Security Council, consisting of pragmatic reformists, the Soviet government directed the people's views to the ideas of deep economic reforms. |Taking a cue from China and having established relations with them, President Gorbachev ruled the country for two presidential terms, himself having introduced a board limit. After the second term, he resigned his post and promised not to run for more, remaining the General Secretary of the CPSU Central Committee. However, Gorbachev's reforms, although they gave more freedom to the country and helped to rise for certain enterprising organizers, but, on the whole, the social situation continues to deteriorate year after year. |And people with great hope expects qualitative changes, linking them with the new presidential elections.";
				}
				else if (this.global1.data[45] == 3)
				{
					this.text_fake = "Despite the reforms that have taken place in the USSR and the countries of the socialist camp, the world is still multi-polar, and renewed communism is still a decisive international force. |And although, under the pressure of the right-liberal public, the treaty on the transformation of the USSR into the Union of Soviet Sovereign Republics entered into force, in spite of Yeltsin's promises to give more sovereignty to Russia and not feed other nations, the candidate from the CPSU, Nikolai Ryzhkov, won the first presidential election in the RSFSR, and the new union treaty, even though it expanded the rights of the republics, but, at the same time, confirmed and consolidated the unity of the Soviet people and the inviolability of the Union. |With the active support of the newly formed Security Council, consisting of pragmatic reformists, the Soviet government directed the people's views to the ideas of deep economic reforms. |Taking a cue from China and having established relations with them, President Gorbachev ruled the country for two presidential terms, himself having introduced a board limit. After the second term, he resigned his post and promised not to run for more, remaining the General Secretary of the CPSU Central Committee. However, Gorbachev's reforms, although they gave more freedom to the country and helped to rise for certain enterprising organizers, but, on the whole, the social situation continues to deteriorate year after year, and nationalistic and traditionalist associations are increasingly raising their heads in the union republics. |And people with great hope expects qualitative changes, linking them with the new presidential elections.";
				}
				else if (this.global1.data[45] == 4)
				{
					if (!this.global1.event_done[74])
					{
						this.text_fake = "The GKChP failed, largely due to the fact that on the last day of its existence, Defense Minister Yazov decided to listen to Shaposhnikov and personally dispersed the Emergency Committee, arresting its members. Thanks to this, Gorbachev's cleansings were directed only against the members of the State Emergency Committee and their prominent supporters, but other sympathizers remained unaffected, including the Chairman of the Supreme Soviet of the USSR, Anatoly Lukyanov.| As a consequence of this, the 5th Congress of People's Deputies of the USSR adopted a decision to transform the USSR into a Union of Sovereign States, which was ratified by other republics and thwarted the plans of the Belovezhskaya conspiracy. Mikhail Gorbachev became president of the SSG.| The confrontation between the Center and the supporters of complete disengagement came to an end in October 1993, when the Supreme Soviet of the RSFSR lawfully sent President Yeltsin to retirement, and when he attempted to organize a military coup, he received no support from either the Center or the military and was forced to flee abroad . Since that moment, the political situation in the SSG has stabilized.| However, Gorbachev's reforms, although they gave more freedom to the country and helped to rise for certain enterprising organizers, but, on the whole, the social situation continues to deteriorate year after year, and nationalistic and traditionalist associations are increasingly raising their heads in the union republics, which have well hidden benevolence from the representatives of the governing bodies of some of the member states of the SSG. |And people with great hope expects qualitative changes, linking them with the new presidential elections.";
					}
					else
					{
						this.text_fake = "The GKChP failed, largely due to the fact that on the last day of its existence, Defense Minister Yazov decided to listen to Shaposhnikov and personally dispersed the Emergency Committee, arresting its members. Thanks to this, Gorbachev's cleansings were directed only against the members of the State Emergency Committee and their prominent supporters, but other sympathizers remained unaffected, including the Chairman of the Supreme Soviet of the USSR, Anatoly Lukyanov. The confrontation between the Center and the supporters of complete disengagement came to an end in October 1993, when the Supreme Soviet of the RSFSR lawfully sent President Yeltsin to retirement, and when he attempted to organize a military coup, he received no support from either the Center or the military and was forced to flee abroad . Since that moment, the political situation in the SSG has stabilized.| However, Gorbachev's reforms, although they gave more freedom to the country and helped to rise for certain enterprising organizers, but, on the whole, the social situation continues to deteriorate year after year, and nationalistic and traditionalist associations are increasingly raising their heads in the union republics, which have well hidden benevolence from the representatives of the governing bodies of some of the member states of the SSG. |And people with great hope expects qualitative changes, linking them with the new presidential elections.";
					}
				}
				else if (this.global1.data[45] == 5)
				{
					this.text_fake = "The GKChP failed and the punishing hand of Gorbachev befell on all active supporters and simply sympathizing with socialist ideas and the State Emergency Committee. Mikhail Sergeyevich, destroyed the undermined confidence in the Soviet regime, liquidated the remnants of at least some influential Soviet government, and without any kind of reaction accepted the Belovezhskaya conspiracy as an accomplished affair.| The organizers of the Belovezhskaya conspiracy prepared for the escape and were surprised by this outcome gladly deceive their peoples and declare the continuity of the Soviet Union by the Commonwealth of Independent States, which, as a treaty, is only a nominal stroke of the pen, which put a fat point on the outcome of the referendum on the preservation and transformation of the USSR.| The multiple decline in the economy and in the standard of living, the unsuccessful reforms and the sharp increase in corruption and crime will now remain in the memory of the former Soviet people forever, just like the illegal coup carried out by Yeltsin in October 1993...";
				}
				else if (this.global1.data[45] == 6)
				{
					this.text_fake = string.Concat(new object[]
					{
						"The State Emergency Committee was able to take control of all TV and radio stations and prevent radical journalists from speaking out, even arresting them. Boris Yeltsin died during a shootout between his guard and the KGB detachment, who arrived for his arrest, since he did not want to surrender. Headed by General Lebed, the storming of the opposition's stronghold - the building of the Supreme Council - led to the final stabilization of the power of the Emergency Committee.|In his speeches, the leader of the State Emergency Committee Yanayev declared his adherence to the ideals of Perestroika, announcing to the whole world that Gorbachev was ill and could no longer rule the country, and in the future the first nation-wide presidential elections will be held. At the same time, the State Emergency Committee condemned the attempt to disengage the Soviet Union, calling it an attempt to go against the will of the people, who supported the unity of the USSR at the March referendum|During the whole 1992-",
						this.global1.data[21] + 1,
						", major criminal cases of the state level were held to condemn corrupt officials, scammers and state embezzlers, and with the help of brute force and well-coordinated work of the special services, all the rebel's hotbeds were finally suppressed.|And only in August ",
						this.global1.data[21] + 1,
						" the promised presidential elections began..."
					});
				}
				else if (this.global1.data[45] == 7)
				{
					this.text_fake = string.Concat(new object[]
					{
						"The State Emergency Committee was able to take control of all TV and radio stations and prevent radical journalists from speaking out, even arresting them. Boris Yeltsin died during a shootout between his guard and the KGB detachment, who arrived for his arrest, since he did not want to surrender. Headed by General Lebed, the storming of the opposition's stronghold - the building of the Supreme Council of RSFSR - led to the final stabilization of the power of the Emergency Committee.|In his speeches, the leader of the State Emergency Committee Alksnis declared that Gorbachev himself has betrayed the ideals of Perestroika, announcing to the whole world that after the funeral of Gorbachev the first presidential elections will be held, but he will be elected by members of the Supreme Soviet. At the same time, the State Emergency Committee condemned the attempt to disengage the Soviet Union, calling it an attempt to go against the will of the people.|During the whole 1992-",
						this.global1.data[21] + 1,
						", major criminal cases of the state level were held to condemn corrupt officials, scammers and state embezzlers, and with the help of brute force and well-coordinated work of the special services, all the rebel's hotbeds were finally suppressed.|And only in August ",
						this.global1.data[21] + 1,
						" the promised presidential elections began..."
					});
				}
			}
			else if (this.this_okno == 4)
			{
				this.Name.text = "SOVIET UNION";
				this.text_fake = "";
				if (this.global1.allcountries[7].paths == 2)
				{
					this.text_fake = this.dlce1.credits_text[46];
				}
				else if (this.global1.allcountries[7].paths == 3)
				{
					this.text_fake = this.dlce1.credits_text[47];
				}
				else if (this.global1.data[45] == 1)
				{
					if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(24);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Boris Pugo</color>|";
						this.text_fake += "In the new presidential election, Boris Pugo, the former Minister of Internal Affairs, came to power and immediately launched a huge campaign against corruption and market machinations, as well as mass persecution of nationalists, including the Baltic nationalists, being himself a Latvian by nationality. The next step was to force the shift of the vector of market reforms to the Chinese analogue of the bird-cage reforms, with the multiple strengthening of state intervention. Disagreed with this, Gorbachev resigned for health reasons.| The sharp drop in the level of corruption and speculation, the purging of state structures and the transition to more effective methods of economic reforms are already yielding multiple benefits in the form of a rise in the social, economic and spiritual spheres.";
					}
					else
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(26);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Vladimir Zhirinovsky</color>|";
						this.text_fake += "In the new presidential election, Vladimir Zhirinovsky, the first non-member of the CPSU since Perestroika, came to power. His promises were populist: the honest privatization of unprofitable state-owned enterprises after the restructuring of the economy and the increase in social expenses due to this, the widespread fight against corruption and bureaucracy, and the return of the former greatness of the Soviet Union on the international arena.| However, having come to power, Zhirinovsky did not make huge reassignments in the governing apparatus and the CPSU representatives still remain in the majority.| His rule Zhirinovsky began with an inaugural speech, in which he loudly and rudely attacked the supporters of the disengagement and external enemies. This already gave rise to a large-scale campaign against local nationalism and an avalanche of Russophile propaganda, which aroused negative criticism from Gorbachev and marked the beginning of an official split in the Soviet leadership...";
					}
				}
				else if (this.global1.data[45] == 2)
				{
					if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(24);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Boris Pugo</color>|";
						this.text_fake += "In the new presidential election, Boris Pugo, the former Minister of Internal Affairs, came to power and immediately launched a huge campaign against corruption and market machinations, as well as mass persecution of nationalists, including the Baltic nationalists, being himself a Latvian by nationality. The next step was to force the shift of the vector of market reforms to the Chinese analogue of the bird-cage reforms, with the multiple strengthening of state intervention. Disagreed with this, Gorbachev resigned for health reasons.| The sharp drop in the level of corruption and speculation, the purging of state structures and the transition to more effective methods of economic reforms are already yielding multiple benefits in the form of a rise in the social, economic and spiritual spheres.";
					}
					else
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(25);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Gennady Zyuganov</color>|";
						this.text_fake += "In the new presidential election, Gennady Zyuganov came to power. His promises were: support of religious freedom, in particular Orthodoxy, honest privatization of unprofitable state-owned enterprises after economic restructuring and increase of social expenses due to this, which should lead to improvement of the people's financial situation.| And he started with the opening of many SEZ in the country, inviting of foreign investors and selling of cheap labour force to them. The next step is the fulfillment of the requirements for the USSR membership in the WTO...";
					}
				}
				else if (this.global1.data[45] == 3)
				{
					if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(25);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Gennady Zyuganov</color>|";
						this.text_fake += "In the new presidential election, Gennady Zyuganov came to power. His promises were: support of religious freedom, in particular Orthodoxy, honest privatization of unprofitable state-owned enterprises after economic restructuring and increase of social expenses due to this, which should lead to improvement of the people's financial situation.| And he started with the opening of many SEZ in the country, inviting of foreign investors and selling of cheap labour force to them. The next step is the fulfillment of the requirements for the USSR membership in the WTO...";
					}
					else
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(26);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Vladimir Zhirinovsky</color>|";
						this.text_fake += "In the new presidential election, Vladimir Zhirinovsky, the first non-member of the CPSU since Perestroika, came to power. His promises were populist: the honest privatization of unprofitable state-owned enterprises after the restructuring of the economy and the increase in social expenses due to this, the widespread fight against corruption and bureaucracy, and the return of the former greatness of the Soviet Union on the international arena.| However, having come to power, Zhirinovsky did not make huge reassignments in the governing apparatus and the CPSU representatives still remain in the majority.| His rule Zhirinovsky began with an inaugural speech, in which he loudly and rudely attacked the supporters of the disengagement and external enemies. This already gave rise to a large-scale campaign against local nationalism and an avalanche of Russophile propaganda, which aroused negative criticism from Gorbachev and marked the beginning of an official split in the Soviet leadership...";
					}
				}
				else if (this.global1.data[45] == 4)
				{
					if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(27);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Alexander Lebed</color>|";
						this.text_fake += "In the new presidential election, Alexander Lebed, the first non-member of the CPSU since Perestroika, came to power, supported by mostly Russian-speaking population, who heads his own nationalist Russophile party. His promises were populist: the honest privatization of unprofitable state-owned enterprises after the restructuring of the economy and the increase in social expenses due to this, the widespread fight against corruption and bureaucracy, and the return of the former greatness of the country on the international arena.| Having come to power, Alexander completely retired the entire old composition of the country's top governing bodies and replaced them with his supporters. At the same time, using popularity and having huge connections among the officers of the Soviet army, he began training and conducting military operations against the disgruntled regional leaders who raised their heads.| His rule Lebed began with an inaugural speech, in which he loudly and rudely attacked the supporters of the disengagement and external enemies. This already gave rise to a large-scale campaign against local nationalism and an avalanche of Russophile propaganda...";
					}
					else
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(28);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Grigory Yavlinsky</color>|";
						this.text_fake += "In the new presidential election, Grigory Yavlinsky, a former member of the CPSU and leader of his own left-liberal \"Yabloko\" Party, as well as the current deputy chairman of the Council of Ministers of the SSG, came to power.|Having come to power in the wake of promises to implement the program of reforming the SSG in 500 days, abandoned by the Communists, with the integration of the Union as a whole into the international economy, Yavlinsky considers it important to strengthen market ties between the member states of the SSG and sees his rule as a lever to transform the SSG into a treaty, similar to the European Union, which definitely does not appeal to regional leaders who do not want to share economic autonomies and embezzlement rights from their budgets. | With the coming to power, under the leadership of Yavlinsky the formation of the Committee for Economic Reforms begins, the old composition of the governing bodies of the USSR is being retired, open hearings and loud persecution of corrupt people begin.|The people are eagerly awaiting the introduction of a real socially-oriented market economy...";
					}
				}
				else if (this.global1.data[45] == 5)
				{
					this.text_fake = "<color=blue>REAL HISTORY</color>|";
				}
				else if (this.global1.data[45] == 6)
				{
					if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(24);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Boris Pugo</color>|";
						this.text_fake += "In the new presidential election, Boris Pugo, the former Minister of Internal Affairs, came to power and immediately launched a huge campaign against corruption and market machinations, as well as mass persecution of nationalists, including the Baltic nationalists, being himself a Latvian by nationality. The next step was to force the shift of the vector of market reforms to the Chinese analogue of the bird-cage reforms, with the multiple strengthening of state intervention. And exactly after six months Gorbachev died tragically on the operating table...| The sharp drop in the level of corruption and speculation, the purging of state structures and the transition to more effective methods of economic reforms are already yielding multiple benefits in the form of a rise in the social, economic and spiritual spheres.";
					}
					else
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(25);
						}
						this.text_fake = "|<color=red>CALCULATING...|</color>";
						this.text_fake += "<color=blue>Gennady Zyuganov</color>|";
						this.text_fake += "In the new presidential election, Gennady Zyuganov came to power. His promises were: support of religious freedom, in particular Orthodoxy, honest privatization of unprofitable state-owned enterprises after economic restructuring and increase of social expenses due to this, which should lead to improvement of the people's financial situation.| And he started with the opening of many SEZ in the country, inviting of foreign investors and selling of cheap labour force to them. His reforms also imply the strengthening of market integration of the SSG member states and support for the free movement of capital and labor force across the entire territory of the SSG, and hence the strengthening of ties within the Union. |The next step is the fulfillment of the requirements for the USSR membership in the WTO...|Gorbachev, who after the dissolution of the Emergency Committee again had the opportunity to speak and publish freely, supported Zyuganov's actions and, soon, was even appointed his personal adviser.";
					}
				}
				else if (this.global1.data[45] == 7)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(29);
					}
					this.text_fake = "<color=blue>Viktor Alksnis</color>|";
					this.text_fake += "The Supreme Soviet elected Viktor Alksnis as the new President, as expected, and after he had come to power, he immediately launched a huge campaign against corruption and market machinations, as well as mass persecution of nationalists, including the Baltic nationalists, being himself a Latvian by nationality. The next step was to force the shift of the vector of market reforms to the Chinese analogue of the bird-cage reforms, with the multiple strengthening of state intervention.| The sharp drop in the level of corruption and speculation, the purging of state structures and the transition to more effective methods of economic reforms are already yielding multiple benefits in the form of a rise in the social, economic and spiritual spheres.";
				}
			}
			else if (this.this_okno == 5)
			{
				this.Name.text = "SCIENTIFIC ACHIEVEMENTS";
				this.text_fake = "";
				if (this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && (this.global1.data[0] < 49 || this.global1.data[0] > 51))
				{
					if (((this.global1.data[42] == 2 && this.global1.science[1]) || (this.global1.science[2] && this.global1.data[42] != 7 && this.global1.data[17] != 17)) && !this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						this.text_fake = "We successfully researched and implemented new methods of surveillance of the citizens in order to protect our state. Surveillance cameras, wiretaps and electronic databases for every citizen allow us to know almost everything about people of interest to us. And, although sometimes these measures create inconvenience to the people and some do not like the idea that they are being watched, we would still have to fight against internal and external enemies. Thanks to our system, we can do this as quickly and efficiently as possible without affecting on the innocent.|";
					}
					else if ((this.global1.science[1] && (this.global1.data[14] >= 3 || this.global1.allcountries[this.global1.data[0]].Vyshi)) || this.global1.science[2])
					{
						this.text_fake = "Despite certain progress in the development of methods of surveillance of the population, our further moves towards liberalization forced us to abandon the project. The ideological liberals and reformers, whose values became one of the most important for us, did not want to endure such a violation of human rights, no matter what their goals were. We will have to use other methods of protecting our state from internal and external enemies.|";
					}
					else
					{
						this.text_fake = "|There is no progress in establishing total surveillance.|";
					}
					if ((this.global1.data[43] == 2 && this.global1.science[4]) || (this.global1.science[5] && this.global1.data[43] == 1 && this.global1.data[18] <= 20))
					{
						if (this.global1.data[44] <= 2)
						{
							this.text_fake += "|Based on the research of Glushkov and Kitov, we successfully developed and built OGAS, introducing it into our Gosplan. This centralized system, taking into account our production capabilities, resources and the dynamics of needs, now manages all our enterprises, eradicating the forgery, despite the protests of some conservatives. This allows our economy to rapidly increase its growth rates, and some are already confidently predicting the onset of the future of automated communism.|";
						}
						else
						{
							this.text_fake += "|Based on the research of Glushkov and Kitov, we successfully developed and built OGAS, introducing it into our Gosplan. This centralized system, taking into account our production capabilities, resources and the dynamics of needs, now manages all our enterprises, eradicating the forgery, despite the protests of some conservatives. This allows our economy to rapidly increase its growth rates and keep up with the times in the world military race.|";
						}
					}
					else if ((this.global1.science[4] || this.global1.science[5]) && this.global1.data[43] <= 2)
					{
						this.text_fake += "|Despite some progress in the development of computerization and its introduction into our economy, before the development of OGAS, we have not get around to it . As a result (including those taken under the pressure of conservatives) it was decided to limit the introduction of automated control systems and republican automated control system, which, of course, increased the growth of our economy and helped fight corruption. However, the dreams of cybernetics in the 1950s about building a single centralized automated system capable of eradicating the forgery and ensuring the most effective production still remain a dream.|";
					}
					else if ((this.global1.science[4] || this.global1.science[5]) && this.global1.data[43] > 2)
					{
						this.text_fake += "|Despite the development of computerization and its introduction into our economy, further economic reforms towards the free market have put an end to the construction of OGAS. Separate private companies competing for profit did not need a single centralized system that takes into account our production capabilities, resources and the dynamics of needs. Work on OGAS was curtailed, and it remained a bold dream from the past.|";
					}
					else
					{
						this.text_fake += "|There is no progress in implementation of automation.|";
					}
					if ((this.global1.data[42] != 9 && this.global1.data[42] != 10 && this.global1.data[42] != 6 && this.global1.data[42] != 5 && this.global1.data[42] != 2 && this.global1.science[5] && this.global1.science[7]) || (this.global1.science[8] && this.global1.data[42] != 5 && this.global1.data[42] != 6 && this.global1.data[42] != 2 && ((this.global1.data[42] != 9 && this.global1.data[14] <= 0) || this.global1.data[42] == 9) && this.global1.data[42] != 10))
					{
						this.text_fake += "|We have successfully developed and introduced advanced genetics into our agriculture and medicine. This allowed us to obtain much more harvests, improving the taste and persistence of cultivated products to environmental influences, and fighting more effectively with diseases, helping to determine their origin. Our scientists have endless perspectives, up to the cultivation of artificial organs and products.|";
					}
					else if ((this.global1.science[7] || this.global1.science[8]) && (this.global1.data[42] == 9 || this.global1.data[42] == 2))
					{
						this.text_fake += "|The development of genetics has caused disagreements and fierce arguments in our scientific and party communities. As a result, under the pressure of some scientists, along with conservative public and party figures, new methods of genetics were recognized as pseudoscientific, contradictory to materialism and propagandizing racism and eugenics. New research in genetics soon stalled, some scientists deprived of their degrees, some moved to other areas or were forced to abandon their views on genetics.|";
					}
					else if (this.global1.science[7] || this.global1.science[8])
					{
						this.text_fake += "|The development of genetics has caused great concern among conservative social and political figures and the clergy. As a result, under their pressure, genetics was recognized as contradictory to human nature, tradition and divine plan and was forbidden, as unethical pseudoscience. Studies in this area have been curtailed, forcing scientists to hide their views and reorganize into other areas of science.|";
					}
					else
					{
						this.text_fake += "|There is no progress in development of genetics.|";
					}
				}
				else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					if (this.global1.science[0] && this.global1.science[1] && this.global1.science[7] && (this.global1.data[42] == 2 || (this.global1.data[42] != 7 && this.global1.data[17] != 17)) && !this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						this.text_fake = this.yug1.science_text[41];
					}
					else if (this.global1.science[0] && this.global1.science[1] && this.global1.science[7])
					{
						this.text_fake = this.yug1.science_text[42];
					}
					else
					{
						this.text_fake = this.yug1.science_text[43];
					}
					bool flag = false;
					for (int i = 0; i < this.yug1.gameState.yugcountries.Length; i++)
					{
						if (this.yug1.gameState.yugcountries[i].is_exist && i != this.yug1.gameState.player)
						{
							flag = true;
							break;
						}
					}
					if (this.global1.science[6] && this.global1.science[8] && (this.global1.data[135] > 7 || !flag || this.global1.data[114] != 100))
					{
						this.text_fake += this.yug1.science_text[44];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(79);
						}
					}
					else if (this.global1.science[6] && this.global1.science[8])
					{
						this.text_fake += this.yug1.science_text[45];
					}
					else
					{
						this.text_fake += this.yug1.science_text[46];
					}
				}
				else
				{
					if ((this.global1.data[42] == 2 && this.global1.science[1]) || this.global1.science[2])
					{
						this.text_fake = "Thanks to the pragmatic leadership of the government, the Ministry of Internal Affairs of our country underwent serious reforms, as a result of which it was possible to create a workable police system, which in turn guaranteed the safety and quiet life of our citizens. And successful reforms in the field of intelligence and foreign agents have allowed us to strengthen the influence of our special services on the world stage.|";
					}
					else
					{
						this.text_fake = "|There is no progress.|";
					}
					if (this.global1.science[5])
					{
						this.text_fake += "Over the past few years, our country has been able to increase the pace of economic growth and begin the course towards industrialization. Conducting forced construction of factories allowed us to increase the potential of our economy and markedly strengthened our role in the global world economy. As a result of this, we were able to bridge the gap with more developed countries by starting a rapid movement towards building an industrial society.|";
					}
					else
					{
						this.text_fake += "|There is no progress.|";
					}
					if ((this.global1.data[42] != 9 && this.global1.data[42] != 10 && this.global1.data[42] != 6 && this.global1.data[42] != 5 && this.global1.data[42] != 2 && this.global1.science[5] && this.global1.science[7]) || this.global1.science[8])
					{
						this.text_fake += "|The government of our country managed to carry out successful agrarian reform, which significantly improved agricultural productivity and the technical equipment of agricultural enterprises. The logical result of this was an increase in the production and consumption of food per capita, which had a very positive effect on the standard of living and health of our citizens.|";
					}
					else
					{
						this.text_fake += "|There is no progress.|";
					}
				}
			}
			else if (this.this_okno == 6 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.Name.text = this.yug1.science_text[47];
				bool flag2 = false;
				for (int j = 0; j < this.yug1.gameState.yugcountries.Length; j++)
				{
					if (this.yug1.gameState.yugcountries[j].is_exist && j != this.yug1.gameState.player)
					{
						flag2 = true;
						break;
					}
				}
				if (this.global1.science[9] && (this.global1.data[135] > 7 || !flag2 || this.global1.data[114] != 100))
				{
					this.text_fake = this.yug1.science_text[48];
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(78);
					}
				}
				else if (this.global1.science[9])
				{
					this.text_fake = this.yug1.science_text[49];
				}
				else
				{
					this.text_fake = this.yug1.science_text[50];
				}
			}
			else if (this.this_okno == 6)
			{
				this.Name.text = "NUCLEAR ACHIEVEMENTS";
				this.text_fake = "";
				if (this.global1.science[9] && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[22] > 500)
				{
					this.text_fake = "Seeing how easy it is to reshape the world and understanding the need to protect our sovereignty on our own, we have decided to develop nuclear weapons. Having received technology and raw materials, we successfully completed the development by creating our nuclear weapons, and proudly declared this to the world. This caused quite a stir, but no one could do anything about it. Now any country will reckon with us, and the enemy will think twice before attacking us.|";
				}
				else if (this.global1.science[9] && this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					this.text_fake = "Seeing how easy it is to reshape the world and understanding the need to protect our sovereignty on our own, we have decided to develop nuclear weapons. We received technology and raw materials, but the West, guessing about our plans, did not want to have a competitor. The IAEA commission was sent to us, which discovered our developments. Under world pressure, the pressure of the party apparatus and the dissident movement that raised its head, we had to abandon the military nuclear program, and all our peaceful nuclear facilities are now tightly controlled by the IAEA.|";
				}
				else if (this.global1.science[9])
				{
					this.text_fake = "Seeing how easy it is to reshape the world and understanding the need to protect our sovereignty on our own, we have decided to develop nuclear weapons. We received technology and raw materials, but the West, whose values we so diligently adopted, guessing about our plans, did not want to have a competitor. The IAEA commission was sent to us, which discovered our developments. Under world pressure, unable to resist it because of the freedom we created, we had to abandon the military nuclear program, and all our peaceful nuclear facilities are now tightly controlled by the IAEA.|";
				}
				else
				{
					this.text_fake = "|There is no progress in development of nuclear weapons.";
				}
				if (this.global1.allcountries[10].Stasi)
				{
					if (this.global1.iron_and_blood && !this.global1.science[9] && this.global1.science_time[9] <= 0)
					{
						this.achieves.GetComponent<achievements>().Set(23);
					}
					this.text_fake += "||According to our latest information, the news that the DPRK not only possesses nuclear weapons but actively builds up and tests it, produces longer-range missiles (bragging about the fact that they will soon be able to reach all cities of the world), and also working on the development of hydrogen weapons, plunged the whole world into shock and horror. US President George H.W. Bush has already declared North Korea a global threat, and in South Korea, South Korean-Japanese-American exercises are now being constantly held. The UN demands that the DPRK stop the development of hydrogen weapons and freeze all military nuclear development. North Korea, however, demands the cessation of provocations on the borders and the withdrawal of US military institutions, missiles and missile defense, from the territory of South Korea.|After the denunciation of the peace treaty on the Korean Peninsula, a new tension began again ... But everyone seems to want to avoid a new war.";
				}
			}
			else if (this.this_okno == 7)
			{
				this.Name.text = "SOCIALIST CAMP";
				this.text.text = "";
				for (int k = 2; k < this.global1.allcountries.Length; k++)
				{
					if (this.global1.allcountries[k] != null && k != this.global1.data[0] && k != 8 && k != 7 && k != 21 && k != 12 && k != 15 && k != 37 && k != 31 && k != 45 && k != 48 && k != 49 && k != 50 && k != 51 && k != 17 && k != 39 && k != 24 && k != 32 && k != 25 && (k < 40 || k > 43))
					{
						TextMesh textMesh = this.text;
						textMesh.text = textMesh.text + "<color=brown>" + this.global1.allcountries[k].name + ":</color>";
						if (this.global1.allcountries[k].subideology == 0)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh2 = this.text;
								textMesh2.text += "<color=black> Left nationalism,</color>";
							}
							else
							{
								TextMesh textMesh3 = this.text;
								textMesh3.text += "<color=black> Левый национализм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 1)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh4 = this.text;
								textMesh4.text += "<color=black> National-Bolshevism,</color>";
							}
							else
							{
								TextMesh textMesh5 = this.text;
								textMesh5.text += "<color=black> Национал-большевизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 2)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh6 = this.text;
								textMesh6.text += "<color=black> Pro-market dictatorship,</color>";
							}
							else
							{
								TextMesh textMesh7 = this.text;
								textMesh7.text += "<color=black> Рыночная диктатура,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 3)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh8 = this.text;
								textMesh8.text += "<color=black> Third way,</color>";
							}
							else
							{
								TextMesh textMesh9 = this.text;
								textMesh9.text += "<color=black> Третий путь,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 4)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh10 = this.text;
								textMesh10.text += "<color=purple> Conservative Socialism,</color>";
							}
							else
							{
								TextMesh textMesh11 = this.text;
								textMesh11.text += "<color=purple> Консервативный социализм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 5)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh12 = this.text;
								textMesh12.text += "<color=purple> Trotskyism,</color>";
							}
							else
							{
								TextMesh textMesh13 = this.text;
								textMesh13.text += "<color=purple> Троцкизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 6)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh14 = this.text;
								textMesh14.text += "<color=purple> Maoism,</color>";
							}
							else
							{
								TextMesh textMesh15 = this.text;
								textMesh15.text += "<color=purple> Маоизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 7)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh16 = this.text;
								textMesh16.text += "<color=purple> Antirevisionism,</color>";
							}
							else
							{
								TextMesh textMesh17 = this.text;
								textMesh17.text += "<color=purple> Антиревизионизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 8)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh18 = this.text;
								textMesh18.text += "<color=green> Democratic socialism,</color>";
							}
							else
							{
								TextMesh textMesh19 = this.text;
								textMesh19.text += "<color=green> Демократический социализм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 9)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh20 = this.text;
								textMesh20.text += "<color=green> Left social-democracy,</color>";
							}
							else
							{
								TextMesh textMesh21 = this.text;
								textMesh21.text += "<color=green> Левая социал-демократия,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 10)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh22 = this.text;
								textMesh22.text += "<color=green> Red tory,</color>";
							}
							else
							{
								TextMesh textMesh23 = this.text;
								textMesh23.text += "<color=green> Красный торизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 11)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh24 = this.text;
								textMesh24.text += "<color=green> Political pragmatism,</color>";
							}
							else
							{
								TextMesh textMesh25 = this.text;
								textMesh25.text += "<color=green> Политический прагматизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 12)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh26 = this.text;
								textMesh26.text += "<color=blue> Centrism,</color>";
							}
							else
							{
								TextMesh textMesh27 = this.text;
								textMesh27.text += "<color=blue> Центризм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 13)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh28 = this.text;
								textMesh28.text += "<color=blue> Right social-democracy,</color>";
							}
							else
							{
								TextMesh textMesh29 = this.text;
								textMesh29.text += "<color=blue> Правая социал-демократия,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 14)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh30 = this.text;
								textMesh30.text += "<color=blue> Liberal-conservative,</color>";
							}
							else
							{
								TextMesh textMesh31 = this.text;
								textMesh31.text += "<color=blue> Либерал-консерватизм,</color>";
							}
						}
						else if (this.global1.allcountries[k].subideology == 15)
						{
							if (PlayerPrefs.GetInt("language") == 0)
							{
								TextMesh textMesh32 = this.text;
								textMesh32.text += "<color=blue> Euroatlanticism,</color>";
							}
							else
							{
								TextMesh textMesh33 = this.text;
								textMesh33.text += "<color=blue> Евроатлантизм,</color>";
							}
						}
						if (this.global1.allcountries[k].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							TextMesh textMesh34 = this.text;
							textMesh34.text += "<color=blue> pro-american.</color>\n";
						}
						else if (this.global1.allcountries[k].Vyshi && this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							TextMesh textMesh35 = this.text;
							textMesh35.text += "<color=blue> partner in NATO.</color>\n";
						}
						else if (this.global1.allcountries[k].isOVD && this.global1.allcountries[k].Torg)
						{
							TextMesh textMesh36 = this.text;
							textMesh36.text += "<color=magenta> close ally.</color>\n";
						}
						else if (this.global1.allcountries[k].isOVD)
						{
							TextMesh textMesh37 = this.text;
							textMesh37.text += "<color=purple> friend.</color>\n";
						}
						else if (this.global1.allcountries[k].isSEV)
						{
							TextMesh textMesh38 = this.text;
							textMesh38.text += "<color=teal> economic partner.</color>\n";
						}
						else if (this.global1.allcountries[k].Torg)
						{
							TextMesh textMesh39 = this.text;
							textMesh39.text += "<color=olive> commercial partner.</color>\n";
						}
						else
						{
							TextMesh textMesh40 = this.text;
							textMesh40.text += "<color=black> preserves neutrality.</color>\n";
						}
					}
				}
				this.this_done_done = true;
			}
			else if (this.this_okno == 8)
			{
				this.Name.text = "REPORTS ON THE WORLD";
				this.text_fake = "";
				if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
				{
					if (this.global1.data[59] != 2 && this.global1.allcountries[this.global1.data[0]].isOVD && (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD) && (this.global1.data[54] >= 7 || (this.global1.allcountries[15].isOVD && this.global1.data[54] >= 5)) && !this.global1.allcountries[15].Help)
					{
						this.text_fake = "|<color=purple>Socialist Federal Republic of Yugoslavia</color>|";
						this.text_fake += "The American proposal to intervene in the civil war in <color=purple>Yugoslavia</color> was blocked by some UN Security Council member countries, as a result of which, thanks to our support and support from our military alliance, Milosevic and the Serbian states were able to win in a long and bloody confrontation. Yugoslavia remained unharmed, although finally passing to state capitalism and bourgeois democracy, led by the Socialist Party and Milosevic.";
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(31);
						}
					}
					else if (this.global1.data[54] >= 2 && !this.global1.allcountries[15].Help)
					{
						this.text_fake = "|<color=purple>Federal Republic of Yugoslavia</color>|";
						this.text_fake += "During the civil war in <color=purple>Yugoslavia</color> , Milosevic still had to part with the separatists and stop helping the Serbian fighters for sovereignty. However, while maintaining contact with us and other friend countries of the renovated Yugoslavia, the new state received a lot of assistance, including military assistance, while Milosevic personally received support from our special services during the Bulldozer Revolution and was able to hold on to power, and the Americans did not decided to conduct a deeper intervention . And the war for Kosovo never happened, as well as the NATO bombing - the conflict was suppressed as soon as possible.";
					}
					else
					{
						this.text_fake = "|<color=purple>Breakup of Yugoslavia</color>|";
						this.text_fake += "During the civil war, <color=purple>Yugoslavia</color>  still had to part with its republics and stop provide assistance to Serbian fighters for sovereignty. And then to experience  the terrible bombing of NATO aviation because of the problems in Kosovo, which led to numerous deaths among the civilian population. The next step was the Bulldozer revolution and the fall of the Milosevic regime, and with it the gradual collapse of the rest of Yugoslavia.";
					}
				}
				if (this.global1.event_done[1079] && (this.global1.allcountries[17].Gosstroy == 1 || this.global1.allcountries[7].paths == 3))
				{
					if (this.global1.allcountries[17].Gosstroy == 1)
					{
						this.text_fake += "||<color=purple>Sovereign Federal Republic of Germany</color>";
						this.text_fake += "|The bloc of left-wing parties was able to successfully hold power in Germany throughout the entire 90s. Successful social policies, coupled with the introduction of elements of \"Swedish socialism\", the expansion of trade union rights and support for production in the eastern lands, required large financial investments. In terms of foreign policy, a united Germany began to distance itself from NATO by withdrawing from its political structures. However, tax increases and additional loans hit the middle and upper class seriously, so in the 2000 elections the CDU won 35% of the vote and, together with the liberals, formed a new center-right government headed by Volker Kauder, who promised \"to fight not only left-wing economic ideas, but also left-wing societal ideas\" and also promised \"to defend the sovereignty of Germany \"and called on the United States \"to abandon the behavior of global domination\".";
					}
					else if (this.global1.allcountries[7].paths == 3)
					{
						this.text_fake += "||<color=purple>Vorotnikov's strike on the FRG</color>";
						this.text_fake += "|After the reunification of Germany, the Soviet Union insisted on the revision of a number of treaties, including \"Two plus four\". Soviet Foreign Minister Yuli Vorontsov put forward a note to the Western powers, accusing the FRG of sabotaging the withdrawal of Soviet troops from its territory. At a new international conference, the USSR demanded that the Soviet commission be given control over the withdrawal of troops and put forward a number of the following demands: the FRG leaves NATO and fixes the status of a neutral power in the constitution, all debts are written off to the Soviet Union. In case of failure to comply with these notes, the USSR will cease the withdrawal of troops from the territory of East Germany and transfer control of the area to its administration. In the Western press, a campaign was launched against the USSR with accusations of aggression, but Germany had to retreat and fulfill the requirements in order to remain a whole and sovereign state.";
					}
				}
				else if (this.global1.data[0] == 1 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && ((this.global1.allcountries[17].Westalgie >= 350 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[7].isOVD) || (((this.global1.allcountries[17].Westalgie >= 400 && this.global1.allcountries[16].Gosstroy == 0) || this.global1.allcountries[17].Westalgie >= 450) && this.global1.allcountries[this.global1.data[0]].isSEV && (this.global1.allcountries[17].Westalgie >= 550 || this.global1.allcountries[7].isSEV))))
				{
					this.text_fake += "|<color=purple>Renewed Federal Republic of Germany</color>";
					this.text_fake += "|<color=purple>In Germany </color>, during the reformation of the socialist world, the fall of the veil of the red scare and the flourishing of the idea of world friendship, the coalition of the left forces, which advocated pacifism, social reforms, friendship and peace, won the next election. The result of its victory was not simply the establishment of relations with the GDR and the recognition of West Berlin as a demilitarized zone: the Federal Republic announced its withdrawal from the military structures of NATO, remaining only in the political, and, together with the GDR, withdrew foreign military bases from its territories, signing agreements on the non-presence of troops or missiles on the territory of both Germanies, and on the non-nuclear status of the territories of FRG. This was supported by both the USSR and France, which also approved the speeches of the new German leadership for strengthening economic integration in Western Europe, which, in spite of the dissatisfaction with the new policies of the United Kingdom and the United States, is the formation of the European Union.";
				}
				else if (this.global1.allcountries[1].Gosstroy != 2 && this.global1.allcountries[7].Gosstroy <= 1)
				{
					this.text_fake += "|<color=purple>Federal Republic of Germany</color>";
					this.text_fake += "|After an unsuccessful attempt to <color=purple>unify Germany</color> , Helmut Kohl lost in FRG for the Chancellor's post in 1994. A coalition of Social Democrats and Green headed by Gerhard Schroeder came to power with promises of economic modernization, support of entrepreneurship, preservation of the social protection system and provision of more sovereign foreign policy. The consequence of this was the establishment of more friendly relations with the USSR and a new stage of detente in relations with the GDR.";
				}
				else if (this.global1.allcountries[1].Gosstroy != 2)
				{
					this.text_fake += "|<color=purple>Federal Republic of Germany</color>";
					this.text_fake += "|After an unsuccessful attempt to <color=purple>unify Germany</color> , Helmut Kohl lost in FRG for the Chancellor's post in 1994. A coalition of Social Democrats and Green headed by Gerhard Schroeder came to power with promises of economic modernization, support of entrepreneurship, preservation of the social protection system and provision of more sovereign foreign policy. The consequence of this was the establishment of more friendly relations with the Russia and a new stage of detente in relations with the GDR.";
				}
				else
				{
					this.text_fake += "|<color=purple>United Federal Republic of Germany</color>";
					this.text_fake += "|East Germany collapsed and now <color=purple>the German people became united</color>. However, this did not solve a lot of problems that were as in the GDR, and <color=purple>in FRG</color>. Germany still has a lot to go through.";
				}
			}
			else if (this.this_okno == 9)
			{
				this.Name.text = "REPORTS ON THE WORLD";
				this.text_fake = "";
				this.text_fake = "<color=purple>Greece</color>|";
				if (this.global1.allcountries[45].Gosstroy <= 1 && this.global1.allcountries[45].isSEV && this.global1.allcountries[45].Torg && !this.global1.allcountries[7].isOVD && this.greece_ally > 6)
				{
					this.text_fake += "The ruling Greek coalition of socialists and communists was able to successfully survive the problems of the socialist camp of the late twentieth century and, with our full support, finally take the country out of NATO, announcing its neutrality and the rejection of the deployment of nuclear weapons. Keeping economic contacts with us, Greece continues to be a member of our Economic Alliance, despite proposals to join the newly-formed European Union.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(44);
					}
				}
				else if (this.global1.allcountries[45].Gosstroy <= 1 && this.global1.allcountries[45].isSEV && this.global1.allcountries[45].Torg && !this.global1.allcountries[7].isOVD && this.greece_ally <= 5)
				{
					this.text_fake += "The ruling Greek coalition of socialists and communists was able to successfully survive the problems of the socialist camp of the late twentieth century and, with our full support, finally take the country out of NATO, announcing its neutrality and the rejection of the deployment of nuclear weapons. Despite economic contacts with us, Greece decides to join the European Union under the slogan of an intermediary between East and West. They do not lost connection with us, but still...";
				}
				else if (this.global1.allcountries[45].Gosstroy <= 1)
				{
					this.text_fake += "In the next elections, the Greek coalition of socialists and communists, after a scandal, collapsed, and power in the socialist party passed to the centre-right wing. Despite economic contacts with us, Greece decides to join the European Union under the slogan of an intermediary between East and West. They do not lost connection with us, but still...";
				}
				else
				{
					this.text_fake += "Greece continues to be a member of NATO and begins to take part in the formation of the European Union.";
				}
				if (this.global1.data[37] >= 8 && this.global1.data[0] != 12 && !this.global1.allcountries[7].Vyshi && (this.global1.allcountries[7].isSEV || this.global1.allcountries[16].isSEV || this.global1.allcountries[19].Gosstroy <= 0) && this.global1.allcountries[31].Help)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(22);
					}
					this.text_fake += "||<color=purple>Democratic Republic of Afghanistan</color>";
					this.text_fake += "|Constantly provided by us and the entire socialist bloc, assistance to <color=purple>the Najibullah regime</color>, together with the imposition of harsh sanctions against Pakistan and the condemnation of Pakistani terrorists, even by France and China (after they carried out a series of terrorist attacks around the world) - have become the final turning point in the history of Afghanistan. And Najibullah's reforms, legalizing small private traders, shops and handicrafts, along with the integration of Afghan traditions and religion into state ideology, consolidated the power of socialists in the country. The Civil War is over.";
				}
				else if (this.global1.allcountries[7].Gosstroy <= 1 && this.global1.data[0] != 12)
				{
					this.text_fake += "||<color=purple>Civil War in Afghanistan</color>";
					this.text_fake += "|The Soviet Union continued to exist, providing humanitarian and military support to <color=purple>Afghanistan</color>, which helped alleviate its situation. Some countries, fearing the expansion of Islamic terrorists, began to exert pressure on Pakistan, making it more difficult for the Mujahideen. And with China, the USSR managed to agree and develop a unified position on stopping the support of the Mujahideen. And although disagreements in the PDPA and the DRA army were not settled to the end, and Najibullah's policy had its flaws, the mujahideen succeeded in suppressing the offensive, and the DRA controls enough territories to exist further. There was not a decisive advantage for either side, so the civil war in Afghanistan continues.";
				}
				else if (this.global1.data[0] != 12)
				{
					this.text_fake += "||<color=purple>Islamic State of Afghanistan</color>";
					this.text_fake += "|After the withdrawal of the Soviet troops, the situation of <color=purple>Afghanistan</color> began to deteriorate rapidly - the inconsistent policy of the PDPA, together with disagreements in it and in army leadership, led to the fact that the people began to turn away from the Afghan government, and the army with difficulty restrain the onslaught of the mujahideen. Almost in international isolation, Afghanistan could not get support from outside, and Pakistan continued to send more and more groups of Islamists with impunity. In April 1992, the Mujahideen entered Kabul without a fight, declaring Afghanistan an Islamic state. All the achievements of the Soviet government in the social, economic and legal fields have been destroyed. And four years later Najibullah himself was brutally murdered without trial and investigation.";
				}
			}
			else if (this.this_okno == 10)
			{
				this.Name.text = "REPORTS ON THE WORLD";
				this.text_fake = "";
				this.text_fake = "";
				if (this.global1.allcountries[24].Stasi && this.global1.data[55] >= 2)
				{
					this.text_fake = "<color=purple>Socialist Republic of Yemen</color>";
					this.text_fake += "|During the massive and rapid development of oil production <color=purple>in the PDRY</color>, the country became a new major player in the arena of oil exporters, which resulted in an increase in both our profits and substantial diplomatic, political and economic assistance to allied states that have the same interests with us and PDRY. The world has become stronger. For us.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(33);
					}
				}
				else if (this.global1.allcountries[24].Gosstroy == 0 && this.global1.allcountries[24].Stasi)
				{
					this.text_fake = "<color=purple>People's Democratic Republic of Yemen</color>";
					this.text_fake += "|In the course of mass purges <color=purple>in the PDRY</color>, conservative traditional power was preserved, and only sole traders, cooperatives and small private traders in the service sector, including the opening of several SEZ, were allowed from the reforms. The PDRY remains one of our main allies in the Middle East, at the same time it is trying to start the development of oil production, the deposits of which were discovered with Soviet help by the end of the 1980s, but were not developed because of help end.";
				}
				else
				{
					this.text_fake = "<color=purple>United Republic of Yemen</color>";
					this.text_fake += "|<color=purple>Two Yemen</color> became united in exchange for the allocation of important and major government posts to the leaders of the socialist Yemen regime and the supreme posts of the bourgeois leaders. However, such a shaky coalition did not last long and, after the final loss of the socialist world's influence on this territory, the politics of the former PDRY were kicked out of their posts, and when they tried to start the uprising because of their disappointment, they were persecuted. ";
				}
				this.text_fake += "|";
				if (this.global1.allcountries[21].Gosstroy != 1)
				{
					for (int l = 40; l < 44; l++)
					{
						if (this.global1.allcountries[l].Westalgie >= 1000)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[l].name + "</color>: In the country there was a stabilization. The Left Coalition finally approved its authority throughout the country, forming a socialist government and a socialist republic. The triumph of socialism has come.|";
						}
						else if (this.global1.allcountries[l].Westalgie >= 600)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[l].name + "</color>: There was partial stabilization. The Left coalition was able to take power in the country, having formed the regime of People's Democracy, while the opposition still exists and sows troubles, and its radicalized wing continues to partisan.|";
						}
						else if (this.global1.allcountries[l].Westalgie > 0)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[l].name + "</color>: There was partial stabilization. The Right coalition was able to take power in the country, having formed the regime of the Right Imitation Democracy, while the opposition still exists and sows troubles, and its radicalized wing continues to partisan.|";
						}
						else if (this.global1.allcountries[l].Westalgie <= 0)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[l].name + "</color>: In the country there was a stabilization. The Right coalition finally established its authority throughout the country, forming a liberal-democratic government and a capitalist republic. The triumph of bourgeois democracy has come.|";
						}
					}
				}
				else
				{
					this.text_fake += "The democratic government managed to curb Islamic fundamentalism and prevent a looming crisis. As a result, in <color=purple>Algeria</color> a bipartisan system similar to the Western one has developed, where socialists and democrats play a dominant role. Nevertheless, despite the internal political stabilization, Algeria is becoming more and more dependent on France, which is gradually taking over the country's domestic market with its goods, with which local production cannot compete.|";
					for (int m = 41; m < 44; m++)
					{
						if (this.global1.allcountries[m].Westalgie >= 1000)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[m].name + "</color>: In the country there was a stabilization. The Left Coalition finally approved its authority throughout the country, forming a socialist government and a socialist republic. The triumph of socialism has come.|";
						}
						else if (this.global1.allcountries[m].Westalgie >= 600)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[m].name + "</color>: There was partial stabilization. The Left coalition was able to take power in the country, having formed the regime of People's Democracy, while the opposition still exists and sows troubles, and its radicalized wing continues to partisan.|";
						}
						else if (this.global1.allcountries[m].Westalgie > 0)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[m].name + "</color>: There was partial stabilization. The Right coalition was able to take power in the country, having formed the regime of the Right Imitation Democracy, while the opposition still exists and sows troubles, and its radicalized wing continues to partisan.|";
						}
						else if (this.global1.allcountries[m].Westalgie <= 0)
						{
							this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[m].name + "</color>: In the country there was a stabilization. The Right coalition finally established its authority throughout the country, forming a liberal-democratic government and a capitalist republic. The triumph of bourgeois democracy has come.|";
						}
					}
				}
			}
			else if (this.this_okno == 11)
			{
				this.Name.text = "COMMONWEALTH";
				this.text_fake = "";
				if (this.global1.allcountries[7].isSEV && this.global1.allcountries[7].isOVD)
				{
					this.text_fake = "|<color=purple>Soviet leadership</color>";
					this.text_fake += "|The Soviet Union continues to be the informal leader of a more reformed socialist camp, leading all its members to a brighter future.";
				}
				else if (!this.global1.allcountries[7].isOVD && this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					this.text_fake = "|<color=purple>New Neighbors</color>";
					this.text_fake += "|After the Soviet Union renounced the Brezhnev doctrine and allowed us to make our choice, our government decided to integrate with western neighbors. And now we are a new member of the NATO family and the European Union.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(34);
					}
				}
				else
				{
					if (!this.global1.allcountries[7].isOVD)
					{
						this.text_fake = "|<color=purple>Military agreement</color>";
						this.text_fake = this.text_fake + "|Total: " + this.military_ally.ToString();
						if (this.military_ally <= 2)
						{
							this.text_fake += " (small)|With the fall of the Warsaw Pact, we became more defenseless, and although we tried to put together our own military alliance, we should admit that it turned out badly. Our influence in the world remained about as small as it was before the Warsaw Pact was broken.";
						}
						else if (this.military_ally <= 5)
						{
							this.text_fake += " (medium)|With the fall of the Warsaw Pact, we became more defenseless, and although we tried to put together our own military alliance, we should admit that it was much better than it could be. Our influence in the world has greatly expanded after the break of the Warsaw Pact and a new, albeit small, but strong bloc of countries is ready to defend us and each other.";
						}
						else
						{
							this.text_fake += " (large)|With the fall of the Warsaw Pact, we have become more defenseless, but our attempts to put together our own military alliance, it is worth acknowledging, exceeded the expectations of even the most optimistic of our party members. Thanks to our actions, we were able to become one of the new powerful world powers with which other countries begin to reckon.";
						}
					}
					else
					{
						this.text_fake = "|<color=purple>Military agreement</color>";
						this.text_fake += "|The Soviet Union continues to be the informal leader of a more reformed socialist camp, leading all its members to a brighter future.";
					}
					if (!this.global1.allcountries[7].isSEV)
					{
						this.text_fake += "|<color=purple>Economic alliance</color>";
						this.text_fake = this.text_fake + "|Total: " + this.economy_ally.ToString();
						if (this.economy_ally <= 4)
						{
							this.text_fake += " (small)|With the dissolution of the Council for Mutual Economic Assistance, we lost many trading partners, and, unfortunately, our trade was never able to recover from such a vile blow from the Soviet Union, and from CMEA remained only its pale shadow.";
						}
						else if (this.economy_ally <= 7)
						{
							this.text_fake += " (medium)|With the dissolution of the Council for Mutual Economic Assistance we lost many trading partners, however, we managed to recover from such a vile blow from the Soviet Union and restore our trade ties, forming a strong alternative to the CMEA.";
						}
						else
						{
							this.text_fake += " (large)|With the dissolution of the Council for Mutual Economic Assistance we lost many trading partners, however, we managed not only to recover from such a vile blow from the Soviet Union, but also to expand our trade ties, gaining more and more economic partners, forming an equally broad and strong alternative to CMEA .";
						}
					}
					else
					{
						this.text_fake += "|<color=purple>Economic alliance</color>";
						this.text_fake += "|The Council for Mutual Economic Assistance, despite stopping the provision of benefits and assistance from the Soviet Union, thanks to decades of strong economic ties, was able to reform and retain its niche in the global economic system, remaining the same alternative to the Western commonwealth.";
					}
				}
				if (this.global1.data[59] == 1 && this.global1.data[0] == 5 && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[42] != 7)
				{
					this.text_fake += "||The Soviet Union collapsed, after which Transnistria solidified its own sovereignty and declared itself to be a real Moldavia. An armed conflict broke out, in which we hastened to intervene - after striking the unsuspecting Moldovans in the rear, we quickly seized the key cities and coordinated our actions with the Gagauz, Transnistrians and Russian volunteers. Under the close supervision of Securitate, the referendum in Moldova approved by an overwhelming majority of votes the entry of Moldova into Romania, Transnistria was recognized as a true Moldova, Gagauzia gained independence and they became our friends, and former Moldovans were declared Bessarabian Romanians. Soon all our allies recognized this, despite protests from the West, while Russia did not care.";
					if (this.global1.iron_and_blood && this.global1.data[60] == 6)
					{
						this.achieves.GetComponent<achievements>().Set(39);
					}
				}
				else if (this.global1.data[59] == 1 && this.global1.data[0] == 5)
				{
					this.text_fake += "||The Soviet Union collapsed, after which Transnistria solidified its own sovereignty and declared itself to be a real Moldavia. An armed conflict broke out, in which we hastened to intervene - after striking the unsuspecting Moldovans in the rear, we quickly seized the key cities and coordinated our actions with the Gagauz, Transnistrians and Russian volunteers. However, soon, under pressure from the international community, we were forced to withdraw troops from Moldova, guaranteeing its sovereignty. Well, at least Gagauzia and Transnistria have gained independence and become our loyal friends-allies.";
				}
			}
			else if (this.this_okno == 12 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.Name.text = "SPECIAL RESULT";
				this.text_fake = "";
				if (this.global1.data[135] <= 4)
				{
					this.global1.data[161] = 0;
				}
				else if (this.global1.data[131] != 1 && this.yug1.gameState.modifies[5] <= 0 && this.yug1.gameState.modifies[4] <= 0)
				{
					if (this.global1.data[126] == 0 && this.global1.data[115] <= 4)
					{
						this.global1.data[161] = 0;
					}
					else if (this.global1.data[126] == 0 && (this.global1.data[126] != 0 || this.global1.data[115] < 16))
					{
						this.global1.data[161] = 0;
					}
				}
				if (this.global1.data[161] == 4 && this.global1.data[114] != 100)
				{
					if (this.global1.allcountries[7].isOVD && this.global1.event_done[62])
					{
						this.text_fake = this.dlce1.credits_text[220];
						this.text_fake += this.dlce1.credits_text[229];
					}
					else if ((this.global1.allcountries[15].Gosstroy == 0 && this.global1.allcountries[6].Gosstroy != 2 && this.global1.allcountries[5].Gosstroy != 2 && this.global1.allcountries[4].Gosstroy != 2 && this.global1.allcountries[3].Gosstroy != 2 && this.global1.allcountries[2].Gosstroy != 2 && this.global1.allcountries[7].Gosstroy == 2 && this.global1.data[148] != 1 && this.global1.data[0] == 49) || (this.global1.data[136] != 1 && this.global1.data[0] == 50) || (this.global1.data[118] != 1 && this.global1.data[0] == 51))
					{
						this.text_fake = this.dlce1.credits_text[221];
						this.text_fake += this.dlce1.credits_text[230];
					}
					else if ((this.global1.allcountries[15].Gosstroy == 9 && this.global1.allcountries[6].Gosstroy != 2 && this.global1.allcountries[5].Gosstroy != 2 && this.global1.allcountries[4].Gosstroy != 2 && this.global1.allcountries[3].Gosstroy != 2 && this.global1.allcountries[2].Gosstroy != 2 && this.global1.allcountries[7].Gosstroy == 2 && this.global1.data[148] == 1 && this.global1.data[0] == 49) || (this.global1.data[136] == 1 && this.global1.data[0] == 50) || (this.global1.data[118] == 1 && this.global1.data[0] == 51))
					{
						this.text_fake = this.dlce1.credits_text[222];
						this.text_fake += this.dlce1.credits_text[231];
					}
					else if (this.global1.allcountries[15].Gosstroy == 2 && this.global1.allcountries[6].Gosstroy != 0 && this.global1.allcountries[5].Gosstroy != 0 && this.global1.allcountries[4].Gosstroy != 0 && this.global1.allcountries[3].Gosstroy != 0 && this.global1.allcountries[2].Gosstroy != 0 && this.global1.allcountries[6].isSEV && this.global1.allcountries[5].isSEV && this.global1.allcountries[4].isSEV && this.global1.allcountries[3].isSEV && this.global1.allcountries[2].isSEV && this.global1.allcountries[7].Gosstroy == 2 && !this.global1.allcountries[7].isSEV)
					{
						this.text_fake = this.dlce1.credits_text[223];
						this.text_fake += this.dlce1.credits_text[232];
					}
					else if (this.global1.allcountries[15].Gosstroy == 2 && this.global1.allcountries[7].Gosstroy == 2)
					{
						this.text_fake = this.dlce1.credits_text[224];
						this.text_fake += this.dlce1.credits_text[233];
					}
					else if (this.global1.allcountries[6].isSEV && this.global1.allcountries[5].isSEV && this.global1.allcountries[4].isSEV && this.global1.allcountries[3].isSEV && this.global1.allcountries[2].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)
					{
						this.text_fake = this.dlce1.credits_text[225];
						this.text_fake += this.dlce1.credits_text[234];
					}
					else if (this.global1.allcountries[15].isSEV && !this.global1.allcountries[7].isSEV)
					{
						this.text_fake = this.dlce1.credits_text[226];
						this.text_fake += this.dlce1.credits_text[235];
					}
				}
				else if (this.yug1.gameState.yugcountries[0].is_independent && this.yug1.gameState.yugcountries[1].is_independent && this.global1.data[126] == 1 && this.global1.data[161] == 1 && this.global1.allcountries[45].Gosstroy < 2)
				{
					this.text_fake = this.dlce1.credits_text[227];
					this.text_fake += this.dlce1.credits_text[236];
				}
				else if (this.global1.data[161] == 1)
				{
					this.text_fake = this.dlce1.credits_text[117];
					this.text_fake += this.dlce1.credits_text[118];
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(80);
					}
				}
				else
				{
					this.text_fake = "Nothing special";
				}
			}
			else if (this.this_okno == 12)
			{
				this.Name.text = "SPECIAL RESULT";
				this.text_fake = "";
				if (!this.global1.science[9] && this.global1.data[0] == 1 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && (this.global1.data[14] == 3 || (this.global1.data[14] == 2 && this.global1.data[15] >= 8 && this.global1.data[17] >= 16) || (this.global1.data[14] == 4 && this.global1.data[16] <= 12)) && ((this.global1.allcountries[17].Westalgie >= 300 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.data[0] == 1 && this.global1.allcountries[7].isOVD && !this.global1.is_gkchp) || (((this.global1.allcountries[17].Westalgie >= 350 && this.global1.allcountries[16].Gosstroy == 0) || this.global1.allcountries[17].Westalgie >= 400) && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.data[0] == 1 && (this.global1.allcountries[17].Westalgie >= 550 || (this.global1.allcountries[7].isSEV && !this.global1.is_gkchp)))))
				{
					this.text_fake += "||<color=purple>Renewed United Germany</color>";
					this.text_fake += "|<color=purple>In the FRG</color>, during the reformation of the socialist world, the fall of the veil of the red scare and the flourishing of the idea of ​​world friendship, the coalition of the left forces, which advocated pacifism, social reforms, friendship and peace, won the next election. The result of its victory was not simply the establishment of relations with the GDR and the recognition of West Berlin as a demilitarized zone: the Federal Republic announced its withdrawal from the military structures of NATO, remaining only in the political, and, together with the GDR, withdrew foreign military bases from its territories, signing agreements on the non-presence of troops or missiles on the territory of both Germanies, and on the non-nuclear status of the territories of FRG.This was supported by both the USSR and France, but the further was a complete surprise - a referendum was held in FRG on the reunification of the FRG and the GDR into a single GDR with the preservation of the non-aligned status and recognition of neutrality, after which the former left-wing functionaries of the FRG entered the government of the GDR, and the Chancellor of Germany became Chairman Council of Ministers of New Germany.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(32);
					}
				}
				if (this.global1.data[0] == 20 && this.global1.data[56] >= 100)
				{
					if (this.global1.data[11] == 0)
					{
						this.text_fake += "||<color=purple>Center of the Islamic Socialism";
						this.text_fake += "|</color>Nedzhmie Hoxha became the first woman leader of a religious state in history, vividly showing the entire progressiveness of Islamic socialism, which combines the best of the teachings of the founders of the Muslim religion and the achievements of the most humane and just of all possible systems that the world has ever seen - socialism. Religion and ideology united, ending their animosities and thereby proving that the desire for peace and prosperity is part of human nature. Imams and zealous preachers do not allow corruption to grow, and the people find solace in the religion or ideology of the party that has come close to its people. ";
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(52);
						}
					}
					else if (this.global1.data[11] == 2)
					{
						this.text_fake += "||<color=purple>Islamic Republic of Albania";
						this.text_fake += "|</color>Perestroika in Albania followed the path of Iran. The internal political consequences of the revolution were manifested in the establishment of the theocratic regime of the Muslim clergy in the country and the increasing role of Islam absolutely in all spheres of life. The country was headed by the President, bourgeois democracy was established and civil liberties were expanded, but religious leaders received special rights. For example, they can collectively veto any law of secular power or submit their own bill, which the secular authorities must adopt. Reliance on religion allowed the APT to reborn and survive a severe crisis, opening the country to the whole world. Warm relations were established with Turkey, Arab countries and Iran. Let life by the laws of Shari'ah restrict the rights of citizens and nations, but this is much better than complete isolation, and the new friends of Albania are glad to welcome it in the ranks of countries that carry the word of Islam to this world. ";
					}
					if (this.global1.iron_and_blood && this.global1.data[62] > 4)
					{
					}
				}
				else if (this.global1.data[0] == 18)
				{
					if (this.global1.iron_and_blood && this.global1.data[14] <= 3 && this.global1.data[11] == 2 && this.global1.allcountries[44].Torg && this.global1.allcountries[44].Gosstroy <= 1)
					{
						this.achieves.GetComponent<achievements>().Set(62);
					}
					if (this.global1.allcountries[7].Gosstroy == 0 && this.global1.data[10] >= 800 && this.global1.data[14] <= 1 && this.global1.regions[1].buildings[0].type == 23)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(61);
						}
						this.text_fake += "||<color=purple>Second Caribbean Crisis";
						this.text_fake += "|</color>Viktor Alksnis managed to crush separatism in the Soviet republics and prevent the collapse of the socialist camp. However, after the end of the arms race and the Cold War, relations between the two countries again escalated. Alksnis' tough policy towards the Eastern Bloc countries led to retaliatory measures from the United States, which, in turn, began a program of enhanced re-equipment of missile launchers in Western countries, which particularly affected Germany and Turkey. US President George H.W. Bush demanded that the Soviet Union immediately withdraw troops from the territory of the Warsaw Pact countries, and also threatened military intervention to \"restore democracy\". The response of the USSR came not long after: Soviet secret missiles arrived in Cuba under the guise of convoys with food aid. After some time, the American reconnaissance aircraft, despite the strict secrecy of the entire event, found military personnel who were installing these missiles near the Soviet military base. The new Caribbean crisis once again hung over the world, but this time the situation was much more serious. However, in the end, George H.W. Bush had to make concessions, stopping militarization and exercises in NATO countries, and the USSR again withdrew its missiles from Cuba. The start date of the Third World War was again postponed, but for how long?";
					}
					else if (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.data[77] > 0)
					{
						this.text_fake += "||<color=purple>Island of socialism";
						this.text_fake += "|</color>Cuba became a complete socialist orphan in Latin America after collapse of the Soviet Union. In 1992 the United States of America had become the hegemon of world politics, started pushing its ”democratic” policy and seriously tightened their sanctions against us. Cuba greatly suffered the loss of fraternal allied countries, but it managed to survive in hostile surroundings and continue to develop in the new XXI century, with support of the military officer Hugo Chavez, who won the venezuelan elections, and bolivian socialist Evo Morales, thus giving lots of problems to the USA.";
					}
					else if ((this.global1.allcountries[7].isSEV || this.global1.allcountries[7].isOVD) && (this.global1.data[77] > 0 || this.global1.is_gkchp))
					{
						this.text_fake += "||<color=purple>Front line";
						this.text_fake += "|</color>Socialist camp continues to exist and cooperate with Cuba, whereby the economic crisis passed in a lighter form and american attempts to tighten sanctions against Cuba were condemned by the eastern block and the United Nations. Cuban revolution continues. Viva Cuba!";
					}
					else if (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.data[77] == 0)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(60);
						}
						this.text_fake += "||<color=purple>Restoration";
						this.text_fake += "|</color>Due to worsening situation in the socialist camp we had to return to the idea of cooperation with those who we wanted to cooperate with before our friendship with Khruschev – the United States. Thanks to improved relations between our countries, the embargo was lifted and it saved our stagnating economy from complete crash. Now everything came back to its place – Cuba is again a patrimony of the USA, which is visited by crowds of american tourists. Under pressure of President Bush we had to allow american investors in our country. Now in Cuba there is again US monopoly on production of sugar and tabacco, as well as mass spread of brothels and gambling with which our police is having ”viscous struggle”. Some journalists, which we had to arrest due to false accusations against our government, call our leader ”new Batista” and ”traitor of Cuban revolution”, but they are so wrong!  ";
					}
					else if (this.global1.data[45] != 5 && this.global1.data[77] == 0)
					{
						this.text_fake += "||<color=purple>Renovation";
						this.text_fake += "|</color>Socialist camp continues to exist, but under Gorbachev’s pressure we still had to go to negotiations with the United States, in result of which the embargo was lifted. Now a new era has began for our economy - energy crisis eventually ended and development of tourism under tight control of the state allowed us to increase amount of tourists from the whole world, which is only good for us.";
					}
					if (this.global1.data[171] == 100)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(105);
						}
						this.text_fake += "|<color=purple>Caribbean Germany</color>";
						this.text_fake += "|In the future, the existence of the «second» GDR was recognized only by the friendly governments of Hugo Chavez in Venezuela and Evo Morales in Bolivia, as well as other unrecognized states: Eritrea, Western Sahara, Somaliland, Ambazonia, the Mexican Zapatista Autonomous Municipalities, the states of Shan, Kachin and Wa, and some microstates. Western countries are actively hindering our and North Korean attempts to restore the membership of the GDR in the UN. After the death of Erich Honecker, Erich Mielke became the Chairman of the People's Chamber, and after his death, power in micro-Germany passed into the hands of Sigmund Jähn. In 1998, Hurricane Mitch caused major damage to the island (including the bust of Ernst Thalmann), but Jähn was not only able to restore the destruction on his own, but also turned the island into a tourist center where everyone could purchase East German paraphernalia (coins , books, toys, badges, etc.), making it a self-sustaining tourist paradise by 2008. At the same time, East Germans remain faithful to the ideas of Marx and do not stop political activity - it is on the island of Ernst Thalmann that the headquarters of the IMCAWP is located, and its last conference was also held. At the beginning of 2022, the micro GDR managed to achieve observer status at the UN, but still remains a state with partial international legal recognition.";
					}
				}
				else if (this.global1.data[0] == 12)
				{
					if (this.global1.data[106] == 1 && this.global1.data[81] == 0 && !this.global1.allcountries[7].Vyshi)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(66);
						}
						this.text_fake += "||<color=purple>National Reconciliation Policy";
						this.text_fake += "|</color>The DRA government succeeded in negotiating with the «moderate» part of the opposition, and after the completion of the supply of Pakistani weapons, the remaining radical Islamist opposition was defeated and the government successfully entrenched throughout Afghanistan. In 1993, the first general presidential election was held, in which the current leader of the country successfully won. The situation in the country has finally stabilized - a constitution was adopted that enshrined the dominant position of Islam and allowed the use of Sharia, and representatives of the clergy and mujahiddins also entered the new single government. The long-awaited peace has come on Afghan soil.";
					}
					else if (this.global1.data[106] == 1 && this.global1.data[81] == 0 && this.global1.allcountries[7].Vyshi)
					{
						this.text_fake += "||<color=purple>New civil war";
						this.text_fake = this.text_fake + "|</color>The collapse of the socialist camp and the cessation of assistance from the USSR seriously hit our weak economy: in the cities there was a shortage of food and fuel, electricity was not supplied for months. And, despite successful negotiations with the opposition, which ended with the creation of a coalition government, a political crisis erupts in the country, amid the economic crisis. The radical Islamic opposition won the 1993 parliamentary elections, while " + this.global1.politics_name[this.global1.data[11]] + " continues to be president. Attempts by the country's leader to prevent new centers of separatism were unsuccessful, and opposition organizations are again forming in the regions, terrorizing local residents and robbing cities. The country's future is vague, but it seems that a new fratricidal war cannot be avoided.";
					}
					else if ((this.global1.data[80] == 100 && this.global1.data[106] == 0) || (this.global1.data[80] >= 80 && this.global1.data[81] == 0 && !this.global1.allcountries[7].Vyshi && this.global1.data[106] == 0))
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(63);
						}
						this.text_fake += "||<color=purple>Victory of the revolution";
						this.text_fake += "|</color>Thanks to the constant assistance of the socialist camp, as well as the stubborn struggle of the Afghan peoples for freedom and a brighter future for Afghanistan, the opposition was completely defeated and fled to the territory of Pakistan in panic. Peace has finally arrived on Afghan soil, and the power of the socialists in the country has finally stabilized. Civil war is over.";
					}
					else if (this.global1.data[80] >= 40 && this.global1.data[80] <= 80 && !this.global1.allcountries[7].Vyshi && this.global1.data[106] == 0)
					{
						this.text_fake += "||<color=purple>Civil war continues";
						this.text_fake += "|</color>The USSR continued to exist, providing humanitarian and military support to Afghanistan, which helped ease its situation. Some countries, fearing the expansion of Islamic terrorists, began to put pressure on Pakistan, complicating its assistance to terrorists. But we managed to come to an agreement with China and work out a unified position to stop supporting terrorists. And although the disagreements in the party and army of the DRA were not resolved to the end, and the presidentвЂ™s policy had its flaws, the attacks of the terrorists were stopped and the DRA controls enough territories to exist further. None of the parties found a decisive advantage, so the civil war in Afghanistan continues.";
					}
					else if (this.global1.data[80] >= 20 && !this.global1.allcountries[7].Vyshi)
					{
						this.text_fake += "||<color=purple>The last frontier of defense";
						this.text_fake += "|</color>With the withdrawal of Soviet troops from Afghanistan, the situation of the regime began to deteriorate sharply. Some successful government offensives were harshly suppressed by the terrorists who launched a massive counter-offensive. As a result, the opposition moved so deep into the country that it came close to Kabul, but as a result of the courageous feats of the DRA army, was knocked back. Repeated offensive operations were either grandiose victories or terrifying defeats. And, despite the fact that the DRA controls such a small territory, thanks to the support of the USSR, it continues to exist, and the civil war only intensifies over time.";
					}
					else
					{
						this.text_fake += "||<color=purple>Strange war";
						this.text_fake += "|</color>Despite the cessation of aid from the USSR, the Democratic Republic of Afghanistan owns enough territories to continue to exist and partially fend off attacks by the opposition. The forces of terrorists and the government are always approximately equal, which does not allow one of the parties to prevail in the conflict, so the civil war continues and it is not known when it will end. ";
					}
				}
				else if (this.global1.data[0] == 10)
				{
					if (this.global1.data[68] >= 4 && this.global1.data[11] == 3)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(56);
						}
						this.text_fake += "||<color=purple>United Korea";
						this.text_fake += "|</color>Comrade Kim Young Chun pursued a brilliant policy, achieving what his predecessor could not do. Carrying out a course on «De-Kiminization» and the introduction of large-scale economic transformations, he was able to drag the DPRK from the rank of the most closed and centralized states to one of the most influential forces in world politics. Special attention should be paid to his policy regarding South Korea, which recently had been branded as «American puppet» by state propaganda. Now, after a long process of negotiations, a large-scale detente has unfolded on the Korean peninsula: the North has stopped all nuclear weapons development, and American bases have been withdrawn from the South. And now, thanks to his brilliant rule, there is no longer a «shameful border» separating the Korean people, and Korea has become a single confederate state called «The Democratic Confederate Republic of Koryo». And in 2000, in recognition of merit in the cause of peace, the President of the Republic of Korea, Kim Dae-jung and the President of the DPRK, Kim Yong-jung, jointly received the Nobel Peace Prize. Korea is henceforth united and indivisible.";
					}
					else if ((this.global1.data[68] >= 4 && this.global1.data[11] != 3) || (this.global1.data[68] >= 0 && this.global1.data[68] < 4))
					{
						this.text_fake += "||<color=purple>Truce";
						this.text_fake = this.text_fake + "|</color>Comrade " + this.global1.politics_name[this.global1.data[11]] + " was a controversial leader in the history of our country. A bad start in the economy was combined with great breakthroughs in the reunification of the Korean people. On the Korean peninsula, a relaxation of tension was carried out, and the program of families separated during the Korean War was recreated. There have also been several joint teams in some sports competing under the flag of United Korea. Inter-Korean summits take place at some intervals, demonstrating the desire of the Korean people for unity, but the future of a united Korea is still vague.";
					}
					else if ((this.global1.data[68] <= -3 && this.global1.data[11] != 1) || (this.global1.data[68] > -3 && this.global1.data[68] <= -1))
					{
						this.text_fake += "||<color=purple>Cold confrontation";
						this.text_fake += "|</color>Despite our attempts to negotiate with our southern neighbor, it turned out very badly. Any of our joint endeavors was suppressed by the excessive militarization of the North and the excessively reactionary anti-communism of the South. Of course, there is no talk of any military clashes, but the Korean peninsula is still «blowing cold», despite the end of the confrontation between the USSR and the USA. Everything continues to remain, as it was, and even hard to imagine, when the Korean people will again become one, as before.";
					}
					else if (this.global1.data[68] <= -3 && this.global1.data[11] == 1 && this.global1.science[9] && this.global1.allcountries[16].Gosstroy == 0)
					{
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(58);
						}
						this.text_fake += "||<color=purple>Well forgotten old";
						this.text_fake += "|</color>Because of the increased militarization and the aggressive foreign policy of North Korea, The United States of America, with the support of their allies, managed to get their resolution approved by the UN Security Council - to immediately intervene militarily into DPRK, to put an end to the North's  very much independent and unpredictable political course and to prevent a massive military conflict with the South. However, our old ally China helped us again, and effectively saved us, by vetoing the resolution forced thorugh by the American Imperialists and their marionettes. Now after the end of the old Cold War, a new one is brewing, now between America and China. Fear Capitalists, your last hour is nigh!";
					}
					else
					{
						this.text_fake += "||<color=purple>BUG. PLS REPORT ABOUT IT TO DEVS.</color>";
					}
				}
				else if (this.global1.data[0] == 3)
				{
					if (this.global1.data[50] < -5)
					{
						this.text_fake += "||<color=purple>Velvet divorce|</color>";
						this.text_fake = string.Concat(new string[]
						{
							this.text_fake,
							"As the situation in Czechoslovakia destabilized, the question arose of the national self-determination of the its republics. In general, despite a clear change in the political and economic course of the country, the majority of the population, both Czechs and Slovaks, were not ready for national self-determination, which was confirmed by the results of a survey conducted at that time. However, the fate of the country was in the hands of politicians who thought otherwise. Individual residents of the border areas on both sides of the new border had a negative attitude towards the division of the country. July 17 of the year ",
							(this.global1.data[21] + 1 + (8 + this.global1.data[50])).ToString(),
							" the Slovak parliament adopted a declaration of independence. The Czechoslovak President, who opposed the division, resigned. On November 25, the Federal Assembly adopted a law on the division of the country on January 1 ",
							(this.global1.data[21] + 2 + (8 + this.global1.data[50])).ToString(),
							". Velvet divorce has occured."
						});
					}
					else if (this.global1.data[50] < -2)
					{
						this.text_fake += "||<color=purple>State Union of the Czech Republic and Slovakia|</color>";
						this.text_fake += "We have given enough freedoms to the Slovaks. Despite the increased nationalism throughout the socialist camp, we were able to maintain a delicate balance in our country. From now on Czechoslovakia is becoming a confederation. Bratislava and Prague divided the responsibilities of government, reconciling the nationalists of both countries. And let the evil tongues still call us the “Monster of Versailles”, we will do everything for the sake of the prosperity of the Czech and Slovak peoples by the will of fate united in one state.";
					}
					else if (this.global1.data[50] > 5 && this.global1.data[11] != 3)
					{
						this.text_fake += "||<color=purple>One people, one nation!|</color>";
						this.text_fake += "The developed new standart language, which we had to implant in places by force on occasion, gradually became the national language among the people of our country. Nationalists of all kinds were made into resignation and their supporters found themselves behind bars or abroad, where they could not harm us. The “Cultural Exchange” policy introduced over time has allowed the people of our country not only to feel, but also to become one people. And now the Czechoslovak people are indivisible! Forward to a bright future!";
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(54);
						}
					}
					else
					{
						this.text_fake += "||<color=purple>Everything goes as it went.</color>";
					}
					if (this.global1.data[60] == 10)
					{
						this.text_fake += "||<color=purple>Tseshin is one and indivisible!</color>";
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(55);
						}
					}
				}
				else if (this.global1.data[0] == 4)
				{
					if (this.global1.data[11] == 0 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.allcountries[4].isOVD && this.global1.allcountries[4].isSEV && this.global1.data[14] == 0 && this.global1.is_gkchp && this.global1.allcountries[7].Vyshi && this.global1.allcountries[7].Gosstroy == 2 && this.global1.eventVariantChosen[153] >= 2 && this.global1.eventVariantChosen[157] == 3)
					{
						this.text_fake = this.dlce1.credits_text[28];
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(129);
						}
					}
					else if (this.global1.data[62] >= 4 && this.global1.allcountries[15].isOVD && (this.global1.allcountries[6].isOVD || this.global1.allcountries[6].Gosstroy == 0 || this.global1.allcountries[6].Gosstroy == 9) && !this.global1.allcountries[5].Vyshi)
					{
						this.text_fake += "||<color=purple>Confederate North Korea of Europe";
						this.text_fake += "|</color>Taking advantage of the instability in the socialist camp, we were not taken aback, we took control into our own hands. Having lost Transylvania, Romania plunged into anarchy and the valiant Hungarian troops, with the support of the Bulgarians, who took control of their former lands lost in the wars of this century, established a puppet government in Romania. The next step was the insurrection of the Hungarians in Transcarpathia, which, along with the pro-Polish uprisings in the rest of Western Ukraine, destabilized the situation of the Ukrainian government, it resigned, and we entered the State of Ruthenia with our boots, which declared the independence of their lands, which has been occupied by the Ukrainian authorities since 1945. Our help to Milosevic allowed us to keep NATO busy and prolong the conflict in Yugoslavia. Taking advantage of the captured and already available resourses and technologies, a coalition of four countries, including Bulgaria, Romania, Hungary and Yugoslavia has formed. This new confederation was bristled with nuclear weapons and became a kind of confederative North Korea of Europe. Under pressure from the world community, all countries trading with Hungary, except for the faithful three allies, imposed sanctions, but withdrawing into self-isolation with captured territories and several loyal allies allowed the Hungarian state to maintain economic stability and loads of nuclear weapons stopped Kuchma from threats of nuclear cudgel (which he, however, refused to hand over to his fellow Yeltsin). ";
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(51);
						}
					}
					else if (this.global1.data[62] >= 2 && this.global1.allcountries[7].Vyshi)
					{
						this.text_fake += "From the usual and unremarkable European country, Hungary has become a force that cannot be ignored in the region and our ruler has become a symbol of the greatness and power of the Hungarian people. Unfortunately, dizziness from success did not last long. The project to provoke dissatisfaction in Transylvania was crowned with success after a hastily held referendum under the control of our unmarked units. Autonomous region of Transylvania added to the list of our lands. However, NATO did not stand aside and immediately called us an aggressor, leading troops to our borders. Following NATO, Kuchma and Yeltsin, emboldened, joined forces and began to threaten us with their nuclear clubs. ";
						if (this.global1.data[16] > 11 || this.global1.allcountries[4].Vyshi)
						{
							this.text_fake += " We had to retreat and loose all our gains and only because we opened to foreign capitals and became a new market for Western partners, we were allowed to remain sovereign. Transylvania was declared a demilitarized zone, and among the Hungarians ultra-right views are growing in numbers and social-nationalist movements are being created and strengthened in our lands, eager for revenge.";
						}
						else
						{
							this.text_fake += " We had to retreat from our conquests, and only because we firmly held the power and fought off the first attempts of the offensive by international forces and found scapegoats for the international community, we were allowed to remain sovereign. The 30-kilometer borders with Transcarpathia and Transylvania from our territory were declared a demilitarized zone, and among the Hungarians ultra-right views are growing in numbers and social-nationalist movements are being created and strengthened in our lands, eager for revenge.";
						}
					}
					else if (this.global1.data[62] >= 2 && this.global1.regions[2].buildings[0].type == 19)
					{
						this.text_fake += "From the usual and unremarkable European country, Hungary has become a force that cannot be ignored in the region and our ruler has become a symbol of the greatness and power of the Hungarian people. Unfortunately, dizziness from success did not last long. The project to ingnite dissatisfaction in Transylvania was crowned with success after a hastily held referendum under the control of our unmarked units. Autonomous region of Transylvania added to the list of our lands. However, NATO did not stand aside and immediately called us an aggressor, leading troops to our borders. Following NATO, the Soviet Union, emboldened, began to threaten us with its nuclear cudgel. ";
						if (this.global1.data[16] > 11 || this.global1.allcountries[4].Vyshi)
						{
							this.text_fake += " We had to retreat and loose all our gains and only because we opened to foreign capitals and became a new market for Western partners, we were allowed to remain sovereign. Transylvania was declared a demilitarized zone, and among the Hungarians ultra-right views are growing in numbers and social-nationalist movements are being created and strengthened in our lands, eager for revenge.";
						}
						else
						{
							this.text_fake += " We had to retreat from our conquests, and only because we firmly held the power and fought off the first attempts of the offensive by international forces and found scapegoats for the international community, we were allowed to remain sovereign. The 30-kilometer borders with Transcarpathia and Transylvania from our territory were declared a demilitarized zone, and among the Hungarians ultra-right views are growing in numbers and social-nationalist movements are being created and strengthened in our lands, eager for revenge.";
						}
					}
					else
					{
						this.text_fake = "Nothing special";
					}
				}
				else if (!this.global1.science[9] && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && this.global1.data[0] == 1 && (this.global1.data[14] == 3 || (this.global1.data[14] == 2 && this.global1.data[15] >= 8 && this.global1.data[17] >= 16) || (this.global1.data[14] == 4 && this.global1.data[16] <= 12)) && ((this.global1.allcountries[17].Westalgie >= 300 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.data[0] == 1 && this.global1.allcountries[7].isOVD && !this.global1.is_gkchp) || (((this.global1.allcountries[17].Westalgie >= 350 && this.global1.allcountries[16].Gosstroy == 0) || this.global1.allcountries[17].Westalgie >= 400) && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.data[0] == 1 && (this.global1.allcountries[17].Westalgie >= 550 || (this.global1.allcountries[7].isSEV && !this.global1.is_gkchp)))))
				{
					this.text_fake += "||<color=purple>Renewal United Germany</color>";
					this.text_fake += "|<color=purple>In the FRG</color>, in the course of the reformation of the socialist world, the fall of the veil of the red threat and the flourishing of the idea of ​​world friendship, a coalition of left-wing forces, advocating pacifism, social reforms, friendship and peace, won the next elections. The consequence of their victory was not just an establishment of relations with the GDR and the recognition of West Berlin as a demilitarized zone: the Federal Republic announced its withdrawal from NATO military structures, remaining only in political ones, and, together with the GDR, withdrew foreign military bases from its territories, signing an agreement on not the presence on the territory of both Germany of someone's troops or missiles, and about the nuclear-free status of the FRG. This was supported by both the USSR and France, but what happened next turned out to be a complete surprise - a referendum was held in the FRG on the reunification of the FRG and the GDR into a single GDR with the preservation of non-aligned status and recognition of neutrality, after which the former left functionaries of the FRG entered the government of the GDR, and the Chancellor of the FRG became the Chairman of the Council of Ministers of the new Germany.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(32);
					}
				}
				else if (this.sinochek && this.global1.data[0] == 5)
				{
					if (this.otstavnoysinochek && this.global1.data[50] == 3)
					{
						this.text_fake += "|After Ceausescu's death, his son Nicu was pushed aside from the Party by the bureaucracy, and was confirmed as a professor of physics at the University of Bucharest. However, Nicu always approached to study with laziness and ridiculed education, so it is not surprising that he remained a professor for a short time and was transferred to position of an ordinary teacher to his native lyceum, and then died of cirrhosis due to alcoholism connected with the failures of recent years.";
					}
					else if (this.global1.data[50] == 3)
					{
						this.text_fake += "|After Ceausescu's death, his son Nicu was unanimously elected as the new leader of the Party and the state. However, despite this, he had no experience and for him it was shameful to learn from others. However, all his attempts to reform has failed, as a result of which he began to drink more and spend time at recreational activities, and the power gradually passed into the hands of the party apparatus, which now manages the country behind the screen of Nicu. However, it is in the interests of the party apparatus to continue not to impede the establishment of a monarchical line of continuity of government. More and more nominal every year...";
						if (this.global1.iron_and_blood && this.global1.data[14] <= 0 && this.global1.data[34] == 11)
						{
							this.achieves.GetComponent<achievements>().Set(36);
						}
					}
					else if (this.otstavnoysinochek && this.global1.data[50] == 4)
					{
						this.text_fake += "|After Ceausescu's death, his son Valentin was pushed aside from the Party by the bureaucracy, and was confirmed as director of the Institute of Atomic Physics in Bucharest, where he continues to work until now, without interfering in politics at all. He managed to get a divorce and get married for the second time, but few people care about his fate, and he is happy to work in his favorite field and in prosperity, while the country is ruled by partocrats.";
					}
					else if (this.global1.data[50] == 4)
					{
						this.text_fake += "|After Ceausescu's death, his son Valentin was unanimously elected as the new leader of the Party and the state. Despite the fact that earlier he had little interest in politics, when he came to power, he with zealously began to solve all the problems of the state, because of what he entered into many conflicts with the party functionaries. However, in general, he continued the line of his father Nicolae, relying on long-standing loyalists, but focusing on combating corruption and the development of science.";
						if (this.global1.iron_and_blood && this.global1.data[14] <= 0 && this.global1.data[26] <= 0)
						{
							this.achieves.GetComponent<achievements>().Set(37);
						}
					}
				}
				else if (this.global1.data[42] == 10 && this.global1.data[0] == 5)
				{
					if (this.global1.data[0] == 5 && this.global1.data[11] != 0 && this.global1.data[50] == 1)
					{
						this.text_fake = this.text_fake + "|Our wise leader " + this.global1.politics_name[this.global1.data[11]] + ", when his power was finally established in the country, made a truly wise decision, which pleased the hearts of all patriots: he did not just return the hero King Mihai to the country, he restored the monarchy! The monarch, in the person of the Mihai, became the personification of the unity of our nation, a symbol of our state and a guarantor of eternal stability and preservation of the centuries-old traditions! However, in spite of this, he is endowed with only ceremonial power...";
						if (this.global1.iron_and_blood && this.global1.data[11] == 3)
						{
							this.achieves.GetComponent<achievements>().Set(38);
						}
					}
				}
				else if (this.global1.data[59] == 2 && this.global1.data[0] == 6 && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[42] != 7)
				{
					this.text_fake += "||While civil war was in full swing in Yugoslavia, we successfully introduced troops to Macedonia, where they organized their own referendum and created the Autonomous Region of Vardar after the name of the former times of the Kingdom of the Vardar Banovina, and the existence of the Macedonians themselves was refuted. Separated by the western imperialists, the Bulgarians, who had previously lived in Macedonia, recognized in the very referendum in 76% of voices themselves to be Bulgarian and desired Bulgarian citizenship. The President of Croatia, Tudman, and then the President of Serbia, Milosevic, recognized our sovereignty over Macedonia, and our allies also followed. And although most of the world does not recognize our new territories, but we are established there. I hope that now once and for all.";
					if (this.global1.iron_and_blood && this.global1.data[11] == 1 && this.global1.data[42] == 9 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)
					{
						this.achieves.GetComponent<achievements>().Set(41);
					}
				}
				else if (this.global1.data[59] == 2 && this.global1.data[0] == 6)
				{
					this.text_fake += "||While civil war was in full swing in Yugoslavia, we successfully introduced troops to Macedonia, where they organized their own referendum and created the Autonomous Region of Vardar after the name of the former times of the Kingdom of the Vardar Banovina, and the existence of the Macedonians themselves was refuted. However, such a precedent, not recognized by the West, was the main reason for the refusal of EU and NATO cooperation with us, as a result of which, under the pressure of the world community, we were forced to hold a repeated referendum where 3/4 of the Macedonian population voted for their own independence, which they received. And we got our ticket to a civilized Europe.";
				}
				else if (this.global1.data[59] == 4 && this.global1.data[0] == 6)
				{
					this.text_fake += "||Milosevic provided substantial assistance with armament, food and finance, together with Albania, we were able to settle the Albanian question peacefully: some Albanians left for Albania, and some settled in the Republic of Kosovo, which became part of the federal Yugoslavia. Then, together with the Albanians, our special services and special forces secretly took part in the war on the side of Milosevic, our allies also joined in. And before the USA ultimatums reached the UN rostrum, the war in Yugoslavia was over - quickly and decisively. Separatists were brought to trial, and their leaders were executed on air. And then, once and for all, the three countries, Yugoslavia, Albania and Bulgaria, merged into a single federation.";
					if (this.global1.data[14] > 2)
					{
						this.text_fake = this.text_fake + "|The country was headed by the federal parliament and the federal government under the leadership of the All-Union Socialist Party of Balkans, although the republican socialist parties survived. The President and General Secretary of the VSPB of the new federation became " + this.global1.politics_name[this.global1.data[11]] + ", Milosevic became Prime Minister (with retaining the powers of Vice-President), and Ramiz Alia became SPieckr of the Parliament and 2 Secretary of the VSPB. Despite the principles of preserving the ideals of socialism, the new Balkan Union State allowed for pluralism of opinions and private business in the country, although the All-Balkan Socialist Party remains the leading force in governing the country, and the state is the leading force in the economy itself.";
					}
					else if (this.global1.data[16] > 11)
					{
						this.text_fake = this.text_fake + "|The country was headed by the federal Supreme Soviet and the federal government under the leadership of the All-Union Communist Party of Balkans, although the republican communist parties survived. The Chairman of the State Council and the General Secretary of the VKPB of the new federation became " + this.global1.politics_name[this.global1.data[11]] + ", Milosevic became Chairman of the Council of Ministers, and Ramiz Alia became the Chairman of the Supreme Council and the 2nd Secretary of the VKPB. Despite the principles of preserving the ideals of socialism, the new Balkan Union State allowed the operation of frequent business in the country and the leadership of the principles of economic accounting, although the state still remains the leading force in the economy itself.";
					}
					else
					{
						this.text_fake = this.text_fake + "|The country was headed by the federal Supreme Soviet and the federal government under the leadership of the All-Union Communist Party of Balkans, although the republican communist parties survived. The Chairman of the State Council and the General Secretary of the VKPB of the new federation became " + this.global1.politics_name[this.global1.data[11]] + ", Milosevic became Chairman of the Council of Ministers, and Ramiz Alia became the Chairman of the Presidium of the Supreme Council and the 2nd Secretary of the VKPB. Despite the old Milosevic and Alia attempts to reform in sovereign Yugoslavia and Albania, which took place several years ago, all the principles of Marxism-Leninism in the leadership of the country and in the management of the economy are preserved and absolutely guarded in the new Balkan Socialist Union State.";
						if (this.global1.iron_and_blood && this.global1.data[11] == 0 && this.global1.data[50] == 9)
						{
							this.achieves.GetComponent<achievements>().Set(40);
						}
					}
				}
				else if (this.global1.data[0] == 6 && this.global1.data[130] == 100)
				{
					if (this.global1.data[16] <= 11)
					{
						this.text_fake += "|The General Secretary managed to combine conflicting ideas into a single whole - monarchical socialism! The tsar, as before, is the symbol of the nation and the guarantor of the stability and prosperity of the country, and the well-being of the population is ensured by the people's socialist state. On the other hand, former allies condemn us for perverting Marxist teachings, while the West accuses us of chauvinism.";
					}
					else
					{
						this.text_fake += "|We have returned Bulgaria to its historical face. The tsar is again the guarantor of stability and prosperity in the country, and communism is out of the question. Simeon II proudly announced the creation of the Fourth Bulgarian Kingdom, in which the principles of the Constitutional Monarchy and People's Democracy are strictly guarded. And all this despite the fact that the former allies now do not want to have anything to do with us. But do we really need them?";
					}
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(68);
					}
				}
				else if (this.global1.data[0] == 2 && (this.global1.data[50] == 20 || this.global1.data[60] <= -10))
				{
					if (this.global1.data[50] == 20)
					{
						this.text_fake = string.Concat(new string[]
						{
							"In ",
							(this.global1.data[21] + 1).ToString(),
							", we proudly opened our cosmodrome and launched the first domestic satellite! After 5 years, in ",
							(this.global1.data[21] + 6).ToString(),
							", we successfully launched the animals into space and their return passed without problems. In ",
							(this.global1.data[21] + 8).ToString(),
							" our shuttles, based on Soviet models (including those bought from the USSR \"Buran\"), first entered the international market and for several years we became the leader of their supplies. Now we are already full members of the ISS project and own our own segment of the station. Now every Pole proudly can say that Poland can into space!|"
						});
						if (this.global1.iron_and_blood)
						{
							this.achieves.GetComponent<achievements>().Set(46);
						}
					}
					if (this.global1.data[60] <= -10)
					{
						if (!this.global1.allcountries[7].Vyshi)
						{
							this.text_fake += "After the failure of the State Committee on the State of Emergency, we decided to organize the Prometheus Project, reworking an old version of the interwar period, which was aimed at dismembering the USSR by force. First, the renewed Prometheus seemed to be a successful project for us, but then, after Yeltsin's defeat, he dragged on: our networks and organizations for a long time on an equal footing fought with the Inter-republican Security Service of the USSR and local nationalists competitive with us. But it all ended with the coming to power of the new President of the Soviet Union: he paid special attention to the organizations and networks that we controlled, once and for all stoping our Project. And it's time to admit - Prometheus has failed.";
						}
						else if (this.global1.allcountries[7].Vyshi && (this.global1.allcountries[this.global1.data[0]].Vyshi || (!this.global1.science[9] && this.global1.data[50] != 20) || this.military_ally <= 2 || this.economy_ally <= 4))
						{
							this.text_fake += "After the failure of the State Committee on the State of Emergency, we decided to organize the Prometheus Project, reworking an old version of the interwar period, which was aimed at dismembering the USSR by force. We paid special attention to Ukraine, Belarus and Lithuania. In Belarus, everything started and went well: historical societies and nationalist organizations called for a centuries-old historical connection with Poland and soon an agreement was signed on the creation of the Union State of Poland and Belarus, a single economic space with military commitments. But the deepening did not go any further after the Ukrainian nationalists supported by us began to praise the OUN-UPA (responsible for the genocide of the Poles in cooperation with the Nazis during the Second World War), and then, after our outrage, opposed us together with the oligarchs , remembering to the Poles all minor and big grievances. With our help, in Ukraine, a nationalist oligarchic regime has been formed, which is very unfortunate. And all this put an end to our attempts in Lithuania.";
						}
						else if (this.global1.allcountries[7].Vyshi && (this.global1.science[9] || this.global1.data[50] == 20) && this.military_ally > 2 && this.economy_ally > 4)
						{
							if (this.global1.data[14] <= 3 && this.global1.data[16] <= 12)
							{
								this.text_fake += "After the failure of the State Committee on the State of Emergency, we decided to organize the Prometheus Project, reworking an old version of the interwar period, which was aimed at dismembering the USSR by force. We paid special attention to the left-nationalist organizations of Ukraine, Belarus and Lithuania. In Belarus, everything started and went well: historical societies and nationalist organizations called for a centuries-old historical connection with Poland. Everything went well in Ukraine, where people who were tired of oligarchs and yearly poverty, especially a lot of unemployed and young people, responded with joy to the ideas, that we promoted, and social party programs for members. The main supporters of our operation were the national-syndicalists, national-communists and the social-nationalists, who formed a coalition and, during mass rallies and the seizure of the administration buildings, eventually came to power. The next step was the possibility of creating a confederation of our three states in the form of the Socialist Union of Eastern Europe. And the victory of the left-nationalist coalition of Frontas in the elections in Lithuania (of course, with our support). Frontas, while denying the Soviet occupation, claims that Lithuanians were shot by Lithuanian snipers in 1991 (calling Gorbachev to be tried), but is preparing an application for Lithuania's accession to our SUEE, as the fourth member.";
								if (this.global1.iron_and_blood)
								{
									this.achieves.GetComponent<achievements>().Set(45);
								}
							}
							else
							{
								this.text_fake += "After the failure of the State Committee on the State of Emergency, we decided to organize the Prometheus Project, reworking an old version of the interwar period, which was aimed at dismembering the USSR by force. We paid special attention to the right-nationalist organizations of Ukraine, Belarus and Lithuania. In Belarus, everything started and went well: historical societies and nationalist organizations called for a centuries-old historical connection with Poland. Everything went well in Ukraine, where people who were tired of oligarchs and yearly poverty, especially a lot of unemployed and young people, responded with joy to the ideas, that we promoted, and social party programs for members. The main supporters of our operation were national-conservatives, neo-fascists and the social-nationalists who formed a coalition and, during mass rallies and the seizure of administration buildings, eventually came to power. The next step was the possibility of creating a Confederation of Eastern Europe from three of our states. And the victory of the right-nationalist coalition Young Lithuania in the elections in Lithuania (of course, with our support). Young Lithuania, although it tends to revise the sins of Hitler's times and praise the former legionaries of the Lithuanian SS battalions, but is preparing an application for Lithuania's entry into our CEE, as the fourth member.";
								if (this.global1.iron_and_blood)
								{
									this.achieves.GetComponent<achievements>().Set(45);
								}
							}
						}
						else
						{
							this.text_fake += "After the failure of the State Committee on the State of Emergency, we decided to organize the Prometheus Project, reworking an old version of the interwar period, which was aimed at dismembering the USSR by force. We paid special attention to Ukraine, Belarus and Lithuania. In Belarus, everything started and went well: historical societies and nationalist organizations called for a centuries-old historical connection with Poland, but current government started, with the support of Russia, to resist them and this confrontation resulted in the victory of the pro-Russian candidate Alexander Lukashenko. Belarus withdrew to the Russian sphere of influence, which affected badly to Ukraine, where Ukrainian nationalists supported by us began to praise the OUN-UPA (responsible for the genocide of the Poles in cooperation with the Nazis during the Second World War), and then, after our outrage, opposed us together with the oligarchs , remembering to the Poles all minor and big grievances. With our help, in Ukraine, a nationalist oligarchic regime has been formed, which is very unfortunate. And all this put an end to our attempts in Lithuania.";
						}
					}
				}
				else
				{
					this.text_fake = "Nothing special";
				}
				if (this.global1.data[0] == 6 && this.global1.data[50] == 9 && (this.global1.data[42] == 2 || this.global1.data[42] == 4 || this.global1.data[42] == 6 || this.global1.data[42] == 9 || (this.global1.data[42] == 8 && this.global1.data[43] == 2)))
				{
					this.text_fake = this.text_fake + "|After the great " + this.global1.politics_name[this.global1.data[11]] + " died, his body was laid in the Mausoleum, where he is at peace with Dimitrov and now became part of the school program - visiting the memorable places of Bulgarian history.";
				}
			}
			else if (this.this_okno == 13 + plus_max)
			{
				this.Name.text = "TOO LATE";
				this.text_fake = "";
				this.text_fake = "Year: " + this.global1.data[21].ToString() + "|";
				this.text_fake += "1991 year was over a long time ago, but you've decided to play next... And you win!|";
				this.text_fake += "Do you think this is the Greatest achievement? Then try to do the same until 1992 year!|";
			}
		}
		else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.this_okno >= 0 && this.this_okno <= 2)
		{
			this.YugoEndings();
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 0 && this.global1.data[0] != 12)
		{
			this.text_fake = "";
			this.Name.text = "ПОЛИТИЧЕСКАЯ ПОЗИЦИЯ";
			if (this.global1.data[42] == 1)
			{
				if (this.global1.data[0] != 10 && this.global1.data[0] != 18 && this.global1.data[0] != 12)
				{
					this.text_fake = string.Concat(new string[]
					{
						"Благодаря решительным действиям, ",
						this.global1.politics_name[this.global1.data[11]],
						" смог разгромить своих противников и сохранить социалистический строй. А после нашего аналога Культурной революции, пусть и ценой некоторых жертв, ",
						this.global1.politics_name[this.global1.data[11]],
						" окончательно укрепил свою власть.|К сожалению, после его смерти, в ",
						this.global1.party_name[0],
						" начались распри за место главы государстве, в результате которой, на съезде партии, культ личности прошлого правителя был развенчан, а он сам был посмертно осуждён. Была ли тому причиной личная неприязнь или это было необходимостью для удержания власти - кто знает?... Да и это уже не важно, ведь рассказы о кровавых преступлениях предыдущего лидера передаются из поколения в поколение. |В стране произошла оттепель. Началось налаживание более дружественных отношений даже с Западом, а также были даны послабления в сфере плюрализма, культуры и цензуры. Партийные же бюрократы получили защиту от спецслужб и всю полноту власти, стремясь сохранить текущее консервативное положение правления. Возможно, это даже к лучшему..."
					});
				}
				else
				{
					this.text_fake = string.Concat(new string[]
					{
						"Благодаря решительным действиям, ",
						this.global1.politics_name[this.global1.data[11]],
						" смог разгромить своих противников и сохранить социалистический строй. А после нашего аналога Культурной революции, пусть и ценой некоторых жертв, ",
						this.global1.politics_name[this.global1.data[11]],
						" окончательно укрепил свою власть.|После смерти великого руководителя, его сын, заранее выбранный преемником, продолжил дело своего отца – Лидера нации. Однако его попытки что-либо видоизменить в стране были пресечены высшим партийным руководством, и он начал постепенно охладевать к политике, да и к управлению страны, передав это дело в руки Политбюро. Тем самым, его нахождение на должности становиться всё более и более номинальным. Хоть в названии государства и фигурирует слово «республика», но фактически в стране воцарилась новая династия монархов. "
					});
				}
			}
			else if (this.global1.data[42] == 2)
			{
				this.text_fake = "Благодаря вашим решительным действиям, вы смогли разгромить ваших противников, и сохранить социалистический строй. А после Культурной революции, пусть и ценой некоторых жертв, вы окончательно укрепили свою власть. Не захотев повторить судьбу Сталина, вы начали строить собственный культ личности, ставя себя на одно место с Марксом, Энгельсом и прочими теоретиками коммунизма, постепенно формируя свою идеологию. Вашим детищем стала Партия. Полностью обновленная и полностью преданная вам. |К сожалению, вашу жизнь оборвала неизвестная болезнь. Да и болезнь ли?..|Вы, как живая и настоящая личность, больше не нужны Партии, детищу, поглотившего своего создателя. Вы больше не должны были быть просто человеком. Вы должны стать иконой, \"вечным лидером\". |Были существенно урезаны свободомыслие и свобода слова, а также сильно расширен контроль над гражданами. Но это дало свои плоды: теперь наши граждане беззаветно верны Партии, а Партия и есть государство.";
				if (this.global1.data[0] != 10)
				{
					this.text_fake += "|К сожалению, нашу страну все чаще и чаще называют \"европейской КНДР\" - Западные империалисты терпеть не могут нас, впрочем, как и идеалы социализма. Или... Может это все же мы зашли куда-то не туда? ";
				}
				this.text_fake += "|Как бы-то ни было, наша страна продолжает существовать, как и ваш культ. Вы - наш вечный и единственный посмертный президент! Аве вам!|И все-таки, куда мы зашли, и куда нам идти дальше? Вопрос, пожалуй, риторический...";
			}
			else if (this.global1.data[42] == 3)
			{
				this.text_fake = this.global1.politics_name[this.global1.data[11]] + " решительными действиями установил однопартийную демократию во главе с " + this.global1.party_name[0] + ", идеей которой было отмести все контрреволюционные идеи, двигаться к построению марксизма-ленинизма и утвердить ведущую роль демократического централизма и коллективного правления. Однако народ воспринял в штыки текущее правительство погрязшее в бюрократии, «поедающей» честных людей. Граждане травят байки и высмеивает Партию.";
			}
			else if (this.global1.data[42] == 4)
			{
				this.text_fake = this.global1.politics_name[this.global1.data[11]] + " и " + this.global1.party_name[0] + " решительными действиями установили в стране однопартийную демократию, позволяющую отмести все контрреволюционные идеи и двигаться к построению марксизма-ленинизма. Несмотря на некоторые просчёты правителя, народ отнёсся с пониманием к проводимой политике и готов поддерживать и дальше его и Партию. Тем самым в стране утвердилась ведущая роль демократического централизма и коллективного правления.";
			}
			else if (this.global1.data[42] == 5)
			{
				this.text_fake = string.Concat(new string[]
				{
					"Благодаря решительным действиям, ",
					this.global1.politics_name[this.global1.data[11]],
					" смог разгромить своих противников и сохранить власть. К сожалению, со временем, его бдительность ослабла. ",
					this.global1.politics_name[this.global1.data[11]],
					" и не заметил, как в парламенте формируются группы, недовольные его правлением...|И вот, после очередной полемики в парламенте, секретарь нашего достопочтимого лидера принес ему чай, со странным запахом миндаля. ",
					this.global1.politics_name[this.global1.data[11]],
					" даже не успел понять, что это был цианистый калий....|После \"безвременной кончины\" Великого Вождя, власть перешла к другим людям, которые начали медленно сворачивать попытку введения его Культа Личности в стране, а затем просто стирать предыдущего правителя из памяти и истории.| Впрочем, как таковых существенных изменений не произошло, а в экономике же по-прежнему доминирует государство. Хорошо это или плохо - кто знает?.."
				});
			}
			else if (this.global1.data[42] == 6)
			{
				this.text_fake = string.Concat(new string[]
				{
					"Во время падения социалистических режимов по всему миру, ",
					this.global1.politics_name[this.global1.data[11]],
					", боясь за собственную власть, стал лихорадочно искать компромиссы с представителями оппозиции и политическими противниками, параллельно пытаясь угодить и силовым структурам. К сожалению, для сохранения власти, ему также пришлось пойти на поклон к Западным державам...|В итоге, к ",
					(this.global1.data[21] + 3).ToString(),
					" году, страна изменилась до неузнаваемости. Будучи загнанным в угол, ",
					this.global1.politics_name[this.global1.data[11]],
					" отбросил идеалы марксизма-ленинизма. В порыве лихорадочной борьбы за сохранение власти, он провел сверхбыструю либерализацию дипломатической, политической и социальной сферы. Как результат - глобализация, зависимость от иностранных держав и появление коррумпированной бюрократической системы.|В стране установилась мнимая демократия. Все партии, представленные в парламенте, по факту являются лишь марионетками. А власть сейчас вполне крепка и ",
					this.global1.politics_name[this.global1.data[11]],
					" может спокойно может править и дальше. Но возникает вопрос - А надо ли оно вообще?.. "
				});
			}
			else if (this.global1.data[42] == 7)
			{
				this.text_fake = string.Concat(new string[]
				{
					this.global1.politics_name[this.global1.data[11]],
					" был противоречивой фигурой, для одних он навсегда останется \"победителем коммунизма\", а для других всего лишь предателем. На долю ",
					this.global1.party_name[0],
					" выпала трудная миссия победы над прошлым строем, демократизация страны по западному образцу. Время нашего президента навсегда запомнится, как эпоха либерализма, впрочем и консерватиные правые и более радикальные левые оппозиционеры всё еще остро критикуют реформы тех времён. В конце концов пришли президентские выборы, которые выиграла легальная оппозиция, а лидер отправился на покой. Оппозиционеры воспользовались недовольством населения экономической политикой, что-бы прийти к власти, однако по приходу экономика подверглась лишь косметическим реформам. Что привело к тому, что всё еще не потерявшая веса ",
					this.global1.party_name[0],
					" вновь вернулась к власти на следующих выборах.|"
				});
				if (this.global1.data[0] == 1)
				{
					this.text_fake += "Когда ГДР и ФРГ стали так похожи друг на друга, как два брата близнеца, встал вопрос об объединении. Однако полного объединения так и не случилось: осси и весси хоть и были немцами, но годы жизни при разных режимах сделали своё дело. Поэтому объединение запада и востока прошло в виде конфедерации: Германия стала формально единой, таможенные границы исчезли, а армия стала единым бундесвером, но всё равно в остальном на востоке изменения были минимальны, а автономии всех остальных структур довольно значительны. Ничто не сотрясало нового порядка вещей.|";
				}
				this.text_fake = this.text_fake + "Только " + this.global1.politics_name[this.global1.data[11]] + " позже был обвинён в том, что он был внештатным агентом спецслужб старого коммунистического режима, до прихода к власти. Это единственное, что потревожило бывшего президента, который разочаровался в том, что сделали со страной его преемники, но вернуться в политику у него уже не было возможности: времена слишком переменились. А верховный суд его оправдал.";
			}
			else if (this.global1.data[42] == 8 && this.global1.data[43] == 2)
			{
				this.text_fake = this.global1.politics_name[this.global1.data[11]] + " был противоречивой фигурой, для одних он навсегда останется \"совершенным марксистом\", а для других всего лишь предателем. На долю " + this.global1.party_name[0] + " выпала трудная миссия победы над прошлым строем, демократизация страны по западному образцу. Время нашего президента навсегда запомнится, как эпоха расцвета экономики нашей страны, впрочем не многие радикалы будут сметь утверждать, что раньше было лучше. Политика проводимая национальным лидером была поддержана всеми классами на столько, что пост президента он занимал до самой смерти. Толковых противников в стране уже не было, а СМИ до сих пор сравнивают нашего всеми уважаемого президента с самим Рузвельтом!|";
				if (this.global1.data[0] == 1)
				{
					this.text_fake = this.text_fake + "Сам " + this.global1.politics_name[this.global1.data[11]] + " позже был увековечен в памятнике на одном из специально сохранённых участков Берлинской стены.";
				}
			}
			else if (this.global1.data[42] == 8)
			{
				this.text_fake = this.global1.politics_name[this.global1.data[11]] + " был противоречивой фигурой, для одних он навсегда останется \"победителем коммунизма\", а для других всего лишь предателем. На долю " + this.global1.party_name[0] + " выпала трудная миссия победы над прошлым строем, демократизация страны по западному образцу. Время нашего президента навсегда запомнится, как эпоха расцвета экономики нашей страны, впрочем не многие радикалы будут сметь утверждать, что раньше было лучше. Политика проводимая национальным лидером была поддержана всеми классами на столько, что пост президента он занимал до самой смерти. Толковых противников в стране уже не было, а СМИ до сих пор сравнивают нашего всеми уважаемого президента с самим Рузвельтом!|";
				if (this.global1.data[0] == 1)
				{
					this.text_fake = this.text_fake + "Когда ГДР и ФРГ стали так похожи друг на друга, как два брата близнеца, встал вопрос об объединении. Однако полного объединения так и не случилось: осси и весси хоть и были немцами, но годы жизни при разных режимах сделали своё дело. Да и сам " + this.global1.politics_name[this.global1.data[11]] + " при своей жизни оттягивал этот вопрос до последнего. Поэтому объединение запада и востока прошло в виде конфедерации: Германия стала формально единой, таможенные границы исчезли, а армия стала единым бундесвером, но всё равно в остальном на востоке изменения были минимальны, а автономии всех остальных структур довольно значительны. На Востоке даже остался свой собственный Парламент и декоративная Народная гвардия. Ничто не сотрясало нового порядка вещей.|";
				}
				this.text_fake = this.text_fake + "А " + this.global1.politics_name[this.global1.data[11]] + " позже был увековечен в памятнике на одном из специально сохранённых участков Берлинской стены.";
			}
			else if (this.global1.data[42] == 9)
			{
				this.text_fake = "После падения соцлагеря, вы, боясь за собственную власть, заручившись поддержкой гэбистов и армии, начали лихорадочно уничтожать любое инакомыслие в своей стране. После волны репрессий вы попали под первую волну санкций со стороны ООН, после чего страна окончательно ушла в изоляцию и, сократив торговые и дипломатические связи с внешним миром, основала свой еще более железный занавес. |Теперь в вашей стране идеология возведена в ранг религии, а любой инакомыслящий немедленно уничтожается физическим путем. А сама идеология окончательно отделилась от марксизма-ленинизма сформировав новую структуру, с опорой на народные традиции и национальные силы.| После вашей смерти вокруг вас сложили много мистический легенд, сделав чуть ли не богом в новом идеологическо-религиозном Пантеоне, открыв мавзолей и начав отсчёт нового календаря с вашего рождения. А страной стал править ваш сын, дав начало новой династии. ";
			}
			else if (this.global1.data[42] == 10)
			{
				this.text_fake = string.Concat(new string[]
				{
					"Из-за мудрой политики нашего вождя страна выстояла в неспокойные годы. ",
					this.global1.politics_name[this.global1.data[11]],
					" навсегда запомнится как спаситель страны, по крайней мере так напишут в учебниках истории. Несмотря на вопли отдельных \"отщепенцев\", жёсткой рукой спецслужбы, полиция и армия навели свои порядки: были запрещены все оппозиционные СМИ и партии, страна погрязла в ксенофобии и милитаризме, а цензорские комитеты работали без остановок. Голову подняла и Церковь, заключив негласный конкордат с правительством... Однако про это никто не осмеливался говорить вслух. Иногда из-за рубежа шли обвинения в \"фашизации\", впрочем они раз за разом объявлялись лживой пропагандой, конфликт заминался и дипломатические и экономические сношения продолжались. Так лидер ",
					this.global1.party_name[0],
					" правил вплоть до своей скоропостижной смерти от инсульта. После этого страну возглавили его ближайшие сподвижники, которые сразу начали борьбу за власть. Вероятно, когда-нибудь эта коррумпированная военно-бюрократическая система падёт под собственным весом, но будет это очень не скоро."
				});
			}
			if (this.global1.data[0] == 1 && this.global1.data[42] != 8 && this.global1.data[42] != 7 && this.global1.allcountries[this.global1.data[0]].Vyshi && !this.global1.allcountries[7].isOVD)
			{
				this.text_fake = this.text_fake + "Когда ГДР и ФРГ стали так похожи друг на друга, как два брата близнеца, встал вопрос об объединении. Однако полного объединения так и не случилось: осси и весси хоть и были немцами, но годы жизни при разных режимах сделали своё дело. Да и сам " + this.global1.politics_name[this.global1.data[11]] + " при своей жизни оттягивал этот вопрос до последнего. Поэтому объединение запада и востока прошло в виде конфедерации: Германия стала формально единой, таможенные границы исчезли, а армия стала единым бундесвером, но всё равно в остальном на востоке изменения были минимальны, а автономии всех остальных структур довольно значительны. На Востоке даже остался свой собственный Парламент и декоративная Народная гвардия. Ничто не сотрясало нового порядка вещей.";
			}
			else if (this.global1.eventVariantChosen[1098] == 2)
			{
				if (this.global1.data[16] < 12 && this.global1.data[14] < 3)
				{
					this.text_fake += "|Сначала СЕПГ, ХДС и НДПГ были объединены в блок ХСС/ХДС с формально новой официальной идеологией, затем был введён чисто номинальный пост Президента, избираемого парламентом, а конечным шагом стал возврат к Конституции 1949 года с введением формального федерализма и немецкими наименованиями. Но несмотря на ожидания некоторых лиц и организаций Восточная Германия не поддалась на влияние Запада, не вестернизировалась и не либерализовалась: на улице продолжали висеть портреты Маркса и Энгельса, в школе - изучаться работы марксистов и диалектика, а в стране действовать плановая экономика и социалистический режим.";
				}
				else
				{
					this.text_fake += "|Многие верили в лучшее, но ожидали, что преобразования в ГДР останутся чистой формальностью. Их страхи не оправдались: несмотря на то, что Восточная Германия продолжила противостоять западному либерализму, ГДР претерпела серьёзные реформы, а внутри страны установился режим, который в шутку называют \"зеркалом ФРГ\". И даже восточнонемецкое правительство не скрывает свой статус \"зеркала\" и в пропаганде гордо именует себя \"лучшей версией Западной Германии\".";
				}
			}
			else if (this.global1.eventVariantChosen[58] == 1 && this.global1.event_done[58])
			{
				this.text_fake += "|Оставаясь у власти, переняв идеи австромарксизма и еврокоммунизма, наша партия сменила вектор классовой борьбы на борьбу за толерантность, принятие любого отличия и социальный индивидуализм. Реализовывая новую политическую программу к 2020 году наша страна успешно сумела стать примером для множества западных оппозиционных социальных движений несмотря на все наши новые общественные проблемы, как низкий уровень коллективизма и высокий уровень распространения депрессии и агрессии среди населения.";
			}
			else if (this.global1.eventVariantChosen[58] == 0 && this.global1.event_done[58])
			{
				if (this.global1.data[16] < 12)
				{
					this.text_fake += "|Оставаясь у власти, переняв идеи старого национал-большевизма и Никиша, наша партия сменила вектор классовой борьбы на борьбу за национальное благосостояние и общенародное государство, борьбу против Запада и за единство с Востоком. Реализовывая новую политическую программу к 2020 году наша страна успешно сумела стать примером для множества мировых социалистических организаций, которые, видя наш успешный курс, переняли и популяризировали национал-большевистское движение. Будем надеяться, что эклектическая система объединения крестьян, рабочих, мелкой буржуазии и интеллигенции будет держаться и дальше, а не перейдёт к классическому \"союзу лебедя, рака и щуки\".";
				}
				else
				{
					this.text_fake += "|Оставаясь у власти, переняв идеи старого национал-большевизма и Никиша, наша партия сменила вектор классовой борьбы на борьбу за национальное благосостояние и общенародное государство, борьбу против Запада и за единство с Востоком. Реализовывая новую политическую программу к 2020 году наша страна также отошла и от изначальных идей Никиша, вдохновившись братьями Штрассерами, но сумела стать примером для множества мировых националистических партий и организаций, показав пример построения национал-корпоративистского государства без этнических чисток и имперских амбиций. Будем надеяться, что солидаризм рабочих и корпораций при посредничестве государства будет работать дольше, чем во всех прошлых исторических примерах.";
				}
			}
			if (this.global1.iron_and_blood)
			{
				if (this.global1.eventVariantChosen[1098] == 2 && this.global1.eventVariantChosen[57] == 4 && this.global1.eventVariantChosen[34] == 0 && this.global1.data[14] <= 0)
				{
					this.achieves.GetComponent<achievements>().Set(131);
				}
				else if (this.global1.eventVariantChosen[1098] == 0 && this.global1.eventVariantChosen[58] == 1 && this.global1.data[16] > 12)
				{
					this.achieves.GetComponent<achievements>().Set(132);
				}
				else if (this.global1.eventVariantChosen[1098] == 1 && this.global1.eventVariantChosen[58] == 0 && this.global1.data[16] == 11)
				{
					this.achieves.GetComponent<achievements>().Set(133);
				}
			}
		}
		else if (this.this_okno == 0)
		{
			if (this.global1.iron_and_blood && !this.global1.allcountries[7].Vyshi && this.global1.data[90] == 0 && this.global1.data[92] == 0 && this.global1.data[93] == 0 && this.global1.data[94] == 0)
			{
				this.achieves.GetComponent<achievements>().Set(65);
			}
			this.Name.text = "ПОЛИТИЧЕСКАЯ ПОЗИЦИЯ";
			if (this.global1.data[103] == 1 && this.global1.data[80] >= 80)
			{
				this.text_fake = this.global1.politics_name[this.global1.data[11]] + " и " + this.global1.party_name[0] + " решительными действиями установили в стране однопартийную демократию, позволяющую отмести все контрреволюционные идеи и двигаться к построению марксизма-ленинизма. Несмотря на некоторые просчёты правителя, народ отнёсся с пониманием к проводимой политике и готов поддерживать и дальше его и Партию. Тем самым в стране утвердилась ведущая роль демократического централизма и коллективного правления.";
			}
			else if (this.global1.data[104] == 1)
			{
				this.text_fake = "Танай и халькистское крыло партии смогли расправиться с оппозицией в НДПА и установить официальной идеологией партии – «исламский социализм», тем самым совместив учение Корана и пророка Мухаммеда с прогрессивными принципами социальной справедливости, свободы и равенства. Данные меры помогли афганскому правительству заручиться поддержкой духовенства и внести раздор среди мятежников, часть которых начала активно переходить на сторону НДПА. Несмотря на некоторые просчёты президента Таная, Демократическая Республика Афганистан продолжает существовать, а это главное.";
			}
			else if (this.global1.data[105] == 1 && this.global1.data[106] == 0)
			{
				this.text_fake = "Под влиянием советской перестройки и стремлением к осуществлению «политики национального примирения», Народно-демократическая партия Афганистана сменила своё название на «Ватан» (Отечество), начав отход от марксистско-ленинской теории к демократическому социализму с исламской спецификой. Была вновь легализована многопартийность, однако в последующих выборах смогли принять участие только продемократические и лояльные правительству партии, и в итоге реформированная НДПА получила абсолютное большинство голосов. Благодаря относительной либерализации режима и закреплением за Исламом статуса государственной религии, малая часть оппозиции пошла на сотрудничество с правительством, однако недовольных половинчатыми реформами было всё равно достаточно.";
			}
			else if (this.global1.data[105] == 1 && this.global1.data[106] == 1)
			{
				this.text_fake = "Под влиянием советской перестройки и стремлением к осуществлению «политики национального примирения», Народно-демократическая партия Афганистана сменила своё название на «Ватан» (Отечество), начав отход от марксистско-ленинской теории к демократическому социализму с исламской спецификой. Также, правительство ДРА пошло на сотрудничество с «умеренной частью оппозиции», договорившись о проведении свободных демократических выборов и создании совместного коалиционного правительства. Благодаря относительной либерализации режима и провозглашению Ислама государственной религии, значительная часть оппозиции перешла на сторону ДРА, отказавшись от партизанской непримиримой борьбы. Со временем страна полноценно преобразовалась в аналог либеральной демократии с двумя лидирующими партиями – социал-демократической партией «Ватан» и правоконсервативной «Исламской партией Афганистана».";
			}
			else
			{
				this.text_fake = "Гражданская война нанесла серьёзный урон по политической системе Афганистана, поэтому сейчас весьма трудно сказать, что страну ждёт в будущем. Тем не менее, Демократическая республика Афганистан продолжает существовать и это главное. ";
			}
		}
		else if (this.this_okno == 1 && this.global1.data[0] != 12)
		{
			this.Name.text = "ЭКОНОМИЧЕСКАЯ СИСТЕМА";
			this.text_fake = "";
			if (this.global1.data[43] == 1)
			{
				this.text_fake = "Несмотря ни на что, мы смогли сохранить классическую плановую экономику с её преимуществами и недостатками. Хотя всемирное развитие компьютеризации и постепенное внедрение АСУ и РАСУ в наши предприятия осложняет чиновникам коррупцию и приписки, но о полной компьютеризации Госплана говорить не приходится. Так что припски и коррупция в Госплане всё ещё остаются обычным делом, из-за чего определённых товаров порой не хватает, однако кустари и кооперативы понемногу компенсируют этот дефицит. Госконтроль над внешней торговлей же обеспечивает нам независимость от внешнего рынка. Экономика стабильно развивается, в бюджет идут деньги, а мы доказали всему миру, что реальная альтернатива капитализму существует.";
			}
			else if (this.global1.data[43] == 2)
			{
				this.text_fake = "Несмотря на требования реформировать экономику, мы успешно построили ОГАС и внедрили её в наш Госплан. Благодаря этому, нам удалось почти полностью одолеть приписки и коррупцию внутри него, что дало резкий толчок к развитию нашей экономики, позволив нам совершить своё экономическое чудо. Теперь наша экономика беспристрастно управляется единой автоматизированной системой, благодаря чему она бурно развивается, а товаров производится достаточно для всех. Народ рад, бюджет наполняется деньгами, а автоматизированный коммунизм кажется народу всё более реальным.";
			}
			else if (this.global1.data[43] == 3)
			{
				this.text_fake = "Понимая необходимость реформирования нашей экономики, но не видя будущего в капитализме, мы провели реформы на основе венгерской системы Кадара. Отказ от централизованного планирования в пользу расширения самостоятельности предприятий, при сохранении на них госсобственности дали толчок к развитию нашей экономики. Конкурентоспособность и качество наших товаров повысились, появились даже новые для нашей страны товары, а внешняя торговля процветает. Однако вместе с тем произошло развитие коррупции и теневых схем, зависимость от внешнего рынка увеличилась, а \"нерентабельные\" предприятия либо дотируются из бюджета, либо разваливаются. Впрочем мы показали, что рынок можно организовать и при социализме и обеспечить благосостояние страны.";
			}
			else if (this.global1.data[43] == 4)
			{
				this.text_fake = "Повинуясь ветру перемен, мы совершили переход к свободной рыночной экономике. Государственные предприятия были приватизированы, а контроль за ценами и внешней торговлей ушли в прошлое. Это позволило предприимчивым и умелым руководителям возвыситься и теперь они двигают нашу экономику, а народ получил долгожданные джинсы и колу и возможность организовать свой бизнес. Однако вместе с тем люди, ища способы заработать, не стесняются в методах, что способствует расцвету теневых схем и коррупции, многие рабочие остались без работы, а многие начинающие бизнесмены очень быстро разоряются. Теперь вам придётся столкнуться уже с проблемами капитализма - растущим неравенством, коррупцией и безработицей, зато проблемы плановой экономики теперь точно нас не потревожат.";
			}
			else if (this.global1.data[43] == 5)
			{
				this.text_fake = "В то время как общественные организации стали призывать дать всё больше свободы народу в производстве собственных товаров, в " + this.global1.party_name[0] + " , на волне либерализации, к лидерству пришли сторонники фракции либерализации и самой экономики: сначала были разрешены коллективные формы предпринимательства - артели, кооперативы, ИП, семейные хозяйства вместе колхозов, которым дали множественную свободу. Следующим шагом стал переход государственных предприятий на хозрасчет, под видом борьбы с бюрократией и перегибами. Затем вовнутрь были допущены иностранные инвестиции и началось открытие совместных с иностранцами предприятий, как формы использования иностранного капитала во благо нашего народа. Постепенно вся плановая экономика сошла на нет, а в стране воцарился государственный капитализм со всеми работающими механизмами рыночной экономики. ";
			}
			if (this.global1.allcountries[this.global1.data[0]].subideology >= 300)
			{
				this.text_fake = this.text_fake + "\n" + this.dlce1.credits_text[48];
			}
		}
		else if (this.this_okno == 1)
		{
			this.Name.text = "ЭКОНОМИЧЕСКАЯ СИСТЕМА";
			this.text_fake = "";
			if (this.global1.data[16] == 10 && !this.global1.allcountries[7].Vyshi)
			{
				this.text_fake = "Постепенная стабилизация ситуации дала возможность развернуть в стране полноценные социалистические реформы с последующей установкой в стране экономического планирования. Малое предпринимательство и кустарщина были полностью легализованы, а в сельском хозяйстве поощряется объединение в семейные подряды и кооперативы. Вместе с этим правительство проводит масштабные социальные преобразования: строительство квартир, школ, больниц, детских садов. Мирная обстановка и поддержка СССР дали возможность афганской экономике стабильно развиваться.";
			}
			else if (this.global1.data[16] == 12 && !this.global1.allcountries[7].Vyshi)
			{
				this.text_fake = "Постепенная стабилизация ситуации дала возможность правительству развернуть экономические реформы в рамках социализма. Крупные предприятия по-прежнему находятся в государственном владении, однако производство лёгкой промышленности и ширпотреба было полностью передано в управление рабочих коллективов. В сельскохозяйственных регионах проходят кампании по поддержке единоличного крестьянства, а правительство активно выделяет сельским работникам ссуды и льготы на покупку оборудования. Массовое строительство школ, больниц и жилищных комплексов смогли значительно поднять уровень жизни населения, а благодаря советской помощи и специалистам, Афганистан с каждым годом осваивает всё более и более наукоёмкие отрасли в ведении народного хозяйства.";
			}
			else if (this.global1.data[16] == 13 && !this.global1.allcountries[7].Vyshi)
			{
				this.text_fake = "Постепенная стабилизация ситуации дала возможность правительству развернуть экономические реформы. Большинство средних, а также некоторые крупные предприятий, построенные СССР были приватизированы и переданы в руки предпринимателей. В сельском хозяйстве развернулись кампании по поощрению фермеров, которым правительство выдаёт ссуды для покупки оборудования. Благодаря советской поддержке развернулось массовое строительство школ, больниц и жилищных комплексов, уровень жизни населения стабильно растёт, а экономика Афганистана постепенно оправляется от последствий гражданской войны.";
			}
			else if (this.global1.allcountries[7].Vyshi)
			{
				this.text_fake = "Распад социалистического лагеря и СССР серьёзно ударили по нашей и без того слабой экономике. Послевоенная попытка правительства внедрить какие-либо экономические реформы привёл лишь к сопротивлению со стороны оппозиции, которая по сей день считает частную собственность «божественным даром», требуя соблюдения её неприкосновенности и защиты со стороны государства. В итоге хоть у государства и осталась регулирующая роль, малые и средние предприятия были переданы под управление предпринимателей, а среди крестьян растёт недовольство из-за малоземелья и плохой механизации сельского хозяйства. Несмотря на это, наша экономика показывает хоть и маленький, но стабильный рост, хотя в некоторых регионах всё ещё господствуют феодальные пережитки.";
			}
			else if (!this.global1.allcountries[7].Vyshi)
			{
				this.text_fake = "Преобразования в социалистическом лагере серьёзно ударили по нашей и без того слабой экономике. Послевоенная попытка правительства внедрить какие-либо экономические реформы привёл лишь к сопротивлению со стороны оппозиции, которая по сей день защищает племенную собственность  «божественным даром», требуя соблюдения её неприкосновенности и защиты со стороны государства. В итоге хоть у государства и осталась регулирующая роль, малые и средние предприятия были переданы под управление предпринимателей, а среди крестьян растёт недовольство из-за малоземелья и плохой механизации сельского хозяйства. Несмотря на это, наша экономика показывает хоть и маленький, но стабильный рост, хотя в стране всё ещё господствуют феодальные пережитки.";
			}
		}
		else if (this.this_okno == 2)
		{
			this.Name.text = "БЛАГОСОСТОЯНИЕ НАСЕЛЕНИЯ";
			this.text_fake = "";
			if (this.global1.data[44] == 1)
			{
				this.text_fake = string.Concat(new string[]
				{
					"Наш лидер, ",
					this.global1.politics_name[this.global1.data[11]],
					", и его гениальное правление позволили создать процветающую экономику и отличное социальное обеспечение, благодаря чему весь наш народ живёт в роскоши и процветании. Наша страна занимает первые строчки мировых рейтингов по уровню жизни, опережая даже страны Скандинавии. ",
					this.global1.politics_name[this.global1.data[11]],
					" войдёт в историю, как один из самых успешных правителей, а наши граждане счастливы процветать под его мудрым руководством."
				});
				if (this.global1.data[58] == 1)
				{
					this.text_fake += "|Решение о модернизации нефтедобычи позволило нам существенно нарастить уровень импорта и провести углубленные социальные реформы, благодаря чему народ сейчас очень доволен.";
				}
			}
			else if (this.global1.data[44] == 2)
			{
				this.text_fake = "Наш лидер, " + this.global1.politics_name[this.global1.data[11]] + ", и его умелое руководство создали развитую экономику и социальную сферу и смогли обеспечить всему народу комфортную и стабильную жизнь. Наша страна гордо стоит по уровню жизни вровень с Европой, а многие люди из менее успешных стран, коих большинство, мечтают уехать к нам. Наш народ рад иметь такую достойную жизнь и правителя, обеспечившего её.";
				if (this.global1.data[58] == 1)
				{
					this.text_fake += "|Решение о модернизации нефтедобычи позволило нам существенно нарастить уровень импорта и провести углубленные социальные реформы, благодаря чему народ сейчас очень доволен.";
				}
			}
			else if (this.global1.data[44] == 3 && this.global1.allcountries[7].isSEV)
			{
				this.text_fake = "Наш лидер, " + this.global1.politics_name[this.global1.data[11]] + ", и его правление создали экономику, позволившую обеспечить народу более-менее достойную жизнь. И, хотя, мы отстаём от Европы, у нашего народа есть еда, жильё, образование и некоторая роскошь. Советский Союз смог оправиться от социального кризиса и выйти на наш уровень лишь к 2010-м годам, а наши граждане по крайней мере не должны беспокоиться насчёт голода и крыши над головой.";
				if (this.global1.data[58] == 1)
				{
					this.text_fake += "|Решение о модернизации нефтедобычи позволило нам существенно нарастить уровень импорта и провести углубленные социальные реформы, благодаря чему народ сейчас доволен.";
				}
			}
			else if (this.global1.data[44] == 3)
			{
				this.text_fake = "Наш лидер, " + this.global1.politics_name[this.global1.data[11]] + ", и его правление создали экономику, позволившую обеспечить народу более-менее достойную жизнь. И, хотя, мы отстаём от Европы, у нашего народа есть еда, жильё, образование и некоторая роскошь. Страны бывшего СССР смогли выйти на наш уровень лишь к 2010-м годам, а наши граждане по крайней мере не должны беспокоиться насчёт голода и крыши над головой.";
				if (this.global1.data[58] == 1)
				{
					this.text_fake += "|Решение о модернизации нефтедобычи позволило нам существенно нарастить уровень импорта и провести углубленные социальные реформы, благодаря чему народ сейчас доволен.";
				}
			}
			else if (this.global1.data[44] == 4)
			{
				this.text_fake = "Наш лидер, " + this.global1.politics_name[this.global1.data[11]] + ", и его правление привели к развалу социальной сферы, ввергнув население в бедность. Безработица, бездомность и периодическое недоедание стали обычным делом для наших граждан, а наша страна вынуждена принимать гуманитарную помощь от международных организаций. Ни о каком комфорте говорить не приходится, а наши граждане навсегда запомнят эти трудные времена.";
			}
		}
		else if (this.this_okno == 3)
		{
			this.Name.text = "СОВЕТСКИЙ СОЮЗ";
			this.text_fake = "";
			if (this.global1.allcountries[7].paths == 2)
			{
				this.text_fake = "Несмотря на реформы, постигшие СССР и страны соцлагеря, мир всё еще остался многополярным, а обновленный коммунизм - всё еще решающей международной силой.";
			}
			else if (this.global1.allcountries[7].paths == 3)
			{
				this.text_fake = "Несмотря на реформы, постигшие СССР и страны соцлагеря, Советский Союз остался одним из бесспорных гегемонов в мире, а обновленный коммунизм - всё еще решающей международной силой. |Стабилизировав внешнее положение и оставшись всё еще весомой силой, при активной поддержке новообразованного Совета Безопасности, состоящего из прагматичных реформистов, советское правительство смогло пресечь внутренние распри и направить взгляды народа от идей размежевания в сторону идей углубления экономических реформ.";
			}
			else if (this.global1.data[45] == 1)
			{
				this.text_fake = "Несмотря на реформы, постигшие СССР и страны соцлагеря, Советский Союз остался одним из бесспорных гегемонов в мире, а обновленный коммунизм - всё еще решающей международной силой. |Стабилизировав внешнее положение и оставшись всё еще весомой силой, при активной поддержке новообразованного Совета Безопасности, состоящего из прагматичных реформистов, советское правительство смогло пресечь внутренние распри и направить взгляды народа от идей размежевания в сторону идей углубления экономических реформ. |Взяв пример с Китая, и наладив с ним отношения, Президент Горбачёв правил страной два президентских срока, сам же введя лимит на правление. После второго срока он оставил свой пост и обещал больше не баллотироваться, оставшись Генеральным Секретарем ЦК КПСС. Впрочем, реформы Горбачёва хоть и дали больше свободы стране и помогли возвыситься определенным предприимчивым организаторам, но, в целом, социальное положение продолжает ухудшаться год от года. |И население с огромной надеждой ожидает качественных изменений, связывая их с новыми президентскими выборами.";
			}
			else if (this.global1.data[45] == 2)
			{
				this.text_fake = "Несмотря на реформы, постигшие СССР и страны соцлагеря, Советский Союз остался одним из бесспорных лидеров в мире, а обновленный коммунизм - всё еще решающей международной силой. |Все попытки право-либеральной оппозиции провести реформы, нацеленные на размежевание Союза, быстро заглохли, когда на первых президентских выборах в РСФСР на обещания Ельцина дать больше суверенитета России и не кормить иные нации, победу одержал кандидат от КПСС - Николай Рыжков. |При активной поддержке новообразованного Совета Безопасности, состоящего из прагматичных реформистов, советское правительство направило взгляды народа в сторону углубления экономических реформ. |Взяв пример с Китая, и наладив с ним отношения, Президент Горбачёв правил страной два президентских срока, сам же введя лимит на правление. После второго срока он оставил свой пост и обещал больше не баллотироваться, оставшись Генеральным Секретарем ЦК КПСС. Впрочем, реформы Горбачёва хоть и дали больше свободы стране и помогли возвыситься определенным предприимчивым организаторам, но, в целом, социальное положение продолжает ухудшаться год от года. |И население с огромной надеждой ожидает качественных изменений, связывая их с новыми президентскими выборами.";
			}
			else if (this.global1.data[45] == 3)
			{
				this.text_fake = "Несмотря на реформы, постигшие СССР и страны соцлагеря, мир всё еще остался многополярным, а обновленный коммунизм - всё еще решающей международной силой. |И хотя, под давлением право-либеральной общественности, в силу вступил договор о преобразовании СССР в Союз Советских Суверенных Республик, на первых президентских выборах в РСФСР, несмотря на обещания Ельцина дать больше суверенитета России и не кормить иные нации, победу одержал кандидат от КПСС - Николай Рыжков, а сам новый союзный договор хоть и расширил права республик, но, в то же время, подтвердил и закрепил единство советского народа и нерушимость Союза. |При активной поддержке новообразованного Совета Безопасности, состоящего из прагматичных реформистов, советское правительство направило взгляды народа в сторону углубления экономических реформ. |Взяв пример с Китая, и наладив с ним отношения, Президент Горбачёв правил страной два президентских срока, сам же введя лимит на правление. После второго срока он оставил свой пост и обещал больше не баллотироваться, оставшись Генеральным Секретарем ЦК КПСС. Впрочем, реформы Горбачёва хоть и дали больше свободы стране и помогли возвыситься определенным предприимчивым организаторам, но, в целом, социальное положение продолжает ухудшаться год от года, а в союзных республиках всё больше подымают голову националистические и традиционалистические объединения. |Население с огромной надеждой ожидает качественных изменений, связывая их с новыми президентскими выборами.";
			}
			else if (this.global1.data[45] == 4)
			{
				if (!this.global1.event_done[74])
				{
					this.text_fake = "ГКЧП провалилось, но во многом за счёт того, что в последний день своего существования Министр Обороны Язов решил послушать Шапошникова и самолично разогнал ГКЧП, арестовав его состав. Благодаря этому под горбачёвские чистки попали лишь сами члены ГКЧП и ярко отличившиеся их сторонники, но другие сочуствующие остались не тронутыми, в том числе и Председатель Верховного Совета СССР Анатолий Лукьянов.| Следствием этого V Съезд народных депутатов СССР принял решение о преобразовании СССР в Союз Суверенных Государств, что было ратифицировано другими республиками и сорвало планы беловежского сговора. Президентом ССГ стал Михаил Горбачёв.| Противостояние Центра со сторонниками полного размежевания получило свой конец в октябре 1993 года, когда Верховный Совет РСФСР законно отправил Президента России Ельцина в отставку, а когда тот попытался организовать военный переворот - не получил поддержки ни из Центра ни от самих военных и был вынужден бежать за границу. С того момента политическое положение в ССГ стабилизировалось.| Впрочем, реформы Горбачёва хоть и дали больше свободы стране и помогли возвыситься определенным предприимичвым организаторам, но, в целом, социальное и экономическое положение продолжает ухудшаться год от года, а в союзных республиках всё больше подымают голову националистические и традиционалистические объединения, имеющие хорошо скрываемую благосклонность со стороны представителей руководящих органов некоторых республик-членов ССГ. |Население с огромной надеждой ожидает качественных изменений, связывая их с новыми президентскими выборами.";
				}
				else
				{
					this.text_fake = "ГКЧП провалилось, но во многом за счёт того, что в последний день своего существования Министр Обороны Язов решил послушать Шапошникова и самолично разогнал ГКЧП, арестовав его состав. Благодаря этому под горбачёвские чистки попали лишь сами члены ГКЧП и ярко отличившиеся их сторонники, но другие сочуствующие остались не тронутыми, в том числе и Председатель Верховного Совета СССР Анатолий Лукьянов.| Следствием этого V Съезд народных депутатов СССР принял решение о преобразовании СССР в Союз Суверенных Государств, что было ратифицировано другими республиками и сорвало планы беловежского сговора. Президентом ССГ стал Михаил Горбачёв. Впрочем, реформы Горбачёва хоть и дали больше свободы стране и помогли возвыситься определенным предприимичвым организаторам, но, в целом, социальное и экономическое положение продолжает ухудшаться год от года, а в союзных республиках всё больше подымают голову националистические и традиционалистические объединения, имеющие хорошо скрываемую благосклонность со стороны представителей руководящих органов некоторых республик-членов ССГ. |Население с огромной надеждой ожидает качественных изменений, связывая их с новыми президентскими выборами.";
				}
			}
			else if (this.global1.data[45] == 5)
			{
				this.text_fake = "ГКЧП провалилось и карающая длань Горбачёва обрушилась на всех активных сторонников и просто сочуствующих социалистическим идеям и ГКЧП. Михаил Сергеевич, разрушая и так подорванное доверие к советской власти, ликвидирует остатки хоть на что-то влияющих советских органов управления и без какой-либо внятной реакции принимает Беловежский сговор как совершившееся дело.| Готовившиеся к побегу и удивленные подобным исходом организаторы Беловежского сговора с радостью обманывают свои народы и заявляют о преемственности Советского Союза Содружеством Независимых Государств, который, как договор, является лишь номинальным росчерком пера, поставившим жирную точку на итоги референдума о сохранении и преобразовании СССР.| Многократное падение экономики и уровня жизни, неудачное проведение реформ и резкий рост коррупции и криминала теперь останутся в памяти бывшего советского народа навсегда, ровно как и незаконный переворот, осуществленный Ельциным в октября 1993 года...";
			}
			else if (this.global1.data[45] == 6)
			{
				this.text_fake = string.Concat(new object[]
				{
					"ГКЧП сумело взять под контроль все теле- и радиостанции и не допустить к показу радикальных журналистов, даже арестовав их. Борис Ельцин погиб по время перестрелки между его охраной и отрядом КГБ, прибывшим для его ареста, так как не пожелал сдаваться. Возглавленный генералом Лебедем штурм оплота оппозиции - здания Верховного Совета - привёл к окончательной стабилизации власти ГКЧП.|В своих выступлениях лидер ГКЧП Янаев заявил о приверженности идеалам Перестройки, огласив всему миру, что Горбачёв болен и более не сможет править страной, а в дальнейшем будущем будут проведены первые всенародные президентские выборы. В то же время ГКЧП осудило попытку размежевания Советского Союза, назвав это попыткой пойти против воли народа, который на мартовском референдуме поддержал единство СССР|В течении всего 1992-",
					this.global1.data[21] + 1,
					" годов шли крупные уголовные дела государственного уровня по осуждению коррупционеров, мошенников и расхитителей госсобственности, а с помощью грубой силы и слаженной работы спецслужб были окончательно подавлены все очаги мятежников.|И лишь в ",
					this.global1.data[21] + 1,
					" году, в августе, начались обещанные президентские выборы..."
				});
			}
			else if (this.global1.data[45] == 7)
			{
				this.text_fake = string.Concat(new object[]
				{
					"ГКЧП сумело взять под контроль все теле- и радиостанции и не допустить к показу радикальных журналистов, даже арестовав их. Борис Ельцин погиб по время перестрелки между его охраной и отрядом КГБ, прибывшим для его ареста, так как не пожелал сдаваться. Возглавленный генералом Лебедем штурм оплота оппозиции - здания Верховного Совета РСФСР - привёл к окончательной стабилизации власти ГКЧП.|В своих выступлениях лидер ГКЧП Алкснис заявил о том, что сам Горбачёв предал идеалы Перестройки, огласив всему миру, что после похорон Горбачёва в дальнейшем будущем будут проведены президентские выборы, но избирать его будет Верховный Совет. В то же время ГКЧП осудило попытку размежевания Советского Союза, назвав это попыткой пойти против воли народа.|В течении всего 1992-",
					this.global1.data[21] + 1,
					" годов шли крупные уголовные дела государственного уровня по осуждению коррупционеров, мошенников и расхитителей госсобственности, а с помощью грубой силы и слаженной работы спецслужб были окончательно подавлены все очаги мятежников.|И лишь в ",
					this.global1.data[21] + 1,
					" году, в августе, начались обещанные президентские выборы..."
				});
			}
		}
		else if (this.this_okno == 4)
		{
			this.Name.text = "СОВЕТСКИЙ СОЮЗ";
			this.text_fake = "";
			if (this.global1.allcountries[7].paths == 2)
			{
				this.text_fake = this.dlce1.credits_text[46];
			}
			else if (this.global1.allcountries[7].paths == 3)
			{
				this.text_fake = this.dlce1.credits_text[47];
			}
			else if (this.global1.data[45] == 1)
			{
				if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(24);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Борис Пуго</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Борис Пуго, бывший Министр Внутренних Дел, который сразу же начал огромную кампанию против коррупции и рыночных махинаций, а также массовое преследование националистов, в том числе и прибалтийских, сам будучи латышом по национальности. Дальнейшим шагом стало продавливание смены вектора рыночных реформ на китайский аналог реформ птичьей клетки, с многократным усилением государственного вмешательства. Не согласный с этим Горбачёв ушел в отставку по состоянию здоровья.| Резкое падение уровня коррупции и спекуляции, чистки государственных структур и переход к более эффективным методам проведения экономических реформ уже дают множественные плоды в виде подъема социального, экономического и духовного.";
				}
				else
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(26);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Владимир Жириновский</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Владимир Жириновский, первый не член КПСС со времён Перестройки. Его обещания были популистическими: честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, повсеместная борьба с коррупцией и бюрократией и возвращение былого величия Советского Союза на международной арене.| Впрочем, придя к власти Жириновский не провёл огромные переназначения в руководящем аппарате и представители КПСС всё еще остаются в большинстве.| Своё правление Жириновский начал с инаугурационной речи, на которой громко и грубо выразил нападки против сторонников размежевания и внешних врагов. Это уже породило начало масштабной кампании борьбы с местническим национализмом и лавину русофильской пропаганды, что вызвало негативную критику со стороны Горбачёва и стало началом официального раскола в советском руководстве...";
				}
			}
			else if (this.global1.data[45] == 2)
			{
				if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(24);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Борис Пуго</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Борис Пуго, бывший Министр Внутренних Дел, который сразу же начал огромную кампанию против коррупции и рыночных махинаций, а также массовое преследование националистов, в том числе и прибалтийских, сам будучи латышом по национальности. Дальнейшим шагом стало продавливание смены вектора рыночных реформ на китайский аналог реформ птичьей клетки, с многократным усилением государственного вмешательства. Не согласный с этим Горбачёв ушел в отставку по состоянию здоровья.| Резкое падение уровня коррупции и спекуляции, чистки государственных структур и переход к более эффективным методам проведения экономических реформ уже дают множественные плоды в виде подъема социального, экономического и духовного.";
				}
				else
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(25);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Геннадий Зюганов</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Геннадий Зюганов. Его обещаниями были: поддержка религиозной свободы, в частности Православия, честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, что должно было привести к улучшению материального положения населения.|И своё правление он начал с открытием множества СЭЗ на территории страны, приглашением иностранных инвесторов и продаже дешёвой рабочей силы им. Следующим шагом он видит исполнение требований для членства СССР в ВТО...";
				}
			}
			else if (this.global1.data[45] == 3)
			{
				if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(25);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Геннадий Зюганов</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Геннадий Зюганов. Его обещаниями были: поддержка религиозной свободы, в частности Православия, честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, что должно было привести к улучшению материального положения населения.|И своё правление он начал с открытием множества СЭЗ на территории страны, приглашением иностранных инвесторов и продаже дешёвой рабочей силы им. Следующим шагом он видит исполнение требований для членства СССР в ВТО...";
				}
				else
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(26);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Владимир Жириновский</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Владимир Жириновский, первый не член КПСС со времён Перестройки. Его обещания были популистическими: честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, повсеместная борьба с коррупцией и бюрократией и возвращение былого величия Советского Союза на международной арене.| Впрочем, придя к власти Жириновский не провёл огромные переназначения в руководящем аппарате и представители КПСС всё еще остаются в большинстве.| Своё правление Жириновский начал с инаугурационной речи, на которой громко и грубо выразил нападки против сторонников размежевания и внешних врагов. Это уже породило начало масштабной кампании борьбы с местническим национализмом и лавину русофильской пропаганды, что вызвало негативную критику со стороны Горбачёва и стало началом официального раскола в советском руководстве...";
				}
			}
			else if (this.global1.data[45] == 4)
			{
				if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(27);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Александр Лебедь</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел поддержанный в основном русскоязычным населением Александр Лебедь, первый не-член КПСС со времён Перестройки, возглавляющий собственную правонационалистическую русофильскую партию. Его обещания были популистическими: честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, повсеместная борьба с коррупцией и бюрократией и возвращение былого величия страны на международной арене.| Придя к власти Александр полностью отправил в отставку весь старый состав высших руководящих органов страны и заменил их своими сторонниками. В то же время, пользуясь популярностью и имея огромные связи среди офицерского состава советской армии, он начал подготовку и проведение военных операций против поднявших голову недовольных региональных лидеров.| Своё правление Лебедь начал с инаугурационной речи, на которой громко и грубо выразил нападки против сторонников размежевания и внешних врагов. Это уже породило начало масштабной кампании борьбы с местническим национализмом и лавину русофильской пропаганды...";
				}
				else
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(28);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Григорий Явлинский</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Григорий Явлинский, бывший член КПСС и лидер собственной лево-либеральной Партии \"Яблоко\", а также действующий заместитель Председателя Совета Министров ССГ.|Придя к власти на волне обещаний реализовать заброшенную коммунистами программу реформирования ССГ за 500 дней вместе с интеграцией Союза как единого целого в международную экономику, Явлинский считает важным укрепление рыночных связей между республиками-членами ССГ и видит своё правление в качестве рычага для преобразования ССГ в договор, схожий с Европейским Союзом, что определенно не нравится местническим региональным лидерам, не желающим делиться экономическими автономиями и правами на казнокрадство из своих бюджетов. | С приходом к власти под руководством Явлинского начинается формирование Комитета реформ экономики, в отставку уходит старый состав руководящих органов СССР, начинаются открытые слушанья и громогласные преследования коррупционеров.|Народ с нетерпением ожидает внедрения реальной социально-ориентированной рыночной экономики...";
				}
			}
			else if (this.global1.data[45] == 5)
			{
				this.text_fake = "<color=blue>РЕАЛЬНАЯ ИСТОРИЯ</color>|";
			}
			else if (this.global1.data[45] == 6)
			{
				if (this.global1.data[51] + this.global1.data[52] * 3 > 10)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(24);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Борис Пуго</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Борис Пуго, бывший Министр Внутренних Дел, который сразу же начал огромную кампанию против коррупции и рыночных махинаций, а также массовое преследование националистов, в том числе и прибалтийских, сам будучи латышом по национальности. Дальнейшим шагом стало продавливание смены вектора рыночных реформ на китайский аналог реформ птичьей клетки, с многократным усилением государственного вмешательства. А ровно через полгода трагично скончался Горбачёв на операционном столе...| Резкое падение уровня коррупции и спекуляции, чистки государственных структур и переход к более эффективным методам проведения экономических реформ уже дают множественные плоды в виде подъема социального, экономического и духовного.";
				}
				else
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(25);
					}
					this.text_fake = "|<color=red>РАСЧЁТ...|</color>";
					this.text_fake += "<color=blue>Геннадий Зюганов</color>|";
					this.text_fake += "На новых президентских выборах к власти пришел Геннадий Зюганов. Его обещаниями были: поддержка религиозной свободы, в частности Православия, честная приватизация нерентабельных госпредприятий после реструктуризации экономики и увеличение социальных расходов за счёт этого, что должно было привести к улучшению материального положения населения.|И своё правление он начал с открытием множества СЭЗ на территории страны, приглашением иностранных инвесторов и продаже дешёвой рабочей силы им. Следующим шагом он видит исполнение требований для членства СССР в ВТО...|Горбачёв, который после самороспуска ГКЧП вновь получил возможность свободно выступать и печататься, поддержал деяния Зюганова и, вскоре, даже был назначен его личным советником.";
				}
			}
			else if (this.global1.data[45] == 7)
			{
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(29);
				}
				this.text_fake = "<color=blue>Виктор Алкснис</color>|";
				this.text_fake += "Президентом был утверждён Виктор Алкснис, как и ожидалось, который сразу же начал огромную кампанию против коррупции и рыночных махинаций, а также массовое преследование националистов, в том числе и прибалтийских, сам будучи латышом по национальности. Дальнейшим шагом стало продавливание смены вектора рыночных реформ на китайский аналог реформ птичьей клетки, с многократным усилением государственного вмешательства.| Резкое падение уровня коррупции и спекуляции, чистки государственных структур и переход к более эффективным методам проведения экономических реформ уже дают множественные плоды в виде подъема социального, экономического и духовного.";
			}
		}
		else if (this.this_okno == 5)
		{
			this.Name.text = "НАУЧНЫЕ ДОСТИЖЕНИЯ";
			this.text_fake = "";
			if (this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && (this.global1.data[0] < 49 || this.global1.data[0] > 51))
			{
				if (((this.global1.data[42] == 2 && this.global1.science[1]) || (this.global1.science[2] && this.global1.data[42] != 7 && this.global1.data[17] != 17)) && !this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					this.text_fake = "Мы успешно исследовали и внедрили новые методы наблюдения за гражданами с целью защиты нашего государства. Камеры наблюдения, прослушки и электронные базы данных на каждого гражданина позволяют нам знать почти всё об интересующих нас людях. И, хотя иногда эти меры создают неудобства народу и некоторым не нравится мысль, что за ними наблюдают, нам бы всё равно пришлось бороться с внутренними и внешними врагами. Благодаря нашей системе, мы можем сделать это максимально быстро и эффективно, не затронув невиновных.|";
				}
				else if ((this.global1.science[1] && (this.global1.data[14] >= 3 || this.global1.allcountries[this.global1.data[0]].Vyshi)) || this.global1.science[2])
				{
					this.text_fake = "Несмотря на определённые подвижки в развитии методов слежки за населением, наши дальнейшие движения в сторону либерализации вынудили нас свернуть работы. Идейные либералы и реформаторы, чьи ценности стали для нас одними из основных, не захотели терпеть подобного нарушения прав человека, какие бы ни стояли за ними цели. Нам придётся использовать другие методы защиты государства от внутренних и внешних врагов.|";
				}
				else
				{
					this.text_fake = "Достижений в установлении тотальной слежки - нет.|";
				}
				if ((this.global1.data[43] == 2 && this.global1.science[4]) || (this.global1.science[5] && this.global1.data[43] == 1 && this.global1.data[18] <= 20))
				{
					if (this.global1.data[44] <= 2)
					{
						this.text_fake += "|На основе исследований Глушкова и Китова мы успешно разработали и построили ОГАС, внедрив её в наш Госплан. Эта централизованная система, учитывающая наши производственные возможности, ресурсы и динамику потребностей, теперь управляет всеми нашими предприятиями, искореняя приписки, несмотря на протесты некоторых консерваторов. Это позволяет нашей экономике быстро наращивать темпы роста, а некоторые уже уверенно предсказывают наступление будущего автоматизированного коммунизма.|";
					}
					else
					{
						this.text_fake += "|На основе исследований Глушкова и Китова мы успешно разработали и построили ОГАС, внедрив её в наш Госплан. Эта централизованная система, учитывающая наши производственные возможности, ресурсы и динамику потребностей, теперь управляет всеми нашими предприятиями, искореняя приписки, несмотря на протесты некоторых консерваторов. Это позволяет нашей экономике быстро наращивать темпы роста и идти в ногу со временем в мировой военной гонке.|";
					}
				}
				else if ((this.global1.science[4] || this.global1.science[5]) && this.global1.data[43] <= 2)
				{
					this.text_fake += "|Несмотря на определённые подвижки в развитии компьютеризации и внедрении её в нашу экономику, до разработки ОГАС наши руки и средства так и не дошли. В итоге (в том числе под давлением консерваторов) было решено ограничиться внедрением АСУ и РАСУ, что, конечно, увеличило рост нашей экономики и помогло бороться с коррупционерами. Однако мечты кибернетиков 50-х годов о построении единой централизованной автоматизированной системы, способной искоренить приписки и обеспечить максимально эффективное производство, так и остаются мечтами.|";
				}
				else if ((this.global1.science[4] || this.global1.science[5]) && this.global1.data[43] > 2)
				{
					this.text_fake += "|Несмотря на развитие компьютеризации и внедрение её в нашу экономику, дальнешйие экономические реформы в сторону свободного рынка поставили крест на построении ОГАС. Разрозненным частным компаниям, конкурирующим за прибыль, не нужна была единая централизованная система, учитывающая наши производственные возможности, ресурсы и динамику потребностей. Работы над ОГАС были свёрнуты, а сама она так и осталась смелой мечтой из прошлого.|";
				}
				else
				{
					this.text_fake += "|Достижений во внедрении автоматизации - нет.|";
				}
				if ((this.global1.data[42] != 9 && this.global1.data[42] != 10 && this.global1.data[42] != 6 && this.global1.data[42] != 5 && this.global1.data[42] != 2 && this.global1.science[5] && this.global1.science[7]) || (this.global1.science[8] && this.global1.data[42] != 5 && this.global1.data[42] != 6 && this.global1.data[42] != 2 && ((this.global1.data[42] != 9 && this.global1.data[14] <= 0) || this.global1.data[42] == 9) && this.global1.data[42] != 10))
				{
					this.text_fake += "|Мы успешно развили и внедрили передовую генетику в наше сельское хозяйство и медицину. Это позволило нам получать гораздо больше урожаев, улучшив вкус и стойкость выращиваемых продуктов к окружающим воздействиям, и эффективнее бороться с болезнями, помогая определять их происхождение. Перед нашими учёными простираются бесконечные перспективы вплоть до выращивания искусственных органов и продуктов.|";
				}
				else if ((this.global1.science[7] || this.global1.science[8]) && (this.global1.data[42] == 9 || this.global1.data[42] == 2))
				{
					this.text_fake += "|Развитие генетики вызвало в наших научных и партийных кругах разногласия и ожесточённые споры. В итоге под давлением части учёных вместе с консервативными общественными и партийными деятелями новые методы генетики были признаны лженаучными, противоречащими материализму и пропагандирующими расизм и евгенику. Новые исследования в генетике вскоре застопорились, часть учёных лишили своих степеней, часть перешли в другие области или вынуждены были отказаться от своих взглядов на генетику.|";
				}
				else if (this.global1.science[7] || this.global1.science[8])
				{
					this.text_fake += "|Развитие генетики вызвало большое беспокойство среди консервативных общественных и политических деятелей и духовенства. В итоге под их давлением, генетика была признана противоречащей человеческой природе, традициям и божественному замыслу и запрещена, как неэтичная лженаука. Исследования в этой области были свёрнуты, заставляя учёных скрывать свои взгляды и перестраиваться на другие области науки.|";
				}
				else
				{
					this.text_fake += "|Достижений в развитии генетики - нет.|";
				}
			}
			else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				if (this.global1.science[0] && this.global1.science[1] && this.global1.science[7] && (this.global1.data[42] == 2 || (this.global1.data[42] != 7 && this.global1.data[17] != 17)) && !this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					this.text_fake = this.yug1.science_text[41];
				}
				else if (this.global1.science[0] && this.global1.science[1] && this.global1.science[7])
				{
					this.text_fake = this.yug1.science_text[42];
				}
				else
				{
					this.text_fake = this.yug1.science_text[43];
				}
				bool flag3 = false;
				for (int n = 0; n < this.yug1.gameState.yugcountries.Length; n++)
				{
					if (this.yug1.gameState.yugcountries[n].is_exist && n != this.yug1.gameState.player)
					{
						flag3 = true;
						break;
					}
				}
				if (this.global1.science[6] && this.global1.science[8] && (this.global1.data[135] > 7 || !flag3 || this.global1.data[114] != 100))
				{
					this.text_fake += this.yug1.science_text[44];
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(79);
					}
				}
				else if (this.global1.science[6] && this.global1.science[8])
				{
					this.text_fake += this.yug1.science_text[45];
				}
				else
				{
					this.text_fake += this.yug1.science_text[46];
				}
			}
			else
			{
				if ((this.global1.data[42] == 2 && this.global1.science[1]) || this.global1.science[2])
				{
					this.text_fake = "Благодаря прагматичному руководству правительства Министерство Внутренних дел нашей страны претерпело серьёзные реформы, в результате которых удалось создать работоспособную систему милиции, что, в свою очередь, гарантировало безопасность и спокойную жизнь нашим гражданам. А успешные реформы в области разведки и зарубежной агентуры позволили усилить влияние наших спецслужб на мировой арене.|";
				}
				else
				{
					this.text_fake = "|Достижений нет.|";
				}
				if (this.global1.science[5])
				{
					this.text_fake += "За последние несколько лет наша страна смогла нарастить темпы экономического роста и начать курс на промышленную индустриализацию. Проведение форсированного строительства фабрик позволило увеличить потенциал нашей экономики и заметно усилило нашу роль в глобальном мировом хозяйстве. Вследствие этого мы смогли преодолеть отставание от более развитых стран, начав стремительное движение к построению индустриального общества.|";
				}
				else
				{
					this.text_fake += "|Достижений нет.|";
				}
				if ((this.global1.data[42] != 9 && this.global1.data[42] != 10 && this.global1.data[42] != 6 && this.global1.data[42] != 5 && this.global1.data[42] != 2 && this.global1.science[5] && this.global1.science[7]) || this.global1.science[8])
				{
					this.text_fake += "|Правительству нашей страны удалось провести успешную аграрную реформу, которая значительно улучшила продуктивность сельского хозяйства и техническую оснащённость сельхоз-предприятий. Логическим результатом этого был рост производства и потребления продовольствия на душу населения, что весьма положительно повлияло на уровень жизни и здоровье наших граждан.|";
				}
				else
				{
					this.text_fake += "|Достижений нет.|";
				}
			}
		}
		else if (this.this_okno == 6 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			this.Name.text = this.yug1.science_text[47];
			bool flag4 = false;
			for (int num = 0; num < this.yug1.gameState.yugcountries.Length; num++)
			{
				if (this.yug1.gameState.yugcountries[num].is_exist && num != this.yug1.gameState.player)
				{
					flag4 = true;
					break;
				}
			}
			if (this.global1.science[9] && (this.global1.data[135] > 7 || !flag4 || this.global1.data[114] != 100))
			{
				this.text_fake = this.yug1.science_text[48];
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(78);
				}
			}
			else if (this.global1.science[9])
			{
				this.text_fake = this.yug1.science_text[49];
			}
			else
			{
				this.text_fake = this.yug1.science_text[50];
			}
		}
		else if (this.this_okno == 6)
		{
			this.Name.text = "ЯДЕРНЫЕ ДОСТИЖЕНИЯ";
			this.text_fake = "";
			if (this.global1.science[9] && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[22] > 500)
			{
				this.text_fake = "Видя, как легко можно перекроить мир и понимая необходимость защиты нашего суверенитета своими силами, мы приняли решение о разработке ядерного оружия. Получив технологии и сырьё, мы успешно завершили разработку, создав своё ядерное оружие, и гордо заявили об этом миру. Это вызвало немалый переполох, однако никто уже не мог ничего поделать. Теперь любая страна будет с нами считаться, а враг дважды подумает перед тем, как нападать на нас.|";
			}
			else if (this.global1.science[9] && this.global1.allcountries[this.global1.data[0]].Vyshi)
			{
				this.text_fake = "Видя, как легко можно перекроить мир и понимая необходимость защиты нашего суверенитета своими силами, мы приняли решение о разработке ядерного оружия. Мы получили технологии и сырьё, однако Запад, догадываясь о наших планах, не пожелал иметь конкурента. К нам была направлена комиссия МАГАТЭ, которая обнаружила наши разработки. Под мировым давлением, давлением партаппарата и поднявшего голову диссидентского движения, нам пришлось отказаться от военной ядерной программы, а все наши объекты мирного атома теперь жёстко контролируются МАГАТЭ.|";
			}
			else if (this.global1.science[9])
			{
				this.text_fake = "Видя, как легко можно перекроить мир и понимая необходимость защиты нашего суверенитета своими силами, мы приняли решение о разработке ядерного оружия. Мы получили технологии и сырьё, однако Запад, чьи ценности мы так старательно перенимали, догадываясь о наших планах, не пожелал иметь конкурента. К нам была направлена комиссия МАГАТЭ, которая обнаружила наши разработки. Под мировым давлением, не в силах противостоять ему из-за созданной нами свободы, нам пришлось отказаться от военной ядерной программы, а все наши объекты мирного атома теперь жёстко контролируются МАГАТЭ.|";
			}
			else
			{
				this.text_fake = "|Достижений в развитии ядерного оружия - нет.";
			}
			if (this.global1.allcountries[10].Stasi)
			{
				if (this.global1.iron_and_blood && !this.global1.science[9] && this.global1.science_time[9] <= 0)
				{
					this.achieves.GetComponent<achievements>().Set(23);
				}
				this.text_fake += "|По нашим новейшим сведениям известия о том, что КНДР не просто обладает ядерным оружием, а активно его наращивает и испытывает, производит ракеты большей дальности (бахвальствуя о том, что они скоро смогут долетать до всех городов мира), а также работает над разработкой водородного оружия, повергли весь мир в шок и ужас. Американский Президент Джордж Буш младший уже объявил Северную Корею мировой угрозой, а в Южной Корее теперь постоянно проходят южнокорейско-японско-американские учения. ООН требует от КНДР прекращения разработки водородного оружия и замораживания всех военных ядерных разработок. Северная Корея же требует прекращения провокаций на границах и вывода американских военных учреждений, ракет и ПРО, с территории Южной Кореи.|После денонсации мирного договора на Корейском полуострове вновь началось огромное напряжение... Но, кажется, новой войны хотят избежать все.";
			}
		}
		else if (this.this_okno == 7)
		{
			this.Name.text = "СОЦИАЛИСТИЧЕСКИЙ ЛАГЕРЬ";
			this.text.text = "";
			for (int num2 = 2; num2 < this.global1.allcountries.Length; num2++)
			{
				if (this.global1.allcountries[num2] != null && num2 != this.global1.data[0] && num2 != 8 && num2 != 7 && num2 != 21 && num2 != 12 && num2 != 15 && num2 != 37 && num2 != 31 && num2 != 45 && num2 != 48 && num2 != 49 && num2 != 50 && num2 != 51 && num2 != 17 && num2 != 39 && num2 != 24 && num2 != 32 && num2 != 25 && (num2 < 40 || num2 > 43))
				{
					TextMesh textMesh41 = this.text;
					textMesh41.text = textMesh41.text + "<color=brown>" + this.global1.allcountries[num2].name + ":</color>";
					if (this.global1.allcountries[num2].subideology == 0)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh42 = this.text;
							textMesh42.text += "<color=black> Left nationalism,</color>";
						}
						else
						{
							TextMesh textMesh43 = this.text;
							textMesh43.text += "<color=black> Левый национализм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 1)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh44 = this.text;
							textMesh44.text += "<color=black> National-Bolshevism,</color>";
						}
						else
						{
							TextMesh textMesh45 = this.text;
							textMesh45.text += "<color=black> Национал-большевизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 2)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh46 = this.text;
							textMesh46.text += "<color=black> Pro-market dictatorship,</color>";
						}
						else
						{
							TextMesh textMesh47 = this.text;
							textMesh47.text += "<color=black> Рыночная диктатура,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 3)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh48 = this.text;
							textMesh48.text += "<color=black> Third way,</color>";
						}
						else
						{
							TextMesh textMesh49 = this.text;
							textMesh49.text += "<color=black> Третий путь,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 4)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh50 = this.text;
							textMesh50.text += "<color=purple> Conservative Socialism,</color>";
						}
						else
						{
							TextMesh textMesh51 = this.text;
							textMesh51.text += "<color=purple> Консервативный социализм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 5)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh52 = this.text;
							textMesh52.text += "<color=purple> Trotskyism,</color>";
						}
						else
						{
							TextMesh textMesh53 = this.text;
							textMesh53.text += "<color=purple> Троцкизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 6)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh54 = this.text;
							textMesh54.text += "<color=purple> Maoism,</color>";
						}
						else
						{
							TextMesh textMesh55 = this.text;
							textMesh55.text += "<color=purple> Маоизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 7)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh56 = this.text;
							textMesh56.text += "<color=purple> Antirevisionism,</color>";
						}
						else
						{
							TextMesh textMesh57 = this.text;
							textMesh57.text += "<color=purple> Антиревизионизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 8)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh58 = this.text;
							textMesh58.text += "<color=green> Democratic socialism,</color>";
						}
						else
						{
							TextMesh textMesh59 = this.text;
							textMesh59.text += "<color=green> Демократический социализм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 9)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh60 = this.text;
							textMesh60.text += "<color=green> Left social-democracy,</color>";
						}
						else
						{
							TextMesh textMesh61 = this.text;
							textMesh61.text += "<color=green> Левая социал-демократия,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 10)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh62 = this.text;
							textMesh62.text += "<color=green> Red tory,</color>";
						}
						else
						{
							TextMesh textMesh63 = this.text;
							textMesh63.text += "<color=green> Красный торизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 11)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh64 = this.text;
							textMesh64.text += "<color=green> Political pragmatism,</color>";
						}
						else
						{
							TextMesh textMesh65 = this.text;
							textMesh65.text += "<color=green> Политический прагматизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 12)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh66 = this.text;
							textMesh66.text += "<color=blue> Centrism,</color>";
						}
						else
						{
							TextMesh textMesh67 = this.text;
							textMesh67.text += "<color=blue> Центризм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 13)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh68 = this.text;
							textMesh68.text += "<color=blue> Right social-democracy,</color>";
						}
						else
						{
							TextMesh textMesh69 = this.text;
							textMesh69.text += "<color=blue> Правая социал-демократия,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 14)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh70 = this.text;
							textMesh70.text += "<color=blue> Liberal-conservative,</color>";
						}
						else
						{
							TextMesh textMesh71 = this.text;
							textMesh71.text += "<color=blue> Либерал-консерватизм,</color>";
						}
					}
					else if (this.global1.allcountries[num2].subideology == 15)
					{
						if (PlayerPrefs.GetInt("language") == 0)
						{
							TextMesh textMesh72 = this.text;
							textMesh72.text += "<color=blue> Euroatlanticism,</color>";
						}
						else
						{
							TextMesh textMesh73 = this.text;
							textMesh73.text += "<color=blue> Евроатлантизм,</color>";
						}
					}
					if (this.global1.allcountries[num2].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						TextMesh textMesh74 = this.text;
						textMesh74.text += "<color=blue> проамериканизм.</color>\n";
					}
					else if (this.global1.allcountries[num2].Vyshi && this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						TextMesh textMesh75 = this.text;
						textMesh75.text += "<color=blue> партнёр по НАТО.</color>\n";
					}
					else if (this.global1.allcountries[num2].isOVD && this.global1.allcountries[num2].Torg)
					{
						TextMesh textMesh76 = this.text;
						textMesh76.text += "<color=magenta> близкий союзник.</color>\n";
					}
					else if (this.global1.allcountries[num2].isOVD)
					{
						TextMesh textMesh77 = this.text;
						textMesh77.text += "<color=purple> друг.</color>\n";
					}
					else if (this.global1.allcountries[num2].isSEV)
					{
						TextMesh textMesh78 = this.text;
						textMesh78.text += "<color=teal> экономический партнёр.</color>\n";
					}
					else if (this.global1.allcountries[num2].Torg)
					{
						TextMesh textMesh79 = this.text;
						textMesh79.text += "<color=olive> торговый партнёр.</color>\n";
					}
					else
					{
						TextMesh textMesh80 = this.text;
						textMesh80.text += "<color=black> сохраняет нейтралитет.</color>\n";
					}
				}
			}
			this.this_done_done = true;
		}
		else if (this.this_okno == 8)
		{
			this.Name.text = "СВОДКИ ПО МИРУ";
			this.text_fake = "";
			if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
			{
				if (this.global1.data[59] != 2 && this.global1.allcountries[this.global1.data[0]].isOVD && (this.global1.allcountries[5].isOVD || this.global1.allcountries[6].isOVD) && (this.global1.data[54] >= 7 || (this.global1.allcountries[15].isOVD && this.global1.data[54] >= 5)) && !this.global1.allcountries[15].Help)
				{
					this.text_fake = "|<color=purple>Социалистическая Федеративная Республика Югославия</color>|";
					this.text_fake += "Американское предложение о вмешательстве в гражданскую войну в <color=purple>Югославии</color> было заблокировано некоторыми странами-членами Совбеза ООН, вследствие чего, благодаря нашей поддержке и поддержке со стороны нашего военного альянса, Милошевич и сербские государства смогли одержать победу в долгом и кровопролитном противостоянии. Югославия осталась целой и невредимой, хоть и перейдя окончательно к государственному капитализму и буржуазной демократии, во главе с Социалистической Партией и Милошевичем.";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(31);
					}
				}
				else if (this.global1.data[54] >= 2 && !this.global1.allcountries[15].Help)
				{
					this.text_fake = "|<color=purple>Союзная Республика Югославия</color>|";
					this.text_fake += "В ходе гражданской войны в <color=purple>Югославии</color>, Милошевичу все же пришлось растаться с сепаратистами и перестать оказывать помощь сербским борцам. Однако, поддерживая связь с нами и другими странами-друзьями обновленной Югославии, новое государство получало множество помощи, в том числе и военной, а Милошевич лично получил поддержку наших спецслужб во время Бульдозерной революции и смог удержать власть, а американцы не решились на более глубокое вмешательство. А войны за Косово так и не произошло, как и бомбардировок НАТО - конфликт был подавлен в максимально быстрые сроки.";
				}
				else
				{
					this.text_fake = "|<color=purple>Распад Югославии</color>|";
					this.text_fake += "В ходе гражданской войны, <color=purple>Югославии</color> все же пришлось растаться со своими республиками и перестать оказывать помощь сербским борцам за суверенитет. А затем и пережить страшные бомбардировки авиации НАТО из-за проблем в Косово, приведшие к многочисленной гибели среди гражданского населения. Следующим шагом стала Бульдозерная революция и падение режима Милошевича, а вместе с ним и постепенный развал остатка Югославии.";
				}
			}
			if (this.global1.event_done[1079] && (this.global1.allcountries[17].Gosstroy == 1 || this.global1.allcountries[7].paths == 3))
			{
				if (this.global1.allcountries[17].Gosstroy == 1)
				{
					this.text_fake += "||<color=purple>Суверенная Федеративная Республика Германия</color>";
					this.text_fake += "|Блок левых партий смог успешно удерживать власть в Германии на протяжении всех 90-х годов. Успешная социальная политика, вкупе с введением элементов «шведского социализма», расширением прав профсоюзов и поддержкой производства в восточных землях, требовали больших финансовых вливаний. В плане внешней политики, объединенная Германия стала дистанцироваться от НАТО, выйдя из его политических структур. Однако повышение налогов и дополнительные кредиты серьёзно ударили по среднему и высшему классу, поэтому на выборах 2000 года ХДС набрала 35% голосов и вместе с либералами сформировала новое правоцентристское правительство во главе с Фолькером Каудером, который пообещал \"бороться не только с левыми экономическими идеями, но и левыми социально-общественными идеями\", а также пообещал \"защищать суваеренитет ФРГ\" и призвал США \"отказаться от поведения глобальной доминации\".";
				}
				else if (this.global1.allcountries[7].paths == 3)
				{
					this.text_fake += "||<color=purple>Удар Воротникова по ФРГ</color>";
					this.text_fake += "|После воссоединения Германии Советский Союз настоял на пересмотре ряда договоров, в том числе «Два плюс четыре». Советский министр иностранных дел Юлий Воронцов выдвинул ноту западным державам, обвинив ФРГ в саботаже вывода советских войск с её территории. На новой международной конференции СССР потребовал предоставить контроль советской комиссии за выводом войск и выдвинул ряд следующих требований: ФРГ выходит из НАТО и закрепляет в конституции статус нейтральной державы, Советскому Союзу списываются все долги. В случае невыполнения этих нот, СССР прекратит вывод войск с территории Восточной Германии и передаст управление районом своей администрации. В западной печати против СССР развернулась кампания с обвинениями в агрессии, однако Германии пришлось отступить и выполнить требования, чтобы остаться целым и суверенным государством.";
				}
			}
			else if (this.global1.data[0] == 1 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && ((this.global1.allcountries[17].Westalgie >= 350 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[7].isOVD) || (((this.global1.allcountries[17].Westalgie >= 400 && this.global1.allcountries[16].Gosstroy == 0) || this.global1.allcountries[17].Westalgie >= 450) && this.global1.allcountries[this.global1.data[0]].isSEV && (this.global1.allcountries[17].Westalgie >= 550 || this.global1.allcountries[7].isSEV))))
			{
				this.text_fake += "||<color=purple>Обновлённая Федеративная Республика Германия</color>";
				this.text_fake += "|<color=purple>В ФРГ</color>, в ходе реформации социалистического мира, падения пелены красной угрозы и расцвета идеи всемирной дружбы на очередных выборах одержала победу коалиция левых сил, выступавшая за пацифизм, социальные реформы, дружбу и мир. Следствием её победы стало не простое налаживание отношений с ГДР и признание Западного Берлина демилитаризованной зоной: Федеративная Республика объявила о выходе из военных структур НАТО, оставшись лишь в политических, и, вместе с ГДР, вывела со своих территорий иностранные военные базы, подписав договора о не нахождении на территории обоих Германий чьих-либо войск или ракет, и о безъядерном статусе ФРГ. Это было поддержано и СССР и Францией, которая также одобрила выступления нового германского руководства за усиление экономической интеграции в Западной Европе, итогом чего, несмотря на недовольство новой политикой со стороны Великобритании и США, становится формирование Европейского Союза.";
			}
			else if (this.global1.allcountries[1].Gosstroy != 2 && !this.global1.allcountries[7].Vyshi)
			{
				this.text_fake += "||<color=purple>Федеративная Республика Германия</color>";
				this.text_fake += "|После неудачной попытки <color=purple>объединения Германии</color> Гельмут Коль проиграл борьбу в ФРГ за канцлерский пост в 1994. К власти пришла коалиция социал-демократов и зелёных во главе с Герхардом Шрёдером с обещаниями модернизации экономики, поддержки предпринимательства, сохранения системы социальной защиты и обеспечения более суверенной внешней политики. Следствием этого стало налаживание более дружественных отношений с СССР и новый виток разрядки в отношениях с ГДР.";
			}
			else if (this.global1.allcountries[1].Gosstroy != 2)
			{
				this.text_fake += "||<color=purple>Федеративная Республика Германия</color>";
				this.text_fake += "|После неудачной попытки <color=purple>объединения Германии</color> Гельмут Коль проиграл борьбу в ФРГ за канцлерский пост в 1994. К власти пришла коалиция социал-демократов и зелёных во главе с Герхардом Шрёдером с обещаниями модернизации экономики, поддержки предпринимательства, сохранения системы социальной защиты и обеспечения более суверенной внешней политики. Следствием этого стало налаживание более дружественных отношений с Россией и новый виток разрядки в отношениях с ГДР.";
			}
			else
			{
				this.text_fake += "||<color=purple>Единая Федеративная Республика Германия</color>";
				this.text_fake += "|Восточная Германия пала и теперь <color=purple>немецкий народ стал един</color>. Однако, это не решило множество проблем, которые были как и в ГДР, так и <color=purple>в ФРГ</color>. Германии еще предстоит много чего пережить.";
			}
		}
		else if (this.this_okno == 9)
		{
			this.Name.text = "СВОДКИ ПО МИРУ";
			this.text_fake = "";
			this.text_fake = "<color=purple>Греция</color>|";
			if (this.global1.allcountries[45].Gosstroy <= 1 && this.global1.allcountries[45].isSEV && !this.global1.allcountries[7].isOVD && this.greece_ally > 6)
			{
				this.text_fake += "Правящая греческая коалиция социалистов и коммунистов смогла успешно пережить проблемы социалистического лагеря конца XX века и, при нашей всецелой поддержке, наконец-то вывести страну из НАТО, объявив о своём нейтралитете и отказе от размещения ядерного оружия.|Сохраняя с нами экономические контакты Греция продолжает быть членом нашего Экономического альянса, несмотря на предложения о вступлении Греции в новосформированный Европейский Союз.";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(44);
				}
			}
			else if (this.global1.allcountries[45].Gosstroy <= 1 && this.global1.allcountries[45].isSEV && !this.global1.allcountries[7].isOVD && this.greece_ally <= 5)
			{
				this.text_fake += "Правящая греческая коалиция социалистов и коммунистов смогла успешно пережить проблемы социалистического лагеря конца XX века и, при нашей всецелой поддержке, наконец-то вывести страну из НАТО, объявив о своём нейтралитете и отказе от размещения ядерного оружия.|Несмотря на имеющиеся с нами экономические контакты, Греция принимает решение о вступлении в Европейский Союз под лозунгом страны-посредника между Востоком и Западом. Связи с нами они не обрывают, но всё же...";
			}
			else if (this.global1.allcountries[45].Gosstroy <= 1)
			{
				this.text_fake += "На следующий выборах греческая коалиция социалистов и коммунистов, после громкого скандала, развалилась, а власть в социалистической партии перешла к правоцентристскому крылу.|Несмотря на имеющиеся с нами экономические контакты, Греция принимает решение о вступлении в Европейский Союз под лозунгом страны-посредника между Востоком и Западом. Связи с нами они не обрывают, но всё же... ";
			}
			else
			{
				this.text_fake += "Греция продолжает оставаться членом НАТО и начинает принимать участие в формировании Европейского Союза.";
			}
			if (this.global1.data[37] >= 8 && this.global1.data[0] != 12 && !this.global1.allcountries[7].Vyshi && (this.global1.allcountries[7].isSEV || this.global1.allcountries[16].isSEV || this.global1.allcountries[19].Gosstroy <= 0) && this.global1.allcountries[31].Help)
			{
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(22);
				}
				this.text_fake += "||<color=purple>Демократическая Республика Афганистан</color>";
				this.text_fake += "|Постоянно оказываемая нами и всем социалистическим блоком помощь <color=purple>режиму Наджибуллы</color>, вместе с введением жестких санкций против Пакистана и осуждением пакистанских террористов даже со стороны Франции и Китая (после того как те совершили ряд терактов по всему миру) - стали окончательным поворотным моментом в истории Афганистана. А реформы Наджибуллы, легализовавшие мелких частников, лавочки и кустарщину, вместе с интеграцией афганских традиций и религии в государственную идеологию, закрепили власть социалистов в стране. Гражданская война окончена.";
			}
			else if (this.global1.allcountries[7].Gosstroy <= 1 && this.global1.data[0] != 12)
			{
				this.text_fake += "||<color=purple>Гражданская война в Афганистане</color>";
				this.text_fake += "|СССР продолжил существовать, оказывая гуманитарную и военную поддержку <color=purple>Афганистану</color>, что позволило облегчить его положение. Некоторые страны, опасаясь расширения исламских террористов начали оказывать давление на Пакистан, усложняя ему помощь террористам. А с Китаем удалось договориться и выработать единую позицию по прекращению поддержки террористов. И, хотя, разногласия в НДПА и армии ДРА не были улажены до конца, а политика Наджибуллы имела свои изъяны, наступления террористов удалось пресечь, а ДРА контролирует достаточно территорий, чтобы существовать дальше. Решающего перевеса не оказалось ни у одной из сторон, так что гражданская война в Афганистане продолжается.";
			}
			else if (this.global1.data[0] != 12)
			{
				this.text_fake += "||<color=purple>Исламское Государство Афганистан</color>";
				this.text_fake += "|После вывода советских войск положение <color=purple>Афганистана</color> начало стремительно ухудшаться - непоследовательная политика НДПА вместе с разногласиями в ней и в армейском руководстве привели к тому, что народ стал отворачиваться от Афганского правительства, а армия с трудом сдерживала натиск террористов. Оказавшись почти что в международной изоляции, Афганистан не мог получить поддержку извне, а Пакистан продолжал безнаказанно отправлять всё новые отряды исламистов. В апреле 1992 года террористы без боя вошли в Кабул, провозгласив Афганистан исламским государством. Все завоевания советской власти в социальной, экономической и правовой областях оказались уничтожены. А через 4 года и сам Наджибулла был зверски убит без суда и следствия.";
			}
		}
		else if (this.this_okno == 10)
		{
			this.Name.text = "СВОДКИ ПО МИРУ";
			this.text_fake = "";
			if (this.global1.allcountries[24].Stasi && this.global1.data[55] >= 2)
			{
				this.text_fake = "<color=purple>Социалистическая Республика Йемен</color>";
				this.text_fake += "|В ходе массового и быстрого развития нефтедобычи <color=purple>в НДРЙ</color>, страна стала новым крупным игроком на арене экспортёров нефти, следствием чего стало и увеличение как и нашей прибыли, так и оказания существенной дипломатической, политической и экономической помощи государствам-союзникам, имеющим одинаковые с нами и НДРЙ интересы. Мир стал прочнее. Для нас.";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(33);
				}
			}
			else if (this.global1.allcountries[24].Gosstroy == 0 && this.global1.allcountries[24].Stasi)
			{
				this.text_fake = "<color=purple>Народная Демократическая Республика Йемен</color>";
				this.text_fake += "|В ходе массовых чисток <color=purple>в НДРЙ</color> сохранилась консервативная традиционная власть, а из реформ были допущены лишь ИП, кооперативы и мелкие частники в сфере услуг, вместе с открытием нескольких СЭЗ. НДРЙ остается одним из наших основных союзников на Ближнем Востоке, вместе с этим он пытается начать развитие нефтедобычи, месторождения чего были обнаружены с советской помощью к концу 80х годов, но не были разработаны из-за её сворачивания.";
			}
			else
			{
				this.text_fake = "<color=purple>Единая Республика Йемен</color>";
				this.text_fake += "|<color=purple>Два Йемена</color> стали единым в обмен на передачу важных и крупных постов в правительстве деятелям режима социалистического Йемена и главенствующих постов деятелям буржуазного. Однако, такая шаткая коалиция продлилась не долго и, после окончательной потери влияния социалистического мира на эту территорию, политики бывшего НДРЙ были вышвырнуты со своих постов, а при попытке начать восстание из-за своего разочарования - подверглись преследованию. ";
			}
			this.text_fake += "|";
			if (this.global1.allcountries[21].Gosstroy != 1)
			{
				for (int num3 = 40; num3 < 44; num3++)
				{
					if (this.global1.allcountries[num3].Westalgie >= 1000)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num3].name + "</color>: В стране произошла стабилизация. Левая коалиция окончательно утвердила свою власть на всей территории страны, сформировав социалистическое правительство и социалистическую республику. Торжество социализма наступило.|";
					}
					else if (this.global1.allcountries[num3].Westalgie >= 600)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num3].name + "</color>: Произошла частичная стабилизация. Левая коалиция смогла взять власть в стране, сформировав режим Народной демократии, в то время как оппозиция всё еще существует и сеет смуту, а её радикализированное крыло продолжаёт партизанствовать.|";
					}
					else if (this.global1.allcountries[num3].Westalgie > 0)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num3].name + "</color>: Произошла частичная стабилизация. Правая коалиция смогла взять власть в стране, сформировав режим правой имитационной демократии, в то время как оппозиция всё еще существует и сеет смуту, а её радикализированное крыло продолжаёт партизанствовать.|";
					}
					else if (this.global1.allcountries[num3].Westalgie <= 0)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num3].name + "</color>: В стране произошла стабилизация. Правая коалиция окончательно утвердила свою власть на всей территории страны, сформировав либерально-демократическое правительство и капиталистическую республику. Торжество буржуазной демократии наступило.|";
					}
				}
			}
			else
			{
				this.text_fake += "Демократическому правительству удалось обуздать исламский фундаментализм и предотвратить назревающий кризис. В итоге, в <color=purple>Алжире</color> сложилась двухпартийная система аналогичная западной, где главенствующую роль играют социалисты и демократы. Тем не менее, несмотря на внутриполитическую стабилизацию, Алжир становится всё более и более зависимым от Франции, которая постепенно захватывает внутренний рынок страны своими товарами, с которыми местное производство конкурировать не может.|";
				for (int num4 = 41; num4 < 44; num4++)
				{
					if (this.global1.allcountries[num4].Westalgie >= 1000)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num4].name + "</color>: В стране произошла стабилизация. Левая коалиция окончательно утвердила свою власть на всей территории страны, сформировав социалистическое правительство и социалистическую республику. Торжество социализма наступило.|";
					}
					else if (this.global1.allcountries[num4].Westalgie >= 600)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num4].name + "</color>: Произошла частичная стабилизация. Левая коалиция смогла взять власть в стране, сформировав режим Народной демократии, в то время как оппозиция всё еще существует и сеет смуту, а её радикализированное крыло продолжаёт партизанствовать.|";
					}
					else if (this.global1.allcountries[num4].Westalgie > 0)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num4].name + "</color>: Произошла частичная стабилизация. Правая коалиция смогла взять власть в стране, сформировав режим правой имитационной демократии, в то время как оппозиция всё еще существует и сеет смуту, а её радикализированное крыло продолжаёт партизанствовать.|";
					}
					else if (this.global1.allcountries[num4].Westalgie <= 0)
					{
						this.text_fake = this.text_fake + "<color=purple>" + this.global1.allcountries[num4].name + "</color>: В стране произошла стабилизация. Правая коалиция окончательно утвердила свою власть на всей территории страны, сформировав либерально-демократическое правительство и капиталистическую республику. Торжество буржуазной демократии наступило.|";
					}
				}
			}
		}
		else if (this.this_okno == 11)
		{
			this.Name.text = "СОДРУЖЕСТВО";
			this.text_fake = "";
			if (this.global1.allcountries[7].isSEV && this.global1.allcountries[7].isOVD)
			{
				this.text_fake = "|<color=purple>Советское лидерство</color>";
				this.text_fake += "|Советский Союз продолжает оставаться неформальным лидером более реформированного социалистического лагеря, ведя за собой всех его членов к светлому будущему.";
			}
			else if (!this.global1.allcountries[7].isOVD && this.global1.allcountries[this.global1.data[0]].Vyshi)
			{
				this.text_fake = "|<color=purple>Новые соседи</color>";
				this.text_fake += "|После того, как Советский Союз отказался от доктрины Брежнева и позволил нам делать свой выбор, наше правительство решило интегрироваться к западным соседям. И теперь мы новый член семьи НАТО и Европейского Союза.";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(34);
				}
			}
			else
			{
				if (!this.global1.allcountries[7].isOVD)
				{
					this.text_fake = "|<color=purple>Военный договор</color>";
					this.text_fake = this.text_fake + "|Всего: " + this.military_ally.ToString();
					if (this.military_ally <= 2)
					{
						this.text_fake += " (маленький)|С падением Варшавского Договора мы стали более беззащитны, И, хотя, мы и пытались сколотить свой собственный военный альянс, но стоит признать, что вышло это из рук вон плохо. Наше влияние в мире осталось примерно столь же малым, что и было до разрыва Варшавского договора.";
					}
					else if (this.military_ally <= 5)
					{
						this.text_fake += " (средний)|С падением Варшавского Договора мы стали более беззащитны, И, хотя, мы и пытались сколотить свой собственный военный альянс, но стоит признать, что вышло намного лучше, чем могло быть. Наше влияние в мире намного расширилось после разрыва Варшавского договора и новый, хоть и малый, но крепкий блок стран готов защищать нас и друг друга.";
					}
					else
					{
						this.text_fake += " (большой)|С падением Варшавского Договора мы стали более беззащитны, но наши попытки сколотить свой собственный военный альянс, стоит признать, превысили ожидания даже самых оптимистичных наших партийцев. Благодаря нашим действиям мы смогли стать одной из новых весомых мировых сил, с которой другие страны начинают считаться.";
					}
				}
				else
				{
					this.text_fake = "|<color=purple>Военный договор</color>";
					this.text_fake += "|Советский Союз продолжает оставаться неформальным лидером более реформированного социалистического лагеря, ведя за собой всех его членов к светлому будущему.";
				}
				if (!this.global1.allcountries[7].isSEV)
				{
					this.text_fake += "|<color=purple>Экономический альянс</color>";
					this.text_fake = this.text_fake + "|Всего: " + this.economy_ally.ToString();
					if (this.economy_ally <= 4)
					{
						this.text_fake += " (маленький)|С роспуском Совета Экономической Взаимопомощи мы растеряли множество торговых партнёров, и, к сожалению, наша торговля так и не смогла восстановиться от столь подлого удара со стороны Советского Союза, а от СЭВ осталась лишь его блеклая тень.";
					}
					else if (this.economy_ally <= 7)
					{
						this.text_fake += " (средний)|С роспуском Совета Экономической Взаимопомощи мы растеряли множество торговых партнёров, однако, мы умудрились оправиться от столь подлого удара со стороны Советского Союза и восстановить наши торговые связи, сформировав крепкую альтернативу СЭВ.";
					}
					else
					{
						this.text_fake += " (большой)|С роспуском Совета Экономической Взаимопомощи мы растеряли множество торговых партнёров, однако, мы умудрились не только оправиться от столь подлого удара со стороны Советского Союза, но и расширить наши торговые связи, приобретая всё новых и новых экономических партнёров, сформировав не менее широкую и крепкую альтернативу СЭВ.";
					}
				}
				else
				{
					this.text_fake += "|<color=purple>Экономический альянс</color>";
					this.text_fake += "|Совет Экономической Взаимопомощи, несмотря на прекращение оказания льгот и помощи Советского Союза, благодаря создаваемым десятилетиями крепким экономическим связям, смог реформироваться и удержать свою нишу в глобальной экономической системе, оставясь всё той же альтернативой западному содружеству.";
				}
			}
			if (this.global1.data[59] == 1 && this.global1.data[0] == 5 && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[42] != 7)
			{
				this.text_fake += "||Советский Союз распался, после чего Приднестровье увтердило собственный суверенитет и объявило себя настоящей Молдавией. Начался вооружённый конфликт, в который поспешили вмешаться мы - ударив ничего не подозревающим молдаванам в тыл, мы быстро овладели ключевыми городами и скоординировали свои действия с гагаузами, приднестровцами и русскими добровольцами. Под плотным надзором Секуритате референдум в Молдавии подавляющим большинством голосов утвердил вхождение Молдавии в состав Румынии, Приднестровье было признано настоящей Молдавией, Гагаузия получила независимость и они стали нашими друзьями, а бывшие молдаване были объявлены бессарабами-румынами. Вскоре и все наши союзники признали это, несмотря на протесты с Запада, тогда как России было плевать.";
				if (this.global1.iron_and_blood && this.global1.data[60] == 6)
				{
					this.achieves.GetComponent<achievements>().Set(39);
				}
			}
			else if (this.global1.data[59] == 1 && this.global1.data[0] == 5)
			{
				this.text_fake += "||Советский Союз распался, после чего Приднестровье увтердило собственный суверенитет и объявило себя настоящей Молдавией. Начался вооружённый конфликт, в который поспешили вмешаться мы - ударив ничего не подозревающим молдаванам в тыл, мы быстро овладели ключевыми городами и скоординировали свои действия с гагаузами, приднестровцами и русскими добровольцами. Однако вскоре, под давлением международной общественности, мы были вынуждены вывести войска из Молдавии, гарантировав её суверенитет. Ну хотя бы Гагаузия и Приднестровье получили независимость и стали нашими верными друзьями-союзниками.";
			}
		}
		else if (this.this_okno == 12 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			this.Name.text = "ОСОБЫЕ ИТОГИ";
			this.text_fake = "";
			if (this.global1.data[135] <= 4)
			{
				this.global1.data[161] = 0;
			}
			else if (this.global1.data[131] != 1 && this.yug1.gameState.modifies[5] <= 0 && this.yug1.gameState.modifies[4] <= 0)
			{
				if (this.global1.data[126] == 0 && this.global1.data[115] <= 4)
				{
					this.global1.data[161] = 0;
				}
				else if (this.global1.data[126] == 0 && (this.global1.data[126] != 0 || this.global1.data[115] < 16))
				{
					this.global1.data[161] = 0;
				}
			}
			if (this.global1.data[161] == 4 && this.global1.data[114] != 100)
			{
				if (this.global1.allcountries[7].isOVD && this.global1.event_done[62])
				{
					this.text_fake = this.dlce1.credits_text[220];
					this.text_fake += this.dlce1.credits_text[229];
				}
				else if ((this.global1.allcountries[15].Gosstroy == 0 && this.global1.allcountries[6].Gosstroy != 2 && this.global1.allcountries[5].Gosstroy != 2 && this.global1.allcountries[4].Gosstroy != 2 && this.global1.allcountries[3].Gosstroy != 2 && this.global1.allcountries[2].Gosstroy != 2 && this.global1.allcountries[7].Gosstroy == 2 && this.global1.data[148] != 1 && this.global1.data[0] == 49) || (this.global1.data[136] != 1 && this.global1.data[0] == 50) || (this.global1.data[118] != 1 && this.global1.data[0] == 51))
				{
					this.text_fake = this.dlce1.credits_text[221];
					this.text_fake += this.dlce1.credits_text[230];
				}
				else if ((this.global1.allcountries[15].Gosstroy == 9 && this.global1.allcountries[6].Gosstroy != 2 && this.global1.allcountries[5].Gosstroy != 2 && this.global1.allcountries[4].Gosstroy != 2 && this.global1.allcountries[3].Gosstroy != 2 && this.global1.allcountries[2].Gosstroy != 2 && this.global1.allcountries[7].Gosstroy == 2 && this.global1.data[148] == 1 && this.global1.data[0] == 49) || (this.global1.data[136] == 1 && this.global1.data[0] == 50) || (this.global1.data[118] == 1 && this.global1.data[0] == 51))
				{
					this.text_fake = this.dlce1.credits_text[222];
					this.text_fake += this.dlce1.credits_text[231];
				}
				else if (this.global1.allcountries[15].Gosstroy == 2 && this.global1.allcountries[6].Gosstroy != 0 && this.global1.allcountries[5].Gosstroy != 0 && this.global1.allcountries[4].Gosstroy != 0 && this.global1.allcountries[3].Gosstroy != 0 && this.global1.allcountries[2].Gosstroy != 0 && this.global1.allcountries[6].isSEV && this.global1.allcountries[5].isSEV && this.global1.allcountries[4].isSEV && this.global1.allcountries[3].isSEV && this.global1.allcountries[2].isSEV && this.global1.allcountries[7].Gosstroy == 2 && !this.global1.allcountries[7].isSEV)
				{
					this.text_fake = this.dlce1.credits_text[223];
					this.text_fake += this.dlce1.credits_text[232];
				}
				else if (this.global1.allcountries[15].Gosstroy == 2 && this.global1.allcountries[7].Gosstroy == 2)
				{
					this.text_fake = this.dlce1.credits_text[224];
					this.text_fake += this.dlce1.credits_text[233];
				}
				else if (this.global1.allcountries[6].isSEV && this.global1.allcountries[5].isSEV && this.global1.allcountries[4].isSEV && this.global1.allcountries[3].isSEV && this.global1.allcountries[2].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)
				{
					this.text_fake = this.dlce1.credits_text[225];
					this.text_fake += this.dlce1.credits_text[234];
				}
				else if (this.global1.allcountries[15].isSEV && !this.global1.allcountries[7].isSEV)
				{
					this.text_fake = this.dlce1.credits_text[226];
					this.text_fake += this.dlce1.credits_text[235];
				}
			}
			else if (this.yug1.gameState.yugcountries[0].is_independent && this.yug1.gameState.yugcountries[1].is_independent && this.global1.data[126] == 1 && this.global1.data[161] == 1 && this.global1.allcountries[45].Gosstroy < 2)
			{
				this.text_fake = this.dlce1.credits_text[227];
				this.text_fake += this.dlce1.credits_text[236];
			}
			else if (this.global1.data[161] == 1)
			{
				this.text_fake = this.dlce1.credits_text[117];
				this.text_fake += this.dlce1.credits_text[118];
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(80);
				}
			}
			else
			{
				this.text_fake = "Ничего особенного";
			}
		}
		else if (this.this_okno == 12)
		{
			this.Name.text = "ОСОБЫЕ ИТОГИ";
			this.text_fake = "";
			if (this.global1.data[0] == 20 && this.global1.data[56] >= 100)
			{
				if (this.global1.data[11] == 0)
				{
					this.text_fake += "||<color=purple>Центр исламского социализма";
					this.text_fake += "|</color>Неджмие Ходжа стала первой женщиной лидером религиозного государства в истории, наглядно показав тем самым всю прогрессивность исламского социализма, в котором соединяется лучшее из учений основоположников мусульманской религии и достижений самого человечного и справедливого из всех возможных строев, которые повидал мир, - социализма. Религия и идеология объединились, прекратив свою вражду и тем самым доказав, что стремление к миру и процветанию является частью природы человека. Имамы и рьяные проповедники не дают разрастаться коррупции, а народ находит свое утешение в религии или идеологии партии, сблизившейся со своим народом. ";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(52);
					}
				}
				else if (this.global1.data[11] == 2)
				{
					this.text_fake += "||<color=purple>Исламская Республика Албания";
					this.text_fake += "|</color>Перестройка в Албании пошла по пути Ирана. Внутриполитические последствия революции проявились в установлении в стране теократического режима мусульманского духовенства, повышении роли ислама абсолютно во всех сферах жизни. Страну возглавил Президент, установились буржуазная демократия и расширились гражданские свободы, однако религиозные деятели получили особые права. Например, они коллективно могут наложить вето на любой закон светской власти или же представить свой законопроект, который светская власть обязана принять. Опора на религию позволила АПТ переродиться и пережить суровый кризис, открывшись всему миру. Были налажены теплые отношения с Турцией, Арабскими странами и Ираном. Пусть жизнь по законам Шариата и ограничивает права граждан и народов, но это куда лучше, чем полная самоизоляция, да и новые друзья Албании рады приветствовать ее в рядах стран, несущих слово ислама в этот мир.";
				}
				if (this.global1.iron_and_blood && this.global1.data[62] > 4)
				{
				}
			}
			else if (this.global1.data[0] == 18)
			{
				if (this.global1.iron_and_blood && this.global1.data[14] <= 3 && this.global1.data[11] == 2 && this.global1.allcountries[44].Torg && this.global1.allcountries[44].Gosstroy <= 1)
				{
					this.achieves.GetComponent<achievements>().Set(62);
				}
				if (this.global1.allcountries[7].Gosstroy == 0 && this.global1.data[10] >= 800 && this.global1.data[14] <= 1 && this.global1.regions[1].buildings[0].type == 23)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(61);
					}
					this.text_fake += "||<color=purple>Второй Карибский Кризис";
					this.text_fake += "|</color>Виктору Алкснису удалось уничтожить сепаратизм в советских республиках и предотвратить распад социалистического лагеря. Однако после окончания гонки вооружений и холодной войны, отношения между двумя странами вновь обострились. Жёсткая политика Алксниса по отношению к странам Восточного блока, привела к ответным мерам со стороны США, которые, в свою очередь, начали программу усиленного переоснащения ракетных установок в странах Запада, что в особенности коснулось ФРГ и Турцию. Президент США Джордж Буш потребовал от Советского Союза немедленного вывода войск с территории стран Варшавского Договора, а также пригрозил военной интервенцией для «восстановления демократии». Симметричный ответ СССР не заставил себя долго ждать: по секретным маршрутам, под видом конвоев с продовольственной помощью, на Кубу поступили советские новейшие ракеты.Через некоторое время, американские самолёты-разведчики, несмотря на строгую секретность всего мероприятия, обнаружили близ советской военной базы военных, которые занимались установкой этих самых ракет. Новый Карибский кризис вновь повис над миром, но на этот раз ситуация была гораздо серьёзней. Однако в итоге Джорджу Бушу пришлось пойти на уступки, прекратив милитаризацию и учения в странах НАТО, а СССР снова вывел свои ракеты с Кубы. Дата начала Третьей Мировой войны вновь перенеслась, но надолго ли?!";
				}
				else if (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.data[77] > 0)
				{
					this.text_fake += "||<color=purple>Остров социализма";
					this.text_fake += "|</color>После распада Советского союза Куба стала круглой социалистической  сиротой в Латинской Америке. В 1992 Соединённые штаты Америки, ставшие гегемоном мировой политики, начали проводить свою «демократическую» политику и серьёзно ужесточили санкции  против нас. Потерю братских стран-союзников Куба перенесла большими потерями, однако в окружении врагом смогла выстоять и в новом XXI продолжить развитие, при поддержке победившего на выборах в Венесуэле военного Уго Чавеса и боливийского социалиста Эво Моралес, доставив своим союзом немало хлопот США.";
				}
				else if ((this.global1.allcountries[7].isSEV || this.global1.allcountries[7].isOVD) && (this.global1.data[77] > 0 || this.global1.is_gkchp))
				{
					this.text_fake += "||<color=purple>Передний рубеж";
					this.text_fake += "|</color>Социалистический лагерь продолжил существовать и сотрудничать с Кубой, благодаря чему экономический кризис прошёл в более лёгкой форме, а попытки ужесточить американские санкции против Кубы были осуждены Восточным блоком и Организацией Объединенных наций. Кубинская революция продолжается. Вива Куба!";
				}
				else if (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.data[77] == 0)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(60);
					}
					this.text_fake += "||<color=purple>Реставрация";
					this.text_fake += "|</color>На фоне ухудшения положения в социалистическом лагере нам пришлось вернуться к идее сотрудничества с теми, с кем мы и собирались до дружбы с Хрущёвым, - Соединёнными Штатами Америки. Благодаря потеплению отношений между нашими странами, торговое эмбарго было снято, что спасло нашу стагнирующую экономику от полного краха. Теперь всё вернулось на свои места – Куба вновь вотчина США, которую толпами посещают американские туристы. Под давлением Президента Буша нам пришлось допустить американских инвесторов в нашу страну. Теперь на Кубе вновь появляется монополия США на производство сахара и табака, а также массовое распространение снова получили бордели и игорный бизнес, с которыми полиция острова ведёт «вязкую борьбу». Некоторые журналисты, которых пришлось арестовать из-за ложных обвинений в адрес правительства, называют лидера страны Очоа «Новым Батистой» и «предателем дел Кубинской революции», но как же они неправы!  ";
				}
				else if (this.global1.data[45] != 5 && this.global1.data[77] == 0)
				{
					this.text_fake += "||<color=purple>Реновация";
					this.text_fake += "|</color>Социалистический лагерь продолжил своё существование, однако под давлением Горбачёва нам всё же пришлось пойти на переговоры с Соединёнными штатами Америки, в результате которых эмбарго было снято. Теперь для нашей экономики наступила новая эпоха, энергетический кризис постепенно закончился, а развитие туристической отрасли, под бдительным контролем государства, смогло увеличить приток туристов со всего мира, что для нас только плюс.";
				}
				if (this.global1.data[171] == 100)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(105);
					}
					this.text_fake += "|<color=purple>Карибская Германия</color>";
					this.text_fake += "|В дальнейшем, существование «второй» ГДР признали только дружественные нам правительства Уго Чавеса в Венесуэле и Эво Моралеса в Боливии, а также другие непризнанные государства: Эритрея, Западная Сахара, Сомалиленд, Амбазония, Мексиканские Сапатистские Автономные Муниципалитеты, государства Шан, Качин и Ва, и некоторые микрогосударства. Страны Запада же активно препятствуют нашим и северокорейским попыткам добиться восстановления членства ГДР в ООН. После смерти Эриха Хонеккера, Председателем Народной палаты стал Эрих Мильке, а после его смерти власть в микрогермании перешла в руки Зигмунда Йена. В 1998 году ураган Митч нанёс крупный урон острову (в том числе был разбит бюст Эрнста Тельмана), но Йен не только смог преимущественно своими силами восстановить разрушения, но и превратил остров в туристический центр, где каждый мог по демократичным ценам приобрести восточногерманскую атрибутику (монеты, книги, игрушки, значки и т.д.), что к 2008 году превратило его в самоокупаемый туристический рай. Вместе с этим, восточные немцы остаются верны идеям Маркса и не прекращают политическую активность — именно на острове Эрнста Тельмана располагается штаб-квартира МВКРП, а также прошла её последняя конференция. В начале 2022 года микроГДР смогла-таки добиться статуса наблюдателя в ООН, но по-прежнему остаётся государством с частичным международно-правовым признанием.";
				}
			}
			else if (this.global1.data[0] == 12)
			{
				if (this.global1.data[106] == 1 && this.global1.data[81] == 0 && !this.global1.allcountries[7].Vyshi)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(66);
					}
					this.text_fake += "||<color=purple>Политика национального примирения";
					this.text_fake += "|</color>Правительству ДРА удалось провести успешные переговоры с «умеренной» частью оппозиции, и после окончания поставок пакистанского оружия добить остатки радикальной исламистской оппозиции были разбиты, и правительство успешно закрепилось на всей территории Афганистана. В 1993 году были проведены первые всеобщие президентские выборы, на которых успешно победил действующий лидер страны. Ситуация в стране окончательно стабилизировалась - была принята конституция, закрепившая главенствующее положение Ислама и допустила применение шариата, также, в новое единое правительство вошли представители духовенства и моджахедов. На афганской земле наступил долгожданный мир.";
				}
				else if (this.global1.data[106] == 1 && this.global1.data[81] == 0 && this.global1.allcountries[7].Vyshi)
				{
					this.text_fake += "||<color=purple>Новая гражданская война";
					this.text_fake = this.text_fake + "|</color>Развал социалистического лагеря и прекращение помощи со стороны СССР серьёзно ударили по нашей слабой экономике: в городах началась нехватка продовольствия и топлива, электроэнергия не подаётся месяцами. И, несмотря на успешные переговоры с оппозицией, окончившиеся созданием коалиционного правительства, в стране, на фоне экономического кризиса, разгорается кризис политический. На парламентских выборах 1993 года победила радикальная исламская оппозиция, в то время как президентом страны продолжает оставаться " + this.global1.politics_name[this.global1.data[11]] + ". Попытки лидера страны предотвратить новые очаги сепаратизма не увенчались успехом, и в регионах вновь формируются оппозиционные организации, терроризирующие местных жителей и грабящие города. Будущее страны туманно, но, похоже, новой братоубийственной войны не избежать.";
				}
				else if ((this.global1.data[80] == 100 && this.global1.data[106] == 0) || (this.global1.data[80] >= 80 && this.global1.data[81] == 0 && !this.global1.allcountries[7].Vyshi && this.global1.data[106] == 0))
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(63);
					}
					this.text_fake += "||<color=purple>Победа революции";
					this.text_fake += "|</color>Благодаря постоянно оказываемой помощи социалистического лагеря, а также упорной борьбе афганских народов за свободу и светлое будущее Афганистана, оппозиция была полностью разгромлена и в панике сбежала на территорию Пакистана. На афганской земле наконец-то наступил мир, и власть социалистов в стране окончательно стабилизировалась. Гражданская война окончена.";
				}
				else if (this.global1.data[80] >= 40 && this.global1.data[80] <= 80 && !this.global1.allcountries[7].Vyshi && this.global1.data[106] == 0)
				{
					this.text_fake += "||<color=purple>Гражданская война продолжается";
					this.text_fake += "|</color>СССР продолжил существовать, оказывая гуманитарную и военную поддержку Афганистану, что позволило облегчить его положение. Некоторые страны, опасаясь расширения исламских террористов, начали оказывать давление на Пакистан, усложняя ему помощь террористам. А с Китаем удалось договориться и выработать единую позицию по прекращению поддержки террористов. И, хотя, разногласия в партии и армии ДРА не были улажены до конца, а политика президента имела свои изъяны, наступления террористов удалось пресечь, а ДРА контролирует достаточно территорий, чтобы существовать дальше. Решающего перевеса не оказалось ни у одной из сторон, так что гражданская война в Афганистане продолжается.";
				}
				else if (this.global1.data[80] >= 20 && !this.global1.allcountries[7].Vyshi)
				{
					this.text_fake += "||<color=purple>Последний рубеж обороны";
					this.text_fake += "|</color>С выходом советских войск из Афганистана положение режима начало резко ухудшаться. Некоторые успешные наступления правительства были резко пресечены террористами, начавшие масштабное контрнаступление. В итоге оппозиция продвинулась настолько вглубь страны, что вплотную подошла к Кабулу, но в результате мужественных подвигов армии ДРА была отбита назад. Повторные наступательные операции были либо грандиозными победами, либо ужасающими поражениями. И, несмотря на то, что ДРА контролирует столь малую территорию, благодаря поддержке СССР она продолжает существовать, а гражданская война со временем только усиливается.";
				}
				else
				{
					this.text_fake += "||<color=purple>Странная война";
					this.text_fake += "|</color>Несмотря на прекращение помощи из СССР, Демократическая Республика Афганистан владеет достаточным количеством территорий, чтобы продолжать существовать и частично отбиваться от нападений оппозиции. Силы террористов и правительства всегда примерно равны, что не позволяет одной из сторон одержать верх в конфликте, поэтому гражданская война продолжается и неизвестно когда ей настанет конец. ";
				}
			}
			else if (this.global1.data[0] == 10)
			{
				if (this.global1.data[68] >= 4 && this.global1.data[11] == 3)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(56);
					}
					this.text_fake += "||<color=purple>Единая Корея";
					this.text_fake += "|</color>Товарищ Ким Ён Чхун проводил блестящую политику, добившись того, что не смог сделать его предшественник. Осуществляя курс на «декимирсенализацию» и внедрение масштабных экономических преобразований, он смог своими силами перетащить КНДР из ранга самых закрытых и централизованных государств в одну из самых влиятельных сил мировой политики. Отдельного внимания заслуживает его политика относительно Южной Кореи, которую совсем недавно государственная пропаганда клеймила «американской марионеткой», теперь после длительного процесса переговоров развернулся масштабная разрядка на Корейском полуострове: Север прекратил все разработки ядерного вооружения, а с Юга были выведены американские базы. И теперь, благодаря его гениальному правлению, больше не существует «позорной границы», разъединяющей корейский народ, а Корея стала единым конфедеративным государством под названием - «Демократическая Конфедеративная Республика Корё». А в 2000 году, в знак признания заслуг в дело мира, президент Республики Корея Ким Дэ Чжун и Председатель КНДР Ким Ён Чхун совместно получили Нобелевскую премию мира. Корея отныне едина и неделима.";
				}
				else if ((this.global1.data[68] >= 4 && this.global1.data[11] != 3) || (this.global1.data[68] >= 0 && this.global1.data[68] < 4))
				{
					this.text_fake += "||<color=purple>Перемирие";
					this.text_fake = this.text_fake + "|</color>Товарищ " + this.global1.politics_name[this.global1.data[11]] + " был спорным лидером в истории нашей страны. Неудачный старт в экономике совмещался с великими прорывами в деле воссоединения корейского народа. На Корейском полуострове была проведена разрядка напряжённости, воссоздана программа разлучённых за время Корейской войны семей. Также были созданы несколько совместных команд по некоторым видам спорта, выступающих под флагом единой Кореи. С некоторой периодичностью происходят межкорейские саммиты, демонстрирующие стремление корейского народа к единству, однако будущее объединенной Кореи всё ещё туманно.";
				}
				else if ((this.global1.data[68] <= -3 && this.global1.data[11] != 1) || (this.global1.data[68] > -3 && this.global1.data[68] <= -1))
				{
					this.text_fake += "||<color=purple>Холодное противостояние";
					this.text_fake += "|</color>Несмотря на наши попытки наладить переговоры с нашим южным соседом, получилось это из рук вон плохо. Любые наши совместные начинания пресекались чрезмерной милитаризации Севера и чересчур реакционным антикоммунизмом Юга. Конечно, о каких-либо военных столкновениях речи не идёт, но на Корейском полуострове всё ещё \"веет холодом\", невзирая на окончание противостояния СССР и США. Всё продолжает оставаться, как было и даже трудно предположить, когда корейский народ вновь станет един, как прежде.";
				}
				else if (this.global1.data[68] <= -3 && this.global1.data[11] == 1 && this.global1.science[9] && this.global1.allcountries[16].Gosstroy == 0)
				{
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(58);
					}
					this.text_fake += "||<color=purple>Хорошо забытое старое";
					this.text_fake += "|</color>Из-за чрезмерной милитаризации и агрессивной внешней политики Северной Кореи, Соединенные штаты, при поддержке своих союзников, смогли протолкнуть в Совет безопасности ООН резолюцию о необходимости военного вмешательства в КНДР, чтобы пресечь враждебную политику севера и не допустить масштабного конфликта с Югом. Однако наш старый союзник Китай вновь благородно пришёл на помощь и наложил вето на инициативу американских империалистов и их марионеток. Теперь после окончания старой холодной войны обороты стремительно набирает новая, в которой главенствующими силами будут США и КНР. Берегитесь, капиталисты, ваш конец близок!";
				}
				else
				{
					this.text_fake += "||<color=purple>БАГ: ТУТ ДОЛЖЕН БЫТЬ ИТОГ.</color>";
				}
			}
			else if (this.global1.data[0] == 3)
			{
				if (this.global1.data[50] < -5)
				{
					this.text_fake += "||<color=purple>Бархатный развод|</color>";
					this.text_fake = string.Concat(new string[]
					{
						this.text_fake,
						"По мере дестабилизации обстановки в Чехословакии, встал вопрос и о национальном самоопределении составляющих её республик. В целом, несмотря на явственную смену политико-экономического курса страны, большинство населения, и чехов, и словаков, было не готово к национальному самоопределению, что подтвердили результаты опроса, проведенного в то время. Тем не менее, судьба страны оказалась в руках политиков, которые распорядились иначе. Отдельные жители приграничных областей с обеих сторон новой границы негативно относились к разделу страны. 17 июля ",
						(this.global1.data[21] + 1 + (8 + this.global1.data[50])).ToString(),
						" года словацкий парламент принял декларацию о независимости. Чехословацкий Президент, который выступавший против разделения, ушёл в отставку. 25 ноября Федеральное собрание приняло закон о разделении страны с 1 января ",
						(this.global1.data[21] + 2 + (8 + this.global1.data[50])).ToString(),
						" года. Бархатный развод случился."
					});
				}
				else if (this.global1.data[50] < -2)
				{
					this.text_fake += "||<color=purple>Государственный Союз Чехии и Словакии|</color>";
					this.text_fake += "Мы дали достаточно свобод словакам. Несмотря на возросший национализм по всему соцлагерю, мы смогли сохранить хрупкий баланс в нашей стране. Отныне Чехословакия превращается в конфедерацию. Братислава и Прага разделили обязанности по управлению государством, примирив националистов обеих стран. И пусть злые языки по-прежнему называют нас «Чудовищем Версаля», мы сделаем все, ради процветания чешского и словацкого народов, волею судьбы объединенных в одном государстве.";
				}
				else if (this.global1.data[50] > 5 && this.global1.data[11] != 3)
				{
					this.text_fake += "||<color=purple>Один народ, одна нация!|</color>";
					this.text_fake += "Разработанный единый язык, который нам пришлось местами насадить силой, постепенно становится народным языком среди людей нашей страны. Националисты всех сортов и мастей были отлучены от власти, а их сторонники оказались за решеткой или за границей, где они не смогут причинить нам вреда. Введенная со временем политика «Культурного обмена» позволила людям нашей страны не только почувствовать, но и стать единым народом. И отныне чехословацкий народ неделим! Вперед, в светлое будущее";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(54);
					}
				}
				else
				{
					this.text_fake += "||<color=purple>Всё идёт как и шло.</color>";
				}
				if (this.global1.data[60] == 10)
				{
					this.text_fake += "||<color=purple>Тешин един и неделим!</color>";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(55);
					}
				}
			}
			else if (this.global1.data[0] == 4)
			{
				if (this.global1.data[11] == 0 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && this.global1.allcountries[4].isOVD && this.global1.allcountries[4].isSEV && this.global1.data[14] == 0 && this.global1.is_gkchp && this.global1.allcountries[7].Vyshi && this.global1.allcountries[7].Gosstroy == 2 && this.global1.eventVariantChosen[153] >= 2 && this.global1.eventVariantChosen[157] == 3)
				{
					this.text_fake = this.dlce1.credits_text[28];
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(129);
					}
				}
				else if (this.global1.data[62] >= 4 && this.global1.allcountries[15].isOVD && (this.global1.allcountries[6].isOVD || this.global1.allcountries[6].Gosstroy == 0 || this.global1.allcountries[6].Gosstroy == 9) && !this.global1.allcountries[5].Vyshi)
				{
					this.text_fake += "||<color=purple>Конфедеративная Северная Корея Европы";
					this.text_fake += "|</color>Воспользовавшись нестабильностью в соцлагере мы не растерялись взяли контроль в свои руки. Потеряв Трансильванию, Румыния погрузилась в анархию и доблестные венгерские войска при поддержке болгар, взявших под свой контроль утраченные в войнах этого века свои бывшие земли, установили марионеточное правительство в Румынии. Следующим шагом вспыхнуло восстания венгров в Закарпатье, которые наряду с пропольскими восстаниями в остальной Западной Украине дестабилизировали положение украинского правительства, оно ушло в отставку, а мы же вошли своими сапогами в Государство Рутения, которое провозгласило независимость и заявило о незаконной оккупации своих земель украинскими властями с 1945 года. Помощь Милошевичу позволила отвлечь НАТО и затянуть конфликт в Югославии. Воспользовавшись захваченными и уже имеющимися мощностями и технологиями, коалиция из четырех стран, включающая Болгарию, Румынию, Венгрию и Югославию, ощетинилась ядерным вооружением, и стала эдаким конфедеративным КНДР от Европы. Под давлением мировой общественности все страны, торговавшие с Венгрией, кроме самых верных трех союзников, наложили санкции, однако уход в самоизоляцию с захваченными территориями и несколькими верными союзниками позволил Венгерскому государству сохранить стабильность экономики, а обилие ядерного оружия остановило Кучму от угроз ядерной дубиной (которую, он, однако, отказался передавать своему сотоварищу Ельцину). ";
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(51);
					}
				}
				else if (this.global1.data[62] >= 2 && this.global1.allcountries[7].Vyshi)
				{
					this.text_fake += "Из обычной и непримечательной европейской страны Венгрия стала силой, с которой нельзя не считаться в регионе, а наш правитель стал символом величия и могущества венгерского народа. К сожалению, головокружение от успехов продлилось недолго. Проект по разжиганию недовольства в Трансильвании увенчался успехом после наскоро проведенного референдума под контролем наших частей без опознавательных знаков. Автономный регион Трансильвания пополнил список наших земель. Однако НАТО не стала стоять в стороне и тут же нарекла нас агрессором, подведя войска к нашим границам. Вслед за НАТО Кучма и Ельцин, осмелев, объединили усилия и начали угрожать нам своими ядерными дубинами. ";
					if (this.global1.data[16] > 11 || this.global1.allcountries[4].Vyshi)
					{
						this.text_fake += " Нам пришлось отступиться от наших завоеваний и лишь благодаря тому, что мы открылись иностранному капиталу и стали для западных партнеров новым рынком сбыта, нам позволили остаться суверенными. Трансильвания была объявлена демилитаризованной зоной, а среди венгров зреют ультраправые взгляды и социал-националистические движения создаются и крепнут на наших землях, жаждая реванша.";
					}
					else
					{
						this.text_fake += " Нам пришлось отступиться от наших завоеваний и лишь благодаря тому, что мы крепко держались за власть и отбили первые попытки наступления интернациональных сил, а затем нашли для международного сообщества козлов отпущения, нам позволили остаться суверенными. 30-километровые границы с Закарпатьем и Трансильванией от нашей территории были объявлены демилитаризованной зоной, а среди венгров зреют ультраправые взгляды и социал-националистические движения создаются и крепнут на наших землях, жаждая реванша.";
					}
				}
				else if (this.global1.data[62] >= 2 && this.global1.regions[2].buildings[0].type == 19)
				{
					this.text_fake += "Из обычной и непримечательной европейской страны Венгрия стала силой, с которой нельзя не считаться в регионе, а наш правитель стал символом величия и могущества венгерского народа. К сожалению, головокружение от успехов продлилось недолго. Проект по разжиганию недовольства в Трансильвании увенчался успехом после наскоро проведенного референдума под контролем наших частей без опознавательных знаков. Автономный регион Трансильвания пополнил список наших земель. Однако НАТО не стала стоять в стороне и тут же нарекла нас агрессором, подведя войска к нашим границам. Вслед за НАТО и Советский Союз, осмелев, начал угрожать нам своей ядерной дубиной. ";
					if (this.global1.data[16] > 11 || this.global1.allcountries[4].Vyshi)
					{
						this.text_fake += " Нам пришлось отступиться от наших завоеваний и лишь благодаря тому, что мы открылись иностранному капиталу и стали для западных партнеров новым рынком сбыта, нам позволили остаться суверенными. Трансильвания была объявлена демилитаризованной зоной, а среди венгров зреют ультраправые взгляды и социал-националистические движения создаются и крепнут на наших землях, жаждая реванша.";
					}
					else
					{
						this.text_fake += " Нам пришлось отступиться от наших завоеваний и лишь благодаря тому, что мы крепко держались за власть и отбили первые попытки наступления интернациональных сил, а затем нашли для международного сообщества козлов отпущения, нам позволили остаться суверенными. 30-километровые границы с Закарпатьем и Трансильванией от нашей территории были объявлены демилитаризованной зоной, а среди венгров зреют ультраправые взгляды и социал-националистические движения создаются и крепнут на наших землях, жаждая реванша.";
					}
				}
				else
				{
					this.text_fake = "Ничего особенного";
				}
			}
			else if (!this.global1.science[9] && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && this.global1.data[0] == 1 && (this.global1.data[14] == 3 || (this.global1.data[14] == 2 && this.global1.data[15] >= 8 && this.global1.data[17] >= 16) || (this.global1.data[14] == 4 && this.global1.data[16] <= 12)) && ((this.global1.allcountries[17].Westalgie >= 300 && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.data[0] == 1 && this.global1.allcountries[7].isOVD && !this.global1.is_gkchp) || (((this.global1.allcountries[17].Westalgie >= 350 && this.global1.allcountries[16].Gosstroy == 0) || this.global1.allcountries[17].Westalgie >= 400) && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.data[0] == 1 && (this.global1.allcountries[17].Westalgie >= 550 || (this.global1.allcountries[7].isSEV && !this.global1.is_gkchp)))))
			{
				this.text_fake += "||<color=purple>Обновлённая Единая Германия</color>";
				this.text_fake += "|<color=purple>В ФРГ</color>, в ходе реформации социалистического мира, падения пелены красной угрозы и расцвета идеи всемирной дружбы на очередных выборах одержала победу коалиция левых сил, выступавшая за пацифизм, социальные реформы, дружбу и мир. Следствием её победы стало не простое налаживание отношений с ГДР и признание Западного Берлина демилитаризованной зоной: Федеративная Республика объявила о выходе из военных структур НАТО, оставшись лишь в политических, и, вместе с ГДР, вывела со своих территорий иностранные военные базы, подписав договора о не нахождении на территории обоих Германий чьих-либо войск или ракет, и о безъядерном статусе ФРГ. Это было поддержано и СССР и Францией, однако дальнейшее оказалось полной неожиданностью - в ФРГ прошёл референдум о воссоединении ФРГ и ГДР в единую ГДР с сохранением внеблокового статуса и признанием нейтралитета, после чего бывшие левые функционеры ФРГ вошли в правительство ГДР, а Канцлер ФРГ стал Председателем Совета Министров новой Германии.";
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(32);
				}
			}
			else if (this.sinochek && this.global1.data[0] == 5)
			{
				if (this.otstavnoysinochek && this.global1.data[50] == 3)
				{
					this.text_fake += "|После смерти Чаушеску его сын Нику был задвинут бюрократией на задворки сначала Партии, а потом и истории, и был утверждён на пост профессора физики в Универститете Бухареста. Впрочем, Нику всегда подходил к учёбе с ленью, а образованность высмеивал, так что неудивительно, что профессором он пробыл недолго и был переведён обычным учителем в свой родной лицей, а потом и вовсе скончался от цирроза печени из-за алкоголизма на фоне неудач последних годов.";
				}
				else if (this.global1.data[50] == 3)
				{
					this.text_fake += "|После смерти Чаушеску его сын Нику был единогласно избран новым руководителем Партии и государства. Впрочем, несмотря на это, опытом он не обладал, а обучаться у других ему было зазорно. Однако, все его попытки реформ кончались неудачей за неудачей, вследствие чего он стал больше пить и проводить время на развлекательных мероприятиях, а власть постепенно перешла в руки партаппарата, который теперь управляет страной за ширмой в лице Нику. Впрочем, в интересах того же самого партаппарата и дальше потворствовать утверждению монархической линии преемственности правления. Пусть и всё более номинального с каждым годом...";
					if (this.global1.iron_and_blood && this.global1.data[14] <= 0 && this.global1.data[34] == 11)
					{
						this.achieves.GetComponent<achievements>().Set(36);
					}
				}
				else if (this.otstavnoysinochek && this.global1.data[50] == 4)
				{
					this.text_fake += "|После смерти Чаушеску его сын Валентин был задвинут бюрократией на задворки сначала Партии, а потом и истории, и был утверждён на пост директора Института атомной физики в Бухаресте, где и продолжает работать до сих пор, не вмешиваясь в политику вовсе. Он успел развестись и жениться во второй раз, но его судьба мало кого волнует, а он счастлив работать на любимом поприще и в достатке, пока страной правят партократы.";
				}
				else if (this.global1.data[50] == 4)
				{
					this.text_fake += "|После смерти Чаушеску его сын Валентин был единогласно избран новым руководителем Партии и государства. Несмотря на то, что ранее он мало интересовался политикой, но придя к власти он с усердством стал разгребать все проблемы государства, из-за чего вступил в немало конфликтов с партаппаратчиками. Однако, в целом, он продолжал линию своего отца Николае, опираясь на давних лоялистов, но уделяя особое внимание борьбе с коррупцией и развитию науки.";
					if (this.global1.iron_and_blood && this.global1.data[14] <= 0 && this.global1.data[26] <= 0)
					{
						this.achieves.GetComponent<achievements>().Set(37);
					}
				}
			}
			else if (this.global1.data[42] == 10 && this.global1.data[0] == 5)
			{
				if (this.global1.data[11] != 0 && this.global1.data[50] == 1)
				{
					this.text_fake = this.text_fake + "|Наш мудрый лидер " + this.global1.politics_name[this.global1.data[11]] + ", когда его власть окончательно утвердилась в стране, сделал воистину мудрое решение, которое порадовало сердца всех патриотов: он не просто вернул Короля-героя Михая в страну, нет, он реставрировал монархию! Монарх, в лице того же самого Михая, стал олицетворением единства нашей нации, символом нашего государства и гарантом вечной стабильности и сохранения наших многовековых традиций! Впрочем, несмотря на это, властью он наделён лишь церемониальной...";
					if (this.global1.iron_and_blood && this.global1.data[11] == 3)
					{
						this.achieves.GetComponent<achievements>().Set(38);
					}
				}
			}
			else if (this.global1.data[59] == 2 && this.global1.data[0] == 6 && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[42] != 7)
			{
				this.text_fake += "||Пока в Югославии вовсю шла гражданская война, мы успешно ввели войска в Македонию, где организовали свой собственный референдум и создали Автономный Край Вардария по названию бывшей времён Королевства Вардарской бановины, а существование самих македонцев опровергли. Отделённые западными империалистами болгарцы, ранее жившие в Македонии, на том самом референдуме в 76% голосов признали себя болгарцами и возжелали гражданства болгарского. Президент Хорватии Туджман, а затем и Президент Сербии Милошевич признали наш суверенитет над Македонией, вслед за ними подтянулись и наши союзники. И, хотя, большая часть мира не признаёт наши новые территории, но мы там утвердились. Надеюсь, что теперь раз и навсегда.";
				if (this.global1.iron_and_blood && this.global1.data[11] == 1 && this.global1.data[42] == 9 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)
				{
					this.achieves.GetComponent<achievements>().Set(41);
				}
			}
			else if (this.global1.data[59] == 2 && this.global1.data[0] == 6)
			{
				this.text_fake += "||Пока в Югославии вовсю шла гражданская война, мы успешно ввели войска в Македонию, где организовали свой собственный референдум и создали Автономный Край Вардария по названию бывшей времён Королевства Вардарской бановины, а существование самих македонцев опровергли. Впрочем, подобный прецедент, не признанный Западом, был основной причиной отказа сотрудничества Евросоюза и НАТО с нами, вследствие чего под давлением мирового сообщества мы вынуждены были провести повторный референдум, где 3/4 населения Македонии высказались за собственную независимость, коию и получили. А мы получили свой билет в цивилизованную Европу.";
			}
			else if (this.global1.data[59] == 4 && this.global1.data[0] == 6)
			{
				this.text_fake += "||Оказав Милошевичу существенную помощь вооружением, продовольствием и финансами, мы вместе с Албанией смогли мирно урегулировать албанский вопрос: часть албанцев уехала в Албанию, а часть поселилась в Республике Косовский Край, которая стала частью федеративной Югославии. Затем, вместе с албанцами, наши спецслужбы и войска специального назначения негласно приняли участие в войне на стороне Милошевича, к помощи подключились и наши союзники. И ещё до того, как американские ультиматумы достигли трибуны ООН, война в Югославии была закончена - быстро и решительно. Сепаратистов предали суду, а их лидеров казнили в прямом эфире. А затем раз и навсегда три страны, Югославия, Албания и Болгария, соединились в единую федерацию.";
				if (this.global1.data[14] > 2)
				{
					this.text_fake = this.text_fake + "|Во главе страны встал федеральный парламент и федеральное правительство под лидерством Всесоюзной Социалистической Партии Балкан, хотя республиканские социалистические партии сохранились. Президентом и Генеральным секретарём ВСПБ новой федерации стал " + this.global1.politics_name[this.global1.data[11]] + ", Премьер-Министром (с сохранением полномочий Вице-Президента) стал Милошевич, а Спикером парламента и 2 секретарём ВСПБ стал Рамиз Алия. Несмотря на принципы сохранения идеалов социализма, новое Балканское Союзное Государство допустило плюрализм мнений и частный бизнес в стране, хотя Всесоюзная Социалистическая Партия Балкан остаётся ведущей силой в управлении страной, а государство - ведущей силой в самой экономике.";
				}
				else if (this.global1.data[16] > 11)
				{
					this.text_fake = this.text_fake + "|Во главе страны встал федеральный Верховный Совет и федеральное правительство под лидерством Всесоюзной Коммунистической Партии Балкан, хотя республиканские коммунистические партии сохранились. Председателем Государственного Совета и Генеральным секретарём ВКПБ новой федерации стал " + this.global1.politics_name[this.global1.data[11]] + ", Председателем Совета Министров стал Милошевич, а Председателем Верховного Совета и 2 секретарём ВКПБ стал Рамиз Алия. Несмотря на принципы сохранения идеалов социализма, новое Балканское Союзное Государство допустило действие частного бизнеса в стране и лидерство принципов хозрасчёта, хотя государство всё еще остаётся ведущей силой в самой экономике.";
				}
				else
				{
					this.text_fake = this.text_fake + "|Во главе страны встал федеральный Верховный Совет и федеральное правительство под лидерством Всесоюзной Коммунистической Партии Балкан, хотя республиканские коммунистические партии сохранились. Председателем Государственного Совета и Генеральным секретарём ВКПБ новой федерации стал " + this.global1.politics_name[this.global1.data[11]] + ", Председателем Совета Министров стал Милошевич, а Председателем Президиума Верховного Совета и 2 секретарём ВКПБ стал Рамиз Алия. Несмотря на старые попытки реформ Милошевича и Алии в ещё суверенных Югославии и Албании, которые шли несколько лет назад, в новом Балканском Социалистическом Союзном Государстве сохраняются и абсолютно оберегаются все принципы марксизма-ленинизма в руководстве страной и управлении экономикой.";
					if (this.global1.iron_and_blood && this.global1.data[11] == 0 && this.global1.data[50] == 9)
					{
						this.achieves.GetComponent<achievements>().Set(40);
					}
				}
			}
			else if (this.global1.data[0] == 6 && this.global1.data[130] == 100)
			{
				if (this.global1.data[16] <= 11)
				{
					this.text_fake += "|Генеральному Секретарю удалось совместить противоречащие друг другу идеи в единое целое - монархо-социализм! Царь, как и прежде, является символом нации и гарантом стабильности и процветания страны, а благосостояние населения обеспечивается народным социалистическом государством. С другой же стороны бывшие союзники осуждают нас за извращение марксистских учений, а Запад обвиняет нас в шовинизме.";
				}
				else
				{
					this.text_fake += "|Мы вернули Болгарии её историческое лицо. Царь вновь является гарантом стабильности и процветания в стране, а о коммунизме не может идти и речи. Симеон II гордо объявил о создании Четвёртого Болгарского Царства, в котором строго оберегаются принципы Конституционной монархии и Народной Демократии. И всё это несмотря на то, что бывшие союзники теперь не хотят иметь с нами никакого дела. Да и нужны ли они нам?";
				}
				if (this.global1.iron_and_blood)
				{
					this.achieves.GetComponent<achievements>().Set(68);
				}
			}
			else if (this.global1.data[0] == 2 && (this.global1.data[50] == 20 || this.global1.data[60] <= -10))
			{
				if (this.global1.data[50] == 20)
				{
					this.text_fake = string.Concat(new string[]
					{
						"В ",
						(this.global1.data[21] + 1).ToString(),
						" году мы с гордостью открыли свой космодром и запустили первый отечественный спутник! Через 5 лет, в ",
						(this.global1.data[21] + 6).ToString(),
						", мы успешно запустили животных в космос и их возвращение прошло без проблем. В ",
						(this.global1.data[21] + 8).ToString(),
						" наши шаттлы, основанные на советских моделях (в т.ч. на выкупленном у СССР \"Буране\"), впервые вышли на международный рынок и за несколько лет мы стали лидером их поставок. Сейчас мы уже является полноправными членами проекта МКС и владеем собственным сегментом станции. Теперь каждый поляк с гордостью может сказать, что Польша может в космос!|"
					});
					if (this.global1.iron_and_blood)
					{
						this.achieves.GetComponent<achievements>().Set(46);
					}
				}
				if (this.global1.data[60] <= -10)
				{
					if (!this.global1.allcountries[7].Vyshi)
					{
						this.text_fake += "После провала ГКЧП мы решились организовать Проект Прометей, переработав ещё старую давнишнюю версию межвоенного периода, которая была нацелена на расчленение СССР насильственным путём. Сначала обновленный Прометей казался успешным для нас проектом, но затем, после поражения Ельцина, он затянулся: наши сети и организации долгое время на равных боролись с Межреспубликанской Службой Безопасности СССР и местными конкурентными нам националистами. Но всё закончилось с приходом нового Президента Советского Союза: он уделил особое внимание подконтрольным нам организациям и сетям, раз и навсегда оборвав наш Проект. И пора признать - Прометей провалился.";
					}
					else if (this.global1.allcountries[7].Vyshi && (this.global1.allcountries[this.global1.data[0]].Vyshi || (!this.global1.science[9] && this.global1.data[50] != 20) || this.military_ally <= 2 || this.economy_ally <= 4))
					{
						this.text_fake += "После провала ГКЧП мы решились организовать Проект Прометей, переработав ещё старую давнишнюю версию межвоенного периода, которая была нацелена на расчленение СССР насильственным путём. Особое внимание мы уделили Украине, Беларуси и Литве. В Беларуси всё начиналось и проходило успешно: исторические общества и националистические организации взывали к многовековой исторической связи с Польшей и вскоре был подписан договор о создании Союзного государства Польши и Беларуси - единого экономического пространства с военными обязательствами. Правда углубление не зашло дальше, после того, как украинские националисты, поддерживаемые нами, начали восхвалять ОУН-УПА (ответственных за геноцид поляков в сотрудничестве с гитлеровцами во время Второй Мировой Войны), а затем, после наших возмущений, выступили против нас вместе с олигархами, припомнив полякам все малые и большие обиды. С нашей подачи в Украине образовался националистический олигархический режим, что очень прискорбно. И всё это положило конец нашим поползновениям в Литву.";
					}
					else if (this.global1.allcountries[7].Vyshi && (this.global1.science[9] || this.global1.data[50] == 20) && this.military_ally > 2 && this.economy_ally > 4)
					{
						if (this.global1.data[14] <= 3 && this.global1.data[16] <= 12)
						{
							this.text_fake += "После провала ГКЧП мы решились организовать Проект Прометей, переработав ещё старую давнишнюю версию межвоенного периода, которая была нацелена на расчленение СССР насильственным путём. Особое внимание мы уделили левонационалистическим организациям Украины, Беларуси и Литвы. В Беларуси всё начиналось и проходило успешно: исторические общества и националистические организации взывали к многовековой исторической связи с Польшей. Всё успешно проходило и в Украине, где люди, уставшие от олигархов и ежегодного обеднения, особенно множество безработных и молодёжь, с радостью откликнулись на прививаемые нами идеи и социальные партийные программы для своих членов. Основной опорой нашей операции стали национал-синдикалисты, национал-коммунисты и примкнувшие к ним Социал-националисты, образовавшие коалицию и, в ходе массовых митингов и захвата зданий администрации, в конце концов пришедшие к власти. Дальнейшими шагами стала возможность создания конфедерации трёх наших государств в виде Социалистического Союза Восточной Европы. И победа лево-националистической коалиции Фронтас на выборах в Литве (конечно, при нашей поддержке). Фронтас, хоть и отрицает советскую оккупацию и утверждает, что в литовцев стреляли литовские снайперы в 1991 (призывая судить Горбачёва), но готовит подачу заявки на вступление Литвы в состав нашего ССВЕ, четвёртым членом.";
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(45);
							}
						}
						else
						{
							this.text_fake += "После провала ГКЧП мы решились организовать Проект Прометей, переработав ещё старую давнишнюю версию межвоенного периода, которая была нацелена на расчленение СССР насильственным путём. Особое внимание мы уделили правонационалистическим организациям Украины, Беларуси и Литвы. В Беларуси всё начиналось и проходило успешно: исторические общества и националистические организации взывали к многовековой исторической связи с Польшей. Всё успешно проходило и в Украине, где люди, уставшие от олигархов и ежегодного обеднения, особенно множество безработных и молодёжь, с радостью откликнулись на прививаемые нами идеи и социальные партийные программы для своих членов. Основной опорой нашей операции стали национал-консерваторы, неофашисты и примкнувшие к ним социал-националисты, образовавшие коалицию и, в ходе массовых митингов и захвата зданий администрации, в конце концов пришедшие к власти. Дальнейшими шагами стала возможность создания из трёх наших государств Конфедерации Восточной Европы. И победа право-националистической коалиции Молодая Литва на выборах в Литве (конечно, при нашей поддержке). Молодая Литва, хоть и имеет склонность к пересмотру грехов гитлеровских времён и восхвалению бывших легионеров литовских батальонов СС, но готовит подачу заявки на вступление Литвы в состав нашей КВЕ, четвёртым членом.";
							if (this.global1.iron_and_blood)
							{
								this.achieves.GetComponent<achievements>().Set(45);
							}
						}
					}
					else
					{
						this.text_fake += "После провала ГКЧП мы решились организовать Проект Прометей, переработав ещё старую давнишнюю версию межвоенного периода, которая была нацелена на расчленение СССР насильственным путём. Особое внимание мы уделили Украине, Беларуси и Литве. В Беларуси всё начиналось успешно: исторические общества и националистические организации взывали к многовековой исторической связи с Польшей, но им начало, при поддержке России, противостоять действующее правительство и это противостояние вылилось в победе пророссийского кандидата Александра Лукашенко. Беларусь ушла в российскую сферу влияния, что сказалось плохо и на Украине, где украинские националисты, поддерживаемые нами, начали восхвалять ОУН-УПА (ответственных за геноцид поляков в сотрудничестве с гитлеровцами во время Второй Мировой Войны), а затем, после наших возмущений, выступили против нас вместе с олигархами, припомнив полякам все малые и большие обиды. С нашей подачи в Украине образовался националистический олигархический режим, что очень прискорбно. И всё это положило конец нашим поползновениям в Литву.";
					}
				}
			}
			else
			{
				this.text_fake = "Ничего особенного";
			}
			if (this.global1.data[0] == 6 && this.global1.data[50] == 9 && (this.global1.data[42] == 2 || this.global1.data[42] == 4 || this.global1.data[42] == 6 || this.global1.data[42] == 9 || (this.global1.data[42] == 8 && this.global1.data[43] == 2)))
			{
				this.text_fake = this.text_fake + "|После того как великий " + this.global1.politics_name[this.global1.data[11]] + " скончался, его тело было положено в Мавзолей, где он упокоился вместе с Димитровым и теперь стал частью школьной программы по посещению памятных мест болгарской истории.";
			}
		}
		else if (this.this_okno == 13 + plus_max)
		{
			this.text_fake = "";
			this.Name.text = "СЛИШКОМ ПОЗДНО";
			this.text_fake = "Год: " + this.global1.data[21].ToString() + "|";
			this.text_fake += "1991 год давно закончился, но вы продолжили играть... И победили!|";
			this.text_fake += "Считаете это достижением? Тогда добейтесь того же самого до 1992 года!";
		}
		if (this.this_okno == 13)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[0]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[0]);
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 14)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[1]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[1]);
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 15)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[2]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[2]);
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 16)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[3]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[3]);
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 17)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[4]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[4]);
			this.SovToRus(this.text_fake);
		}
		else if (this.this_okno == 18)
		{
			this.Name.text = "<color=purple>" + this.global1.allcountries[havepaths[5]].name + "</color>";
			this.text_fake = this.CheckDLCEnding(havepaths[5]);
			this.SovToRus(this.text_fake);
		}
		if (this.global1.diff[0] && this.global1.diff[1] && this.global1.diff[2] && !this.global1.diff[3] && (this.global1.data[21] < 1992 || this.global1.data[20] == 1))
		{
			if (this.global1.data[195] == 1000)
			{
				this.achieves.GetComponent<achievements>().Set(69);
			}
			if (this.global1.allcountries[1].paths == 2 && this.global1.allcountries[4].paths == 3 && this.CheckDLCEnding(6) == this.dlce1.credits_text[41] && this.global1.allcountries[6].paths == 3 && this.global1.allcountries[5].paths == 5 && this.global1.data[198] != 1)
			{
				this.achieves.GetComponent<achievements>().Set(70);
			}
			if (this.CheckDLCEnding(2) == this.dlce1.credits_text[11] && this.CheckDLCEnding(3) == this.dlce1.credits_text[18] && this.CheckDLCEnding(6) == this.dlce1.credits_text[40])
			{
				this.achieves.GetComponent<achievements>().Set(71);
			}
			if (this.global1.allcountries[2].paths == 2 && this.global1.allcountries[3].paths == 5 && this.global1.event_done[99] && (this.global1.data[11] == 1 || this.global1.data[11] == 3) && this.global1.allcountries[4].paths == 4 && this.global1.data[125] != 1000 && this.global1.allcountries[7].Gosstroy < 2)
			{
				this.achieves.GetComponent<achievements>().Set(72);
			}
			else if (this.global1.allcountries[2].paths == 2 && this.global1.allcountries[3].paths == 5 && this.global1.allcountries[4].paths == 2 && this.global1.allcountries[5].paths == 4)
			{
				this.achieves.GetComponent<achievements>().Set(72);
			}
			if (this.global1.allcountries[this.global1.data[0]].subideology >= 300)
			{
				this.achieves.GetComponent<achievements>().Set(73);
			}
			if (this.CheckDLCEnding(4) == this.dlce1.credits_text[28] && this.CheckDLCEnding(6) == this.dlce1.credits_text[43] && this.global1.science[9] && this.global1.allcountries[10].Stasi)
			{
				this.achieves.GetComponent<achievements>().Set(75);
			}
			if (this.global1.allcountries[1].paths == 3 && this.global1.allcountries[3].isOVD && this.global1.allcountries[6].paths == 4 && this.global1.allcountries[7].Gosstroy < 2 && this.global1.allcountries[2].paths == 3 && this.global1.allcountries[2].isOVD && this.global1.allcountries[4].paths == 4 && this.global1.data[196] == 100)
			{
				this.achieves.GetComponent<achievements>().Set(76);
			}
		}
		if (this.this_okno != 7)
		{
			this.text.text = this.Text(this.text_fake, 72);
			return;
		}
		if (!this.this_done_done)
		{
			this.text.text = this.Text(this.text_fake, 72);
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00057BE0 File Offset: 0x00055DE0
	private void SovToRus(string text)
	{
		if (this.global1.data[45] == 5)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.text_fake = text.Replace("Soviet Union", "Russian Federation").Replace("USSR", "RF").Replace("Soviet", "Russian");
				return;
			}
			this.text_fake = text.Replace("Советский Союз", "Российская Федерация").Replace("Советского Союза", "Российской Федерации").Replace("Советскому Союзу", "Российской Федерации").Replace("Советским Союзом", "Российской Федерацией").Replace("СССР", "РФ").Replace("советский", "российский").Replace("советского", "российского").Replace("советскому", "российскому").Replace("советским", "российским").Replace("советском", "российском");
			return;
		}
		else
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.text_fake = text.Replace("Russian Federation", "Soviet Union").Replace("RF", "USSR").Replace("Russian", "Soviet").Replace("Russia", "Soviet Union");
				return;
			}
			this.text_fake = text.Replace("Россия", "Советский Союз").Replace("России", "СССР").Replace("Россией", "Советским Союзом").Replace("РФ", "СССР").Replace("российский", "советский").Replace("российского", "советского").Replace("российскому", "советскому").Replace("российским", "советским").Replace("российском", "советском");
			return;
		}
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00057DC0 File Offset: 0x00055FC0
	private string CheckDLCEnding(int number)
	{
		if (number == 1)
		{
			if (this.global1.allcountries[number].paths == 2)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[0];
				}
				return this.dlce1.credits_text[1];
			}
			else if (this.global1.allcountries[number].paths == 3)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[2];
				}
				return this.dlce1.credits_text[3];
			}
			else if (this.global1.allcountries[number].paths == 4)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[4];
				}
				return this.dlce1.credits_text[5];
			}
			else
			{
				if (this.global1.allcountries[number].paths != 5)
				{
					return this.dlce1.credits_text[8];
				}
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[6];
				}
				return this.dlce1.credits_text[7];
			}
		}
		else if (number == 2)
		{
			if (this.global1.allcountries[number].paths == 2)
			{
				return this.dlce1.credits_text[9];
			}
			if (this.global1.allcountries[number].paths != 3)
			{
				return this.dlce1.credits_text[12];
			}
			if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
			{
				return this.dlce1.credits_text[10];
			}
			return this.dlce1.credits_text[11];
		}
		else if (number == 3)
		{
			if (this.global1.allcountries[number].paths == 2)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[13];
				}
				return this.dlce1.credits_text[14];
			}
			else if (this.global1.allcountries[number].paths == 3)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[15];
				}
				return this.dlce1.credits_text[16];
			}
			else
			{
				if (this.global1.allcountries[number].paths != 4)
				{
					return this.dlce1.credits_text[19];
				}
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[17];
				}
				return this.dlce1.credits_text[18];
			}
		}
		else if (number == 4)
		{
			if (this.global1.allcountries[number].paths == 2)
			{
				return this.dlce1.credits_text[20];
			}
			if (this.global1.allcountries[number].paths == 3)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[21];
				}
				return this.dlce1.credits_text[22];
			}
			else if (this.global1.allcountries[number].paths == 4)
			{
				if (this.global1.data[195] == 1000)
				{
					return this.dlce1.credits_text[49];
				}
				if (this.global1.data[196] > 0)
				{
					return this.dlce1.credits_text[23];
				}
				if (this.global1.allcountries[7].paths == 3 || this.global1.allcountries[7].Gosstroy == 0)
				{
					return this.dlce1.credits_text[24];
				}
				if (this.global1.allcountries[7].Gosstroy < 2)
				{
					return this.dlce1.credits_text[25];
				}
				return this.dlce1.credits_text[26];
			}
			else
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[27];
				}
				return this.dlce1.credits_text[28];
			}
		}
		else if (number == 5)
		{
			if (this.global1.data[196] > 0)
			{
				return this.dlce1.credits_text[29];
			}
			if (this.global1.allcountries[number].paths == 2)
			{
				if (this.global1.data[197] == 4)
				{
					return this.dlce1.credits_text[30];
				}
				return this.dlce1.credits_text[31];
			}
			else if (this.global1.allcountries[number].paths == 3)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[32];
				}
				return this.dlce1.credits_text[33];
			}
			else
			{
				if (this.global1.allcountries[number].paths == 4)
				{
					return this.dlce1.credits_text[34];
				}
				if (this.global1.data[198] == 1)
				{
					return this.dlce1.credits_text[35];
				}
				return this.dlce1.credits_text[36];
			}
		}
		else
		{
			if (number != 6)
			{
				return "Баг";
			}
			if (this.global1.allcountries[number].paths == 2)
			{
				if ((this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD && this.global1.data[0] != 20) || this.global1.data[199] > 0)
				{
					return this.dlce1.credits_text[37];
				}
				return this.dlce1.credits_text[38];
			}
			else if (this.global1.allcountries[number].paths == 3)
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[39];
				}
				if (this.global1.allcountries[number].isSEV || this.global1.allcountries[7].Gosstroy < 2)
				{
					return this.dlce1.credits_text[40];
				}
				return this.dlce1.credits_text[41];
			}
			else if (this.global1.allcountries[number].paths == 4)
			{
				if (this.global1.allcountries[7].Gosstroy < 2)
				{
					return this.dlce1.credits_text[42];
				}
				return this.dlce1.credits_text[43];
			}
			else
			{
				if (this.global1.allcountries[number].isSEV && this.global1.allcountries[number].isOVD)
				{
					return this.dlce1.credits_text[44];
				}
				return this.dlce1.credits_text[45];
			}
		}
	}

	// Token: 0x0600007B RID: 123 RVA: 0x0005856C File Offset: 0x0005676C
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

	// Token: 0x040000A5 RID: 165
	public GlobalScript global1;

	// Token: 0x040000A6 RID: 166
	public DLCEndingScript dlce1;

	// Token: 0x040000A7 RID: 167
	private Yugoglobal yug1;

	// Token: 0x040000A8 RID: 168
	public TextMesh Name;

	// Token: 0x040000A9 RID: 169
	public TextMesh text;

	// Token: 0x040000AA RID: 170
	private string text_fake;

	// Token: 0x040000AB RID: 171
	public int this_okno;

	// Token: 0x040000AC RID: 172
	public int this_vrem;

	// Token: 0x040000AD RID: 173
	public Sprite winfon;

	// Token: 0x040000AE RID: 174
	public Sprite winplan;

	// Token: 0x040000AF RID: 175
	public int ipolitic;

	// Token: 0x040000B0 RID: 176
	public GameObject achieves;

	// Token: 0x040000B1 RID: 177
	public GameObject button_l;

	// Token: 0x040000B2 RID: 178
	public GameObject button_r;

	// Token: 0x040000B3 RID: 179
	public bool sinochek;

	// Token: 0x040000B4 RID: 180
	public bool otstavnoysinochek;

	// Token: 0x040000B5 RID: 181
	public bool this_done_done;

	// Token: 0x040000B6 RID: 182
	public int military_ally;

	// Token: 0x040000B7 RID: 183
	public int economy_ally;

	// Token: 0x040000B8 RID: 184
	public int greece_ally;

	// Token: 0x040000B9 RID: 185
	public int yeye;

	// Token: 0x040000BA RID: 186
	public int guevara;
}
