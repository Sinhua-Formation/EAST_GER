using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000029 RID: 41
public class LoadInScript : MonoBehaviour
{
	// Token: 0x060000C3 RID: 195 RVA: 0x000606EF File Offset: 0x0005E8EF
	public bool from_string(string str)
	{
		return str == "True";
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00060701 File Offset: 0x0005E901
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00060718 File Offset: 0x0005E918
	private void OnMouseDown()
	{
		this.global1.is_save_bylo = true;
		string text = (PlayerPrefs.GetInt("language") == 0) ? "en" : "ru";
		if (PlayerPrefs.HasKey("g6" + this.number.ToString()))
		{
			string text2 = "";
			string[] array = text2.Split(new char[]
			{
				':'
			});
			for (int i = 0; i < this.global1.data_old.Length; i++)
			{
				this.global1.data_old[i] = PlayerPrefs.GetInt("D_old" + i + this.number);
			}
			for (int j = 0; j < this.global1.data.Length; j++)
			{
				this.global1.data[j] = PlayerPrefs.GetInt("data" + j + this.number);
			}
			this.global1.turn_on = false;
			string[] array2 = new string[]
			{
				PlayerPrefs.GetString("V1" + this.number.ToString()),
				PlayerPrefs.GetString("I2" + this.number.ToString()),
				PlayerPrefs.GetString("S3" + this.number.ToString()),
				PlayerPrefs.GetString("R3" + this.number.ToString())
			};
			PlayerPrefs.SetString("V1", array2[0]);
			PlayerPrefs.SetString("I2", array2[1]);
			PlayerPrefs.SetString("S3", array2[2]);
			PlayerPrefs.SetString("R3", array2[3]);
			this.global1.bylo = this.from_string(PlayerPrefs.GetString("b4" + this.number.ToString()));
			this.global1.neizucheno = this.from_string(PlayerPrefs.GetString("n5" + this.number.ToString()));
			this.global1.diff[0] = this.from_string(PlayerPrefs.GetString("01d" + this.number.ToString()));
			this.global1.diff[1] = this.from_string(PlayerPrefs.GetString("02d" + this.number.ToString()));
			this.global1.diff[2] = this.from_string(PlayerPrefs.GetString("03d" + this.number.ToString()));
			this.global1.diff[4] = this.from_string(PlayerPrefs.GetString("04d" + this.number.ToString()));
			this.global1.diff[3] = this.from_string(PlayerPrefs.GetString("sand" + this.number.ToString()));
			if (this.number == 5)
			{
				this.global1.iron_and_blood = this.from_string(PlayerPrefs.GetString("i7" + this.number.ToString()));
			}
			else
			{
				this.global1.iron_and_blood = false;
			}
			for (int k = 0; k < 5; k++)
			{
				if (this.global1.regions[k] == null)
				{
					this.global1.regions[k] = new Region();
				}
				for (int l = 0; l < 15; l++)
				{
					if (this.global1.regions[k].buildings[l] == null)
					{
						this.global1.regions[k].buildings[l] = new Building();
					}
					this.global1.regions[k].buildings[l].is_builded = this.from_string(PlayerPrefs.GetString("b8" + k.ToString() + l.ToString() + this.number.ToString()));
					this.global1.regions[k].buildings[l].is_working = this.from_string(PlayerPrefs.GetString("w9" + k.ToString() + l.ToString() + this.number.ToString()));
					this.global1.regions[k].buildings[l].is_private = this.from_string(PlayerPrefs.GetString("p10" + k.ToString() + l.ToString() + this.number.ToString()));
					this.global1.regions[k].buildings[l].type = PlayerPrefs.GetInt(string.Concat(new object[]
					{
						"t11",
						k,
						l,
						this.number
					}));
					this.global1.regions[k].city_level = PlayerPrefs.GetInt("l12" + k + this.number);
				}
			}
			for (int m = 0; m < this.global1.allcountries.Length; m++)
			{
				if (this.global1.allcountries[m] == null)
				{
					this.global1.allcountries[m] = new Country();
				}
				this.global1.allcountries[m].isSEV = this.from_string(PlayerPrefs.GetString("SEV" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].isOVD = this.from_string(PlayerPrefs.GetString("OVD" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Vyshi = this.from_string(PlayerPrefs.GetString("Vys" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Donat = this.from_string(PlayerPrefs.GetString("Don" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Help = this.from_string(PlayerPrefs.GetString("Hel" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Stasi = this.from_string(PlayerPrefs.GetString("Sta" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Torg = this.from_string(PlayerPrefs.GetString("Tor" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Money = this.from_string(PlayerPrefs.GetString("Mon" + m.ToString() + this.number.ToString()));
				this.global1.allcountries[m].Gosstroy = PlayerPrefs.GetInt("Gos" + m + this.number);
				this.global1.allcountries[m].subideology = PlayerPrefs.GetInt("Sub" + m + this.number);
			}
			this.global1.allcountries[17].Westalgie = PlayerPrefs.GetInt("Wes" + 17 + this.number);
			this.global1.allcountries[40].Westalgie = PlayerPrefs.GetInt("Wes" + 40 + this.number);
			this.global1.allcountries[41].Westalgie = PlayerPrefs.GetInt("Wes" + 41 + this.number);
			this.global1.allcountries[42].Westalgie = PlayerPrefs.GetInt("Wes" + 42 + this.number);
			this.global1.allcountries[43].Westalgie = PlayerPrefs.GetInt("Wes" + 43 + this.number);
			this.global1.allcountries[44].Westalgie = PlayerPrefs.GetInt("Wes" + 44 + this.number);
			this.global1.allcountries[45].Westalgie = PlayerPrefs.GetInt("Wes" + 45 + this.number);
			this.global1.allcountries[46].Westalgie = PlayerPrefs.GetInt("Wes" + 46 + this.number);
			this.global1.allcountries[47].Westalgie = PlayerPrefs.GetInt("Wes" + 47 + this.number);
			for (int n = 1; n < 8; n++)
			{
				this.global1.allcountries[n].paths = PlayerPrefs.GetInt("Cou" + n + this.number);
			}
			TextAsset textAsset = Resources.Load(string.Format("Country_{0}", text)) as TextAsset;
			if (text == "en")
			{
				if (this.global1.allcountries[7].paths == 2)
				{
					this.global1.sovietPremiereName = "Yakovlev";
				}
				else if (this.global1.allcountries[7].paths == 3)
				{
					this.global1.sovietPremiereName = "Vorotnikov";
				}
				else
				{
					this.global1.sovietPremiereName = "Gorbachev";
				}
			}
			else if (this.global1.allcountries[7].paths == 2)
			{
				this.global1.sovietPremiereName = "Яковлев";
			}
			else if (this.global1.allcountries[7].paths == 3)
			{
				this.global1.sovietPremiereName = "Воротников";
			}
			else
			{
				this.global1.sovietPremiereName = "Горбачёв";
			}
			text2 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text2.Split(new char[]
			{
				';'
			});
			for (int num = 0; num < array.Length; num++)
			{
				this.global1.allcountries[num].name = array[num];
			}
			for (int num2 = 0; num2 < this.global1.Events_number.Length; num2++)
			{
				this.global1.Events_number[num2] = PlayerPrefs.GetInt("E_num" + num2 + this.number);
				this.global1.Events_time[num2] = PlayerPrefs.GetFloat("E_tim" + num2 + this.number);
				this.global1.Events_active[num2] = this.from_string(PlayerPrefs.GetString("E_act" + num2.ToString() + this.number.ToString()));
				this.global1.event_done[num2] = this.from_string(PlayerPrefs.GetString("E_don" + num2.ToString() + this.number.ToString()));
				this.global1.eventVariantChosen[num2] = PlayerPrefs.GetInt("E_variant" + num2 + this.number);
			}
			this.global1.is_elect = this.from_string(PlayerPrefs.GetString("elec" + this.number.ToString()));
			this.global1.is_speech = this.from_string(PlayerPrefs.GetString("spee" + this.number.ToString()));
			this.global1.is_liber = this.from_string(PlayerPrefs.GetString("libe" + this.number.ToString()));
			this.global1.povod = this.from_string(PlayerPrefs.GetString("povod" + this.number.ToString()));
			this.global1.is_konst_max = this.from_string(PlayerPrefs.GetString("konst" + this.number.ToString()));
			this.global1.is_gkchp = this.from_string(PlayerPrefs.GetString("gkchp" + this.number.ToString()));
			this.global1.issleduetsya = PlayerPrefs.GetInt("issled" + this.number);
			TextAsset textAsset2 = Resources.Load(string.Format("Part_{0}", text)) as TextAsset;
			text2 = textAsset2.text;
			Resources.UnloadAsset(textAsset2);
			array = text2.Split(new char[]
			{
				':'
			});
			for (int num3 = 0; num3 < this.global1.party_number.Length; num3++)
			{
				this.global1.is_party_ally[num3] = this.from_string(PlayerPrefs.GetString("P_ally" + num3.ToString() + this.number.ToString()));
				this.global1.is_party_enabled[num3] = this.from_string(PlayerPrefs.GetString("P_enab" + num3.ToString() + this.number.ToString()));
				this.global1.party_number[num3] = PlayerPrefs.GetInt("P_num" + num3 + this.number);
				this.global1.party_ideology[num3] = PlayerPrefs.GetInt("P_ideo" + num3 + this.number);
				this.global1.party_name[num3] = PlayerPrefs.GetString("P_name" + num3.ToString() + this.number.ToString());
			}
			if (this.global1.data[0] < 49 || this.global1.data[0] > 51 || this.global1.data[114] != 100)
			{
				TextAsset textAsset3 = Resources.Load(string.Format("Polit_{0}", text)) as TextAsset;
				text2 = textAsset3.text;
				Resources.UnloadAsset(textAsset3);
				array = text2.Split(new char[]
				{
					':'
				});
				for (int num4 = 0; num4 < array.Length; num4++)
				{
					string[] array3 = array[num4].Split(new char[]
					{
						';'
					});
					if (array3[0] == this.global1.data[0].ToString())
					{
						this.global1.politics_name[0] = array3[1];
						this.global1.politics_name[1] = array3[2];
						this.global1.politics_name[2] = array3[3];
						this.global1.politics_name[3] = array3[4];
						this.global1.politics_name[4] = array3[5];
						this.global1.politics_name[5] = array3[6];
						this.global1.politics_name[6] = array3[7];
						this.global1.politics_name[7] = array3[8];
						this.global1.politics_name[8] = array3[9];
						this.global1.politics_name[9] = array3[10];
						break;
					}
				}
				TextAsset textAsset4 = Resources.Load(string.Format("Opis_{0}", text)) as TextAsset;
				text2 = textAsset4.text;
				Resources.UnloadAsset(textAsset4);
				array = text2.Split(new char[]
				{
					':'
				});
				for (int num5 = 0; num5 < array.Length; num5++)
				{
					string[] array4 = array[num5].Split(new char[]
					{
						';'
					});
					if (array4[0] == this.global1.data[0].ToString())
					{
						this.global1.politics_opis[0] = array4[1].Replace("|", "\n");
						this.global1.politics_opis[1] = array4[2].Replace("|", "\n");
						this.global1.politics_opis[2] = array4[3].Replace("|", "\n");
						this.global1.politics_opis[3] = array4[4].Replace("|", "\n");
						this.global1.politics_opis[4] = array4[5].Replace("|", "\n");
						this.global1.politics_opis[5] = array4[6].Replace("|", "\n");
						this.global1.politics_opis[6] = array4[7].Replace("|", "\n");
						this.global1.politics_opis[7] = array4[8].Replace("|", "\n");
						this.global1.politics_opis[8] = array4[9].Replace("|", "\n");
						this.global1.politics_opis[9] = array4[10].Replace("|", "\n");
						break;
					}
				}
				TextAsset textAsset5 = Resources.Load(string.Format("Charact_{0}", text)) as TextAsset;
				text2 = textAsset5.text;
				Resources.UnloadAsset(textAsset5);
				array = text2.Split(new char[]
				{
					':'
				});
				for (int num6 = 0; num6 < array.Length; num6++)
				{
					string[] array5 = array[num6].Split(new char[]
					{
						';'
					});
					if (array5[0] == this.global1.data[0].ToString())
					{
						this.global1.politics_charact[0] = array5[1];
						this.global1.politics_charact[1] = array5[2];
						this.global1.politics_charact[2] = array5[3];
						this.global1.politics_charact[3] = array5[4];
						this.global1.politics_charact[4] = array5[5];
						this.global1.politics_charact[5] = array5[6];
						this.global1.politics_charact[6] = array5[7];
						this.global1.politics_charact[7] = array5[8];
						this.global1.politics_charact[8] = array5[9];
						this.global1.politics_charact[9] = array5[10];
						break;
					}
				}
			}
			TextAsset textAsset6 = Resources.Load(string.Format("Doctr_{0}", text)) as TextAsset;
			text2 = textAsset6.text;
			Resources.UnloadAsset(textAsset6);
			array = text2.Split(new char[]
			{
				';'
			});
			for (int num7 = 0; num7 < array.Length; num7++)
			{
				this.global1.doctr[num7] = array[num7];
			}
			for (int num8 = 0; num8 < this.global1.science.Length; num8++)
			{
				this.global1.science[num8] = this.from_string(PlayerPrefs.GetString("science" + num8.ToString() + this.number.ToString()));
				this.global1.science_time[num8] = PlayerPrefs.GetInt("S_time" + num8 + this.number);
			}
			this.global1.speed = 0;
			if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.LoadYugoSave(this.number);
			}
			SceneManager.LoadScene("Diplomacy");
		}
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00061B10 File Offset: 0x0005FD10
	private void LoadYugoSave(int num)
	{
		if (File.Exists(string.Format("YugData{0}{1}.save", Path.DirectorySeparatorChar, num)))
		{
			if (GameObject.Find("Yugoglobal(Clone)") == null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.yug);
				UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Yugoglobal(Clone)"));
			}
			GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>().CreateWorld(this.number);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			Yugoglobal component = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
			using (FileStream fileStream = File.OpenRead(string.Format("YugData{0}{1}.save", Path.DirectorySeparatorChar, num)))
			{
				component.gameState = (binaryFormatter.Deserialize(fileStream) as GameState);
			}
			if (this.global1.data[114] == 100)
			{
				GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>().ChangeLeaders();
			}
			if (component.gameState.battle_royal && component.gameState.yugcountries[11].is_exist && this.global1.event_done[102])
			{
				component.gameState.yugcountries[10].name = component.science_text[109];
			}
			else if (this.global1.allcountries[6].Gosstroy == 9 && this.global1.event_done[313])
			{
				component.gameState.yugcountries[10].name = component.science_text[109];
			}
			else if (this.global1.allcountries[20].Gosstroy == 9 && this.global1.event_done[315])
			{
				component.gameState.yugcountries[10].name = component.science_text[112];
			}
			if (this.global1.allcountries[5].Gosstroy == 9 && this.global1.event_done[39] && this.global1.event_done[313])
			{
				component.gameState.yugcountries[9].name = component.science_text[111];
			}
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00061D48 File Offset: 0x0005FF48
	private void OnMouseEnter()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.number == 5)
			{
				this.Opis.text = "With achievements";
			}
			else
			{
				this.Opis.text = "Without achievements";
			}
			if (PlayerPrefs.HasKey("g6" + this.number.ToString()))
			{
				TextMesh opis = this.Opis;
				opis.text = opis.text + "\nDate: " + PlayerPrefs.GetString("g6" + this.number.ToString());
				TextMesh opis2 = this.Opis;
				opis2.text = opis2.text + "\nCountry: " + PlayerPrefs.GetString("n6" + this.number.ToString());
				TextMesh opis3 = this.Opis;
				opis3.text = opis3.text + "\nSystem: " + this.global1.doctr[PlayerPrefs.GetInt("data14" + this.number)];
				TextMesh opis4 = this.Opis;
				opis4.text = opis4.text + "\nSocialist Camp: " + (PlayerPrefs.GetInt("data7" + this.number) / 10).ToString();
				TextMesh opis5 = this.Opis;
				opis5.text += "\nDifficulty: ";
				bool flag = this.from_string(PlayerPrefs.GetString("01d" + this.number.ToString()));
				bool flag2 = this.from_string(PlayerPrefs.GetString("02d" + this.number.ToString()));
				bool flag3 = this.from_string(PlayerPrefs.GetString("03d" + this.number.ToString()));
				if (flag && flag2 && flag3)
				{
					TextMesh opis6 = this.Opis;
					opis6.text += "<color=red>Turned on</color>";
				}
				else
				{
					TextMesh opis7 = this.Opis;
					opis7.text += "<color=red>Turned off</color>";
				}
				TextMesh opis8 = this.Opis;
				opis8.text += "\nAchievements: ";
				bool flag4 = this.from_string(PlayerPrefs.GetString("i7" + this.number.ToString()));
				bool flag5 = this.from_string(PlayerPrefs.GetString("sand" + this.number.ToString()));
				if (flag4)
				{
					TextMesh opis9 = this.Opis;
					opis9.text += "<color=red>Available</color>";
				}
				else if (flag && flag2 && flag3 && !flag5)
				{
					TextMesh opis10 = this.Opis;
					opis10.text += "<color=red>Only paths</color>";
				}
				else
				{
					TextMesh opis11 = this.Opis;
					opis11.text += "<color=red>Unavailable</color>";
				}
				TextMesh opis12 = this.Opis;
				opis12.text += "\nGorbachev's call: ";
				if (this.from_string(PlayerPrefs.GetString("04d" + this.number.ToString())))
				{
					TextMesh opis13 = this.Opis;
					opis13.text += "<color=blue>Turned on</color>";
				}
				else
				{
					TextMesh opis14 = this.Opis;
					opis14.text += "<color=blue>Turned off</color>";
				}
			}
			else
			{
				TextMesh opis15 = this.Opis;
				opis15.text += "\nEmpty Slot";
			}
		}
		else
		{
			if (this.number == 5)
			{
				this.Opis.text = "С Достижениями";
			}
			else
			{
				this.Opis.text = "Без Достижений";
			}
			if (PlayerPrefs.HasKey("g6" + this.number.ToString()))
			{
				TextMesh opis16 = this.Opis;
				opis16.text = opis16.text + "\nДата: " + PlayerPrefs.GetString("g6" + this.number.ToString());
				TextMesh opis17 = this.Opis;
				opis17.text = opis17.text + "\nСтрана: " + PlayerPrefs.GetString("n6" + this.number.ToString());
				TextMesh opis18 = this.Opis;
				opis18.text = opis18.text + "\nГосстрой: " + this.global1.doctr[PlayerPrefs.GetInt("data14" + this.number)];
				TextMesh opis19 = this.Opis;
				opis19.text = opis19.text + "\nСоцлагерь: " + (PlayerPrefs.GetInt("data7" + this.number) / 10).ToString();
				TextMesh opis20 = this.Opis;
				opis20.text += "\nСложность: ";
				bool flag6 = this.from_string(PlayerPrefs.GetString("01d" + this.number.ToString()));
				bool flag7 = this.from_string(PlayerPrefs.GetString("02d" + this.number.ToString()));
				bool flag8 = this.from_string(PlayerPrefs.GetString("03d" + this.number.ToString()));
				if (flag6 && flag7 && flag8)
				{
					TextMesh opis21 = this.Opis;
					opis21.text += "<color=red>Включена</color>";
				}
				else
				{
					TextMesh opis22 = this.Opis;
					opis22.text += "<color=red>Выключена</color>";
				}
				TextMesh opis23 = this.Opis;
				opis23.text += "\nДостижения: ";
				bool flag9 = this.from_string(PlayerPrefs.GetString("i7" + this.number.ToString()));
				bool flag10 = this.from_string(PlayerPrefs.GetString("sand" + this.number.ToString()));
				if (flag9)
				{
					TextMesh opis24 = this.Opis;
					opis24.text += "<color=red>Доступны</color>";
				}
				else if (flag6 && flag7 && flag8 && !flag10)
				{
					TextMesh opis25 = this.Opis;
					opis25.text += "<color=red>Только пути</color>";
				}
				else
				{
					TextMesh opis26 = this.Opis;
					opis26.text += "<color=red>Недоступны</color>";
				}
				TextMesh opis27 = this.Opis;
				opis27.text += "\nЗвонок Горбачёва: ";
				if (this.from_string(PlayerPrefs.GetString("04d" + this.number.ToString())))
				{
					TextMesh opis28 = this.Opis;
					opis28.text += "<color=blue>Включён</color>";
				}
				else
				{
					TextMesh opis29 = this.Opis;
					opis29.text += "<color=blue>Выключен</color>";
				}
			}
			else
			{
				TextMesh opis30 = this.Opis;
				opis30.text += "\nПустой слот";
			}
		}
		base.GetComponent<SpriteRenderer>().sprite = this.navel;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x0006240F File Offset: 0x0006060F
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		this.Opis.text = "";
	}

	// Token: 0x04000158 RID: 344
	public int number;

	// Token: 0x04000159 RID: 345
	public GlobalScript global1;

	// Token: 0x0400015A RID: 346
	private Yugoglobal yug1;

	// Token: 0x0400015B RID: 347
	public TextMesh Opis;

	// Token: 0x0400015C RID: 348
	public Sprite navel;

	// Token: 0x0400015D RID: 349
	public Sprite nenavel;

	// Token: 0x0400015E RID: 350
	public GameObject yug;
}
