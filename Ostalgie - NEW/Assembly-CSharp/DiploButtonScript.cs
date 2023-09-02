using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000014 RID: 20
public class DiploButtonScript : MonoBehaviour
{
	// Token: 0x06000059 RID: 89 RVA: 0x0000F362 File Offset: 0x0000D562
	private void Awake()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0000F38E File Offset: 0x0000D58E
	public void Hide()
	{
		base.transform.Find("Text").GetComponent<TextMesh>().text = null;
		this.is_active = false;
		base.GetComponent<SpriteRenderer>().sprite = null;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0000F3C0 File Offset: 0x0000D5C0
	public void Show(string text, int number)
	{
		this.is_active = true;
		this.this_type = number;
		base.GetComponent<SpriteRenderer>().sprite = this.off;
		base.transform.Find("Text").GetComponent<TextMesh>().text = text;
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.this_type == 1)
			{
				this.this_opis = "Invite foreign investors";
				this.number_uslovie = 3;
				this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Money;
				this.uslovie_text[0] = "Investors are not invited";
				if (this.global1.allcountries[21].Gosstroy == 2)
				{
					this.uslovie_bool[1] = (this.global1.data[16] == 13);
					this.uslovie_text[1] = "Market economy";
				}
				else
				{
					this.uslovie_bool[1] = (this.global1.data[16] >= 12);
					this.uslovie_text[1] = "Not planned economy/automation";
				}
				this.uslovie_bool[2] = (this.global1.data[6] < 800 - this.global1.allcountries[21].Gosstroy * 200);
				this.uslovie_text[2] = "Diplomatic reputation is less than " + (80 - this.global1.allcountries[21].Gosstroy * 20);
				return;
			}
			if (this.this_type == 2)
			{
				this.this_opis = "Treaty of friendship with France";
				this.number_uslovie = 2;
				this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
				this.uslovie_text[0] = "The treaty is not signed";
				if (this.global1.allcountries[21].Gosstroy != 2)
				{
					this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[31] >= 750);
					this.uslovie_text[1] = "Nationalism & we aren't integrating into the EEC";
					return;
				}
				if (this.global1.allcountries[7].isSEV)
				{
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Diplomatic reputation is less than 80";
					return;
				}
				this.uslovie_bool[1] = (this.global1.data[6] < 490);
				this.uslovie_text[1] = "Diplomatic reputation is less than 49";
				return;
			}
			else
			{
				if (this.this_type == 3)
				{
					this.this_opis = "Enter into the integration community in the EEC";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
					this.uslovie_text[0] = "We are not integrating into the EEC";
					if (this.global1.data[14] >= 4 && this.global1.data[16] >= 13)
					{
						this.uslovie_bool[1] = (this.global1.data[6] < 600);
						this.uslovie_text[1] = "Diplomatic reputation is less than 60";
					}
					else
					{
						this.uslovie_bool[1] = (this.global1.data[6] < 400);
						this.uslovie_text[1] = "Diplomatic reputation is less than 40";
					}
					this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isOVD;
					this.uslovie_text[2] = "We aren't a member of Warsaw Pact";
					this.uslovie_bool[3] = (this.global1.data[16] > 11);
					this.uslovie_text[3] = "Do not have planned/automated economy";
					return;
				}
				if (this.this_type == 4)
				{
					this.this_opis = "Join the international embargo";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
					this.uslovie_text[0] = "Trade relations weren't deepen";
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Diplomatic reputation is less than 80";
					this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
					this.uslovie_text[2] = "No embargo";
					this.uslovie_bool[3] = (this.global1.data[32] == 1);
					this.uslovie_text[3] = "International sanctions introduced";
					return;
				}
				if (this.this_type == 5)
				{
					this.this_opis = "To deepen the development of trade relations";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
					this.uslovie_text[0] = "Trade relations weren't deepen";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Diplomatic reputation is more than 60";
					this.uslovie_bool[2] = (!this.global1.allcountries[this.selected_country].Help && !this.global1.allcountries[8].Torg);
					this.uslovie_text[2] = "No embargo. No friendship with Iran.";
					this.uslovie_bool[3] = (this.global1.data[32] == 1);
					this.uslovie_text[3] = "International sanctions introduced";
					return;
				}
				if (this.this_type == 6 && !this.global1.allcountries[this.selected_country].Donat)
				{
					this.this_opis = "Put money in the accounts of reform supporters so that they abandon their position";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
					this.uslovie_text[0] = "Don't put money";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Diplomatic reputation is more than 60";
					this.uslovie_bool[2] = (this.global1.data[8] >= 10);
					this.uslovie_text[2] = "Money in your budget: 1.0";
					return;
				}
				if (this.this_type == 6 && this.global1.allcountries[this.selected_country].Donat)
				{
					this.this_opis = "Recognize Libyan claims in Chad and assist with weapons";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
					this.uslovie_text[0] = "Didn't support";
					this.uslovie_bool[1] = (this.global1.data[6] > 650);
					this.uslovie_text[1] = "Diplomatic reputation is more than 65";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Agent networks: 1.0";
					return;
				}
				if (this.this_type == 7)
				{
					this.this_opis = "Push on the socialist path of development and start trade";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
					this.uslovie_text[0] = "Not yet";
					this.uslovie_bool[1] = (this.global1.data[6] >= 650);
					this.uslovie_text[1] = "Diplomatic reputation is more than 65";
					this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Donat && this.global1.allcountries[this.selected_country].Stasi);
					this.uslovie_text[2] = "Interfere in the internal politics of Gaddafi";
					return;
				}
				if (this.this_type == 8)
				{
					this.this_opis = "Establish an emergency oil supply channel";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
					this.uslovie_text[0] = "We interfered in the internal politics of Gaddafi";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Diplomatic reputation is more than 60";
					this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
					this.uslovie_text[2] = "The channel wasn't established";
					return;
				}
				if (this.this_type == 9)
				{
					this.this_opis = "Provide food assistance";
					this.number_uslovie = 2;
					if (!this.global1.allcountries[this.selected_country].Donat)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
						this.uslovie_text[0] = "Food wasn't sent";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "We have a constitutional majority";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
						this.uslovie_text[0] = "Wait until the next year";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 590);
					this.uslovie_text[1] = "Diplomatic reputation is more than 59";
					return;
				}
				if (this.this_type == 10)
				{
					this.this_opis = "Provide military assistance";
					this.number_uslovie = 3;
					if (!this.global1.allcountries[this.selected_country].Stasi)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Military assistance wasn't provided";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "We have a constitutional majority";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Wait until the next year";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 790);
					this.uslovie_text[1] = "Diplomatic reputation is more than 79";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "There are free agent networks";
					return;
				}
				if (this.this_type == 11)
				{
					this.this_opis = "Help RAF";
					this.number_uslovie = 3;
					if (!this.global1.allcountries[this.selected_country].Stasi)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Help wasn't given";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "We have a constitutional majority";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Wait until the next year";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 790);
					this.uslovie_text[1] = "Diplomatic reputation is more than 79";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "There are free agent networks";
					return;
				}
				if (this.this_type == 12)
				{
					this.this_opis = "Start an anti-war campaign through the \"Generals for Peace\" ";
					this.number_uslovie = 4;
					if (!this.global1.allcountries[this.selected_country].Help)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Help;
						this.uslovie_text[0] = "The campaign wasn't started";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "We have a constitutional majority";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Help;
						this.uslovie_text[0] = "Wait until next year";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 390);
					this.uslovie_text[1] = "Diplomatic reputation is more than 39";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "There are free agent networks";
					this.uslovie_bool[3] = (this.global1.data[0] == 1);
					this.uslovie_text[3] = "German Democratic Republic";
					return;
				}
				if (this.this_type == 13)
				{
					this.this_opis = "Provide humanitarian assistance";
					this.number_uslovie = 2;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
					this.uslovie_text[0] = "Humanitarian assistance wasn't provided this year";
					this.uslovie_bool[1] = (this.global1.data[6] > 190);
					this.uslovie_text[1] = "Diplomatic reputation is more than 19";
					return;
				}
				if (this.this_type == 14)
				{
					this.this_opis = "To help Milosevic";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
					this.uslovie_text[0] = "Military assistance wasn't provided this year";
					this.uslovie_bool[1] = (this.global1.data[6] > 390);
					this.uslovie_text[1] = "Diplomatic reputation is more than 39";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "There are free agent networks";
					this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy >= 2);
					this.uslovie_text[3] = "Nationalists won the elections in Yugoslavia";
					return;
				}
				if (this.this_type == 51)
				{
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.this_opis = "Sign an agreement on military mutual aid";
					}
					else
					{
						this.this_opis = "Sign an agreement on economical mutual aid";
					}
					this.number_uslovie = 4;
					if (this.global1.data[59] != 2 || this.global1.data[0] != 6)
					{
						this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Milosevic was supported";
					}
					else
					{
						this.uslovie_bool[0] = (this.global1.data[59] != 2);
						this.uslovie_text[0] = "Macedonia in Yugoslavia";
					}
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.uslovie_bool[1] = (this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[this.selected_country].isOVD);
					}
					else
					{
						this.uslovie_bool[1] = (this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[this.selected_country].isSEV);
					}
					this.uslovie_text[1] = "We are in the alliance";
					this.uslovie_bool[2] = (this.global1.data[9] >= 50);
					this.uslovie_text[2] = "We have five agent networks";
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.uslovie_bool[3] = (!this.global1.allcountries[7].isOVD || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 0));
					}
					else
					{
						this.uslovie_bool[3] = (!this.global1.allcountries[7].isSEV || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 0));
					}
					this.uslovie_text[3] = "Soviet Union isn't in the alliance or there is Alksnis";
					return;
				}
				if (this.this_type == 15)
				{
					this.this_opis = "To help the separatists";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Help && !this.global1.allcountries[this.selected_country].Stasi);
					this.uslovie_text[0] = "Military assistance wasn't provided";
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Diplomatic reputation is less than 80";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "There are free agent networks";
					this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy >= 2);
					this.uslovie_text[3] = "Nationalists won the elections in Yugoslavia";
					return;
				}
				if (this.this_type == 44)
				{
					this.this_opis = "Eliminate Deng Xiaoping, allowing the conservatives to retain power";
					this.number_uslovie = 4;
					if (this.global1.data[6] >= 800)
					{
						this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
						this.uslovie_text[0] = "We have established a trade";
					}
					else
					{
						this.uslovie_bool[0] = (this.global1.data[6] >= 800);
						this.uslovie_text[0] = "Diplomatic reputation is more than 80";
					}
					this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy == 9);
					this.uslovie_text[1] = "Opposition in China was suppressed";
					this.uslovie_bool[2] = (this.global1.data[9] >= 100 && this.global1.data[8] >= 100);
					this.uslovie_text[2] = "Free agent networks are 10 (and money too)";
					if (this.global1.data[21] >= 1991 && (this.global1.data[0] == 12 || this.global1.data[0] == 10 || this.global1.data[0] == 18))
					{
						this.uslovie_bool[3] = this.global1.science[2];
						this.uslovie_text[3] = "Foreign Agent networks were advanced";
						return;
					}
					if (this.global1.data[21] >= 1991)
					{
						this.uslovie_bool[3] = this.global1.science[2];
						this.uslovie_text[3] = "We have SORM (SOIA)";
						return;
					}
					if (this.global1.data[21] >= 1991)
					{
						this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[3] = "Deng Xiaoping wasn't eliminated";
						return;
					}
					if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[3] = this.global1.is_konst_max;
						this.uslovie_text[3] = "We have a constitutional majority";
						return;
					}
					this.uslovie_bool[3] = (this.global1.data[21] >= 1991);
					this.uslovie_text[3] = "Not earlier than 1991 year";
					return;
				}
				else
				{
					if (this.this_type == 16)
					{
						this.this_opis = "Establish diplomatic relations";
						this.number_uslovie = 2;
						this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Donat && !this.global1.allcountries[this.selected_country].Torg);
						this.uslovie_text[0] = "We have not established a relationship";
						if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
						{
							this.uslovie_bool[1] = (this.global1.data[6] < 880);
							this.uslovie_text[1] = "Diplomatic reputation is less than 88";
						}
						else if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
						{
							this.uslovie_bool[1] = (this.global1.data[6] < 700);
							this.uslovie_text[1] = "Diplomatic reputation is less than 70";
						}
						else if (this.global1.allcountries[this.selected_country].Gosstroy == 0 || this.global1.allcountries[this.selected_country].Gosstroy == 9)
						{
							this.uslovie_bool[1] = (this.global1.data[6] > 600);
							this.uslovie_text[1] = "Diplomatic reputation is more than 60";
						}
						this.uslovie_bool[2] = !this.global1.allcountries[38].Donat;
						this.uslovie_text[2] = "China wasn't condemned";
						return;
					}
					if (this.this_type == 17)
					{
						this.this_opis = "Go to active trade phase";
						this.number_uslovie = 3;
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
						this.uslovie_text[0] = "We have not established a trade";
						this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Donat || this.global1.allcountries[this.selected_country].Help);
						this.uslovie_text[1] = "Established relationships";
						if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
						{
							this.uslovie_bool[2] = (this.global1.data[6] < 880);
							this.uslovie_text[2] = "Diplomatic reputation is less than 88";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
						{
							this.uslovie_bool[2] = (this.global1.data[6] < 500);
							this.uslovie_text[2] = "Diplomatic reputation is less than 50";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
						{
							this.uslovie_bool[2] = (this.global1.data[6] > 600);
							this.uslovie_text[2] = "Diplomatic reputation is more than 60";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
						{
							this.uslovie_bool[2] = (this.global1.data[8] >= 60);
							this.uslovie_text[2] = "Money in your budget: 6";
							return;
						}
					}
					else
					{
						if (this.this_type == 68)
						{
							this.this_opis = "Send a delegation to Kuwait to create friendly relations";
							this.number_uslovie = 4;
							this.uslovie_bool[0] = this.global1.allcountries[14].Help;
							this.uslovie_text[0] = "We imposed an embargo on Iraq";
							this.uslovie_bool[1] = (this.global1.event_done[81] || !this.global1.event_done[53]);
							this.uslovie_text[1] = "This country isn't annexed.";
							this.uslovie_bool[2] = (this.global1.allcountries[14].Gosstroy != 9);
							this.uslovie_text[2] = "You've helped to overthrow Saddam Hussein.";
							this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[3] = "The delegation hasn't been sent yet.";
							return;
						}
						if (this.this_type == 18)
						{
							this.this_opis = "Invite to the customs union";
							this.number_uslovie = 4;
							if (!this.global1.allcountries[this.global1.data[0]].Vyshi)
							{
								this.uslovie_bool[1] = !this.global1.allcountries[16].isSEV;
								this.uslovie_text[1] = "China is not in the customs union";
							}
							else
							{
								this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
								this.uslovie_text[1] = "We are not integrating into the EEC";
							}
							this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Torg && this.global1.allcountries[this.global1.data[0]].isSEV);
							this.uslovie_text[2] = "Trade is active and we have an alliance";
							if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
							{
								this.uslovie_bool[3] = (this.global1.data[6] > 390);
								this.uslovie_text[3] = "Diplomatic reputation is more than 39";
								this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
								this.uslovie_text[0] = "The USSR is not in the CMEA";
								return;
							}
							if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
							{
								this.uslovie_bool[3] = (this.global1.data[6] < 400);
								this.uslovie_text[3] = "Diplomatic reputation is less than 40";
								this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
								this.uslovie_text[0] = "The USSR is not in the CMEA";
								return;
							}
							if (this.global1.allcountries[this.selected_country].Gosstroy == 0 && this.global1.data[7] > 700)
							{
								this.uslovie_bool[3] = (this.global1.data[7] > 700);
								this.uslovie_text[3] = "Stability of the Socialist camp is more than 70";
								this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
								this.uslovie_text[0] = "China is conservative";
								return;
							}
							if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
							{
								this.uslovie_bool[3] = (this.global1.data[8] >= 100);
								this.uslovie_text[3] = "You have more than 10 money";
								this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
								this.uslovie_text[0] = "China is conservative";
								return;
							}
							this.uslovie_bool[3] = (this.global1.data[6] < 800);
							this.uslovie_text[3] = "Diplomatic reputation is less than 80";
							this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
							this.uslovie_text[0] = "The USSR is not in the CMEA";
							return;
						}
						else if (this.this_type == 19)
						{
							this.this_opis = "Sign a contract for the supply of weapons to India";
							this.number_uslovie = 2;
							this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[0] = "The contract is not signed";
							if (this.global1.allcountries[this.selected_country].Gosstroy != 2)
							{
								this.uslovie_bool[1] = (this.global1.data[6] > 590);
								this.uslovie_text[1] = "Diplomatic reputation is more than 59";
								this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isSEV;
								this.uslovie_text[2] = "We are in the CMEA";
								return;
							}
							this.uslovie_bool[1] = (this.global1.data[6] < 490);
							this.uslovie_text[1] = "Diplomatic reputation is less than 49";
							this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
							this.uslovie_text[2] = "We are not in the CMEA";
							return;
						}
						else
						{
							if (this.this_type == 20)
							{
								this.this_opis = "Get guarantees of political asylum to our party apparatus";
								this.number_uslovie = 3;
								this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
								this.uslovie_text[0] = "Signed contract";
								this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Help;
								this.uslovie_text[1] = "Guarantees weren't given";
								this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
								this.uslovie_text[2] = "INC in power";
								return;
							}
							if (this.this_type == 45)
							{
								this.this_opis = "To provoke a new Indo-Pakistan war";
								this.number_uslovie = 4;
								this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
								this.uslovie_text[0] = "INC in power";
								this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Torg;
								this.uslovie_text[1] = "Weapons were sold";
								this.uslovie_bool[2] = (this.global1.data[9] >= 100);
								this.uslovie_text[2] = "Free agent networks are 10";
								this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
								this.uslovie_text[3] = "War wasn't provoked";
								return;
							}
							if (this.this_type == 21)
							{
								this.this_opis = "Restore Diplomatic Relationships";
								this.number_uslovie = 3;
								this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Donat && !this.global1.allcountries[this.selected_country].Torg);
								this.uslovie_text[0] = "Diplomatic relationships not restored";
								this.uslovie_bool[1] = (this.global1.data[6] > 190 && this.global1.data[6] < 800);
								this.uslovie_text[1] = "Diplomatic reputation between 19 and 80";
								this.uslovie_bool[2] = this.global1.event_done[14];
								this.uslovie_text[2] = "The liberalization of Iran began";
								return;
							}
							if (this.this_type == 22)
							{
								this.this_opis = "Go to active trade phase";
								this.number_uslovie = 3;
								this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Donat;
								this.uslovie_text[0] = "Diplomatic relationships restored";
								this.uslovie_bool[1] = (this.global1.data[6] > 250 && this.global1.data[6] < 800);
								this.uslovie_text[1] = "Diplomatic reputation between 25 and 80";
								this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
								this.uslovie_text[2] = "Trade is not started";
								return;
							}
							if (this.this_type == 23)
							{
								this.this_opis = "Invite to the Economic Union";
								this.number_uslovie = 4;
								if (this.selected_country == 8)
								{
									this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
									this.uslovie_text[0] = "The USSR is not in the CMEA and we are in the Alliance";
								}
								else
								{
									this.uslovie_bool[0] = (this.global1.allcountries[14].Gosstroy == 0 && this.global1.allcountries[8].isSEV && this.global1.allcountries[35].isSEV);
									this.uslovie_text[0] = "Socialism in Iraq and Sirya with Iran are in the CMEA";
								}
								this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
								this.uslovie_text[1] = "This country isn't in the CMEA";
								this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
								this.uslovie_text[2] = "Trade is active";
								this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
								this.uslovie_text[3] = "We are not integrating into the EEC";
								return;
							}
							if (this.this_type == 24)
							{
								if (!this.global1.allcountries[7].Vyshi)
								{
									this.this_opis = "Support conservatives in the USSR";
								}
								else
								{
									this.this_opis = "Support communists in the CIS";
								}
								this.number_uslovie = 4;
								this.uslovie_bool[0] = (this.global1.data[9] > 29);
								this.uslovie_text[0] = "Free agent networks >= 3";
								this.uslovie_bool[1] = (this.global1.data[14] <= 3);
								this.uslovie_text[1] = "We have socialism";
								this.uslovie_bool[2] = (this.global1.data[8] > 10);
								this.uslovie_text[2] = "Money in your budget is more than 1";
								if (!this.global1.allcountries[this.selected_country].Stasi)
								{
									this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
									this.uslovie_text[3] = "We didn't support them";
									return;
								}
								if (!this.global1.is_konst_max)
								{
									this.uslovie_bool[3] = this.global1.is_konst_max;
									this.uslovie_text[3] = "We have a constitutional majority";
									return;
								}
								this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
								this.uslovie_text[3] = "Wait until the next year";
								return;
							}
							else if (this.this_type == 25)
							{
								this.this_opis = "Issue a loan to the USSR";
								this.number_uslovie = 3;
								this.uslovie_bool[0] = (this.global1.data[8] > 30);
								this.uslovie_text[0] = "Money in your budget is more than 3";
								this.uslovie_bool[1] = this.global1.allcountries[7].isSEV;
								this.uslovie_text[1] = "USSR in the CMEA";
								if (this.global1.data[8] < 30)
								{
									this.uslovie_bool[2] = (this.global1.data[8] >= 30);
									this.uslovie_text[2] = "It needs 3 from your budget";
									return;
								}
								if (!this.global1.allcountries[this.selected_country].Donat)
								{
									this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
									this.uslovie_text[2] = "The loan wasn't issued";
									return;
								}
								this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
								this.uslovie_text[2] = "Wait";
								return;
							}
							else
							{
								if (this.this_type == 26)
								{
									this.this_opis = "Sell licenses for weapons";
									this.number_uslovie = 2;
									this.uslovie_bool[0] = (this.global1.data[6] > 390);
									this.uslovie_text[0] = "Diplomatic reputation is more than 39";
									this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Donat;
									this.uslovie_text[1] = "Licenses weren't sold";
									return;
								}
								if (this.this_type == 43)
								{
									this.this_opis = "Secretly sell blueprints and technology for creating nuclear weapons";
									this.number_uslovie = 4;
									this.uslovie_bool[0] = (this.global1.data[6] > 790 || this.global1.data[8] <= 0);
									this.uslovie_text[0] = "Dip. reputation is more than 79 or the budget is negative";
									this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Stasi;
									this.uslovie_text[1] = "Blueprints and technology weren't sold";
									this.uslovie_bool[2] = (this.global1.data[36] == 1);
									this.uslovie_text[2] = "We have blueprints and technology";
									this.uslovie_bool[3] = (this.global1.data[9] >= 30);
									this.uslovie_text[3] = "Free agent networks are more than 2";
									return;
								}
								if (this.this_type == 27)
								{
									this.this_opis = "Send the analysts to study the Juche";
									this.number_uslovie = 2;
									this.uslovie_bool[0] = (this.global1.data[6] > 790);
									this.uslovie_text[0] = "Diplomatic reputation is more than 79";
									this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Help;
									this.uslovie_text[1] = "We did not send analysts";
									return;
								}
								if (this.this_type == 28)
								{
									this.this_opis = "Invite to the Economic Union";
									this.number_uslovie = 3;
									if (!this.global1.allcountries[this.global1.data[0]].Vyshi)
									{
										this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
										this.uslovie_text[0] = "The USSR is not in the CMEA";
									}
									else
									{
										this.uslovie_bool[0] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
										this.uslovie_text[0] = "We are not integrating into the EEC";
									}
									this.uslovie_bool[1] = (!this.global1.allcountries[this.selected_country].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
									this.uslovie_text[1] = "Country not in the CMEA and we are in the Alliance";
									if (this.selected_country != 35 && this.selected_country != 47)
									{
										this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
										this.uslovie_text[2] = "They aren't liberal";
										return;
									}
									if (this.selected_country != 47)
									{
										this.uslovie_bool[2] = (this.global1.data[9] >= 10);
										this.uslovie_text[2] = "There are free agent networks";
										return;
									}
									this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
									this.uslovie_text[2] = "FSLN won the elections";
									return;
								}
								else
								{
									if (this.this_type == 56)
									{
										this.this_opis = "Invite to the Economic Union";
										this.number_uslovie = 4;
										this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
										this.uslovie_text[0] = "The USSR is not in the CMEA and we are in the Alliance";
										this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
										this.uslovie_text[1] = "Country not in the CMEA";
										if (this.global1.data[0] == 5 && this.global1.data[11] == 0)
										{
											this.uslovie_bool[2] = (this.global1.data[11] == 0);
											this.uslovie_text[2] = "Ceausescu is in power";
										}
										else
										{
											this.uslovie_bool[2] = (this.global1.data[6] >= 990);
											this.uslovie_text[2] = "Diplomatic reputation isn't less than  99";
										}
										this.uslovie_bool[3] = this.global1.allcountries[this.selected_country].Help;
										this.uslovie_text[3] = "We've sent analysts";
										return;
									}
									if (this.this_type == 29)
									{
										this.this_opis = "Restore trade relations";
										this.number_uslovie = 3;
										this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
										this.uslovie_text[0] = "Trade relations weren't restored";
										if (this.global1.data[6] <= 900)
										{
											this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
											this.uslovie_text[1] = "Hoxhaism isn't the dominant ideology";
											this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Stasi;
											this.uslovie_text[2] = "Ramiz Aliya supported";
											return;
										}
										this.uslovie_bool[1] = (this.global1.data[6] > 900);
										this.uslovie_text[1] = "Diplomatic reputation is more than 90";
										this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Stasi;
										this.uslovie_text[2] = "Ramiz Aliya wasn't supported";
										return;
									}
									else
									{
										if (this.this_type == 30)
										{
											this.this_opis = "Invite to the Economic Union";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
											this.uslovie_text[0] = "The USSR is not in the CMEA and we are in the Alliance";
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
											this.uslovie_text[1] = "This country is not in the CMEA";
											this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[2] = "Trade relations were restored";
											this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[3] = "We are not integrating into the EEC";
											return;
										}
										if (this.this_type == 31)
										{
											this.this_opis = "Support the Ramiz Aliya regime";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
											this.uslovie_text[0] = "Ramiz Aliya wasn't supported";
											this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
											this.uslovie_text[1] = "Ramiz Alia is in power";
											this.uslovie_bool[2] = (this.global1.data[6] > 590);
											this.uslovie_text[2] = "Diplomatic reputation is more than 59";
											this.uslovie_bool[3] = (this.global1.data[9] >= 10);
											this.uslovie_text[3] = "There are free agent networks";
											return;
										}
										if (this.this_type == 32)
										{
											this.this_opis = "Support the ruling party";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
											this.uslovie_text[0] = "The ruling party wasn't supported";
											this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[1] = "This country is in the Secret Agreement";
											this.uslovie_bool[2] = (this.global1.data[6] > 690);
											this.uslovie_text[2] = "Diplomatic reputation is more than 69";
											this.uslovie_bool[3] = (this.global1.data[9] >= 10);
											this.uslovie_text[3] = "There are free agent networks";
											return;
										}
										if (this.this_type == 33)
										{
											this.this_opis = "Invite to integrate into the EEC";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[0] = "We are integrating into the EEC";
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Vyshi;
											this.uslovie_text[1] = "They are not integrating into the EEC";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].isOVD;
											this.uslovie_text[2] = "This country is not in the Warsaw Pact";
											this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy == 2);
											this.uslovie_text[3] = "This country has liberalized";
											return;
										}
										if (this.this_type == 34)
										{
											this.this_opis = "Send financial assistance";
											this.number_uslovie = 3;
											this.uslovie_bool[0] = (this.global1.data[6] > 390);
											this.uslovie_text[0] = "Diplomatic reputation is more than 39";
											this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
											this.uslovie_text[1] = "They did not liberalize";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
											this.uslovie_text[2] = "You did not send them financial assistance";
											if (this.global1.data[8] < 30)
											{
												this.uslovie_bool[2] = (this.global1.data[8] >= 30);
												this.uslovie_text[2] = "It needs 3 from your budget";
												return;
											}
											if (!this.global1.allcountries[this.selected_country].Donat || this.selected_country == 35)
											{
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
												this.uslovie_text[2] = "You did not send them financial assistance";
												return;
											}
											if (!this.global1.is_konst_max)
											{
												this.uslovie_bool[2] = this.global1.is_konst_max;
												this.uslovie_text[2] = "We have a constitutional majority";
												return;
											}
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
											this.uslovie_text[2] = "Wait until the next year";
											return;
										}
										else
										{
											if (this.this_type == 35)
											{
												this.this_opis = "Provide military and special services assistance";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[6] > (3 - this.global1.allcountries[this.selected_country].Gosstroy) * 300 - 200);
												this.uslovie_text[0] = "Diplomatic reputation is more than " + ((3 - this.global1.allcountries[this.selected_country].Gosstroy) * 300 - 200) / 10;
												this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
												this.uslovie_text[1] = "They are not liberalized";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[2] = "Military and special services assistance wasn't provided";
												this.uslovie_bool[3] = (this.global1.data[9] >= 10);
												this.uslovie_text[3] = "There are two free agent networks";
												return;
											}
											if (this.this_type == 36)
											{
												this.this_opis = "Invite to the Economic Union";
												this.number_uslovie = 4;
												if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 790);
													this.uslovie_text[0] = "Diplomatic reputation is more than 79";
												}
												else if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 690);
													this.uslovie_text[0] = "Diplomatic reputation is more than 69";
												}
												else if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 800);
													this.uslovie_text[0] = "Diplomatic reputation between 39 and 80";
												}
												else
												{
													this.uslovie_bool[0] = (this.global1.data[6] <= 390);
													this.uslovie_text[0] = "Diplomatic reputation is less than 40";
												}
												this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
												this.uslovie_text[1] = "They are not in the CMEA";
												this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isSEV;
												this.uslovie_text[2] = "We are in the Economic Alliance";
												this.uslovie_bool[3] = (!this.global1.allcountries[this.selected_country].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi);
												this.uslovie_text[3] = "They and we are not integrating into the EEC";
												return;
											}
											if (this.this_type == 37)
											{
												this.this_opis = "Invite to a military pact";
												this.number_uslovie = 4;
												if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 890);
													this.uslovie_text[0] = "Diplomatic reputation is more than 89";
												}
												else if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 790);
													this.uslovie_text[0] = "Diplomatic reputation is more than 79";
												}
												else if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
												{
													this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 600);
													this.uslovie_text[0] = "Diplomatic reputation between 39 and 60";
												}
												else
												{
													this.uslovie_bool[0] = (this.global1.data[6] < 200);
													this.uslovie_text[0] = "Diplomatic reputation is less than 20";
												}
												this.uslovie_bool[1] = (!this.global1.allcountries[this.selected_country].isOVD && this.global1.allcountries[this.selected_country].isSEV);
												this.uslovie_text[1] = "They are not in the Warsaw Pact, but in CMEA";
												this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isOVD;
												this.uslovie_text[2] = "We are in the Military Pact";
												this.uslovie_bool[3] = (!this.global1.allcountries[this.selected_country].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi);
												this.uslovie_text[3] = "They and we are not integrating into the EEC";
												return;
											}
											if (this.this_type == 38)
											{
												this.this_opis = "To deepen the trade relations";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[6] < 300 + (28 - this.selected_country) * 100);
												this.uslovie_text[0] = "Diplomatic reputation is less than " + (30 + (28 - this.selected_country) * 10).ToString();
												this.uslovie_bool[1] = (this.global1.data[27] > 0);
												this.uslovie_text[1] = "There is at least one fully open border";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Trade relations were not deepened";
												return;
											}
											if (this.this_type == 39)
											{
												this.this_opis = "Invite to integrate into the EEC";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[0] = "We are integrating into the EEC";
												this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Vyshi;
												this.uslovie_text[1] = "They are not integrating into the EEC";
												this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Trade relations were deepened";
												this.uslovie_bool[3] = !this.global1.allcountries[7].isSEV;
												this.uslovie_text[3] = "The USSR is not in the CMEA";
												return;
											}
											if (this.this_type == 40)
											{
												this.this_opis = "Restore friendly relations";
												this.number_uslovie = 2;
												this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 800);
												this.uslovie_text[0] = "Diplomatic reputation between 39 and 80";
												this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[1] = "Friendly relations were not restored";
												return;
											}
											if (this.this_type == 41)
											{
												this.this_opis = "Invite to trade and customs union";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
												this.uslovie_text[0] = "The USSR is not in the CMEA and we are in the Alliance";
												this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
												this.uslovie_text[1] = "Wasn't invited to the trade and customs union";
												this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Friendly relations were restored";
												this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[3] = "We aren't integrating into the EEC";
												return;
											}
											if (this.this_type == 42)
											{
												this.this_opis = "Restore full relations with the new government of Myanmar";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[0] = "Relations with this country were not restored";
												this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy == 9 || this.global1.allcountries[this.selected_country].Gosstroy == 0);
												this.uslovie_text[1] = "The new government has already seized all power";
												this.uslovie_bool[2] = (this.global1.data[6] > 790);
												this.uslovie_text[2] = "Diplomatic reputation is more than 79";
												return;
											}
											if (this.this_type == 46)
											{
												this.this_opis = "Convince our allies to impose sanctions for supporting terrorism in Afghanistan";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[6] > 590);
												this.uslovie_text[0] = "Diplomatic reputation is more than 59";
												this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[1] = "We are not integrating into the EEC";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
												this.uslovie_text[2] = "Weren't imposed sanctions";
												this.uslovie_bool[3] = this.global1.is_konst_max;
												this.uslovie_text[3] = "We have a constitutional majority";
												return;
											}
											if (this.this_type == 52)
											{
												this.this_opis = "Decline sanctions";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[6] < 400);
												this.uslovie_text[0] = "Diplomatic reputation is less than 40";
												this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].isOVD || !this.global1.allcountries[7].isOVD);
												this.uslovie_text[1] = "We and USSR aren't in the same military alliance";
												this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Help;
												this.uslovie_text[2] = "Were imposed sanctions";
												return;
											}
											if (this.this_type == 47)
											{
												this.this_opis = "Recognize Syrian Lebanon and break off relations with Israeli one";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[6] > 790);
												this.uslovie_text[0] = "Diplomatic reputation is more than 79";
												this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[1] = "We are not integrating into the EEC";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
												this.uslovie_text[2] = "Syrian Lebanon weren't recognized";
												return;
											}
											if (this.this_type == 48)
											{
												this.this_opis = "Bribe officials and get blueprints and technologies for the production of nuclear weapons";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[9] >= 100);
												this.uslovie_text[0] = "Free agent networks are more than 9";
												this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[1] = "We are not integrating into the EEC";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[2] = "Officials weren't bribed";
												if (this.global1.data[0] != 10 || this.global1.event_done[255])
												{
													this.uslovie_bool[3] = (this.global1.data[8] >= 250);
													this.uslovie_text[3] = "You have 25 money in your budget";
													return;
												}
												this.uslovie_bool[3] = this.global1.event_done[255];
												this.uslovie_text[3] = "Do we want them?";
												return;
											}
											else if (this.this_type == 50)
											{
												this.this_opis = "Bribe officials and get blueprints and technologies for the production of nuclear weapons";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[9] >= 50);
												this.uslovie_text[0] = "Free agent networks are more than 4";
												this.uslovie_bool[1] = this.global1.allcountries[7].Vyshi;
												this.uslovie_text[1] = "The USSR doesn't exist";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
												this.uslovie_text[2] = "Officials weren't bribed";
												if (this.global1.data[0] != 10 || this.global1.event_done[255])
												{
													this.uslovie_bool[3] = (this.global1.data[8] >= 100);
													this.uslovie_text[3] = "You have 10 money in your budget";
													return;
												}
												this.uslovie_bool[3] = this.global1.event_done[255];
												this.uslovie_text[3] = "Do we want them?";
												return;
											}
											else
											{
												if (this.this_type == 49)
												{
													this.this_opis = "Help in the development of oil production";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
													this.uslovie_text[0] = "Conservatives are in power in Yemen";
													this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[1] = "Didn't help";
													this.uslovie_bool[2] = (this.global1.data[8] >= 30);
													this.uslovie_text[2] = "You have 3 money in your budget";
													return;
												}
												if (this.this_type == 53)
												{
													this.this_opis = "Invest in oil production";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
													this.uslovie_text[0] = "Wasn't invested this year";
													this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[1] = "Was helped in the development";
													this.uslovie_bool[2] = (this.global1.data[8] >= 30);
													this.uslovie_text[2] = "You have 3 money in your budget";
													return;
												}
												if (this.this_type == 54)
												{
													this.this_opis = "Sign the agreement on Detente";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[0] = "Wasn't signed this month";
													this.uslovie_bool[1] = (this.global1.data[9] >= this.global1.data[6] / 20);
													this.uslovie_text[1] = "Agent networks: " + (this.global1.data[6] / 200).ToString() + "." + Mathf.Abs(this.global1.data[6] / 20 % 10).ToString();
													this.uslovie_bool[2] = (this.global1.data[8] >= this.global1.data[6] / 20);
													this.uslovie_text[2] = "Money you have in your budget: " + (this.global1.data[6] / 200).ToString() + "." + Mathf.Abs(this.global1.data[6] / 20 % 10).ToString();
													this.uslovie_bool[3] = (this.global1.data[10] > 500);
													this.uslovie_text[3] = "Threat of NATO is more than 50";
													return;
												}
												if (this.this_type == 55)
												{
													this.this_opis = "Put money on a secret account";
													this.number_uslovie = 1;
													this.uslovie_bool[0] = (this.global1.data[8] >= 80);
													this.uslovie_text[0] = "Money you have in your budget: 8";
													return;
												}
												if (this.this_type == 57)
												{
													this.this_opis = "Return Bessarabia to the Romanian fold";
													this.number_uslovie = 4;
													if (this.global1.data[59] == 0)
													{
														this.uslovie_bool[0] = this.global1.allcountries[7].Vyshi;
														this.uslovie_text[0] = "The USSR collapsed";
													}
													else
													{
														this.uslovie_bool[0] = (this.global1.data[59] == 0);
														this.uslovie_text[0] = "Bessarabia isn't ours";
													}
													this.uslovie_bool[1] = (this.global1.data[11] == 0 || this.global1.data[31] >= 700);
													this.uslovie_text[1] = "Ceausescu or nationalism in Romania";
													this.uslovie_bool[2] = (this.global1.data[9] >= 100);
													this.uslovie_text[2] = "Agent networks: 10";
													this.uslovie_bool[3] = (this.global1.data[8] >= 60);
													this.uslovie_text[3] = "Money you have in your budget: 6";
													return;
												}
												if (this.this_type == 58)
												{
													this.this_opis = string.Concat(new string[]
													{
														"Support pro-american right-wing groupments (The leftists: ",
														(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
														".",
														Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
														")"
													});
													this.number_uslovie = 4;
													this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[0] = "Left-wing groupments aren't supported";
													this.uslovie_bool[1] = (this.global1.data[8] >= 8);
													this.uslovie_text[1] = "Money you have in your budget: 0,8";
													this.uslovie_bool[2] = (this.global1.data[9] >= 10);
													this.uslovie_text[2] = "There is one free agent network";
													this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
													this.uslovie_text[3] = "1-99";
													return;
												}
												if (this.this_type == 59)
												{
													if (this.global1.allcountries[this.selected_country].Westalgie <= 975)
													{
														this.this_opis = string.Concat(new string[]
														{
															"Support antiamerican left-wing groupments (The leftists: ",
															(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
															".",
															Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
															")"
														});
													}
													else
													{
														this.this_opis = string.Concat(new string[]
														{
															"Establish antiamerican left-wing groupments (The leftists: ",
															(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
															".",
															Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
															")"
														});
													}
													this.number_uslovie = 4;
													this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
													this.uslovie_text[0] = "Right-wing groupments aren't supported";
													this.uslovie_bool[1] = (this.global1.data[8] >= 8);
													this.uslovie_text[1] = "Money you have in your budget: 0,8";
													this.uslovie_bool[2] = (this.global1.data[9] >= 10);
													this.uslovie_text[2] = "There is one free agent network";
													this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
													this.uslovie_text[3] = "They are alive and aren't established";
													return;
												}
												if (this.this_type == 60)
												{
													this.this_opis = string.Concat(new string[]
													{
														"Provide humanitarian assistance to their people (The leftists: ",
														(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
														".",
														Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
														")"
													});
													this.number_uslovie = 2;
													this.uslovie_bool[0] = (this.global1.data[8] >= 20);
													this.uslovie_text[0] = "Money you have in your budget: 2";
													this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
													this.uslovie_text[1] = "1-99";
													return;
												}
												if (this.this_type == 61)
												{
													this.this_opis = "Fully open one of the borders";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.data[27] < 5);
													this.uslovie_text[0] = "There is at least one not fully open border";
													this.uslovie_bool[1] = (this.global1.data[6] < 600);
													this.uslovie_text[1] = "Diplomatic reputation is less than 60";
													this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].Help;
													this.uslovie_text[2] = "We didn't touch borders this month";
													return;
												}
												if (this.this_type == 62)
												{
													this.this_opis = "Open one of the borders as paid";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.data[28] < 5);
													this.uslovie_text[0] = "There is at least one free border";
													this.uslovie_bool[1] = (this.global1.data[6] < 800);
													this.uslovie_text[1] = "Diplomatic reputation is less than 80";
													this.uslovie_bool[2] = (this.global1.data[6] > 400);
													this.uslovie_text[2] = "Diplomatic reputation is more than 40";
													this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Help;
													this.uslovie_text[3] = "We didn't touch borders this month";
													return;
												}
												if (this.this_type == 63)
												{
													this.this_opis = "Close one of the borders";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] > 0);
													this.uslovie_text[0] = "There is at least one not closed border";
													this.uslovie_bool[1] = (this.global1.data[6] > 800);
													this.uslovie_text[1] = "Diplomatic reputation is more than 80";
													this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].Help;
													this.uslovie_text[2] = "We didn't touch borders this month";
													return;
												}
												if (this.this_type == 64)
												{
													this.this_opis = "Obtain an exclusive right to extract resources";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Westalgie >= 1000 || this.global1.allcountries[this.global1.data[0]].Vyshi);
													this.uslovie_text[0] = "Left-wing has 100 control or we are integrating into the EEC";
													this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.allcountries[this.selected_country].Westalgie <= 0);
													this.uslovie_text[1] = "We are not integrating into the EEC or left-wing has 0 control";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
													this.uslovie_text[2] = "Rights haven't been obtained yet";
													return;
												}
												if (this.this_type == 65)
												{
													this.this_opis = "Establish a connection with the Japanese Communists.";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.data[6] < 850);
													this.uslovie_text[0] = "Diplomatic reputation is less than 85";
													this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
													this.uslovie_text[1] = "We are not integrating into the EEC";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[2] = "The connection hasn't been established yet";
													this.uslovie_bool[3] = (this.global1.data[14] <= 3 && this.global1.data[14] > 0);
													this.uslovie_text[3] = "Satisfy the view of JCP on communism";
													return;
												}
												if (this.this_type == 66)
												{
													this.this_opis = "Establish trade relations with Japan";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].isOVD || !this.global1.allcountries[7].isOVD);
													this.uslovie_text[0] = "We aren't in the same military alliance with the USSR";
													this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
													this.uslovie_text[1] = "We are not integrating into the EEC";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
													this.uslovie_text[2] = "Trade hasn't been established yet";
													this.uslovie_bool[3] = !this.global1.allcountries[44].Vyshi;
													this.uslovie_text[3] = "Left parties' alliance is in the lead in the Japanese parliament";
													return;
												}
												if (this.this_type == 67)
												{
													this.this_opis = "Invite in our economic union";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = !this.global1.allcountries[7].isOVD;
													this.uslovie_text[0] = "The USSR isn't in the Warsaw Pact";
													if (this.global1.allcountries[this.selected_country].isSEV)
													{
														this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
														this.uslovie_text[1] = "Greece isn't in our economic union";
													}
													else if (!this.global1.event_done[50])
													{
														this.uslovie_bool[1] = this.global1.event_done[50];
														this.uslovie_text[1] = "The 1989 year elections were held";
													}
													else
													{
														this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
														this.uslovie_text[1] = "The Socialist Coalition is at the head";
													}
													this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Torg && this.global1.allcountries[this.global1.data[0]].isSEV);
													this.uslovie_text[2] = "The trade is active";
													this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
													this.uslovie_text[3] = "We are not integrating into the EEC";
													return;
												}
												if (this.this_type == 69)
												{
													this.this_opis = "Use Indian mediators to support Rohana Wijeweera";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.allcountries[19].Torg && this.global1.allcountries[16].Torg);
													this.uslovie_text[0] = "Close relations with India and China";
													this.uslovie_bool[1] = !this.global1.allcountries[46].Donat;
													this.uslovie_text[1] = "You haven't helped them";
													this.uslovie_bool[2] = (this.global1.data[8] > 30);
													this.uslovie_text[2] = "Money in your budget more than 3";
													this.uslovie_bool[3] = (this.global1.data[20] < 3 && this.global1.data[21] == 1989);
													this.uslovie_text[3] = "Earlier than March of 1989";
													return;
												}
												if (this.this_type == 70)
												{
													this.this_opis = "Organize the Security Service for Rohana Wijeweera";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.allcountries[46].Donat && !this.global1.allcountries[46].Stasi);
													this.uslovie_text[0] = "You helped them, but didn't orginize the Service";
													this.uslovie_bool[1] = (this.global1.data[9] > 30);
													this.uslovie_text[1] = "Agent networks more than 3";
													this.uslovie_bool[2] = this.global1.allcountries[19].Help;
													this.uslovie_text[2] = "Received asylum in India";
													this.uslovie_bool[3] = (this.global1.data[20] < 11 && this.global1.data[21] == 1989);
													this.uslovie_text[3] = "Earlier than November of 1989";
													return;
												}
												if (this.this_type == 71)
												{
													this.this_opis = "To provoke an uprising of the PLF";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.allcountries[46].Donat && this.global1.allcountries[46].Stasi);
													this.uslovie_text[0] = "PLF is ready";
													this.uslovie_bool[1] = (this.global1.allcountries[46].Gosstroy != 0);
													this.uslovie_text[1] = "Old government";
													this.uslovie_bool[2] = (this.global1.data[9] > 50);
													this.uslovie_text[2] = "Agent networks more than 5";
													this.uslovie_bool[3] = (this.global1.data[8] > 50);
													this.uslovie_text[3] = "Money in your budget more than 5";
													return;
												}
												if (this.this_type == 72)
												{
													this.this_opis = "Secretly finance Noel Browne";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
													this.uslovie_text[0] = "Not a Westernizer";
													this.uslovie_bool[1] = (this.global1.data[8] > 80);
													this.uslovie_text[1] = "Money in your budget more than 8";
													this.uslovie_bool[2] = (this.global1.data[21] == 1989);
													this.uslovie_text[2] = "Earlier than 1990";
													this.uslovie_bool[3] = !this.global1.allcountries[29].Donat;
													this.uslovie_text[3] = "Haven't helped them";
													return;
												}
												if (this.this_type == 73)
												{
													this.this_opis = "To eliminate Dick Spring";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
													this.uslovie_text[0] = "Not a Westernizer";
													this.uslovie_bool[1] = (this.global1.data[9] > 150);
													this.uslovie_text[1] = "Agent networks more than 15";
													this.uslovie_bool[2] = (this.global1.data[21] == 1989);
													this.uslovie_text[2] = "Earlier than 1990";
													this.uslovie_bool[3] = !this.global1.allcountries[29].Stasi;
													this.uslovie_text[3] = "Haven't eliminated him yet";
													return;
												}
												if (this.this_type == 74)
												{
													this.this_opis = "Create a united party of Labor and left parties";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (this.global1.allcountries[29].Stasi && this.global1.allcountries[29].Donat && ((this.global1.data[20] < 11 && this.global1.data[21] <= 1990) || this.global1.data[21] <= 1989));
													this.uslovie_text[0] = "Everything is ready! (before November 1990)";
													this.uslovie_bool[1] = this.global1.science[2];
													this.uslovie_text[1] = "You have SORM";
													this.uslovie_bool[2] = (this.global1.allcountries[29].Gosstroy != 1);
													this.uslovie_text[2] = "The Lefts haven't won the elections of 1990 yet";
													this.uslovie_bool[3] = (this.global1.data[10] <= 510);
													this.uslovie_text[3] = "The threat of NATO is less than 51";
													return;
												}
												if (this.this_type == 75)
												{
													this.this_opis = "Commit an act of terrorism against Kaysone Phomvihane";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
													this.uslovie_text[0] = "Not a Westernizer";
													this.uslovie_bool[1] = (this.global1.data[9] > 100);
													this.uslovie_text[1] = "Agent networks more than 10";
													this.uslovie_bool[2] = (this.global1.data[21] <= 1990);
													this.uslovie_text[2] = "Earlier than 1991";
													this.uslovie_bool[3] = !this.global1.allcountries[22].Stasi;
													this.uslovie_text[3] = "Didn't commit it";
													return;
												}
												if (this.this_type == 76)
												{
													this.this_opis = "Help the faction of Souphanouvong-Phuoimu";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = this.global1.allcountries[22].Stasi;
													this.uslovie_text[0] = "Commit the act of terrorism";
													this.uslovie_bool[1] = (this.global1.data[9] > 50 && this.global1.data[8] > 50);
													this.uslovie_text[1] = "Agent networks and money more than 5";
													this.uslovie_bool[2] = ((this.global1.data[20] < 8 && this.global1.data[21] <= 1991) || this.global1.data[21] <= 1990);
													this.uslovie_text[2] = "Earlier than August of 1991";
													this.uslovie_bool[3] = !this.global1.allcountries[22].Donat;
													this.uslovie_text[3] = "Didn't help the faction yet";
													return;
												}
												if (this.this_type == 77)
												{
													this.this_opis = "Start offensive";
													this.number_uslovie = 1;
													this.uslovie_bool[0] = (this.global1.data[90] != 1 || this.global1.data[92] != 1 || this.global1.data[93] != 1 || this.global1.data[94] != 1);
													this.uslovie_text[0] = "There are some places where we can attack";
													return;
												}
												if (this.this_type == 78)
												{
													this.this_opis = "Send reinforcements to the Afghan army";
													this.number_uslovie = 2;
													this.uslovie_bool[0] = (this.global1.data[8] >= 30);
													this.uslovie_text[0] = "Money in your budget: 3";
													this.uslovie_bool[1] = (this.global1.data[9] >= 50);
													this.uslovie_text[1] = "Agent networks more than 5";
													return;
												}
												if (this.this_type == 79)
												{
													this.this_opis = "Go to the active trading phase";
													this.number_uslovie = 4;
													if (this.global1.data[0] == 18)
													{
														this.uslovie_bool[0] = (this.global1.data[77] <= 0);
														this.uslovie_text[0] = "Embargo was removed";
														this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
														this.uslovie_text[2] = "We are not in the COMECON";
													}
													else if (this.global1.data[0] == 12 || this.global1.data[0] == 10)
													{
														this.uslovie_bool[0] = (this.global1.data[101] == 0 || (this.global1.data[98] < 0 && this.global1.data[68] > 3) || this.global1.data[112] == 1);
														this.uslovie_text[0] = "Peace Treaty Signed or nuclear weapons abandoned";
														this.uslovie_bool[2] = (this.global1.data[101] == 0);
														this.uslovie_text[2] = "Do not have nuclear weapons";
													}
													else
													{
														this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
														this.uslovie_text[0] = "We areintegrating into the EEC";
														this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
														this.uslovie_text[2] = "We are not in the COMECON";
													}
													this.uslovie_bool[1] = (this.global1.data[6] <= 500);
													this.uslovie_text[1] = "Diplomatic reputation is less than 50";
													this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Torg;
													this.uslovie_text[3] = "We don't have an active trade";
													return;
												}
												if (this.this_type == 80)
												{
													this.this_opis = "Invite foreign investors";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
													this.uslovie_text[0] = "We have an active trade";
													this.uslovie_bool[1] = (this.global1.data[6] <= 300);
													this.uslovie_text[1] = "Diplomatic reputation is less than 30";
													this.uslovie_bool[2] = (this.global1.data[16] >= 13 || this.global1.data[70] > 0);
													this.uslovie_text[2] = "Relevant economy";
													this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Money;
													this.uslovie_text[3] = "No investment received";
													return;
												}
												if (this.this_type == 81)
												{
													this.this_opis = "To economically influence to reform the Korean system";
													this.number_uslovie = 4;
													this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].isSEV;
													this.uslovie_text[0] = "This country is in the CMEA";
													this.uslovie_bool[1] = (this.global1.allcountries[16].isSEV && this.global1.allcountries[16].Gosstroy == 0);
													this.uslovie_text[1] = "China is in the CMEA and is socialist country";
													int num = 0;
													if (this.global1.allcountries[16].isSEV && this.global1.allcountries[16].Gosstroy == 0 && !this.global1.allcountries[7].isSEV && this.global1.allcountries[this.selected_country].Gosstroy != 0)
													{
														foreach (Country country in this.global1.allcountries)
														{
															if (country != null && country.isSEV)
															{
																num++;
															}
														}
													}
													this.uslovie_bool[2] = (this.global1.allcountries[7].isSEV || num > 8);
													this.uslovie_text[2] = "The USSR is in the CMEA or more than 8 countries";
													this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
													this.uslovie_text[3] = "Doesn't have orthodox socialism";
													return;
												}
												if (this.this_type == 82)
												{
													this.this_opis = "Increase the number of UDBA residents in Italy";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.data[9] >= 50);
													this.uslovie_text[0] = "Agent networks - 5";
													this.uslovie_bool[1] = (this.global1.data[6] <= 450);
													this.uslovie_text[1] = "Diplomatic reputation is less than 45";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
													this.uslovie_text[2] = "has not already used";
													return;
												}
												if (this.this_type == 83)
												{
													this.this_opis = "Support the Communist Fighting Brigades";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.data[8] >= 50);
													this.uslovie_text[0] = "Money in the budget - 5";
													this.uslovie_bool[1] = (this.global1.data[6] <= 750);
													this.uslovie_text[1] = "Diplomatic reputation is less than 75";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Money;
													this.uslovie_text[2] = "Has not already used";
													return;
												}
												if (this.this_type == 84)
												{
													this.this_opis = "Enter the active trading phase";
													this.number_uslovie = 3;
													this.uslovie_bool[0] = (this.global1.data[27] > 0);
													this.uslovie_text[0] = "There is at least one open border";
													this.uslovie_bool[1] = (this.global1.data[6] < 350);
													this.uslovie_text[1] = "Diplomatic reputation less than 35.0";
													this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
													this.uslovie_text[2] = "Not started trading with them";
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
			if (this.this_type == 1)
			{
				this.this_opis = "Пригласить иностранных инвесторов";
				this.number_uslovie = 3;
				this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Money;
				this.uslovie_text[0] = "Инвесторы не приглашены";
				if (this.global1.allcountries[21].Gosstroy == 2)
				{
					this.uslovie_bool[1] = (this.global1.data[16] == 13);
					this.uslovie_text[1] = "Рыночная экономика";
				}
				else
				{
					this.uslovie_bool[1] = (this.global1.data[16] >= 12);
					this.uslovie_text[1] = "Не плановая экономика/автоматизация";
				}
				this.uslovie_bool[2] = (this.global1.data[6] < 800 - this.global1.allcountries[21].Gosstroy * 200);
				this.uslovie_text[2] = "Дипломатическая репутация меньше " + (80 - this.global1.allcountries[21].Gosstroy * 20);
				return;
			}
			if (this.this_type == 2)
			{
				this.this_opis = "Договор о дружбе с Францией";
				this.number_uslovie = 2;
				this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
				this.uslovie_text[0] = "Договор не подписан";
				if (this.global1.allcountries[21].Gosstroy != 2)
				{
					this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[31] >= 750);
					this.uslovie_text[1] = "Национализм и не евроинтегрируемся";
					return;
				}
				if (this.global1.allcountries[7].isSEV)
				{
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Дипломатическая репутация меньше 80";
					return;
				}
				this.uslovie_bool[1] = (this.global1.data[6] < 490);
				this.uslovie_text[1] = "Дипломатическая репутация меньше 49";
				return;
			}
			else
			{
				if (this.this_type == 3)
				{
					this.this_opis = "Войти в сообщество по интеграции в ЕЭС";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
					this.uslovie_text[0] = "Не интегрируемся";
					if (this.global1.data[14] >= 4 && this.global1.data[16] >= 13)
					{
						this.uslovie_bool[1] = (this.global1.data[6] < 600);
						this.uslovie_text[1] = "Дипломатическая репутация меньше 60";
					}
					else
					{
						this.uslovie_bool[1] = (this.global1.data[6] < 400);
						this.uslovie_text[1] = "Дипломатическая репутация меньше 40";
					}
					this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isOVD;
					this.uslovie_text[2] = "Не состоять в ОВД";
					this.uslovie_bool[3] = (this.global1.data[16] > 11);
					this.uslovie_text[3] = "Не плановая экономика/не автоматизация";
					return;
				}
				if (this.this_type == 4)
				{
					this.this_opis = "Присоединиться к международному эмбарго";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
					this.uslovie_text[0] = "Не углубляли торговлю";
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Дипломатическая репутация меньше 80";
					this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
					this.uslovie_text[2] = "Нет эмбарго";
					this.uslovie_bool[3] = (this.global1.data[32] == 1);
					this.uslovie_text[3] = "Введены международные санкции";
					return;
				}
				if (this.this_type == 5)
				{
					this.this_opis = "Углубить развитие торговых отношений";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
					this.uslovie_text[0] = "Не углубляли торговлю";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Дипломатическая репутация выше 60";
					this.uslovie_bool[2] = (!this.global1.allcountries[this.selected_country].Help && !this.global1.allcountries[8].Torg);
					this.uslovie_text[2] = "Нет эмбарго и дружбы с Ираном";
					this.uslovie_bool[3] = (this.global1.data[32] == 1);
					this.uslovie_text[3] = "Введены международные санкции";
					return;
				}
				if (this.this_type == 6 && !this.global1.allcountries[this.selected_country].Donat)
				{
					this.this_opis = "Положить деньги на счета сторонников реформ, чтобы те отказались от своей позиции";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
					this.uslovie_text[0] = "Не клали денег";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Дипломатическая репутация выше 60";
					this.uslovie_bool[2] = (this.global1.data[8] >= 10);
					this.uslovie_text[2] = "Денег в бюджете: 1.0";
					return;
				}
				if (this.this_type == 6 && this.global1.allcountries[this.selected_country].Donat)
				{
					this.this_opis = "Признать ливийские претензии в Чаде и оказать помощь вооружением";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
					this.uslovie_text[0] = "Не поддержали";
					this.uslovie_bool[1] = (this.global1.data[6] > 650);
					this.uslovie_text[1] = "Дипломатическая репутация выше 65";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Агентурных сетей: 1.0";
					return;
				}
				if (this.this_type == 7)
				{
					this.this_opis = "Подтолкнуть на социалистический путь развития и начать торговлю";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
					this.uslovie_text[0] = "Ещё нет";
					this.uslovie_bool[1] = (this.global1.data[6] >= 650);
					this.uslovie_text[1] = "Дипломатическая репутация выше 65";
					this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Donat && this.global1.allcountries[this.selected_country].Stasi);
					this.uslovie_text[2] = "Вмешаться во внутрненнюю политику Каддафи";
					return;
				}
				if (this.this_type == 8)
				{
					this.this_opis = "Наладить чрезвычайный канал поставок нефти";
					this.number_uslovie = 3;
					this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
					this.uslovie_text[0] = "Вмешались во внутрненнюю политику Каддафи";
					this.uslovie_bool[1] = (this.global1.data[6] > 600);
					this.uslovie_text[1] = "Дипломатическая репутация выше 60";
					this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
					this.uslovie_text[2] = "Не наладили поставки";
					return;
				}
				if (this.this_type == 9)
				{
					this.this_opis = "Оказать продовольственную помощь";
					this.number_uslovie = 2;
					if (!this.global1.allcountries[this.selected_country].Donat)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
						this.uslovie_text[0] = "Не направили продовольствие";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "Есть конституционное большинство";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
						this.uslovie_text[0] = "Подождите до нового года";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 590);
					this.uslovie_text[1] = "Дипломатическая репутация выше 59";
					return;
				}
				if (this.this_type == 10)
				{
					this.this_opis = "Оказать военную помощь";
					this.number_uslovie = 3;
					if (!this.global1.allcountries[this.selected_country].Stasi)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Не оказали военную помощь";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "Есть конституционное большинство";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Подождите до нового года";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 790);
					this.uslovie_text[1] = "Дипломатическая репутация выше 79";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Есть свободные агентурные сети";
					return;
				}
				if (this.this_type == 11)
				{
					this.this_opis = "Оказать помощь RAF";
					this.number_uslovie = 3;
					if (!this.global1.allcountries[this.selected_country].Stasi)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Не оказали помощь";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "Есть конституционное большинство";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Подождите до нового года";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 790);
					this.uslovie_text[1] = "Дипломатическая репутация выше 79";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Есть свободные агентурные сети";
					return;
				}
				if (this.this_type == 12)
				{
					this.this_opis = "Начать антивоенную кампанию через \"Генералы за мир\" ";
					this.number_uslovie = 4;
					if (!this.global1.allcountries[this.selected_country].Help)
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Help;
						this.uslovie_text[0] = "Не начали кампанию";
					}
					else if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[0] = this.global1.is_konst_max;
						this.uslovie_text[0] = "Есть конституционное большинство";
					}
					else
					{
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Help;
						this.uslovie_text[0] = "Подождите до нового года";
					}
					this.uslovie_bool[1] = (this.global1.data[6] > 390);
					this.uslovie_text[1] = "Дипломатическая репутация выше 39";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Есть свободные агентурные сети";
					this.uslovie_bool[3] = (this.global1.data[0] == 1);
					this.uslovie_text[3] = "Германская Демократическая Республика";
					return;
				}
				if (this.this_type == 13)
				{
					this.this_opis = "Оказать гуманитарную помощь";
					this.number_uslovie = 2;
					this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
					this.uslovie_text[0] = "Не оказали гуманитарную помощь  в этом году";
					this.uslovie_bool[1] = (this.global1.data[6] > 190);
					this.uslovie_text[1] = "Дипломатическая репутация выше 19";
					return;
				}
				if (this.this_type == 14)
				{
					this.this_opis = "Оказать помощь Милошевичу";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Stasi && !this.global1.allcountries[this.selected_country].Help);
					this.uslovie_text[0] = "Не оказали военную помощь в этом году";
					this.uslovie_bool[1] = (this.global1.data[6] > 390);
					this.uslovie_text[1] = "Дипломатическая репутация выше 39";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Есть свободные агентурные сети";
					this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy >= 2);
					this.uslovie_text[3] = "На выборах в Югославии победили националисты";
					return;
				}
				if (this.this_type == 51)
				{
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.this_opis = "Подписать договор о военной взаимопомощи";
					}
					else
					{
						this.this_opis = "Подписать договор об экономической взаимопомощи";
					}
					this.number_uslovie = 4;
					if (this.global1.data[59] != 2 || this.global1.data[0] != 6)
					{
						this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[0] = "Милошевичу оказана поддержка";
					}
					else
					{
						this.uslovie_bool[0] = (this.global1.data[59] != 2);
						this.uslovie_text[0] = "Македония в Югославии";
					}
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.uslovie_bool[1] = (this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[this.selected_country].isOVD);
					}
					else
					{
						this.uslovie_bool[1] = (this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[this.selected_country].isSEV);
					}
					this.uslovie_text[1] = "Мы состоим в альянсе";
					this.uslovie_bool[2] = (this.global1.data[9] >= 50);
					this.uslovie_text[2] = "Есть пять агентурных сетей";
					if (this.global1.allcountries[this.selected_country].isSEV)
					{
						this.uslovie_bool[3] = (!this.global1.allcountries[7].isOVD || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 0));
					}
					else
					{
						this.uslovie_bool[3] = (!this.global1.allcountries[7].isSEV || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy <= 0));
					}
					this.uslovie_text[3] = "Советский Союз не в альянсе или победил Алкснис";
					return;
				}
				if (this.this_type == 15)
				{
					this.this_opis = "Оказать помощь сепаратистам";
					this.number_uslovie = 4;
					this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Help && !this.global1.allcountries[this.selected_country].Stasi);
					this.uslovie_text[0] = "Не оказали военную помощь";
					this.uslovie_bool[1] = (this.global1.data[6] < 800);
					this.uslovie_text[1] = "Дипломатическая репутация меньше 80";
					this.uslovie_bool[2] = (this.global1.data[9] >= 10);
					this.uslovie_text[2] = "Есть свободные агентурные сети";
					this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy >= 2);
					this.uslovie_text[3] = "На выборах в Югославии победили националисты";
					return;
				}
				if (this.this_type == 44)
				{
					this.this_opis = "Устранить Дэн Сяопина, позволив консерваторам удержать власть";
					this.number_uslovie = 4;
					if (this.global1.data[6] >= 800)
					{
						this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
						this.uslovie_text[0] = "Наладили торговлю";
					}
					else
					{
						this.uslovie_bool[0] = (this.global1.data[6] >= 800);
						this.uslovie_text[0] = "Дипломатическая репутация больше 80";
					}
					this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy == 9);
					this.uslovie_text[1] = "Оппозиция в Китае подавлена";
					this.uslovie_bool[2] = (this.global1.data[9] >= 100 && this.global1.data[8] >= 100);
					this.uslovie_text[2] = "Свободных агентурных сетей 10 (и денег тоже)";
					if (this.global1.data[21] >= 1991 && (this.global1.data[0] == 12 || this.global1.data[0] == 10 || this.global1.data[0] == 18))
					{
						this.uslovie_bool[3] = this.global1.science[2];
						this.uslovie_text[3] = "Развита зарубежная сеть";
						return;
					}
					if (this.global1.data[21] >= 1991)
					{
						this.uslovie_bool[3] = this.global1.science[2];
						this.uslovie_text[3] = "Есть СОРМ";
						return;
					}
					if (this.global1.data[21] >= 1991)
					{
						this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
						this.uslovie_text[3] = "Не устранили Сяопина";
						return;
					}
					if (!this.global1.is_konst_max)
					{
						this.uslovie_bool[3] = this.global1.is_konst_max;
						this.uslovie_text[3] = "Есть конституционное большинство";
						return;
					}
					this.uslovie_bool[3] = (this.global1.data[21] >= 1991);
					this.uslovie_text[3] = "Не раньше 1991 года";
					return;
				}
				else
				{
					if (this.this_type == 16)
					{
						this.this_opis = "Наладить дипотношения";
						this.number_uslovie = 3;
						this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Donat && !this.global1.allcountries[this.selected_country].Torg);
						this.uslovie_text[0] = "Не наладили отношения";
						if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
						{
							this.uslovie_bool[1] = (this.global1.data[6] < 880);
							this.uslovie_text[1] = "Дипломатическая репутация меньше 88";
						}
						else if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
						{
							this.uslovie_bool[1] = (this.global1.data[6] < 700);
							this.uslovie_text[1] = "Дипломатическая репутация меньше 70";
						}
						else if (this.global1.allcountries[this.selected_country].Gosstroy == 0 || this.global1.allcountries[this.selected_country].Gosstroy == 9)
						{
							this.uslovie_bool[1] = (this.global1.data[6] > 600);
							this.uslovie_text[1] = "Дипломатическая репутация больше 60";
						}
						this.uslovie_bool[2] = !this.global1.allcountries[38].Donat;
						this.uslovie_text[2] = "Китай не был осуждён";
						return;
					}
					if (this.this_type == 17)
					{
						this.this_opis = "Перейти в фазу активной торговли";
						this.number_uslovie = 3;
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
						this.uslovie_text[0] = "Не наладили торговлю";
						this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Donat || this.global1.allcountries[this.selected_country].Help);
						this.uslovie_text[1] = "Наладили отношения";
						if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
						{
							this.uslovie_bool[2] = (this.global1.data[6] < 880);
							this.uslovie_text[2] = "Дипломатическая репутация меньше 88";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
						{
							this.uslovie_bool[2] = (this.global1.data[6] < 500);
							this.uslovie_text[2] = "Дипломатическая репутация меньше 50";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
						{
							this.uslovie_bool[2] = (this.global1.data[6] > 600);
							this.uslovie_text[2] = "Дипломатическая репутация больше 60";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
						{
							this.uslovie_bool[2] = (this.global1.data[8] >= 60);
							this.uslovie_text[2] = "Денег в бюджете: 6";
							return;
						}
					}
					else if (this.this_type == 18)
					{
						this.this_opis = "Пригласить в таможенный союз";
						this.number_uslovie = 4;
						if (!this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							this.uslovie_bool[1] = !this.global1.allcountries[16].isSEV;
							this.uslovie_text[1] = "Китай не в таможенном союзе";
						}
						else
						{
							this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
							this.uslovie_text[1] = "Мы не Евроинтегрируемся";
						}
						this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Torg && this.global1.allcountries[this.global1.data[0]].isSEV);
						this.uslovie_text[2] = "Наладили торговлю и есть альянс";
						if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
						{
							this.uslovie_bool[3] = (this.global1.data[6] > 390);
							this.uslovie_text[3] = "Дипломатическая репутация больше 39";
							this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
							this.uslovie_text[0] = "СССР не в СЭВ";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 2)
						{
							this.uslovie_bool[3] = (this.global1.data[6] < 400);
							this.uslovie_text[3] = "Дипломатическая репутация меньше 40";
							this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
							this.uslovie_text[0] = "СССР не в СЭВ";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 0 && this.global1.data[7] > 700)
						{
							this.uslovie_bool[3] = (this.global1.data[7] > 700);
							this.uslovie_text[3] = "Стабильность соцлагеря больше 70";
							this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
							this.uslovie_text[0] = "Консерватизм в Китае";
							return;
						}
						if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
						{
							this.uslovie_bool[3] = (this.global1.data[8] >= 100);
							this.uslovie_text[3] = "Денег в бюджете более 10";
							this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
							this.uslovie_text[0] = "Консерватизм в Китае";
							return;
						}
						this.uslovie_bool[3] = (this.global1.data[6] < 800);
						this.uslovie_text[3] = "Дипломатическая репутация меньше 80";
						this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
						this.uslovie_text[0] = "СССР не в СЭВ";
						return;
					}
					else if (this.this_type == 19)
					{
						this.this_opis = "Подписать контракт о поставках оружия в Индию";
						this.number_uslovie = 2;
						this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
						this.uslovie_text[0] = "Не подписан контракт";
						if (this.global1.allcountries[this.selected_country].Gosstroy != 2)
						{
							this.uslovie_bool[1] = (this.global1.data[6] > 590);
							this.uslovie_text[1] = "Дипломатическая репутация больше 59";
							this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isSEV;
							this.uslovie_text[2] = "Мы в СЭВ";
							return;
						}
						this.uslovie_bool[1] = (this.global1.data[6] < 490);
						this.uslovie_text[1] = "Дипломатическая репутация меньше 49";
						this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
						this.uslovie_text[2] = "Мы не в СЭВ";
						return;
					}
					else
					{
						if (this.this_type == 20)
						{
							this.this_opis = "Получить гарантии политического убежища партаппарату";
							this.number_uslovie = 3;
							this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[0] = "Подписан контракт";
							this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Help;
							this.uslovie_text[1] = "Гарантии не получены";
							this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
							this.uslovie_text[2] = "ИНК у власти";
							return;
						}
						if (this.this_type == 45)
						{
							this.this_opis = "Спровоцировать новую индо-пакистанскую войну";
							this.number_uslovie = 4;
							this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
							this.uslovie_text[0] = "ИНК у власти";
							this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[1] = "Оружие поставлено";
							this.uslovie_bool[2] = (this.global1.data[9] >= 100);
							this.uslovie_text[2] = "Свободных агентурных сетей 10";
							this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
							this.uslovie_text[3] = "Не спровоцировали войну";
							return;
						}
						if (this.this_type == 21)
						{
							this.this_opis = "Восстановить дипотношения";
							this.number_uslovie = 3;
							this.uslovie_bool[0] = (!this.global1.allcountries[this.selected_country].Donat && !this.global1.allcountries[this.selected_country].Torg);
							this.uslovie_text[0] = "Отношения не восстановлены";
							this.uslovie_bool[1] = (this.global1.data[6] > 190 && this.global1.data[6] < 800);
							this.uslovie_text[1] = "Дипломатическая репутация между 19 и 80";
							this.uslovie_bool[2] = this.global1.event_done[14];
							this.uslovie_text[2] = "Началась либерализация Ирана";
							return;
						}
						if (this.this_type == 22)
						{
							this.this_opis = "Перейти в фазу активной торговли";
							this.number_uslovie = 3;
							this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Donat;
							this.uslovie_text[0] = "Отношения восстановлены";
							this.uslovie_bool[1] = (this.global1.data[6] > 250 && this.global1.data[6] < 800);
							this.uslovie_text[1] = "Дипломатическая репутация между 25 и 80";
							this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[2] = "Не начата торговля";
							return;
						}
						if (this.this_type == 23)
						{
							this.this_opis = "Пригласить в экономический союз";
							this.number_uslovie = 4;
							if (this.selected_country == 8)
							{
								this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
								this.uslovie_text[0] = "СССР не в СЭВ и мы в альянсе";
							}
							else
							{
								this.uslovie_bool[0] = (this.global1.allcountries[14].Gosstroy == 0 && this.global1.allcountries[8].isSEV && this.global1.allcountries[35].isSEV);
								this.uslovie_text[0] = "Социализм в Ираке и Сирия с Ираном в СЭВ";
							}
							this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
							this.uslovie_text[1] = "Эта страна не в СЭВ";
							this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
							this.uslovie_text[2] = "Активно идет торговля";
							this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
							this.uslovie_text[3] = "Мы не Евроинтегрируемся";
							return;
						}
						if (this.this_type == 24)
						{
							if (!this.global1.allcountries[7].Vyshi)
							{
								this.this_opis = "Поддержать консерваторов в СССР";
							}
							else
							{
								this.this_opis = "Поддержать коммунистов в СНГ";
							}
							this.number_uslovie = 4;
							this.uslovie_bool[0] = (this.global1.data[9] > 29);
							this.uslovie_text[0] = "Свободных агентурных сетей >= 3";
							this.uslovie_bool[1] = (this.global1.data[14] <= 3);
							this.uslovie_text[1] = "У нас социализм";
							this.uslovie_bool[2] = (this.global1.data[8] > 9);
							this.uslovie_text[2] = "Денег в бюджете больше 1";
							if (!this.global1.allcountries[this.selected_country].Stasi)
							{
								this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
								this.uslovie_text[3] = "Не поддержали их";
								return;
							}
							if (!this.global1.is_konst_max)
							{
								this.uslovie_bool[3] = this.global1.is_konst_max;
								this.uslovie_text[3] = "Есть конституционное большинство";
								return;
							}
							this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Stasi;
							this.uslovie_text[3] = "Подождите до следующего года";
							return;
						}
						else if (this.this_type == 25)
						{
							this.this_opis = "Выдать кредит СССР";
							this.number_uslovie = 3;
							this.uslovie_bool[0] = (this.global1.data[8] > 30);
							this.uslovie_text[0] = "Денег в бюджете больше 3";
							this.uslovie_bool[1] = this.global1.allcountries[7].isSEV;
							this.uslovie_text[1] = "СССР в СЭВ";
							if (this.global1.data[8] < 30)
							{
								this.uslovie_bool[2] = (this.global1.data[8] >= 30);
								this.uslovie_text[2] = "Нужно 3 из бюджета";
								return;
							}
							if (!this.global1.allcountries[this.selected_country].Donat)
							{
								this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
								this.uslovie_text[2] = "Кредит не выдан";
								return;
							}
							this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
							this.uslovie_text[2] = "Подождите";
							return;
						}
						else
						{
							if (this.this_type == 26)
							{
								this.this_opis = "Продать лицензии на оружие";
								this.number_uslovie = 2;
								this.uslovie_bool[0] = (this.global1.data[6] > 390);
								this.uslovie_text[0] = "Дипломатическая репутация больше 39";
								this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Donat;
								this.uslovie_text[1] = "Не продали лицензии";
								return;
							}
							if (this.this_type == 43)
							{
								this.this_opis = "Тайно продать чертежи и технологии изготовления Ядерного оружия";
								this.number_uslovie = 4;
								this.uslovie_bool[0] = (this.global1.data[6] > 790 || this.global1.data[8] <= 0);
								this.uslovie_text[0] = "Дип. репутация больше 79 или отрицательный бюджет";
								this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Stasi;
								this.uslovie_text[1] = "Не продали чертежи и технологии";
								this.uslovie_bool[2] = (this.global1.data[36] == 1);
								this.uslovie_text[2] = "У нас есть чертежи и технологии";
								this.uslovie_bool[3] = (this.global1.data[9] >= 30);
								this.uslovie_text[3] = "Свободных агентурных сетей более двух";
								return;
							}
							if (this.this_type == 27)
							{
								this.this_opis = "Отправить аналитиков для изучения Чучхе";
								this.number_uslovie = 2;
								this.uslovie_bool[0] = (this.global1.data[6] > 790);
								this.uslovie_text[0] = "Дипломатическая репутация больше 79";
								this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Help;
								this.uslovie_text[1] = "Не направили аналитиков";
								return;
							}
							if (this.this_type == 28)
							{
								this.this_opis = "Пригласить в экономический союз";
								this.number_uslovie = 3;
								if (!this.global1.allcountries[this.global1.data[0]].Vyshi)
								{
									this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
									this.uslovie_text[0] = "СССР не в СЭВ";
								}
								else
								{
									this.uslovie_bool[0] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
									this.uslovie_text[0] = "Мы не евроинтегрируемся";
								}
								this.uslovie_bool[1] = (!this.global1.allcountries[this.selected_country].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
								this.uslovie_text[1] = "Страна не в СЭВ и мы в Альянсе";
								if (this.selected_country != 35 && this.selected_country != 47)
								{
									this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
									this.uslovie_text[2] = "Они не либерализовались";
									return;
								}
								if (this.selected_country != 47)
								{
									this.uslovie_bool[2] = (this.global1.data[9] >= 10);
									this.uslovie_text[2] = "Есть свободные агентурные сети";
									return;
								}
								this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
								this.uslovie_text[2] = "СФНО победил на выборах ";
								return;
							}
							else
							{
								if (this.this_type == 56)
								{
									this.this_opis = "Пригласить в экономический союз";
									this.number_uslovie = 4;
									this.uslovie_bool[0] = !this.global1.allcountries[7].isSEV;
									this.uslovie_text[0] = "СССР не в СЭВ";
									this.uslovie_bool[1] = (!this.global1.allcountries[this.selected_country].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
									this.uslovie_text[1] = "Страна не в СЭВ и мы в Альянсе";
									if (this.global1.data[0] == 5 && this.global1.data[11] == 0)
									{
										this.uslovie_bool[2] = (this.global1.data[11] == 0);
										this.uslovie_text[2] = "Чаушеску у власти";
									}
									else
									{
										this.uslovie_bool[2] = (this.global1.data[6] >= 990);
										this.uslovie_text[2] = "Дипломатическая репутация не менее 99";
									}
									this.uslovie_bool[3] = this.global1.allcountries[this.selected_country].Help;
									this.uslovie_text[3] = "Направили аналитиков";
									return;
								}
								if (this.this_type == 29)
								{
									this.this_opis = "Восстановить торговые отношения";
									this.number_uslovie = 3;
									this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
									this.uslovie_text[0] = "Не начата торговля";
									if (this.global1.data[6] <= 900)
									{
										this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
										this.uslovie_text[1] = "Не господствует ходжаизм";
										this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Stasi;
										this.uslovie_text[2] = "Мы поддержали Рамиза Алию";
										return;
									}
									this.uslovie_bool[1] = (this.global1.data[6] > 900);
									this.uslovie_text[1] = "Дипломатическая репутация больше 90";
									this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Stasi;
									this.uslovie_text[2] = "Мы поддержали Рамиза Алию";
									return;
								}
								else
								{
									if (this.this_type == 30)
									{
										this.this_opis = "Пригласить в экономический союз";
										this.number_uslovie = 4;
										this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
										this.uslovie_text[0] = "СССР не в СЭВ и мы в Альянсе";
										this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
										this.uslovie_text[1] = "Эта страна не в СЭВ";
										this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
										this.uslovie_text[2] = "Идет торговля";
										this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
										this.uslovie_text[3] = "Мы не евроинтегрируемся";
										return;
									}
									if (this.this_type == 31)
									{
										this.this_opis = "Поддержать режим Рамиза Алии";
										this.number_uslovie = 4;
										this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
										this.uslovie_text[0] = "Не поддержали режим";
										this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
										this.uslovie_text[1] = "Рамиз Алия у власти";
										this.uslovie_bool[2] = (this.global1.data[6] > 590);
										this.uslovie_text[2] = "Дипломатическая репутация больше 59";
										this.uslovie_bool[3] = (this.global1.data[9] >= 10);
										this.uslovie_text[3] = "Есть свободные агентурные сети";
										return;
									}
									if (this.this_type == 32)
									{
										this.this_opis = "Поддержать правящую партию";
										this.number_uslovie = 4;
										this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
										this.uslovie_text[0] = "Не поддержали режим";
										this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Torg;
										this.uslovie_text[1] = "Есть тайный договор";
										this.uslovie_bool[2] = (this.global1.data[6] > 690);
										this.uslovie_text[2] = "Дипломатическая репутация больше 69";
										this.uslovie_bool[3] = (this.global1.data[9] >= 10);
										this.uslovie_text[3] = "Есть свободные агентурные сети";
										return;
									}
									if (this.this_type == 33)
									{
										this.this_opis = "Пригласить интегрироваться в ЕЭС";
										this.number_uslovie = 4;
										this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
										this.uslovie_text[0] = "Мы евроинтегрируемся";
										this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Vyshi;
										this.uslovie_text[1] = "Они не евроинтегрируются";
										this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].isOVD;
										this.uslovie_text[2] = "Эта страна не в ОВД";
										this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy == 2);
										this.uslovie_text[3] = "Эта страна либерализовалась";
										return;
									}
									if (this.this_type == 34)
									{
										this.this_opis = "Выслать финансовую помощь";
										this.number_uslovie = 3;
										this.uslovie_bool[0] = (this.global1.data[6] > 390);
										this.uslovie_text[0] = "Дипломатическая репутация больше 39";
										this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
										this.uslovie_text[1] = "Они не либерализовались";
										if (this.global1.data[8] < 30)
										{
											this.uslovie_bool[2] = (this.global1.data[8] >= 30);
											this.uslovie_text[2] = "Нужно 3 из бюджета";
											return;
										}
										if (!this.global1.allcountries[this.selected_country].Donat || this.selected_country == 35)
										{
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
											this.uslovie_text[2] = "Не высылали финансов";
											return;
										}
										if (!this.global1.is_konst_max)
										{
											this.uslovie_bool[2] = this.global1.is_konst_max;
											this.uslovie_text[2] = "Есть конституционное большинство";
											return;
										}
										this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Donat;
										this.uslovie_text[2] = "Подождите до нового года";
										return;
									}
									else
									{
										if (this.this_type == 35)
										{
											this.this_opis = "Оказать помощь спецслужбами";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (this.global1.data[6] > (3 - this.global1.allcountries[this.selected_country].Gosstroy) * 300 - 200);
											this.uslovie_text[0] = "Дипломатическая репутация больше " + ((3 - this.global1.allcountries[this.selected_country].Gosstroy) * 300 - 200) / 10;
											this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy != 2);
											this.uslovie_text[1] = "Они не либерализовались";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
											this.uslovie_text[2] = "Не оказали помощь";
											this.uslovie_bool[3] = (this.global1.data[9] >= 20);
											this.uslovie_text[3] = "Есть две свободные агентурные сети";
											return;
										}
										if (this.this_type == 36)
										{
											this.this_opis = "Пригласить в экономический союз";
											this.number_uslovie = 4;
											if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 790);
												this.uslovie_text[0] = "Дипломатическая репутация больше 79";
											}
											else if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 690);
												this.uslovie_text[0] = "Дипломатическая репутация больше 69";
											}
											else if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 800);
												this.uslovie_text[0] = "Дипломатическая репутация между 39 и 80";
											}
											else
											{
												this.uslovie_bool[0] = (this.global1.data[6] <= 390);
												this.uslovie_text[0] = "Дипломатическая репутация меньше 40";
											}
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
											this.uslovie_text[1] = "Они не в СЭВ";
											this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isSEV;
											this.uslovie_text[2] = "Мы в СЭВ";
											this.uslovie_bool[3] = (!this.global1.allcountries[this.selected_country].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi);
											this.uslovie_text[3] = "Они и мы не евроинтегрируемся";
											return;
										}
										if (this.this_type == 37)
										{
											this.this_opis = "Пригласить в военный договор";
											this.number_uslovie = 4;
											if (this.global1.allcountries[this.selected_country].Gosstroy == 9)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 890);
												this.uslovie_text[0] = "Дипломатическая репутация больше 89";
											}
											else if (this.global1.allcountries[this.selected_country].Gosstroy == 0)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 790);
												this.uslovie_text[0] = "Дипломатическая репутация больше 79";
											}
											else if (this.global1.allcountries[this.selected_country].Gosstroy == 1)
											{
												this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 600);
												this.uslovie_text[0] = "Дипломатическая репутация между 39 и 60";
											}
											else
											{
												this.uslovie_bool[0] = (this.global1.data[6] < 200);
												this.uslovie_text[0] = "Дипломатическая репутация меньше 20";
											}
											this.uslovie_bool[1] = (!this.global1.allcountries[this.selected_country].isOVD && this.global1.allcountries[this.selected_country].isSEV);
											this.uslovie_text[1] = "Они не в ОВД. Они в СЭВ.";
											this.uslovie_bool[2] = this.global1.allcountries[this.global1.data[0]].isOVD;
											this.uslovie_text[2] = "Мы в ОВД";
											this.uslovie_bool[3] = (!this.global1.allcountries[this.selected_country].Vyshi && !this.global1.allcountries[this.global1.data[0]].Vyshi);
											this.uslovie_text[3] = "Они и мы не евроинтегрируемся";
											return;
										}
										if (this.this_type == 38)
										{
											this.this_opis = "Углубить торговые отношения";
											this.number_uslovie = 3;
											this.uslovie_bool[0] = (this.global1.data[6] < 300 + (28 - this.selected_country) * 100);
											this.uslovie_text[0] = "Дипломатическая репутация меньше " + (30 + (28 - this.selected_country) * 10).ToString();
											this.uslovie_bool[1] = (this.global1.data[27] > 0);
											this.uslovie_text[1] = "Есть хоть одна полностью открытая граница";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[2] = "Не углублены торговые отношения";
											return;
										}
										if (this.this_type == 39)
										{
											this.this_opis = "Пригласить интегрироваться в ЕЭС";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[0] = "Мы евроинтегрируемся";
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Vyshi;
											this.uslovie_text[1] = "Они не евроинтегрируются";
											this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[2] = "Углублены торговые отношения";
											this.uslovie_bool[3] = !this.global1.allcountries[7].isSEV;
											this.uslovie_text[3] = "СССР не в СЭВ";
											return;
										}
										if (this.this_type == 40)
										{
											this.this_opis = "Восстановить дружеские отношения";
											this.number_uslovie = 2;
											this.uslovie_bool[0] = (this.global1.data[6] > 390 && this.global1.data[6] < 800);
											this.uslovie_text[0] = "Дипломатическая репутация между 39 и 80";
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[1] = "Не восстановлены дружеские отношения";
											return;
										}
										if (this.this_type == 41)
										{
											this.this_opis = "Пригласить в торгово-таможенный союз";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (!this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV);
											this.uslovie_text[0] = "СССР не в СЭВ и мы в Альянсе";
											this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
											this.uslovie_text[1] = "Не состоит в торгово-таможенном союзе";
											this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[2] = "Дружеские отношения восстановлены";
											this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[3] = "Мы не евроинтегрируемся";
											return;
										}
										if (this.this_type == 42)
										{
											this.this_opis = "Восстановить все отношения с новым правительством Мьянмы";
											this.number_uslovie = 3;
											this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Torg;
											this.uslovie_text[0] = "Отношения с этой страной не восстановлены";
											this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy == 9 || this.global1.allcountries[this.selected_country].Gosstroy == 0);
											this.uslovie_text[1] = "Новое правительство уже захватило всю полноту власти";
											this.uslovie_bool[2] = (this.global1.data[6] > 790);
											this.uslovie_text[2] = "Дипломатическая репутация больше 79";
											return;
										}
										if (this.this_type == 46)
										{
											this.this_opis = "Убедить союзников наложить санкции за поддержку терроризма в Афганистане";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (this.global1.data[6] > 590);
											this.uslovie_text[0] = "Дипломатическая репутация больше 59";
											this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[1] = "Мы не евроинтегрируемся";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
											this.uslovie_text[2] = "Не наложили санкции";
											this.uslovie_bool[3] = this.global1.is_konst_max;
											this.uslovie_text[3] = "Есть конституционное большинство";
											return;
										}
										if (this.this_type == 52)
										{
											this.this_opis = "Снять санкции";
											this.number_uslovie = 3;
											this.uslovie_bool[0] = (this.global1.data[6] < 400);
											this.uslovie_text[0] = "Дипломатическая репутация меньше 40";
											this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].isOVD || !this.global1.allcountries[7].isOVD);
											this.uslovie_text[1] = "Мы не в ОВД с СССР";
											this.uslovie_bool[2] = this.global1.allcountries[this.selected_country].Help;
											this.uslovie_text[2] = "Наложили санкции";
											return;
										}
										if (this.this_type == 47)
										{
											this.this_opis = "Признать сирийский Ливан и разорвать отношения с израильским";
											this.number_uslovie = 3;
											this.uslovie_bool[0] = (this.global1.data[6] > 790);
											this.uslovie_text[0] = "Дипломатическая репутация больше 79";
											this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[1] = "Мы не евроинтегрируемся";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
											this.uslovie_text[2] = "Не признали сирийский Ливан";
											return;
										}
										if (this.this_type == 48)
										{
											this.this_opis = "Подкупить чиновников и получить чертежи и технологии производства Ядерного оружия";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (this.global1.data[9] >= 100);
											this.uslovie_text[0] = "Свободных агентурных сетей: 10";
											this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
											this.uslovie_text[1] = "Мы не евроинтегрируемся";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
											this.uslovie_text[2] = "Не подкупили чиновников";
											if (this.global1.data[0] != 10 || this.global1.event_done[255])
											{
												this.uslovie_bool[3] = (this.global1.data[8] >= 250);
												this.uslovie_text[3] = "Свободных денег в бюджете: 25";
												return;
											}
											this.uslovie_bool[3] = this.global1.event_done[255];
											this.uslovie_text[3] = "Хотим ли мы?";
											return;
										}
										else if (this.this_type == 50)
										{
											this.this_opis = "Подкупить чиновников и получить чертежи и технологии производства Ядерного оружия";
											this.number_uslovie = 4;
											this.uslovie_bool[0] = (this.global1.data[9] >= 50);
											this.uslovie_text[0] = "Свободных агентурных сетей: 5";
											this.uslovie_bool[1] = this.global1.allcountries[7].Vyshi;
											this.uslovie_text[1] = "СССР не существует";
											this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Help;
											this.uslovie_text[2] = "Не подкупили чиновников";
											if (this.global1.data[0] != 10 || this.global1.event_done[255])
											{
												this.uslovie_bool[3] = (this.global1.data[8] >= 100);
												this.uslovie_text[3] = "Свободных денег в бюджете: 10";
												return;
											}
											this.uslovie_bool[3] = this.global1.event_done[255];
											this.uslovie_text[3] = "Хотим ли мы?";
											return;
										}
										else
										{
											if (this.this_type == 49)
											{
												this.this_opis = "Помочь с развитием нефтедобычи";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Gosstroy == 0);
												this.uslovie_text[0] = "Консерваторы пришли к власти в Йемене";
												this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[1] = "Не помогли";
												this.uslovie_bool[2] = (this.global1.data[8] >= 30);
												this.uslovie_text[2] = "Свободных денег в бюджете: 3";
												return;
											}
											if (this.this_type == 53)
											{
												this.this_opis = "Инвестировать в нефтедобычу";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
												this.uslovie_text[0] = "Не инвестировали в этом году";
												this.uslovie_bool[1] = this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[1] = "Помогли с развитием нефтедобычи";
												this.uslovie_bool[2] = (this.global1.data[8] >= 30);
												this.uslovie_text[2] = "Свободных денег в бюджете: 3";
												return;
											}
											if (this.this_type == 54)
											{
												this.this_opis = "Подписать договор о Разрядке";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[0] = "Не подписывали в этом месяце";
												this.uslovie_bool[1] = (this.global1.data[9] >= this.global1.data[6] / 20);
												this.uslovie_text[1] = "Агенутрных сетей: " + (this.global1.data[6] / 200).ToString() + "." + Mathf.Abs(this.global1.data[6] / 20 % 10).ToString();
												this.uslovie_bool[2] = (this.global1.data[8] >= this.global1.data[6] / 20);
												this.uslovie_text[2] = "Свободных денег в бюджете: " + (this.global1.data[6] / 200).ToString() + "." + Mathf.Abs(this.global1.data[6] / 20 % 10).ToString();
												this.uslovie_bool[3] = (this.global1.data[10] > 500);
												this.uslovie_text[3] = "Угроза НАТО больше 50";
												return;
											}
											if (this.this_type == 55)
											{
												this.this_opis = "Положить деньги на тайный счёт Партии в банке";
												this.number_uslovie = 1;
												this.uslovie_bool[0] = (this.global1.data[8] >= 80);
												this.uslovie_text[0] = "Свободных денег в бюджете: 8";
												return;
											}
											if (this.this_type == 57)
											{
												this.this_opis = "Вернуть Бессарабию в лоно Румынии";
												this.number_uslovie = 4;
												if (this.global1.data[59] == 0)
												{
													this.uslovie_bool[0] = this.global1.allcountries[7].Vyshi;
													this.uslovie_text[0] = "СССР распался";
												}
												else
												{
													this.uslovie_bool[0] = (this.global1.data[59] == 0);
													this.uslovie_text[0] = "Бессарабия не наша";
												}
												this.uslovie_bool[1] = (this.global1.data[11] == 0 || this.global1.data[31] >= 700);
												this.uslovie_text[1] = "Чаушеску или национализм в Румынии";
												this.uslovie_bool[2] = (this.global1.data[9] >= 100);
												this.uslovie_text[2] = "Агентурных сетей не менее 10";
												this.uslovie_bool[3] = (this.global1.data[8] >= 60);
												this.uslovie_text[3] = "Свободных денег в бюджете: 6";
												return;
											}
											if (this.this_type == 58)
											{
												this.this_opis = string.Concat(new string[]
												{
													"Поддержать проамериканские правые группировки (Левые: ",
													(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
													".",
													Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
													")"
												});
												this.number_uslovie = 4;
												this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[0] = "Не встали на сторону левых группировок";
												this.uslovie_bool[1] = (this.global1.data[8] >= 8);
												this.uslovie_text[1] = "Свободных денег в бюджете: 0,8";
												this.uslovie_bool[2] = (this.global1.data[9] >= 10);
												this.uslovie_text[2] = "Есть свободные агентурные сети";
												this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
												this.uslovie_text[3] = "1-99";
												return;
											}
											if (this.this_type == 59)
											{
												if (this.global1.allcountries[this.selected_country].Westalgie <= 975)
												{
													this.this_opis = string.Concat(new string[]
													{
														"Поддержать антиамериканские левые группировки (Левые: ",
														(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
														".",
														Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
														")"
													});
												}
												else
												{
													this.this_opis = string.Concat(new string[]
													{
														"Утвердить антиамериканские левые группировки (Левые: ",
														(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
														".",
														Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
														")"
													});
												}
												this.number_uslovie = 4;
												this.uslovie_bool[0] = !this.global1.allcountries[this.selected_country].Donat;
												this.uslovie_text[0] = "Не встали на сторону правых группировок";
												this.uslovie_bool[1] = (this.global1.data[8] >= 8);
												this.uslovie_text[1] = "Свободных денег в бюджете: 0,8";
												this.uslovie_bool[2] = (this.global1.data[9] >= 10);
												this.uslovie_text[2] = "Есть свободные агентурные сети";
												this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
												this.uslovie_text[3] = "Не пали и не утвердились";
												return;
											}
											if (this.this_type == 60)
											{
												this.this_opis = string.Concat(new string[]
												{
													"Выслать гуманитарную помощь населению (Левые: ",
													(this.global1.allcountries[this.selected_country].Westalgie / 10).ToString(),
													".",
													Mathf.Abs(this.global1.allcountries[this.selected_country].Westalgie % 10).ToString(),
													")"
												});
												this.number_uslovie = 2;
												this.uslovie_bool[0] = (this.global1.data[8] >= 20);
												this.uslovie_text[0] = "Свободных денег в бюджете: 2";
												this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Westalgie > 0 && this.global1.allcountries[this.selected_country].Westalgie < 1000);
												this.uslovie_text[1] = "1-99";
												return;
											}
											if (this.this_type == 61)
											{
												this.this_opis = "Полностью открыть одну из границ";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[27] < 5);
												this.uslovie_text[0] = "Есть хоть одна не открытая полностью граница";
												this.uslovie_bool[1] = (this.global1.data[6] < 600);
												this.uslovie_text[1] = "Дипломатическая репутация меньше 60";
												this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].Help;
												this.uslovie_text[2] = "Мы не трогали границы в этом месяце";
												return;
											}
											if (this.this_type == 62)
											{
												this.this_opis = "Платно открыть одну из границ";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[28] < 5);
												this.uslovie_text[0] = "Есть хоть одна не платная граница";
												this.uslovie_bool[1] = (this.global1.data[6] < 800);
												this.uslovie_text[1] = "Дипломатическая репутация меньше 80";
												this.uslovie_bool[2] = (this.global1.data[6] > 400);
												this.uslovie_text[2] = "Дипломатическая репутация больше 40";
												this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Help;
												this.uslovie_text[3] = "Мы не трогали границы в этом месяце";
												return;
											}
											if (this.this_type == 63)
											{
												this.this_opis = "Закрыть одну из границ";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] > 0);
												this.uslovie_text[0] = "Есть хоть одна не закрытая граница";
												this.uslovie_bool[1] = (this.global1.data[6] > 800);
												this.uslovie_text[1] = "Дипломатическая репутация больше 80";
												this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].Help;
												this.uslovie_text[2] = "Мы не трогали границы в этом месяце";
												return;
											}
											if (this.this_type == 64)
											{
												this.this_opis = "Получить эксклюзивные права добычи ресурсов";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.allcountries[this.selected_country].Westalgie >= 1000 || this.global1.allcountries[this.global1.data[0]].Vyshi);
												this.uslovie_text[0] = "Контроль левыми силами - 100 или Евроинтегрируемся";
												this.uslovie_bool[1] = (!this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.allcountries[this.selected_country].Westalgie <= 0);
												this.uslovie_text[1] = "Мы не Евроинтегрируемся или контроль левыми силами - 0";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Права не получены";
												return;
											}
											if (this.this_type == 65)
											{
												this.this_opis = "Установить связи с японскими коммунистами";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.data[6] < 850);
												this.uslovie_text[0] = "Дипломатическая репутация меньше 85";
												this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[1] = "Мы не Евроинтегрируемся";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[2] = "Связи еще не установлены";
												this.uslovie_bool[3] = (this.global1.data[14] <= 3 && this.global1.data[14] > 0);
												this.uslovie_text[3] = "Удовлетворяем взглядам КПЯ на коммунизм";
												return;
											}
											if (this.this_type == 66)
											{
												this.this_opis = "Установить торговые отношения с Японией";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].isOVD || !this.global1.allcountries[7].isOVD);
												this.uslovie_text[0] = "Не состоим в одном военном альянсе с СССР";
												this.uslovie_bool[1] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[1] = "Мы не Евроинтегрируемся";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Торговля не возобновлена";
												this.uslovie_bool[3] = !this.global1.allcountries[44].Vyshi;
												this.uslovie_text[3] = "Альянс левых партий лидирует в парламенте Японии";
												return;
											}
											if (this.this_type == 67)
											{
												this.this_opis = "Пригласить в экономический союз";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = !this.global1.allcountries[7].isOVD;
												this.uslovie_text[0] = "СССР не в ОВД";
												if (this.global1.allcountries[this.selected_country].isSEV)
												{
													this.uslovie_bool[1] = !this.global1.allcountries[this.selected_country].isSEV;
													this.uslovie_text[1] = "Греция не в СЭВ";
												}
												else if (!this.global1.event_done[50])
												{
													this.uslovie_bool[1] = this.global1.event_done[50];
													this.uslovie_text[1] = "Выборы 1989 года в Греции прошли";
												}
												else
												{
													this.uslovie_bool[1] = (this.global1.allcountries[this.selected_country].Gosstroy <= 1);
													this.uslovie_text[1] = "Социалистический блок возглавляет страну";
												}
												this.uslovie_bool[2] = (this.global1.allcountries[this.selected_country].Torg && this.global1.allcountries[this.global1.data[0]].isSEV);
												this.uslovie_text[2] = "Активно идет торговля";
												this.uslovie_bool[3] = !this.global1.allcountries[this.global1.data[0]].Vyshi;
												this.uslovie_text[3] = "Мы не Евроинтегрируемся";
												return;
											}
											if (this.this_type == 68)
											{
												this.this_opis = "Послать делегацию в Кувейт для создания дружественных отношений";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = this.global1.allcountries[14].Help;
												this.uslovie_text[0] = "Наложили эмбарго на Ирак";
												this.uslovie_bool[1] = (this.global1.event_done[81] || !this.global1.event_done[53]);
												this.uslovie_text[1] = "Страна не оккупирована";
												this.uslovie_bool[2] = (this.global1.allcountries[14].Gosstroy != 9);
												this.uslovie_text[2] = "Помогли свергнуть Саддама Хусейна";
												this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[3] = "Делегация еще не была послана.";
												return;
											}
											if (this.this_type == 69)
											{
												this.this_opis = "Использовать индийских посредников для поддержки Рохана Виджевира";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.allcountries[19].Torg && this.global1.allcountries[16].Torg);
												this.uslovie_text[0] = "Тесные отношения с Индией и Китаем";
												this.uslovie_bool[1] = !this.global1.allcountries[46].Donat;
												this.uslovie_text[1] = "Не оказали помощь";
												this.uslovie_bool[2] = (this.global1.data[8] > 30);
												this.uslovie_text[2] = "Денег в бюджете больше 3";
												this.uslovie_bool[3] = (this.global1.data[20] < 3 && this.global1.data[21] == 1989);
												this.uslovie_text[3] = "Раньше, чем март 1989";
												return;
											}
											if (this.this_type == 70)
											{
												this.this_opis = "Организовать Службу Безопасности для Рохана Виджевира";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.allcountries[46].Donat && !this.global1.allcountries[46].Stasi);
												this.uslovie_text[0] = "Оказали помощь, но не создали службу";
												this.uslovie_bool[1] = (this.global1.data[9] > 30);
												this.uslovie_text[1] = "Агентурных сетей больше 3";
												this.uslovie_bool[2] = this.global1.allcountries[19].Help;
												this.uslovie_text[2] = "Получили убежище в Индии";
												this.uslovie_bool[3] = (this.global1.data[20] < 11 && this.global1.data[21] == 1989);
												this.uslovie_text[3] = "Раньше, чем ноябрь 1989";
												return;
											}
											if (this.this_type == 71)
											{
												this.this_opis = "Спровоцировать восстание НОФ";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.allcountries[46].Donat && this.global1.allcountries[46].Stasi);
												this.uslovie_text[0] = "НОФ готова";
												this.uslovie_bool[1] = (this.global1.allcountries[46].Gosstroy != 0);
												this.uslovie_text[1] = "Старые власти";
												this.uslovie_bool[2] = (this.global1.data[9] > 50);
												this.uslovie_text[2] = "Агентурных сетей больше 5";
												this.uslovie_bool[3] = (this.global1.data[8] > 50);
												this.uslovie_text[3] = "Денег в бюджете больше 5";
												return;
											}
											if (this.this_type == 72)
											{
												this.this_opis = "Негласно профинансировать Ноэля Брауна";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
												this.uslovie_text[0] = "Не западники";
												this.uslovie_bool[1] = (this.global1.data[8] > 80);
												this.uslovie_text[1] = "Денег в бюджете больше 8";
												this.uslovie_bool[2] = (this.global1.data[21] == 1989);
												this.uslovie_text[2] = "Раньше, чем 1990";
												this.uslovie_bool[3] = !this.global1.allcountries[29].Donat;
												this.uslovie_text[3] = "Не финансировали";
												return;
											}
											if (this.this_type == 73)
											{
												this.this_opis = "Устранить Дика Спринга";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
												this.uslovie_text[0] = "Не западники";
												this.uslovie_bool[1] = (this.global1.data[9] > 150);
												this.uslovie_text[1] = "Агентурный сетей больше 15";
												this.uslovie_bool[2] = (this.global1.data[21] == 1989);
												this.uslovie_text[2] = "Раньше, чем 1990";
												this.uslovie_bool[3] = !this.global1.allcountries[29].Stasi;
												this.uslovie_text[3] = "Не устраняли";
												return;
											}
											if (this.this_type == 74)
											{
												this.this_opis = "Создать объединённую партию Лейбористов и левых";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (this.global1.allcountries[29].Stasi && this.global1.allcountries[29].Donat && ((this.global1.data[20] < 11 && this.global1.data[21] <= 1990) || this.global1.data[21] <= 1989));
												this.uslovie_text[0] = "Всё готово для единения (до ноября 1990)";
												this.uslovie_bool[1] = this.global1.science[2];
												this.uslovie_text[1] = "Есть СОРМ";
												this.uslovie_bool[2] = (this.global1.allcountries[29].Gosstroy != 1);
												this.uslovie_text[2] = "Левые ещё не победили на выборах 1990";
												this.uslovie_bool[3] = (this.global1.data[10] <= 510);
												this.uslovie_text[3] = "Угроза НАТО меньше 51";
												return;
											}
											if (this.this_type == 75)
											{
												this.this_opis = "Совершить теракт против Кейсона Фомвихана";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = (!this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[14] < 4);
												this.uslovie_text[0] = "Не западники";
												this.uslovie_bool[1] = (this.global1.data[9] > 100);
												this.uslovie_text[1] = "Агентурный сетей больше 10";
												this.uslovie_bool[2] = (this.global1.data[21] <= 1990);
												this.uslovie_text[2] = "Раньше, чем 1991";
												this.uslovie_bool[3] = !this.global1.allcountries[22].Stasi;
												this.uslovie_text[3] = "Не совершали теракт";
												return;
											}
											if (this.this_type == 76)
											{
												this.this_opis = "Оказать помощь фракции Суфанувонга-Фуми";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = this.global1.allcountries[22].Stasi;
												this.uslovie_text[0] = "Совершили теракт";
												this.uslovie_bool[1] = (this.global1.data[9] > 50 && this.global1.data[8] > 50);
												this.uslovie_text[1] = "Агентурный сетей и денег больше 5";
												this.uslovie_bool[2] = ((this.global1.data[20] < 8 && this.global1.data[21] <= 1991) || this.global1.data[21] <= 1990);
												this.uslovie_text[2] = "Раньше, чем август 1991";
												this.uslovie_bool[3] = !this.global1.allcountries[22].Donat;
												this.uslovie_text[3] = "Не помогли фракции";
												return;
											}
											if (this.this_type == 77)
											{
												this.this_opis = "Начать наступление";
												this.number_uslovie = 1;
												this.uslovie_bool[0] = (this.global1.data[90] != 1 || this.global1.data[92] != 1 || this.global1.data[93] != 1 || this.global1.data[94] != 1);
												this.uslovie_text[0] = "Есть куда воевать";
												return;
											}
											if (this.this_type == 78)
											{
												this.this_opis = "Отправить подкрепление афганской армии";
												this.number_uslovie = 2;
												this.uslovie_bool[0] = (this.global1.data[8] >= 30);
												this.uslovie_text[0] = "Денег в бюджете: 3";
												this.uslovie_bool[1] = (this.global1.data[9] >= 50);
												this.uslovie_text[1] = "Агентурный сетей больше 5";
												return;
											}
											if (this.this_type == 79)
											{
												this.this_opis = "Перейти в фазу активной торговли";
												this.number_uslovie = 4;
												if (this.global1.data[0] == 18)
												{
													this.uslovie_bool[0] = (this.global1.data[77] <= 0);
													this.uslovie_text[0] = "Эмбарго снято";
													this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
													this.uslovie_text[2] = "Мы не в СЭВ";
												}
												else if (this.global1.data[0] == 12 || this.global1.data[0] == 10)
												{
													this.uslovie_bool[0] = (this.global1.data[101] == 0 || (this.global1.data[98] < 0 && this.global1.data[68] > 3) || this.global1.data[112] == 1);
													this.uslovie_text[0] = "Мирный договор подписан или отказались от ядерного оружия";
													this.uslovie_bool[2] = (this.global1.data[101] == 0);
													this.uslovie_text[2] = "Нет ядерного оружия";
												}
												else
												{
													this.uslovie_bool[0] = this.global1.allcountries[this.global1.data[0]].Vyshi;
													this.uslovie_text[0] = "Мы евроинтегрируемся";
													this.uslovie_bool[2] = !this.global1.allcountries[this.global1.data[0]].isSEV;
													this.uslovie_text[2] = "Мы не в СЭВ";
												}
												this.uslovie_bool[1] = (this.global1.data[6] <= 500);
												this.uslovie_text[1] = "Дипломатическая репутация менее 50";
												this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[3] = "Не наладили торговлю";
												return;
											}
											if (this.this_type == 80)
											{
												this.this_opis = "Пригласить иностранных инвесторов";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[0] = "Наладили торвголю";
												this.uslovie_bool[1] = (this.global1.data[6] <= 300);
												this.uslovie_text[1] = "Дипломатическая репутация менее 30";
												this.uslovie_bool[2] = (this.global1.data[16] >= 13 || this.global1.data[70] > 0);
												this.uslovie_text[2] = "Соответствующая экономика";
												this.uslovie_bool[3] = !this.global1.allcountries[this.selected_country].Money;
												this.uslovie_text[3] = "Инвестиции не получены";
												return;
											}
											if (this.this_type == 81)
											{
												this.this_opis = "Экономически повлиять на реформирование корейской системы";
												this.number_uslovie = 4;
												this.uslovie_bool[0] = this.global1.allcountries[this.selected_country].isSEV;
												this.uslovie_text[0] = "Эта страна в СЭВ";
												this.uslovie_bool[1] = (this.global1.allcountries[16].isSEV && this.global1.allcountries[16].Gosstroy == 0);
												this.uslovie_text[1] = "Китай в СЭВ и социалистический";
												int num2 = 0;
												if (this.global1.allcountries[16].isSEV && this.global1.allcountries[16].Gosstroy == 0 && !this.global1.allcountries[7].isSEV && this.global1.allcountries[this.selected_country].Gosstroy != 0)
												{
													foreach (Country country2 in this.global1.allcountries)
													{
														if (country2 != null && country2.isSEV)
														{
															num2++;
														}
													}
												}
												this.uslovie_bool[2] = (this.global1.allcountries[7].isSEV || num2 > 8);
												this.uslovie_text[2] = "СССР в СЭВ или в эконом. союзе более 8 стран";
												this.uslovie_bool[3] = (this.global1.allcountries[this.selected_country].Gosstroy != 0);
												this.uslovie_text[3] = "Не ортодоксально социалистический";
												return;
											}
											if (this.this_type == 82)
											{
												this.this_opis = "Увеличить число резидентов УДБА в Италии";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[9] >= 50);
												this.uslovie_text[0] = "Агентурных сетей - 5";
												this.uslovie_bool[1] = (this.global1.data[6] <= 450);
												this.uslovie_text[1] = "Дипломатическая репутация менее 45";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Stasi;
												this.uslovie_text[2] = "Не использовали";
												return;
											}
											if (this.this_type == 83)
											{
												this.this_opis = "Поддержать Коммунистические Боевые Бригады";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[8] >= 50);
												this.uslovie_text[0] = "Денег в бюджете - 5";
												this.uslovie_bool[1] = (this.global1.data[6] <= 750);
												this.uslovie_text[1] = "Дипломатическая репутация менее 75";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Money;
												this.uslovie_text[2] = "Не использовали";
												return;
											}
											if (this.this_type == 84)
											{
												this.this_opis = "Перейти в фазу активной торговли";
												this.number_uslovie = 3;
												this.uslovie_bool[0] = (this.global1.data[27] > 0);
												this.uslovie_text[0] = "Есть хоть одна открытая граница";
												this.uslovie_bool[1] = (this.global1.data[6] < 350);
												this.uslovie_text[1] = "Дипломатическая репутация мееньше 35.0";
												this.uslovie_bool[2] = !this.global1.allcountries[this.selected_country].Torg;
												this.uslovie_text[2] = "Не начата торговля";
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

	// Token: 0x0600005C RID: 92 RVA: 0x0001A49C File Offset: 0x0001869C
	private void OnMouseDown()
	{
		if (this.is_active && (this.number_uslovie == 0 || (this.number_uslovie == 1 && this.uslovie_bool[0]) || (this.number_uslovie == 2 && this.uslovie_bool[0] && this.uslovie_bool[1]) || (this.number_uslovie == 3 && this.uslovie_bool[0] && this.uslovie_bool[1] && this.uslovie_bool[2]) || (this.number_uslovie == 4 && this.uslovie_bool[0] && this.uslovie_bool[1] && this.uslovie_bool[2] && this.uslovie_bool[3])))
		{
			if (this.this_type == 1)
			{
				this.global1.data[8] += 50;
				this.global1.allcountries[this.selected_country].Money = true;
				this.global1.data[4] += 50;
				this.global1.data[22] -= 50;
				this.global1.data[1] += 150;
				this.global1.data[24] -= 3;
			}
			else if (this.this_type == 46)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[10] += 10;
				this.global1.data[6] += 5;
				this.global1.data[7] += 5;
				this.global1.data[2] += 100;
				this.global1.data[24]++;
			}
			else if (this.this_type == 52)
			{
				this.global1.allcountries[this.selected_country].Help = false;
				this.global1.data[10] -= 25;
				this.global1.data[37]--;
				this.global1.data[6] -= 10;
				this.global1.data[7] -= 5;
				this.global1.data[2] += 100;
				this.global1.data[24]--;
			}
			else if (this.this_type == 47)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[10] += 25;
				this.global1.data[6] -= 10;
				this.global1.data[7] += 2;
				this.global1.data[2] -= 250;
			}
			else if (this.this_type == 48)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.povod = true;
				this.global1.data[36] = 1;
				this.global1.data[8] -= 250;
				this.global1.data[9] -= 100;
				if (this.global1.data[6] > 0)
				{
					this.global1.data[6] += 6;
				}
				else
				{
					this.global1.data[6] = 20;
				}
				this.global1.data[2] -= 250;
				this.global1.data[1] -= 150;
			}
			else if (this.this_type == 50)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.povod = true;
				this.global1.data[36] = 1;
				this.global1.data[8] -= 100;
				this.global1.data[9] -= 50;
				if (this.global1.data[6] > 0)
				{
					this.global1.data[6] += 6;
				}
				else
				{
					this.global1.data[6] = 20;
				}
				this.global1.data[1] -= 150;
			}
			else if (this.this_type == 49)
			{
				this.global1.data[8] -= 30;
				this.global1.data[9] += 10;
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[22] += 50;
				this.global1.data[24] -= 2;
			}
			else if (this.this_type == 53)
			{
				this.global1.data[8] -= 30;
				this.global1.data[55]++;
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.allcountries[this.selected_country].Torg = true;
			}
			else if (this.this_type == 54)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= this.global1.data[6] / 20;
				this.global1.data[8] -= this.global1.data[6] / 20;
				this.global1.data[6] -= 20;
				this.global1.data[2] += 150;
				this.global1.data[4] += this.global1.data[6] / 20;
				this.global1.data[10] -= 100;
			}
			else if (this.this_type == 55)
			{
				this.global1.data[1] += 300;
				this.global1.data[8] -= 80;
				this.global1.data[6] -= 10;
				this.global1.data[10] -= 10;
				this.global1.allcountries[this.selected_country].Stasi = true;
			}
			else if (this.this_type == 2)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[6] -= 20;
				this.global1.data[10] -= 20;
				if (this.global1.allcountries[21].Gosstroy != 2)
				{
					this.global1.data[7] += 5;
				}
			}
			else if (this.this_type == 3)
			{
				this.global1.allcountries[this.global1.data[0]].Vyshi = true;
				this.global1.data[10] -= 100;
				this.global1.data[7] -= 50;
				this.global1.data[6] -= 50;
				this.global1.data[4] -= this.global1.data[4] / 4;
				this.global1.data[23] -= 3;
			}
			else if (this.this_type == 4)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.allcountries[this.selected_country].Torg = false;
				this.global1.data[10] -= 10;
				this.global1.data[6] -= 20;
				this.global1.data[7] -= 10;
				this.global1.data[2] += 100;
				this.global1.data[24] += 2;
			}
			else if (this.this_type == 5)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[6] += 50;
				this.global1.data[10] += 20;
				this.global1.data[2] -= 100;
				this.global1.data[7] += 10;
			}
			else if (this.this_type == 6)
			{
				if (!this.global1.allcountries[this.selected_country].Donat)
				{
					this.global1.allcountries[this.selected_country].Donat = true;
					this.global1.data[10] += 10;
					this.global1.data[8] -= 10;
				}
				else
				{
					this.global1.allcountries[this.selected_country].Stasi = true;
					this.global1.data[10] += 20;
					this.global1.data[9] -= 10;
				}
				this.global1.data[7]++;
			}
			else if (this.this_type == 7)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.allcountries[this.selected_country].Gosstroy = 0;
				this.global1.allcountries[this.selected_country].subideology = 4;
			}
			else if (this.this_type == 8)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[4] -= 50;
				this.global1.data[1] += 150;
				this.global1.data[22] += 50;
				this.global1.data[24] -= 3;
				this.global1.data[2] -= 150;
			}
			else if (this.this_type == 9)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[8] -= 20;
				this.global1.data[10] += 10;
				this.global1.data[7] += 5;
				this.global1.data[37]++;
				this.global1.data[2] += 10;
			}
			else if (this.this_type == 10)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[10] += 10;
				this.global1.data[7] += 5;
				this.global1.data[6] += 10;
				this.global1.data[9] -= 10;
				this.global1.data[37]++;
			}
			else if (this.this_type == 11)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 10;
				this.global1.data[10] += 10;
				this.global1.data[7] += 5;
				this.global1.data[6] += 10;
				this.global1.data[8] -= 20;
				this.global1.allcountries[17].Westalgie += 30;
			}
			else if (this.this_type == 12)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[9] -= 10;
				this.global1.data[10] -= 20;
				this.global1.data[8] -= 25;
				this.global1.data[2] += 50;
				this.global1.allcountries[17].Westalgie += 50;
			}
			else if (this.this_type == 13)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[8] -= 20 * (this.global1.data[21] - 1988);
				this.global1.data[7] += 5;
				this.global1.data[54]++;
			}
			else if (this.this_type == 14)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 20;
				this.global1.data[7] += 5;
				this.global1.data[10] += 10;
				this.global1.data[6] += 10;
				this.global1.data[54]++;
			}
			else if (this.this_type == 51)
			{
				if (this.global1.allcountries[this.selected_country].isSEV)
				{
					this.global1.allcountries[this.selected_country].isOVD = true;
				}
				else
				{
					this.global1.allcountries[this.selected_country].isSEV = true;
					this.global1.allcountries[this.selected_country].Gosstroy = 9;
					this.global1.allcountries[this.selected_country].subideology = 2;
				}
				this.global1.data[9] -= 50;
				this.global1.data[8] -= 50;
				this.global1.data[10] += 50;
				if (!this.global1.is_gkchp || this.global1.allcountries[7].Gosstroy > 0)
				{
					this.global1.data[2] -= 250;
				}
			}
			else if (this.this_type == 15)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[9] -= 10;
				this.global1.data[7] -= 10;
				this.global1.data[10] -= 50;
				this.global1.data[6] -= 25;
				this.global1.data[54] -= 2;
			}
			else if (this.this_type == 44)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 100;
				this.global1.allcountries[this.selected_country].Gosstroy = 0;
				this.global1.allcountries[this.selected_country].subideology = 4;
				this.global1.allcountries[7].Westalgie++;
				this.global1.data[6] += 30;
				this.global1.data[10] -= 30;
				this.global1.data[7] += 30;
				this.global1.data[2] -= 150;
				this.global1.data[8] -= 100;
				this.global1.number_event = 1099;
				this.global1.speed = 0;
				this.map1.EventRead();
				SceneManager.LoadScene("Event");
			}
			else if (this.this_type == 16)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[10] -= 10;
				this.global1.data[8] -= 10;
				this.global1.data[2] += 20;
				this.global1.data[6] -= 10;
				this.global1.data[22] += 10;
			}
			else if (this.this_type == 17)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				if (this.selected_country != 38)
				{
					this.global1.data[6] -= 10;
					this.global1.allcountries[17].Westalgie += 30;
					this.global1.data[22] += 20;
				}
				else if (this.selected_country == 38)
				{
					this.global1.data[8] += 10;
					this.global1.data[6] -= this.global1.data[6] / 10;
					this.global1.data[10] -= 100;
					this.global1.data[2] -= 150;
					this.global1.data[7] -= 3;
				}
			}
			else if (this.this_type == 68)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				if (this.global1.data[0] == 5)
				{
					this.global1.data[8] += 10;
				}
				this.global1.data[6] -= this.global1.data[6] / 20;
				this.global1.data[10] -= 50;
				this.global1.data[7] -= 3;
			}
			else if (this.this_type == 18)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.allcountries[17].Westalgie += 50;
				this.global1.data[10] -= 30;
				this.global1.data[6] -= 30;
				this.global1.data[2] += 30;
				this.global1.data[3] += 30;
				this.global1.data[5] += 20;
			}
			else if (this.this_type == 19)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[10] += 10;
				this.global1.data[2] -= 25;
				this.global1.data[6] += 10;
			}
			else if (this.this_type == 20)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[22] += 50;
				this.global1.data[1] += 150;
				this.global1.data[2] -= 50;
			}
			else if (this.this_type == 45)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 100;
				this.global1.allcountries[31].subideology = 15;
				this.global1.allcountries[this.selected_country].Gosstroy = 1;
				this.global1.allcountries[this.selected_country].subideology = 11;
				this.global1.data[6] += 30;
				this.global1.data[10] += 30;
				this.global1.data[2] -= 150;
				this.global1.data[8] -= 50;
			}
			else if (this.this_type == 21)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[10] += 10;
				this.global1.data[22] += 10;
				this.global1.data[2] -= 50;
				this.global1.data[6] -= 20;
			}
			else if (this.this_type == 22)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[10] += 10;
				this.global1.data[22] += 20;
				this.global1.data[2] -= 50;
				this.global1.data[6] -= 10;
			}
			else if (this.this_type == 23)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.data[10] += 30;
				this.global1.data[22] += 30;
				this.global1.data[2] -= 50;
				this.global1.data[6] -= 20;
			}
			else if (this.this_type == 24)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[7] += 10;
				this.global1.data[9] -= 30;
				this.global1.data[6]++;
				this.global1.data[8] -= 10;
				this.global1.data[52]++;
				this.global1.allcountries[7].Westalgie++;
			}
			else if (this.this_type == 25)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[2] += 100;
				this.global1.data[8] -= 30;
				this.global1.data[51]++;
				this.global1.allcountries[7].Westalgie++;
			}
			else if (this.this_type == 26)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[2] -= 50;
				this.global1.data[8] += 30;
				this.global1.data[6] += 20;
			}
			else if (this.this_type == 43)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[2] -= 250;
				this.global1.data[10] -= 50;
				this.global1.data[8] += 50;
				this.global1.data[6] += 50;
				this.global1.data[7] -= 10;
				this.global1.data[1] -= 150;
				this.global1.data[9] -= 20;
			}
			else if (this.this_type == 27)
			{
				this.global1.allcountries[this.selected_country].Help = true;
				this.global1.data[10] += 10;
				this.global1.data[6] += 20;
				this.global1.data[2] -= 100;
				this.global1.data[4] -= 50;
				this.global1.data[9] += 10;
				this.global1.data[3] += 50;
			}
			else if (this.this_type == 28)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.data[6] -= 10;
				this.global1.data[9] -= 10;
			}
			else if (this.this_type == 56)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[6] += 30;
				this.global1.data[8] -= 10;
				this.global1.data[9] -= 10;
				this.global1.data[2] -= 150;
				this.global1.data[10] += 200;
			}
			else if (this.this_type == 29)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[22] += 10;
				this.global1.data[6] += 10;
			}
			else if (this.this_type == 30)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.data[22] += 10;
				this.global1.data[6] += 10;
				this.global1.data[10] += 20;
				this.global1.data[2] -= 50;
			}
			else if (this.this_type == 31)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[6] += 10;
				this.global1.data[7] += 10;
				this.global1.data[9] -= 10;
				this.global1.data[10] += 10;
			}
			else if (this.this_type == 32)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[6] += 10;
				this.global1.data[7] += 10;
				this.global1.data[9] -= 10;
			}
			else if (this.this_type == 33)
			{
				this.global1.allcountries[this.selected_country].Vyshi = true;
				this.global1.data[10] -= 10;
				this.global1.data[7] -= 20;
				this.global1.data[6] -= 10;
				this.global1.data[22] -= 10;
			}
			else if (this.this_type == 34)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[7]++;
				this.global1.data[8] -= 30;
			}
			else if (this.this_type == 35)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[7]++;
				this.global1.data[10] += 5;
				this.global1.data[9] -= 20;
			}
			else if (this.this_type == 36)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.data[1] += 50;
				this.global1.data[10] += 10;
				this.global1.data[4] -= 20;
				if (this.global1.data[6] > 59)
				{
					this.global1.data[7] += 10;
				}
				else if (this.global1.data[6] < 40)
				{
					this.global1.data[7] -= 10;
				}
			}
			else if (this.this_type == 37)
			{
				this.global1.allcountries[this.selected_country].isOVD = true;
				this.global1.data[10] -= 10;
				this.global1.data[1] += 50;
				this.global1.data[4] -= 50;
				this.global1.data[2] -= 50;
				if (this.global1.data[6] > 79)
				{
					this.global1.data[7] += 20;
				}
				else if (this.global1.data[6] > 59 && this.global1.data[6] < 80)
				{
					this.global1.data[7] += 10;
				}
				else
				{
					this.global1.data[7] -= 10;
				}
			}
			else if (this.this_type == 38)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[5] += 20;
				this.global1.data[3] += 25;
				this.global1.data[6] -= 5;
			}
			else if (this.this_type == 39)
			{
				this.global1.allcountries[this.selected_country].Vyshi = true;
				this.global1.data[10] -= 10;
				this.global1.data[7] -= 20;
				this.global1.data[6] -= 10;
				this.global1.data[22] -= 10;
			}
			else if (this.this_type == 40)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[5] += 10;
				this.global1.data[3] += 10;
				this.global1.data[6] -= 5;
				this.global1.data[22] += 10;
			}
			else if (this.this_type == 41)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.data[22] += 10;
				this.global1.data[6] += 10;
				this.global1.data[2] -= 25;
				this.global1.data[1] += 25;
			}
			else if (this.this_type == 42)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[6] += 25;
				this.global1.data[10] += 10;
				this.global1.data[2] -= 25;
			}
			else if (this.this_type == 57)
			{
				this.global1.data[59] = 1;
				this.global1.data[1] += 300;
				this.global1.data[2] -= 500;
				this.global1.data[3] += 200;
				this.global1.data[4] += 100;
				this.global1.data[5] -= 30;
				this.global1.data[6] += 300;
				this.global1.data[7] += 10;
				this.global1.data[8] -= 60;
				this.global1.data[9] -= 100;
				this.global1.data[10] += 500;
				this.global1.data[31] += 50;
			}
			else if (this.this_type == 58)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.allcountries[this.selected_country].Westalgie -= 15;
				this.global1.data[8] -= 8;
				this.global1.data[9] -= 10;
				if (this.global1.allcountries[this.selected_country].Westalgie > 1000)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 1000;
				}
				else if (this.global1.allcountries[this.selected_country].Westalgie < 0)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 0;
				}
			}
			else if (this.this_type == 59)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.allcountries[this.selected_country].Westalgie += 25;
				this.global1.data[8] -= 8;
				this.global1.data[9] -= 10;
				if (this.global1.allcountries[this.selected_country].Westalgie > 1000)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 1000;
				}
				else if (this.global1.allcountries[this.selected_country].Westalgie < 0)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 0;
				}
			}
			else if (this.this_type == 60)
			{
				if (this.global1.allcountries[this.selected_country].Donat)
				{
					this.global1.allcountries[this.selected_country].Westalgie -= 5;
					this.global1.data[8] -= 20;
				}
				else
				{
					this.global1.allcountries[this.selected_country].Westalgie += 10;
					this.global1.data[8] -= 20;
				}
				if (this.global1.allcountries[this.selected_country].Westalgie > 1000)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 1000;
				}
				else if (this.global1.allcountries[this.selected_country].Westalgie < 0)
				{
					this.global1.allcountries[this.selected_country].Westalgie = 0;
				}
			}
			else if (this.this_type == 61)
			{
				if (this.global1.data[28] > 0)
				{
					this.global1.data[28]--;
				}
				else if (this.global1.data[29] > 0)
				{
					this.global1.data[29]--;
				}
				this.global1.data[27]++;
				this.global1.data[1] -= (4 - this.global1.data[14]) * 50;
				this.global1.data[2] += (6 - this.global1.data[14]) * 15;
				this.global1.data[9] -= (6 - this.global1.data[14]) * 5;
				this.global1.data[3] += (6 - this.global1.data[14]) * 15;
				this.global1.data[4] += (6 - this.global1.data[14]) * 15;
				this.global1.data[22] -= 25;
				this.global1.data[6] -= (5 - this.global1.data[14]) * 10;
				this.global1.data[33] -= 25;
				this.global1.allcountries[this.global1.data[0]].Help = true;
			}
			else if (this.this_type == 62)
			{
				if (this.global1.data[27] > 0)
				{
					this.global1.data[27]--;
					this.global1.data[9] += 6 - this.global1.data[14];
					this.global1.data[3] += (2 - this.global1.data[14]) * 15;
					this.global1.data[4] += (2 - this.global1.data[14]) * 15;
					this.global1.data[22] += 10;
					this.global1.data[6] -= (2 - this.global1.data[14]) * 10;
				}
				else if (this.global1.data[29] > 0)
				{
					this.global1.data[29]--;
					this.global1.data[9] -= (6 - this.global1.data[14]) * 2;
					this.global1.data[3] += (6 - this.global1.data[14]) * 10;
					this.global1.data[4] += (5 - this.global1.data[14]) * 10;
					this.global1.data[6] -= (5 - this.global1.data[14]) * 10;
				}
				this.global1.data[28]++;
				this.global1.data[8] += 10;
				this.global1.allcountries[this.global1.data[0]].Help = true;
			}
			else if (this.this_type == 63)
			{
				if (this.global1.data[27] > 0)
				{
					this.global1.data[27]--;
				}
				else if (this.global1.data[28] > 0)
				{
					this.global1.data[28]--;
				}
				else if (this.global1.data[29] > 0)
				{
					this.global1.data[29]--;
				}
				this.global1.allcountries[this.global1.data[0]].Help = true;
				this.global1.data[1] += (3 - this.global1.data[14]) * 40;
				this.global1.data[3] -= (6 - this.global1.data[14]) * 15;
				this.global1.data[4] += (6 - this.global1.data[14]) * 15;
				this.global1.data[22] += 5;
				this.global1.data[6] += this.global1.data[14] * 10;
				this.global1.data[22] += 10;
			}
			else if (this.this_type == 64)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[6] += 30;
				this.global1.data[10] += 50;
				this.global1.data[22] += 50;
			}
			else if (this.this_type == 65)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[2] -= 100;
				this.global1.data[9] += 15;
				this.global1.data[1] -= 50;
				this.global1.data[10] += 50;
				this.global1.data[7]++;
				this.global1.data[22]++;
			}
			else if (this.this_type == 66)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[2] -= 100;
				this.global1.data[1] += 50;
				this.global1.data[10] += 50;
				this.global1.data[7]++;
				this.global1.data[22] += 50;
			}
			else if (this.this_type == 67)
			{
				this.global1.allcountries[this.selected_country].isSEV = true;
				this.global1.allcountries[this.selected_country].Vyshi = false;
				this.global1.data[4] -= 50;
				this.global1.data[1] += 100;
				this.global1.data[10] += 100;
				this.global1.data[7] += 5;
				this.global1.data[22] += 25;
				this.global1.data[9] += 25;
				this.global1.data[8] -= 30;
			}
			else if (this.this_type == 69)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[8] -= 30;
				this.global1.data[10]++;
			}
			else if (this.this_type == 70)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 30;
				this.global1.data[10] += 10;
				this.global1.data[2] -= 100;
			}
			else if (this.this_type == 71)
			{
				this.global1.allcountries[this.selected_country].Gosstroy = 0;
				this.global1.allcountries[this.selected_country].subideology = 4;
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[9] -= 50;
				this.global1.data[8] -= 50;
				this.global1.data[10] += 100;
				this.global1.data[2] -= 100;
			}
			else if (this.this_type == 72)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.data[8] -= 80;
				this.global1.data[10] += 10;
			}
			else if (this.this_type == 73)
			{
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 150;
				this.global1.data[2] -= 500;
				this.global1.data[10] += 300;
			}
			else if (this.this_type == 74)
			{
				this.global1.allcountries[this.selected_country].Gosstroy = 1;
				this.global1.allcountries[this.selected_country].subideology = 8;
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[7] += 50;
				this.global1.data[10] += 100;
			}
			else if (this.this_type == 75)
			{
				this.global1.allcountries[this.selected_country].Torg = false;
				this.global1.allcountries[this.selected_country].Stasi = true;
				this.global1.data[9] -= 100;
				this.global1.data[2] -= 200;
				this.global1.data[1] -= 100;
			}
			else if (this.this_type == 76)
			{
				this.global1.allcountries[this.selected_country].Donat = true;
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[9] -= 50;
				this.global1.data[8] -= 50;
				this.global1.data[2] -= 200;
			}
			else if (this.this_type == 77)
			{
				this.global1.data[108] = 25;
				this.global1.number_event = 238;
				this.global1.speed = 0;
				this.map1.EventRead();
				SceneManager.LoadScene("Event");
			}
			else if (this.this_type == 78)
			{
				this.global1.data[108] += 25;
				this.global1.data[8] -= 30;
				this.global1.data[9] -= 50;
				this.global1.data[3] += 10;
			}
			else if (this.this_type == 79)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
			}
			else if (this.this_type == 80)
			{
				this.global1.allcountries[this.selected_country].Money = true;
				this.global1.data[8] += 30;
				this.global1.data[4] += 50;
				this.global1.data[22] -= 50;
				this.global1.data[24] -= 3;
			}
			else if (this.this_type == 81)
			{
				this.global1.allcountries[this.selected_country].Gosstroy = 0;
				this.global1.allcountries[this.selected_country].subideology = 7;
				this.global1.data[6] += 15;
			}
			else if (this.this_type == 82)
			{
				this.global1.data[4] -= 50;
				this.global1.data[1] += 50;
				this.global1.data[165]++;
				this.global1.data[9] -= 50;
				this.global1.allcountries[17].Westalgie += 50;
				this.global1.allcountries[this.selected_country].Stasi = true;
			}
			else if (this.this_type == 83)
			{
				this.global1.data[4] -= 50;
				this.global1.data[165]++;
				this.global1.data[8] -= 50;
				this.global1.allcountries[17].Westalgie += 5;
				this.global1.data[7]++;
				this.global1.allcountries[this.selected_country].Money = true;
			}
			else if (this.this_type == 84)
			{
				this.global1.allcountries[this.selected_country].Torg = true;
				this.global1.data[4] += 5;
			}
			if (this.selected_country < 40 || this.selected_country > 43)
			{
				this.global1.data[63]++;
			}
			this.map1.UpdateMap();
			this.map1.ShowHideOcno(false);
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0001DC28 File Offset: 0x0001BE28
	private void OnMouseEnter()
	{
		if (this.is_active)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			this.opis.GetComponent<TextMesh>().text = this.Text(this.this_opis, 20);
			for (int i = 0; i < this.number_uslovie; i++)
			{
				this.uslovie[i].GetComponent<TextMesh>().text = this.Text(this.uslovie_text[i], 30);
				if (this.uslovie_bool[i])
				{
					this.uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = this.usl_on;
				}
				else
				{
					this.uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = this.usl_off;
				}
			}
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0001DD04 File Offset: 0x0001BF04
	private void OnMouseExit()
	{
		if (this.is_active)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			this.opis.GetComponent<TextMesh>().text = null;
			for (int i = 0; i < 4; i++)
			{
				this.uslovie[i].GetComponent<TextMesh>().text = null;
				this.uslovie[i].transform.Find("If").GetComponent<SpriteRenderer>().sprite = null;
			}
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0001DD7C File Offset: 0x0001BF7C
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

	// Token: 0x04000079 RID: 121
	public Sprite usl_off;

	// Token: 0x0400007A RID: 122
	public Sprite usl_on;

	// Token: 0x0400007B RID: 123
	private bool is_active;

	// Token: 0x0400007C RID: 124
	public GameObject opis;

	// Token: 0x0400007D RID: 125
	public GameObject[] uslovie = new GameObject[4];

	// Token: 0x0400007E RID: 126
	private bool[] uslovie_bool = new bool[4];

	// Token: 0x0400007F RID: 127
	private int number_uslovie;

	// Token: 0x04000080 RID: 128
	private string[] uslovie_text = new string[4];

	// Token: 0x04000081 RID: 129
	private string this_opis;

	// Token: 0x04000082 RID: 130
	public GlobalScript global1;

	// Token: 0x04000083 RID: 131
	private MapChangesScript map1;

	// Token: 0x04000084 RID: 132
	public Sprite on;

	// Token: 0x04000085 RID: 133
	public Sprite off;

	// Token: 0x04000086 RID: 134
	private int this_type = -1;

	// Token: 0x04000087 RID: 135
	public int selected_country = -1;
}
