using EMS.DTOs;
using EMS.Entities;

namespace EMS.Mapper;

public static class JournalMapper
{
    public static ReadJournal ReadToJournal(this Journal journal)
        => new ReadJournal()
        {
            Id = journal.Id,
            EmployeeId = journal.EmployeeId,
            IsApsent = journal.IsApsent,
            Data = journal.Data,
            AmountOfLating = journal.AmountOfLating,
            Comment = journal.Comment
        };
    public static Journal UpdateToJournal(this Journal journal, UpdateJournal updateJournal)
    {
        journal.Id = updateJournal.Id;
        journal.EmployeeId = updateJournal.EmployeeId;
        journal.IsApsent = updateJournal.IsApsent;
        journal.Data = updateJournal.Data;
        journal.AmountOfLating = updateJournal.AmountOfLating;
        journal.Comment = updateJournal.Comment;
        journal.UpdatedAt = DateTime.UtcNow;
        return journal;
    }

    public static Journal CreateToJournal(this CreateJournal createJournal)
        => new Journal()
        {
            EmployeeId = createJournal.EmployeeId,
            IsApsent = createJournal.IsApsent,
            Data = createJournal.Data,
            AmountOfLating = createJournal.AmountOfLating,
            Comment = createJournal.Comment
        };

    public static Journal DeleteToJournal(this Journal journal)
    {
        journal.IsDeleted = true;
        journal.DeletedAt = DateTime.UtcNow;
        journal.UpdatedAt = DateTime.UtcNow;
        return journal;
    }
}