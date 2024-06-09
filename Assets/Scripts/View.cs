using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI nameMessageText;

    public TMP_InputField jobInputField;
    public TextMeshProUGUI jobMessageText;

    public TextMeshProUGUI resultText;
    public Button applyButton;

    public ViewModel viewModel;

    private void Start()
    {
        viewModel = new ViewModel();
        viewModel.Name.OnValueChanged += OnNameChanged;
        nameInputField.onValueChanged.AddListener(OnNameInputChanged);

        viewModel.Job.OnValueChanged += OnJobChanged;
        jobInputField.onValueChanged.AddListener(OnJobInputChanged);

        applyButton.onClick.AddListener(OnApplyButtonClick);

        viewModel.GetModel();
    }


    private void OnDestroy()
    {
        viewModel.Name.OnValueChanged -= OnNameChanged;
        nameInputField.onValueChanged.RemoveListener(OnNameInputChanged);

        viewModel.Job.OnValueChanged -= OnJobChanged;
        jobInputField.onValueChanged.RemoveListener(OnJobInputChanged);

        applyButton.onClick.RemoveListener(OnApplyButtonClick);
    }

    private void OnNameChanged(string oldVal, string newVal)
    {
        nameMessageText.text = newVal;
    }

    private void OnNameInputChanged(string value)
    {
        viewModel.Name.Value = value;
    }

    private void OnJobChanged(string oldVal, string newVal)
    {
        jobMessageText.text = newVal;
    }

    private void OnJobInputChanged(string value)
    {
        viewModel.Job.Value = value;
    }

    private void OnApplyButtonClick()
    {
        resultText.text = viewModel.Name.Value + ", " + viewModel.Job.Value + " have been saved";
        viewModel.SaveModel();
    }
}
