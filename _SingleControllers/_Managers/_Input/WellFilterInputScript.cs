using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WellFilterInputScript : MonoBehaviour {

    [System.Serializable]
    public class FilterSelection {
        public int Value;
        public KeyCode PullKey;
        public KeyCode PushKey;
    }

    public delegate void FilterHandler(int pullFilter, int pushFilter);
    public event FilterHandler ChangeFilter;

    public List<FilterSelection> Filters = new List<FilterSelection>();


    public static WellFilterInputScript Instance {
        get;
        private set;
    }

    public int CurrentPullFilterValue {
        get;
        private set;
    }

    public int CurrentPushFilterValue {
        get;
        private set;
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        SetDefault();
    }

    private void Update() {
        foreach (FilterSelection filter in Filters) {
            if (Input.GetKeyDown(filter.PullKey)) {
                SetPullFilter(filter);
            } else if (Input.GetKeyDown(filter.PullKey)) {
                SetPushFilter(filter);
            }
        }
    }

    private void SetPullFilter(FilterSelection filter) {
        CurrentPullFilterValue = filter.Value;
        CallEvent();
    }

    private void SetPushFilter(FilterSelection filter) {
        CurrentPushFilterValue = filter.Value;
        CallEvent();
    }

    private void CallEvent() {
        if (ChangeFilter != null) {
            ChangeFilter(CurrentPullFilterValue, CurrentPushFilterValue);
        } else {
            Debug.Log("No subscribers");
        }
    }

    private void SetDefault() {
        SetPullFilter(Filters[0]);
        SetPushFilter(Filters[0]);
    }

}
