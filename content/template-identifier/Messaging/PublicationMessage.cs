using System;
using MessagePack;

namespace template_identifier.PublicationMessage
{
    [MessagePackObject]
    public class PublicationMessage {
        [Key(0)]
        public string CorrelationId {get;set;}
        [Key(1)]
        public string Topic {get;set;}
        [Key(2)]
        public string UserData {get;set;}
        [Key(3)]
        public bool IsRetained {get;set;}
        [Key(4)]
        public PublicationOptions Options {get;set;}
        [Key(5)]
        public uint Level {get;set;}
        [Key(6)]
        public long Ticks {get;set;}
        [Key(7)]
        public uint Sequence {get;set;}
        [Key(8)]
        public string Data {get;set;}
        [Key(9)]
        public string AccountingToken {get;set;}
        [Key(10)]
        public string IdentityData {get;set;}
        [Key(11)]
        public uint Priority {get;set;}
        [IgnoreMember]
        public DateTime Date {
            get{
                return new DateTime(Ticks);
            }
            set {
                Ticks = value.Ticks;
            }
        }
    }
}