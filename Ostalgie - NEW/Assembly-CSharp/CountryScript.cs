using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class CountryScript : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x0000A7F4 File Offset: 0x000089F4
	private void OnMouseEnter()
	{
		if (!this.rightwing)
		{
			this.Repaint();
		}
		else
		{
			this.Repaint_right(true);
		}
		this.sp.material.SetColor("_MainColor", new Color(0.4f, 0.4f, 0.4f));
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0000A841 File Offset: 0x00008A41
	private void OnMouseExit()
	{
		if (!this.rightwing)
		{
			this.Repaint();
			return;
		}
		this.Repaint_right(true);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x0000A85C File Offset: 0x00008A5C
	private void OnMouseDown()
	{
		if (this.this_number != 15 || this.global1.data[0] < 49 || this.global1.data[0] > 51)
		{
			if (this.okno1[0] == null)
			{
				this.okno1[0] = this.map1.okno.transform.Find("Znach (0)").GetComponent<OkoshkoScript>();
				this.okno1[1] = this.map1.okno.transform.Find("Znach (1)").GetComponent<OkoshkoScript>();
				this.okno1[2] = this.map1.okno.transform.Find("Znach (2)").GetComponent<OkoshkoScript>();
				this.okno1[3] = this.map1.okno.transform.Find("Znach (3)").GetComponent<OkoshkoScript>();
			}
			if (this.global1.data[0] != 999999)
			{
				this.map1.ShowHideOcno(true);
				this.map1.okno.transform.Find("Text (0)").GetComponent<TextMesh>().text = this.global1.allcountries[this.this_number].name;
				this.okno1[0].nonono = false;
				this.okno1[1].nonono = false;
				this.okno1[2].nonono = false;
				this.okno1[3].nonono = false;
				if (this.global1.allcountries[this.this_number].subideology < 0 || this.global1.allcountries[this.this_number].subideology >= 100)
				{
					if (this.global1.allcountries[this.this_number].Gosstroy == 0)
					{
						this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[1];
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.okno1[0].text_en = "Socialism";
						}
						else
						{
							this.okno1[0].text = "Социализм";
						}
					}
					else if (this.global1.allcountries[this.this_number].Gosstroy == 1)
					{
						this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[3];
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.okno1[0].text_en = "Reformism";
						}
						else
						{
							this.okno1[0].text = "Реформизм";
						}
					}
					else if (this.global1.allcountries[this.this_number].Gosstroy == 2)
					{
						this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[4];
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.okno1[0].text_en = "Liberalism";
						}
						else
						{
							this.okno1[0].text = "Либерализм";
						}
					}
					else
					{
						this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[8];
						if (PlayerPrefs.GetInt("language") == 0)
						{
							this.okno1[0].text_en = "Authoritarianism";
						}
						else
						{
							this.okno1[0].text = "Авторитаризм";
						}
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 0)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[0];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Left nationalism";
					}
					else
					{
						this.okno1[0].text = "Левый национализм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 1)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[1];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "National-Bolshevism";
					}
					else
					{
						this.okno1[0].text = "Национал-большевизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 2)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[2];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Pro-market dictatorship";
					}
					else
					{
						this.okno1[0].text = "Рыночная диктатура";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 3)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[3];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Third way";
					}
					else
					{
						this.okno1[0].text = "Третий путь";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 4)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[4];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Conservative Socialism";
					}
					else
					{
						this.okno1[0].text = "Консервативный социализм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 5)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[5];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Trotskyism";
					}
					else
					{
						this.okno1[0].text = "Троцкизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 6)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[6];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Maoism";
					}
					else
					{
						this.okno1[0].text = "Маоизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 7)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[7];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Antirevisionism";
					}
					else
					{
						this.okno1[0].text = "Антиревизионизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 8)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[8];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Democratic socialism";
					}
					else
					{
						this.okno1[0].text = "Демократический социализм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 9)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[9];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Left social-democracy";
					}
					else
					{
						this.okno1[0].text = "Левая социал-демократия";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 10)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[10];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Red tory";
					}
					else
					{
						this.okno1[0].text = "Красный торизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 11)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[11];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Political pragmatism";
					}
					else
					{
						this.okno1[0].text = "Политический прагматизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 12)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[12];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Centrism";
					}
					else
					{
						this.okno1[0].text = "Центризм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 13)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[13];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Right social-democracy";
					}
					else
					{
						this.okno1[0].text = "Правая социал-демократия";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 14)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[14];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Liberal-conservative";
					}
					else
					{
						this.okno1[0].text = "Либерал-консерватизм";
					}
				}
				else if (this.global1.allcountries[this.this_number].subideology == 15)
				{
					this.map1.okno.transform.Find("Znach (0)").GetComponent<SpriteRenderer>().sprite = this.map1.subIdZ[15];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[0].text_en = "Euroatlanticism";
					}
					else
					{
						this.okno1[0].text = "Евроатлантизм";
					}
				}
				if (this.global1.allcountries[this.this_number].isOVD && this.global1.allcountries[7].isOVD)
				{
					this.map1.okno.transform.Find("Znach (1)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[2];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[1].text_en = "Warsaw Pact";
					}
					else
					{
						this.okno1[1].text = "Варшавский договор";
					}
				}
				else if (this.global1.allcountries[this.this_number].isOVD)
				{
					this.map1.okno.transform.Find("Znach (1)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[6];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[1].text_en = "CSO";
					}
					else
					{
						this.okno1[1].text = "ОКБ";
					}
				}
				else
				{
					this.map1.okno.transform.Find("Znach (1)").GetComponent<SpriteRenderer>().sprite = null;
					this.okno1[1].nonono = true;
				}
				if (this.global1.allcountries[this.this_number].isSEV && this.global1.allcountries[7].isSEV)
				{
					this.map1.okno.transform.Find("Znach (2)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[5];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[2].text_en = "CMEA";
					}
					else
					{
						this.okno1[2].text = "СЭВ";
					}
				}
				else if (this.global1.allcountries[this.this_number].isSEV)
				{
					this.map1.okno.transform.Find("Znach (2)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[7];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[2].text_en = "The new CMEA";
					}
					else
					{
						this.okno1[2].text = "Новый СЭВ";
					}
				}
				else if (this.global1.allcountries[this.this_number].Torg)
				{
					this.map1.okno.transform.Find("Znach (2)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[9];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[2].text_en = "The close trade";
					}
					else
					{
						this.okno1[2].text = "Тесная торговля";
					}
				}
				else
				{
					this.map1.okno.transform.Find("Znach (2)").GetComponent<SpriteRenderer>().sprite = null;
					this.okno1[2].nonono = true;
				}
				if (this.global1.allcountries[this.this_number].Vyshi)
				{
					this.map1.okno.transform.Find("Znach (3)").GetComponent<SpriteRenderer>().sprite = this.map1.znachki[0];
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.okno1[3].text_en = "Influenced By the USA";
					}
					else
					{
						this.okno1[3].text = "Под влиянием США";
					}
				}
				else
				{
					this.map1.okno.transform.Find("Znach (3)").GetComponent<SpriteRenderer>().sprite = null;
					this.okno1[3].nonono = true;
				}
				for (int i = 0; i < 4; i++)
				{
					this.map1.buttons[i].GetComponent<DiploButtonScript>().Hide();
					this.map1.buttons[i].GetComponent<DiploButtonScript>().selected_country = this.this_number;
				}
				if (PlayerPrefs.GetInt("language") == 0)
				{
					if (this.this_number == this.global1.data[0])
					{
						if ((this.global1.data[0] != 10 || this.global1.data[11] == 3) && this.global1.data[0] != 12)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Open", 61);
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Paid", 62);
							this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Close", 63);
							return;
						}
						if (this.global1.data[0] == 12)
						{
							if (this.global1.data[88] == 0)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Offensive", 77);
								return;
							}
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Reinforcements", 78);
							return;
						}
					}
					else
					{
						if (this.this_number == 21)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Investments", 1);
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Friendship", 2);
							return;
						}
						if (this.this_number == 0)
						{
							if (this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && (this.global1.data[0] < 49 || this.global1.data[0] > 51))
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Integration", 3);
							}
							if (this.global1.data[0] != 12)
							{
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Detente", 54);
								return;
							}
						}
						else
						{
							if (this.this_number == 54)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Brigades", 83);
								if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
								{
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("UDBA", 82);
								}
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Trade", 84);
								return;
							}
							if (this.this_number == 14)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Embargo", 4);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 5);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 23);
								return;
							}
							if (this.this_number == 13)
							{
								if (!this.global1.allcountries[this.this_number].Donat)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Support", 6);
								}
								else
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Recognize", 6);
								}
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Interfere", 7);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Channel", 8);
								return;
							}
							if (this.this_number == 12)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Humanitarian", 9);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Military", 10);
								return;
							}
							if (this.this_number == 17)
							{
								if (this.global1.data[0] != 12 || this.global1.science[2])
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("RAF", 11);
								}
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Peace", 12);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Trade", 84);
								return;
							}
							if (this.this_number == 15)
							{
								if (this.global1.data[0] != 12 || this.global1.science[2])
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Help", 13);
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Milosevic", 14);
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Separatists", 15);
									this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Agreement", 51);
									return;
								}
							}
							else
							{
								if (this.this_number == 16)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Relationships", 16);
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 17);
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Customs", 18);
									this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Elimination", 44);
									return;
								}
								if (this.this_number == 23 && this.global1.event_done[17])
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 17);
									return;
								}
								if (this.this_number == 34 && this.global1.allcountries[34].Gosstroy == 2)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Trade", 17);
									return;
								}
								if (this.this_number == 19)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Contract", 19);
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Asylum", 20);
									if (this.global1.data[0] != 10)
									{
										this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Provocation", 45);
										return;
									}
								}
								else if (this.this_number == 8)
								{
									if (this.global1.data[0] != 12)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Diplomacy", 21);
										this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 22);
										this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Economy", 23);
										return;
									}
								}
								else if (this.this_number == 7)
								{
									if (this.global1.data[0] != 20 && this.global1.data[0] != 10 && this.global1.data[0] != 12)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Credit", 25);
									}
									if (this.global1.data[0] != 12 || this.global1.science[2])
									{
										this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Conservatives", 24);
									}
									if (this.global1.data[0] != 18 && this.global1.data[0] != 12)
									{
										this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Buy", 50);
									}
									if (this.global1.data[0] == 5)
									{
										this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Moldavia", 57);
										return;
									}
								}
								else if (this.this_number == 10)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Licenses", 26);
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Analysts", 27);
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Technologies", 43);
									if (!this.global1.allcountries[this.this_number].isSEV)
									{
										this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 56);
										return;
									}
									this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Influence", 81);
									return;
								}
								else
								{
									if (this.this_number == 11)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 28);
										return;
									}
									if (this.this_number == 18)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 28);
										return;
									}
									if (this.this_number == 47)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 28);
										return;
									}
									if (this.this_number == 48)
									{
										if (this.global1.data[0] != 12 || this.global1.science[2])
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Friendship", 79);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Investments", 80);
											return;
										}
									}
									else if (this.this_number == 20)
									{
										if (this.global1.data[0] != 12 || this.global1.science[2])
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Restore", 29);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 30);
											this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alia", 31);
											this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Alliance", 37);
											return;
										}
									}
									else
									{
										if (this.this_number == 9)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 28);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Support", 32);
											return;
										}
										if (this.this_number >= 1 && this.this_number <= 6)
										{
											if (this.global1.data[0] != 12 || this.global1.science[2])
											{
												if (this.global1.allcountries[this.global1.data[0]].Vyshi)
												{
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Invite", 33);
												}
												else if ((this.this_number != 6 && this.this_number != 4) || (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD))
												{
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 36);
												}
												else if (this.global1.allcountries[6].paths != 4 && this.this_number == 6)
												{
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 36);
												}
												else if (!this.global1.event_done[1045] && this.this_number == 4)
												{
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Union", 36);
												}
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Finance", 34);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Coordination", 35);
												this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Alliance", 37);
												return;
											}
										}
										else
										{
											if (this.this_number == 28)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Deep trade", 38);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Integration", 39);
												return;
											}
											if (this.this_number == 27)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Deep trade", 38);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Integration", 39);
												return;
											}
											if (this.this_number == 26)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Deep trade", 38);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Integration", 39);
												return;
											}
											if (this.this_number == 30)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Restore", 40);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Union", 41);
												return;
											}
											if (this.this_number == 33)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Diplomacy", 42);
												return;
											}
											if (this.this_number == 31)
											{
												if (this.global1.data[0] != 12)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Sanctions", 46);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Decline", 52);
													return;
												}
											}
											else
											{
												if (this.this_number == 35)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Lebanon", 47);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Trade", 17);
													this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Union", 28);
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Help", 34);
													return;
												}
												if (this.this_number == 37)
												{
													if (this.global1.data[0] != 18 && this.global1.data[0] != 12)
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Buy", 48);
														this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Trade", 84);
														return;
													}
												}
												else if (this.this_number == 24)
												{
													if (this.global1.data[0] != 12 || this.global1.science[2])
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Petroleum", 49);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Investments", 53);
														return;
													}
												}
												else if (this.this_number == 39)
												{
													if (this.global1.data[0] != 12)
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Bank", 55);
														return;
													}
												}
												else if (this.this_number == 38)
												{
													if (this.global1.data[0] != 12 || this.global1.science[2])
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Friendship", 17);
														return;
													}
												}
												else if (this.this_number >= 40 && this.this_number <= 43)
												{
													if (this.global1.data[0] != 12 || this.global1.science[2])
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Right-wing", 58);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Left-wing", 59);
														this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Humanitarian", 60);
														this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Resources", 64);
														return;
													}
												}
												else if (this.this_number == 44)
												{
													if (this.global1.data[0] != 12)
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("JCP", 65);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Deep trade", 66);
														return;
													}
												}
												else
												{
													if (this.this_number == 45)
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Union", 67);
														return;
													}
													if (this.this_number == 36)
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Friendship", 68);
														return;
													}
													if (this.this_number == 46)
													{
														if (this.global1.data[0] != 12 || this.global1.science[2])
														{
															this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Wijeweera", 69);
															this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Security", 70);
															this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("PLF", 71);
															return;
														}
													}
													else if (this.this_number == 29)
													{
														if (this.global1.data[0] != 12 || this.global1.science[2])
														{
															this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Browne", 72);
															this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Spring", 73);
															this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("The Left", 74);
															this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Trade", 84);
															return;
														}
													}
													else if (this.this_number == 22 && (this.global1.data[0] != 12 || this.global1.science[2]))
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Phomvihane", 75);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Faction", 76);
														return;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else if (this.this_number == this.global1.data[0])
				{
					if ((this.global1.data[0] != 10 || this.global1.data[11] == 3) && this.global1.data[0] != 12)
					{
						this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Открытые", 61);
						this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Платная", 62);
						this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Закрыть", 63);
						return;
					}
					if (this.global1.data[0] == 12)
					{
						if (this.global1.data[88] == 0)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Наступление", 77);
							return;
						}
						this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Подкрепления", 78);
						return;
					}
				}
				else
				{
					if (this.this_number == 21)
					{
						this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Инвестиции", 1);
						this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Дружба", 2);
						return;
					}
					if (this.this_number == 0)
					{
						if (this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && (this.global1.data[0] < 49 || this.global1.data[0] > 51))
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Интеграция", 3);
						}
						if (this.global1.data[0] != 12)
						{
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Разрядка", 54);
							return;
						}
					}
					else
					{
						if (this.this_number == 54)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Боевые Ядра", 83);
							if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
							{
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("УДБА", 82);
							}
							this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Торговля", 84);
							return;
						}
						if (this.this_number == 14)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Эмбарго", 4);
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 5);
							this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 23);
							return;
						}
						if (this.this_number == 13)
						{
							if (!this.global1.allcountries[this.this_number].Donat)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Поддержать", 6);
							}
							else
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Признать", 6);
							}
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Вмешаться", 7);
							this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Канал", 8);
							return;
						}
						if (this.this_number == 12)
						{
							this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Гуманитарная", 9);
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Военная", 10);
							return;
						}
						if (this.this_number == 17)
						{
							if (this.global1.data[0] != 12 || this.global1.science[2])
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("RAF", 11);
							}
							this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Мир", 12);
							this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Торговля", 84);
							return;
						}
						if (this.this_number == 15)
						{
							if (this.global1.data[0] != 12 || this.global1.science[2])
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Помощь", 13);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Милошевич", 14);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Сепаратисты", 15);
								this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Договор", 51);
								return;
							}
						}
						else
						{
							if (this.this_number == 16)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Отношения", 16);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 17);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Таможня", 18);
								this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Устранение", 44);
								return;
							}
							if (this.this_number == 23 && this.global1.event_done[17])
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 17);
								return;
							}
							if (this.this_number == 34 && this.global1.allcountries[34].Gosstroy == 2)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Торговля", 17);
								return;
							}
							if (this.this_number == 19)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Контракт", 19);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Убежище", 20);
								if (this.global1.data[0] != 10)
								{
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Провокация", 45);
									return;
								}
							}
							else if (this.this_number == 8)
							{
								if (this.global1.data[0] != 12)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дипломатия", 21);
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 22);
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Экономика", 23);
									return;
								}
							}
							else if (this.this_number == 7)
							{
								if (this.global1.data[0] != 20 && this.global1.data[0] != 10 && this.global1.data[0] != 12)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Кредит", 25);
								}
								if (this.global1.data[0] != 12 || this.global1.science[2])
								{
									this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Консерваторы", 24);
								}
								if (this.global1.data[0] != 18 && this.global1.data[0] != 12)
								{
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Купить", 50);
								}
								if (this.global1.data[0] == 5)
								{
									this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Молдавия", 57);
									return;
								}
							}
							else if (this.this_number == 10)
							{
								this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Лицензии", 26);
								this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Аналитики", 27);
								this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Технологии", 43);
								if (!this.global1.allcountries[this.this_number].isSEV)
								{
									this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 56);
									return;
								}
								this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Повлиять", 81);
								return;
							}
							else
							{
								if (this.this_number == 11)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 28);
									return;
								}
								if (this.this_number == 18)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 28);
									return;
								}
								if (this.this_number == 47)
								{
									this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 28);
									return;
								}
								if (this.this_number == 48)
								{
									if (this.global1.data[0] != 12 || this.global1.science[2])
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дружба", 79);
										this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Инвестиции", 80);
										return;
									}
								}
								else if (this.this_number == 20)
								{
									if (this.global1.data[0] != 12 || this.global1.science[2])
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Восстановить", 29);
										this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 30);
										this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Алия", 31);
										this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Альянс", 37);
										return;
									}
								}
								else
								{
									if (this.this_number == 9)
									{
										this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 28);
										this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Поддержка", 32);
										return;
									}
									if (this.this_number >= 1 && this.this_number <= 6)
									{
										if (this.global1.data[0] != 12 || this.global1.science[2])
										{
											if (this.global1.allcountries[this.global1.data[0]].Vyshi)
											{
												this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Пригласить", 33);
											}
											else if ((this.this_number != 6 && this.this_number != 4) || (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD))
											{
												this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 36);
											}
											else if (this.global1.allcountries[6].paths != 4 && this.this_number == 6)
											{
												this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 36);
											}
											else if (!this.global1.event_done[1045] && this.this_number == 4)
											{
												this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Союз", 36);
											}
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Финансы", 34);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Координация", 35);
											this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Альянс", 37);
											return;
										}
									}
									else
									{
										if (this.this_number == 28)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Углубить", 38);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Интеграция", 39);
											return;
										}
										if (this.this_number == 27)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Углубить", 38);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Интеграция", 39);
											return;
										}
										if (this.this_number == 26)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Углубить", 38);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Интеграция", 39);
											return;
										}
										if (this.this_number == 30)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Восстановить", 40);
											this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Союз", 41);
											return;
										}
										if (this.this_number == 33)
										{
											this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дипломатия", 42);
											return;
										}
										if (this.this_number == 31)
										{
											if (this.global1.data[0] != 12)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Санкции", 46);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Снять", 52);
												return;
											}
										}
										else
										{
											if (this.this_number == 35)
											{
												this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Ливан", 47);
												this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 17);
												this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Союз", 28);
												this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Помощь", 34);
												return;
											}
											if (this.this_number == 37)
											{
												if (this.global1.data[0] != 18 && this.global1.data[0] != 12)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Купить", 48);
													this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Торговля", 84);
													return;
												}
											}
											else if (this.this_number == 24)
											{
												if (this.global1.data[0] != 12 || this.global1.science[2])
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Нефть", 49);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Инвестиции", 53);
													return;
												}
											}
											else if (this.this_number == 39)
											{
												if (this.global1.data[0] != 12)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Банк", 55);
													return;
												}
											}
											else if (this.this_number == 38)
											{
												if (this.global1.data[0] != 12 || this.global1.science[2])
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дружба", 17);
													return;
												}
											}
											else if (this.this_number >= 40 && this.this_number <= 43)
											{
												if (this.global1.data[0] != 12 || this.global1.science[2])
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Правые", 58);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Левые", 59);
													this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Гуманитарная", 60);
													this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Ресурсы", 64);
													return;
												}
											}
											else if (this.this_number == 44)
											{
												if (this.global1.data[0] != 12)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("КПЯ", 65);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Торговля", 66);
													return;
												}
											}
											else
											{
												if (this.this_number == 45)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Союз", 67);
													return;
												}
												if (this.this_number == 36)
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Дружба", 68);
													return;
												}
												if (this.this_number == 46)
												{
													if (this.global1.data[0] != 12 || this.global1.science[2])
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Виджевир", 69);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Безопасность", 70);
														this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("НОФ", 71);
														return;
													}
												}
												else if (this.this_number == 29)
												{
													if (this.global1.data[0] != 12 || this.global1.science[2])
													{
														this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Браун", 72);
														this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Спринг", 73);
														this.map1.buttons[2].GetComponent<DiploButtonScript>().Show("Левые", 74);
														this.map1.buttons[3].GetComponent<DiploButtonScript>().Show("Торговля", 84);
														return;
													}
												}
												else if (this.this_number == 22 && (this.global1.data[0] != 12 || this.global1.science[2]))
												{
													this.map1.buttons[0].GetComponent<DiploButtonScript>().Show("Фомвихан", 75);
													this.map1.buttons[1].GetComponent<DiploButtonScript>().Show("Фракция", 76);
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			this.vkladka.SetActive(!this.vkladka.activeSelf);
			this.vkladka.GetComponent<YugoMapManager>().AddButtons(false);
			this.vkladka.GetComponent<YugoMapManager>().Repaint();
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000DE1C File Offset: 0x0000C01C
	public void Repaint_right(bool nado = true)
	{
		if (this.global1 == null)
		{
			this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
			this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		}
		if (nado)
		{
			this.sp = base.GetComponent<SpriteRenderer>();
			this.sp.sprite = this.grey;
			this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0f));
		}
		if (this.global1.data[0] == this.this_number)
		{
			if (this.global1.data[14] <= 0)
			{
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 9;
				return;
			}
			if (this.global1.data[14] <= 2)
			{
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 0;
				return;
			}
			if (this.global1.data[14] <= 3)
			{
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 1;
				return;
			}
			this.global1.allcountries[this.global1.data[0]].Gosstroy = 2;
		}
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0000DF78 File Offset: 0x0000C178
	public void Repaint()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.sp = base.GetComponent<SpriteRenderer>();
		if (this.this_number == 1)
		{
			if (this.global1.allcountries[1].Gosstroy == 2 && this.global1.data[0] != 1 && !this.global1.allcountries[1].isSEV && !this.global1.allcountries[1].isOVD)
			{
				this.this_number = 17;
			}
		}
		else if (this.this_number == 24)
		{
			if (this.global1.allcountries[24].Gosstroy == 2)
			{
				this.this_number = 25;
			}
		}
		else if (this.this_number == 36)
		{
			if (this.global1.event_done[53] && !this.global1.event_done[81])
			{
				if (PlayerPrefs.GetInt("language") == 0)
				{
					this.global1.allcountries[this.this_number].name = "Occupied by Iraq";
				}
				else
				{
					this.global1.allcountries[this.this_number].name = "Оккупирован\nИраком";
				}
			}
			else if (PlayerPrefs.GetInt("language") == 0)
			{
				this.global1.allcountries[this.this_number].name = "Kuwait";
			}
			else
			{
				this.global1.allcountries[this.this_number].name = "Кувейт";
			}
		}
		else if (this.this_number == 5 && this.global1.event_done[1044])
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.global1.allcountries[this.this_number].name = "Hung. Romania";
			}
			else
			{
				this.global1.allcountries[this.this_number].name = "Венг. Румыния";
			}
		}
		this.sp.sprite = this.grey;
		this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0f));
		if (this.global1.map_type == 0)
		{
			if (this.global1.allcountries[this.this_number].isOVD)
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 1f, 1f, 0f));
			}
			else if (this.global1.allcountries[this.this_number].Vyshi)
			{
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
			}
			else
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 0f, 0f, 0f));
			}
			this.Repaint_right(false);
		}
		else if (this.global1.map_type == 2)
		{
			if (this.global1.allcountries[this.this_number].isSEV)
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 1f, 1f, 0f));
			}
			else if (this.global1.allcountries[this.this_number].Vyshi)
			{
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
			}
			else if (this.global1.allcountries[this.this_number].Torg)
			{
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.72f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0f, 1f, 0f));
			}
			else
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 0f, 0f, 0f));
			}
			this.Repaint_right(false);
		}
		else if (this.global1.data[0] == this.this_number)
		{
			if (this.global1.data[14] <= 0)
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 0f, 0f, 0f));
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 9;
			}
			else if (this.global1.data[14] <= 2)
			{
				this.sp.material.SetColor("_MainColor2", new Color(0f, 1f, 1f, 0f));
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 0;
			}
			else if (this.global1.data[14] <= 3)
			{
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.72f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0f, 1f, 0f));
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 1;
			}
			else
			{
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
				this.global1.allcountries[this.global1.data[0]].Gosstroy = 2;
			}
		}
		else if (this.global1.allcountries[this.this_number].Gosstroy == 2)
		{
			this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
			this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
		}
		else if (this.global1.allcountries[this.this_number].Gosstroy == 0)
		{
			this.sp.material.SetColor("_MainColor2", new Color(0f, 1f, 1f, 0f));
		}
		else if (this.global1.allcountries[this.this_number].Gosstroy == 1)
		{
			this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.72f));
			this.sp.material.SetColor("_MainColor2", new Color(1f, 0f, 1f, 0f));
		}
		else
		{
			this.sp.material.SetColor("_MainColor2", new Color(0f, 0f, 0f, 0f));
		}
		if (this.this_number == 7)
		{
			if (this.global1.allcountries[7].Vyshi)
			{
				this.sp.sprite = this.special;
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
				return;
			}
		}
		else if (this.this_number == 17)
		{
			if (this.global1.allcountries[1].Gosstroy == 2 && this.global1.data[0] != 1)
			{
				this.sp.sprite = this.special;
				return;
			}
		}
		else if (this.this_number == 24)
		{
			if (this.global1.allcountries[24].Gosstroy == 2)
			{
				this.sp.sprite = this.special;
				this.sp.material.SetColor("_MainColor", new Color(0f, 0f, 0.46f));
				this.sp.material.SetColor("_MainColor2", new Color(1f, 0.48f, 0f, 0f));
				return;
			}
		}
		else if (this.this_number == 4)
		{
			if (this.global1.event_done[1044])
			{
				this.sp.sprite = this.special;
				return;
			}
		}
		else if (this.this_number == 5)
		{
			if (this.global1.data[59] == 1)
			{
				this.sp.sprite = this.special;
				return;
			}
			if (this.global1.event_done[1044])
			{
				this.sp.sprite = this.special2;
				return;
			}
		}
		else if (this.this_number == 6 && this.global1.data[59] == 2)
		{
			this.sp.sprite = this.special;
		}
	}

	// Token: 0x04000051 RID: 81
	public GlobalScript global1;

	// Token: 0x04000052 RID: 82
	public int this_number;

	// Token: 0x04000053 RID: 83
	public Sprite grey;

	// Token: 0x04000054 RID: 84
	public Sprite special;

	// Token: 0x04000055 RID: 85
	public Sprite special2;

	// Token: 0x04000056 RID: 86
	private MapChangesScript map1;

	// Token: 0x04000057 RID: 87
	private SpriteRenderer sp;

	// Token: 0x04000058 RID: 88
	public bool rightwing;

	// Token: 0x04000059 RID: 89
	private OkoshkoScript[] okno1 = new OkoshkoScript[4];

	// Token: 0x0400005A RID: 90
	public GameObject vkladka;
}
