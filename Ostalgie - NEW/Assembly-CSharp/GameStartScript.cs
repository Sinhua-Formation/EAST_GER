using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001F RID: 31
public class GameStartScript : MonoBehaviour
{
	// Token: 0x06000098 RID: 152 RVA: 0x0005AF8C File Offset: 0x0005918C
	private void InDLCCheck()
	{
		if ((this.number == 49 || this.number == 50 || this.number == 51) && this.is_active[2])
		{
			if (GameObject.Find("Yugoglobal(Clone)") == null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.yug);
				UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Yugoglobal(Clone)"));
			}
			if (this.is_active[2])
			{
				Yugoglobal component = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
				component.CreateWorld(this.number);
				this.global1.data[135] = 11;
				this.global1.data[124] = 3;
				this.global1.data[130] = 9;
				this.global1.data[26] = 400;
				component.gameState.battle_royal = this.diff[5];
				if (component.gameState.battle_royal)
				{
					this.global1.data[10] = 1000;
					this.global1.regions[4].buildings[6].type = 4;
					this.global1.regions[4].buildings[6].is_builded = true;
					this.global1.regions[4].buildings[6].is_working = true;
					this.global1.regions[0].buildings[11].type = 4;
					this.global1.regions[0].buildings[11].is_builded = true;
					this.global1.regions[0].buildings[11].is_working = true;
				}
				else
				{
					component.gameState.modifies[6] = 2;
					component.gameState.modifies[19] = 1;
					component.gameState.modifies[20] = 1;
					if (this.global1.data[0] == 50)
					{
						component.gameState.modifies[21] = 1;
					}
				}
			}
		}
		if (this.is_active[3])
		{
			if (this.global1.allcountries[7].paths == 1)
			{
				while (this.global1.allcountries[7].paths == 1)
				{
					this.global1.allcountries[7].paths = UnityEngine.Random.Range(0, 5);
				}
				Debug.Log("Путь 7: " + this.global1.allcountries[7].paths);
			}
			if ((this.global1.allcountries[7].paths == 2 || this.global1.allcountries[7].paths == 3) && this.number == 18)
			{
				this.global1.allcountries[7].paths = 0;
			}
			if (this.global1.allcountries[1].paths == 1)
			{
				while (this.global1.allcountries[1].paths == 1 || (this.global1.allcountries[1].paths == 6 && this.global1.allcountries[7].paths != 3))
				{
					this.global1.allcountries[1].paths = UnityEngine.Random.Range(0, 6);
				}
				Debug.Log("Путь 1: " + this.global1.allcountries[1].paths);
			}
			if ((this.global1.allcountries[1].paths == 6 && this.global1.allcountries[7].paths != 3) || this.number == 1)
			{
				this.global1.allcountries[1].paths = 0;
			}
			if (this.global1.allcountries[2].paths == 1)
			{
				while (this.global1.allcountries[2].paths == 1 || (this.global1.allcountries[2].paths == 2 && this.global1.allcountries[7].paths != 3))
				{
					this.global1.allcountries[2].paths = UnityEngine.Random.Range(0, 5);
				}
				Debug.Log("Путь 2: " + this.global1.allcountries[2].paths);
			}
			if ((this.global1.allcountries[2].paths == 2 && this.global1.allcountries[7].paths != 3) || this.number == 2)
			{
				this.global1.allcountries[2].paths = 0;
			}
			if (this.global1.allcountries[3].paths == 1)
			{
				while (this.global1.allcountries[3].paths == 1 || (this.global1.allcountries[3].paths == 5 && this.global1.allcountries[7].paths != 3))
				{
					this.global1.allcountries[3].paths = UnityEngine.Random.Range(0, 6);
				}
				Debug.Log("Путь 3: " + this.global1.allcountries[3].paths);
			}
			if ((this.global1.allcountries[3].paths == 5 && this.global1.allcountries[7].paths != 3) || this.number == 3)
			{
				this.global1.allcountries[3].paths = 0;
			}
			if (this.global1.allcountries[4].paths == 1)
			{
				while (this.global1.allcountries[4].paths == 1 || (this.global1.allcountries[4].paths == 2 && this.global1.allcountries[7].paths != 3))
				{
					this.global1.allcountries[4].paths = UnityEngine.Random.Range(0, 6);
				}
				Debug.Log("Путь 4: " + this.global1.allcountries[4].paths);
			}
			if ((this.global1.allcountries[4].paths == 2 && this.global1.allcountries[7].paths != 3) || this.number == 4)
			{
				this.global1.allcountries[4].paths = 0;
			}
			if (this.global1.allcountries[5].paths == 1)
			{
				while (this.global1.allcountries[5].paths == 1 || (this.global1.allcountries[5].paths == 4 && this.global1.allcountries[7].paths != 3))
				{
					this.global1.allcountries[5].paths = UnityEngine.Random.Range(0, 6);
				}
				Debug.Log("Путь 5: " + this.global1.allcountries[5].paths);
			}
			if ((this.global1.allcountries[5].paths == 4 && this.global1.allcountries[7].paths != 3) || this.number == 5)
			{
				this.global1.allcountries[5].paths = 0;
			}
			if (this.global1.allcountries[6].paths == 1)
			{
				while (this.global1.allcountries[6].paths == 1)
				{
					this.global1.allcountries[6].paths = UnityEngine.Random.Range(0, 6);
				}
				Debug.Log("Путь 6: " + this.global1.allcountries[6].paths);
			}
			if ((this.global1.allcountries[6].paths == 2 && (this.number == 49 || this.number == 50 || this.number == 51)) || this.number == 6)
			{
				this.global1.allcountries[6].paths = 0;
			}
			for (int i = 1; i < 7; i++)
			{
				if (this.number == i)
				{
					this.global1.allcountries[i].paths = 0;
					break;
				}
			}
			for (int j = 1; j < 7; j++)
			{
				if (this.global1.allcountries[j].paths > 1)
				{
					this.global1.iron_and_blood = false;
					break;
				}
			}
			if (PlayerPrefs.GetInt("language") == 0)
			{
				if (this.global1.allcountries[7].paths == 2)
				{
					this.global1.sovietPremiereName = "Yakovlev";
					return;
				}
				if (this.global1.allcountries[7].paths == 3)
				{
					this.global1.sovietPremiereName = "Vorotnikov";
					return;
				}
				this.global1.sovietPremiereName = "Gorbachev";
				return;
			}
			else
			{
				if (this.global1.allcountries[7].paths == 2)
				{
					this.global1.sovietPremiereName = "Яковлев";
					return;
				}
				if (this.global1.allcountries[7].paths == 3)
				{
					this.global1.sovietPremiereName = "Воротников";
					return;
				}
				this.global1.sovietPremiereName = "Горбачёв";
			}
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0005B878 File Offset: 0x00059A78
	private void subIdeologyCheck()
	{
		this.global1.allcountries[0].subideology = 15;
		this.global1.allcountries[1].subideology = 4;
		this.global1.allcountries[2].subideology = 4;
		this.global1.allcountries[3].subideology = 4;
		this.global1.allcountries[4].subideology = 8;
		this.global1.allcountries[5].subideology = 4;
		this.global1.allcountries[6].subideology = 4;
		this.global1.allcountries[7].subideology = 4;
		this.global1.allcountries[8].subideology = 3;
		this.global1.allcountries[9].subideology = 4;
		this.global1.allcountries[10].subideology = 0;
		this.global1.allcountries[11].subideology = 11;
		this.global1.allcountries[12].subideology = 0;
		this.global1.allcountries[13].subideology = 11;
		this.global1.allcountries[14].subideology = 0;
		this.global1.allcountries[15].subideology = 11;
		this.global1.allcountries[16].subideology = 11;
		this.global1.allcountries[17].subideology = 14;
		this.global1.allcountries[18].subideology = 4;
		this.global1.allcountries[19].subideology = 9;
		this.global1.allcountries[20].subideology = 7;
		this.global1.allcountries[21].subideology = 13;
		this.global1.allcountries[22].subideology = 11;
		this.global1.allcountries[23].subideology = 4;
		this.global1.allcountries[24].subideology = 11;
		this.global1.allcountries[25].subideology = 2;
		this.global1.allcountries[26].subideology = 13;
		this.global1.allcountries[27].subideology = 13;
		this.global1.allcountries[28].subideology = 13;
		this.global1.allcountries[29].subideology = 14;
		this.global1.allcountries[30].subideology = 2;
		this.global1.allcountries[31].subideology = 13;
		this.global1.allcountries[32].subideology = 2;
		this.global1.allcountries[33].subideology = 11;
		this.global1.allcountries[34].subideology = 2;
		this.global1.allcountries[35].subideology = 11;
		this.global1.allcountries[36].subideology = 2;
		this.global1.allcountries[37].subideology = 15;
		this.global1.allcountries[38].Gosstroy = 2;
		this.global1.allcountries[38].subideology = 15;
		this.global1.allcountries[39].subideology = 12;
		this.global1.allcountries[40].subideology = 0;
		this.global1.allcountries[41].subideology = 0;
		this.global1.allcountries[42].subideology = 0;
		this.global1.allcountries[43].subideology = 2;
		this.global1.allcountries[44].subideology = 14;
		this.global1.allcountries[45].subideology = 9;
		this.global1.allcountries[46].subideology = 9;
		this.global1.allcountries[47].subideology = 11;
		this.global1.allcountries[48].subideology = 15;
		this.global1.allcountries[52].subideology = 15;
		this.global1.allcountries[53].subideology = 14;
		this.global1.allcountries[this.number].subideology = -1;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0005BCC0 File Offset: 0x00059EC0
	private void OnMouseDown()
	{
		if (this.number == 1 || this.number == 2 || this.number == 5 || this.number == 6 || ((this.number == 10 || this.number == 12 || this.number == 18) && this.is_active[1]) || ((this.number == 3 || this.number == 4 || this.number == 20) && this.is_active[0]) || ((this.number == 49 || this.number == 50 || this.number == 51) && this.is_active[2]))
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.global1.sovietPremiereName = "Gorbachev";
			}
			else
			{
				this.global1.sovietPremiereName = "Горбачёв";
			}
			this.global1.diff[0] = this.diff[0];
			this.global1.diff[1] = this.diff[1];
			this.global1.diff[2] = this.diff[2];
			this.global1.diff[4] = this.diff[4];
			if (this.global1.diff[0] && this.global1.diff[1] && this.global1.diff[2])
			{
				this.global1.iron_and_blood = true;
			}
			else
			{
				this.global1.iron_and_blood = false;
			}
			this.subIdeologyCheck();
			PlayerPrefs.SetString("V1", " ");
			PlayerPrefs.SetString("I2", " ");
			PlayerPrefs.SetString("S3", " ");
			PlayerPrefs.SetString("R3", " ");
			for (int i = 0; i < this.global1.science.Length; i++)
			{
				this.global1.science[i] = false;
			}
			for (int j = 0; j < this.global1.event_done.Length; j++)
			{
				this.global1.event_done[j] = false;
			}
			for (int k = 0; k < this.global1.Events_active.Length; k++)
			{
				this.global1.Events_active[k] = false;
			}
			this.global1.speed = 0;
			for (int l = 0; l < this.global1.science_time.Length; l++)
			{
				this.global1.science_time[l] = 0;
			}
			for (int m = 0; m < this.global1.data_old.Length; m++)
			{
				this.global1.data_old[m] = 0;
			}
			for (int n = 0; n < this.global1.science_time.Length; n++)
			{
				this.global1.science_time[n] = 0;
			}
			this.global1.data[0] = this.number;
			this.global1.is_elect = true;
			this.global1.is_speech = true;
			this.global1.is_liber = false;
			this.global1.povod = false;
			this.global1.is_konst_max = true;
			this.global1.is_gkchp = false;
			this.global1.issleduetsya = 0;
			this.global1.turn_on = false;
			this.global1.is_save_bylo = false;
			string arg;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				arg = "en";
			}
			else
			{
				arg = "ru";
			}
			TextAsset textAsset = Resources.Load(string.Format("{0}_text/new_texts", arg)) as TextAsset;
			this.global1.new_texts = textAsset.text.Split(new char[]
			{
				'\n'
			});
			Resources.UnloadAsset(textAsset);
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Part_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Part_ru") as TextAsset);
			}
			string text = textAsset.text;
			Resources.UnloadAsset(textAsset);
			string[] array = text.Split(new char[]
			{
				':'
			});
			for (int num = 0; num < array.Length; num++)
			{
				string[] array2 = array[num].Split(new char[]
				{
					';'
				});
				if (array2[0] == this.number.ToString())
				{
					this.global1.party_name[0] = array2[1];
					this.global1.party_name[1] = array2[2];
					this.global1.party_name[2] = array2[3];
					this.global1.party_name[3] = array2[4];
					this.global1.party_name[4] = array2[5];
					break;
				}
			}
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Polit_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Polit_ru") as TextAsset);
			}
			string text2 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text2.Split(new char[]
			{
				':'
			});
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				string[] array3 = array[num2].Split(new char[]
				{
					';'
				});
				if (array3[0] == this.number.ToString())
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
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Opis_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Opis_ru") as TextAsset);
			}
			string text3 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text3.Split(new char[]
			{
				':'
			});
			for (int num3 = 0; num3 < array.Length; num3++)
			{
				string[] array4 = array[num3].Split(new char[]
				{
					';'
				});
				if (array4[0] == this.number.ToString())
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
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Charact_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Charact_ru") as TextAsset);
			}
			string text4 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text4.Split(new char[]
			{
				':'
			});
			for (int num4 = 0; num4 < array.Length; num4++)
			{
				string[] array5 = array[num4].Split(new char[]
				{
					';'
				});
				if (array5[0] == this.number.ToString())
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
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Doctr_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Doctr_ru") as TextAsset);
			}
			string text5 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text5.Split(new char[]
			{
				';'
			});
			for (int num5 = 0; num5 < array.Length; num5++)
			{
				this.global1.doctr[num5] = array[num5];
			}
			textAsset = (Resources.Load("Country_data_" + this.number.ToString()) as TextAsset);
			string text6 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text6.Replace("\n", "").Split(new char[]
			{
				':'
			});
			this.global1.allcountries[49] = new Country();
			this.global1.allcountries[50] = new Country();
			this.global1.allcountries[51] = new Country();
			for (int num6 = 0; num6 < array.Length; num6++)
			{
				string[] array6 = array[num6].Split(new char[]
				{
					';'
				});
				int num7 = int.Parse(array6[0]);
				this.global1.allcountries[num7].isSEV = (array6[1] == "1");
				this.global1.allcountries[num7].isOVD = (array6[2] == "1");
				this.global1.allcountries[num7].Vyshi = (array6[3] == "1");
				this.global1.allcountries[num7].Donat = (array6[4] == "1");
				this.global1.allcountries[num7].Help = (array6[5] == "1");
				this.global1.allcountries[num7].Stasi = (array6[6] == "1");
				this.global1.allcountries[num7].Torg = (array6[7] == "1");
				this.global1.allcountries[num7].Money = (array6[8] == "1");
				this.global1.allcountries[num7].Westalgie = int.Parse(array6[9]);
				this.global1.allcountries[num7].Gosstroy = int.Parse(array6[10]);
			}
			this.global1.allcountries[54].isSEV = false;
			this.global1.allcountries[54].isOVD = false;
			this.global1.allcountries[54].Vyshi = true;
			this.global1.allcountries[54].Donat = false;
			this.global1.allcountries[54].Help = false;
			this.global1.allcountries[54].Stasi = false;
			this.global1.allcountries[54].Torg = false;
			this.global1.allcountries[54].Money = false;
			this.global1.allcountries[54].Westalgie = 0;
			this.global1.allcountries[54].Gosstroy = 2;
			this.global1.allcountries[54].subideology = 15;
			this.global1.allcountries[47].isSEV = false;
			this.global1.allcountries[47].isOVD = false;
			this.global1.allcountries[47].Vyshi = false;
			this.global1.allcountries[47].Donat = false;
			this.global1.allcountries[47].Help = false;
			this.global1.allcountries[47].Stasi = false;
			if (this.global1.data[0] == 10 || this.global1.data[0] == 18)
			{
				this.global1.allcountries[47].Torg = true;
			}
			else
			{
				this.global1.allcountries[47].Torg = false;
			}
			this.global1.allcountries[47].Money = false;
			this.global1.allcountries[47].Westalgie = 0;
			this.global1.allcountries[47].Gosstroy = 1;
			this.global1.allcountries[48].isSEV = false;
			this.global1.allcountries[48].isOVD = false;
			this.global1.allcountries[48].Vyshi = false;
			this.global1.allcountries[48].Donat = false;
			this.global1.allcountries[48].Help = false;
			this.global1.allcountries[48].Stasi = false;
			this.global1.allcountries[48].Torg = false;
			this.global1.allcountries[48].Money = false;
			this.global1.allcountries[48].Westalgie = 0;
			this.global1.allcountries[48].Gosstroy = 2;
			if (PlayerPrefs.GetInt("language") == 0)
			{
				textAsset = (Resources.Load("Country_en") as TextAsset);
			}
			else
			{
				textAsset = (Resources.Load("Country_ru") as TextAsset);
			}
			string text7 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text7.Split(new char[]
			{
				';'
			});
			Debug.Log(array.Length);
			Debug.Log(this.global1.allcountries.Length);
			for (int num8 = 0; num8 < array.Length; num8++)
			{
				this.global1.allcountries[num8].name = array[num8];
			}
			textAsset = (Resources.Load("Data" + this.number.ToString()) as TextAsset);
			string text8 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text8.Replace("\n", null).Split(new char[]
			{
				';'
			});
			for (int num9 = 1; num9 < array.Length; num9++)
			{
				this.global1.data[num9] = int.Parse(array[num9]);
			}
			for (int num10 = array.Length; num10 < this.global1.data.Length; num10++)
			{
				this.global1.data[num10] = 0;
			}
			textAsset = (Resources.Load("Party_data_" + this.number.ToString()) as TextAsset);
			string text9 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text9.Replace("\n", null).Split(new char[]
			{
				':'
			});
			for (int num11 = 0; num11 < array.Length; num11++)
			{
				string[] array7 = array[num11].Split(new char[]
				{
					';'
				});
				this.global1.is_party_enabled[num11] = (array7[0] == "1");
				this.global1.is_party_ally[num11] = (array7[1] == "1");
				this.global1.party_ideology[num11] = int.Parse(array7[2]);
				this.global1.party_number[num11] = int.Parse(array7[3]);
			}
			textAsset = (Resources.Load("Regions_" + this.number.ToString()) as TextAsset);
			string text10 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			string[] array8 = text10.Replace("\n", null).Split(new char[]
			{
				'|'
			});
			array = array8[1].Split(new char[]
			{
				':'
			});
			string[] array9 = array8[0].Split(new char[]
			{
				':'
			});
			for (int num12 = 0; num12 < array9.Length; num12++)
			{
				string[] array10 = array9[num12].Split(new char[]
				{
					';'
				});
				this.global1.regions[int.Parse(array10[0])] = new Region();
				this.global1.regions[int.Parse(array10[0])].city_level = int.Parse(array10[1]);
			}
			for (int num13 = 0; num13 < 5; num13++)
			{
				for (int num14 = 0; num14 < 15; num14++)
				{
					this.global1.regions[num13].buildings[num14] = new Building();
					this.global1.regions[num13].buildings[num14].type = 0;
					this.global1.regions[num13].buildings[num14].is_builded = false;
					this.global1.regions[num13].buildings[num14].is_working = false;
					this.global1.regions[num13].buildings[num14].is_private = false;
				}
			}
			for (int num15 = 0; num15 < array.Length; num15++)
			{
				string[] array11 = array[num15].Split(new char[]
				{
					';'
				});
				int num16 = int.Parse(array11[0]);
				int num17 = int.Parse(array11[1]);
				this.global1.regions[num16].buildings[num17].type = int.Parse(array11[2]);
				this.global1.regions[num16].buildings[num17].is_builded = (array11[3] == "1");
				this.global1.regions[num16].buildings[num17].is_working = (array11[4] == "1");
				this.global1.regions[num16].buildings[num17].is_private = (array11[5] == "1");
			}
			textAsset = (Resources.Load("Science_" + this.number.ToString()) as TextAsset);
			string text11 = textAsset.text;
			Resources.UnloadAsset(textAsset);
			array = text11.Split(new char[]
			{
				';'
			});
			for (int num18 = 0; num18 < array.Length; num18++)
			{
				this.global1.science[num18] = (array[num18] == "1");
			}
			this.global1.data[49] = UnityEngine.Random.Range(1, 5);
			this.global1.data[48] = UnityEngine.Random.Range(1, 5);
			this.global1.data[47] = UnityEngine.Random.Range(1, 5);
			if (this.global1.diff[0])
			{
				this.global1.data[8] -= 50;
			}
			if (this.global1.diff[1])
			{
				this.global1.data[8] -= 50;
			}
			if (this.global1.diff[2])
			{
				this.global1.data[8] -= 50;
			}
			if (this.number == 5)
			{
				this.global1.povod = true;
				this.global1.data[36] = 1;
			}
			else if (this.number == 2)
			{
				this.global1.is_elect = false;
			}
			if (this.sanbox)
			{
				this.global1.diff[3] = true;
				this.global1.iron_and_blood = false;
				this.global1.data[1] = 1000;
				this.global1.data[2] = 100;
				this.global1.data[3] = 1000;
				this.global1.data[4] = 0;
				this.global1.data[8] = 1000;
				this.global1.data[9] = 1000;
				this.global1.data[10] = 0;
			}
			if (this.global1.data[0] == 10)
			{
				this.global1.data[97] = this.global1.data[7];
				this.global1.data[64] = 200;
			}
			else if (this.global1.data[0] == 18)
			{
				this.global1.data[102] = 0;
				this.global1.data[77] = 3;
			}
			else if (this.global1.data[0] == 12)
			{
				this.global1.data[90] = 0;
				this.global1.data[94] = 0;
				this.global1.data[92] = 1;
				this.global1.data[93] = 1;
				this.global1.data[81] = 1;
				this.global1.data[80] = 60;
				for (int num19 = 114; num19 < 126; num19++)
				{
					if (this.global1.data[num19 - 1] > 85)
					{
						this.global1.data[num19] = UnityEngine.Random.Range(60, 85);
					}
					else if (this.global1.data[num19 - 1] > 80)
					{
						this.global1.data[num19] = UnityEngine.Random.Range(60, 80);
					}
					else if (this.global1.data[num19 - 1] > 75)
					{
						this.global1.data[num19] = UnityEngine.Random.Range(60, 75);
					}
					else if (this.global1.data[num19 - 1] > 70)
					{
						this.global1.data[num19] = UnityEngine.Random.Range(60, 70);
					}
					else
					{
						this.global1.data[num19] = UnityEngine.Random.Range(70, 90);
					}
				}
			}
			this.global1.allcountries[13].Gosstroy = 1;
			this.InDLCCheck();
			SceneManager.LoadScene(this.new_scene);
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0005D338 File Offset: 0x0005B538
	public void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (!this.diff[0] || !this.diff[1] || !this.diff[2] || this.sanbox)
			{
				this.ach_text.text = "Achievements cannot be unlocked";
				return;
			}
			if (this.global1.allcountries[1].paths > 0 || this.global1.allcountries[2].paths > 0 || this.global1.allcountries[3].paths > 0 || this.global1.allcountries[4].paths > 0 || this.global1.allcountries[5].paths > 0 || this.global1.allcountries[6].paths > 0 || this.global1.allcountries[7].paths > 0)
			{
				this.ach_text.text = "Only special achievements";
				return;
			}
			this.ach_text.text = "Achievements can be unlocked";
			return;
		}
		else
		{
			if (!this.diff[0] || !this.diff[1] || !this.diff[2] || this.sanbox)
			{
				this.ach_text.text = "Достижения не могут быть открыты";
				return;
			}
			if (this.global1.allcountries[1].paths > 0 || this.global1.allcountries[2].paths > 0 || this.global1.allcountries[3].paths > 0 || this.global1.allcountries[4].paths > 0 || this.global1.allcountries[5].paths > 0 || this.global1.allcountries[6].paths > 0 || this.global1.allcountries[7].paths > 0)
			{
				this.ach_text.text = "Только особые достижения";
				return;
			}
			this.ach_text.text = "Достижения могут быть открыты";
			return;
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0005D544 File Offset: 0x0005B744
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		for (int i = 0; i < this.global1.allcountries.Length; i++)
		{
			this.global1.allcountries[i] = new Country();
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.ach_text.text = "Achievements cannot be unlocked";
			this.usl2.text = "Pressure from Moscow";
			this.usl3.text = "Western propaganda";
			this.usl1.text = "   Party doggery";
			this.start.text = "Start";
			this.exit.text = "Exit";
		}
		this.Checking_dlc01();
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0005D604 File Offset: 0x0005B804
	public void Checking_dlc01()
	{
		try
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				if (File.Exists(Application.dataPath + "\\hoxha".ToString() + ".txt"))
				{
					this.is_active[0] = true;
					this.ddlc[0].sprite = this.dlc_spr[0];
					this.okno_dlc[0].text_en = "\"Legacy of Hoxha\" is activated";
					this.okno_dlc[0].text = "\"Наследие Ходжи\" активировано";
				}
				else
				{
					this.is_active[0] = false;
					this.okno_dlc[0].text_en = "For Hungary, Czechoslovakia and Albania\nthe DLC \"Legacy of Hoxha\" needed";
					this.okno_dlc[0].text = "Для Венгрии, Чехословакии и Албании\nнужно ДЛЦ \"Наследие Ходжи\"";
				}
				if (File.Exists(Application.dataPath + "\\lefty".ToString() + ".txt"))
				{
					this.is_active[1] = true;
					this.ddlc[1].sprite = this.dlc_spr[1];
					this.BoxDLC[1].SetActive(true);
					this.okno_dlc[1].text_en = "\"Fall of the Curtain\"\nis activated";
					this.okno_dlc[1].text = "\"Падение Занавеса\"\nактивировано";
				}
				else
				{
					this.is_active[1] = false;
					this.okno_dlc[1].text_en = "For DPRK, Cuba and Afganistan\nthe DLC \"Fall of the Curtain\" needed";
					this.okno_dlc[1].text = "Для КНДР, Кубы и Афганистана\nнужно ДЛЦ \"Падение занавеса\"";
					this.BoxDLC[1].SetActive(false);
				}
				if (File.Exists(Application.dataPath + "\\bigb".ToString() + ".txt"))
				{
					this.is_active[2] = true;
					this.ddlc[2].sprite = this.dlc_spr[2];
					this.okno_dlc[2].text_en = "\"Disorder in Yugoslavia\"\nis activated";
					this.okno_dlc[2].text = "\"Раздор в Югославии\"\nактивировано";
				}
				else
				{
					this.is_active[2] = false;
					this.okno_dlc[2].text_en = "For Yugoslavian countries\nthe DLC \"Disorder in Yugoslavia\" needed";
					this.okno_dlc[2].text = "Для Югославских стран\nнужно ДЛЦ \"Раздор в Югославии\"";
				}
				if (File.Exists(Application.dataPath + "\\pmod".ToString() + ".txt"))
				{
					this.is_active[3] = true;
					this.BoxDLC[3].SetActive(true);
					this.ddlc[3].sprite = this.dlc_spr[3];
					this.okno_dlc[3].text_en = "\"Paths of history\"\nis activated";
					this.okno_dlc[3].text = "\"Пути истории\"\nактивировано";
				}
				else
				{
					this.is_active[3] = false;
					this.okno_dlc[3].text_en = "For countries' paths\nthe DLC \"Paths of history\" needed";
					this.okno_dlc[3].text = "Для путей стран\nнужно ДЛЦ \"Пути истории\"";
				}
			}
			else
			{
				if (File.Exists(Application.dataPath + "/hoxha".ToString() + ".txt"))
				{
					this.is_active[0] = true;
					this.ddlc[0].sprite = this.dlc_spr[0];
					this.okno_dlc[0].text_en = "\"Legacy of Hoxha\" is activated";
					this.okno_dlc[0].text = "\"Наследие Ходжи\" активировано";
				}
				else
				{
					this.is_active[0] = false;
					this.okno_dlc[0].text_en = "For Hungary, Czechoslovakia and Albania\nNeed to buy DLC \"Legacy of Hoxha\"";
					this.okno_dlc[0].text = "Для Венгрии, Чехословакии и Албании\nНужно купить ДЛЦ \"Наследие Ходжи\"";
				}
				if (File.Exists(Application.dataPath + "/lefty".ToString() + ".txt"))
				{
					this.is_active[1] = true;
					this.ddlc[1].sprite = this.dlc_spr[1];
					this.BoxDLC[1].SetActive(true);
					this.okno_dlc[1].text_en = "\"Fall of the Curtain\"\nis activated";
					this.okno_dlc[1].text = "\"Падение Занавеса\"\nактивировано";
				}
				else
				{
					this.is_active[1] = false;
					this.okno_dlc[1].text_en = "For DPRK, Cuba and Afganistan\nthe DLC \"Fall of the Curtain\" needed";
					this.okno_dlc[1].text = "Для КНДР, Кубы и Афганистана\nнужно ДЛЦ \"Падение занавеса\"";
					this.BoxDLC[1].SetActive(false);
				}
				if (File.Exists(Application.dataPath + "/bigb".ToString() + ".txt"))
				{
					this.is_active[2] = true;
					this.ddlc[2].sprite = this.dlc_spr[2];
					this.okno_dlc[2].text_en = "\"Disorder in Yugoslavia\"\nis activated";
					this.okno_dlc[2].text = "\"Раздор в Югославии\"\nактивировано";
				}
				else
				{
					this.is_active[2] = false;
					this.okno_dlc[2].text_en = "For Yugoslavian countries\nthe DLC \"Disorder in Yugoslavia\" needed";
					this.okno_dlc[2].text = "Для Югославских стран\nнужно ДЛЦ \"Раздор в Югославии\"";
				}
				if (File.Exists(Application.dataPath + "/pmod".ToString() + ".txt"))
				{
					this.is_active[3] = true;
					this.BoxDLC[3].SetActive(true);
					this.ddlc[3].sprite = this.dlc_spr[3];
					this.okno_dlc[3].text_en = "\"Paths of history\"\nis activated";
					this.okno_dlc[3].text = "\"Пути истории\"\nактивировано";
				}
				else
				{
					this.is_active[3] = false;
					this.okno_dlc[3].text_en = "For countries' paths\nthe DLC \"Paths of history\" needed";
					this.okno_dlc[3].text = "Для путей стран\nнужно ДЛЦ \"Пути истории\"";
				}
			}
		}
		catch
		{
			this.is_active[0] = false;
			this.is_active[1] = false;
			this.okno_dlc[0].text_en = "For Hungary, Czechoslovakia and Albania\nNeed to buy DLC \"Legacy of Hoxha\"";
			this.okno_dlc[0].text = "Для Венгрии, Чехословакии и Албании\nНужно купить ДЛЦ \"Наследие Ходжи\"";
			this.okno_dlc[1].text_en = "For DPRK, Cuba and Afganistan\nthe DLC \"Aftermath\" needed";
			this.okno_dlc[1].text = "Для КНДР, Кубы и Афганистана\nнужно ДЛЦ \"Последствия\"";
			this.okno_dlc[2].text_en = "For Yugoslavian countries\nthe DLC \"Disorder in Yugoslavia\" needed";
			this.okno_dlc[2].text = "Для Югославских стран\nнужно ДЛЦ \"Раздор в Югославии\"";
			this.okno_dlc[3].text_en = "For countries' paths\nthe DLC \"Paths of history\" needed";
			this.okno_dlc[3].text = "Для путей стран\nнужно ДЛЦ \"Пути истории\"";
			this.BoxDLC[1].SetActive(false);
		}
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0005DBD4 File Offset: 0x0005BDD4
	private void OnMouseEnter()
	{
		if (this.number != -1)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0005DBF0 File Offset: 0x0005BDF0
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x040000DC RID: 220
	public string new_scene;

	// Token: 0x040000DD RID: 221
	public string this_scene;

	// Token: 0x040000DE RID: 222
	public int number = -1;

	// Token: 0x040000DF RID: 223
	public Sprite on;

	// Token: 0x040000E0 RID: 224
	public Sprite off;

	// Token: 0x040000E1 RID: 225
	public Sprite[] dlc_spr = new Sprite[5];

	// Token: 0x040000E2 RID: 226
	public SpriteRenderer[] ddlc = new SpriteRenderer[5];

	// Token: 0x040000E3 RID: 227
	public OkoshkoScript[] okno_dlc = new OkoshkoScript[5];

	// Token: 0x040000E4 RID: 228
	public bool[] diff = new bool[6];

	// Token: 0x040000E5 RID: 229
	private GlobalScript global1;

	// Token: 0x040000E6 RID: 230
	public bool sanbox;

	// Token: 0x040000E7 RID: 231
	public bool cheked;

	// Token: 0x040000E8 RID: 232
	public GameObject[] BoxDLC = new GameObject[5];

	// Token: 0x040000E9 RID: 233
	public bool[] is_active = new bool[5];

	// Token: 0x040000EA RID: 234
	public GameObject yug;

	// Token: 0x040000EB RID: 235
	public TextMesh ach_text;

	// Token: 0x040000EC RID: 236
	public TextMesh usl1;

	// Token: 0x040000ED RID: 237
	public TextMesh usl2;

	// Token: 0x040000EE RID: 238
	public TextMesh usl3;

	// Token: 0x040000EF RID: 239
	public TextMesh start;

	// Token: 0x040000F0 RID: 240
	public TextMesh exit;

	// Token: 0x040000F1 RID: 241
	public TextMesh text_dlc;

	// Token: 0x040000F2 RID: 242
	public TextMesh yugobattle;
}
