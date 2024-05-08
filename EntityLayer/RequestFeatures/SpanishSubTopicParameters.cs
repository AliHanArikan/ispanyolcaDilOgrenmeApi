namespace EntityLayer.RequestFeatures
{
    public class SpanishSubTopicParameters : RequestParameters
    {
        //unsigned
        public uint MinLevel {  get; set; }
        public uint MaxLevel { get; set; } = 4;

        public bool ValidLevelRange => MaxLevel > MinLevel;

    }
}
