namespace ServerDto.Abstract
{
    using ServerDto.Enums;

    public abstract class Response
    {
        public MessageType MessageType { get; set; }
    }
}