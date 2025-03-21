using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class spineCube : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Transform _cube;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _durartion;

    private void Start()
    {
        _button.onClick.AddListener(Spin);
    }
    private async void Spin()
    {
        _button.interactable = false;

        float time = 0;

        while(time< _durartion)
        {
            _cube.Rotate(Vector3.one, _rotationSpeed * Time.deltaTime);

            time += Time.deltaTime;

            await Task.Yield();
        }

        _button.interactable = true;
    }
}
