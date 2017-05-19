using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Character character;

	public Color fullHealthColor = Color.green;
	public Color zeroHealthColor = Color.red;

	private Color currentColor;
	private Image image;

	void Start() {
		image = GetComponent<Image> ();
	}

	void Update () {
		UpdateHealthBar ();
	}

	void UpdateHealthBar () {
		currentColor = Color.Lerp (zeroHealthColor, fullHealthColor, character.health / character.startingHealth);
		image.color = currentColor;
	}
}