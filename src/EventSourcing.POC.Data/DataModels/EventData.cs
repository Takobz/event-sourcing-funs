using System.ComponentModel.DataAnnotations.Schema;

namespace EventSourcing.POC.Data.DataModels 
{
    public class EventData 
    {

        [Column(name: "event_id")]
        public Guid EventId { get; set; } = Guid.NewGuid();

        [Column(name: "aggregate_id")]
        public Guid AggregateId { get; set; }

        [Column(name: "event_timestamp")]
        public DateTimeOffset EventTimeStamp { get; set; }

        [Column(name: "event_type")]
        public string EventType { get; set; } = string.Empty;
        
        /// <summary>
        /// Stringyfied JSON representing extra props specific to an event.
        /// </summary>
        [Column(name: "event_json_data")]
        public string EventJsonData { get; set; } = string.Empty;
    }
}