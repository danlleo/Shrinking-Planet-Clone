public static class MathUtils
{
    #region NormalizeValue

    public static float NormalizeValue(float value, float min, float max) => (value - min) / (max - min);

    public static float NormalizeValue(int value, int min, int max) => (float)(value - min) / (max - min);

    public static double NormalizeValue(double value, double min, double max) => (value - min) / (max - min);

    #endregion
}
