using UnityEngine;
using TMPro;

public class ScoreUpdateView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private ScoreUpdate _scoreUpdate;

    public void Init(ScoreUpdate scoreUpdate)
    {
        this._scoreUpdate = scoreUpdate;
        scoreUpdate.ChangedCurrentScore += UpdateScoreView;
    }

    private void OnDisable()
    {
        _scoreUpdate.ChangedCurrentScore -= UpdateScoreView;
    }

    private void UpdateScoreView(int score) 
    {
        _text.text = $"Score: {score}";
    }
}
