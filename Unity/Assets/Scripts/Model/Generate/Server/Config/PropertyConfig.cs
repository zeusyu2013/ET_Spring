using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class PropertyConfigCategory : Singleton<PropertyConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, PropertyConfig> dict = new();
		
        public void Merge(object o)
        {
            PropertyConfigCategory s = o as PropertyConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public PropertyConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PropertyConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PropertyConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PropertyConfig> GetAll()
        {
            return this.dict;
        }

        public PropertyConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class PropertyConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }

	}
}
