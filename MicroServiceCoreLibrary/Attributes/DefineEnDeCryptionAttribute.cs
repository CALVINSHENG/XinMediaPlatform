namespace MicroServiceCoreLibrary.Attributes
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// 加解密相關屬性
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class NeedEnDeCryptDefinAttribute : Attribute
    {
        /// <summary>
        /// The needendecryptdefin
        /// The _alias.
        /// </summary>
        private readonly bool _needendecryptdefin;

        /// <summary>
        /// Gets a value indicating whether [need en de crypt defin].
        /// Gets the alias.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [need en de crypt defin]; otherwise, <c>false</c>.
        /// </value>
        public bool NeedEnDeCryptDefin
        {
            get
            {
                return _needendecryptdefin;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NeedEnDeCryptDefinAttribute"/> class.
        /// </summary>
        /// <param name="alias">if set to <c>true</c> [alias].</param>
        public NeedEnDeCryptDefinAttribute(bool alias)
        {
            _needendecryptdefin = alias;
        }

        /// <summary>
        /// Gets the single de crypt defin.
        /// 取得特性的定義值
        /// </summary>
        /// <returns></returns>
        public bool GetSingleDeCryptDefin()
        {
            return _needendecryptdefin;
        }
    }
}
