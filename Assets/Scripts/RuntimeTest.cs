using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace ReadyPlayerMe
{
    public class RuntimeTest : MonoBehaviour
    {
        string avatarText;

        public GameObject parent;

        private DancingScript DScript;
        private FollowPlayer FPlayer;
        private SetPosition setPos;

        public void Awake()
        {
            Debug.Log($"Started loading avatar. [{Time.timeSinceLevelLoad:F2}]");
            
            avatarText = PlayerPrefs.GetString("link");
            AvatarLoader avatarLoader = new AvatarLoader();
            avatarLoader.LoadAvatar(avatarText, OnAvatarImported, OnAvatarLoaded);

            DScript = parent.GetComponent<DancingScript>();
            FPlayer = parent.GetComponent<FollowPlayer>();
        }

       
        public void OnAvatarImported(GameObject avatar)
        {
            Debug.Log($"Avatar imported. [{Time.timeSinceLevelLoad:F2}]");
        }

        public void OnAvatarLoaded(GameObject avatar, AvatarMetaData metaData)
        {
            Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");

            avatar.transform.parent = parent.transform;
            avatar.AddComponent<DancingScript>();
            avatar.AddComponent<SetPosition>();

            DScript.enabled = false;
            FPlayer.enabled = true;

        }    
    }
}
