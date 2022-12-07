using UnityEngine;
using UnityEngine.EventSystems;

public class LR_ButtonsScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public static bool lButtonPressed;
	public static bool rButtonPressed;

	private void Start() {
		lButtonPressed = false;
		rButtonPressed = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (this.gameObject.name.Equals("LeftButton")) {
			lButtonPressed = true;
		}
		else if (this.gameObject.name.Equals("RightButton")) {
			rButtonPressed = true;
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (this.gameObject.name.Equals("LeftButton")) {
			lButtonPressed = false;
		}
		else if (this.gameObject.name.Equals("RightButton")) {
			rButtonPressed = false;
		}
	}
}