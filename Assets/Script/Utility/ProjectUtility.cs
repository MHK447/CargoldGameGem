using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BanpoFri;
using System.Linq;


public class ProjectUtility 
{

    private static string str_seconds;
    private static string str_minute;
    private static string str_hour;
    private static string str_day;

    public static void SetActiveCheck(GameObject target, bool value)
    {
        if (target != null)
        {
            if (value && !target.activeSelf)
                target.SetActive(true);
            else if (!value && target.activeSelf)
                target.SetActive(false);
        }
    }

    public static System.Numerics.BigInteger FibonacciDynamic(int n)
    {
        if (n <= 1)
            return n;

        System.Numerics.BigInteger[] fib = new System.Numerics.BigInteger[n + 1];
        fib[0] = 0;
        fib[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }
        return fib[n];
    }

    private static char[] NumberChar =
    {
            'a','b','c','d','e','f','g','h','i','j','k',
            'l','m','n','o','p','q','r','s','t','u','v',
            'w','x','y','z'
        };

    public static string CalculateMoneyToString(System.Numerics.BigInteger _Long)
    {
        var targetString = _Long.ToString();
        var targetLen = targetString.Length - 1;
        if (targetLen == 0)
            targetLen = 1;
        var front = targetLen / 3;
        var back = targetLen % 3;
        if (front == 0)
        {
            return _Long.ToString();
        }
        var top = targetString.Substring(0, back + 1);
        var top_back = targetString.Substring(back + 1, 1);
        var top_back2 = targetString.Substring(back + 2, 1);

        var front_copy = front;
        if (front > 1378) // 26 + 26 * 26 + 26 * 26 + 26 * 26
        {
            front_copy = front_copy - 1378;
        }
        else if (front > 702) // 26 + 26 * 26
        {
            front_copy = front_copy - 702;
        }
        else if (front > 26)
        {
            front_copy = front_copy - 26;
        }

        var front_front = front_copy / 26;
        var front_second = front_copy % 26;

        char secondChar;
        if (front_second == 0)
        {
            secondChar = 'z';
            front_front = front_front - 1;
        }
        else if (front_second > 0 && front_second < 26)
            secondChar = NumberChar[front_second - 1];
        else
            secondChar = (char)0;

        char frontChar;
        if (front_front == 26)
            frontChar = 'z';
        else if (front_front >= 0 && front_front <= 26)
            frontChar = NumberChar[front_front];
        else
            frontChar = (char)0;

        string final_numTostr = string.Empty;

        if (front > 1378) // 26 + 26 * 26 + 26 * 26 + 26 * 26
            final_numTostr = $"{char.ToUpper(frontChar)}{char.ToUpper(secondChar)}";
        else if (front > 702) // 26 + 26 * 26 + 26 * 26 + 26 * 26
            final_numTostr = $"{char.ToUpper(frontChar)}{secondChar}";
        else if (front > 26)
            final_numTostr = $"{frontChar}{secondChar}";
        else
            final_numTostr = $"{secondChar}";

        if (top_back == "0" && top_back2 != "0")
            return string.Format("{0}.{1}{2}{3}", top, top_back, top_back2, final_numTostr);
        else if (top_back == "0" && top_back2 == "0")
            return string.Format("{0}{1}", top, final_numTostr);
        else if (top_back != "0" && top_back2 == "0")
            return string.Format("{0}.{1}{2}", top, top_back, final_numTostr);
        else
            return string.Format("{0}.{1}{2}{3}", top, top_back, top_back2, final_numTostr);

    }

    public static int GetOutGameGachaGrade()
    {
        float total = 0;

        int totalratio = 0;

        List<int> gacharatiolist = new List<int>();

        var tdlist = Tables.Instance.GetTable<OutGameGachaGradeInfo>().DataList.ToList();
            
        foreach (var td in tdlist)
        {
            totalratio += td.ratio;

            gacharatiolist.Add(td.ratio);
        }

        float randomPoint = UnityEngine.Random.Range(0, totalratio);

        for (int i = 0; i < gacharatiolist.Count; i++)
        {
            total += gacharatiolist[i];
            if (randomPoint <= total)
            {
                return tdlist[i].grade;
            }
        }

        return 1;
    }
    public static int GetRandGachaCard(int level)
    {

        int randgrade = 1;

        var td = Tables.Instance.GetTable<UnitGradeInfo>().GetData(level);

        int totalgacharatio = 0;

        if(td != null)
        {
            for(int i = 0; i < td.gradepercent.Count; ++i)
            {
                totalgacharatio += td.gradepercent[i];
            }


            var randgacha = UnityEngine.Random.Range(0, totalgacharatio + 1);
            int cumulativevalue = 0;

            for (int i = 0; i < td.gradepercent.Count; ++i)
            {
                cumulativevalue += td.gradepercent[i];

                if(randgacha < cumulativevalue)
                {
                    return i + 1;
                }

            }


        }

        return randgrade;
    }


