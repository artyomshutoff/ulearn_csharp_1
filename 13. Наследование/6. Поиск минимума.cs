static object
Min(Array list)
{
    Array.Sort(list);
    return list.GetValue(0);
}