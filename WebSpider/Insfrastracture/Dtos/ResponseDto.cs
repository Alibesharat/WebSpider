namespace WebSpider.Insfrastracture.Dtos
{
    public  class ResponseDto<T>
    {
        public bool Statuse { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
