using UnityEngine;

public class SquareRoomController : MonoBehaviour
{
    public GameObject northGate;
    public GameObject northGateUp;

    public GameObject eastGate;
    public GameObject eastGateUp;

    public float gateOpenTime = 3.0f;
    public float gateCloseTime = 0.4f;
    public float enemyBattleTime = 10.0f;

    public bool debugEnabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_triggerEnteredOnce)
        {
            if (other.gameObject.GetComponent<CyberSpaceFirstPerson>() != null)
            {
                _state = SquareRoomControllerState.Closing;
                _stateTimer = gateCloseTime;
                _triggerEnteredOnce = true;
            }    
        }
    }

    public void OnExitTrigger()
    {
        if (_state == SquareRoomControllerState.PostBattle)
        {
            _state = SquareRoomControllerState.FinalClosing;
            _stateTimer = gateCloseTime;
        }
        else
        {
            Debug.LogError("SquareRoomController got OnExitTrigger during unexpected state");
        }
    }

    void Start()
    {
        _northGateOriginalPosition = northGate.transform.position;
        _northGateUpPosition = northGateUp.transform.position;
        _eastGateOriginalPosition = eastGate.transform.position;
        _eastGateUpPosition= eastGateUp.transform.position;

        northGate.transform.position = _northGateUpPosition;
        eastGate.transform.position = _eastGateUpPosition;
    }

    private void OnGUI()
    {
        if (!debugEnabled)
        {
            return;
        }
        GUI.Label(new Rect(30, 30, 1000, 40), "State is " + _state.ToString());
    }

    void Update()
    {
        
        void UpdateClosing()
        {
            _stateTimer -= Time.deltaTime;

            Vector3 northGatePosition =
                Vector3.Lerp(_northGateOriginalPosition, _northGateUpPosition, _stateTimer / gateCloseTime);
            northGate.transform.position = northGatePosition;

            Vector3 eastGatePosition =
                Vector3.Lerp(_eastGateOriginalPosition, _eastGateUpPosition, _stateTimer / gateCloseTime);
            eastGate.transform.position = eastGatePosition;

            if (_stateTimer <= 0)
            {
                _state = SquareRoomControllerState.EnemyBattle;
                _stateTimer = gateCloseTime;
            }
        };

        void UpdateEnemyBattle()
        {
            _stateTimer -= Time.deltaTime;

            if (_stateTimer <= 0)
            {
                _state = SquareRoomControllerState.Opening;
                _stateTimer = enemyBattleTime;
            }
        };

        void UpdateOpening()
        {
            _stateTimer -= Time.deltaTime;
            Vector3 northGatePosition =
                Vector3.Lerp(_northGateOriginalPosition, _northGateUpPosition, 1 - _stateTimer / gateOpenTime);
            Vector3 eastGatePosition =
                Vector3.Lerp(_eastGateOriginalPosition, _eastGateUpPosition, 1 - _stateTimer / gateOpenTime);
            northGate.transform.position = northGatePosition;
            eastGate.transform.position = eastGatePosition;

            if (_stateTimer <= 0)
            {
                _state = SquareRoomControllerState.PostBattle;
                _stateTimer = gateOpenTime;
            }
        };

        void UpdateFinalClosing()
        {
            _stateTimer -= Time.deltaTime;
            Vector3 northGatePosition =
                Vector3.Lerp(_northGateOriginalPosition, _northGateUpPosition, _stateTimer / gateCloseTime);
            Vector3 eastGatePosition =
                Vector3.Lerp(_eastGateOriginalPosition, _eastGateUpPosition, _stateTimer / gateCloseTime);
            northGate.transform.position = northGatePosition;
            eastGate.transform.position = eastGatePosition;

            if (_stateTimer <= 0)
            {
                _state = SquareRoomControllerState.Idle;
                _stateTimer = gateCloseTime;
            }
        };

        switch (_state)
        {
            case SquareRoomControllerState.Idle:
                break;
            case SquareRoomControllerState.Closing:
                UpdateClosing();
                break;
            case SquareRoomControllerState.EnemyBattle:
                UpdateEnemyBattle();
                break;
            case SquareRoomControllerState.Opening:
                UpdateOpening();
                break;
            case SquareRoomControllerState.PostBattle:
                break;
            case SquareRoomControllerState.FinalClosing:
                UpdateFinalClosing();
                break;
            default:
                break;
        }
    }

    private enum SquareRoomControllerState
    {
        Idle,
        Closing,
        EnemyBattle,
        Opening,
        PostBattle,
        FinalClosing
    }

    private Vector3 _northGateOriginalPosition;
    private Vector3 _eastGateOriginalPosition;
    private Vector3 _northGateUpPosition;
    private Vector3 _eastGateUpPosition;

    private float _stateTimer;

    private SquareRoomControllerState _state = SquareRoomControllerState.Idle;

    private bool _triggerEnteredOnce = false;
}
