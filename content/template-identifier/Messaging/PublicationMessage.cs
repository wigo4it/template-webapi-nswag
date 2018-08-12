using System;

namespace template_identifier.PublicationMessage {
    public class PublicationMessage {
        public string Topic {get;set;}
        public string UserData {get;set;}
        public bool IsRetained {get;set;}
        public PublicationOptions Options {get;set;}
        public uint Level {get;set;}
        public DateTime Date {get;set;}
        public uint Sequence {get;set;}
        public string Data {get;set;}
    }

    public enum PublicationOptions
    {
        Default = 0
    }

}