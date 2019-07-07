
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateImageText : MonoBehaviour {

	[MenuItem("GameObject/UI/Text")]
	static void CreatText()
	{
		if(Selection.activeTransform)
		{
			if(Selection.activeTransform.GetComponentInParent<Canvas>())
			{
				GameObject go = new GameObject("text",typeof(Text));
				go.GetComponent<Text>().raycastTarget = false;
				go.transform.SetParent(Selection.activeTransform);
				go.transform.localPosition = new Vector3(0,0,0);
			}
		}
	}

	[MenuItem("GameObject/UI/Image")]
	static void CreatImage()
	{
		if(Selection.activeTransform)
		{
			if(Selection.activeTransform.GetComponentInParent<Canvas>())
			{
				GameObject go = new GameObject("image",typeof(Image));
				go.GetComponent<Image>().raycastTarget = false;
				go.transform.SetParent(Selection.activeTransform);
				go.transform.localPosition = new Vector3(0,0,0);
			}
		}
	}

	[MenuItem("GameObject/UI/Button")]
	static void CreatButton()
	{
		if(Selection.activeTransform)
		{
			if(Selection.activeTransform.GetComponentInParent<Canvas>())
			{
				GameObject go = new GameObject("button",typeof(Image));
				go.AddComponent<Button>();
				go.transform.SetParent(Selection.activeTransform);
				go.transform.localPosition = new Vector3(0,0,0);
			}
		}
	}
}
