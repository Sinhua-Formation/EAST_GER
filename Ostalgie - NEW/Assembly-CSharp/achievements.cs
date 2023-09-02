using System;
using Steamworks;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class achievements : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x0000221C File Offset: 0x0000041C
	private void OnEnable()
	{
		if (!GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			try
			{
				if (SteamManager.Initialized)
				{
					Debug.Log("------------ACHIVKI ACTIVIROVANI-------------------");
					this.m_GameID = new CGameID(SteamUtils.GetAppID());
					this.m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate(this.OnUserStatsReceived));
					this.m_UserStatsStored = Callback<UserStatsStored_t>.Create(new Callback<UserStatsStored_t>.DispatchDelegate(this.OnUserStatsStored));
					this.m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(new Callback<UserAchievementStored_t>.DispatchDelegate(this.OnAchievementStored));
					this.m_bRequestedStats = false;
					this.m_bStatsValid = false;
				}
			}
			catch
			{
				Debug.Log("------------OSHIBKA PRO ACRIVACCI-------------------");
			}
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000022D8 File Offset: 0x000004D8
	public void Set(int number)
	{
		Debug.Log("------------SET VISVAN-------------------");
		this.ach_this[number] = true;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000022F0 File Offset: 0x000004F0
	private void UnlockAchievement(string ach, bool clear)
	{
		if (!GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			try
			{
				Debug.Log("------------UNLOCK ACHIVMENT VIS VAN BES OSHIPOK-------------------");
				if (clear)
				{
					SteamUserStats.ClearAchievement(ach);
				}
				else
				{
					Debug.Log("------------OTRKIVAEM  " + ach + "-------------------");
					SteamUserStats.SetAchievement(ach);
				}
				this.m_bStoreStats = true;
			}
			catch
			{
			}
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002364 File Offset: 0x00000564
	private void Update()
	{
		if (!GameObject.Find("SteamManager").GetComponent<SteamManager>().achivki_sosut)
		{
			try
			{
				if (SteamManager.Initialized)
				{
					if (!this.m_bRequestedStats)
					{
						if (!SteamManager.Initialized)
						{
							this.m_bRequestedStats = true;
							return;
						}
						bool bRequestedStats = SteamUserStats.RequestCurrentStats();
						this.m_bRequestedStats = bRequestedStats;
					}
					if (this.m_bStatsValid)
					{
						for (int i = 1; i < this.ach_this.Length; i++)
						{
							if (this.ach_this[i])
							{
								Debug.Log("---------NASHL CHTO " + i.ToString() + " TRUE=========");
								this.ach_this[i] = false;
								this.UnlockAchievement("ACH_" + i, false);
							}
						}
						if (this.m_bStoreStats)
						{
							Debug.Log("------------STORESTATS VISIVAEM-------------------");
							bool flag = SteamUserStats.StoreStats();
							this.m_bStoreStats = !flag;
						}
					}
				}
			}
			catch
			{
			}
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002458 File Offset: 0x00000658
	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				this.m_bStatsValid = true;
				Debug.Log("------------POLUCHILI STATI-------------------");
				return;
			}
			Debug.Log("------------POLUCHENIE STATOV NE POLUICHILOS-------------------");
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000024A8 File Offset: 0x000006A8
	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			if (EResult.k_EResultOK == pCallback.m_eResult)
			{
				Debug.Log("------------STROE STATS SDELALI------------------");
				return;
			}
			if (EResult.k_EResultInvalidParam == pCallback.m_eResult)
			{
				Debug.Log("------------YA NE ZNA U CHE ETO  NO  IZ STORESTST VIZIVAEM ON USERSTATSRECIVED CALLBACK------------------");
				this.OnUserStatsReceived(new UserStatsReceived_t
				{
					m_eResult = EResult.k_EResultOK,
					m_nGameID = (ulong)this.m_GameID
				});
				return;
			}
			Debug.Log("------------STORESTATS NE POLUCHILOS PITAEMSA ZANOVO-------------------");
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002523 File Offset: 0x00000723
	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)this.m_GameID == pCallback.m_nGameID)
		{
			Debug.Log("-------Achievement " + pCallback.m_rgchAchievementName + " unlocked!------");
		}
	}

	// Token: 0x04000001 RID: 1
	public bool[] ach_this = new bool[200];

	// Token: 0x04000002 RID: 2
	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	// Token: 0x04000003 RID: 3
	protected Callback<UserStatsStored_t> m_UserStatsStored;

	// Token: 0x04000004 RID: 4
	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	// Token: 0x04000005 RID: 5
	private bool m_bStoreStats;

	// Token: 0x04000006 RID: 6
	private bool m_bRequestedStats;

	// Token: 0x04000007 RID: 7
	private bool m_bStatsValid;

	// Token: 0x04000008 RID: 8
	private CGameID m_GameID;
}
