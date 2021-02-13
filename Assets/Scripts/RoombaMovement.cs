using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoombaMovement : MonoBehaviour
{
    [SerializeField] private Image _batteryUI;
    [SerializeField] private Transform cam;
    [SerializeField] private FloatingJoystick joystick;
    private RoombaController _roombaController;
    private CharacterController _controller;
    private float _gravity;
    private float _currentPower;
    private float _maxPower;
    private float _moveSpeed;
    private float _turnSpeed;
    private float _powerConsMultiplier;

    public float CurrentPower { get => _currentPower; set => _currentPower = value; }
    public float MaxPower { get => _maxPower; set => _maxPower = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float TurnSpeed { get => _turnSpeed; set => _turnSpeed = value; }
    public float PowerConsMultiplier { get => _powerConsMultiplier; set => _powerConsMultiplier = value; }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _roombaController = GetComponent<RoombaController>();
        _currentPower = _maxPower;
    }

    private void Update()
    {
        _gravity -= 9.81f * Time.deltaTime;
        if (_controller.isGrounded) _gravity = 0;

        if (_currentPower > 0)
        {
            // Vertical is speed, horizontal is rotation
            transform.Rotate(joystick.Horizontal * _turnSpeed * Time.deltaTime * Vector3.up);

            Vector3 moveDelta = transform.forward * joystick.Vertical * _moveSpeed + Vector3.up * _gravity;
            _controller.Move(moveDelta * Time.deltaTime);
        }

        if (joystick.Vertical != 0)
        {
            _currentPower -= Time.deltaTime * _powerConsMultiplier;
        }
        else
        {
            _currentPower -= Time.deltaTime;
        }
        if(_currentPower <= 0f)
        {
            _roombaController.OpenShopUI();
        }

        _batteryUI.fillAmount = _currentPower / _maxPower;
    }
}
