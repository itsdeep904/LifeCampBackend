using System.Resources;
using System.Text;

namespace LifeCamp.ViewModel
{
    public class RequestCamp_VM
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long EmployeeId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string Date { get; set; }
        public int Status { get; set; } // 0= Active.1= inactive 
        public int OvertimeHours { get; set; }
        public long ShiftId { get; set; }
        public int IsDeleted { get; set; }
        public int Mode { get; set; }
        
    }
}
