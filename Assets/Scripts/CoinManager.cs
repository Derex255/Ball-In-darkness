using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{

    public List<Coin> CoinList = new List<Coin>();
    public GameObject coinPrefab;
    public TMP_Text coinText;
    public int initialCoin = 50;
    public GameObject BloodMarkerPrefab;
    private AudioController audioController;


    void Start()
    {


        audioController = FindObjectOfType<AudioController>();
        for (int i = 0; i < initialCoin; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
            GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity);
            CoinList.Add(newCoin.GetComponent<Coin>());
        }
        UpdateText();
    }
    public void CollectCoin(Coin coin)
    {
        Vector3 bloodPosition = new Vector3(coin.transform.position.x, -0.035f, coin.transform.position.z);
        CoinList.Remove(coin);
        Destroy(coin.gameObject);
        UpdateText();
        Instantiate(BloodMarkerPrefab, bloodPosition, coin.transform.rotation);
        audioController.PlayDeathSound();
    }
    private void UpdateText()
    {
        coinText.text = "ти Маєш зібрати" + CoinList.Count.ToString();
    }
    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < CoinList.Count; i++)
        {
            float distance = Vector3.Distance(point, CoinList[i].transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestCoin = CoinList[i];
            }
        }
        return closestCoin;
    }
}






