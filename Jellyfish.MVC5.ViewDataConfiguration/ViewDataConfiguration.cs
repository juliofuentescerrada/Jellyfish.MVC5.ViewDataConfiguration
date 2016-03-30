namespace Jellyfish.MVC5.ViewDataConfiguration
{
    using System;
    using System.Web.Mvc;

    public static class ViewDataConfiguration
    {
        public static TConfig GetConfiguration<TConfig>(this ViewDataDictionary viewdata) where TConfig : class, new()
        {
            return viewdata[typeof(TConfig).FullName] as TConfig ?? new TConfig();
        }

        public static void SetConfiguration<TConfig>(this ViewDataDictionary viewdata, TConfig config) where TConfig : class
        {
            viewdata[typeof(TConfig).FullName] = config;
        }

        public static void Configuration<TConfig>(this ViewDataDictionary viewdata, Action<TConfig> setConfig) where TConfig : class, new()
        {
            var config = GetConfiguration<TConfig>(viewdata);
            setConfig(config);
            SetConfiguration(viewdata, config);
        }

        public static TValue Configuration<TConfig, TValue>(this ViewDataDictionary viewdata, Func<TConfig, TValue> getConfig) where TConfig : class, new()
        {
            var config = GetConfiguration<TConfig>(viewdata);
            return getConfig(config);
        }
    }
}
