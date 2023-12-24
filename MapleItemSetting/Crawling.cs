using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class Crawling : MonoBehaviour
{
    private void Start()
    {
        Crawl();
    }

    public async void Crawl()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://maplestory.nexon.com/Guide/OtherProbability/cube/red");

        // 오류 검사
        if (!response.IsSuccessStatusCode)
        {
            Debug.LogError($"서버에서 오류를 반환했습니다. 반환코드 = {response.StatusCode}");
            return;
        }

        string content = await response.Content.ReadAsStringAsync();
        Debug.Log(content);

    }
}
