using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UI_Button : MonoBehaviour, IPointerClickHandler
{
    protected Button button = null;

    void Start()
    {
        Init();
        InitEvents();
    }

    protected virtual void Init()
    {
        button = GetComponent<Button>();
    }

    void InitEvents()
    {
        button.onClick.AddListener(Execute);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Call the Execute method when the UI element is clicked or touched
        Execute();
        Debug.Log("POINTER CLICK CALLED");
    }

    abstract protected void Execute();
}
