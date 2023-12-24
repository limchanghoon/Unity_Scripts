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

        // ���� �˻�
        if (!response.IsSuccessStatusCode)
        {
            Debug.LogError($"�������� ������ ��ȯ�߽��ϴ�. ��ȯ�ڵ� = {response.StatusCode}");
            return;
        }

        string content = await response.Content.ReadAsStringAsync();
        Debug.Log(content);

    }
}
