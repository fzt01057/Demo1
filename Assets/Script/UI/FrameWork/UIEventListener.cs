using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script.UI
{

    public delegate void PointerEventHandler(PointerEventData eventData);
    public delegate void BaseEventHandler(BaseEventData eventData);
    public delegate void AxisEventHandler(AxisEventData eventData);

    public class UIEventListener :MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler, IEventSystemHandler
    {

        public event PointerEventHandler PointerClick;
        public event PointerEventHandler PointerEnter;
        public event PointerEventHandler PointerExit;
        public event PointerEventHandler PointerDown;
        public event PointerEventHandler PointerUp;
        public event PointerEventHandler PointerBeginDrag;
        public event PointerEventHandler PointerDrag;
        public event PointerEventHandler PointerDrop;
        public event PointerEventHandler PointerEndDrag;
        public event PointerEventHandler PointerInitializePotentialDrag;
        public event PointerEventHandler PointerScroll;
        public event BaseEventHandler BaseCancel;
        public event BaseEventHandler BaseDeselect;
        public event BaseEventHandler BaseSelect;
        public event BaseEventHandler BaseSubmit;
        public event BaseEventHandler BaseUpdateSelected;
        public event AxisEventHandler AxisMove;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (PointerBeginDrag != null)
                PointerBeginDrag(eventData);
        }

        public void OnCancel(BaseEventData eventData)
        {
            if (BaseCancel != null)
                BaseCancel(eventData);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (BaseDeselect != null)
                BaseDeselect(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (PointerDrag != null)
                PointerDrag(eventData);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (PointerDrop != null)
                PointerDrop(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (PointerEndDrag != null)
                PointerEndDrag(eventData);
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            if (PointerInitializePotentialDrag != null)
                PointerInitializePotentialDrag(eventData);
        }

        public void OnMove(AxisEventData eventData)
        {
            if (AxisMove != null)
                AxisMove(eventData);
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (PointerClick != null)
                PointerClick(eventData);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (PointerDown != null)
                PointerDown(eventData);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (PointerEnter != null)
                PointerEnter(eventData);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (PointerExit != null)
                PointerExit(eventData);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (PointerUp != null)
                PointerUp(eventData);
        }

        public void OnScroll(PointerEventData eventData)
        {
            if (PointerScroll != null)
                PointerScroll(eventData);
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (BaseSelect != null)
                BaseSelect(eventData);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (BaseSubmit != null)
                BaseSubmit(eventData);
        }

        public void OnUpdateSelected(BaseEventData eventData)
        {
            if (BaseUpdateSelected != null)
                BaseUpdateSelected(eventData);
        }

        public static UIEventListener GetUIEventListener(Transform transform)
        {
            if (transform == null)
                return null;
            return transform.GetComponent<UIEventListener>() ?? transform.gameObject.AddComponent<UIEventListener>();
        }
    }
}