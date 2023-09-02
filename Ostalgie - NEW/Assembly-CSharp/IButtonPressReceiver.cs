using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
public interface IButtonPressReceiver
{
	// Token: 0x060001A4 RID: 420
	void OnButtonDown(int num);

	// Token: 0x060001A5 RID: 421
	void OnButtonEnter(int num, SpriteRenderer spr);

	// Token: 0x060001A6 RID: 422
	void OnButtonExit(int num, SpriteRenderer spr);

	// Token: 0x060001A7 RID: 423
	void OnButtonStay(int num);
}
