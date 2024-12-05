using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
	[SerializeField] private MemoryCard _originalCard;
	[SerializeField] private Sprite[] _images;
	[SerializeField] private TextMesh _scoreLabel;
	[Space]
	[SerializeField] private Vector3 _startPos = new Vector3(-3f, 1f, 0f);

    public const int GridRows = 2;
    public const int GridCols = 4;
    public const float OffsetX = 2f;
    public const float OffsetY = 2.5f;

    public bool CanReveal
    {
        get
        {
            return _secondRevealed == null;
        }
    }

    private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;

	private int _score = 0;

	void Start() 
	{
		int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
		numbers = ShuffleArray(numbers);

		// place cards in a grid
		for (int i = 0; i < GridCols; i++) 
		{
			for (int j = 0; j < GridRows; j++) 
			{
				MemoryCard card = Instantiate(_originalCard) as MemoryCard;
				card.SetController(this);

                int index = j * GridCols + i;
				int id = numbers[index];
				card.SetCard(id, _images[id]);

				float posX = (OffsetX * i) + _startPos.x;
				float posY = -(OffsetY * j) + _startPos.y;

				card.transform.position = new Vector3(posX, posY, _startPos.z);
			}
		}
	}

	private int[] ShuffleArray(int[] numbers) 
	{
		int[] newArray = numbers.Clone() as int[];

		for (int i = 0; i < newArray.Length; i++ ) 
		{
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}

		return newArray;
	}

	public void CardRevealed(MemoryCard card) 
	{
		if (_firstRevealed == null) 
		{
			_firstRevealed = card;
		} 
		else 
		{
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}
	
	private IEnumerator CheckMatch() 
	{
		if (_firstRevealed.Id == _secondRevealed.Id) 
		{
			_score++;
			_scoreLabel.text = "Score: " + _score;
		}
		else 
		{
			yield return new WaitForSeconds(.5f);
			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		
		_firstRevealed = null;
		_secondRevealed = null;
	}

	public void Restart() 
	{
		SceneManager.LoadScene("Scene");
	}
}
