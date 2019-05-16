namespace EndProject.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public string Message { get; set; }

        public ResponseBase()
        {
            Message = "Opetarion success";
        }
    }
}
