using System.IO;
using Unions;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetEventsQueryParamsArg {
        /// <summary>
        /// Defines the type of events that are returned
        /// 
        /// * `all` returns everything for a user and is the default
        /// * `changes` returns events that may cause file tree changes
        ///   such as file updates or collaborations.
        /// * `sync` is similar to `changes` but only applies to synced folders
        /// * `admin_logs` returns all events for an entire enterprise and
        ///   requires the user making the API call to have admin permissions. This
        ///   stream type is for programmatically pulling from a 1 year history of
        ///   events across all users within the enterprise and within a
        ///   `created_after` and `created_before` time frame. The complete history
        ///   of events will be returned in chronological order based on the event
        ///   time, but latency will be much higher than `admin_logs_streaming`.
        /// * `admin_logs_streaming` returns all events for an entire enterprise and
        ///   requires the user making the API call to have admin permissions. This
        ///   stream type is for polling for recent events across all users within
        ///   the enterprise. Latency will be much lower than `admin_logs`, but
        ///   events will not be returned in chronological order and may
        ///   contain duplicates.
        /// </summary>
        public GetEventsQueryParamsArgStreamTypeField? StreamType { get; set; } = default;

        /// <summary>
        /// The location in the event stream to start receiving events from.
        /// 
        /// * `now` will return an empty list events and
        /// the latest stream position for initialization.
        /// * `0` or `null` will return all events.
        /// </summary>
        public string? StreamPosition { get; set; } = default;

        /// <summary>
        /// Limits the number of events returned
        /// 
        /// Note: Sometimes, the events less than the limit requested can be returned
        /// even when there may be more events remaining. This is primarily done in
        /// the case where a number of events have already been retrieved and these
        /// retrieved events are returned rather than delaying for an unknown amount
        /// of time to see if there are any more results.
        /// </summary>
        public long? Limit { get; set; } = default;

        /// <summary>
        /// A comma-separated list of events to filter by. This can only be used when
        /// requesting the events with a `stream_type` of `admin_logs` or
        /// `adming_logs_streaming`. For any other `stream_type` this value will be
        /// ignored.
        /// </summary>
        public string? EventType { get; set; } = default;

        /// <summary>
        /// The lower bound date and time to return events for. This can only be used
        /// when requesting the events with a `stream_type` of `admin_logs`. For any
        /// other `stream_type` this value will be ignored.
        /// </summary>
        public string? CreatedAfter { get; set; } = default;

        /// <summary>
        /// The upper bound date and time to return events for. This can only be used
        /// when requesting the events with a `stream_type` of `admin_logs`. For any
        /// other `stream_type` this value will be ignored.
        /// </summary>
        public string? CreatedBefore { get; set; } = default;

        public GetEventsQueryParamsArg() {
            
        }
    }
}