
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private UserInputService _input;
    [SerializeField] private LevelDataHandler _levelDataHandler;

    [Header("Snake")]
    [SerializeField] private Snake _snake;
    [SerializeField] private SnakeCollisionDetection _collisionDetection;
    [SerializeField] private SegmentsMovement _segmentsMovement;

    [Header("UI")]
    [SerializeField] private ScoreUpdateView _scoreUpdateView;
    [SerializeField] private Button _reloadButton;

    void Start()
    {
        SnakeEventDispatcher dispatcher = new SnakeEventDispatcher(); // dispatch events about eat food or snake death for registered listeners
        SnakeSegmentsRepository segmentsRepository = new();

        ScoreUpdate _scoreUpdate = new ScoreUpdate();
        FoodUpdate _foodUpdate = new FoodUpdate(_levelDataHandler.Repository);
        SnakeDeathInvoker _deathListener = new SnakeDeathInvoker(_snake, _reloadButton.gameObject);
        TailCountUpdate _tailCountUpdate = new TailCountUpdate(segmentsRepository, _snake);


        _snake.Movement.Init();
        segmentsRepository.Init(_snake.transform);
        _collisionDetection.Init(dispatcher);
        _segmentsMovement.Init(segmentsRepository, _snake);

        _input.InitInput(); // Init Input system
        _input.RegisterMovableListener(_snake.Movement);

        dispatcher.Register(_scoreUpdate); // dispatcher register
        dispatcher.Register(_foodUpdate);
        dispatcher.Register(_deathListener);
        dispatcher.Register(_tailCountUpdate);
        dispatcher.Register(_segmentsMovement);
        dispatcher.Register(_input);

        _scoreUpdateView.Init(_scoreUpdate); // UI Init

        _snake.Movement.SetNewMoveSpeed(_levelDataHandler.Repository.StartSnakeSpeed);
    }

}
