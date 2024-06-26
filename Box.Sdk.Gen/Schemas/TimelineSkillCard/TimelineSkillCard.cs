using Unions;
using System.Text.Json.Serialization;
using Box.Sdk.Gen;
using Serializer;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Sdk.Gen.Schemas {
    public class TimelineSkillCard {
        /// <summary>
        /// The optional date and time this card was created at.
        /// </summary>
        [JsonPropertyName("created_at")]
        public System.DateTimeOffset? CreatedAt { get; init; }

        /// <summary>
        /// `skill_card`
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(StringEnumConverter<TimelineSkillCardTypeField>))]
        public StringEnum<TimelineSkillCardTypeField> Type { get; }

        /// <summary>
        /// `timeline`
        /// </summary>
        [JsonPropertyName("skill_card_type")]
        [JsonConverter(typeof(StringEnumConverter<TimelineSkillCardSkillCardTypeField>))]
        public StringEnum<TimelineSkillCardSkillCardTypeField> SkillCardType { get; }

        /// <summary>
        /// The title of the card.
        /// </summary>
        [JsonPropertyName("skill_card_title")]
        public TimelineSkillCardSkillCardTitleField? SkillCardTitle { get; init; }

        /// <summary>
        /// The service that applied this metadata.
        /// </summary>
        [JsonPropertyName("skill")]
        public TimelineSkillCardSkillField Skill { get; }

        /// <summary>
        /// The invocation of this service, used to track
        /// which instance of a service applied the metadata.
        /// </summary>
        [JsonPropertyName("invocation")]
        public TimelineSkillCardInvocationField Invocation { get; }

        /// <summary>
        /// An total duration in seconds of the timeline.
        /// </summary>
        [JsonPropertyName("duration")]
        public long? Duration { get; init; }

        /// <summary>
        /// A list of entries on the timeline.
        /// </summary>
        [JsonPropertyName("entries")]
        public IReadOnlyList<TimelineSkillCardEntriesField> Entries { get; }

        public TimelineSkillCard(TimelineSkillCardSkillField skill, TimelineSkillCardInvocationField invocation, IReadOnlyList<TimelineSkillCardEntriesField> entries, TimelineSkillCardTypeField type = TimelineSkillCardTypeField.SkillCard, TimelineSkillCardSkillCardTypeField skillCardType = TimelineSkillCardSkillCardTypeField.Timeline) {
            Type = type;
            SkillCardType = skillCardType;
            Skill = skill;
            Invocation = invocation;
            Entries = entries;
        }
        
        [JsonConstructorAttribute]
        internal TimelineSkillCard(TimelineSkillCardSkillField skill, TimelineSkillCardInvocationField invocation, IReadOnlyList<TimelineSkillCardEntriesField> entries, StringEnum<TimelineSkillCardTypeField> type, StringEnum<TimelineSkillCardSkillCardTypeField> skillCardType) {
            Type = TimelineSkillCardTypeField.SkillCard;
            SkillCardType = TimelineSkillCardSkillCardTypeField.Timeline;
            Skill = skill;
            Invocation = invocation;
            Entries = entries;
        }
    }
}