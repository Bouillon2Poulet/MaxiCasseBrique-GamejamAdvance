using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_manager : MonoBehaviour
{

    public enum prefabs {casse_brique, alarme, couteau, harambe, miamo, poisson, tasse, voiture, appel};
    public GameObject[] windows_prefabs; // casse brique est le premier élément
    public GameObject[] logos_prefabs;

    public Transform start_pos_logo;

    

    public float offset_logo = 1f;
    private bool has_harambe = false;


    private List<GameObject> windows_on_screen; // in order of display
    private List<GameObject> logos_on_screen; // in order of display
    private int higher_layer;

    private List<KeyCode> myKeys;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generate_random_window", 5.0f, 3f);


        windows_on_screen = new List<GameObject>();
        logos_on_screen = new List<GameObject>();

        create_window(prefabs.casse_brique, Vector3.zero);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        check_logo_remove();
        if (GetComponentInChildren<brick_game_manager>().actual_game_state ==brick_game_manager.game_state.win)
        {
            destroy_all_popup();
        }


        if (windows_on_screen[0] == null) {
            windows_on_screen[0] = Instantiate(get_window_prefab(prefabs.casse_brique), Vector3.zero, new Quaternion(0f,0f,0f,0f));
        }

       

        has_harambe = GetComponentInChildren<harambe_game>() !=null;
        
    }

    GameObject get_window_prefab(prefabs name){
        return windows_prefabs[((int)name)];
    }
    GameObject get_logo_prefab(prefabs name){
        return logos_prefabs[((int)name)];
    }
    
    void set_ordering_layer(int i, GameObject go) { // i = position in screen/taskbar
    foreach(SpriteRenderer spr in go.GetComponentsInChildren<SpriteRenderer>()) spr.sortingOrder+=10*i;
    }


    void create_window(prefabs name, Vector3 position){
        if (name == prefabs.harambe) has_harambe = true;

        GameObject new_go = Instantiate(get_window_prefab(name),position,new Quaternion(0f,0f,0f,0f),transform); // create the object
        set_ordering_layer(windows_on_screen.Count, new_go);
        windows_on_screen.Add(new_go);
        

        GameObject new_logo_go = Instantiate(get_logo_prefab(name),position_in_task_bar(logos_on_screen.Count),new Quaternion(0f,0f,0f,0f),start_pos_logo); // create the object

        logos_on_screen.Add(new_logo_go);
    
    }

    Vector3 position_in_task_bar(int i){
        return start_pos_logo.position + new Vector3(i*offset_logo,0f,0f);
    }

    void check_logo_remove() {
        for (int i=1; i<windows_on_screen.Count; i++) {
            if (!windows_on_screen[i]) {
                Destroy(logos_on_screen[i]);
                for (int j=i; j<windows_on_screen.Count-1; j++) {
                    windows_on_screen[j] = windows_on_screen[j+1];
                    logos_on_screen[j] = logos_on_screen[j+1];
                    logos_on_screen[j].transform.Translate(Vector3.right*(-offset_logo));
                    set_ordering_layer(j, windows_on_screen[j]);
                }
            // Destroy(windows_on_screen[windows_on_screen.Count-1]);
            // Destroy(logos_on_screen[logos_on_screen.Count-1]);
            windows_on_screen.RemoveAt(windows_on_screen.Count-1);
            logos_on_screen.RemoveAt(logos_on_screen.Count-1);
            }
        }
    }

    void generate_random_window() {
        brick_game_manager bgm = GetComponentInChildren<brick_game_manager>();
        if(!bgm) return;
        if (bgm.actual_game_state != brick_game_manager.game_state.game) return;

        int type = (int) Random.Range(1, prefabs.GetNames(typeof(prefabs)).Length);
        
        while ((prefabs)type == prefabs.harambe && has_harambe){
            type = (int) Random.Range(1, prefabs.GetNames(typeof(prefabs)).Length);
        }   // repull while u pull a second harambe


        float x = Random.Range(-5,5);
        float y = Random.Range(-5,4);

        create_window((prefabs)(type), new Vector3(x,y,0f));

    }

    public void destroy_all_popup(){
        for (int i = 0; i< transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            if(go.name != "Brick_game(Clone)" && go.name !="start_pos_of_logos") Destroy(go);
        }
        if(windows_on_screen.Count >= 2){
            windows_on_screen.RemoveRange(1,windows_on_screen.Count-2);
            logos_on_screen.RemoveRange(1,windows_on_screen.Count-2);
        }

    }
}


