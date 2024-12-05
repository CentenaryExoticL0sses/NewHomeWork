using System;
using UnityEngine;

public class MemoryCard : MonoBehaviour 
{
	[SerializeField] private GameObject _cardBack;
	[SerializeField] private SceneController _controller;

    public int Id
    {
        get
        {
            return _id;
        }
    }

    private int _id;

	public void SetCard(int id, Sprite image) 
	{
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	public void SetController(SceneController controller)
	{
		_controller = controller;
	}

	public void OnMouseDown() 
	{
		if (_cardBack.activeSelf && _controller.CanReveal) 
		{
			_cardBack.SetActive(false);
            _controller.CardRevealed(this);
        }
	}

	public void Unreveal() 
	{
		_cardBack.SetActive(true);
	}
}
