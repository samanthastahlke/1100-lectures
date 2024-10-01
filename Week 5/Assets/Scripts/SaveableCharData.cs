using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

/* OK Y'ALL LISTEN UP
 * 
 * This is one of those kind of hacky scripts thrown together by a teacher
 * with not-really-enough time on their hands who wants to provide a good in-class 
 * experience in a timely manner, but without making you write egregiously stupid 
 * code in class. 
 * 
 * Unfortunately, sometimes Unity makes *me* write egregiously stupid code.
 * 
 * If you would like to ask me about why exactly this code is bad, or complain
 * (justifiably) about how bad this code is, please message me.
 * 
 * Google "Unity built in serialize dictionary" if you want to feel true pain.
 * 
 * Also, if you think you'll need to save and load fairly complex data in your
 * own projects, you'll want to look into external libraries/plugins (or building
 * your own parser). I included a couple of leads on that in the Week 5 slides.
 * 
 */

[System.Serializable]
public class SaveableCharData<T> where T : struct, System.IConvertible
{
    //Quick and dirty Dictionary wrapper since Unity is stuck in 1998.
    [System.Serializable]
    private class SerializableDictionary<TKey, TValue>
    {
        [System.Serializable]
        public class Item
        {
            public TKey key;
            public TValue value;
            
            public Item(TKey _key, TValue _value)
            {
                key = _key;
                value = _value;
            }
        }

        [SerializeField]
        private List<Item> items;

        public SerializableDictionary(Dictionary<TKey, TValue> dict)
        {
            //This is certainly not the most robust type checking,
            //but it'll do for this.
            if (!typeof(TKey).IsSerializable || !typeof(TValue).IsSerializable)
                throw new SerializationException("Non-serializable key/value type specified!");

            items = new List<Item>(dict.Count);

            foreach (var item in dict)
            {
                items.Add(new Item(item.Key, item.Value));
            }
        }

        public void DeserializeTo(Dictionary<TKey, TValue> dict)
        {
            dict.Clear();

            foreach(var item in items)
            {
                dict.Add(item.key, item.value);
            }
        }
    }

    [SerializeField]
    private string charName;

    [SerializeField]
    private SerializableDictionary<T, int> stats;

    public SaveableCharData(string _charName, Dictionary<T, int> _stats)
    {
        charName = _charName;
        stats = new(_stats);
    }

    public void LoadInto(ref string _charName, Dictionary<T, int> _stats)
    {
        _charName = charName;
        stats.DeserializeTo(_stats);
    }
}
