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
                //DownloadPercent프로퍼티로 다운로드 정도를 확인할 수 있음.
                //ex) float DownloadPercent = Handle.PercentComplete;

                Debug.Log("다운로드 완료!");

                //다운로드가 끝나면 메모리 해제.
                Addressables.Release(Handle);

            };
    }

    public void _Click_CheckTheDownloadFileSize()
    {
        //크기를 확인할 번들 또는 번들들에 포함된 레이블을 인자로 주면 됨.
        //long타입으로 반환되는게 특징임.
        Addressables.GetDownloadSizeAsync(LableForBundleDown).Completed +=
            (AsyncOperationHandle<long> SizeHandle) =>
            {
                string sizeText = string.Concat(SizeHandle.Result, " byte");

                SizeText.text = sizeText;

                //메모리 해제.
                Addressables.Release(SizeHandle);
            };
    }
}
