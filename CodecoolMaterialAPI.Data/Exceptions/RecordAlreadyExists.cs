namespace CodecoolMaterialsAPI.Data.Exceptions
{
    public class RecordAlreadyExists : Exception
    {
        public RecordAlreadyExists(string message) : base(message) { }
    }
}
