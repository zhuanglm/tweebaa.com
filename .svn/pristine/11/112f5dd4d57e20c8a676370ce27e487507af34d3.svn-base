using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Newtonsoft.Json;
using System.Collections;
using System.Web.Script.Serialization;

namespace Twee.Comm
{
    public class Json : DynamicObject
    {
        private IDictionary<string, object> Dictionary;

        public Json(IDictionary<string, object> dictionary)
        {
            this.Dictionary = dictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this.Dictionary[binder.Name];

            if (result is IDictionary<string, object>)
            {
                this.Dictionary[binder.Name] = result = new Json(result as IDictionary<string, object>);
            }
            else if (result is IEnumerable && !(result is string))
            {
                var list = new List<object>();
                foreach (var i in (result as IEnumerable))
                {
                    if (i is IDictionary<string, object>)
                        list.Add(new Json(i as IDictionary<string, object>));
                    else
                        list.Add(i);
                }
                this.Dictionary[binder.Name] = result = list;
            }

            return true;
        }

        static readonly JavaScriptSerializer jss = new JavaScriptSerializer();

        public static dynamic Deserialize(string json)
        {
            return new Json(jss.Deserialize(json, typeof(object)) as IDictionary<string, object>);
        }

        public static string Serialize(object obj)
        {
            return jss.Serialize(obj);
        }
    }
}
