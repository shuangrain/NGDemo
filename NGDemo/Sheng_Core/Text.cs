using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using AutoMapper;

namespace Sheng_Core
{
    public static class Text
    {

        #region 讀取Config中AppSettings字串

        /// <summary>
        /// 讀取Config中AppSettings字段
        /// </summary>
        /// <param name="ParameterName">參數名稱</param>    
        /// <returns>參數值</returns>
        public static string GetConfigAppParm(string ParameterName)
        {
            return (ConfigurationManager.AppSettings[ParameterName]);
        }

        /// <summary>
        /// 讀取Config中ConnectionString字段
        /// </summary>
        /// <param name="ParameterName">參數名稱</param>    
        /// <returns>參數值</returns>
        public static string GetConfigConParm(string ParameterName)
        {
            return (ConfigurationManager.ConnectionStrings[ParameterName].ConnectionString);
        }

        #endregion

        #region 複製Model

        /// <summary>
        /// 鏡像模型
        /// </summary>
        /// <typeparam name="TModel">原模型</typeparam>
        /// <typeparam name="TResponse">新模型</typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TResponse CopyModel<TModel, TResponse>(TModel model)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<TModel, TResponse>().IgnoreAllNonExisting();
            });
            Mapper.Configuration.AssertConfigurationIsValid();

            var converted = Mapper.Map<TResponse>(model);
            return converted;
        }

        /// <summary>
        /// 忽略沒有的欄位
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }

        #endregion
    }
}
