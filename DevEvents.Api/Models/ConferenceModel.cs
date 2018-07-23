using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevEvents.Api.Models
{
    public class Conference
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("conferenceName")]
        public string ConferenceName { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("prices")]
        public List<PriceEntry> Prices { get; set; }
        
        [JsonProperty("cfpStartDate")]
        public DateTime CfpStartDate { get; set; }
        [JsonProperty("cfpEndDate")]
        public DateTime CfpEndDate { get; set; }
        [JsonProperty("cfpUrl")]
        public string CfpUrl { get; set; }
        [JsonProperty("travelExpenses")]
        public TravelExpenses TravelAndExpenses { get; set; }

        public class PriceEntry
        {
            [JsonProperty("startDate")]
            public DateTime StartDate { get; set; }
            [JsonProperty("endDate")]
            public DateTime EndDate { get; set; }
            [JsonProperty("price")]
            public int Price { get; set; }
        }

        public enum TravelExpenses
        {
            Covered,
            PartiallyCovered,
            NotCovered
        }
    }
}