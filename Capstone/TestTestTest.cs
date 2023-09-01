using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTestTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            DialogController.Instance.ShowDialog("테스트 테스토 테스테스");
        }
    }
}
