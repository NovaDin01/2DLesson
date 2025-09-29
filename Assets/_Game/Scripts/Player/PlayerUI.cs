using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    
    public static PlayerUI Instance { get; private set; }
    
    [SerializeField] private GameObject firstHearth;
    [SerializeField] private GameObject secondHearth;
    [SerializeField] private GameObject thirdHearth;

    private GameObject[] healthList;
    private HealthSystem playerHealth;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
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