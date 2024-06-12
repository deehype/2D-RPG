using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public Text coinCountText;
    public static CoinController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
