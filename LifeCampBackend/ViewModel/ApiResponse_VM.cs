namespace LifeCamp.ViewModel
{
    public class ApiResponse_VM
    {
        public int status { get; set; }
        public long Id { get; set; }
        public string message { get; set; }
        public string Errormessage { get; set; }
        public object data { get; set; }
    }
    public class ApiResponseViewModel<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
