using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    public class BaseClass<T> :  ICloneable<T> where T : new()
    {
        //public object Clone()
        //{
                        
        //    object obj = Activator.CreateInstance(this.GetType());            

        //    foreach (var field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        //    {
        //        var val = field.GetValue(this);
        //        field.SetValue(obj, val);
        //    }           

        //    return obj;
        //}

        public T Clone()
        {
            T obj = new T();

            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var val = field.GetValue(this);
                field.SetValue(obj, val);
            }
            return obj;
        }
    }


}
