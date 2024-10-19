using Repository.Models;
using Service.DTOs;

public class TaskDto
{

    public int TaskId { get; set; }
    public Guid? Guid { get; set; }
    public int? CustomerTblId { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int? StatusTaskTblId { get; set; }
    public string? AssignedTo { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public int? ConversationTblId { get; set; }
    public StatusTaskDto StatusTaskTbl { get; set; }
}
