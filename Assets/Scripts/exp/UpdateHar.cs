using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Text strenght;
    [SerializeField] private Text agility;
    [SerializeField] private Text intellect;
    [SerializeField] private ClassHerro characterSettings;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ClaimHar();
        }
    }

    private void ClaimHar()
    {
        if (characterSettings == null)
        {
            Debug.LogError("characterSettings ?? ???? ?????????? ? ??????????!");
            return;
        }

        if (strenght == null || intellect == null || agility == null)
        {
            Debug.LogError("?? ??? UI Text ?????????? ??????????!");
            return;
        }

        strenght.text = characterSettings.strenght.ToString();
        intellect.text = characterSettings.intelect.ToString();
        agility.text = characterSettings.agility.ToString();
    }
}