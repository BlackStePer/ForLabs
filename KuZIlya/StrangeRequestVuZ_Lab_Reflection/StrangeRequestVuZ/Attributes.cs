namespace StrangeRequestVuZ
{
    /// <summary>
    /// Нельзя сравнивать и читать
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property)]
    internal class NotComparableAttribute : Attribute { }
    /// <summary>
    /// Нельзя читать
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property)]
    internal class UnreadableAttribute : Attribute { }
}
