using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    public static DialogueUI Instance{ get; private set; }
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    private List<string> contentList;
    private int contentTextIndex = 0;

    private GameObject uiGameObject;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); 
            return;
        }
        
        Instance = this;
    }

    public void Start()
    {
        nameText = transform.Find("UI/NameTextBg/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentTextBg/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/ContinueButtonBg").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();

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
        contentTextIndex = 0;
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
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
