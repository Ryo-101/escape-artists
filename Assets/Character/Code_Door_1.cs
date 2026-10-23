using TMPro;
using UnityEngine;

public class Code_Door_1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Typed;
    [SerializeField] private GameObject Door;

    private string Code = "351";

    public void Input(int num)
    {
        Typed.text += num.ToString();
    }

    public void Execute()
    {
        if (Typed.text == Code)
        {
            Destroy(Door);
        }
        else
        {
            Typed.text = "INVALID";
        }
    }

    public void Backspace()
    {
        Typed.text = Typed.text.Remove(Typed.text.Length - 1);
    }
}
