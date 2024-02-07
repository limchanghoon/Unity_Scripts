using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.UI;

public class DownloadContent : MonoBehaviour
{
    [SerializeField] string LableForBundleDown = string.Empty;
    [SerializeField] TextMeshProUGUI SizeText;
    [SerializeField] Button downloadButton;

    private void Start()
    {
        _Click_CheckTheDownloadFileSize();
    }

    public void _Click_BundleDown()
    {
        Addressables.DownloadDependenciesAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle Handle) =>
            {
                //DownloadPercent������Ƽ�� �ٿ�ε� ������ Ȯ���� �� ����.
                //ex) float DownloadPercent = Handle.PercentComplete;

                Debug.Log("�ٿ�ε� �Ϸ�!");

                //�ٿ�ε尡 ������ �޸� ����.
                Addressables.Release(Handle);

            };
    }

    public void _Click_CheckTheDownloadFileSize()
    {
        //ũ�⸦ Ȯ���� ���� �Ǵ� ����鿡 ���Ե� ���̺��� ���ڷ� �ָ� ��.
        //longŸ������ ��ȯ�Ǵ°� Ư¡��.
        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle<long> SizeHandle) =>
            {
                string sizeText = string.Concat(SizeHandle.Result, " byte");

                SizeText.text = sizeText;

                //�޸� ����.
                Addressables.Release(SizeHandle);
            };
    }
}
