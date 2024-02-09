using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakuWakuAPI.Domain.Models;

public class User : BaseModel
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int UserDataId { get; set; }
    public UserData UserData { get; set; }
    public ICollection<Goal> Goals { get; set; }
}
