using System;
using System.Collections.Generic;

namespace BlazeSDK.Tools.JsonMini
{
    public class JsonData
    {
		public JsonData()
		{
			type = JsonType.None;
			data = null;
		}

        public JsonData(object obj)
		{
			if (obj is int) type = JsonType.Int;
			else if (obj is bool) type = JsonType.Boolean;
			else if (obj is double || obj is float) type = JsonType.Double;
			else if (obj is string) type = JsonType.String;
			else if (obj is Dictionary<string, JsonData>) type = JsonType.Array;
			else type = JsonType.Object;
			data = obj;
		}
		public JsonData(JsonType jsonType, object obj)
		{
			type = jsonType;
			data = obj;
		}

		public T ReadData<T>() => (T)data;

		public JsonType type;
        public object data;
    }
}
