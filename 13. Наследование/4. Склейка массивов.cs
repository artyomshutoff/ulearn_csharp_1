static Array
Combine(params Array[] arrays)
{
    if (arrays.Length == 0)
        return null;
    var type = arrays [0]
                 .GetType()
                 .GetElementType();
    var length = 0;
    foreach (var array in arrays) {
        if (array.GetType().GetElementType() != type)
            return null;
        length += array.Length;
    }

    var result = Array.CreateInstance(type, length);
    var index = 0;
    foreach (var array in arrays)
        foreach (var elem in array)
            result.SetValue(elem, index++);
    return result;
}