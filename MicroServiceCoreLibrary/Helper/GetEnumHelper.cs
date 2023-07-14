#region SonarLint Disabled 放置區域
#pragma warning disable S1118
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S1118   Add a 'protected' constructor or the 'static' keyword to the class declaration.	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	46	作用中
#pragma warning disable S3928
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S3928   Use a constructor overloads that allows a more meaningful exception message to be provided.MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs  78	作用中
#pragma warning disable S2971
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S2971   Drop 'Where' and move the condition into the 'SingleOrDefault'.	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	90	作用中
#pragma warning disable CS8600
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS8600  正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	64	作用中
#pragma warning disable CS8603
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS8603  可能有 Null 參考傳回。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	46	作用中
#pragma warning disable IDE0019 // 使用模式比對
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using System.ComponentModel;
using System.Reflection;

namespace MicroServiceCoreLibrary.Helper
{
    /// <summary>
    /// GetEnumHelper
    /// </summary>
    public class GetEnumHelper
    {
        /// <summary>
        /// Get
        /// </summary>
        public static class Get
        {
            /// <summary>
            /// Gets the description from enum value.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns></returns>
            public static string GetDescriptionFromEnumValue(Enum value)
            {
                DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }

            /// <summary>
            /// Gets the enum value from description.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="description">The description.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentException"></exception>
            public static T GetEnumValueFromDescription<T>(string description)
            {
                var type = typeof(T);
                if (!type.IsEnum)
                    throw new ArgumentException();
                FieldInfo[] fields = type.GetFields();
                var field = fields
                                .SelectMany(f => f.GetCustomAttributes(
                                    typeof(DescriptionAttribute), false), (
                                        f, a) => new { Field = f, Att = a })
                                .Where(a => ((DescriptionAttribute)a.Att)
                                    .Description == description).SingleOrDefault();
                return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
            }
        }
    }
}