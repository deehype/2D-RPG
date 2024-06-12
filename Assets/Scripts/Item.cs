using UnityEngine;


public class Item : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                CoinController.Instance.coinCountText.text = GameManager.Instance.Coin.ToString();
                Debug.Log("Player Coin : " + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player HP : " + GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                GameManager.Instance.player.GetComponent<Character>().Speed += 4;

                Debug.Log("Player Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Damage")
            {
                GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage += 5;
                Debug.Log("Player Attack Damage :" + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage);
                Destroy(gameObject);
            }
        }
    }
}
    