    public static float GetPercentValue(float value , float percent)
    {
        float returnvalue = 0f;

        returnvalue = (value * percent) / 100f;


        return returnvalue;
    }
    public static string GetTimeStringFormattingShort(int seconds)
    {
        str_seconds = Tables.Instance.GetTable<Localize>().GetString("str_time_second");
        str_minute = Tables.Instance.GetTable<Localize>().GetString("str_time_minute");
        str_hour = Tables.Instance.GetTable<Localize>().GetString("str_time_hour");
        str_day = Tables.Instance.GetTable<Localize>().GetString("str_time_day");

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        var cnt = 0;
        var time = new TimeSpan(0, 0, seconds);
        if (time.Days > 0)
        {
            sb.Append(time.Days.ToString());
            sb.Append(str_day);
            ++cnt;
        }
        if (time.Hours > 0)
        {
            if (cnt > 0)
                sb.Append(" ");
            sb.Append(time.Hours.ToString());
            sb.Append(str_hour);

            ++cnt;
        }
        if (time.Minutes > 0 && cnt < 2)
        {
            if (cnt > 0)
                sb.Append(" ");
            sb.Append(time.Minutes.ToString());
            sb.Append(str_minute);
            ++cnt;
        }
        if (time.Seconds >= 0 && cnt < 2)
        {
            if (cnt > 0)
                sb.Append(" ");
            sb.Append(time.Seconds.ToString());
            sb.Append(str_seconds);
            ++cnt;
        }
        return sb.ToString();
    }


}


public static class ScrollViewFocusFunctions
{
    public static Vector2 CalculateFocusedScrollPosition(this ScrollRect scrollView, Vector2 focusPoint)
    {
        Vector2 contentSize = scrollView.content.rect.size;
        Vector2 viewportSize = ((RectTransform)scrollView.content.parent).rect.size;
        Vector2 contentScale = scrollView.content.localScale;

        contentSize.Scale(contentScale);
        focusPoint.Scale(contentScale);

        Vector2 scrollPosition = scrollView.normalizedPosition;
        if (scrollView.horizontal && contentSize.x > viewportSize.x)
            scrollPosition.x = Mathf.Clamp01((focusPoint.x - viewportSize.x * 0.5f) / (contentSize.x - viewportSize.x));
        if (scrollView.vertical && contentSize.y > viewportSize.y)
            scrollPosition.y = Mathf.Clamp01((focusPoint.y - viewportSize.y * 0.5f) / (contentSize.y - viewportSize.y));

        return scrollPosition;
    }

    public static Vector2 CalculateFocusedScrollPosition(this ScrollRect scrollView, RectTransform item)
    {
        Vector2 itemCenterPoint = scrollView.content.InverseTransformPoint(item.transform.TransformPoint(item.rect.center));

        Vector2 contentSizeOffset = scrollView.content.rect.size;
        contentSizeOffset.Scale(scrollView.content.pivot);

        return scrollView.CalculateFocusedScrollPosition(itemCenterPoint + contentSizeOffset);
    }

    public static void FocusAtPoint(this ScrollRect scrollView, Vector2 focusPoint)
    {
        scrollView.normalizedPosition = scrollView.CalculateFocusedScrollPosition(focusPoint);
    }

    public static void FocusOnItem(this ScrollRect scrollView, RectTransform item)
    {
        scrollView.normalizedPosition = scrollView.CalculateFocusedScrollPosition(item);
    }

    private static IEnumerator LerpToScrollPositionCoroutine(this ScrollRect scrollView, Vector2 targetNormalizedPos, float speed , System.Action endaction = null)
    {
        Vector2 initialNormalizedPos = scrollView.normalizedPosition;

        float t = 0f;
        while (t < 1f)
        {
            scrollView.normalizedPosition = Vector2.LerpUnclamped(initialNormalizedPos, targetNormalizedPos, 1f - (1f - t) * (1f - t));

            yield return null;
            t += speed * Time.unscaledDeltaTime;
        }

        scrollView.normalizedPosition = targetNormalizedPos;

        endaction?.Invoke();
    }

    public static IEnumerator FocusAtPointCoroutine(this ScrollRect scrollView, Vector2 focusPoint, float speed)
    {
        yield return scrollView.LerpToScrollPositionCoroutine(scrollView.CalculateFocusedScrollPosition(focusPoint), speed);
    }

    public static IEnumerator FocusOnItemCoroutine(this ScrollRect scrollView, RectTransform item, float speed , System.Action endaction = null)
    {
        yield return scrollView.LerpToScrollPositionCoroutine(scrollView.CalculateFocusedScrollPosition(item), speed , endaction);
    }
    public static IEnumerator FocusOnItemCoroutine(this ScrollRect scrollView, RectTransform item, float speed, Vector2 addPos)
    {
        var pos = scrollView.CalculateFocusedScrollPosition(item);
        pos += addPos;
        yield return scrollView.LerpToScrollPositionCoroutine(pos, speed);
    }

}

