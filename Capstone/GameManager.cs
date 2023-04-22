using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Slider hpBar;
    public TextMeshProUGUI bullet_text;
    public Camera main_camera;
    public Camera ui_camera;
    public List<Transform> targets = new List<Transform>();
}
