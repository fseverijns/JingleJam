using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [Header("Win Condition")]
    [SerializeField]
    private float minMargin;
    [SerializeField]
    private float maxMargin;

    [Header("Arrow")]
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float arrowMoveSpeed;
    [SerializeField]
    private List<float> arrowStartPositions = new List<float>();

    [SerializeField]
    private float imageWidth;

    private Player player;
    private Workbench workbench;

    private float currentArrowValue = 0.5f;
    private bool minigameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.MoveArrow());
    }

    public void StartMinigame(Player player, Workbench workbench)
    { 
        this.player = player;
        this.workbench = workbench;
        minigameActive = true;
    }

    private void StartMiniGameDelayed()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(minigameActive)
        {
            if (Input.GetButtonDown("Player" + player.playerNum + "Interact"))
            {
                FinishMinigame();
            }
        }
        
    }

    public void FinishMinigame()
    {
        minigameActive = false;

        if (currentArrowValue >= minMargin && currentArrowValue <= maxMargin)
        {
            workbench.FinishMiniGame(player, true);
        }
        else
        {
            workbench.FinishMiniGame(player, false);
        }

        Destroy(gameObject);
    }

    private IEnumerator MoveArrow()
    {
        float randomArrowDirection = Random.Range(-1, 1);
        int arrowDirection = (int)Mathf.Sign(randomArrowDirection);

        int randomArrowStartIndex = Random.Range(0, arrowStartPositions.Count);
        currentArrowValue = arrowStartPositions[randomArrowStartIndex];

        Vector3 arrowPosition = new Vector3(arrow.transform.localPosition.x, arrow.transform.localPosition.y, arrow.transform.localPosition.z);

        float t = currentArrowValue;
        float left = transform.localPosition.x - (imageWidth / 2f);
        float right = transform.localPosition.x + (imageWidth / 2f);
        float current = Mathf.Lerp(left, right, t);

        while (minigameActive)
        {
            t += (Time.deltaTime * arrowMoveSpeed) * arrowDirection;

            current = Mathf.Lerp(left, right, t);
            arrowPosition.x = current;

            arrow.transform.localPosition = arrowPosition;

            if(t >= 1)
            {
                arrowDirection = -1;
            }
            else if(t <= 0)
            {
                arrowDirection = 1;
            }

            currentArrowValue = t;

            yield return null;
        }
    }
}
