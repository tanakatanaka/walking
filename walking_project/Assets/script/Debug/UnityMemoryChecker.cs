using UnityEngine.Profiling;

public sealed class UnityMemoryChecker
{
    public float Used { get; private set; }
    public float Unused { get; private set; }
    public float Total { get; private set; }

    public string UsedText { get; private set; }
    public string UnusedText { get; private set; }
    public string TotalText { get; private set; }

    public void Update()
    {
        // Unity �ɂ���Ċ��蓖�Ă�ꂽ������
        Used = (Profiler.GetTotalAllocatedMemoryLong() >> 10) / 1024f;

        // �\��ς݂������蓖�Ă��Ă��Ȃ�������
        Unused = (Profiler.GetTotalUnusedReservedMemoryLong() >> 10) / 1024f;

        // Unity �����݂���я����̊��蓖�Ă̂��߂Ɋm�ۂ��Ă��鑍������
        Total = (Profiler.GetTotalReservedMemoryLong() >> 10) / 1024f;

        UsedText = Used.ToString("0.0") + " MB";
        UnusedText = Unused.ToString("0.0") + " MB";
        TotalText = Total.ToString("0.0") + " MB";
    }
}