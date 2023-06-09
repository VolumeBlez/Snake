
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [Header("Input Service")]
    [SerializeField] private UserInputService _input;

    [Header("Level Data")]
    [SerializeField] private LevelDataHandler _levelDataHandler;

    [Header("Snake")]
    [SerializeField] private Snake _snake;
    [SerializeField] private SnakeCollisionDetection _collisionDetection;
    [SerializeField] private SegmentsMovement _segmentsMovement;

    [Header("UI")]
    [SerializeField] private ScoreUpdateView _scoreUpdateView;
    [SerializeField] private Button _reloadButton;

    [Header("PArticles")]
    [SerializeField] private ParticleSystem _deathParticle;

    [Header("Audio")]
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private AudioClip _gameOverSoundClip;
    [SerializeField] private AudioClip _foodEatSoundClip;

    void Start()
    {
        SnakeEventDispatcher dispatcher = new SnakeEventDispatcher(); // dispatch events about eat food or snake death for registered listeners
        SnakeSegmentsRepository segmentsRepository = new();

        ScoreUpdate _scoreUpdate = new ScoreUpdate();
        FoodUpdate _foodUpdate = new FoodUpdate(_levelDataHandler.Repository);
        SnakeDeathInvoker _deathListener = new SnakeDeathInvoker(_snake, _reloadButton.gameObject);
        TailCountUpdate _tailCountUpdate = new TailCountUpdate(segmentsRepository, _snake);

        DeathParticleInvoker _deathParticleInvoker = new(_deathParticle, _snake.transform);

        EventAudioInvoker foodAudioInvoker = new(EventType.FoodEat, _foodEatSoundClip, _audioPlayer);
        EventAudioInvoker gameOverAudioInvoker = new(EventType.SnakeDeath, _gameOverSoundClip, _audioPlayer);

        segmentsRepository.Init(_snake.transform);
        _collisionDetection.Init(dispatcher);
        _segmentsMovement.Init(segmentsRepository, _snake);


        dispatcher.Register(_deathParticleInvoker);// dispatcher register
        dispatcher.Register(_scoreUpdate);
        dispatcher.Register(_foodUpdate);
        dispatcher.Register(_deathListener);
        dispatcher.Register(_tailCountUpdate);
        dispatcher.Register(_segmentsMovement);
        dispatcher.Register(foodAudioInvoker);
        dispatcher.Register(gameOverAudioInvoker);
        dispatcher.Register(_input);

        _scoreUpdateView.Init(_scoreUpdate); // UI Init

        _snake.Movement.SetNewMoveSpeed(_levelDataHandler.Repository.StartSnakeSpeed); // Data provide init

        _snake.Movement.Init();
        _input.InitInput(); // Init Input system
        _input.RegisterMovableListener(_snake.Movement);
    }

}
