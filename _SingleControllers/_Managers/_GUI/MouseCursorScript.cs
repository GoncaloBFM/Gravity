using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseCursorScript : MonoBehaviour {

    [System.Serializable]
    public class TextureSelection {
        public Texture2D Texture;
        public int PullFilter;
        public int PushFilter;
    }

    public List<TextureSelection> Textures = new List<TextureSelection>();
    public Vector3 Offset;

    public static MouseCursorScript Instance {
        get;
        private set;
    }

    public void SetNewCursor(int pullFilter, int pushFilter) {
        foreach (TextureSelection textureSelection in Textures) {
            if ((textureSelection.PullFilter == pullFilter) && textureSelection.PushFilter == pushFilter) {
                Cursor.SetCursor(textureSelection.Texture, Offset, CursorMode.Auto);
            }
        }
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        WellFilterInputScript.Instance.ChangeFilter += SetNewCursor;
    }


}
