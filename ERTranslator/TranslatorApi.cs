using System;
using System.IO;
using System.Windows;
using System.Net;
using Newtonsoft.Json;

namespace ERTranslator
{
    class TranslatorApi
    {
        public string Translate(string originaltext, bool direction)
        {
            string lang;
            if (direction) lang = "en-ru";
            else lang = "ru-en";
            string text = originaltext;
            Translation translation = null;
            WebResponse response = null;
            string translatedtext = null;
            if (originaltext.Length > 0)
            {
                try
                {
                    WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                   + "key=trnsl.1.1.20180214T173150Z.85867f8aecd48b3d.34e0c2390edf4ffba1dd9fdde792fc2e901de05b"
                   + "&text=" + originaltext
                   + "&lang=" + lang);

                    response = request.GetResponse();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        translation = JsonConvert.DeserializeObject<Translation>(line);
                        translatedtext = "";
                        translatedtext = translation.text[0];
                    }
                }             
            }
            return translatedtext;
        }
    }
}
