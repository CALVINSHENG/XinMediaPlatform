#region SonarLint Disabled 放置區域
#pragma warning disable CS8600
#pragma warning disable S112
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using System.Reflection;

namespace MicroServiceCoreLibrary.Attributes.Extensions
{
    /// <summary>
    /// GetEnDeCryptionDefineExtension
    /// </summary>
    public static class GetEnDeCryptionDefineExtension
    {
        /// <summary>
        /// Gets the single en de crypt defin.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static bool GetSingleEnDeCryptDefin(this bool value)
        {
            try
            {
                Type type = value.GetType();
                FieldInfo field = type.GetField(value.ToString());
                if (field.IsDefined(typeof(NeedEnDeCryptDefinAttribute), true))
                {
                    NeedEnDeCryptDefinAttribute attribute = (NeedEnDeCryptDefinAttribute)field.GetCustomAttribute(typeof(NeedEnDeCryptDefinAttribute), true);
                    return attribute.GetSingleDeCryptDefin();
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
