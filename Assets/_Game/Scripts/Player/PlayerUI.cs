using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject firstHearth;
    [SerializeField] private GameObject secondHearth;
    [SerializeField] private GameObject thirdHearth;

    private GameObject[] healthList;
    private HealthSystem playerHealth;

    private void Awake()
    {
        healthList = new GameObject[] { firstHearth, secondHearth, thirdHearth };
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    private void Update()
    {
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        int currentHP = playerHealth.CurrentHealth;

        for (int i = 0; i < healthList.Length; i++)
        {
            healthList[i].SetActive(i < currentHP);
        }
    }
}