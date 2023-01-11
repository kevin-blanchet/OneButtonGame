using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life : MonoBehaviour
{
    private Life lifeComponent;

    [SerializeField]
    private GameObject _spriteLife;

    private List<GameObject> _spritesLifes = new List<GameObject>();

    private void Awake()
    {
        InitUI();
    }

    void InitUI()
    {
        lifeComponent = GameManager.GameManagerInstance?.GetPlayerController()?.GetComponent<Life>();
        if (!lifeComponent) return;

        

        for (int i = 0; i < lifeComponent.GetMaxLife(); ++i)
        {
            GameObject img = Instantiate(_spriteLife, transform.position, Quaternion.identity);
            img.transform.SetParent(transform);
            _spritesLifes.Add(img);
        }
    }
    
    void AddLife(int remainingLife)
    {
        _spritesLifes[remainingLife - 1].SetActive(true);
    }

    void RemoveLife(int remainingLife)
    {
        if (remainingLife < 0) return;
        _spritesLifes[remainingLife].SetActive(false);
    }

    private void OnEnable()
    {
        lifeComponent._onTakeDamage += RemoveLife;
    }

    private void OnDisable()
    {
        lifeComponent._onTakeDamage -= RemoveLife;
    }
}
