using System;

namespace MessageManager.Infrastructure
{
    public class OperationResponse<T>
    {
        public OperationResponse()
        {
        }

        public OperationResponse(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public OperationResponse(bool isSuccess, int id, string message)
            : this(isSuccess, message)
        {
            this.Id = id;
        }

        public OperationResponse(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public OperationResponse(bool isSuccess, string message, T data)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Data = data;
        }

        public OperationResponse(Exception ex)
        {
            this.IsSuccess = false;
            this.Message = ex.Message;
        }

        public int Id { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public OperationResponse<T> ShowMessage(string msg)
        {
            this.Message = msg;
            return this;
        }

        public OperationResponse GetOperationResponse()
        {
            return new OperationResponse(IsSuccess, Id, Message);
        }

        public T Data { get; set; }
    }

    public class OperationResponse : OperationResponse<object>
    {
        public OperationResponse()
        {
        }

        public OperationResponse(bool isSuccess)
            : base(isSuccess)
        {
        }

        public OperationResponse(bool isSuccess, string message)
            : base(isSuccess, message)
        {
        }

        public OperationResponse(bool isSuccess, int id, string message)
            : base(isSuccess, id, message)
        {
        }

        public OperationResponse(Exception ex)
            : base(ex)
        {
        }

        public void SetErrorMsg(string msg)
        {
            this.IsSuccess = false;
            this.Message = msg;
        }


        public static OperationResponse Error(string msg)
        {
            return new OperationResponse(false) { Message = msg };
        }

        public static OperationResponse Error(string format, string msg)
        {
            return new OperationResponse(false) { Message = String.Format(format, msg) };
        }

        public static OperationResponse Error(Exception ex)
        {
            return new OperationResponse(false) { Message = ex.ToString().Replace("\n", "<br/>") };
        }

        public static OperationResponse Success()
        {
            return new OperationResponse(true);
        }

        public static OperationResponse Success(string msg)
        {
            return new OperationResponse(true) { Message = msg };
        }

        public static OperationResponse Success(string format, string msg)
        {
            return new OperationResponse(true) { Message = String.Format(format, msg) };
        }
    }
}
