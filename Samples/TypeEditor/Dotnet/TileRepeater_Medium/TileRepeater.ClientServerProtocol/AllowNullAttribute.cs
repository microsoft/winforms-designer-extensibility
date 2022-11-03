#if NETFRAMEWORK
namespace System.Diagnostics.CodeAnalysis
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Parameter | System.AttributeTargets.Property, Inherited = false)]
    public class AllowNullAttribute : Attribute
    { }

}
#endif
