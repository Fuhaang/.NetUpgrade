using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustPrice
{
    public class Tools
    {

        public const string path = @"D:\INFO\CSharp\Apprentissage\JustPrice\Items.txt";

        public bool InitData(List<Items> item)
        {
            // Transform code of JSON
            string json = JsonConvert.SerializeObject(item);

            // Write on .txt
            //System.IO.File.AppendAllText(path, json);
            System.IO.File.WriteAllText(path, json);

            return true;
        }

        public Items GetData()
        {
            var json = System.IO.File.ReadAllText(path);

            // Transform JSON on C#
            Items item = JsonConvert.DeserializeObject<Items>(json);



            return item;
        }

        public List<Items> GetDataList()
        {
            var json = System.IO.File.ReadAllText(path);

            // Transform JSON on C#
            List<Items> listItems = JsonConvert.DeserializeObject<List<Items>>(json);


            return listItems;
        }

    }
}
