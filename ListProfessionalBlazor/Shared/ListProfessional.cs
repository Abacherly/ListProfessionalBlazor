using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProfessionalBlazor.Shared;

public class ListProfessional
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Years { get; set; } = string.Empty;
    public Work Work { get; set; }
    public int WorkId { get; set; }
}
