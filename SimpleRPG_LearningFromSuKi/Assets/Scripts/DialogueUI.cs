using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    public  List<string> contentList;
    private int contentTextIndex = 0;

    public void Start()
    {
        nameText = transform.Find("NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentTextBg/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("ContinueButtonBg").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);

    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name, string[] content)
    {
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentText.text = contentList[0];
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        contentTextIndex++;
        if (contentTextIndex >= contentList.Count) // 如果超过了上限就隐藏
        {
            Hide();
            return;
        }

        contentText.text = contentList[contentTextIndex];

    }
    

}
