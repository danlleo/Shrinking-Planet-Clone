using System;

public static class MathUtils
{
    #region NormalizeValue

    public static float NormalizeValue(float value, float min, float max) => (value - min) / (max - min);

    public static float NormalizeValue(int value, int min, int max) => (float)(value - min) / (max - min);

    public static double NormalizeValue(double value, double min, double max) => (value - min) / (max - min);

    #endregion

    #region Percents

    public static float AddPercentToValue(float value, float percent)
    {
        percent = Math.Clamp(percent, 0f, 100f);

        return value + (percent / 100) * value;
    }

    public static double AddPercentToValue(double value, double percent)
    {
        percent = Math.Clamp(percent, 0f, 100f);

        return value + (percent / 100) * value;
    }

    public static int AddPercentToValue(int value, int percent)
    {
        percent = Math.Clamp(percent, 0, 100);

        // Perform the multiplication first to avoid rounding down.
        int addedValue = (value * percent) / 100;

        return value + addedValue;
    }

    public static float RemovePercentToValue(float value, float percent)
    {
        percent = Math.Clamp(percent, 0f, 100f);

        return value - (percent / 100) * value;
    }

    public static double RemovePercentToValue(double value, double percent)
    {
        percent = Math.Clamp(percent, 0f, 100f);

        return value - (percent / 100) * value;
    }

    public static int RemovePercentToValue(int value, int percent)
    {
        percent = Math.Clamp(percent, 0, 100);

        return value - (percent / 100) * value;
    }

    #endregion
}
