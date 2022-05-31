// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class Scene_Manager : MonoBehaviour
// {

//    public static Scene_Manager Instance;

//    [SerializeField] private GameObject _loadercanves;
//    [SerializeField] private Image progeressbar;
//    private float target;


//    private void Awake() 
//    {
//        if(Instance == null){
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else{
//            Destroy(gameObject);
//        }
       
//    }

//    public void LoadScene(string SceneName) {
       
//        target = 0;
//        progeressbar.fillAmount = 0;

//        var scene = SceneManager.LoadSceneAsync(1);
//        scene.allowSceneActivation = false;

//        _loadercanves.SetActive(true);

//        do
//        {
//         target = scene.progress;   
//        } while (scene.progress < 0.9f);

//     scene.allowSceneActivation = true;
//      _loadercanves.SetActive(false);


//    }
//     private void Update() {
//      progeressbar.fillAmount = Mathf.MoveTowards(progeressbar.fillAmount, target, 3 * Time.deltaTime);  
//    }
   
// }
