using Microsoft.Extensions.Configuration;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// ConfigurationProviderExtensionsHelper
    /// </summary>
    public static class ConfigurationProviderExtensionsHelper
    {
        /// <summary>
        /// Gets the full key names.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="rootKey">The root key.</param>
        /// <param name="initialKeys">The initial keys.</param>
        /// <returns></returns>
        public static HashSet<string> GetFullKeyNames(this IConfigurationProvider provider, string rootKey, HashSet<string> initialKeys)
        {
            foreach (var key in provider.GetChildKeys(Enumerable.Empty<string>(), rootKey))
            {
                string surrogateKey = key;
                if (rootKey != null)
                {
                    surrogateKey = rootKey + ":" + key;
                }

                GetFullKeyNames(provider, surrogateKey, initialKeys);

                if (!initialKeys.Any(k => k.StartsWith(surrogateKey)))
                {
                    initialKeys.Add(surrogateKey);
                }
            }

            return initialKeys;
        }
    }
}