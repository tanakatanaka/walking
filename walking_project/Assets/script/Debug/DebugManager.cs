using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private Text _text;

    private readonly UnityMemoryChecker m_unityMemoryChecker =
        new UnityMemoryChecker();

    private int frameCount;
    private float prevTime;
    private float fps;

    // èâä˙âªèàóù
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    private void Update()
    {
        m_unityMemoryChecker.Update();

        var sb = new StringBuilder();
        sb.AppendLine("<b>Unity</b>");
        sb.AppendLine();
        sb.AppendLine($"    Used: {m_unityMemoryChecker.UsedText}");
        sb.AppendLine($"    Unused: {m_unityMemoryChecker.UnusedText}");
        sb.AppendLine($"    Total: {m_unityMemoryChecker.TotalText}");

        //FPSï\é¶
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;
        fps = frameCount / time;
        sb.AppendLine($"    fps: {fps.ToString()}");

        frameCount = 0;
        prevTime = Time.realtimeSinceStartup;

        var text = sb.ToString();
        _text.text = text;
    }
}