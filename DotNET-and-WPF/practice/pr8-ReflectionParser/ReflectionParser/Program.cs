using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionParser
{
    class Program
    {
        static void Main(string[] args)
        {
            MinMaxTry();

            Console.WriteLine(GetDisplayString(ObjectState.Active));
            Console.WriteLine(GetDisplayString(ObjectState.Hidden));
            Console.WriteLine(GetDisplayString(ObjectState.RemovedObject));
        }

        public static string GetDisplayString(ObjectState state)
        {
            Type type = typeof(ObjectState);
            FieldInfo fieldInfo = type.GetField(state.ToString());
            Attribute attr = fieldInfo.GetCustomAttribute(typeof(EnumDisplayStringAttribute));
            var dispAttr = (EnumDisplayStringAttribute)attr;

            if (dispAttr == null)
            {
                return state.ToString();
            }

            return dispAttr.DisplayString;
        }

        [Obsolete("use another method")]
        static void MinMaxTry()
        {
            var intArr = new []
            {
                1,2,3,4,5,6,7,8,9
            };

            int min, max;
            intArr.MinMax(out min, out max);
        }

        static void EnumTry()
        {
            var obj = new ObjectDescription();
            obj.State = ObjectState.Closed;
            obj.State = ObjectState.Active;
            obj.State = ObjectState.RemovedObject;
            //obj.State = ObjectState.Super;

            obj.IntState = 100000000;
            obj.StrState = "this is wrong state";

            if (obj.State == ObjectState.Active)
            {
                //
            }
            else if (obj.State == ObjectState.Closed)
            {
                //
            }
            else if (obj.State == ObjectState.Hidden)
            {
                //
            }
            else if (obj.State == ObjectState.RemovedObject)
            {
                //
            }
            else
            {

            }

            switch (obj.State)
            {
                case ObjectState.Active:
                    //
                    break;
                case ObjectState.Closed:
                    //
                    break;
                //case ObjectState.Hidden:
                //    //
                //    break;
                //case ObjectState.Removed:
                //    //
                //    break;
                default:
                    //
                    break;
            }
        }
    }
}
