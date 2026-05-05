using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OS.Scheduling.UI
{
    public class GanttChartRenderer : MonoBehaviour
    {
        [SerializeField] private RectTransform content;
        [SerializeField] private GanttBar barPrefab;
        //[SerializeField] private TMP_Text titleText;
        [SerializeField] private float pixelsPerTimeUnit = 60f;
        [SerializeField] private float barHeight = 48f;

        private readonly List<GanttBar> bars = new();

        public void Render(SchedulingResult result)
        {
            Clear();

            var colorMap = new Dictionary<int, Color>();
            int index = 0;

            foreach (var segment in result.Segments)
            {
                var bar = Instantiate(barPrefab, content);
                bars.Add(bar);

                if (!colorMap.TryGetValue(segment.Pid, out var color))
                {
                    color = GenerateColor(index++);
                    colorMap[segment.Pid] = color;
                }

                bar.Bind(segment, color);

                var rt = bar.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(0, 1);
                rt.anchorMax = new Vector2(0, 1);
                rt.pivot = new Vector2(0, 1);

                float x = segment.StartTime * pixelsPerTimeUnit;
                float w = segment.Duration * pixelsPerTimeUnit;
                float y = 0f;

                rt.anchoredPosition = new Vector2(x, y);
                rt.sizeDelta = new Vector2(w, barHeight);
            }

            var rect = content as RectTransform;
            if (rect != null)
                LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
        }

        private void Clear()
        {
            for (int i = content.childCount - 1; i >= 0; i--)
                Destroy(content.GetChild(i).gameObject);

            bars.Clear();
        }

        private Color GenerateColor(int index)
        {
            float hue = (index * 0.17f) % 1f;
            return Color.HSVToRGB(hue, 0.65f, 0.9f);
        }
    }
}
