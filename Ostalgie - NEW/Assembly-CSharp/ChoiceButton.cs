using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class ChoiceButton : MonoBehaviour
{
	// Token: 0x0600002E RID: 46 RVA: 0x000099CC File Offset: 0x00007BCC
	public void ChangeSelected(bool isSelected)
	{
		if (isSelected)
		{
			this.state = ChoiceButton.ChoiceButtonState.Selected;
		}
		else if (this.state == ChoiceButton.ChoiceButtonState.Selected)
		{
			this.state = ChoiceButton.ChoiceButtonState.Idle;
		}
		this.Repaint();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000099F0 File Offset: 0x00007BF0
	private void OnMouseEnter()
	{
		if (this.state == ChoiceButton.ChoiceButtonState.Idle)
		{
			this.state = ChoiceButton.ChoiceButtonState.MouseEntered;
		}
		this.Repaint();
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00009A07 File Offset: 0x00007C07
	private void OnMouseExit()
	{
		if (this.state == ChoiceButton.ChoiceButtonState.MouseEntered)
		{
			this.state = ChoiceButton.ChoiceButtonState.Idle;
		}
		this.Repaint();
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00009A1F File Offset: 0x00007C1F
	public void ChangeText(string text)
	{
		this.textMesh.text = text;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00009A30 File Offset: 0x00007C30
	private void Repaint()
	{
		this.textMesh.color = ((this.state == ChoiceButton.ChoiceButtonState.Idle) ? this.defaultColor : this.selectedColor);
		this.spriteRenderer.color = ((this.state == ChoiceButton.ChoiceButtonState.Idle) ? Color.white : new Color(0.8627451f, 0.7882353f, 0.73333335f));
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00009A8C File Offset: 0x00007C8C
	private void OnMouseDown()
	{
		this.controller.ReceiveButtonPress(this.num);
	}

	// Token: 0x04000037 RID: 55
	public int num;

	// Token: 0x04000038 RID: 56
	public ChoiceSystemController controller;

	// Token: 0x04000039 RID: 57
	[SerializeField]
	private TextMesh textMesh;

	// Token: 0x0400003A RID: 58
	public SpriteRenderer spriteRenderer;

	// Token: 0x0400003B RID: 59
	public Color defaultColor;

	// Token: 0x0400003C RID: 60
	public Color selectedColor;

	// Token: 0x0400003D RID: 61
	private ChoiceButton.ChoiceButtonState state;

	// Token: 0x0200005F RID: 95
	public enum ChoiceButtonState
	{
		// Token: 0x04000298 RID: 664
		Idle,
		// Token: 0x04000299 RID: 665
		Selected,
		// Token: 0x0400029A RID: 666
		MouseEntered
	}
}
