namespace homework_7_DelegatesAndEvents.Extensions;

public static class IEnumerableExtensions
{
    /// <summary>
    /// черновой вариант расширения для получения первого наибольшего элемента
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="convertToNumber"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(convertToNumber);

        using var enumerator = collection.GetEnumerator();

        if (!enumerator.MoveNext()) throw new InvalidOperationException($"{nameof(collection)}: Sequence contains no elements");

        T max = enumerator.Current;
        float maxFloat = convertToNumber.Invoke(max);

        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            var itemAsFloat = convertToNumber.Invoke(item);
            if (itemAsFloat > maxFloat)
            {
                maxFloat = itemAsFloat;
                max = item;
            }
        }

        return max;
    }
}
