using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Newtonsoft.Json;
using RestSharp;
using w.beams.visualization.Models;
using w.beams.visualization.Properties;

namespace w.beams.visualization.Helpers
{
    public static class BeamJsonHelper
    {
        private static string JsonPath => Settings.Default.BeamJsonPath;

        /// <summary>
        /// Deserializes beam.json into a collection of Beam
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Beam> BeamCollectionFromJson()
        {
            try
            {
                // From an API
                var restclient = new RestClient { BaseUrl = new Uri("https://api.myjson.com/bins/md81i") };
                var request = new RestRequest("", Method.GET);

                IRestResponse response = restclient.Execute<List<Beam>>(request);
                if (!response.IsSuccessful)
                {
                    return new ObservableCollection<Beam>();
                }

                var json = response.Content;

                var collection = JsonConvert.DeserializeObject<ObservableCollection<Beam>>(json);
                return collection;

                // From local resource
                //var json = File.ReadAllText(JsonPath);
                //return new ObservableCollection<Beam>(JsonConvert.DeserializeObject<Beam[]>(json));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while trying to deserialize json.\n\n" + ex.Message);
            }
            return new ObservableCollection<Beam>();
        }
    }
}
