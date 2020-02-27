using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UIContactsApp.Helpers
{
    public static class ExtensionMethod
    {
        public static bool IsEmptyString(this string value)
        {
            return string.IsNullOrEmpty(value) ? false : true; 
        }
        public static string[] IsSeparatorString(this string value)
        {
            return value.Split('*');
        }
        public static int RadomNumber(this int value)
        {
            var radom = new Random();

            return radom.Next(0, value);
        }
        public static string FirtsLetter(this string value)
        {
            value = value.ToUpper();
            return $"{value[0]}.png";
        }
        public static async void SafeFireAndForget(this Task task,bool returnToCallingContext, Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
