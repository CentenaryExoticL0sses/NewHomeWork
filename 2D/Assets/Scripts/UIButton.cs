using UnityEngine;

public class UIButton : MonoBehaviour 
{
	[SerializeField] private GameObject _targetObject;
	[SerializeField] private string _targetMessage;

	public Color highlightColor = Color.cyan;

	public void OnMouseEnter() 
	{
		if (TryGetComponent<SpriteRenderer>(out var sprite)) 
		{
			sprite.color = highlightColor;
		}
	}

	public void OnMouseExit() 
	{
		if (TryGetComponent<SpriteRenderer>(out var sprite)) 
		{
			sprite.color = Color.white;
		}
	}

	public void OnMouseDown() 
	{
		transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp() 
	{
		transform.localScale = Vector3.one;

		if (_targetObject != null) 
		{
			_targetObject.SendMessage(_targetMessage);
		}
	}
}
