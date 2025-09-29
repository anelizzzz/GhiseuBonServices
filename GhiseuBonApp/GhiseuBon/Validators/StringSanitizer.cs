namespace GhiseuBon.Validators;

public static class StringSanitizer
{
    public static void TrimAllStrings<T>(T obj, params string[] excludeProperties)
    {
        if (obj == null) return;

        var stringProperties = typeof(T)
            .GetProperties()
            .Where(p => p.PropertyType == typeof(string)
                        && p.CanRead
                        && p.CanWrite
                        && !excludeProperties.Contains(p.Name));

        foreach (var prop in stringProperties)
        {
            var value = (string)prop.GetValue(obj);
            if (value != null)
            {
                prop.SetValue(obj, value.Trim());
            }
        }
    }
}
